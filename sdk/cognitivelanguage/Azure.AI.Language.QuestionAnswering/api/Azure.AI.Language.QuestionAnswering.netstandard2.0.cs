namespace Azure.AI.Language.QuestionAnswering
{
    public partial class QuestionAnsweringClient
    {
        protected QuestionAnsweringClient() { }
        public QuestionAnsweringClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public QuestionAnsweringClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswers> QueryKnowledgebase(string projectName, Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseQueryOptions options, string deploymentName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswers>> QueryKnowledgebaseAsync(string projectName, Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseQueryOptions options, string deploymentName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.QuestionAnswering.Models.TextAnswers> QueryText(Azure.AI.Language.QuestionAnswering.Models.TextQueryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.QuestionAnswering.Models.TextAnswers>> QueryTextAsync(Azure.AI.Language.QuestionAnswering.Models.TextQueryOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuestionAnsweringClientOptions : Azure.Core.ClientOptions
    {
        public QuestionAnsweringClientOptions(Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions.ServiceVersion version = Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions.ServiceVersion.V2021_05_01_preview) { }
        public enum ServiceVersion
        {
            V2021_05_01_preview = 1,
        }
    }
}
namespace Azure.AI.Language.QuestionAnswering.Models
{
    public partial class AnswerSpan
    {
        internal AnswerSpan() { }
        public double? ConfidenceScore { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class AnswerSpanRequest
    {
        public AnswerSpanRequest() { }
        public double? ConfidenceScoreThreshold { get { throw null; } set { } }
        public bool? Enable { get { throw null; } set { } }
        public int? TopAnswersWithSpan { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompoundOperationType : System.IEquatable<Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompoundOperationType(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType AND { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType OR { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType left, Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType left, Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KnowledgebaseAnswer
    {
        internal KnowledgebaseAnswer() { }
        public string Answer { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Models.AnswerSpan AnswerSpan { get { throw null; } }
        public double? ConfidenceScore { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswerDialog Dialog { get { throw null; } }
        public int? Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } }
    }
    public partial class KnowledgebaseAnswerDialog
    {
        internal KnowledgebaseAnswerDialog() { }
        public bool? IsContextOnly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswerPrompt> Prompts { get { throw null; } }
    }
    public partial class KnowledgebaseAnswerPrompt
    {
        internal KnowledgebaseAnswerPrompt() { }
        public int? DisplayOrder { get { throw null; } }
        public string DisplayText { get { throw null; } }
        public int? QnaId { get { throw null; } }
    }
    public partial class KnowledgebaseAnswerRequestContext
    {
        public KnowledgebaseAnswerRequestContext(int previousQnaId) { }
        public int PreviousQnaId { get { throw null; } }
        public string PreviousUserQuery { get { throw null; } set { } }
    }
    public partial class KnowledgebaseAnswers
    {
        internal KnowledgebaseAnswers() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswer> Answers { get { throw null; } }
    }
    public partial class KnowledgebaseQueryOptions
    {
        public KnowledgebaseQueryOptions(int qnaId) { }
        public KnowledgebaseQueryOptions(string question) { }
        public Azure.AI.Language.QuestionAnswering.Models.AnswerSpanRequest AnswerSpanRequest { get { throw null; } set { } }
        public double? ConfidenceScoreThreshold { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswerRequestContext Context { get { throw null; } set { } }
        public bool? IncludeUnstructuredSources { get { throw null; } set { } }
        public int? QnaId { get { throw null; } }
        public string Question { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Models.RankerType? RankerType { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Models.StrictFilters StrictFilters { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class MetadataFilter
    {
        public MetadataFilter() { }
        public Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType? CompoundOperation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public static partial class QuestionAnsweringModelFactory
    {
        public static Azure.AI.Language.QuestionAnswering.Models.AnswerSpan AnswerSpan(string text = null, double? confidenceScore = default(double?), int? offset = default(int?), int? length = default(int?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswer KnowledgebaseAnswer(System.Collections.Generic.IEnumerable<string> questions = null, string answer = null, double? confidenceScore = default(double?), int? id = default(int?), string source = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswerDialog dialog = null, Azure.AI.Language.QuestionAnswering.Models.AnswerSpan answerSpan = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswerDialog KnowledgebaseAnswerDialog(bool? isContextOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswerPrompt> prompts = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswerPrompt KnowledgebaseAnswerPrompt(int? displayOrder = default(int?), int? qnaId = default(int?), string displayText = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswers KnowledgebaseAnswers(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Models.KnowledgebaseAnswer> answers = null) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Models.TextAnswer TextAnswer(string answer = null, double? confidenceScore = default(double?), string id = null, Azure.AI.Language.QuestionAnswering.Models.AnswerSpan answerSpan = null, int? offset = default(int?), int? length = default(int?)) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Models.TextAnswers TextAnswers(System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Models.TextAnswer> answers = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RankerType : System.IEquatable<Azure.AI.Language.QuestionAnswering.Models.RankerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RankerType(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Models.RankerType Default { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Models.RankerType QuestionOnly { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Models.RankerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Models.RankerType left, Azure.AI.Language.QuestionAnswering.Models.RankerType right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Models.RankerType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Models.RankerType left, Azure.AI.Language.QuestionAnswering.Models.RankerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StrictFilters
    {
        public StrictFilters() { }
        public Azure.AI.Language.QuestionAnswering.Models.CompoundOperationType? CompoundOperation { get { throw null; } set { } }
        public Azure.AI.Language.QuestionAnswering.Models.MetadataFilter MetadataFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceFilter { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StringIndexType : System.IEquatable<Azure.AI.Language.QuestionAnswering.Models.StringIndexType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StringIndexType(string value) { throw null; }
        public static Azure.AI.Language.QuestionAnswering.Models.StringIndexType TextElementsV8 { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Models.StringIndexType UnicodeCodePoint { get { throw null; } }
        public static Azure.AI.Language.QuestionAnswering.Models.StringIndexType Utf16CodeUnit { get { throw null; } }
        public bool Equals(Azure.AI.Language.QuestionAnswering.Models.StringIndexType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.QuestionAnswering.Models.StringIndexType left, Azure.AI.Language.QuestionAnswering.Models.StringIndexType right) { throw null; }
        public static implicit operator Azure.AI.Language.QuestionAnswering.Models.StringIndexType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.QuestionAnswering.Models.StringIndexType left, Azure.AI.Language.QuestionAnswering.Models.StringIndexType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextAnswer
    {
        internal TextAnswer() { }
        public string Answer { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Models.AnswerSpan AnswerSpan { get { throw null; } }
        public double? ConfidenceScore { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
    }
    public partial class TextAnswers
    {
        internal TextAnswers() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.QuestionAnswering.Models.TextAnswer> Answers { get { throw null; } }
    }
    public partial class TextInput
    {
        public TextInput(string id, string text) { }
        public string Id { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class TextQueryOptions
    {
        public TextQueryOptions(string question, System.Collections.Generic.IEnumerable<Azure.AI.Language.QuestionAnswering.Models.TextInput> records) { }
        public string Language { get { throw null; } set { } }
        public string Question { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Language.QuestionAnswering.Models.TextInput> Records { get { throw null; } }
        public Azure.AI.Language.QuestionAnswering.Models.StringIndexType? StringIndexType { get { throw null; } set { } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class QuestionAnsweringClientExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.QuestionAnswering.QuestionAnsweringClient, Azure.AI.Language.QuestionAnswering.QuestionAnsweringClientOptions> AddQuestionAnsweringClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
