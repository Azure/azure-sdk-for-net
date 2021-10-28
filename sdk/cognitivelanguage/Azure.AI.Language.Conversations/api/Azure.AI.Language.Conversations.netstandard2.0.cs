namespace Azure.AI.Language.Conversations
{
    public partial class AnalyzeConversationOptions
    {
        public AnalyzeConversationOptions(string projectName, string deploymentName, string query) { }
        public string DeploymentName { get { throw null; } }
        public string DirectTarget { get { throw null; } set { } }
        public bool? IsLoggingEnabled { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Language.Conversations.Models.AnalysisParameters> Parameters { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public string Query { get { throw null; } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class ConversationAnalysisClient
    {
        protected ConversationAnalysisClient() { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult> AnalyzeConversation(Azure.AI.Language.Conversations.AnalyzeConversationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult> AnalyzeConversation(string projectName, string deploymentName, string query, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>> AnalyzeConversationAsync(Azure.AI.Language.Conversations.AnalyzeConversationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.Models.AnalyzeConversationResult>> AnalyzeConversationAsync(string projectName, string deploymentName, string query, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConversationAnalysisClientOptions : Azure.Core.ClientOptions
    {
        public ConversationAnalysisClientOptions(Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion.V2021_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2021_11_01_Preview = 1,
        }
    }
}
namespace Azure.AI.Language.Conversations.Models
{
    public partial class AnalysisParameters
    {
        public AnalysisParameters() { }
        public string ApiVersion { get { throw null; } set { } }
    }
    public partial class AnalyzeConversationResult
    {
        internal AnalyzeConversationResult() { }
        public string DetectedLanguage { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.BasePrediction Prediction { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class AnswerSpan
    {
        internal AnswerSpan() { }
        public double? ConfidenceScore { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class BasePrediction
    {
        internal BasePrediction() { }
        public Azure.AI.Language.Conversations.Models.ProjectKind ProjectKind { get { throw null; } set { } }
        public string TopIntent { get { throw null; } }
    }
    public partial class ConversationCallingOptions
    {
        public ConversationCallingOptions() { }
        public bool? IsLoggingEnabled { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class ConversationEntity
    {
        internal ConversationEntity() { }
        public string Category { get { throw null; } }
        public float ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ListKeys { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class ConversationIntent
    {
        internal ConversationIntent() { }
        public string Category { get { throw null; } }
        public float ConfidenceScore { get { throw null; } }
    }
    public partial class ConversationParameters : Azure.AI.Language.Conversations.Models.AnalysisParameters
    {
        public ConversationParameters() { }
        public Azure.AI.Language.Conversations.Models.ConversationCallingOptions CallingOptions { get { throw null; } set { } }
    }
    public partial class ConversationPrediction : Azure.AI.Language.Conversations.Models.BasePrediction
    {
        internal ConversationPrediction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.ConversationIntent> Intents { get { throw null; } }
    }
    public partial class ConversationResult
    {
        internal ConversationResult() { }
        public string DetectedLanguage { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ConversationPrediction Prediction { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public static partial class ConversationsModelFactory
    {
        public static Azure.AI.Language.Conversations.Models.AnalyzeConversationResult AnalyzeConversationResult(string query = null, string detectedLanguage = null, Azure.AI.Language.Conversations.Models.BasePrediction prediction = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.AnswerSpan AnswerSpan(string text = null, double? confidenceScore = default(double?), int? offset = default(int?), int? length = default(int?)) { throw null; }
        public static Azure.AI.Language.Conversations.Models.BasePrediction BasePrediction(Azure.AI.Language.Conversations.Models.ProjectKind projectKind = default(Azure.AI.Language.Conversations.Models.ProjectKind), string topIntent = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationEntity ConversationEntity(string category = null, string text = null, int offset = 0, int length = 0, float confidenceScore = 0f, System.Collections.Generic.IEnumerable<string> listKeys = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationIntent ConversationIntent(string category = null, float confidenceScore = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationPrediction ConversationPrediction(Azure.AI.Language.Conversations.Models.ProjectKind projectKind = default(Azure.AI.Language.Conversations.Models.ProjectKind), string topIntent = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationIntent> intents = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.ConversationEntity> entities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationResult ConversationResult(string query = null, string detectedLanguage = null, Azure.AI.Language.Conversations.Models.ConversationPrediction prediction = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ConversationTargetIntentResult ConversationTargetIntentResult(Azure.AI.Language.Conversations.Models.TargetKind targetKind = default(Azure.AI.Language.Conversations.Models.TargetKind), string apiVersion = null, double confidenceScore = 0, Azure.AI.Language.Conversations.Models.ConversationResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer KnowledgeBaseAnswer(System.Collections.Generic.IEnumerable<string> questions = null, string answer = null, double? confidenceScore = default(double?), int? id = default(int?), string source = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog dialog = null, Azure.AI.Language.Conversations.Models.AnswerSpan answerSpan = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog KnowledgeBaseAnswerDialog(bool? isContextOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt> prompts = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt KnowledgeBaseAnswerPrompt(int? displayOrder = default(int?), int? qnaId = default(int?), string displayText = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswers KnowledgeBaseAnswers(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer> answers = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.LuisTargetIntentResult LuisTargetIntentResult(Azure.AI.Language.Conversations.Models.TargetKind targetKind = default(Azure.AI.Language.Conversations.Models.TargetKind), string apiVersion = null, double confidenceScore = 0, object result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.NoneLinkedTargetIntentResult NoneLinkedTargetIntentResult(Azure.AI.Language.Conversations.Models.TargetKind targetKind = default(Azure.AI.Language.Conversations.Models.TargetKind), string apiVersion = null, double confidenceScore = 0, Azure.AI.Language.Conversations.Models.ConversationResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.OrchestratorPrediction OrchestratorPrediction(Azure.AI.Language.Conversations.Models.ProjectKind projectKind = default(Azure.AI.Language.Conversations.Models.ProjectKind), string topIntent = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Models.TargetIntentResult> intents = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult QuestionAnsweringTargetIntentResult(Azure.AI.Language.Conversations.Models.TargetKind targetKind = default(Azure.AI.Language.Conversations.Models.TargetKind), string apiVersion = null, double confidenceScore = 0, Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswers result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TargetIntentResult TargetIntentResult(Azure.AI.Language.Conversations.Models.TargetKind targetKind = default(Azure.AI.Language.Conversations.Models.TargetKind), string apiVersion = null, double confidenceScore = 0) { throw null; }
    }
    public partial class ConversationTargetIntentResult : Azure.AI.Language.Conversations.Models.TargetIntentResult
    {
        internal ConversationTargetIntentResult() { }
        public Azure.AI.Language.Conversations.Models.ConversationResult Result { get { throw null; } }
    }
    public partial class KnowledgeBaseAnswer
    {
        internal KnowledgeBaseAnswer() { }
        public string Answer { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.AnswerSpan AnswerSpan { get { throw null; } }
        public double? ConfidenceScore { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerDialog Dialog { get { throw null; } }
        public int? Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } }
    }
    public partial class KnowledgeBaseAnswerDialog
    {
        internal KnowledgeBaseAnswerDialog() { }
        public bool? IsContextOnly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswerPrompt> Prompts { get { throw null; } }
    }
    public partial class KnowledgeBaseAnswerPrompt
    {
        internal KnowledgeBaseAnswerPrompt() { }
        public int? DisplayOrder { get { throw null; } }
        public string DisplayText { get { throw null; } }
        public int? QnaId { get { throw null; } }
    }
    public partial class KnowledgeBaseAnswers
    {
        internal KnowledgeBaseAnswers() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswer> Answers { get { throw null; } }
    }
    public partial class LuisCallingOptions
    {
        public LuisCallingOptions() { }
        public string BingSpellCheckSubscriptionKey { get { throw null; } set { } }
        public bool? Log { get { throw null; } set { } }
        public bool? ShowAllIntents { get { throw null; } set { } }
        public bool? SpellCheck { get { throw null; } set { } }
        public float? TimezoneOffset { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class LuisParameters : Azure.AI.Language.Conversations.Models.AnalysisParameters
    {
        public LuisParameters() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.LuisCallingOptions CallingOptions { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
    }
    public partial class LuisTargetIntentResult : Azure.AI.Language.Conversations.Models.TargetIntentResult
    {
        internal LuisTargetIntentResult() { }
        public object Result { get { throw null; } }
    }
    public partial class NoneLinkedTargetIntentResult : Azure.AI.Language.Conversations.Models.TargetIntentResult
    {
        internal NoneLinkedTargetIntentResult() { }
        public Azure.AI.Language.Conversations.Models.ConversationResult Result { get { throw null; } }
    }
    public partial class OrchestratorPrediction : Azure.AI.Language.Conversations.Models.BasePrediction
    {
        internal OrchestratorPrediction() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Models.TargetIntentResult> Intents { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectKind : System.IEquatable<Azure.AI.Language.Conversations.Models.ProjectKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ProjectKind Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.ProjectKind Workflow { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.ProjectKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.ProjectKind left, Azure.AI.Language.Conversations.Models.ProjectKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.ProjectKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.ProjectKind left, Azure.AI.Language.Conversations.Models.ProjectKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuestionAnsweringParameters : Azure.AI.Language.Conversations.Models.AnalysisParameters
    {
        public QuestionAnsweringParameters() { }
        public object CallingOptions { get { throw null; } set { } }
    }
    public partial class QuestionAnsweringTargetIntentResult : Azure.AI.Language.Conversations.Models.TargetIntentResult
    {
        internal QuestionAnsweringTargetIntentResult() { }
        public Azure.AI.Language.Conversations.Models.KnowledgeBaseAnswers Result { get { throw null; } }
    }
    public partial class TargetIntentResult
    {
        internal TargetIntentResult() { }
        public string ApiVersion { get { throw null; } }
        public double ConfidenceScore { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetKind : System.IEquatable<Azure.AI.Language.Conversations.Models.TargetKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TargetKind Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TargetKind Luis { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TargetKind NonLinked { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TargetKind QuestionAnswering { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.TargetKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.TargetKind left, Azure.AI.Language.Conversations.Models.TargetKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.TargetKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.TargetKind left, Azure.AI.Language.Conversations.Models.TargetKind right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ConversationAnalysisClientExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions> AddConversationAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions> AddConversationAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
