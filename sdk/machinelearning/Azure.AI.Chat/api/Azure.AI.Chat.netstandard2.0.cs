namespace Azure.AI.Chat
{
    public static partial class AIChatModelFactory
    {
        public static Azure.AI.Chat.ChatChoice ChatChoice(long index = (long)0, Azure.AI.Chat.ChatMessage message = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> extraArguments = null, System.BinaryData sessionState = null, Azure.AI.Chat.FinishReason finishReason = default(Azure.AI.Chat.FinishReason)) { throw null; }
        public static Azure.AI.Chat.ChatCompletion ChatCompletion(System.Collections.Generic.IEnumerable<Azure.AI.Chat.ChatChoice> choices = null) { throw null; }
        public static Azure.AI.Chat.ChatCompletionChunk ChatCompletionChunk(System.Collections.Generic.IEnumerable<Azure.AI.Chat.ChoiceDelta> choices = null) { throw null; }
        public static Azure.AI.Chat.ChatMessageDelta ChatMessageDelta(string content = null, Azure.AI.Chat.ChatRole? role = default(Azure.AI.Chat.ChatRole?), System.BinaryData sessionState = null) { throw null; }
        public static Azure.AI.Chat.ChoiceDelta ChoiceDelta(long index = (long)0, Azure.AI.Chat.ChatMessageDelta delta = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> extraArguments = null, System.BinaryData sessionState = null, Azure.AI.Chat.FinishReason? finishReason = default(Azure.AI.Chat.FinishReason?)) { throw null; }
    }
    public partial class ChatChoice
    {
        internal ChatChoice() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ExtraArguments { get { throw null; } }
        public Azure.AI.Chat.FinishReason FinishReason { get { throw null; } }
        public long Index { get { throw null; } }
        public Azure.AI.Chat.ChatMessage Message { get { throw null; } }
        public System.BinaryData SessionState { get { throw null; } }
    }
    public partial class ChatClient
    {
        protected ChatClient() { }
        public ChatClient(System.Uri endpoint) { }
        public ChatClient(System.Uri endpoint, Azure.AI.Chat.ChatClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Chat.ChatCompletion> Create(Azure.AI.Chat.ChatCompletionOptions chatCompletionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Chat.ChatCompletion>> CreateAsync(Azure.AI.Chat.ChatCompletionOptions chatCompletionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Chat.ChatCompletionChunk> CreateStreaming(Azure.AI.Chat.StreamingChatCompletionOptions streamingChatCompletionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateStreaming(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Chat.ChatCompletionChunk>> CreateStreamingAsync(Azure.AI.Chat.StreamingChatCompletionOptions streamingChatCompletionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateStreamingAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ChatClientOptions : Azure.Core.ClientOptions
    {
        public ChatClientOptions(Azure.AI.Chat.ChatClientOptions.ServiceVersion version = Azure.AI.Chat.ChatClientOptions.ServiceVersion.V2023_10_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_10_01_Preview = 1,
        }
    }
    public partial class ChatCompletion
    {
        internal ChatCompletion() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Chat.ChatChoice> Choices { get { throw null; } }
    }
    public partial class ChatCompletionChunk
    {
        internal ChatCompletionChunk() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Chat.ChoiceDelta> Choices { get { throw null; } }
    }
    public partial class ChatCompletionOptions
    {
        public ChatCompletionOptions(System.Collections.Generic.IEnumerable<Azure.AI.Chat.ChatMessage> messages, System.BinaryData sessionState, System.Collections.Generic.IDictionary<string, System.BinaryData> extraArguments) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExtraArguments { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Chat.ChatMessage> Messages { get { throw null; } }
        public System.BinaryData SessionState { get { throw null; } }
        public bool Stream { get { throw null; } }
    }
    public partial class ChatMessage
    {
        public ChatMessage(string content, Azure.AI.Chat.ChatRole role, System.BinaryData sessionState) { }
        public string Content { get { throw null; } set { } }
        public Azure.AI.Chat.ChatRole Role { get { throw null; } set { } }
        public System.BinaryData SessionState { get { throw null; } set { } }
    }
    public partial class ChatMessageDelta
    {
        internal ChatMessageDelta() { }
        public string Content { get { throw null; } }
        public Azure.AI.Chat.ChatRole? Role { get { throw null; } }
        public System.BinaryData SessionState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatRole : System.IEquatable<Azure.AI.Chat.ChatRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatRole(string value) { throw null; }
        public static Azure.AI.Chat.ChatRole Assistant { get { throw null; } }
        public static Azure.AI.Chat.ChatRole System { get { throw null; } }
        public static Azure.AI.Chat.ChatRole User { get { throw null; } }
        public bool Equals(Azure.AI.Chat.ChatRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Chat.ChatRole left, Azure.AI.Chat.ChatRole right) { throw null; }
        public static implicit operator Azure.AI.Chat.ChatRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.Chat.ChatRole left, Azure.AI.Chat.ChatRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChoiceDelta
    {
        internal ChoiceDelta() { }
        public Azure.AI.Chat.ChatMessageDelta Delta { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ExtraArguments { get { throw null; } }
        public Azure.AI.Chat.FinishReason? FinishReason { get { throw null; } }
        public long Index { get { throw null; } }
        public System.BinaryData SessionState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FinishReason : System.IEquatable<Azure.AI.Chat.FinishReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FinishReason(string value) { throw null; }
        public static Azure.AI.Chat.FinishReason ContentFiltered { get { throw null; } }
        public static Azure.AI.Chat.FinishReason FunctionCall { get { throw null; } }
        public static Azure.AI.Chat.FinishReason Stopped { get { throw null; } }
        public static Azure.AI.Chat.FinishReason TokenLimitReached { get { throw null; } }
        public bool Equals(Azure.AI.Chat.FinishReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Chat.FinishReason left, Azure.AI.Chat.FinishReason right) { throw null; }
        public static implicit operator Azure.AI.Chat.FinishReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Chat.FinishReason left, Azure.AI.Chat.FinishReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StreamingChatCompletionOptions
    {
        public StreamingChatCompletionOptions(System.Collections.Generic.IEnumerable<Azure.AI.Chat.ChatMessage> messages, System.BinaryData sessionState, System.Collections.Generic.IDictionary<string, System.BinaryData> extraArguments) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExtraArguments { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Chat.ChatMessage> Messages { get { throw null; } }
        public System.BinaryData SessionState { get { throw null; } }
        public bool Stream { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIChatClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Chat.ChatClient, Azure.AI.Chat.ChatClientOptions> AddChatClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Chat.ChatClient, Azure.AI.Chat.ChatClientOptions> AddChatClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
