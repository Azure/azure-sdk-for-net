namespace Azure.AI.Language.QuestionAnswering
{
    public partial class AnswersFromTextOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions>
    {
        public AnswersFromTextOptions(string question, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.TextDocument> textDocuments) { }
        public string Language { get { throw null; } set { } }
        public string Question { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.StringIndexType? StringIndexType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.TextDocument> TextDocuments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnswersFromTextResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult>
    {
        internal AnswersFromTextResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.TextAnswer> Answers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.AnswersFromTextResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.AnswersFromTextResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnswersOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersOptions>
    {
        public AnswersOptions() { }
        public Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext AnswerContext { get { throw null; } set { } }
        public double? ConfidenceThreshold { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.QueryFilters Filters { get { throw null; } set { } }
        public bool? IncludeUnstructuredSources { get { throw null; } set { } }
        public int? QnaId { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.QueryPreferences QueryPreferences { get { throw null; } set { } }
        public string Question { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.RankerKind? RankerKind { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.ShortAnswerOptions ShortAnswerOptions { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.AnswersOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.AnswersOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnswerSpan : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswerSpan>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswerSpan>
    {
        internal AnswerSpan() { }
        public double? Confidence { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.AnswerSpan System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswerSpan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswerSpan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.AnswerSpan System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswerSpan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswerSpan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswerSpan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnswersResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersResult>
    {
        internal AnswersResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer> Answers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.AnswersResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.AnswersResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.AnswersResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.AnswersResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAILanguageQuestionAnsweringContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAILanguageQuestionAnsweringContext() { }
        public static Azure.AI.Language.QuestionAnswering.AzureAILanguageQuestionAnsweringContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class KnowledgeBaseAnswer : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer>
    {
        internal KnowledgeBaseAnswer() { }
        public string Answer { get { throw null; } }
        public double? Confidence { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog Dialog { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public int? QnaId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Questions { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.AnswerSpan ShortAnswer { get { throw null; } }
        public string Source { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswerContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext>
    {
        public KnowledgeBaseAnswerContext(int previousQnaId) { }
        public int PreviousQnaId { get { throw null; } }
        public string PreviousQuestion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswerDialog : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog>
    {
        internal KnowledgeBaseAnswerDialog() { }
        public bool? IsContextOnly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt> Prompts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseAnswerPrompt : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt>
    {
        internal KnowledgeBaseAnswerPrompt() { }
        public int? DisplayOrder { get { throw null; } }
        public string DisplayText { get { throw null; } }
        public int? QnaId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicalOperationKind : System.IEquatable<Azure.AI.Language.QuestionAnswering.LogicalOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicalOperationKind(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.LogicalOperationKind AND { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.LogicalOperationKind OR { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.LogicalOperationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.LogicalOperationKind left, Azure.AI.Language.QuestionAnswering.LogicalOperationKind right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.LogicalOperationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.LogicalOperationKind left, Azure.AI.Language.QuestionAnswering.LogicalOperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MatchingPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.MatchingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MatchingPolicy>
    {
        protected MatchingPolicy() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.MatchingPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.MatchingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.MatchingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.MatchingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MatchingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MatchingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MatchingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchingPolicyFieldsType : System.IEquatable<Azure.AI.Language.QuestionAnswering.MatchingPolicyFieldsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchingPolicyFieldsType(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.MatchingPolicyFieldsType Answer { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.MatchingPolicyFieldsType Questions { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.MatchingPolicyFieldsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.MatchingPolicyFieldsType left, Azure.AI.Language.QuestionAnswering.MatchingPolicyFieldsType right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.MatchingPolicyFieldsType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.MatchingPolicyFieldsType left, Azure.AI.Language.QuestionAnswering.MatchingPolicyFieldsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetadataFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.MetadataFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MetadataFilter>
    {
        public MetadataFilter() { }
        public Azure.AI.Language.QuestionAnswering.LogicalOperationKind? LogicalOperation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.MetadataRecord> Metadata { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.MetadataFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.MetadataFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.MetadataFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.MetadataFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MetadataFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MetadataFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MetadataFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.MetadataRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MetadataRecord>
    {
        public MetadataRecord(string key, string value) { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.MetadataRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.MetadataRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.MetadataRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.MetadataRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MetadataRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MetadataRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.MetadataRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrebuiltQueryMatchingPolicy : Azure.AI.Language.QuestionAnswering.MatchingPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.PrebuiltQueryMatchingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.PrebuiltQueryMatchingPolicy>
    {
        public PrebuiltQueryMatchingPolicy() { }
        public bool? DisableFullMatch { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.MatchingPolicyFieldsType> Fields { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.PrebuiltQueryMatchingPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.PrebuiltQueryMatchingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.PrebuiltQueryMatchingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.PrebuiltQueryMatchingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.PrebuiltQueryMatchingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.PrebuiltQueryMatchingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.PrebuiltQueryMatchingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryFilters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.QueryFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.QueryFilters>
    {
        public QueryFilters() { }
        public Azure.AI.Language.QuestionAnswering.LogicalOperationKind? LogicalOperation { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.MetadataFilter MetadataFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceFilter { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.QueryFilters System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.QueryFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.QueryFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.QueryFilters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.QueryFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.QueryFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.QueryFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryPreferences : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.QueryPreferences>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.QueryPreferences>
    {
        public QueryPreferences() { }
        public Azure.AI.Language.QuestionAnswering.MatchingPolicy MatchingPolicy { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Scorer? Scorer { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.QueryPreferences System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.QueryPreferences>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.QueryPreferences>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.QueryPreferences System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.QueryPreferences>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.QueryPreferences>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.QueryPreferences>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuestionAnsweringAudience : System.IEquatable<Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuestionAnsweringAudience(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience AzureChina { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience AzureGovernment { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience left, Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience left, Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuestionAnsweringClient
    {
        protected QuestionAnsweringClient() { }
        public QuestionAnsweringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public QuestionAnsweringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions options) { }
        public QuestionAnsweringClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public QuestionAnsweringClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersResult> GetAnswers(int qnaId, Azure.AI.Language.QuestionAnswering.QuestionAnsweringProject project, Azure.AI.Language.QuestionAnswering.AnswersOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersResult> GetAnswers(string question, Azure.AI.Language.QuestionAnswering.QuestionAnsweringProject project, Azure.AI.Language.QuestionAnswering.AnswersOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersResult> GetAnswers(string projectName, string deploymentName, Azure.AI.Language.QuestionAnswering.AnswersOptions knowledgeBaseQueryOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAnswers(string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersResult>> GetAnswersAsync(int qnaId, Azure.AI.Language.QuestionAnswering.QuestionAnsweringProject project, Azure.AI.Language.QuestionAnswering.AnswersOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersResult>> GetAnswersAsync(string question, Azure.AI.Language.QuestionAnswering.QuestionAnsweringProject project, Azure.AI.Language.QuestionAnswering.AnswersOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersResult>> GetAnswersAsync(string projectName, string deploymentName, Azure.AI.Language.QuestionAnswering.AnswersOptions knowledgeBaseQueryOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnswersAsync(string projectName, string deploymentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult> GetAnswersFromText(Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions textQueryOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAnswersFromText(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult> GetAnswersFromText(string question, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.TextDocument> textDocuments, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult> GetAnswersFromText(string question, System.Collections.Generic.IEnumerable<string> textDocuments, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult>> GetAnswersFromTextAsync(Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions textQueryOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAnswersFromTextAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult>> GetAnswersFromTextAsync(string question, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.TextDocument> textDocuments, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.AnswersFromTextResult>> GetAnswersFromTextAsync(string question, System.Collections.Generic.IEnumerable<string> textDocuments, string language = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuestionAnsweringClientOptions : Azure.Core.ClientOptions
    {
        public QuestionAnsweringClientOptions(Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions.ServiceVersion version = Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions.ServiceVersion.V2025_05_15_Preview) { }
        public Azure.AI.Language.QuestionAnswering.QuestionAnsweringAudience? Audience { get { throw null; } set { } }
        public string DefaultLanguage { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2023_04_01 = 1,
            V2025_05_15_Preview = 2,
        }
    }
    public static partial class QuestionAnsweringModelFactory
    {
        public static Azure.AI.Language.QuestionAnswering.AnswersFromTextOptions AnswersFromTextOptions(string question = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.TextDocument> textDocuments = null, string language = null, Azure.AI.Language.QuestionAnswering.StringIndexType? stringIndexType = default(Azure.AI.Language.QuestionAnswering.StringIndexType?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.AnswersFromTextResult AnswersFromTextResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.TextAnswer> answers = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.AnswerSpan AnswerSpan(string text = null, double? confidence = default(double?), int? offset = default(int?), int? length = default(int?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.AnswersResult AnswersResult(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer> answers = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswer KnowledgeBaseAnswer(System.Collections.Generic.IEnumerable<string> questions = null, string answer = null, double? confidence = default(double?), int? qnaId = default(int?), string source = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog dialog = null, Azure.AI.Language.QuestionAnswering.AnswerSpan shortAnswer = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerContext KnowledgeBaseAnswerContext(int previousQnaId = 0, string previousQuestion = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerDialog KnowledgeBaseAnswerDialog(bool? isContextOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt> prompts = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.KnowledgeBaseAnswerPrompt KnowledgeBaseAnswerPrompt(int? displayOrder = default(int?), int? qnaId = default(int?), string displayText = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.ShortAnswerOptions ShortAnswerOptions(bool enable = false, double? confidenceThreshold = default(double?), int? size = default(int?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.TextAnswer TextAnswer(string answer = null, double? confidence = default(double?), string id = null, Azure.AI.Language.QuestionAnswering.AnswerSpan shortAnswer = null, int? offset = default(int?), int? length = default(int?)) { throw null; }
    }
    public partial class QuestionAnsweringProject
    {
        public QuestionAnsweringProject(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public string ProjectName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RankerKind : System.IEquatable<Azure.AI.Language.QuestionAnswering.RankerKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RankerKind(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.RankerKind Default { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.RankerKind QuestionOnly { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.RankerKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.RankerKind left, Azure.AI.Language.QuestionAnswering.RankerKind right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.RankerKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.RankerKind left, Azure.AI.Language.QuestionAnswering.RankerKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Scorer : System.IEquatable<Azure.AI.Language.QuestionAnswering.Scorer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Scorer(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Scorer Classic { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Scorer Semantic { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Scorer Transformer { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Scorer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Scorer left, Azure.AI.Language.QuestionAnswering.Scorer right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Scorer (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Scorer left, Azure.AI.Language.QuestionAnswering.Scorer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShortAnswerOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.ShortAnswerOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.ShortAnswerOptions>
    {
        public ShortAnswerOptions(bool enable) { }
        public double? ConfidenceThreshold { get { throw null; } set { } }
        public bool Enable { get { throw null; } }
        public int? Size { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.ShortAnswerOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.ShortAnswerOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.ShortAnswerOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.ShortAnswerOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.ShortAnswerOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.ShortAnswerOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.ShortAnswerOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.QuestionAnswering.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.StringIndexType TextElementsV8 { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.StringIndexType UnicodeCodePoint { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.StringIndexType left, Azure.AI.Language.QuestionAnswering.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.StringIndexType left, Azure.AI.Language.QuestionAnswering.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAnswer : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.TextAnswer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.TextAnswer>
    {
        internal TextAnswer() { }
        public string Answer { get { throw null; } }
        public double? Confidence { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.AnswerSpan ShortAnswer { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.TextAnswer System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.TextAnswer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.TextAnswer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.TextAnswer System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.TextAnswer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.TextAnswer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.TextAnswer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextDocument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.TextDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.TextDocument>
    {
        public TextDocument(string id, string text) { }
        public string Id { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.TextDocument System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.TextDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Language.QuestionAnswering.TextDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Language.QuestionAnswering.TextDocument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.TextDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.TextDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Language.QuestionAnswering.TextDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class QuestionAnsweringClientExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
