namespace Azure.AI.Language.Conversations
{
    public partial class AnalyzeConversationOptions
    {
        public AnalyzeConversationOptions(string projectName, string deploymentName, string query) { }
        public string DeploymentName { get { throw null; } }
        public string DirectTarget { get { throw null; } set { } }
        public bool? IsLoggingEnabled { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Language.Conversations.Models.AnalyzeParameters> Parameters { get { throw null; } }
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
        public ConversationAnalysisClientOptions(Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion.V2021_07_15_preview) { }
        public enum ServiceVersion
        {
            V2021_07_15_preview = 1,
        }
    }
}
namespace Azure.AI.Language.Conversations.Models
{
    public partial class AnalyzeConversationResult
    {
        internal AnalyzeConversationResult() { }
        public string DetectedLanguage { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.BasePrediction Prediction { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class AnalyzeParameters
    {
        public AnalyzeParameters() { }
        public string ApiVersion { get { throw null; } set { } }
    }
    public partial class BasePrediction
    {
        internal BasePrediction() { }
        public string TopIntent { get { throw null; } }
    }
    public static partial class ConversationsModelFactory
    {
        public static Azure.AI.Language.Conversations.Models.AnalyzeConversationResult AnalyzeConversationResult(string query = null, string detectedLanguage = null, Azure.AI.Language.Conversations.Models.BasePrediction prediction = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.BasePrediction BasePrediction(Azure.AI.Language.Conversations.Models.ProjectKind projectKind = default(Azure.AI.Language.Conversations.Models.ProjectKind), string topIntent = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DeepstackEntity DeepstackEntity(string category = null, string text = null, int offset = 0, int length = 0, float confidenceScore = 0f, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.DeepStackEntityResolution> resolution = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DeepStackEntityResolution DeepStackEntityResolution(Azure.AI.Language.Conversations.Models.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.Models.ResolutionKind), System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DeepstackIntent DeepstackIntent(string category = null, float confidenceScore = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DeepstackPrediction DeepstackPrediction(Azure.AI.Language.Conversations.Models.ProjectKind projectKind = default(Azure.AI.Language.Conversations.Models.ProjectKind), string topIntent = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.DeepstackIntent> intents = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.Models.DeepstackEntity> entities = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DeepstackResult DeepstackResult(string query = null, string detectedLanguage = null, Azure.AI.Language.Conversations.Models.DeepstackPrediction prediction = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DictionaryNormalizedValueResolution DictionaryNormalizedValueResolution(Azure.AI.Language.Conversations.Models.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.Models.ResolutionKind), System.Collections.Generic.IReadOnlyDictionary<string, object> additionalProperties = null, System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.DSTargetIntentResult DSTargetIntentResult(Azure.AI.Language.Conversations.Models.TargetKind targetKind = default(Azure.AI.Language.Conversations.Models.TargetKind), string apiVersion = null, double confidenceScore = 0, Azure.AI.Language.Conversations.Models.DeepstackResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.LuisTargetIntentResult LuisTargetIntentResult(Azure.AI.Language.Conversations.Models.TargetKind targetKind = default(Azure.AI.Language.Conversations.Models.TargetKind), string apiVersion = null, double confidenceScore = 0, object result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.QuestionAnsweringTargetIntentResult QuestionAnsweringTargetIntentResult(Azure.AI.Language.Conversations.Models.TargetKind targetKind = default(Azure.AI.Language.Conversations.Models.TargetKind), string apiVersion = null, double confidenceScore = 0, object result = null) { throw null; }
        public static Azure.AI.Language.Conversations.Models.TargetIntentResult TargetIntentResult(Azure.AI.Language.Conversations.Models.TargetKind targetKind = default(Azure.AI.Language.Conversations.Models.TargetKind), string apiVersion = null, double confidenceScore = 0) { throw null; }
        public static Azure.AI.Language.Conversations.Models.WorkflowPrediction WorkflowPrediction(Azure.AI.Language.Conversations.Models.ProjectKind projectKind = default(Azure.AI.Language.Conversations.Models.ProjectKind), string topIntent = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Models.TargetIntentResult> intents = null) { throw null; }
    }
    public partial class DeepstackCallingOptions
    {
        public DeepstackCallingOptions() { }
        public bool? IsLoggingEnabled { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class DeepstackEntity
    {
        internal DeepstackEntity() { }
        public string Category { get { throw null; } }
        public float ConfidenceScore { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.DeepStackEntityResolution> Resolution { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class DeepStackEntityResolution
    {
        internal DeepStackEntityResolution() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.ResolutionKind ResolutionKind { get { throw null; } }
    }
    public partial class DeepstackIntent
    {
        internal DeepstackIntent() { }
        public string Category { get { throw null; } }
        public float ConfidenceScore { get { throw null; } }
    }
    public partial class DeepstackParameters : Azure.AI.Language.Conversations.Models.AnalyzeParameters
    {
        public DeepstackParameters() { }
        public Azure.AI.Language.Conversations.Models.DeepstackCallingOptions CallingOptions { get { throw null; } set { } }
    }
    public partial class DeepstackPrediction : Azure.AI.Language.Conversations.Models.BasePrediction
    {
        internal DeepstackPrediction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.DeepstackEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.Models.DeepstackIntent> Intents { get { throw null; } }
    }
    public partial class DeepstackResult
    {
        internal DeepstackResult() { }
        public string DetectedLanguage { get { throw null; } }
        public Azure.AI.Language.Conversations.Models.DeepstackPrediction Prediction { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class DictionaryNormalizedValueResolution : Azure.AI.Language.Conversations.Models.DeepStackEntityResolution
    {
        internal DictionaryNormalizedValueResolution() { }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public partial class DSTargetIntentResult : Azure.AI.Language.Conversations.Models.TargetIntentResult
    {
        internal DSTargetIntentResult() { }
        public Azure.AI.Language.Conversations.Models.DeepstackResult Result { get { throw null; } }
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
    public partial class LuisParameters : Azure.AI.Language.Conversations.Models.AnalyzeParameters
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
    public partial class QuestionAnsweringParameters : Azure.AI.Language.Conversations.Models.AnalyzeParameters
    {
        public QuestionAnsweringParameters() { }
        public object CallingOptions { get { throw null; } set { } }
    }
    public partial class QuestionAnsweringTargetIntentResult : Azure.AI.Language.Conversations.Models.TargetIntentResult
    {
        internal QuestionAnsweringTargetIntentResult() { }
        public object Result { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResolutionKind : System.IEquatable<Azure.AI.Language.Conversations.Models.ResolutionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResolutionKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.Models.ResolutionKind DictionaryNormalizedValue { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.Models.ResolutionKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.Models.ResolutionKind left, Azure.AI.Language.Conversations.Models.ResolutionKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.Models.ResolutionKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.Models.ResolutionKind left, Azure.AI.Language.Conversations.Models.ResolutionKind right) { throw null; }
        public override string ToString() { throw null; }
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
        public static Azure.AI.Language.Conversations.Models.TargetKind Luis { get { throw null; } }
        public static Azure.AI.Language.Conversations.Models.TargetKind LuisDeepstack { get { throw null; } }
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
    public partial class WorkflowPrediction : Azure.AI.Language.Conversations.Models.BasePrediction
    {
        internal WorkflowPrediction() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.Models.TargetIntentResult> Intents { get { throw null; } }
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
