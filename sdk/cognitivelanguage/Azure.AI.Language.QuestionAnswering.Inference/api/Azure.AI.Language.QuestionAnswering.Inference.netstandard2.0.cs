namespace Azure.AI.Language.QuestionAnswering.Inference
{
    public partial class AnswersFromTextOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions>
    {
        public AnswersFromTextOptions(string question, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Inference.TextDocument> textDocuments) { }
        public string Language { get { throw null; } set { } }
        public string Question { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Inference.StringIndexType? StringIndexType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Inference.TextDocument> TextDocuments { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions answersFromTextOptions) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnswersFromTextResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult>
    {
        internal AnswersFromTextResult() { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Inference.TextAnswer> Answers { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnswersOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions>
    {
        public AnswersOptions() { }
        public Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext AnswerContext { get { throw null; } set { } }
        public double? ConfidenceThreshold { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Inference.QueryFilters Filters { get { throw null; } set { } }
        public bool? IncludeUnstructuredSources { get { throw null; } set { } }
        public int? QnaId { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences QueryPreferences { get { throw null; } set { } }
        public string Question { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Inference.RankerKind? RankerKind { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions ShortAnswerOptions { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions answersOptions) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnswerSpan : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan>
    {
        internal AnswerSpan() { }
        public double? Confidence { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnswersResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult>
    {
        internal AnswersResult() { }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer> Answers { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.AnswersResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Language.QuestionAnswering.Inference.AnswersResult (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.AnswersResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.AnswersResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.AnswersResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAILanguageQuestionAnsweringInferenceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAILanguageQuestionAnsweringInferenceContext() { }
        public static Azure.AI.Language.QuestionAnswering.Inference.AzureAILanguageQuestionAnsweringInferenceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class KnowledgeBaseAnswer : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer>
    {
        internal KnowledgeBaseAnswer() { }
        public string Answer { get { throw null; } }
        public double? Confidence { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog Dialog { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public int? QnaId { get { throw null; } }
        public System.Collections.Generic.IList<string> Questions { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan ShortAnswer { get { throw null; } }
        public string Source { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswerContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext>
    {
        public KnowledgeBaseAnswerContext(int previousQnaId) { }
        public int PreviousQnaId { get { throw null; } }
        public string PreviousQuestion { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswerDialog : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog>
    {
        internal KnowledgeBaseAnswerDialog() { }
        public bool? IsContextOnly { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt> Prompts { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswerPrompt : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt>
    {
        internal KnowledgeBaseAnswerPrompt() { }
        public int? DisplayOrder { get { throw null; } }
        public string DisplayText { get { throw null; } }
        public int? QnaId { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicalOperationKind : System.IEquatable<Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicalOperationKind(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind AND { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind OR { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind left, Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind (string value) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind left, Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MatchingPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy>
    {
        internal MatchingPolicy() { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchingPolicyFieldsType : System.IEquatable<Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchingPolicyFieldsType(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType Answer { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType Questions { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType left, Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType (string value) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType left, Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetadataFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter>
    {
        public MetadataFilter() { }
        public Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind? LogicalOperation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord> Metadata { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord>
    {
        public MetadataRecord(string key, string value) { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrebuiltQueryMatchingPolicy : Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.PrebuiltQueryMatchingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.PrebuiltQueryMatchingPolicy>
    {
        public PrebuiltQueryMatchingPolicy() { }
        public bool? DisableFullMatch { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType> Fields { get { throw null; } }
        protected override Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.PrebuiltQueryMatchingPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.PrebuiltQueryMatchingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.PrebuiltQueryMatchingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.PrebuiltQueryMatchingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.PrebuiltQueryMatchingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.PrebuiltQueryMatchingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.PrebuiltQueryMatchingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryFilters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.QueryFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.QueryFilters>
    {
        public QueryFilters() { }
        public Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind? LogicalOperation { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter MetadataFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceFilter { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.QueryFilters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.QueryFilters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.QueryFilters System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.QueryFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.QueryFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.QueryFilters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.QueryFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.QueryFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.QueryFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryPreferences : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences>
    {
        public QueryPreferences() { }
        public Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy MatchingPolicy { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Inference.Scorer? Scorer { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuestionAnsweringAudience : System.IEquatable<Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuestionAnsweringAudience(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience AzureChina { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience AzureGovernment { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience left, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience left, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuestionAnsweringClient
    {
        protected QuestionAnsweringClient() { }
        public QuestionAnsweringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public QuestionAnsweringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClientOptions options) { }
        public QuestionAnsweringClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public QuestionAnsweringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult> GetAnswers(int qnaId, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringProject project, Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions knowledgeBaseQueryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult> GetAnswers(string question, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringProject project, Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions knowledgeBaseQueryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult> GetAnswers(string projectName, string deploymentName, Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions knowledgeBaseQueryOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAnswers(string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult>> GetAnswersAsync(int qnaId, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringProject project, Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions knowledgeBaseQueryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult>> GetAnswersAsync(string question, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringProject project, Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions knowledgeBaseQueryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersResult>> GetAnswersAsync(string projectName, string deploymentName, Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions knowledgeBaseQueryOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnswersAsync(string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult> GetAnswersFromText(Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions textQueryOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAnswersFromText(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult> GetAnswersFromText(string question, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Inference.TextDocument> textDocuments, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult> GetAnswersFromText(string question, System.Collections.Generic.IEnumerable<string> textDocuments, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult>> GetAnswersFromTextAsync(Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions textQueryOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnswersFromTextAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult>> GetAnswersFromTextAsync(string question, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Inference.TextDocument> textDocuments, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult>> GetAnswersFromTextAsync(string question, System.Collections.Generic.IEnumerable<string> textDocuments, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class QuestionAnsweringClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
    public partial class QuestionAnsweringClientOptions : Azure.Core.ClientOptions
    {
        public QuestionAnsweringClientOptions(Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClientOptions.ServiceVersion version = Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringClientOptions.ServiceVersion.V2025_05_15_Preview) { }
        public Azure.AI.Language.QuestionAnswering.Inference.QuestionAnsweringAudience? Audience { get { throw null; } set { } }
        public string DefaultLanguage { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2023_04_01 = 1,
            V2025_05_15_Preview = 2,
        }
    }
    public static partial class QuestionAnsweringModelFactory
    {
        public static Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextOptions AnswersFromTextOptions(string question = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Inference.TextDocument> textDocuments = null, string language = null, Azure.AI.Language.QuestionAnswering.Inference.StringIndexType? stringIndexType = default(Azure.AI.Language.QuestionAnswering.Inference.StringIndexType?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.AnswersFromTextResult AnswersFromTextResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Inference.TextAnswer> answers = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.AnswersOptions AnswersOptions(int? qnaId = default(int?), string question = null, int? size = default(int?), string userId = null, double? confidenceThreshold = default(double?), Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext answerContext = null, Azure.AI.Language.QuestionAnswering.Inference.RankerKind? rankerKind = default(Azure.AI.Language.QuestionAnswering.Inference.RankerKind?), Azure.AI.Language.QuestionAnswering.Inference.QueryFilters filters = null, Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions shortAnswerOptions = null, bool? includeUnstructuredSources = default(bool?), Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences queryPreferences = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan AnswerSpan(string text = null, double? confidence = default(double?), int? offset = default(int?), int? length = default(int?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.AnswersResult AnswersResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer> answers = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswer KnowledgeBaseAnswer(System.Collections.Generic.IEnumerable<string> questions = null, string answer = null, double? confidence = default(double?), int? qnaId = default(int?), string source = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog dialog = null, Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan shortAnswer = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerContext KnowledgeBaseAnswerContext(int previousQnaId = 0, string previousQuestion = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerDialog KnowledgeBaseAnswerDialog(bool? isContextOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt> prompts = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.KnowledgeBaseAnswerPrompt KnowledgeBaseAnswerPrompt(int? displayOrder = default(int?), int? qnaId = default(int?), string displayText = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy MatchingPolicy(string kind = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter MetadataFilter(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord> metadata = null, Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind? logicalOperation = default(Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.MetadataRecord MetadataRecord(string key = null, string value = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.PrebuiltQueryMatchingPolicy PrebuiltQueryMatchingPolicy(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicyFieldsType> fields = null, bool? disableFullMatch = default(bool?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.QueryFilters QueryFilters(Azure.AI.Language.QuestionAnswering.Inference.MetadataFilter metadataFilter = null, System.Collections.Generic.IEnumerable<string> sourceFilter = null, Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind? logicalOperation = default(Azure.AI.Language.QuestionAnswering.Inference.LogicalOperationKind?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.QueryPreferences QueryPreferences(Azure.AI.Language.QuestionAnswering.Inference.Scorer? scorer = default(Azure.AI.Language.QuestionAnswering.Inference.Scorer?), Azure.AI.Language.QuestionAnswering.Inference.MatchingPolicy matchingPolicy = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions ShortAnswerOptions(bool enable = false, double? confidenceThreshold = default(double?), int? size = default(int?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.TextAnswer TextAnswer(string answer = null, double? confidence = default(double?), string id = null, Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan shortAnswer = null, int? offset = default(int?), int? length = default(int?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.TextDocument TextDocument(string id = null, string text = null) { throw null; }
    }
    public partial class QuestionAnsweringProject
    {
        public QuestionAnsweringProject(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public string ProjectName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RankerKind : System.IEquatable<Azure.AI.Language.QuestionAnswering.Inference.RankerKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RankerKind(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.RankerKind Default { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Inference.RankerKind QuestionOnly { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Inference.RankerKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Inference.RankerKind left, Azure.AI.Language.QuestionAnswering.Inference.RankerKind right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.RankerKind (string value) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.RankerKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Inference.RankerKind left, Azure.AI.Language.QuestionAnswering.Inference.RankerKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Scorer : System.IEquatable<Azure.AI.Language.QuestionAnswering.Inference.Scorer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Scorer(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.Scorer Classic { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Inference.Scorer Semantic { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Inference.Scorer Transformer { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Inference.Scorer other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Inference.Scorer left, Azure.AI.Language.QuestionAnswering.Inference.Scorer right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.Scorer (string value) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.Scorer? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Inference.Scorer left, Azure.AI.Language.QuestionAnswering.Inference.Scorer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShortAnswerOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions>
    {
        public ShortAnswerOptions(bool enable) { }
        public double? ConfidenceThreshold { get { throw null; } set { } }
        public bool Enable { get { throw null; } }
        public int? Size { get { throw null; } set { } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.ShortAnswerOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.QuestionAnswering.Inference.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Inference.StringIndexType TextElementsV8 { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Inference.StringIndexType UnicodeCodePoint { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Inference.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Inference.StringIndexType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Inference.StringIndexType left, Azure.AI.Language.QuestionAnswering.Inference.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.StringIndexType (string value) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Inference.StringIndexType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Inference.StringIndexType left, Azure.AI.Language.QuestionAnswering.Inference.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAnswer : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.TextAnswer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.TextAnswer>
    {
        internal TextAnswer() { }
        public string Answer { get { throw null; } }
        public double? Confidence { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Inference.AnswerSpan ShortAnswer { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.TextAnswer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.TextAnswer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.TextAnswer System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.TextAnswer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.TextAnswer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.TextAnswer System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.TextAnswer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.TextAnswer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.TextAnswer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.TextDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.TextDocument>
    {
        public TextDocument(string id, string text) { }
        public string Id { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.TextDocument JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Language.QuestionAnswering.Inference.TextDocument PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Language.QuestionAnswering.Inference.TextDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.TextDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.Inference.TextDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.Inference.TextDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.TextDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.TextDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.Inference.TextDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
