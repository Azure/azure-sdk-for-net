namespace Azure.Messaging.WebPubSub.Clients
{
    public partial class AckMessage : Azure.Messaging.WebPubSub.Clients.WebPubSubMessage
    {
        public AckMessage(long ackId, bool success, Azure.Messaging.WebPubSub.Clients.AckMessageError error) { }
        public long AckId { get { throw null; } }
        public Azure.Messaging.WebPubSub.Clients.AckMessageError Error { get { throw null; } }
        public bool Success { get { throw null; } }
    }
    public partial class AckMessageError
    {
        public AckMessageError(string name, string message) { }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ConnectedMessage : Azure.Messaging.WebPubSub.Clients.WebPubSubMessage
    {
        public ConnectedMessage(string userId, string connectionId, string reconnectionToken) { }
        public string ConnectionId { get { throw null; } }
        public string ReconnectionToken { get { throw null; } }
        public string UserId { get { throw null; } }
    }
    public partial class DisconnectedMessage : Azure.Messaging.WebPubSub.Clients.WebPubSubMessage
    {
        public DisconnectedMessage(string reason) { }
        public string Reason { get { throw null; } }
    }
    public partial class GroupDataMessage : Azure.Messaging.WebPubSub.Clients.WebPubSubMessage
    {
        public GroupDataMessage(string group, Azure.Messaging.WebPubSub.Clients.WebPubSubDataType dataType, System.BinaryData data, long? sequenceId, string fromUserId) { }
        public System.BinaryData Data { get { throw null; } }
        public Azure.Messaging.WebPubSub.Clients.WebPubSubDataType DataType { get { throw null; } }
        public string FromUserId { get { throw null; } }
        public string Group { get { throw null; } }
        public long? SequenceId { get { throw null; } }
    }
    public partial class JoinGroupMessage : Azure.Messaging.WebPubSub.Clients.WebPubSubMessage
    {
        public JoinGroupMessage(string group, long? ackId) { }
        public long? AckId { get { throw null; } }
        public string Group { get { throw null; } }
    }
    public partial class LeaveGroupMessage : Azure.Messaging.WebPubSub.Clients.WebPubSubMessage
    {
        public LeaveGroupMessage(string group, long? ackId) { }
        public long? AckId { get { throw null; } }
        public string Group { get { throw null; } }
    }
    public partial class SendEventMessage : Azure.Messaging.WebPubSub.Clients.WebPubSubMessage
    {
        public SendEventMessage(string eventName, System.BinaryData data, Azure.Messaging.WebPubSub.Clients.WebPubSubDataType dataType, long? ackId) { }
        public long? AckId { get { throw null; } }
        public System.BinaryData Data { get { throw null; } }
        public Azure.Messaging.WebPubSub.Clients.WebPubSubDataType DataType { get { throw null; } }
        public string EventName { get { throw null; } }
    }
    public partial class SendMessageFailedException : System.Exception
    {
        internal SendMessageFailedException() { }
        public long? AckId { get { throw null; } }
        public string Code { get { throw null; } }
    }
    public partial class SendToGroupMessage : Azure.Messaging.WebPubSub.Clients.WebPubSubMessage
    {
        public SendToGroupMessage(string group, System.BinaryData data, Azure.Messaging.WebPubSub.Clients.WebPubSubDataType dataType, long? ackId, bool noEcho) { }
        public long? AckId { get { throw null; } }
        public System.BinaryData Data { get { throw null; } }
        public Azure.Messaging.WebPubSub.Clients.WebPubSubDataType DataType { get { throw null; } }
        public string Group { get { throw null; } }
        public bool NoEcho { get { throw null; } }
    }
    public partial class SequenceAckMessage : Azure.Messaging.WebPubSub.Clients.WebPubSubMessage
    {
        public SequenceAckMessage(long sequenceId) { }
        public long SequenceId { get { throw null; } }
    }
    public partial class ServerDataMessage : Azure.Messaging.WebPubSub.Clients.WebPubSubMessage
    {
        public ServerDataMessage(Azure.Messaging.WebPubSub.Clients.WebPubSubDataType dataType, System.BinaryData data, long? sequenceId) { }
        public System.BinaryData Data { get { throw null; } }
        public Azure.Messaging.WebPubSub.Clients.WebPubSubDataType DataType { get { throw null; } }
        public long? SequenceId { get { throw null; } }
    }
    public partial class WebPubSubClient
    {
        protected WebPubSubClient() { }
        public WebPubSubClient(Azure.Messaging.WebPubSub.Clients.WebPubSubClientCredential credential, Azure.Messaging.WebPubSub.Clients.WebPubSubClientOptions options = null) { }
        public WebPubSubClient(System.Uri clientAccessUri) { }
        public WebPubSubClient(System.Uri clientAccessUri, Azure.Messaging.WebPubSub.Clients.WebPubSubClientOptions options) { }
        public string ConnectionId { get { throw null; } }
        public event System.Func<Azure.Messaging.WebPubSub.Clients.WebPubSubConnectedEventArgs, System.Threading.Tasks.Task> Connected { add { } remove { } }
        public event System.Func<Azure.Messaging.WebPubSub.Clients.WebPubSubDisconnectedEventArgs, System.Threading.Tasks.Task> Disconnected { add { } remove { } }
        public event System.Func<Azure.Messaging.WebPubSub.Clients.WebPubSubGroupMessageEventArgs, System.Threading.Tasks.Task> GroupMessageReceived { add { } remove { } }
        public event System.Func<Azure.Messaging.WebPubSub.Clients.WebPubSubRejoinGroupFailedEventArgs, System.Threading.Tasks.Task> RejoinGroupFailed { add { } remove { } }
        public event System.Func<Azure.Messaging.WebPubSub.Clients.WebPubSubServerMessageEventArgs, System.Threading.Tasks.Task> ServerMessageReceived { add { } remove { } }
        public event System.Func<Azure.Messaging.WebPubSub.Clients.WebPubSubStoppedEventArgs, System.Threading.Tasks.Task> Stopped { add { } remove { } }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        protected virtual System.Threading.Tasks.ValueTask DisposeAsyncCore() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.WebPubSub.Clients.WebPubSubResult> JoinGroupAsync(string group, long? ackId = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.WebPubSub.Clients.WebPubSubResult> LeaveGroupAsync(string group, long? ackId = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.WebPubSub.Clients.WebPubSubResult> SendEventAsync(string eventName, System.BinaryData content, Azure.Messaging.WebPubSub.Clients.WebPubSubDataType dataType, long? ackId = default(long?), bool fireAndForget = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Messaging.WebPubSub.Clients.WebPubSubResult> SendToGroupAsync(string group, System.BinaryData content, Azure.Messaging.WebPubSub.Clients.WebPubSubDataType dataType, long? ackId = default(long?), bool noEcho = false, bool fireAndForget = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task StartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task StopAsync() { throw null; }
    }
    public partial class WebPubSubClientCredential
    {
        protected WebPubSubClientCredential() { }
        public WebPubSubClientCredential(System.Func<System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<System.Uri>> clientAccessUriProvider) { }
        public WebPubSubClientCredential(System.Uri clientAccessUri) { }
        public virtual System.Threading.Tasks.ValueTask<System.Uri> GetClientAccessUriAsync(System.Threading.CancellationToken token = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebPubSubClientOptions
    {
        public WebPubSubClientOptions() { }
        public bool AutoReconnect { get { throw null; } set { } }
        public bool AutoRejoinGroups { get { throw null; } set { } }
        public Azure.Core.RetryOptions MessageRetryOptions { get { throw null; } }
        public Azure.Messaging.WebPubSub.Clients.WebPubSubProtocol Protocol { get { throw null; } set { } }
    }
    public partial class WebPubSubConnectedEventArgs
    {
        internal WebPubSubConnectedEventArgs() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string ConnectionId { get { throw null; } }
        public string UserId { get { throw null; } }
    }
    public enum WebPubSubDataType
    {
        Json = 0,
        Text = 1,
        Binary = 2,
        Protobuf = 3,
    }
    public partial class WebPubSubDisconnectedEventArgs
    {
        internal WebPubSubDisconnectedEventArgs() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public string ConnectionId { get { throw null; } }
        public Azure.Messaging.WebPubSub.Clients.DisconnectedMessage DisconnectedMessage { get { throw null; } }
    }
    public partial class WebPubSubGroupMessageEventArgs
    {
        internal WebPubSubGroupMessageEventArgs() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public Azure.Messaging.WebPubSub.Clients.GroupDataMessage Message { get { throw null; } }
    }
    public partial class WebPubSubJsonProtocol : Azure.Messaging.WebPubSub.Clients.WebPubSubProtocol
    {
        public WebPubSubJsonProtocol() { }
        public override bool IsReliable { get { throw null; } }
        public override string Name { get { throw null; } }
        public override Azure.Messaging.WebPubSub.Clients.WebPubSubProtocolMessageType WebSocketMessageType { get { throw null; } }
        public override System.ReadOnlyMemory<byte> GetMessageBytes(Azure.Messaging.WebPubSub.Clients.WebPubSubMessage message) { throw null; }
        public override System.Collections.Generic.IReadOnlyList<Azure.Messaging.WebPubSub.Clients.WebPubSubMessage> ParseMessage(System.Buffers.ReadOnlySequence<byte> input) { throw null; }
        public override void WriteMessage(Azure.Messaging.WebPubSub.Clients.WebPubSubMessage message, System.Buffers.IBufferWriter<byte> output) { }
    }
    public partial class WebPubSubJsonReliableProtocol : Azure.Messaging.WebPubSub.Clients.WebPubSubProtocol
    {
        public WebPubSubJsonReliableProtocol() { }
        public override bool IsReliable { get { throw null; } }
        public override string Name { get { throw null; } }
        public override Azure.Messaging.WebPubSub.Clients.WebPubSubProtocolMessageType WebSocketMessageType { get { throw null; } }
        public override System.ReadOnlyMemory<byte> GetMessageBytes(Azure.Messaging.WebPubSub.Clients.WebPubSubMessage message) { throw null; }
        public override System.Collections.Generic.IReadOnlyList<Azure.Messaging.WebPubSub.Clients.WebPubSubMessage> ParseMessage(System.Buffers.ReadOnlySequence<byte> input) { throw null; }
        public override void WriteMessage(Azure.Messaging.WebPubSub.Clients.WebPubSubMessage message, System.Buffers.IBufferWriter<byte> output) { }
    }
    public abstract partial class WebPubSubMessage
    {
        protected WebPubSubMessage() { }
    }
    public abstract partial class WebPubSubProtocol
    {
        protected WebPubSubProtocol() { }
        public abstract bool IsReliable { get; }
        public abstract string Name { get; }
        public abstract Azure.Messaging.WebPubSub.Clients.WebPubSubProtocolMessageType WebSocketMessageType { get; }
        public abstract System.ReadOnlyMemory<byte> GetMessageBytes(Azure.Messaging.WebPubSub.Clients.WebPubSubMessage message);
        public abstract System.Collections.Generic.IReadOnlyList<Azure.Messaging.WebPubSub.Clients.WebPubSubMessage> ParseMessage(System.Buffers.ReadOnlySequence<byte> input);
        public abstract void WriteMessage(Azure.Messaging.WebPubSub.Clients.WebPubSubMessage message, System.Buffers.IBufferWriter<byte> output);
    }
    public enum WebPubSubProtocolMessageType
    {
        Text = 0,
        Binary = 1,
    }
    public partial class WebPubSubRejoinGroupFailedEventArgs
    {
        internal WebPubSubRejoinGroupFailedEventArgs() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public System.Exception Exception { get { throw null; } }
        public string Group { get { throw null; } }
    }
    public partial class WebPubSubResult
    {
        internal WebPubSubResult() { }
        public long? AckId { get { throw null; } }
        public bool IsDuplicated { get { throw null; } }
    }
    public partial class WebPubSubServerMessageEventArgs
    {
        internal WebPubSubServerMessageEventArgs() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public Azure.Messaging.WebPubSub.Clients.ServerDataMessage Message { get { throw null; } }
    }
    public partial class WebPubSubStoppedEventArgs
    {
        internal WebPubSubStoppedEventArgs() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } }
    }
}
