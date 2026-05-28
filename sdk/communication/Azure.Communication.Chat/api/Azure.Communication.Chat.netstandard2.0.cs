namespace Azure.Communication.Chat
{
    public partial class AddChatParticipantsResult
    {
        internal AddChatParticipantsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Chat.ChatError> InvalidParticipants { get { throw null; } }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AzureCommunicationChatContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        public AzureCommunicationChatContext() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Communication.Chat.AzureCommunicationChatContext Default { get { throw null; } }
    }
    public partial class ChatAttachment
    {
        internal ChatAttachment() { }
        public Azure.Communication.Chat.ChatAttachmentType AttachmentType { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Uri PreviewUri { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatAttachmentType : System.IEquatable<Azure.Communication.Chat.ChatAttachmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatAttachmentType(string value) { throw null; }
        public static Azure.Communication.Chat.ChatAttachmentType File { get { throw null; } }
        public static Azure.Communication.Chat.ChatAttachmentType Image { get { throw null; } }
        public bool Equals(Azure.Communication.Chat.ChatAttachmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Chat.ChatAttachmentType left, Azure.Communication.Chat.ChatAttachmentType right) { throw null; }
        public static implicit operator Azure.Communication.Chat.ChatAttachmentType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Chat.ChatAttachmentType left, Azure.Communication.Chat.ChatAttachmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatClient
    {
        protected ChatClient() { }
        public ChatClient(System.Uri endpoint, Azure.Communication.CommunicationTokenCredential communicationTokenCredential, Azure.Communication.Chat.ChatClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.Chat.CreateChatThreadResult> CreateChatThread(Azure.Communication.Chat.CreateChatThreadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Chat.CreateChatThreadResult> CreateChatThread(string topic, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatParticipant> participants, string idempotencyToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.CreateChatThreadResult>> CreateChatThreadAsync(Azure.Communication.Chat.CreateChatThreadOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.CreateChatThreadResult>> CreateChatThreadAsync(string topic, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatParticipant> participants = null, string idempotencyToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteChatThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteChatThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.Chat.ChatThreadClient GetChatThreadClient(string threadId) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Chat.ChatThreadItem> GetChatThreads(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Chat.ChatThreadItem> GetChatThreadsAsync(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatClientOptions : Azure.Core.ClientOptions
    {
        public ChatClientOptions(Azure.Communication.Chat.ChatClientOptions.ServiceVersion version = Azure.Communication.Chat.ChatClientOptions.ServiceVersion.V2025_03_15) { }
        public enum ServiceVersion
        {
            V2021_03_07 = 1,
            V2021_09_07 = 2,
            V2023_11_07 = 3,
            V2024_03_07 = 4,
            V2025_03_15 = 5,
        }
    }
    public partial class ChatError
    {
        internal ChatError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Chat.ChatError> Details { get { throw null; } }
        public Azure.Communication.Chat.ChatError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class ChatMessage
    {
        internal ChatMessage() { }
        public Azure.Communication.Chat.ChatMessageContent Content { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public System.DateTimeOffset? EditedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.Communication.CommunicationIdentifier Sender { get { throw null; } }
        public string SenderDisplayName { get { throw null; } }
        public string SequenceId { get { throw null; } }
        public Azure.Communication.Chat.ChatMessageType Type { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ChatMessageContent
    {
        internal ChatMessageContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Chat.ChatAttachment> Attachments { get { throw null; } }
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
        public static Azure.Communication.Chat.AddChatParticipantsResult AddChatParticipantsResult(System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatError> invalidParticipants = null) { throw null; }
        public static Azure.Communication.Chat.ChatAttachment ChatAttachment(string id, Azure.Communication.Chat.ChatAttachmentType attachmentType, string name, System.Uri uri, System.Uri previewUri) { throw null; }
        public static Azure.Communication.Chat.ChatError ChatError(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatError> details = null, Azure.Communication.Chat.ChatError innerError = null) { throw null; }
        public static Azure.Communication.Chat.ChatMessage ChatMessage(string id, Azure.Communication.Chat.ChatMessageType type, string sequenceId, string version, Azure.Communication.Chat.ChatMessageContent content, string senderDisplayName, System.DateTimeOffset createdOn, string senderId, System.DateTimeOffset? deletedOn, System.DateTimeOffset? editedOn) { throw null; }
        public static Azure.Communication.Chat.ChatMessage ChatMessage(string id, Azure.Communication.Chat.ChatMessageType type, string sequenceId, string version, Azure.Communication.Chat.ChatMessageContent content, string senderDisplayName, System.DateTimeOffset createdOn, string senderId, System.DateTimeOffset? deletedOn, System.DateTimeOffset? editedOn, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata) { throw null; }
        public static Azure.Communication.Chat.ChatMessageContent ChatMessageContent(string message, string topic, Azure.Communication.CommunicationUserIdentifier communicationUserIdentifier, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatParticipant> participants) { throw null; }
        public static Azure.Communication.Chat.ChatMessageContent ChatMessageContent(string message, string topic, Azure.Communication.CommunicationUserIdentifier communicationUserIdentifier, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatParticipant> participants, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatAttachment> attachments = null) { throw null; }
        public static Azure.Communication.Chat.ChatMessageReadReceipt ChatMessageReadReceipt(Azure.Communication.CommunicationIdentifier sender, string chatMessageId, System.DateTimeOffset readOn) { throw null; }
        public static Azure.Communication.Chat.ChatParticipant ChatParticipant(Azure.Communication.CommunicationIdentifier user, string displayName, System.DateTimeOffset? shareHistoryTime) { throw null; }
        public static Azure.Communication.Chat.ChatParticipant ChatParticipant(Azure.Communication.CommunicationIdentifier user, string displayName, System.DateTimeOffset? shareHistoryTime, System.Collections.Generic.IDictionary<string, string> metadata) { throw null; }
        public static Azure.Communication.Chat.ChatThreadItem ChatThreadItem(string id, string topic, System.DateTimeOffset? deletedOn, System.DateTimeOffset? lastMessageReceivedOn) { throw null; }
        public static Azure.Communication.Chat.ChatThreadProperties ChatThreadProperties(string id, string topic, System.DateTimeOffset createdOn, Azure.Communication.CommunicationIdentifier createdBy, System.DateTimeOffset deletedOn) { throw null; }
        public static Azure.Communication.Chat.CreateChatThreadResult CreateChatThreadResult(Azure.Communication.Chat.ChatThreadProperties chatThread, System.Collections.Generic.IEnumerable<Azure.Communication.Chat.ChatError> invalidParticipants) { throw null; }
        public static Azure.Communication.Chat.SendChatMessageResult SendChatMessageResult(string id) { throw null; }
    }
    public partial class ChatParticipant
    {
        public ChatParticipant(Azure.Communication.CommunicationIdentifier identifier) { }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.DateTimeOffset? ShareHistoryTime { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier User { get { throw null; } set { } }
    }
    public abstract partial class ChatRetentionPolicy
    {
        protected ChatRetentionPolicy(Azure.Communication.Chat.RetentionPolicyKind kind) { }
        public Azure.Communication.Chat.RetentionPolicyKind Kind { get { throw null; } }
        public static Azure.Communication.Chat.ChatRetentionPolicy None() { throw null; }
        public static Azure.Communication.Chat.ChatRetentionPolicy ThreadCreationDate(int deleteThreadAfterDays) { throw null; }
    }
    public partial class ChatThreadClient
    {
        protected ChatThreadClient() { }
        public ChatThreadClient(string threadId, System.Uri endpoint, Azure.Communication.CommunicationTokenCredential communicationTokenCredential, Azure.Communication.Chat.ChatClientOptions options = null) { }
        public virtual string Id { get { throw null; } }
        public virtual Azure.Response AddParticipant(Azure.Communication.Chat.ChatParticipant participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddParticipantAsync(Azure.Communication.Chat.ChatParticipant participant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Communication.Chat.ChatThreadProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.ChatThreadProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Chat.ChatMessageReadReceipt> GetReadReceipts(int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Chat.ChatMessageReadReceipt> GetReadReceiptsAsync(int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveParticipant(Azure.Communication.CommunicationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveParticipantAsync(Azure.Communication.CommunicationIdentifier identifier, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Chat.SendChatMessageResult> SendMessage(Azure.Communication.Chat.SendChatMessageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Chat.SendChatMessageResult> SendMessage(string content, Azure.Communication.Chat.ChatMessageType type = default(Azure.Communication.Chat.ChatMessageType), string senderDisplayName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.SendChatMessageResult>> SendMessageAsync(Azure.Communication.Chat.SendChatMessageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Chat.SendChatMessageResult>> SendMessageAsync(string content, Azure.Communication.Chat.ChatMessageType type = default(Azure.Communication.Chat.ChatMessageType), string senderDisplayName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendReadReceipt(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendReadReceiptAsync(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendTypingNotification(Azure.Communication.Chat.TypingNotificationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendTypingNotification(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendTypingNotificationAsync(Azure.Communication.Chat.TypingNotificationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendTypingNotificationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(Azure.Communication.Chat.UpdateChatMessageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(string messageId, string content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(Azure.Communication.Chat.UpdateChatMessageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(string messageId, string content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateProperties(Azure.Communication.Chat.UpdateChatThreadPropertiesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdatePropertiesAsync(Azure.Communication.Chat.UpdateChatThreadPropertiesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateTopic(string topic, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateTopicAsync(string topic, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatThreadItem
    {
        internal ChatThreadItem() { }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastMessageReceivedOn { get { throw null; } }
        public string Topic { get { throw null; } }
    }
    public partial class ChatThreadProperties
    {
        internal ChatThreadProperties() { }
        public Azure.Communication.CommunicationIdentifier CreatedBy { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.Communication.Chat.ChatRetentionPolicy RetentionPolicy { get { throw null; } }
        public string Topic { get { throw null; } }
    }
    public partial class CreateChatThreadOptions
    {
        public CreateChatThreadOptions(string topic) { }
        public string IdempotencyToken { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Chat.ChatParticipant> Participants { get { throw null; } }
        public Azure.Communication.Chat.ChatRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Topic { get { throw null; } }
    }
    public partial class CreateChatThreadResult
    {
        internal CreateChatThreadResult() { }
        public Azure.Communication.Chat.ChatThreadProperties ChatThread { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Chat.ChatError> InvalidParticipants { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RetentionPolicyKind : System.IEquatable<Azure.Communication.Chat.RetentionPolicyKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RetentionPolicyKind(string value) { throw null; }
        public static Azure.Communication.Chat.RetentionPolicyKind None { get { throw null; } }
        public static Azure.Communication.Chat.RetentionPolicyKind ThreadCreationDate { get { throw null; } }
        public bool Equals(Azure.Communication.Chat.RetentionPolicyKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Chat.RetentionPolicyKind left, Azure.Communication.Chat.RetentionPolicyKind right) { throw null; }
        public static implicit operator Azure.Communication.Chat.RetentionPolicyKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Chat.RetentionPolicyKind left, Azure.Communication.Chat.RetentionPolicyKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SendChatMessageOptions
    {
        public SendChatMessageOptions() { }
        public string Content { get { throw null; } set { } }
        public Azure.Communication.Chat.ChatMessageType MessageType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string SenderDisplayName { get { throw null; } set { } }
    }
    public partial class SendChatMessageResult
    {
        internal SendChatMessageResult() { }
        public string Id { get { throw null; } }
    }
    public sealed partial class ThreadCreationDateRetentionPolicy : Azure.Communication.Chat.ChatRetentionPolicy
    {
        public ThreadCreationDateRetentionPolicy(int deleteThreadAfterDays) : base (default(Azure.Communication.Chat.RetentionPolicyKind)) { }
        public int DeleteThreadAfterDays { get { throw null; } }
    }
    public partial class TypingNotificationOptions
    {
        public TypingNotificationOptions() { }
        public string SenderDisplayName { get { throw null; } set { } }
    }
    public partial class UpdateChatMessageOptions
    {
        public UpdateChatMessageOptions() { }
        public string Content { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class UpdateChatThreadPropertiesOptions
    {
        public UpdateChatThreadPropertiesOptions() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.Communication.Chat.ChatRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public string Topic { get { throw null; } set { } }
    }
}
