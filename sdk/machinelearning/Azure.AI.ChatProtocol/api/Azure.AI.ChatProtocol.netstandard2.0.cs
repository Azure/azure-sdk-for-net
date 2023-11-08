namespace Azure.AI.ChatProtocol
{
    public static partial class AIChatProtocolModelFactory
    {
        public static Azure.AI.ChatProtocol.ChatChoice ChatChoice(long index = (long)0, Azure.AI.ChatProtocol.ChatMessage message = null, System.BinaryData sessionState = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> context = null, Azure.AI.ChatProtocol.FinishReason finishReason = default(Azure.AI.ChatProtocol.FinishReason)) { throw null; }
        public static Azure.AI.ChatProtocol.ChatCompletion ChatCompletion(System.Collections.Generic.IEnumerable<Azure.AI.ChatProtocol.ChatChoice> choices = null) { throw null; }
        public static Azure.AI.ChatProtocol.ChatCompletionChunk ChatCompletionChunk(System.Collections.Generic.IEnumerable<Azure.AI.ChatProtocol.ChoiceDelta> choices = null) { throw null; }
        public static Azure.AI.ChatProtocol.ChoiceDelta ChoiceDelta(long index = (long)0, Azure.AI.ChatProtocol.ChatMessageDelta delta = null, System.BinaryData sessionState = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> context = null, Azure.AI.ChatProtocol.FinishReason? finishReason = default(Azure.AI.ChatProtocol.FinishReason?)) { throw null; }
    }
    public partial class ChatChoice
    {
        internal ChatChoice() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Context { get { throw null; } }
        public Azure.AI.ChatProtocol.FinishReason FinishReason { get { throw null; } }
        public long Index { get { throw null; } }
        public Azure.AI.ChatProtocol.ChatMessage Message { get { throw null; } }
        public System.BinaryData SessionState { get { throw null; } }
    }
    public partial class ChatCompletion
    {
        internal ChatCompletion() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ChatProtocol.ChatChoice> Choices { get { throw null; } }
    }
    public partial class ChatCompletionChunk
    {
        internal ChatCompletionChunk() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ChatProtocol.ChoiceDelta> Choices { get { throw null; } }
    }
    public partial class ChatCompletionOptions
    {
        public ChatCompletionOptions(System.Collections.Generic.IEnumerable<Azure.AI.ChatProtocol.ChatMessage> messages) { }
        public ChatCompletionOptions(System.Collections.Generic.IList<Azure.AI.ChatProtocol.ChatMessage> messages, System.BinaryData sessionState, System.Collections.Generic.IDictionary<string, System.BinaryData> context = null) { }
        public ChatCompletionOptions(System.Collections.Generic.IList<Azure.AI.ChatProtocol.ChatMessage> messages, System.Collections.Generic.IDictionary<string, System.BinaryData> context) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Context { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ChatProtocol.ChatMessage> Messages { get { throw null; } }
        public System.BinaryData SessionState { get { throw null; } set { } }
    }
    public abstract partial class ChatMessage
    {
        protected ChatMessage(Azure.AI.ChatProtocol.ChatRole role) { }
        public Azure.AI.ChatProtocol.ChatRole Role { get { throw null; } set { } }
        public System.BinaryData SessionState { get { throw null; } set { } }
    }
    public abstract partial class ChatMessageDelta
    {
        protected ChatMessageDelta() { }
        public Azure.AI.ChatProtocol.ChatRole? Role { get { throw null; } }
        public System.BinaryData SessionState { get { throw null; } }
    }
    public partial class ChatProtocolClient
    {
        protected ChatProtocolClient() { }
        public ChatProtocolClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ChatProtocolClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.ChatProtocol.ChatProtocolClientOptions options) { }
        public ChatProtocolClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ChatProtocolClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.ChatProtocol.ChatProtocolClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.ChatProtocol.ChatCompletion> Create(Azure.AI.ChatProtocol.ChatCompletionOptions chatCompletionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ChatProtocol.ChatCompletion>> CreateAsync(Azure.AI.ChatProtocol.ChatCompletionOptions chatCompletionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IEnumerable<Azure.AI.ChatProtocol.ChatCompletionChunk>> CreateStreaming(Azure.AI.ChatProtocol.StreamingChatCompletionOptions streamingChatCompletionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IAsyncEnumerable<Azure.AI.ChatProtocol.ChatCompletionChunk>>> CreateStreamingAsync(Azure.AI.ChatProtocol.StreamingChatCompletionOptions streamingChatCompletionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatProtocolClientOptions : Azure.Core.ClientOptions
    {
        public ChatProtocolClientOptions(string chatRoute = "chat", string[]? authorizationScopes = null, string? apiKeyHeader = null) { }
        public string? APIKeyHeader { get { throw null; } set { } }
        public string[]? AuthorizationScopes { get { throw null; } set { } }
        public string ChatRoute { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2023_10_01_Preview = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatRole : System.IEquatable<Azure.AI.ChatProtocol.ChatRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatRole(string value) { throw null; }
        public static Azure.AI.ChatProtocol.ChatRole Assistant { get { throw null; } }
        public static Azure.AI.ChatProtocol.ChatRole System { get { throw null; } }
        public static Azure.AI.ChatProtocol.ChatRole User { get { throw null; } }
        public bool Equals(Azure.AI.ChatProtocol.ChatRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ChatProtocol.ChatRole left, Azure.AI.ChatProtocol.ChatRole right) { throw null; }
        public static implicit operator Azure.AI.ChatProtocol.ChatRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.ChatProtocol.ChatRole left, Azure.AI.ChatProtocol.ChatRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChoiceDelta
    {
        internal ChoiceDelta() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Context { get { throw null; } }
        public Azure.AI.ChatProtocol.ChatMessageDelta Delta { get { throw null; } }
        public Azure.AI.ChatProtocol.FinishReason? FinishReason { get { throw null; } }
        public long Index { get { throw null; } }
        public System.BinaryData SessionState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FinishReason : System.IEquatable<Azure.AI.ChatProtocol.FinishReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FinishReason(string value) { throw null; }
        public static Azure.AI.ChatProtocol.FinishReason Stopped { get { throw null; } }
        public static Azure.AI.ChatProtocol.FinishReason TokenLimitReached { get { throw null; } }
        public bool Equals(Azure.AI.ChatProtocol.FinishReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ChatProtocol.FinishReason left, Azure.AI.ChatProtocol.FinishReason right) { throw null; }
        public static implicit operator Azure.AI.ChatProtocol.FinishReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.ChatProtocol.FinishReason left, Azure.AI.ChatProtocol.FinishReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingChatCompletionOptions
    {
        public StreamingChatCompletionOptions(System.Collections.Generic.IEnumerable<Azure.AI.ChatProtocol.ChatMessage> messages) { }
        public StreamingChatCompletionOptions(System.Collections.Generic.IList<Azure.AI.ChatProtocol.ChatMessage> messages, System.BinaryData sessionState, System.Collections.Generic.IDictionary<string, System.BinaryData> context = null) { }
        public StreamingChatCompletionOptions(System.Collections.Generic.IList<Azure.AI.ChatProtocol.ChatMessage> messages, System.Collections.Generic.IDictionary<string, System.BinaryData> context) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Context { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ChatProtocol.ChatMessage> Messages { get { throw null; } }
        public System.BinaryData SessionState { get { throw null; } set { } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIChatProtocolClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ChatProtocol.ChatProtocolClient, Azure.AI.ChatProtocol.ChatProtocolClientOptions> AddChatProtocolClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ChatProtocol.ChatProtocolClient, Azure.AI.ChatProtocol.ChatProtocolClientOptions> AddChatProtocolClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ChatProtocol.ChatProtocolClient, Azure.AI.ChatProtocol.ChatProtocolClientOptions> AddChatProtocolClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
