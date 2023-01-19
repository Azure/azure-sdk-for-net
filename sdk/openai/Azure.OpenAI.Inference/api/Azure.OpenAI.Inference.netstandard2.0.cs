namespace Azure.OpenAI.Inference
{
    public partial class OpenAIClient
    {
        protected OpenAIClient() { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.OpenAI.Inference.OpenAIClientOptions options) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.OpenAI.Inference.OpenAIClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Completions(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.OpenAI.Inference.Models.Completion> Completions(string deploymentId, Azure.OpenAI.Inference.Models.CompletionsRequest completionsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CompletionsAsync(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.OpenAI.Inference.Models.Completion>> CompletionsAsync(string deploymentId, Azure.OpenAI.Inference.Models.CompletionsRequest completionsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Embeddings(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.OpenAI.Inference.Models.Embeddings> Embeddings(string deploymentId, Azure.OpenAI.Inference.Models.EmbeddingsRequest embeddingsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EmbeddingsAsync(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.OpenAI.Inference.Models.Embeddings>> EmbeddingsAsync(string deploymentId, Azure.OpenAI.Inference.Models.EmbeddingsRequest embeddingsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenAIClientOptions : Azure.Core.ClientOptions
    {
        public OpenAIClientOptions(Azure.OpenAI.Inference.OpenAIClientOptions.ServiceVersion version = Azure.OpenAI.Inference.OpenAIClientOptions.ServiceVersion.V2022_06_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_06_01_Preview = 1,
        }
    }
}
namespace Azure.OpenAI.Inference.Models
{
    public partial class Choice
    {
        internal Choice() { }
        public string FinishReason { get { throw null; } }
        public int? Index { get { throw null; } }
        public Azure.OpenAI.Inference.Models.CompletionsLogProbsModel Logprobs { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class Completion
    {
        internal Completion() { }
        public System.Collections.Generic.IReadOnlyList<Azure.OpenAI.Inference.Models.Choice> Choices { get { throw null; } }
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
        public int? Best_of { get { throw null; } set { } }
        public int? Cache_level { get { throw null; } set { } }
        public string Completion_config { get { throw null; } set { } }
        public bool? Echo { get { throw null; } set { } }
        public float? Frequency_penalty { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> Logit_bias { get { throw null; } }
        public int? Logprobs { get { throw null; } set { } }
        public int? Max_tokens { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public int? N { get { throw null; } set { } }
        public float? Presence_penalty { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Prompt { get { throw null; } }
        public System.Collections.Generic.IList<string> Stop { get { throw null; } }
        public bool? Stream { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public float? Top_p { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class Embedding
    {
        internal Embedding() { }
        public System.Collections.Generic.IReadOnlyList<float> EmbeddingFloat { get { throw null; } }
        public int Index { get { throw null; } }
        public string Object { get { throw null; } }
    }
    public partial class Embeddings
    {
        internal Embeddings() { }
        public System.Collections.Generic.IReadOnlyList<Azure.OpenAI.Inference.Models.Embedding> Data { get { throw null; } }
        public string Object { get { throw null; } }
    }
    public partial class EmbeddingsRequest
    {
        public EmbeddingsRequest(string input) { }
        public string Input { get { throw null; } }
        public string Input_type { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
}
