namespace Azure.Messaging.WebPubSub.Chat
{
    public partial class AzureMessagingWebPubSubChatContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMessagingWebPubSubChatContext() { }
        public static Azure.Messaging.WebPubSub.Chat.AzureMessagingWebPubSubChatContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class BuiltInChatRoles
    {
        public const string RoomMember = "room.member";
        public const string RoomOperator = "room.operator";
        public const string UserNormal = "user.normal";
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatPermission : System.IEquatable<Azure.Messaging.WebPubSub.Chat.ChatPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatPermission(string value) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.ChatPermission RoomHistory { get { throw null; } }
        public static Azure.Messaging.WebPubSub.Chat.ChatPermission RoomInvite { get { throw null; } }
        public static Azure.Messaging.WebPubSub.Chat.ChatPermission RoomPublishMessage { get { throw null; } }
        public static Azure.Messaging.WebPubSub.Chat.ChatPermission RoomRemoveUser { get { throw null; } }
        public static Azure.Messaging.WebPubSub.Chat.ChatPermission UserCreateRoom { get { throw null; } }
        public static Azure.Messaging.WebPubSub.Chat.ChatPermission UserFetchAllRooms { get { throw null; } }
        public bool Equals(Azure.Messaging.WebPubSub.Chat.ChatPermission other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.WebPubSub.Chat.ChatPermission left, Azure.Messaging.WebPubSub.Chat.ChatPermission right) { throw null; }
        public static implicit operator Azure.Messaging.WebPubSub.Chat.ChatPermission (string value) { throw null; }
        public static implicit operator Azure.Messaging.WebPubSub.Chat.ChatPermission? (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.WebPubSub.Chat.ChatPermission left, Azure.Messaging.WebPubSub.Chat.ChatPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClientAccessUriOptions
    {
        public static readonly Azure.Messaging.WebPubSub.Chat.ClientAccessUriOptions Default;
        public ClientAccessUriOptions() { }
        public System.TimeSpan ExpiresAfter { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class WebPubSubChatConversation : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation>
    {
        internal WebPubSubChatConversation() { }
        public Azure.ETag Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string ParentRoom { get { throw null; } }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation (Azure.Response response) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubChatMessage : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage>
    {
        public WebPubSubChatMessage(string createdBy, Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent content) { }
        public Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent Content { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
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
        public static Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation WebPubSubChatConversation(string id = null, string parentRoom = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage WebPubSubChatMessage(string id = null, string createdBy = null, Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent content = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessageContent WebPubSubChatMessageContent(string text = null, System.BinaryData binary = null) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole WebPubSubChatRole(string name = null, System.Collections.Generic.IEnumerable<Azure.Messaging.WebPubSub.Chat.ChatPermission> permissions = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom WebPubSubChatRoom(string id = null, string title = null, string defaultConversation = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember WebPubSubChatRoomMember(string userId = null, string roleName = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser WebPubSubChatUser(string kind = null, string id = null, string nickname = null, Azure.ETag etag = default(Azure.ETag)) { throw null; }
        public static Azure.Messaging.WebPubSub.Chat.WebPubSubHumanChatUser WebPubSubHumanChatUser(string id = null, string nickname = null, Azure.ETag etag = default(Azure.ETag), string roleName = null) { throw null; }
    }
    public partial class WebPubSubChatRole : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole>
    {
        public WebPubSubChatRole(System.Collections.Generic.IEnumerable<Azure.Messaging.WebPubSub.Chat.ChatPermission> permissions) { }
        public Azure.ETag Etag { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Messaging.WebPubSub.Chat.ChatPermission> Permissions { get { throw null; } }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole webPubSubChatRole) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubChatRoom : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom>
    {
        public WebPubSubChatRoom(string title) { }
        public string DefaultConversation { get { throw null; } }
        public Azure.ETag Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string Title { get { throw null; } set { } }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom webPubSubChatRoom) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubChatRoomMember : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember>
    {
        public WebPubSubChatRoomMember(string roleName) { }
        public Azure.ETag Etag { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public string UserId { get { throw null; } }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember webPubSubChatRoomMember) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole> CreateOrReplaceRole(string roleName, Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceRoleAsync(string roleName, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole>> CreateOrReplaceRoleAsync(string roleName, Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceRoom(string roomId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom> CreateOrReplaceRoom(string roomId, Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceRoomAsync(string roomId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom>> CreateOrReplaceRoomAsync(string roomId, Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceRoomMember(string roomId, string userId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember> CreateOrReplaceRoomMember(string roomId, string userId, Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceRoomMemberAsync(string roomId, string userId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember>> CreateOrReplaceRoomMemberAsync(string roomId, string userId, Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceUser(string userId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser> CreateOrReplaceUser(string userId, Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceUserAsync(string userId, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser>> CreateOrReplaceUserAsync(string userId, Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser resource, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual System.Uri GetClientAccessUri(Azure.Messaging.WebPubSub.Chat.ClientAccessUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Uri> GetClientAccessUriAsync(Azure.Messaging.WebPubSub.Chat.ClientAccessUriOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConversation(string conversationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation> GetConversation(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConversationAsync(string conversationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatConversation>> GetConversationAsync(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetMessages(string conversationId, string latestMessageId, string earliestMessageId, int? maxPageSize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage> GetMessages(string conversationId, string latestMessageId = null, string earliestMessageId = null, int? maxPageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMessagesAsync(string conversationId, string latestMessageId, string earliestMessageId, int? maxPageSize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.WebPubSub.Chat.WebPubSubChatMessage> GetMessagesAsync(string conversationId, string latestMessageId = null, string earliestMessageId = null, int? maxPageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRole(string roleName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole> GetRole(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoleAsync(string roleName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole>> GetRoleAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRoles(int? maxPageSize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole> GetRoles(int? maxPageSize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRolesAsync(int? maxPageSize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRole> GetRolesAsync(int? maxPageSize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRoom(string roomId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom> GetRoom(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRoomAsync(string roomId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoom>> GetRoomAsync(string roomId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRoomMembers(string roomId, int? maxPageSize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember> GetRoomMembers(string roomId, int? maxPageSize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRoomMembersAsync(string roomId, int? maxPageSize, string continuationToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Messaging.WebPubSub.Chat.WebPubSubChatRoomMember> GetRoomMembersAsync(string roomId, int? maxPageSize = default(int?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetUser(string userId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser> GetUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUserAsync(string userId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser>> GetUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public abstract partial class WebPubSubChatUser : System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser>
    {
        internal WebPubSubChatUser() { }
        public Azure.ETag Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string Nickname { get { throw null; } set { } }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser webPubSubChatUser) { throw null; }
        protected virtual Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebPubSubHumanChatUser : Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser, System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubHumanChatUser>, System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubHumanChatUser>
    {
        public WebPubSubHumanChatUser(string nickname, string roleName) { }
        public string RoleName { get { throw null; } set { } }
        protected override Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Messaging.WebPubSub.Chat.WebPubSubChatUser PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Messaging.WebPubSub.Chat.WebPubSubHumanChatUser System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubHumanChatUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Messaging.WebPubSub.Chat.WebPubSubHumanChatUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Messaging.WebPubSub.Chat.WebPubSubHumanChatUser System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubHumanChatUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubHumanChatUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Messaging.WebPubSub.Chat.WebPubSubHumanChatUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
