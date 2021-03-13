namespace Azure.Communication.Chat
{
    public partial class AddChatParticipantsErrors
    {
        internal AddChatParticipantsErrors() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Chat.CommunicationError> InvalidParticipants { get { throw null; } }
    }
    public partial class AddChatParticipantsResult
    {
        internal AddChatParticipantsResult() { }
        public Azure.Communication.Chat.AddChatParticipantsErrors Errors { get { throw null; } }
    }
    public partial class ChatClient
    {
        protected ChatClient() { }
        public ChatClient(System.Uri endpoint, Azure.Communication.CommunicationTokenCredential communicationTokenCredential, Azure.Communication.Chat.ChatClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.Chat.CreateChatThreadResult> CreateChatThread(string topic, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatParticipant> participants, string repeatabilityRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.CreateChatThreadResult>> CreateChatThreadAsync(string topic, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatParticipant> participants, string repeatabilityRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public const Azure.Communication.Chat.ChatClientOptions.ServiceVersion LatestVersion = Azure.Communication.Chat.ChatClientOptions.ServiceVersion.V2021_01_27_Preview4;
        public ChatClientOptions(Azure.Communication.Chat.ChatClientOptions.ServiceVersion version = Azure.Communication.Chat.ChatClientOptions.ServiceVersion.V2021_01_27_Preview4) { }
        public enum ServiceVersion
        {
            V2021_01_27_Preview4 = 1,
        }
    }
    public partial class ChatMessage
    {
        internal ChatMessage() { }
        public Azure.Communication.Chat.ChatMessageContent Content { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public System.DateTimeOffset? EditedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Communication.CommunicationIdentifier Sender { get { throw null; } }
        public string SenderDisplayName { get { throw null; } }
        public string SequenceId { get { throw null; } }
        public Azure.Communication.Chat.ChatMessageType Type { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ChatMessageContent
    {
        internal ChatMessageContent() { }
        public Azure.Communication.CommunicationIdentifier Initiator { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Chat.ChatParticipant> Participants { get { throw null; } }
        public string Topic { get { throw null; } }
    }
    public partial class ChatMessageReadReceipt
    {
        internal ChatMessageReadReceipt() { }
        public string ChatMessageId { get { throw null; } }
        public System.DateTimeOffset ReadOn { get { throw null; } }
        public Azure.Communication.CommunicationIdentifier Sender { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatMessageType : System.IEquatable<Azure.Communication.Chat.ChatMessageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatMessageType(string value) { throw null; }
        public static Azure.Communication.Chat.ChatMessageType Html { get { throw null; } }
        public static Azure.Communication.Chat.ChatMessageType ParticipantAdded { get { throw null; } }
        public static Azure.Communication.Chat.ChatMessageType ParticipantRemoved { get { throw null; } }
        public static Azure.Communication.Chat.ChatMessageType Text { get { throw null; } }
        public static Azure.Communication.Chat.ChatMessageType TopicUpdated { get { throw null; } }
        public bool Equals(Azure.Communication.Chat.ChatMessageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Chat.ChatMessageType left, Azure.Communication.Chat.ChatMessageType right) { throw null; }
        public static implicit operator Azure.Communication.Chat.ChatMessageType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Chat.ChatMessageType left, Azure.Communication.Chat.ChatMessageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ChatModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Communication.Chat.ChatMessage ChatMessage(string id, Azure.Communication.Chat.ChatMessageType type, string sequenceId, string version, Azure.Communication.Chat.ChatMessageContent content, string senderDisplayName, System.DateTimeOffset createdOn, string senderId, System.DateTimeOffset? deletedOn, System.DateTimeOffset? editedOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Communication.Chat.ChatMessageReadReceipt ChatMessageReadReceipt(Azure.Communication.CommunicationIdentifier sender, string chatMessageId, System.DateTimeOffset readOn) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Communication.Chat.ChatThreadInfo ChatThreadInfo(string id, string topic, System.DateTimeOffset? deletedOn, System.DateTimeOffset? lastMessageReceivedOn) { throw null; }
    }
    public partial class ChatParticipant
    {
        public ChatParticipant(Azure.Communication.CommunicationIdentifier identifier) { }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? ShareHistoryTime { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier User { get { throw null; } set { } }
    }
    public partial class ChatThread
    {
        internal ChatThread() { }
        public Azure.Communication.CommunicationIdentifier CreatedBy { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string Topic { get { throw null; } }
    }
    public partial class ChatThreadClient
    {
        protected ChatThreadClient() { }
        public virtual string Id { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.Chat.AddChatParticipantsResult> AddParticipant(Azure.Communication.Chat.ChatParticipant participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.AddChatParticipantsResult>> AddParticipantAsync(Azure.Communication.Chat.ChatParticipant participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Chat.AddChatParticipantsResult> AddParticipants(System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatParticipant> participants, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.AddChatParticipantsResult>> AddParticipantsAsync(System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatParticipant> participants, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteMessage(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMessageAsync(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Chat.ChatMessage> GetMessage(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.ChatMessage>> GetMessageAsync(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Chat.ChatMessage> GetMessages(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Chat.ChatMessage> GetMessagesAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Chat.ChatParticipant> GetParticipants(int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Chat.ChatParticipant> GetParticipantsAsync(int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Chat.ChatMessageReadReceipt> GetReadReceipts(int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Chat.ChatMessageReadReceipt> GetReadReceiptsAsync(int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipant(Azure.Communication.CommunicationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantAsync(Azure.Communication.CommunicationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> SendMessage(string content, Azure.Communication.Chat.ChatMessageType type = default(Azure.Communication.Chat.ChatMessageType), string senderDisplayName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> SendMessageAsync(string content, Azure.Communication.Chat.ChatMessageType type = default(Azure.Communication.Chat.ChatMessageType), string senderDisplayName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendReadReceipt(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendReadReceiptAsync(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendTypingNotification(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendTypingNotificationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(string messageId, string content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(string messageId, string content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateTopic(string topic, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateTopicAsync(string topic, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatThreadInfo
    {
        internal ChatThreadInfo() { }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastMessageReceivedOn { get { throw null; } }
        public string Topic { get { throw null; } }
    }
    public partial class CommunicationError
    {
        internal CommunicationError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Chat.CommunicationError> Details { get { throw null; } }
        public Azure.Communication.Chat.CommunicationError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class CreateChatThreadErrors
    {
        internal CreateChatThreadErrors() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Chat.CommunicationError> InvalidParticipants { get { throw null; } }
    }
    public partial class CreateChatThreadResult
    {
        internal CreateChatThreadResult() { }
        public Azure.Communication.Chat.ChatThread ChatThread { get { throw null; } }
        public Azure.Communication.Chat.CreateChatThreadErrors Errors { get { throw null; } }
    }
}
