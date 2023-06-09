namespace Azure.AI.OpenAI
{
    public static partial class AzureOpenAIModelFactory
    {
        public static Azure.AI.OpenAI.Choice Choice(string text = null, int index = 0, Azure.AI.OpenAI.CompletionsLogProbabilityModel logProbabilityModel = null, Azure.AI.OpenAI.CompletionsFinishReason? finishReason = default(Azure.AI.OpenAI.CompletionsFinishReason?)) { throw null; }
        public static Azure.AI.OpenAI.CompletionsLogProbabilityModel CompletionsLogProbabilityModel(System.Collections.Generic.IEnumerable<string> tokens = null, System.Collections.Generic.IEnumerable<float?> tokenLogProbabilities = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, float?>> topLogProbabilities = null, System.Collections.Generic.IEnumerable<int> textOffsets = null) { throw null; }
        public static Azure.AI.OpenAI.CompletionsUsage CompletionsUsage(int completionTokens = 0, int promptTokens = 0, int totalTokens = 0) { throw null; }
        public static Azure.AI.OpenAI.EmbeddingItem EmbeddingItem(System.Collections.Generic.IEnumerable<float> embedding = null, int index = 0) { throw null; }
        public static Azure.AI.OpenAI.Embeddings Embeddings(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.EmbeddingItem> data = null, Azure.AI.OpenAI.EmbeddingsUsage usage = null) { throw null; }
        public static Azure.AI.OpenAI.EmbeddingsUsage EmbeddingsUsage(int promptTokens = 0, int totalTokens = 0) { throw null; }
    }
    public partial class ChatChoice
    {
        internal ChatChoice() { }
        public Azure.AI.OpenAI.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        public Azure.AI.OpenAI.ChatMessage Message { get { throw null; } }
    }
    public partial class ChatCompletions
    {
        internal ChatCompletions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ChatChoice> Choices { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsUsage Usage { get { throw null; } }
    }
    public partial class ChatCompletionsOptions
    {
        public ChatCompletionsOptions() { }
        public ChatCompletionsOptions(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatMessage> messages) { }
        public int? ChoiceCount { get { throw null; } set { } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatMessage> Messages { get { throw null; } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StopSequences { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<int, int> TokenSelectionBiases { get { throw null; } }
        public string User { get { throw null; } set { } }
    }
    public partial class ChatMessage
    {
        public ChatMessage(Azure.AI.OpenAI.ChatRole role) { }
        public ChatMessage(Azure.AI.OpenAI.ChatRole role, string content) { }
        public string Content { get { throw null; } set { } }
        public Azure.AI.OpenAI.ChatRole Role { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatRole : System.IEquatable<Azure.AI.OpenAI.ChatRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatRole(string value) { throw null; }
        public static Azure.AI.OpenAI.ChatRole Assistant { get { throw null; } }
        public static Azure.AI.OpenAI.ChatRole System { get { throw null; } }
        public static Azure.AI.OpenAI.ChatRole User { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ChatRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ChatRole left, Azure.AI.OpenAI.ChatRole right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ChatRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ChatRole left, Azure.AI.OpenAI.ChatRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Choice
    {
        internal Choice() { }
        public Azure.AI.OpenAI.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsLogProbabilityModel LogProbabilityModel { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class Completions
    {
        internal Completions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Choice> Choices { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsUsage Usage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompletionsFinishReason : System.IEquatable<Azure.AI.OpenAI.CompletionsFinishReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompletionsFinishReason(string value) { throw null; }
        public static Azure.AI.OpenAI.CompletionsFinishReason ContentFiltered { get { throw null; } }
        public static Azure.AI.OpenAI.CompletionsFinishReason Stopped { get { throw null; } }
        public static Azure.AI.OpenAI.CompletionsFinishReason TokenLimitReached { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.CompletionsFinishReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.CompletionsFinishReason left, Azure.AI.OpenAI.CompletionsFinishReason right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.CompletionsFinishReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.CompletionsFinishReason left, Azure.AI.OpenAI.CompletionsFinishReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CompletionsLogProbabilityModel
    {
        internal CompletionsLogProbabilityModel() { }
        public System.Collections.Generic.IReadOnlyList<int> TextOffsets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float?> TokenLogProbabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, float?>> TopLogProbabilities { get { throw null; } }
    }
    public partial class CompletionsOptions
    {
        public CompletionsOptions() { }
        public CompletionsOptions(System.Collections.Generic.IEnumerable<string> prompts) { }
        public int? ChoicesPerPrompt { get { throw null; } set { } }
        public bool? Echo { get { throw null; } set { } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public int? GenerationSampleCount { get { throw null; } set { } }
        public int? LogProbabilityCount { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Prompts { get { throw null; } }
        public System.Collections.Generic.IList<string> StopSequences { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<int, int> TokenSelectionBiases { get { throw null; } }
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
        public Azure.AI.OpenAI.EmbeddingsUsage Usage { get { throw null; } }
    }
    public partial class EmbeddingsOptions
    {
        public EmbeddingsOptions(System.Collections.Generic.IEnumerable<string> input) { }
        public EmbeddingsOptions(string input) { }
        public System.Collections.Generic.IList<string> Input { get { throw null; } }
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
        public virtual Azure.Response<Azure.AI.OpenAI.ChatCompletions> GetChatCompletions(string deploymentOrModelName, Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.ChatCompletions>> GetChatCompletionsAsync(string deploymentOrModelName, Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.StreamingChatCompletions> GetChatCompletionsStreaming(string deploymentOrModelName, Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.StreamingChatCompletions>> GetChatCompletionsStreamingAsync(string deploymentOrModelName, Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Completions> GetCompletions(string deploymentOrModelName, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Completions> GetCompletions(string deploymentOrModelName, string prompt, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Completions>> GetCompletionsAsync(string deploymentOrModelName, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Completions>> GetCompletionsAsync(string deploymentOrModelName, string prompt, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.StreamingCompletions> GetCompletionsStreaming(string deploymentOrModelName, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.StreamingCompletions>> GetCompletionsStreamingAsync(string deploymentOrModelName, Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Embeddings> GetEmbeddings(string deploymentOrModelName, Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Embeddings>> GetEmbeddingsAsync(string deploymentOrModelName, Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenAIClientOptions : Azure.Core.ClientOptions
    {
        public OpenAIClientOptions(Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion version = Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion.V2023_03_15_Preview) { }
        public enum ServiceVersion
        {
            V2022_12_01 = 1,
            V2023_03_15_Preview = 2,
        }
    }
    public partial class StreamingChatChoice
    {
        internal StreamingChatChoice() { }
        public Azure.AI.OpenAI.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int? Index { get { throw null; } }
        public System.Collections.Generic.IAsyncEnumerable<Azure.AI.OpenAI.ChatMessage> GetMessageStreaming([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingChatCompletions : System.IDisposable
    {
        internal StreamingChatCompletions() { }
        public System.DateTimeOffset Created { get { throw null; } }
        public string Id { get { throw null; } }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public System.Collections.Generic.IAsyncEnumerable<Azure.AI.OpenAI.StreamingChatChoice> GetChoicesStreaming([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingChoice
    {
        internal StreamingChoice() { }
        public Azure.AI.OpenAI.CompletionsFinishReason FinishReason { get { throw null; } }
        public int? Index { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsLogProbabilityModel LogProbabilityModel { get { throw null; } }
        public System.Collections.Generic.IAsyncEnumerable<string> GetTextStreaming([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StreamingCompletions : System.IDisposable
    {
        internal StreamingCompletions() { }
        public System.DateTimeOffset Created { get { throw null; } }
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
