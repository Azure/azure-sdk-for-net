namespace Azure.AI.OpenAI
{
    public partial class Choice
    {
        internal Choice() { }
        public string FinishReason { get { throw null; } }
        public int? Index { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsLogProbability Logprobs { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class Completions
    {
        internal Completions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Choice> Choices { get { throw null; } }
        public int? Created { get { throw null; } }
        public string Id { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsUsage Usage { get { throw null; } }
    }
    public partial class CompletionsLogProbability
    {
        internal CompletionsLogProbability() { }
        public System.Collections.Generic.IReadOnlyList<int> TextOffset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> TokenLogProbability { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, float>> TopLogProbability { get { throw null; } }
    }
    public partial class CompletionsOptions
    {
        public CompletionsOptions() { }
        public int? CacheLevel { get { throw null; } set { } }
        public string CompletionConfig { get { throw null; } set { } }
        public bool? Echo { get { throw null; } set { } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public int? GenerationSampleCount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, int> LogitBias { get { throw null; } }
        public int? LogProbability { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Prompt { get { throw null; } }
        public int? SnippetCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stop { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class CompletionsUsage
    {
        internal CompletionsUsage() { }
        public int CompletionTokens { get { throw null; } }
        public int PromptTokens { get { throw null; } }
        public int TotalTokens { get { throw null; } }
    }
    public partial class EmbeddingItem
    {
        internal EmbeddingItem() { }
        public System.Collections.Generic.IReadOnlyList<float> Embedding { get { throw null; } }
        public int Index { get { throw null; } }
    }
    public partial class Embeddings
    {
        internal Embeddings() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.EmbeddingItem> Data { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.OpenAI.EmbeddingsUsage Usage { get { throw null; } }
    }
    public partial class EmbeddingsOptions
    {
        public EmbeddingsOptions(string input) { }
        public string Input { get { throw null; } set { } }
        public string InputType { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class EmbeddingsUsage
    {
        internal EmbeddingsUsage() { }
        public int PromptTokens { get { throw null; } }
        public int TotalTokens { get { throw null; } }
    }
    public partial class OpenAIClient
    {
        protected OpenAIClient() { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.OpenAI.Completions> GetCompletions(string deploymentId, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCompletions(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Completions> GetCompletions(string deploymentId, string prompt, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Completions>> GetCompletionsAsync(string deploymentId, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCompletionsAsync(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Completions>> GetCompletionsAsync(string deploymentId, string prompt, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Custom.StreamingCompletions> GetCompletionsStreaming(string deploymentId, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Custom.StreamingCompletions>> GetCompletionsStreamingAsync(string deploymentId, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Embeddings> GetEmbeddings(string deploymentId, Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEmbeddings(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Embeddings>> GetEmbeddingsAsync(string deploymentId, Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEmbeddingsAsync(string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class OpenAIClientOptions : Azure.Core.ClientOptions
    {
        public OpenAIClientOptions(Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion version = Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion.V2022_12_01) { }
        public enum ServiceVersion
        {
            V2022_12_01 = 1,
        }
    }
}
namespace Azure.AI.OpenAI.Custom
{
    public partial class StreamingChoice
    {
        internal StreamingChoice() { }
        public string FinishReason { get { throw null; } }
        public int? Index { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsLogProbability Logprobs { get { throw null; } }
        public System.Collections.Generic.IAsyncEnumerable<string> GetTextStreaming([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingCompletions : System.IDisposable
    {
        internal StreamingCompletions() { }
        public System.DateTime Created { get { throw null; } }
        public string Id { get { throw null; } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public System.Collections.Generic.IAsyncEnumerable<Azure.AI.OpenAI.Custom.StreamingChoice> GetChoicesStreaming([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AzureOpenAIClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.OpenAIClient, Azure.AI.OpenAI.OpenAIClientOptions> AddOpenAIClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.OpenAIClient, Azure.AI.OpenAI.OpenAIClientOptions> AddOpenAIClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.OpenAIClient, Azure.AI.OpenAI.OpenAIClientOptions> AddOpenAIClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
