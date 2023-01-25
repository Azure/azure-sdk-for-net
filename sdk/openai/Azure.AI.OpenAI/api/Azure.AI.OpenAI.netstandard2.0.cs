namespace Azure.AI.OpenAI
{
    public partial class OpenAIClient
    {
        protected OpenAIClient() { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.OpenAI.Models.Completion> Completions(string deploymentId, Azure.AI.OpenAI.Models.CompletionsRequest completionsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Completions(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Models.Completion>> CompletionsAsync(string deploymentId, Azure.AI.OpenAI.Models.CompletionsRequest completionsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CompletionsAsync(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Models.Embeddings> Embeddings(string deploymentId, Azure.AI.OpenAI.Models.EmbeddingsRequest embeddingsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Embeddings(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Models.Embeddings>> EmbeddingsAsync(string deploymentId, Azure.AI.OpenAI.Models.EmbeddingsRequest embeddingsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EmbeddingsAsync(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class OpenAIClientOptions : Azure.Core.ClientOptions
    {
        public OpenAIClientOptions(Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion version = Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion.V2022_06_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_06_01_Preview = 1,
        }
    }
}
namespace Azure.AI.OpenAI.Models
{
    public partial class Choice
    {
        internal Choice() { }
        public string FinishReason { get { throw null; } }
        public int? Index { get { throw null; } }
        public Azure.AI.OpenAI.Models.CompletionsLogProbsModel Logprobs { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class Completion
    {
        internal Completion() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Models.Choice> Choices { get { throw null; } }
        public int? Created { get { throw null; } }
        public string Id { get { throw null; } }
        public string Model { get { throw null; } }
        public string Object { get { throw null; } }
    }
    public partial class CompletionsLogProbsModel
    {
        internal CompletionsLogProbsModel() { }
        public System.Collections.Generic.IReadOnlyList<int> TextOffset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> TokenLogprobs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, float>> TopLogprobs { get { throw null; } }
    }
    public partial class CompletionsRequest
    {
        public CompletionsRequest() { }
        public int? BestOf { get { throw null; } set { } }
        public int? CacheLevel { get { throw null; } set { } }
        public string CompletionConfig { get { throw null; } set { } }
        public bool? Echo { get { throw null; } set { } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> LogitBias { get { throw null; } }
        public int? Logprobs { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public int? N { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Prompt { get { throw null; } }
        public System.Collections.Generic.IList<string> Stop { get { throw null; } }
        public bool? Stream { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public float? TopP { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class EmbeddingItem
    {
        internal EmbeddingItem() { }
        public System.Collections.Generic.IReadOnlyList<float> Embedding { get { throw null; } }
        public int Index { get { throw null; } }
        public string Object { get { throw null; } }
    }
    public partial class Embeddings
    {
        internal Embeddings() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Models.EmbeddingItem> Data { get { throw null; } }
        public string Object { get { throw null; } }
    }
    public partial class EmbeddingsRequest
    {
        public EmbeddingsRequest(string input) { }
        public string Input { get { throw null; } }
        public string InputType { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
}
