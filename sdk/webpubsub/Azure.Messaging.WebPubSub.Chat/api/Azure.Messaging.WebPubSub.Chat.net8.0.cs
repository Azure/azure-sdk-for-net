namespace Azure.Messaging.WebPubSub.Chat
{
    public partial class AzureMessagingWebPubSubChatContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMessagingWebPubSubChatContext() { }
        public static Azure.Messaging.WebPubSub.Chat.AzureMessagingWebPubSubChatContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ChatConversation : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatConversation>
    {
        internal ChatConversation() { }
        public Azure.ETag Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string ParentRoom { get { throw null; } }
        protected virtual Azure.Messaging.WebPubSub.Chat.ChatConversation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.ChatConversation (Azure.Response response) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.ChatConversation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.ChatConversation System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatConversation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatConversation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.ChatConversation System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatConversation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatConversation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatConversation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRole : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatRole>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRole>
    {
        public ChatRole(System.Collections.Generic.IEnumerable<string> permissions) { }
        public Azure.ETag Etag { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<string> Permissions { get { throw null; } }
        protected virtual Azure.Messaging.WebPubSub.Chat.ChatRole JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.ChatRole (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.WebPubSub.Chat.ChatRole chatRole) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.ChatRole PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.ChatRole System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.ChatRole System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ChatRoles
    {
        public const string RoomMember = "room.member";
        public const string RoomOperator = "room.operator";
        public const string UserNormal = "user.normal";
    }
    public partial class ChatRoom : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatRoom>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRoom>
    {
        public ChatRoom(string title) { }
        public string DefaultConversation { get { throw null; } }
        public Azure.ETag Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string Title { get { throw null; } set { } }
        protected virtual Azure.Messaging.WebPubSub.Chat.ChatRoom JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.ChatRoom (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.WebPubSub.Chat.ChatRoom chatRoom) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.ChatRoom PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.ChatRoom System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatRoom>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatRoom>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.ChatRoom System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRoom>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRoom>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRoom>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatRoomMember : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatRoomMember>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRoomMember>
    {
        public ChatRoomMember(string roleName) { }
        public Azure.ETag Etag { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public string UserId { get { throw null; } }
        protected virtual Azure.Messaging.WebPubSub.Chat.ChatRoomMember JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.ChatRoomMember (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.WebPubSub.Chat.ChatRoomMember chatRoomMember) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.ChatRoomMember PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.ChatRoomMember System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatRoomMember>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatRoomMember>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.ChatRoomMember System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRoomMember>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRoomMember>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatRoomMember>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ChatUser : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatUser>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatUser>
    {
        internal ChatUser() { }
        public Azure.ETag Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string Nickname { get { throw null; } set { } }
        protected virtual Azure.Messaging.WebPubSub.Chat.ChatUser JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.ChatUser (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.WebPubSub.Chat.ChatUser chatUser) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.ChatUser PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.ChatUser System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.ChatUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.ChatUser System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.ChatUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetClientAccessTokenOptions
    {
        public GetClientAccessTokenOptions() { }
        public System.TimeSpan ExpiresAfter { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class HumanChatUser : Azure.Messaging.WebPubSub.Chat.ChatUser, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.HumanChatUser>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.HumanChatUser>
    {
        public HumanChatUser(string nickname, string roleName) { }
        public string RoleName { get { throw null; } set { } }
        protected override Azure.Messaging.WebPubSub.Chat.ChatUser JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Messaging.WebPubSub.Chat.ChatUser PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.HumanChatUser System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.HumanChatUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.HumanChatUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.HumanChatUser System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.HumanChatUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.HumanChatUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.HumanChatUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class RoomPermissions
    {
        public const string History = "room.history";
        public const string InviteUser = "room.invite";
        public const string PublishMessage = "room.publish_message";
        public const string RemoveUser = "room.remove_user";
    }
    public static partial class UserPermissions
    {
        public const string CreateRoom = "user.create_room";
        public const string FetchAllRooms = "user.fetch_all_rooms";
    }
    public partial class WebPubSubChatMessage : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage>
    {
        public WebPubSubChatMessage(string createdBy, Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent content) { }
        public Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent Content { get { throw null; } set { } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.ETag Etag { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage (Azure.Response response) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubChatMessageContent : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent>
    {
        public WebPubSubChatMessageContent() { }
        public System.BinaryData Binary { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class WebPubSubChatModelFactory
    {
        public static Azure.Messaging.WebPubSub.Chat.ChatConversation ChatConversation(string id = null, string parentRoom = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.ChatRole ChatRole(string name = null, System.Collections.Generic.IEnumerable<string> permissions = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.ChatRoom ChatRoom(string id = null, string title = null, string defaultConversation = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.ChatRoomMember ChatRoomMember(string userId = null, string roleName = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.ChatUser ChatUser(string kind = null, string id = null, string nickname = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.HumanChatUser HumanChatUser(string id = null, string nickname = null, Azure.ETag etag = default(Azure.ETag), string roleName = null) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage WebPubSubChatMessage(string id = null, string createdBy = null, Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent content = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent WebPubSubChatMessageContent(string text = null, System.BinaryData binary = null) { throw null; }
    }
    public partial class WebPubSubChatServiceClient
    {
        protected WebPubSubChatServiceClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public WebPubSubChatServiceClient(Azure.Messaging.WebPubSub.Chat.WebPubSubChatServiceClientSettings settings) { }
        public WebPubSubChatServiceClient(string connectionString, string hub) { }
        public WebPubSubChatServiceClient(string connectionString, string hub, Azure.Messaging.WebPubSub.Chat.WebPubSubChatServiceClientOptions options) { }
        public WebPubSubChatServiceClient(System.Uri endpoint, string hub, Azure.AzureKeyCredential credential) { }
        public WebPubSubChatServiceClient(System.Uri endpoint, string hub, Azure.AzureKeyCredential credential, Azure.Messaging.WebPubSub.Chat.WebPubSubChatServiceClientOptions options) { }
        public WebPubSubChatServiceClient(System.Uri endpoint, string hub, Azure.Core.TokenCredential credential) { }
        public WebPubSubChatServiceClient(System.Uri endpoint, string hub, Azure.Core.TokenCredential credential, Azure.Messaging.WebPubSub.Chat.WebPubSubChatServiceClientOptions options) { }
        public virtual string Hub { get { throw null; } }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrReplaceRole(string roleName, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatRole> CreateOrReplaceRole(string roleName, Azure.Messaging.WebPubSub.Chat.ChatRole resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceRoleAsync(string roleName, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatRole>> CreateOrReplaceRoleAsync(string roleName, Azure.Messaging.WebPubSub.Chat.ChatRole resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceRoom(string roomId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatRoom> CreateOrReplaceRoom(string roomId, Azure.Messaging.WebPubSub.Chat.ChatRoom resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceRoomAsync(string roomId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatRoom>> CreateOrReplaceRoomAsync(string roomId, Azure.Messaging.WebPubSub.Chat.ChatRoom resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceRoomMember(string roomId, string userId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatRoomMember> CreateOrReplaceRoomMember(string roomId, string userId, Azure.Messaging.WebPubSub.Chat.ChatRoomMember resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceRoomMemberAsync(string roomId, string userId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatRoomMember>> CreateOrReplaceRoomMemberAsync(string roomId, string userId, Azure.Messaging.WebPubSub.Chat.ChatRoomMember resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceUser(string userId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatUser> CreateOrReplaceUser(string userId, Azure.Messaging.WebPubSub.Chat.ChatUser resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceUserAsync(string userId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatUser>> CreateOrReplaceUserAsync(string userId, Azure.Messaging.WebPubSub.Chat.ChatUser resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteMessage(string conversationId, string messageId, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteMessage(string conversationId, string messageId, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMessageAsync(string conversationId, string messageId, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMessageAsync(string conversationId, string messageId, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRole(string roleName, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteRole(string roleName, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAsync(string roleName, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoleAsync(string roleName, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoom(string roomId, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteRoom(string roomId, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoomAsync(string roomId, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoomAsync(string roomId, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteRoomMember(string roomId, string userId, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteRoomMember(string roomId, string userId, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoomMemberAsync(string roomId, string userId, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteRoomMemberAsync(string roomId, string userId, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteUser(string userId, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteUser(string userId, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteUserAsync(string userId, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Uri GetClientAccessUri(Azure.Messaging.WebPubSub.Chat.GetClientAccessTokenOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Uri> GetClientAccessUriAsync(Azure.Messaging.WebPubSub.Chat.GetClientAccessTokenOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConversation(string conversationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatConversation> GetConversation(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConversationAsync(string conversationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatConversation>> GetConversationAsync(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetMessages(string conversationId, string latestMessageId, string earliestMessageId, int? maxPageSize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage> GetMessages(string conversationId, string latestMessageId = null, string earliestMessageId = null, int? maxPageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMessagesAsync(string conversationId, string latestMessageId, string earliestMessageId, int? maxPageSize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage> GetMessagesAsync(string conversationId, string latestMessageId = null, string earliestMessageId = null, int? maxPageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRole(string roleName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatRole> GetRole(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleAsync(string roleName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatRole>> GetRoleAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRoles(int? maxPageSize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Messaging.WebPubSub.Chat.ChatRole> GetRoles(int? maxPageSize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRolesAsync(int? maxPageSize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.WebPubSub.Chat.ChatRole> GetRolesAsync(int? maxPageSize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRoom(string roomId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatRoom> GetRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoomAsync(string roomId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatRoom>> GetRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRoomMembers(string roomId, int? maxPageSize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Messaging.WebPubSub.Chat.ChatRoomMember> GetRoomMembers(string roomId, int? maxPageSize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRoomMembersAsync(string roomId, int? maxPageSize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.WebPubSub.Chat.ChatRoomMember> GetRoomMembersAsync(string roomId, int? maxPageSize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUser(string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatUser> GetUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserAsync(string userId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.ChatUser>> GetUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(string conversationId, string messageId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(string conversationId, string messageId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class WebPubSubChatServiceClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedWebPubSubChatServiceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedWebPubSubChatServiceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Messaging.WebPubSub.Chat.WebPubSubChatServiceClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddWebPubSubChatServiceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddWebPubSubChatServiceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Messaging.WebPubSub.Chat.WebPubSubChatServiceClientSettings> configureSettings) { throw null; }
    }
    public partial class WebPubSubChatServiceClientOptions : Azure.Core.ClientOptions
    {
        public WebPubSubChatServiceClientOptions(Azure.Messaging.WebPubSub.Chat.WebPubSubChatServiceClientOptions.ServiceVersion version = Azure.Messaging.WebPubSub.Chat.WebPubSubChatServiceClientOptions.ServiceVersion.V2026_02_01_Preview) { }
        public System.Uri ReverseProxyEndpoint { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2026_02_01_Preview = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class WebPubSubChatServiceClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public WebPubSubChatServiceClientSettings() { }
        public string ConnectionString { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public string Hub { get { throw null; } set { } }
        public Azure.Messaging.WebPubSub.Chat.WebPubSubChatServiceClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
}
