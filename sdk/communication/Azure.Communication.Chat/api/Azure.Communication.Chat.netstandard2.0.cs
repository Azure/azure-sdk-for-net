namespace Azure.Communication.Chat
{
    public partial class ChatClient
    {
        protected ChatClient() { }
        public ChatClient(System.Uri endpointUrl, Azure.Communication.CommunicationTokenCredential communicationTokenCredential, Azure.Communication.Chat.ChatClientOptions? options = null) { }
        public virtual Azure.Communication.Chat.ChatThreadClient CreateChatThread(string topic, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatThreadMember> members, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.Chat.ChatThreadClient> CreateChatThreadAsync(string topic, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatThreadMember> members, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteChatThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteChatThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Chat.ChatThread> GetChatThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.ChatThread>> GetChatThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.Chat.ChatThreadClient GetChatThreadClient(string threadId) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Chat.ChatThreadInfo> GetChatThreadsInfo(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Chat.ChatThreadInfo> GetChatThreadsInfoAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatClientOptions : Azure.Core.ClientOptions
    {
        public const Azure.Communication.Chat.ChatClientOptions.ServiceVersion LatestVersion = Azure.Communication.Chat.ChatClientOptions.ServiceVersion.V1;
        public ChatClientOptions(Azure.Communication.Chat.ChatClientOptions.ServiceVersion version = Azure.Communication.Chat.ChatClientOptions.ServiceVersion.V1) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
    public partial class ChatMessage
    {
        internal ChatMessage() { }
        public string Content { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public System.DateTimeOffset? EditedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Communication.Chat.ChatMessagePriority? Priority { get { throw null; } }
        public Azure.Communication.CommunicationUserIdentifier Sender { get { throw null; } }
        public string SenderDisplayName { get { throw null; } }
        public string Type { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatMessagePriority : System.IEquatable<Azure.Communication.Chat.ChatMessagePriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatMessagePriority(string value) { throw null; }
        public static Azure.Communication.Chat.ChatMessagePriority High { get { throw null; } }
        public static Azure.Communication.Chat.ChatMessagePriority Normal { get { throw null; } }
        public bool Equals(Azure.Communication.Chat.ChatMessagePriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Chat.ChatMessagePriority left, Azure.Communication.Chat.ChatMessagePriority right) { throw null; }
        public static implicit operator Azure.Communication.Chat.ChatMessagePriority (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Chat.ChatMessagePriority left, Azure.Communication.Chat.ChatMessagePriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatThread
    {
        internal ChatThread() { }
        public Azure.Communication.CommunicationUserIdentifier CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Chat.ChatThreadMember> Members { get { throw null; } }
        public string Topic { get { throw null; } }
    }
    public partial class ChatThreadClient
    {
        protected ChatThreadClient() { }
        public virtual string Id { get { throw null; } }
        public virtual Azure.Response AddMembers(System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatThreadMember> members, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddMembersAsync(System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatThreadMember> members, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteMessage(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMessageAsync(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Chat.ChatThreadMember> GetMembers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Chat.ChatThreadMember> GetMembersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Chat.ChatMessage> GetMessage(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.ChatMessage>> GetMessageAsync(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Chat.ChatMessage> GetMessages(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Chat.ChatMessage> GetMessagesAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Chat.ReadReceipt> GetReadReceipts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Chat.ReadReceipt> GetReadReceiptsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveMember(Azure.Communication.CommunicationUserIdentifier user, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveMemberAsync(Azure.Communication.CommunicationUserIdentifier user, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Chat.SendChatMessageResult> SendMessage(string content, Azure.Communication.Chat.ChatMessagePriority? priority = default(Azure.Communication.Chat.ChatMessagePriority?), string senderDisplayName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.SendChatMessageResult>> SendMessageAsync(string content, Azure.Communication.Chat.ChatMessagePriority? priority = default(Azure.Communication.Chat.ChatMessagePriority?), string senderDisplayName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendReadReceipt(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendReadReceiptAsync(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendTypingNotification(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendTypingNotificationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(string messageId, string content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(string messageId, string content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateThread(string topic, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateThreadAsync(string topic, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatThreadInfo
    {
        internal ChatThreadInfo() { }
        public string Id { get { throw null; } }
        public bool? IsDeleted { get { throw null; } }
        public System.DateTimeOffset? LastMessageReceivedOn { get { throw null; } }
        public string Topic { get { throw null; } }
    }
    public partial class ChatThreadMember
    {
        public ChatThreadMember(Azure.Communication.CommunicationUserIdentifier communicationUser) { }
        public string? DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? ShareHistoryTime { get { throw null; } set { } }
        public Azure.Communication.CommunicationUserIdentifier User { get { throw null; } set { } }
    }
    public partial class ReadReceipt
    {
        internal ReadReceipt() { }
        public string ChatMessageId { get { throw null; } }
        public System.DateTimeOffset? ReadOn { get { throw null; } }
        public Azure.Communication.CommunicationUserIdentifier Sender { get { throw null; } }
    }
    public partial class SendChatMessageResult
    {
        internal SendChatMessageResult() { }
        public string Id { get { throw null; } }
    }
}
namespace Azure.Communication.Chat.Models
{
    public static partial class ChatModelFactory
    {
        public static Azure.Communication.Chat.ChatMessage ChatMessage(string id, string type, Azure.Communication.Chat.ChatMessagePriority? priority, string version, string content, string senderDisplayName, System.DateTimeOffset? createdOn, string senderId, System.DateTimeOffset? deletedOn, System.DateTimeOffset? editedOn) { throw null; }
        public static Azure.Communication.Chat.ChatThreadInfo ChatThreadInfo(string id, string topic, bool? isDeleted, System.DateTimeOffset? lastMessageReceivedOn) { throw null; }
        public static Azure.Communication.Chat.ReadReceipt ReadReceipt(string senderId, string chatMessageId, System.DateTimeOffset? readOn) { throw null; }
        public static Azure.Communication.Chat.SendChatMessageResult SendChatMessageResult(string id) { throw null; }
    }
}
