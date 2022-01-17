namespace Azure.AI.Language.Conversations
{
    public partial class AnalysisParameters
    {
        public AnalysisParameters() { }
        public string ApiVersion { get { throw null; } set { } }
    }
    public partial class AnalyzeConversationOptions
    {
        public AnalyzeConversationOptions() { }
        public string DirectTarget { get { throw null; } set { } }
        public bool? IsLoggingEnabled { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Language.Conversations.AnalysisParameters> Parameters { get { throw null; } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class AnalyzeConversationResult
    {
        internal AnalyzeConversationResult() { }
        public string DetectedLanguage { get { throw null; } }
        public Azure.AI.Language.Conversations.BasePrediction Prediction { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class AnswerSpan
    {
        internal AnswerSpan() { }
        public double? Confidence { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class BasePrediction
    {
        internal BasePrediction() { }
        public Azure.AI.Language.Conversations.ProjectKind ProjectKind { get { throw null; } set { } }
        public string TopIntent { get { throw null; } }
    }
    public partial class ConversationAnalysisClient
    {
        protected ConversationAnalysisClient() { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.Conversations.AnalyzeConversationResult> AnalyzeConversation(string utterance, Azure.AI.Language.Conversations.ConversationsProject project, Azure.AI.Language.Conversations.AnalyzeConversationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.AnalyzeConversationResult>> AnalyzeConversationAsync(string utterance, Azure.AI.Language.Conversations.ConversationsProject project, Azure.AI.Language.Conversations.AnalyzeConversationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConversationAnalysisClientOptions : Azure.Core.ClientOptions
    {
        public ConversationAnalysisClientOptions(Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion.V2021_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2021_11_01_Preview = 1,
        }
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
        public float Confidence { get { throw null; } }
        public int Length { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ListKeys { get { throw null; } }
        public int Offset { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class ConversationIntent
    {
        internal ConversationIntent() { }
        public string Category { get { throw null; } }
        public float Confidence { get { throw null; } }
    }
    public partial class ConversationParameters : Azure.AI.Language.Conversations.AnalysisParameters
    {
        public ConversationParameters() { }
        public Azure.AI.Language.Conversations.ConversationCallingOptions CallingOptions { get { throw null; } set { } }
    }
    public partial class ConversationPrediction : Azure.AI.Language.Conversations.BasePrediction
    {
        internal ConversationPrediction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.ConversationEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.ConversationIntent> Intents { get { throw null; } }
    }
    public partial class ConversationResult
    {
        internal ConversationResult() { }
        public string DetectedLanguage { get { throw null; } }
        public Azure.AI.Language.Conversations.ConversationPrediction Prediction { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public static partial class ConversationsModelFactory
    {
        public static Azure.AI.Language.Conversations.AnalyzeConversationResult AnalyzeConversationResult(string query = null, string detectedLanguage = null, Azure.AI.Language.Conversations.BasePrediction prediction = null) { throw null; }
        public static Azure.AI.Language.Conversations.AnswerSpan AnswerSpan(string text = null, double? confidence = default(double?), int? offset = default(int?), int? length = default(int?)) { throw null; }
        public static Azure.AI.Language.Conversations.BasePrediction BasePrediction(Azure.AI.Language.Conversations.ProjectKind projectKind = default(Azure.AI.Language.Conversations.ProjectKind), string topIntent = null) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationEntity ConversationEntity(string category = null, string text = null, int offset = 0, int length = 0, float confidence = 0f, System.Collections.Generic.IEnumerable<string> listKeys = null) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationIntent ConversationIntent(string category = null, float confidence = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationPrediction ConversationPrediction(Azure.AI.Language.Conversations.ProjectKind projectKind = default(Azure.AI.Language.Conversations.ProjectKind), string topIntent = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.ConversationIntent> intents = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.ConversationEntity> entities = null) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationResult ConversationResult(string query = null, string detectedLanguage = null, Azure.AI.Language.Conversations.ConversationPrediction prediction = null) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationTargetIntentResult ConversationTargetIntentResult(Azure.AI.Language.Conversations.TargetKind targetKind = default(Azure.AI.Language.Conversations.TargetKind), string apiVersion = null, double confidence = 0, Azure.AI.Language.Conversations.ConversationResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.KnowledgeBaseAnswer KnowledgeBaseAnswer(System.Collections.Generic.IEnumerable<string> questions = null, string answer = null, double? confidence = default(double?), int? id = default(int?), string source = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Language.Conversations.KnowledgeBaseAnswerDialog dialog = null, Azure.AI.Language.Conversations.AnswerSpan answerSpan = null) { throw null; }
        public static Azure.AI.Language.Conversations.KnowledgeBaseAnswerDialog KnowledgeBaseAnswerDialog(bool? isContextOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.KnowledgeBaseAnswerPrompt> prompts = null) { throw null; }
        public static Azure.AI.Language.Conversations.KnowledgeBaseAnswerPrompt KnowledgeBaseAnswerPrompt(int? displayOrder = default(int?), int? qnaId = default(int?), string displayText = null) { throw null; }
        public static Azure.AI.Language.Conversations.KnowledgeBaseAnswers KnowledgeBaseAnswers(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.KnowledgeBaseAnswer> answers = null) { throw null; }
        public static Azure.AI.Language.Conversations.LuisTargetIntentResult LuisTargetIntentResult(Azure.AI.Language.Conversations.TargetKind targetKind = default(Azure.AI.Language.Conversations.TargetKind), string apiVersion = null, double confidenceScore = 0, object result = null) { throw null; }
        public static Azure.AI.Language.Conversations.NoneLinkedTargetIntentResult NoneLinkedTargetIntentResult(Azure.AI.Language.Conversations.TargetKind targetKind = default(Azure.AI.Language.Conversations.TargetKind), string apiVersion = null, double confidence = 0, Azure.AI.Language.Conversations.ConversationResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.OrchestratorPrediction OrchestratorPrediction(Azure.AI.Language.Conversations.ProjectKind projectKind = default(Azure.AI.Language.Conversations.ProjectKind), string topIntent = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.TargetIntentResult> intents = null) { throw null; }
        public static Azure.AI.Language.Conversations.QuestionAnsweringTargetIntentResult QuestionAnsweringTargetIntentResult(Azure.AI.Language.Conversations.TargetKind targetKind = default(Azure.AI.Language.Conversations.TargetKind), string apiVersion = null, double confidence = 0, Azure.AI.Language.Conversations.KnowledgeBaseAnswers result = null) { throw null; }
        public static Azure.AI.Language.Conversations.TargetIntentResult TargetIntentResult(Azure.AI.Language.Conversations.TargetKind targetKind = default(Azure.AI.Language.Conversations.TargetKind), string apiVersion = null, double confidence = 0) { throw null; }
    }
    public partial class ConversationsProject
    {
        public ConversationsProject(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public string ProjectName { get { throw null; } }
    }
    public partial class ConversationTargetIntentResult : Azure.AI.Language.Conversations.TargetIntentResult
    {
        internal ConversationTargetIntentResult() { }
        public Azure.AI.Language.Conversations.ConversationResult Result { get { throw null; } }
    }
    public partial class KnowledgeBaseAnswer
    {
        internal KnowledgeBaseAnswer() { }
        public string Answer { get { throw null; } }
        public Azure.AI.Language.Conversations.AnswerSpan AnswerSpan { get { throw null; } }
        public double? Confidence { get { throw null; } }
        public Azure.AI.Language.Conversations.KnowledgeBaseAnswerDialog Dialog { get { throw null; } }
        public int? Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } }
    }
    public partial class KnowledgeBaseAnswerDialog
    {
        internal KnowledgeBaseAnswerDialog() { }
        public bool? IsContextOnly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.KnowledgeBaseAnswerPrompt> Prompts { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.KnowledgeBaseAnswer> Answers { get { throw null; } }
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
    public partial class LuisParameters : Azure.AI.Language.Conversations.AnalysisParameters
    {
        public LuisParameters() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.AI.Language.Conversations.LuisCallingOptions CallingOptions { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
    }
    public partial class LuisTargetIntentResult : Azure.AI.Language.Conversations.TargetIntentResult
    {
        internal LuisTargetIntentResult() { }
        public System.BinaryData Result { get { throw null; } }
    }
    public partial class NoneLinkedTargetIntentResult : Azure.AI.Language.Conversations.TargetIntentResult
    {
        internal NoneLinkedTargetIntentResult() { }
        public Azure.AI.Language.Conversations.ConversationResult Result { get { throw null; } }
    }
    public partial class OrchestratorPrediction : Azure.AI.Language.Conversations.BasePrediction
    {
        internal OrchestratorPrediction() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.TargetIntentResult> Intents { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectKind : System.IEquatable<Azure.AI.Language.Conversations.ProjectKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.ProjectKind Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.ProjectKind Workflow { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.ProjectKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.ProjectKind left, Azure.AI.Language.Conversations.ProjectKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.ProjectKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.ProjectKind left, Azure.AI.Language.Conversations.ProjectKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuestionAnsweringParameters : Azure.AI.Language.Conversations.AnalysisParameters
    {
        public QuestionAnsweringParameters() { }
        public object CallingOptions { get { throw null; } set { } }
    }
    public partial class QuestionAnsweringTargetIntentResult : Azure.AI.Language.Conversations.TargetIntentResult
    {
        internal QuestionAnsweringTargetIntentResult() { }
        public Azure.AI.Language.Conversations.KnowledgeBaseAnswers Result { get { throw null; } }
    }
    public partial class TargetIntentResult
    {
        internal TargetIntentResult() { }
        public string ApiVersion { get { throw null; } }
        public double Confidence { get { throw null; } }
        public Azure.AI.Language.Conversations.TargetKind TargetKind { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetKind : System.IEquatable<Azure.AI.Language.Conversations.TargetKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.TargetKind Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.TargetKind Luis { get { throw null; } }
        public static Azure.AI.Language.Conversations.TargetKind NonLinked { get { throw null; } }
        public static Azure.AI.Language.Conversations.TargetKind QuestionAnswering { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.TargetKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.TargetKind left, Azure.AI.Language.Conversations.TargetKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.TargetKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.TargetKind left, Azure.AI.Language.Conversations.TargetKind right) { throw null; }
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
