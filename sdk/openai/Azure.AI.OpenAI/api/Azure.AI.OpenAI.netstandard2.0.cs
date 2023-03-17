namespace Azure.AI.OpenAI
{
    public partial class ChatChoice
    {
        internal ChatChoice() { }
        public string FinishReason { get { throw null; } }
        public int? Index { get { throw null; } }
        public Azure.AI.OpenAI.ChatMessage Message { get { throw null; } }
    }
    public partial class ChatCompletions
    {
        internal ChatCompletions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ChatChoice> Choices { get { throw null; } }
        public System.DateTime Created { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsUsage Usage { get { throw null; } }
    }
    public partial class ChatCompletionsOptions
    {
        public ChatCompletionsOptions() { }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<int, int> LogitBias { get { throw null; } }
        public int? MaxTokens { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatMessage> Messages { get { throw null; } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public int? SnippetCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Stop { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class ChatMessage
    {
        public ChatMessage(Azure.AI.OpenAI.ChatRole role, string content) { }
        public string Content { get { throw null; } }
        public Azure.AI.OpenAI.ChatRole Role { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatRole : System.IEquatable<Azure.AI.OpenAI.ChatRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static readonly Azure.AI.OpenAI.ChatRole Assistant;
        public static readonly Azure.AI.OpenAI.ChatRole System;
        public static readonly Azure.AI.OpenAI.ChatRole User;
        public ChatRole(string label) { throw null; }
        public string Label { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ChatRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ChatRole left, Azure.AI.OpenAI.ChatRole right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ChatRole (string label) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ChatRole left, Azure.AI.OpenAI.ChatRole right) { throw null; }
        public override string ToString() { throw null; }
    }
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
        public System.Collections.Generic.IReadOnlyList<float?> TokenLogProbability { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, float>> TopLogProbability { get { throw null; } }
    }
    public partial class CompletionsOptions
    {
        public CompletionsOptions() { }
        public bool? Echo { get { throw null; } set { } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public int? GenerationSampleCount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<int, int> LogitBias { get { throw null; } }
        public int? LogProbability { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Prompts { get { throw null; } }
        public int? SnippetCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StopSequences { get { throw null; } }
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
        public OpenAIClient(string openAIApiKey) { }
        public OpenAIClient(string openAIApiKey, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential) { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.OpenAI.ChatCompletions> GetChatCompletions(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.ChatCompletions> GetChatCompletions(string deploymentOrModelName, Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.ChatCompletions>> GetChatCompletionsAsync(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.ChatCompletions>> GetChatCompletionsAsync(string deploymentOrModelName, Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.StreamingChatCompletions> GetChatCompletionsStreaming(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.StreamingChatCompletions> GetChatCompletionsStreaming(string deploymentOrModelName, Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.StreamingChatCompletions>> GetChatCompletionsStreamingAsync(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.StreamingChatCompletions>> GetChatCompletionsStreamingAsync(string deploymentOrModelName, Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Completions> GetCompletions(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Completions> GetCompletions(string deploymentOrModelName, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Completions> GetCompletions(string deploymentOrModelName, string prompt, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Completions> GetCompletions(string prompt, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Completions>> GetCompletionsAsync(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Completions>> GetCompletionsAsync(string deploymentOrModelName, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Completions>> GetCompletionsAsync(string deploymentOrModelName, string prompt, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Completions>> GetCompletionsAsync(string prompt, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.StreamingCompletions> GetCompletionsStreaming(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.StreamingCompletions> GetCompletionsStreaming(string deploymentOrModelName, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.StreamingCompletions>> GetCompletionsStreamingAsync(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.StreamingCompletions>> GetCompletionsStreamingAsync(string deploymentOrModelName, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Embeddings> GetEmbeddings(Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Embeddings> GetEmbeddings(string deploymentOrModelName, Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Embeddings>> GetEmbeddingsAsync(Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Embeddings>> GetEmbeddingsAsync(string deploymentOrModelName, Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenAIClientOptions : Azure.Core.ClientOptions
    {
        public OpenAIClientOptions(Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion version = Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion.V2022_12_01) { }
        public string DefaultDeploymentOrModelName { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2022_12_01 = 1,
        }
    }
    public partial class StreamingChatChoice
    {
        internal StreamingChatChoice() { }
        public string FinishReason { get { throw null; } }
        public int? Index { get { throw null; } }
        public System.Collections.Generic.IAsyncEnumerable<Azure.AI.OpenAI.ChatMessage> GetMessageStreaming([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingChatCompletions : System.IDisposable
    {
        internal StreamingChatCompletions() { }
        public System.DateTime Created { get { throw null; } }
        public string Id { get { throw null; } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public System.Collections.Generic.IAsyncEnumerable<Azure.AI.OpenAI.StreamingChatChoice> GetChoicesStreaming([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
        public System.Collections.Generic.IAsyncEnumerable<Azure.AI.OpenAI.StreamingChoice> GetChoicesStreaming([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
