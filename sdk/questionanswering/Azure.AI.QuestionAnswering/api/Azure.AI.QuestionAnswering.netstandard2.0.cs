namespace Azure.AI.QuestionAnswering
{
    public partial class KnowledgebaseClient
    {
        protected KnowledgebaseClient() { }
        public KnowledgebaseClient(System.Uri endpoint, string knowledgebaseId, Azure.AzureKeyCredential credential) { }
        public KnowledgebaseClient(System.Uri endpoint, string knowledgebaseId, Azure.AzureKeyCredential credential, Azure.AI.QuestionAnswering.QuestionAnsweringClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual string KnowledgebaseId { get { throw null; } }
        public virtual Azure.Response<Azure.AI.QuestionAnswering.Models.Knowledgebase> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.QuestionAnswering.Models.Knowledgebase>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuestionAnsweringClientOptions : Azure.Core.ClientOptions
    {
        public QuestionAnsweringClientOptions(Azure.AI.QuestionAnswering.QuestionAnsweringClientOptions.ServiceVersion version = Azure.AI.QuestionAnswering.QuestionAnsweringClientOptions.ServiceVersion.V5_0_Preview_2) { }
        public Azure.AI.QuestionAnswering.QuestionAnsweringClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V5_0_Preview_2 = 1,
        }
    }
    public partial class QuestionAnsweringServiceClient
    {
        protected QuestionAnsweringServiceClient() { }
        public QuestionAnsweringServiceClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public QuestionAnsweringServiceClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.QuestionAnswering.QuestionAnsweringClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.AI.QuestionAnswering.Models.KnowledgebaseOperation CreateKnowledgebase(Azure.AI.QuestionAnswering.Models.CreateKnowledgebaseParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.QuestionAnswering.Models.KnowledgebaseOperation> CreateKnowledgebaseAsync(Azure.AI.QuestionAnswering.Models.CreateKnowledgebaseParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.QuestionAnswering.Models.EndpointKeys> GetEndpointKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.QuestionAnswering.Models.EndpointKeys>> GetEndpointKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.QuestionAnswering.KnowledgebaseClient GetKnowledgebaseClient(string knowledgebaseId) { throw null; }
        public virtual Azure.Response<Azure.AI.QuestionAnswering.Models.EndpointKeys> RefreshEndpointKeys(string keyType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.QuestionAnswering.Models.EndpointKeys>> RefreshEndpointKeysAsync(string keyType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.AI.QuestionAnswering.Models
{
    public partial class AnswerPrompt
    {
        public AnswerPrompt() { }
        public int? DisplayOrder { get { throw null; } set { } }
        public string DisplayText { get { throw null; } set { } }
        public Azure.AI.QuestionAnswering.Models.AnswerPromptQna Qna { get { throw null; } set { } }
        public int? QnaId { get { throw null; } set { } }
    }
    public partial class AnswerPromptQna : Azure.AI.QuestionAnswering.Models.QuestionAnswerContent
    {
        public AnswerPromptQna(string answer, System.Collections.Generic.IEnumerable<string> questions) : base (default(string), default(System.Collections.Generic.IEnumerable<string>)) { }
    }
    public partial class CreateKnowledgebaseContents
    {
        public CreateKnowledgebaseContents() { }
        public System.Collections.Generic.IList<Azure.AI.QuestionAnswering.Models.KnowledgebaseFileContent> Files { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.QuestionAnswering.Models.QuestionAnswerContent> QuestionAnswers { get { throw null; } }
        public System.Collections.Generic.IList<System.Uri> Uris { get { throw null; } }
    }
    public partial class CreateKnowledgebaseParameters
    {
        public CreateKnowledgebaseParameters(string name) { }
        public string DefaultAnswer { get { throw null; } set { } }
        public string DefaultAnswerUsedForExtraction { get { throw null; } set { } }
        public bool? EnableHierarchicalExtraction { get { throw null; } set { } }
        public bool? EnableMultipleLanguages { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.QuestionAnswering.Models.KnowledgebaseFileContent> Files { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.QuestionAnswering.Models.QuestionAnswerContent> QuestionAnswers { get { throw null; } }
        public System.Collections.Generic.IList<System.Uri> Uris { get { throw null; } }
    }
    public partial class DeleteKnowledgebaseContents
    {
        public DeleteKnowledgebaseContents() { }
        public System.Collections.Generic.IList<int> Ids { get { throw null; } }
        public System.Collections.Generic.IList<string> Sources { get { throw null; } }
    }
    public partial class EndpointKeys
    {
        internal EndpointKeys() { }
        public string InstalledVersion { get { throw null; } }
        public string Language { get { throw null; } }
        public string LastStableVersion { get { throw null; } }
        public string PrimaryEndpointKey { get { throw null; } }
        public string SecondaryEndpointKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentType : System.IEquatable<Azure.AI.QuestionAnswering.Models.EnvironmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentType(string value) { throw null; }
        public static Azure.AI.QuestionAnswering.Models.EnvironmentType Prod { get { throw null; } }
        public static Azure.AI.QuestionAnswering.Models.EnvironmentType Test { get { throw null; } }
        public bool Equals(Azure.AI.QuestionAnswering.Models.EnvironmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.QuestionAnswering.Models.EnvironmentType left, Azure.AI.QuestionAnswering.Models.EnvironmentType right) { throw null; }
        public static implicit operator Azure.AI.QuestionAnswering.Models.EnvironmentType (string value) { throw null; }
        public static bool operator !=(Azure.AI.QuestionAnswering.Models.EnvironmentType left, Azure.AI.QuestionAnswering.Models.EnvironmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Knowledgebase
    {
        internal Knowledgebase() { }
        public System.Uri Endpoint { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastAccessed { get { throw null; } }
        public System.DateTimeOffset? LastChanged { get { throw null; } }
        public System.DateTimeOffset? LastPublished { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Uri> Uris { get { throw null; } }
        public string UserId { get { throw null; } }
    }
    public partial class KnowledgebaseFileContent
    {
        public KnowledgebaseFileContent(string name, System.Uri uri) { }
        public bool? IsUnstructured { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class KnowledgebaseOperation : Azure.Operation
    {
        protected KnowledgebaseOperation() { }
        public KnowledgebaseOperation(Azure.AI.QuestionAnswering.QuestionAnsweringServiceClient client, string id) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public virtual Azure.AI.QuestionAnswering.KnowledgebaseClient GetKnowledgebaseClient() { throw null; }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QuestionAnswerContent
    {
        public QuestionAnswerContent(string answer, System.Collections.Generic.IEnumerable<string> questions) { }
        public string Answer { get { throw null; } set { } }
        public Azure.AI.QuestionAnswering.Models.QuestionAnswerContentContext Context { get { throw null; } set { } }
        public int? Id { get { throw null; } set { } }
        public string LastUpdatedTimestamp { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } set { } }
    }
    public partial class QuestionAnswerContentContext : Azure.AI.QuestionAnswering.Models.QuestionAnswerContext
    {
        public QuestionAnswerContentContext() { }
    }
    public partial class QuestionAnswerContext
    {
        public QuestionAnswerContext() { }
        public bool? IsContextOnly { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.QuestionAnswering.Models.AnswerPrompt> Prompts { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StrictFiltersCompoundOperationType : System.IEquatable<Azure.AI.QuestionAnswering.Models.StrictFiltersCompoundOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StrictFiltersCompoundOperationType(string value) { throw null; }
        public static Azure.AI.QuestionAnswering.Models.StrictFiltersCompoundOperationType AND { get { throw null; } }
        public static Azure.AI.QuestionAnswering.Models.StrictFiltersCompoundOperationType OR { get { throw null; } }
        public bool Equals(Azure.AI.QuestionAnswering.Models.StrictFiltersCompoundOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.QuestionAnswering.Models.StrictFiltersCompoundOperationType left, Azure.AI.QuestionAnswering.Models.StrictFiltersCompoundOperationType right) { throw null; }
        public static implicit operator Azure.AI.QuestionAnswering.Models.StrictFiltersCompoundOperationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.QuestionAnswering.Models.StrictFiltersCompoundOperationType left, Azure.AI.QuestionAnswering.Models.StrictFiltersCompoundOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum StringIndexType
    {
        TextElementsV8 = 0,
        UnicodeCodePoint = 1,
        Utf16CodeUnit = 2,
    }
    public partial class UpdateKnowledgebaseContents
    {
        public UpdateKnowledgebaseContents() { }
        public string DefaultAnswer { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.QuestionAnswering.Models.KnowledgebaseFileContent> Files { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.QuestionAnswering.Models.UpdateQuestionAnswerContent> QuestionAnswers { get { throw null; } }
        public System.Collections.Generic.IList<System.Uri> Uris { get { throw null; } }
    }
    public partial class UpdateMetadata
    {
        public UpdateMetadata() { }
        public System.Collections.Generic.IDictionary<string, string> Add { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Delete { get { throw null; } }
    }
    public partial class UpdateQuestionAnswerContent
    {
        public UpdateQuestionAnswerContent() { }
        public string Answer { get { throw null; } set { } }
        public Azure.AI.QuestionAnswering.Models.UpdateQuestionAnswerContentContext Context { get { throw null; } set { } }
        public int? Id { get { throw null; } set { } }
        public Azure.AI.QuestionAnswering.Models.UpdateQuestionAnswerContentMetadata Metadata { get { throw null; } set { } }
        public Azure.AI.QuestionAnswering.Models.UpdateQuestionAnswerContentQuestions Questions { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public partial class UpdateQuestionAnswerContentContext : Azure.AI.QuestionAnswering.Models.UpdateQuestionAnswerContext
    {
        public UpdateQuestionAnswerContentContext() { }
    }
    public partial class UpdateQuestionAnswerContentMetadata : Azure.AI.QuestionAnswering.Models.UpdateMetadata
    {
        public UpdateQuestionAnswerContentMetadata() { }
    }
    public partial class UpdateQuestionAnswerContentQuestions : Azure.AI.QuestionAnswering.Models.UpdateQuestions
    {
        public UpdateQuestionAnswerContentQuestions() { }
    }
    public partial class UpdateQuestionAnswerContext
    {
        public UpdateQuestionAnswerContext() { }
        public bool? IsContextOnly { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.QuestionAnswering.Models.AnswerPrompt> PromptsToAdd { get { throw null; } }
        public System.Collections.Generic.IList<int> PromptsToDelete { get { throw null; } }
    }
    public partial class UpdateQuestions
    {
        public UpdateQuestions() { }
        public System.Collections.Generic.IList<string> Add { get { throw null; } }
        public System.Collections.Generic.IList<string> Delete { get { throw null; } }
    }
}
