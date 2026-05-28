namespace Azure.AI.Language.Text.Authoring
{
    public partial class AzureAILanguageTextAuthoringContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAILanguageTextAuthoringContext() { }
        public static Azure.AI.Language.Text.Authoring.AzureAILanguageTextAuthoringContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CustomEntityRecognitionDocumentEvalResult : Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionDocumentEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionDocumentEvalResult>
    {
        internal CustomEntityRecognitionDocumentEvalResult() : base (default(string), default(string)) { }
        public Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult CustomEntityRecognitionResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomEntityRecognitionDocumentEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionDocumentEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionDocumentEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomEntityRecognitionDocumentEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionDocumentEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionDocumentEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionDocumentEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomEntityRecognitionEvalSummary : Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionEvalSummary>
    {
        internal CustomEntityRecognitionEvalSummary() : base (default(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails)) { }
        public Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary CustomEntityRecognitionEvaluation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomEntityRecognitionEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomEntityRecognitionEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomEntityRecognitionEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomHealthcareDocumentEvalResult : Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomHealthcareDocumentEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomHealthcareDocumentEvalResult>
    {
        internal CustomHealthcareDocumentEvalResult() : base (default(string), default(string)) { }
        public Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult CustomHealthcareResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomHealthcareDocumentEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomHealthcareDocumentEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomHealthcareDocumentEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomHealthcareDocumentEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomHealthcareDocumentEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomHealthcareDocumentEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomHealthcareDocumentEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomHealthcareEvalSummary : Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomHealthcareEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomHealthcareEvalSummary>
    {
        internal CustomHealthcareEvalSummary() : base (default(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails)) { }
        public Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary CustomHealthcareEvaluation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomHealthcareEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomHealthcareEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomHealthcareEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomHealthcareEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomHealthcareEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomHealthcareEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomHealthcareEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomMultiLabelClassificationDocumentEvalResult : Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationDocumentEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationDocumentEvalResult>
    {
        internal CustomMultiLabelClassificationDocumentEvalResult() : base (default(string), default(string)) { }
        public Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult CustomMultiLabelClassificationResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationDocumentEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationDocumentEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationDocumentEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationDocumentEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationDocumentEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationDocumentEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationDocumentEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomMultiLabelClassificationEvalSummary : Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationEvalSummary>
    {
        internal CustomMultiLabelClassificationEvalSummary() : base (default(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails)) { }
        public Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary CustomMultiLabelClassificationEvaluation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSingleLabelClassificationDocumentEvalResult : Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationDocumentEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationDocumentEvalResult>
    {
        internal CustomSingleLabelClassificationDocumentEvalResult() : base (default(string), default(string)) { }
        public Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult CustomSingleLabelClassificationResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationDocumentEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationDocumentEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationDocumentEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationDocumentEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationDocumentEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationDocumentEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationDocumentEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomSingleLabelClassificationEvalSummary : Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationEvalSummary>
    {
        internal CustomSingleLabelClassificationEvalSummary() : base (default(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails)) { }
        public Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary CustomSingleLabelClassificationEvaluation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomTextSentimentDocumentEvalResult : Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentDocumentEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentDocumentEvalResult>
    {
        internal CustomTextSentimentDocumentEvalResult() : base (default(string), default(string)) { }
        public Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult CustomTextSentimentResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomTextSentimentDocumentEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentDocumentEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentDocumentEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomTextSentimentDocumentEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentDocumentEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentDocumentEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentDocumentEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomTextSentimentEvalSummary : Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentEvalSummary>
    {
        internal CustomTextSentimentEvalSummary() : base (default(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails)) { }
        public Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary CustomTextSentimentEvaluation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomTextSentimentEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomTextSentimentEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomTextSentimentProjectAssets : Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentProjectAssets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentProjectAssets>
    {
        public CustomTextSentimentProjectAssets() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedCustomTextSentimentDocument> Documents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomTextSentimentProjectAssets System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentProjectAssets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentProjectAssets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.CustomTextSentimentProjectAssets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentProjectAssets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentProjectAssets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.CustomTextSentimentProjectAssets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataGenerationConnectionInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo>
    {
        public DataGenerationConnectionInfo(string resourceId, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind Kind { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataGenerationConnectionInfoKind : System.IEquatable<Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataGenerationConnectionInfoKind(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind AzureOpenAI { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind left, Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind left, Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataGenerationSetting : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DataGenerationSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DataGenerationSetting>
    {
        public DataGenerationSetting(bool enableDataGeneration, Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo dataGenerationConnectionInfo) { }
        public Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo DataGenerationConnectionInfo { get { throw null; } }
        public bool EnableDataGeneration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DataGenerationSetting System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DataGenerationSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DataGenerationSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DataGenerationSetting System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DataGenerationSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DataGenerationSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DataGenerationSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentEntityLabelEvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult>
    {
        internal DocumentEntityLabelEvalResult() { }
        public string Category { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentEntityRecognitionEvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult>
    {
        internal DocumentEntityRecognitionEvalResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult> Entities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentEntityRegionEvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult>
    {
        internal DocumentEntityRegionEvalResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult> ExpectedEntities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult> PredictedEntities { get { throw null; } }
        public int RegionLength { get { throw null; } }
        public int RegionOffset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentHealthcareEvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult>
    {
        internal DocumentHealthcareEvalResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult> Entities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentMultiLabelClassificationEvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult>
    {
        internal DocumentMultiLabelClassificationEvalResult() { }
        public System.Collections.Generic.IReadOnlyList<string> ExpectedClasses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PredictedClasses { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentSentimentLabelEvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult>
    {
        internal DocumentSentimentLabelEvalResult() { }
        public Azure.AI.Language.Text.Authoring.TextAuthoringSentiment Category { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentSingleLabelClassificationEvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult>
    {
        internal DocumentSingleLabelClassificationEvalResult() { }
        public string ExpectedClass { get { throw null; } }
        public string PredictedClass { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentTextSentimentEvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult>
    {
        internal DocumentTextSentimentEvalResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult> ExpectedSentimentSpans { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult> PredictedSentimentSpans { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntityRecognitionEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary>
    {
        internal EntityRecognitionEvalSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow> ConfusionMatrix { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary> Entities { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomAbstractiveSummarizationDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument>
    {
        public ExportedCustomAbstractiveSummarizationDocument(string summaryLocation) { }
        public string Dataset { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public string SummaryLocation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomAbstractiveSummarizationProjectAsset : Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationProjectAsset>
    {
        public ExportedCustomAbstractiveSummarizationProjectAsset() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument> Documents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomEntityRecognitionDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionDocument>
    {
        public ExportedCustomEntityRecognitionDocument() { }
        public string Dataset { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion> Entities { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomEntityRecognitionProjectAsset : Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionProjectAsset>
    {
        public ExportedCustomEntityRecognitionProjectAsset() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionDocument> Documents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntity> Entities { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomEntityRecognitionProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomHealthcareDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareDocument>
    {
        public ExportedCustomHealthcareDocument() { }
        public string Dataset { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion> Entities { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomHealthcareProjectAsset : Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareProjectAsset>
    {
        public ExportedCustomHealthcareProjectAsset() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareDocument> Documents { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.TextAuthoringExportedCompositeEntity> Entities { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomHealthcareProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomMultiLabelClassificationDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationDocument>
    {
        public ExportedCustomMultiLabelClassificationDocument() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedDocumentClass> Classes { get { throw null; } }
        public string Dataset { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomMultiLabelClassificationProjectAsset : Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationProjectAsset>
    {
        public ExportedCustomMultiLabelClassificationProjectAsset() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass> Classes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationDocument> Documents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomMultiLabelClassificationProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomSingleLabelClassificationDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationDocument>
    {
        public ExportedCustomSingleLabelClassificationDocument() { }
        public Azure.AI.Language.Text.Authoring.ExportedDocumentClass Class { get { throw null; } set { } }
        public string Dataset { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomSingleLabelClassificationProjectAsset : Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationProjectAsset>
    {
        public ExportedCustomSingleLabelClassificationProjectAsset() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass> Classes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationDocument> Documents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomSingleLabelClassificationProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedCustomTextSentimentDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomTextSentimentDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomTextSentimentDocument>
    {
        public ExportedCustomTextSentimentDocument() { }
        public string Dataset { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedDocumentSentimentLabel> SentimentSpans { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomTextSentimentDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomTextSentimentDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedCustomTextSentimentDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedCustomTextSentimentDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomTextSentimentDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomTextSentimentDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedCustomTextSentimentDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedDocumentClass : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentClass>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentClass>
    {
        public ExportedDocumentClass() { }
        public string Category { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedDocumentClass System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentClass>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentClass>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedDocumentClass System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentClass>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentClass>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentClass>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedDocumentEntityLabel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityLabel>
    {
        public ExportedDocumentEntityLabel() { }
        public string Category { get { throw null; } set { } }
        public int? Length { get { throw null; } set { } }
        public int? Offset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedDocumentEntityLabel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedDocumentEntityLabel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedDocumentEntityRegion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion>
    {
        public ExportedDocumentEntityRegion() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityLabel> Labels { get { throw null; } }
        public int? RegionLength { get { throw null; } set { } }
        public int? RegionOffset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentEntityRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedDocumentSentimentLabel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentSentimentLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentSentimentLabel>
    {
        public ExportedDocumentSentimentLabel() { }
        public Azure.AI.Language.Text.Authoring.TextAuthoringSentiment? Category { get { throw null; } set { } }
        public int? Length { get { throw null; } set { } }
        public int? Offset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedDocumentSentimentLabel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentSentimentLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedDocumentSentimentLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedDocumentSentimentLabel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentSentimentLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentSentimentLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedDocumentSentimentLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportedModelManifest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedModelManifest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedModelManifest>
    {
        internal ExportedModelManifest() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.TextAuthoringModelFile> ModelFiles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedModelManifest System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedModelManifest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.ExportedModelManifest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.ExportedModelManifest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedModelManifest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedModelManifest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.ExportedModelManifest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLabelClassEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary>
    {
        internal MultiLabelClassEvalSummary() { }
        public double F1 { get { throw null; } }
        public int FalseNegativeCount { get { throw null; } }
        public int FalsePositiveCount { get { throw null; } }
        public double Precision { get { throw null; } }
        public double Recall { get { throw null; } }
        public int TrueNegativeCount { get { throw null; } }
        public int TruePositiveCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MultiLabelClassificationEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary>
    {
        internal MultiLabelClassificationEvalSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary> Classes { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SentimentEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SentimentEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SentimentEvalSummary>
    {
        internal SentimentEvalSummary() { }
        public double F1 { get { throw null; } }
        public int FalseNegativeCount { get { throw null; } }
        public int FalsePositiveCount { get { throw null; } }
        public double Precision { get { throw null; } }
        public double Recall { get { throw null; } }
        public int TrueNegativeCount { get { throw null; } }
        public int TruePositiveCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.SentimentEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SentimentEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SentimentEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.SentimentEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SentimentEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SentimentEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SentimentEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleLabelClassEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary>
    {
        internal SingleLabelClassEvalSummary() { }
        public double F1 { get { throw null; } }
        public int FalseNegativeCount { get { throw null; } }
        public int FalsePositiveCount { get { throw null; } }
        public double Precision { get { throw null; } }
        public double Recall { get { throw null; } }
        public int TrueNegativeCount { get { throw null; } }
        public int TruePositiveCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleLabelClassificationEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary>
    {
        internal SingleLabelClassificationEvalSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary> Classes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow> ConfusionMatrix { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpanSentimentEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary>
    {
        internal SpanSentimentEvalSummary() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow> ConfusionMatrix { get { throw null; } }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.SentimentEvalSummary> Sentiments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.Text.Authoring.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.StringIndexType left, Azure.AI.Language.Text.Authoring.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.StringIndexType left, Azure.AI.Language.Text.Authoring.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAnalysisAuthoringClient
    {
        protected TextAnalysisAuthoringClient() { }
        public TextAnalysisAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public TextAnalysisAuthoringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Text.Authoring.TextAnalysisAuthoringClientOptions options) { }
        public TextAnalysisAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public TextAnalysisAuthoringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.Text.Authoring.TextAnalysisAuthoringClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetAssignedResourceDeployments(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata> GetAssignedResourceDeployments(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssignedResourceDeploymentsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata> GetAssignedResourceDeploymentsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Text.Authoring.TextAuthoringDeployment GetDeployment(string projectName, string deploymentName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentResources(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource> GetDeploymentResources(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentResourcesAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource> GetDeploymentResourcesAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeployments(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment> GetDeployments(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment> GetDeploymentsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Text.Authoring.TextAuthoringExportedModel GetExportedModel(string projectName, string exportedModelName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetExportedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel> GetExportedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetExportedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel> GetExportedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Text.Authoring.TextAuthoringProject GetProject(string projectName) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata> GetProjects(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata> GetProjectsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage> GetSupportedLanguages(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind? projectKind = default(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedLanguages(string projectKind, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage> GetSupportedLanguagesAsync(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind? projectKind = default(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedLanguagesAsync(string projectKind, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSupportedPrebuiltEntities(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity> GetSupportedPrebuiltEntities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSupportedPrebuiltEntitiesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity> GetSupportedPrebuiltEntitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Language.Text.Authoring.TextAuthoringTrainedModel GetTrainedModel(string projectName, string trainedModelLabel) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainedModels(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel> GetTrainedModels(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainedModelsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel> GetTrainedModelsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion> GetTrainingConfigVersions(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind? projectKind = default(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingConfigVersions(string projectKind, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion> GetTrainingConfigVersionsAsync(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind? projectKind = default(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind?), int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingConfigVersionsAsync(string projectKind, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTrainingJobs(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState> GetTrainingJobs(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTrainingJobsAsync(string projectName, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState> GetTrainingJobsAsync(string projectName, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TextAnalysisAuthoringClientOptions : Azure.Core.ClientOptions
    {
        public TextAnalysisAuthoringClientOptions(Azure.AI.Language.Text.Authoring.TextAnalysisAuthoringClientOptions.ServiceVersion version = Azure.AI.Language.Text.Authoring.TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview) { }
        public enum ServiceVersion
        {
            V2023_04_01 = 1,
            V2024_11_15_Preview = 2,
            V2025_05_15_Preview = 3,
        }
    }
    public static partial class TextAnalysisAuthoringModelFactory
    {
        public static Azure.AI.Language.Text.Authoring.CustomEntityRecognitionDocumentEvalResult CustomEntityRecognitionDocumentEvalResult(string location = null, string language = null, Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult customEntityRecognitionResult = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.CustomEntityRecognitionEvalSummary CustomEntityRecognitionEvalSummary(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary customEntityRecognitionEvaluation = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.CustomHealthcareDocumentEvalResult CustomHealthcareDocumentEvalResult(string location = null, string language = null, Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult customHealthcareResult = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.CustomHealthcareEvalSummary CustomHealthcareEvalSummary(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary customHealthcareEvaluation = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationDocumentEvalResult CustomMultiLabelClassificationDocumentEvalResult(string location = null, string language = null, Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult customMultiLabelClassificationResult = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.CustomMultiLabelClassificationEvalSummary CustomMultiLabelClassificationEvalSummary(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary customMultiLabelClassificationEvaluation = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationDocumentEvalResult CustomSingleLabelClassificationDocumentEvalResult(string location = null, string language = null, Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult customSingleLabelClassificationResult = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.CustomSingleLabelClassificationEvalSummary CustomSingleLabelClassificationEvalSummary(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary customSingleLabelClassificationEvaluation = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.CustomTextSentimentDocumentEvalResult CustomTextSentimentDocumentEvalResult(string location = null, string language = null, Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult customTextSentimentResult = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.CustomTextSentimentEvalSummary CustomTextSentimentEvalSummary(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary customTextSentimentEvaluation = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfo DataGenerationConnectionInfo(Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind kind = default(Azure.AI.Language.Text.Authoring.DataGenerationConnectionInfoKind), string resourceId = null, string deploymentName = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult DocumentEntityLabelEvalResult(string category = null, int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.DocumentEntityRecognitionEvalResult DocumentEntityRecognitionEvalResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult> entities = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult DocumentEntityRegionEvalResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult> expectedEntities = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.DocumentEntityLabelEvalResult> predictedEntities = null, int regionOffset = 0, int regionLength = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.DocumentHealthcareEvalResult DocumentHealthcareEvalResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.DocumentEntityRegionEvalResult> entities = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.DocumentMultiLabelClassificationEvalResult DocumentMultiLabelClassificationEvalResult(System.Collections.Generic.IEnumerable<string> expectedClasses = null, System.Collections.Generic.IEnumerable<string> predictedClasses = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult DocumentSentimentLabelEvalResult(Azure.AI.Language.Text.Authoring.TextAuthoringSentiment category = default(Azure.AI.Language.Text.Authoring.TextAuthoringSentiment), int offset = 0, int length = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.DocumentSingleLabelClassificationEvalResult DocumentSingleLabelClassificationEvalResult(string expectedClass = null, string predictedClass = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.DocumentTextSentimentEvalResult DocumentTextSentimentEvalResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult> expectedSentimentSpans = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.DocumentSentimentLabelEvalResult> predictedSentimentSpans = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.EntityRecognitionEvalSummary EntityRecognitionEvalSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow> confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary> entities = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.ExportedCustomAbstractiveSummarizationDocument ExportedCustomAbstractiveSummarizationDocument(string summaryLocation = null, string location = null, string language = null, string dataset = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.ExportedModelManifest ExportedModelManifest(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.TextAuthoringModelFile> modelFiles = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary MultiLabelClassEvalSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.MultiLabelClassificationEvalSummary MultiLabelClassificationEvalSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.MultiLabelClassEvalSummary> classes = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.SentimentEvalSummary SentimentEvalSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary SingleLabelClassEvalSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.SingleLabelClassificationEvalSummary SingleLabelClassificationEvalSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow> confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.SingleLabelClassEvalSummary> classes = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary SpanSentimentEvalSummary(System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow> confusionMatrix = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Text.Authoring.SentimentEvalSummary> sentiments = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource TextAuthoringAssignedDeploymentResource(string azureResourceId = null, Azure.Core.AzureLocation region = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata TextAuthoringAssignedProjectDeploymentMetadata(string deploymentName = null, System.DateTimeOffset lastDeployedOn = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata TextAuthoringAssignedProjectDeploymentsMetadata(string projectName = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata> deploymentsMetadata = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixCell TextAuthoringConfusionMatrixCell(float normalizedValue = 0f, float rawValue = 0f) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow TextAuthoringConfusionMatrixRow(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState TextAuthoringCopyProjectState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails TextAuthoringCreateDeploymentDetails(string trainedModelLabel = null, System.Collections.Generic.IEnumerable<string> assignedResourceIds = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails TextAuthoringCreateProjectDetails(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind projectKind = default(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind), string storageInputContainerName = null, Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings settings = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState TextAuthoringDeploymentDeleteFromResourcesState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource TextAuthoringDeploymentResource(string resourceId = null, string region = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState TextAuthoringDeploymentResourcesState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState TextAuthoringDeploymentState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult TextAuthoringDocumentEvalResult(string projectKind = null, string location = null, string language = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary TextAuthoringEntityEvalSummary(double f1 = 0, double precision = 0, double recall = 0, int truePositiveCount = 0, int trueNegativeCount = 0, int falsePositiveCount = 0, int falseNegativeCount = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary TextAuthoringEvalSummary(string projectKind = null, Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails evaluationOptions = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult TextAuthoringEvaluationJobResult(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails evaluationOptions = null, string modelLabel = null, string trainingConfigVersion = null, int percentComplete = 0) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState TextAuthoringEvaluationState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult result = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState TextAuthoringExportedModelState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject TextAuthoringExportedProject(string projectFileVersion = null, Azure.AI.Language.Text.Authoring.StringIndexType stringIndexType = default(Azure.AI.Language.Text.Authoring.StringIndexType), Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails metadata = null, Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset assets = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel TextAuthoringExportedTrainedModel(string exportedModelName = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), System.DateTimeOffset lastExportedModelOn = default(System.DateTimeOffset), System.DateTimeOffset modelExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState TextAuthoringExportProjectState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, string resultUrl = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState TextAuthoringImportProjectState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState TextAuthoringLoadSnapshotState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringModelFile TextAuthoringModelFile(string name = null, System.Uri contentUri = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity TextAuthoringPrebuiltEntity(string category = null, string description = null, string examples = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState TextAuthoringProjectDeletionState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment TextAuthoringProjectDeployment(string deploymentName = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), System.DateTimeOffset lastDeployedOn = default(System.DateTimeOffset), System.DateTimeOffset deploymentExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource> assignedResources = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata TextAuthoringProjectMetadata(System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedOn = default(System.DateTimeOffset), System.DateTimeOffset? lastTrainedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastDeployedOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind projectKind = default(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind), string storageInputContainerName = null, Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings settings = null, string projectName = null, bool? multilingual = default(bool?), string description = null, string language = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel TextAuthoringProjectTrainedModel(string label = null, string modelId = null, System.DateTimeOffset lastTrainedOn = default(System.DateTimeOffset), int lastTrainingDurationInSeconds = 0, System.DateTimeOffset modelExpiredOn = default(System.DateTimeOffset), string modelTrainingConfigVersion = null, bool hasSnapshot = false) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState TextAuthoringSubTrainingState(int percentComplete = 0, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus)) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage TextAuthoringSupportedLanguage(string languageName = null, string languageCode = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState TextAuthoringSwapDeploymentsState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion TextAuthoringTrainingConfigVersion(string trainingConfigVersion = null, System.DateTimeOffset modelExpiredOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails TextAuthoringTrainingJobDetails(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails evaluationOptions = null, Azure.AI.Language.Text.Authoring.DataGenerationSetting dataGenerationSettings = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult TextAuthoringTrainingJobResult(string modelLabel = null, string trainingConfigVersion = null, Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState trainingStatus = null, Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState evaluationStatus = null, System.DateTimeOffset? estimatedEndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState TextAuthoringTrainingState(string jobId = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus status = default(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus), System.Collections.Generic.IEnumerable<Azure.ResponseError> warnings = null, System.Collections.Generic.IEnumerable<Azure.ResponseError> errors = null, Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult result = null) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary TextSentimentEvalSummary(Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary spanSentimentsEvaluation = null, float microF1 = 0f, float microPrecision = 0f, float microRecall = 0f, float macroF1 = 0f, float macroPrecision = 0f, float macroRecall = 0f) { throw null; }
    }
    public partial class TextAuthoringAssignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails>
    {
        public TextAuthoringAssignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata> resourcesMetadata) { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata> ResourcesMetadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringAssignedDeploymentResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource>
    {
        internal TextAuthoringAssignedDeploymentResource() { }
        public string AzureResourceId { get { throw null; } }
        public Azure.Core.AzureLocation Region { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedDeploymentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringAssignedProjectDeploymentMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata>
    {
        internal TextAuthoringAssignedProjectDeploymentMetadata() { }
        public System.DateTimeOffset DeploymentExpiresOn { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringAssignedProjectDeploymentsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata>
    {
        internal TextAuthoringAssignedProjectDeploymentsMetadata() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentMetadata> DeploymentsMetadata { get { throw null; } }
        public string ProjectName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringAssignedProjectDeploymentsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAuthoringCompositionMode : System.IEquatable<Azure.AI.Language.Text.Authoring.TextAuthoringCompositionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextAuthoringCompositionMode(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringCompositionMode CombineComponents { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringCompositionMode SeparateComponents { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.TextAuthoringCompositionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.TextAuthoringCompositionMode left, Azure.AI.Language.Text.Authoring.TextAuthoringCompositionMode right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.TextAuthoringCompositionMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.TextAuthoringCompositionMode left, Azure.AI.Language.Text.Authoring.TextAuthoringCompositionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAuthoringConfusionMatrixCell : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixCell>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixCell>
    {
        internal TextAuthoringConfusionMatrixCell() { }
        public float NormalizedValue { get { throw null; } }
        public float RawValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixCell System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixCell>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixCell>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixCell System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixCell>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixCell>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixCell>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringConfusionMatrixRow : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow>
    {
        internal TextAuthoringConfusionMatrixRow() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringConfusionMatrixRow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringCopyProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails>
    {
        public TextAuthoringCopyProjectDetails(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind projectKind, string targetProjectName, string accessToken, System.DateTimeOffset expiresAt, string targetResourceId, string targetResourceRegion) { }
        public string AccessToken { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresAt { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind ProjectKind { get { throw null; } set { } }
        public string TargetProjectName { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TargetResourceRegion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringCopyProjectState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState>
    {
        internal TextAuthoringCopyProjectState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringCreateDeploymentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails>
    {
        public TextAuthoringCreateDeploymentDetails(string trainedModelLabel) { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        public string TrainedModelLabel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringCreateProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails>
    {
        public TextAuthoringCreateProjectDetails(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind projectKind, string storageInputContainerName, string language) { }
        public string Description { get { throw null; } set { } }
        public string Language { get { throw null; } }
        public bool? Multilingual { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind ProjectKind { get { throw null; } }
        public string ProjectName { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings Settings { get { throw null; } set { } }
        public string StorageInputContainerName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringDeleteDeploymentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails>
    {
        public TextAuthoringDeleteDeploymentDetails() { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringDeployment
    {
        protected TextAuthoringDeployment() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation DeleteDeployment(Azure.WaitUntil waitUntil, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation DeleteDeployment(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeleteDeploymentFromResources(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringDeleteDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDeploymentFromResourcesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation DeployProject(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringCreateDeploymentDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployProjectAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeployment(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment> GetDeployment(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment>> GetDeploymentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentDeleteFromResourcesStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState> GetDeploymentDeleteFromResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentDeleteFromResourcesStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState>> GetDeploymentDeleteFromResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeploymentStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState> GetDeploymentStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState>> GetDeploymentStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TextAuthoringDeploymentDeleteFromResourcesState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState>
    {
        internal TextAuthoringDeploymentDeleteFromResourcesState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentDeleteFromResourcesState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringDeploymentResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource>
    {
        internal TextAuthoringDeploymentResource() { }
        public string Region { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringDeploymentResourcesState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState>
    {
        internal TextAuthoringDeploymentResourcesState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringDeploymentState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState>
    {
        internal TextAuthoringDeploymentState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TextAuthoringDocumentEvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult>
    {
        protected TextAuthoringDocumentEvalResult(string location, string language) { }
        public string Language { get { throw null; } }
        public string Location { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringEntityEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary>
    {
        internal TextAuthoringEntityEvalSummary() { }
        public double F1 { get { throw null; } }
        public int FalseNegativeCount { get { throw null; } }
        public int FalsePositiveCount { get { throw null; } }
        public double Precision { get { throw null; } }
        public double Recall { get { throw null; } }
        public int TrueNegativeCount { get { throw null; } }
        public int TruePositiveCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEntityEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TextAuthoringEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary>
    {
        protected TextAuthoringEvalSummary(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails evaluationOptions) { }
        public Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails EvaluationOptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringEvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails>
    {
        public TextAuthoringEvaluationDetails() { }
        public Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationKind? Kind { get { throw null; } set { } }
        public int? TestingSplitPercentage { get { throw null; } set { } }
        public int? TrainingSplitPercentage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringEvaluationJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult>
    {
        internal TextAuthoringEvaluationJobResult() { }
        public Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails EvaluationOptions { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAuthoringEvaluationKind : System.IEquatable<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextAuthoringEvaluationKind(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationKind Manual { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationKind Percentage { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationKind left, Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationKind left, Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAuthoringEvaluationState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState>
    {
        internal TextAuthoringEvaluationState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult Result { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedClass : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass>
    {
        public TextAuthoringExportedClass() { }
        public string Category { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedClass>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedCompositeEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedCompositeEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedCompositeEntity>
    {
        public TextAuthoringExportedCompositeEntity() { }
        public string Category { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringCompositionMode? CompositionSetting { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityList List { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.TextAuthoringExportedPrebuiltEntity> Prebuilts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedCompositeEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedCompositeEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedCompositeEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedCompositeEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedCompositeEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedCompositeEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedCompositeEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntity>
    {
        public TextAuthoringExportedEntity() { }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedEntityList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityList>
    {
        public TextAuthoringExportedEntityList() { }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntitySublist> Sublists { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityList System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedEntityListSynonym : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityListSynonym>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityListSynonym>
    {
        public TextAuthoringExportedEntityListSynonym() { }
        public string Language { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityListSynonym System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityListSynonym>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityListSynonym>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityListSynonym System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityListSynonym>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityListSynonym>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityListSynonym>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedEntitySublist : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntitySublist>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntitySublist>
    {
        public TextAuthoringExportedEntitySublist() { }
        public string ListKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntityListSynonym> Synonyms { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntitySublist System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntitySublist>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntitySublist>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntitySublist System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntitySublist>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntitySublist>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedEntitySublist>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedModel
    {
        protected TextAuthoringExportedModel() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CreateOrUpdateExportedModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CreateOrUpdateExportedModelAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteExportedModel(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteExportedModel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteExportedModelAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteExportedModelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModel(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel> GetExportedModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel>> GetExportedModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModelJobStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState> GetExportedModelJobStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelJobStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState>> GetExportedModelJobStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportedModelManifest(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.ExportedModelManifest> GetExportedModelManifest(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportedModelManifestAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.ExportedModelManifest>> GetExportedModelManifestAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TextAuthoringExportedModelDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails>
    {
        public TextAuthoringExportedModelDetails(string trainedModelLabel) { }
        public string TrainedModelLabel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedModelState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState>
    {
        internal TextAuthoringExportedModelState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedModelState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedPrebuiltEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedPrebuiltEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedPrebuiltEntity>
    {
        public TextAuthoringExportedPrebuiltEntity(string category) { }
        public string Category { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedPrebuiltEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedPrebuiltEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedPrebuiltEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedPrebuiltEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedPrebuiltEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedPrebuiltEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedPrebuiltEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedProject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject>
    {
        public TextAuthoringExportedProject(string projectFileVersion, Azure.AI.Language.Text.Authoring.StringIndexType stringIndexType, Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails metadata) { }
        public Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset Assets { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails Metadata { get { throw null; } }
        public string ProjectFileVersion { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.StringIndexType StringIndexType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TextAuthoringExportedProjectAsset : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset>
    {
        protected TextAuthoringExportedProjectAsset() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedProjectAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportedTrainedModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel>
    {
        internal TextAuthoringExportedTrainedModel() { }
        public string ExportedModelName { get { throw null; } }
        public System.DateTimeOffset LastExportedModelOn { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public System.DateTimeOffset ModelExpiredOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportedTrainedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringExportProjectState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState>
    {
        internal TextAuthoringExportProjectState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string ResultUrl { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringImportProjectState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState>
    {
        internal TextAuthoringImportProjectState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringLoadSnapshotState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState>
    {
        internal TextAuthoringLoadSnapshotState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringModelFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringModelFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringModelFile>
    {
        internal TextAuthoringModelFile() { }
        public System.Uri ContentUri { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringModelFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringModelFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringModelFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringModelFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringModelFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringModelFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringModelFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAuthoringOperationStatus : System.IEquatable<Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextAuthoringOperationStatus(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Cancelled { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Cancelling { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Failed { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus NotStarted { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus PartiallyCompleted { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Running { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus left, Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus left, Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAuthoringPrebuiltEntity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity>
    {
        internal TextAuthoringPrebuiltEntity() { }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public string Examples { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringPrebuiltEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringProject
    {
        protected TextAuthoringProject() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation AssignDeploymentResources(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringAssignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> AssignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails> AuthorizeProjectCopy(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeProjectCopy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails>> AuthorizeProjectCopyAsync(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind projectKind, string storageInputContainerName = null, bool? allowOverwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeProjectCopyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CancelTrainingJob(Azure.WaitUntil waitUntil, string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult> CancelTrainingJob(Azure.WaitUntil waitUntil, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult>> CancelTrainingJobAsync(Azure.WaitUntil waitUntil, string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation CopyProject(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CopyProjectAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateProject(Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateProject(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(Azure.AI.Language.Text.Authoring.TextAuthoringCreateProjectDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateProjectAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteProject(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteProjectAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.StringIndexType stringIndexType, string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Export(Azure.WaitUntil waitUntil, string stringIndexType, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.StringIndexType stringIndexType, string assetKind = null, string trainedModelLabel = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ExportAsync(Azure.WaitUntil waitUntil, string stringIndexType, string assetKind = null, string trainedModelLabel = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAssignDeploymentResourcesStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState> GetAssignDeploymentResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssignDeploymentResourcesStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState>> GetAssignDeploymentResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCopyProjectStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState> GetCopyProjectStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCopyProjectStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringCopyProjectState>> GetCopyProjectStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExportStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState> GetExportStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExportStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringExportProjectState>> GetExportStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetImportStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState> GetImportStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetImportStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringImportProjectState>> GetImportStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProject(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata> GetProject(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata>> GetProjectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetProjectDeletionStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState> GetProjectDeletionStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectDeletionStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState>> GetProjectDeletionStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSwapDeploymentsStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState> GetSwapDeploymentsStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSwapDeploymentsStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState>> GetSwapDeploymentsStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainingStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState> GetTrainingStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState>> GetTrainingStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUnassignDeploymentResourcesStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState> GetUnassignDeploymentResourcesStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUnassignDeploymentResourcesStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResourcesState>> GetUnassignDeploymentResourcesStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject body, string format = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string format = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Import(Azure.WaitUntil waitUntil, string projectJson, string format = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringExportedProject body, string format = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, string format = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportAsync(Azure.WaitUntil waitUntil, string projectJson, string format = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation SwapDeployments(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SwapDeploymentsAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult> Train(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Train(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult>> TrainAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> TrainAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation UnassignDeploymentResources(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> UnassignDeploymentResourcesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class TextAuthoringProjectDeletionState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState>
    {
        internal TextAuthoringProjectDeletionState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeletionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringProjectDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment>
    {
        internal TextAuthoringProjectDeployment() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Text.Authoring.TextAuthoringDeploymentResource> AssignedResources { get { throw null; } }
        public System.DateTimeOffset DeploymentExpiredOn { get { throw null; } }
        public string DeploymentName { get { throw null; } }
        public System.DateTimeOffset LastDeployedOn { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAuthoringProjectKind : System.IEquatable<Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextAuthoringProjectKind(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind CustomAbstractiveSummarization { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind CustomEntityRecognition { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind CustomHealthcare { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind CustomMultiLabelClassification { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind CustomSingleLabelClassification { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind CustomTextSentiment { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind left, Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind left, Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAuthoringProjectMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata>
    {
        internal TextAuthoringProjectMetadata() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string Language { get { throw null; } }
        public System.DateTimeOffset? LastDeployedOn { get { throw null; } }
        public System.DateTimeOffset LastModifiedOn { get { throw null; } }
        public System.DateTimeOffset? LastTrainedOn { get { throw null; } }
        public bool? Multilingual { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringProjectKind ProjectKind { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings Settings { get { throw null; } }
        public string StorageInputContainerName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringProjectSettings : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings>
    {
        public TextAuthoringProjectSettings() { }
        public string AmlProjectPath { get { throw null; } set { } }
        public float? ConfidenceThreshold { get { throw null; } set { } }
        public int? GptPredictiveLookahead { get { throw null; } set { } }
        public bool? IsLabelingLocked { get { throw null; } set { } }
        public bool? RunGptPredictions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringProjectTrainedModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel>
    {
        internal TextAuthoringProjectTrainedModel() { }
        public bool HasSnapshot { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset LastTrainedOn { get { throw null; } }
        public int LastTrainingDurationInSeconds { get { throw null; } }
        public System.DateTimeOffset ModelExpiredOn { get { throw null; } }
        public string ModelId { get { throw null; } }
        public string ModelTrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringResourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata>
    {
        public TextAuthoringResourceMetadata(string azureResourceId, string customDomain, string region) { }
        public string AzureResourceId { get { throw null; } }
        public string CustomDomain { get { throw null; } }
        public string Region { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextAuthoringSentiment : System.IEquatable<Azure.AI.Language.Text.Authoring.TextAuthoringSentiment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextAuthoringSentiment(string value) { throw null; }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringSentiment Negative { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringSentiment Neutral { get { throw null; } }
        public static Azure.AI.Language.Text.Authoring.TextAuthoringSentiment Positive { get { throw null; } }
        public bool Equals(Azure.AI.Language.Text.Authoring.TextAuthoringSentiment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Text.Authoring.TextAuthoringSentiment left, Azure.AI.Language.Text.Authoring.TextAuthoringSentiment right) { throw null; }
        public static implicit operator Azure.AI.Language.Text.Authoring.TextAuthoringSentiment (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Text.Authoring.TextAuthoringSentiment left, Azure.AI.Language.Text.Authoring.TextAuthoringSentiment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAuthoringSubTrainingState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState>
    {
        internal TextAuthoringSubTrainingState() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public int PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringSupportedLanguage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage>
    {
        internal TextAuthoringSupportedLanguage() { }
        public string LanguageCode { get { throw null; } }
        public string LanguageName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSupportedLanguage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringSwapDeploymentsDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails>
    {
        public TextAuthoringSwapDeploymentsDetails(string firstDeploymentName, string secondDeploymentName) { }
        public string FirstDeploymentName { get { throw null; } }
        public string SecondDeploymentName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringSwapDeploymentsState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState>
    {
        internal TextAuthoringSwapDeploymentsState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringSwapDeploymentsState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringTrainedModel
    {
        protected TextAuthoringTrainedModel() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteTrainedModel(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteTrainedModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrainedModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult> EvaluateModel(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> EvaluateModel(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationJobResult>> EvaluateModelAsync(Azure.WaitUntil waitUntil, Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails details, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> EvaluateModelAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEvaluationStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState> GetEvaluationStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationState>> GetEvaluationStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLoadSnapshotStatus(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState> GetLoadSnapshotStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLoadSnapshotStatusAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringLoadSnapshotState>> GetLoadSnapshotStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetModelEvalSummary(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelEvalSummaryAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary>> GetModelEvalSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult> GetModelEvaluationResults(Azure.AI.Language.Text.Authoring.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetModelEvaluationResults(string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Language.Text.Authoring.TextAuthoringDocumentEvalResult> GetModelEvaluationResultsAsync(Azure.AI.Language.Text.Authoring.StringIndexType stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetModelEvaluationResultsAsync(string stringIndexType, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetModelEvaluationSummary(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary> GetModelEvaluationSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetModelEvaluationSummaryAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary>> GetModelEvaluationSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringEvalSummary> GetModelTextAuthoringEvalSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainedModel(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel> GetTrainedModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainedModelAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Text.Authoring.TextAuthoringProjectTrainedModel>> GetTrainedModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation LoadSnapshot(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> LoadSnapshotAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TextAuthoringTrainingConfigVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion>
    {
        internal TextAuthoringTrainingConfigVersion() { }
        public System.DateTimeOffset ModelExpiredOn { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingConfigVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringTrainingJobDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails>
    {
        public TextAuthoringTrainingJobDetails(string modelLabel, string trainingConfigVersion) { }
        public Azure.AI.Language.Text.Authoring.DataGenerationSetting DataGenerationSettings { get { throw null; } set { } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringEvaluationDetails EvaluationOptions { get { throw null; } set { } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringTrainingJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult>
    {
        internal TextAuthoringTrainingJobResult() { }
        public System.DateTimeOffset? EstimatedEndOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState EvaluationStatus { get { throw null; } }
        public string ModelLabel { get { throw null; } }
        public string TrainingConfigVersion { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringSubTrainingState TrainingStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringTrainingState : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState>
    {
        internal TextAuthoringTrainingState() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Errors { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringTrainingJobResult Result { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.TextAuthoringOperationStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> Warnings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringTrainingState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAuthoringUnassignDeploymentResourcesDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails>
    {
        public TextAuthoringUnassignDeploymentResourcesDetails(System.Collections.Generic.IEnumerable<string> assignedResourceIds) { }
        public System.Collections.Generic.IList<string> AssignedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextAuthoringUnassignDeploymentResourcesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextSentimentEvalSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary>
    {
        internal TextSentimentEvalSummary() { }
        public float MacroF1 { get { throw null; } }
        public float MacroPrecision { get { throw null; } }
        public float MacroRecall { get { throw null; } }
        public float MicroF1 { get { throw null; } }
        public float MicroPrecision { get { throw null; } }
        public float MicroRecall { get { throw null; } }
        public Azure.AI.Language.Text.Authoring.SpanSentimentEvalSummary SpanSentimentsEvaluation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.Text.Authoring.TextSentimentEvalSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class TextAuthoringClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.Authoring.TextAnalysisAuthoringClient, Azure.AI.Language.Text.Authoring.TextAnalysisAuthoringClientOptions> AddTextAnalysisAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.Authoring.TextAnalysisAuthoringClient, Azure.AI.Language.Text.Authoring.TextAnalysisAuthoringClientOptions> AddTextAnalysisAuthoringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Text.Authoring.TextAnalysisAuthoringClient, Azure.AI.Language.Text.Authoring.TextAnalysisAuthoringClientOptions> AddTextAnalysisAuthoringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
