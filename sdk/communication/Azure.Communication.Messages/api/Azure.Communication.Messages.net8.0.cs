namespace Azure.Communication.Messages
{
    public abstract partial class ActionBindings : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionBindings>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionBindings>
    {
        protected ActionBindings() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ActionBindings System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionBindings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionBindings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ActionBindings System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionBindings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionBindings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionBindings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActionGroup : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroup>
    {
        public ActionGroup(string title, System.Collections.Generic.IEnumerable<Azure.Communication.Messages.ActionGroupItem> items) { }
        public System.Collections.Generic.IList<Azure.Communication.Messages.ActionGroupItem> Items { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ActionGroup System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ActionGroup System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActionGroupContent : Azure.Communication.Messages.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionGroupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroupContent>
    {
        public ActionGroupContent(string title, System.Collections.Generic.IEnumerable<Azure.Communication.Messages.ActionGroup> groups) { }
        public System.Collections.Generic.IList<Azure.Communication.Messages.ActionGroup> Groups { get { throw null; } }
        public string Title { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ActionGroupContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionGroupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionGroupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ActionGroupContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActionGroupItem : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionGroupItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroupItem>
    {
        public ActionGroupItem(string id, string title, string description) { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ActionGroupItem System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionGroupItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ActionGroupItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ActionGroupItem System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroupItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroupItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ActionGroupItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioNotificationContent : Azure.Communication.Messages.NotificationContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.AudioNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.AudioNotificationContent>
    {
        public AudioNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, System.Uri mediaUri) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public System.Uri MediaUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.AudioNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.AudioNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.AudioNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.AudioNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.AudioNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.AudioNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.AudioNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ButtonContent : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ButtonContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ButtonContent>
    {
        public ButtonContent(string id, string title) { }
        public string Id { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ButtonContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ButtonContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ButtonContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ButtonContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ButtonContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ButtonContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ButtonContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ButtonSetContent : Azure.Communication.Messages.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ButtonSetContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ButtonSetContent>
    {
        public ButtonSetContent(System.Collections.Generic.IEnumerable<Azure.Communication.Messages.ButtonContent> buttons) { }
        public System.Collections.Generic.IList<Azure.Communication.Messages.ButtonContent> Buttons { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ButtonSetContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ButtonSetContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ButtonSetContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ButtonSetContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ButtonSetContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ButtonSetContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ButtonSetContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunicationMessagesClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationMessagesClientOptions(Azure.Communication.Messages.CommunicationMessagesClientOptions.ServiceVersion version = Azure.Communication.Messages.CommunicationMessagesClientOptions.ServiceVersion.V2025_01_15_Preview) { }
        public enum ServiceVersion
        {
            V2024_02_01 = 1,
            V2024_08_30 = 2,
            V2025_01_15_Preview = 3,
        }
    }
    public static partial class CommunicationMessagesModelFactory
    {
        public static Azure.Communication.Messages.ActionGroupContent ActionGroupContent(string title = null, System.Collections.Generic.IEnumerable<Azure.Communication.Messages.ActionGroup> groups = null) { throw null; }
        public static Azure.Communication.Messages.AudioNotificationContent AudioNotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, System.Uri mediaUri = null) { throw null; }
        public static Azure.Communication.Messages.DocumentMessageContent DocumentMessageContent(System.Uri mediaUri = null) { throw null; }
        public static Azure.Communication.Messages.DocumentNotificationContent DocumentNotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, string caption = null, string fileName = null, System.Uri mediaUri = null) { throw null; }
        public static Azure.Communication.Messages.ImageMessageContent ImageMessageContent(System.Uri mediaUri = null) { throw null; }
        public static Azure.Communication.Messages.ImageNotificationContent ImageNotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, string caption = null, System.Uri mediaUri = null) { throw null; }
        public static Azure.Communication.Messages.InteractiveMessage InteractiveMessage(Azure.Communication.Messages.MessageContent header = null, Azure.Communication.Messages.TextMessageContent body = null, Azure.Communication.Messages.TextMessageContent footer = null, Azure.Communication.Messages.ActionBindings action = null) { throw null; }
        public static Azure.Communication.Messages.InteractiveNotificationContent InteractiveNotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, Azure.Communication.Messages.InteractiveMessage interactiveMessage = null) { throw null; }
        public static Azure.Communication.Messages.LinkContent LinkContent(string title = null, System.Uri uri = null) { throw null; }
        public static Azure.Communication.Messages.MediaNotificationContent MediaNotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, string content = null, System.Uri mediaUri = null) { throw null; }
        public static Azure.Communication.Messages.MessageReceipt MessageReceipt(string messageId = null, string to = null) { throw null; }
        public static Azure.Communication.Messages.MessageTemplate MessageTemplate(string name = null, string language = null, System.Collections.Generic.IEnumerable<Azure.Communication.Messages.MessageTemplateValue> values = null, Azure.Communication.Messages.MessageTemplateBindings bindings = null) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateDocument MessageTemplateDocument(string name = null, System.Uri uri = null, string caption = null, string fileName = null) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateImage MessageTemplateImage(string name = null, System.Uri uri = null, string caption = null, string fileName = null) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateItem MessageTemplateItem(string name = null, string language = null, Azure.Communication.Messages.MessageTemplateStatus status = default(Azure.Communication.Messages.MessageTemplateStatus), string kind = null) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateQuickAction MessageTemplateQuickAction(string name = null, string text = null, string payload = null) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateText MessageTemplateText(string name = null, string text = null) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateValue MessageTemplateValue(string name = null, string kind = null) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateVideo MessageTemplateVideo(string name = null, System.Uri uri = null, string caption = null, string fileName = null) { throw null; }
        public static Azure.Communication.Messages.NotificationContent NotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, string kind = null) { throw null; }
        public static Azure.Communication.Messages.ReactionNotificationContent ReactionNotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, string emoji = null, string messageId = null) { throw null; }
        public static Azure.Communication.Messages.SendMessageResult SendMessageResult(System.Collections.Generic.IEnumerable<Azure.Communication.Messages.MessageReceipt> receipts = null) { throw null; }
        public static Azure.Communication.Messages.StickerNotificationContent StickerNotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, System.Uri mediaUri = null) { throw null; }
        public static Azure.Communication.Messages.TemplateNotificationContent TemplateNotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, Azure.Communication.Messages.MessageTemplate template = null) { throw null; }
        public static Azure.Communication.Messages.TextMessageContent TextMessageContent(string text = null) { throw null; }
        public static Azure.Communication.Messages.TextNotificationContent TextNotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, string content = null) { throw null; }
        public static Azure.Communication.Messages.VideoMessageContent VideoMessageContent(System.Uri mediaUri = null) { throw null; }
        public static Azure.Communication.Messages.VideoNotificationContent VideoNotificationContent(System.Guid channelRegistrationId = default(System.Guid), System.Collections.Generic.IEnumerable<string> to = null, string caption = null, System.Uri mediaUri = null) { throw null; }
        public static Azure.Communication.Messages.Models.Channels.WhatsAppButtonActionBindings WhatsAppButtonActionBindings(Azure.Communication.Messages.ButtonSetContent content = null) { throw null; }
        public static Azure.Communication.Messages.Models.Channels.WhatsAppListActionBindings WhatsAppListActionBindings(Azure.Communication.Messages.ActionGroupContent content = null) { throw null; }
        public static Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem WhatsAppMessageTemplateItem(string name = null, string language = null, Azure.Communication.Messages.MessageTemplateStatus status = default(Azure.Communication.Messages.MessageTemplateStatus), System.BinaryData content = null) { throw null; }
        public static Azure.Communication.Messages.Models.Channels.WhatsAppUrlActionBindings WhatsAppUrlActionBindings(Azure.Communication.Messages.LinkContent content = null) { throw null; }
    }
    public partial class DocumentMessageContent : Azure.Communication.Messages.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.DocumentMessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.DocumentMessageContent>
    {
        public DocumentMessageContent(System.Uri mediaUri) { }
        public System.Uri MediaUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.DocumentMessageContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.DocumentMessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.DocumentMessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.DocumentMessageContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.DocumentMessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.DocumentMessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.DocumentMessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentNotificationContent : Azure.Communication.Messages.NotificationContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.DocumentNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.DocumentNotificationContent>
    {
        public DocumentNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, System.Uri mediaUri) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri MediaUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.DocumentNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.DocumentNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.DocumentNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.DocumentNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.DocumentNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.DocumentNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.DocumentNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageMessageContent : Azure.Communication.Messages.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ImageMessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ImageMessageContent>
    {
        public ImageMessageContent(System.Uri mediaUri) { }
        public System.Uri MediaUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ImageMessageContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ImageMessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ImageMessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ImageMessageContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ImageMessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ImageMessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ImageMessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageNotificationContent : Azure.Communication.Messages.NotificationContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ImageNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ImageNotificationContent>
    {
        public ImageNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, System.Uri mediaUri) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string Caption { get { throw null; } set { } }
        public System.Uri MediaUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ImageNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ImageNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ImageNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ImageNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ImageNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ImageNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ImageNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InteractiveMessage : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.InteractiveMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.InteractiveMessage>
    {
        public InteractiveMessage(Azure.Communication.Messages.TextMessageContent body, Azure.Communication.Messages.ActionBindings action) { }
        public Azure.Communication.Messages.ActionBindings Action { get { throw null; } }
        public Azure.Communication.Messages.TextMessageContent Body { get { throw null; } }
        public Azure.Communication.Messages.TextMessageContent Footer { get { throw null; } set { } }
        public Azure.Communication.Messages.MessageContent Header { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.InteractiveMessage System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.InteractiveMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.InteractiveMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.InteractiveMessage System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.InteractiveMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.InteractiveMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.InteractiveMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InteractiveNotificationContent : Azure.Communication.Messages.NotificationContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.InteractiveNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.InteractiveNotificationContent>
    {
        public InteractiveNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, Azure.Communication.Messages.InteractiveMessage interactiveMessage) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public Azure.Communication.Messages.InteractiveMessage InteractiveMessage { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.InteractiveNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.InteractiveNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.InteractiveNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.InteractiveNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.InteractiveNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.InteractiveNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.InteractiveNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkContent : Azure.Communication.Messages.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.LinkContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.LinkContent>
    {
        public LinkContent(string title, System.Uri uri) { }
        public string Title { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.LinkContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.LinkContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.LinkContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.LinkContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.LinkContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.LinkContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.LinkContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("`MediaNotificationContent` is being deprecated, we encourage you to use the new `ImageNotificationContent` for sending images instead.")]
    public partial class MediaNotificationContent : Azure.Communication.Messages.NotificationContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MediaNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MediaNotificationContent>
    {
        public MediaNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, System.Uri mediaUri) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string Content { get { throw null; } set { } }
        public System.Uri MediaUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MediaNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MediaNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MediaNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MediaNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MediaNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MediaNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MediaNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageContent : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageContent>
    {
        protected MessageContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageReceipt : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageReceipt>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageReceipt>
    {
        internal MessageReceipt() { }
        public string MessageId { get { throw null; } }
        public string To { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageReceipt System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageReceipt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageReceipt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageReceipt System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageReceipt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageReceipt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageReceipt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTemplate : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplate>
    {
        public MessageTemplate(string name, string language) { }
        public Azure.Communication.Messages.MessageTemplateBindings Bindings { get { throw null; } set { } }
        public string Language { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Messages.MessageTemplateValue> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplate System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplate System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageTemplateBindings : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateBindings>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateBindings>
    {
        protected MessageTemplateBindings() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateBindings System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateBindings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateBindings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateBindings System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateBindings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateBindings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateBindings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTemplateClient
    {
        protected MessageTemplateClient() { }
        public MessageTemplateClient(string connectionString) { }
        public MessageTemplateClient(string connectionString, Azure.Communication.Messages.CommunicationMessagesClientOptions options) { }
        public MessageTemplateClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public MessageTemplateClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.Messages.CommunicationMessagesClientOptions options = null) { }
        public MessageTemplateClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public MessageTemplateClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.Messages.CommunicationMessagesClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetTemplates(System.Guid channelId, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Messages.MessageTemplateItem> GetTemplates(System.Guid channelId, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTemplatesAsync(System.Guid channelId, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Messages.MessageTemplateItem> GetTemplatesAsync(System.Guid channelId, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MessageTemplateDocument : Azure.Communication.Messages.MessageTemplateValue, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateDocument>
    {
        public MessageTemplateDocument(string name, System.Uri uri) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateDocument System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateDocument System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTemplateImage : Azure.Communication.Messages.MessageTemplateValue, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateImage>
    {
        public MessageTemplateImage(string name, System.Uri uri) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateImage System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateImage System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageTemplateItem : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateItem>
    {
        protected MessageTemplateItem(string language, Azure.Communication.Messages.MessageTemplateStatus status) { }
        public string Language { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Communication.Messages.MessageTemplateStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateItem System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateItem System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTemplateLocation : Azure.Communication.Messages.MessageTemplateValue, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateLocation>
    {
        public MessageTemplateLocation(string name) : base (default(string)) { }
        public string Address { get { throw null; } set { } }
        public string LocationName { get { throw null; } set { } }
        public Azure.Core.GeoJson.GeoPosition Position { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateLocation System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateLocation System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTemplateQuickAction : Azure.Communication.Messages.MessageTemplateValue, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateQuickAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateQuickAction>
    {
        public MessageTemplateQuickAction(string name) : base (default(string)) { }
        public string Payload { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateQuickAction System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateQuickAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateQuickAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateQuickAction System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateQuickAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateQuickAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateQuickAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageTemplateStatus : System.IEquatable<Azure.Communication.Messages.MessageTemplateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageTemplateStatus(string value) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateStatus Approved { get { throw null; } }
        public static Azure.Communication.Messages.MessageTemplateStatus Paused { get { throw null; } }
        public static Azure.Communication.Messages.MessageTemplateStatus Pending { get { throw null; } }
        public static Azure.Communication.Messages.MessageTemplateStatus Rejected { get { throw null; } }
        public bool Equals(Azure.Communication.Messages.MessageTemplateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Messages.MessageTemplateStatus left, Azure.Communication.Messages.MessageTemplateStatus right) { throw null; }
        public static implicit operator Azure.Communication.Messages.MessageTemplateStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Messages.MessageTemplateStatus left, Azure.Communication.Messages.MessageTemplateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageTemplateText : Azure.Communication.Messages.MessageTemplateValue, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateText>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateText>
    {
        public MessageTemplateText(string name, string text) : base (default(string)) { }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateText System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateText System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageTemplateValue : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateValue>
    {
        protected MessageTemplateValue(string name) { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateValue System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateValue System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTemplateVideo : Azure.Communication.Messages.MessageTemplateValue, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateVideo>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateVideo>
    {
        public MessageTemplateVideo(string name, System.Uri uri) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateVideo System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateVideo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.MessageTemplateVideo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.MessageTemplateVideo System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateVideo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateVideo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.MessageTemplateVideo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class NotificationContent : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.NotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.NotificationContent>
    {
        protected NotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to) { }
        public System.Guid ChannelRegistrationId { get { throw null; } }
        public System.Collections.Generic.IList<string> To { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.NotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.NotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.NotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.NotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.NotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.NotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.NotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationMessagesClient
    {
        protected NotificationMessagesClient() { }
        public NotificationMessagesClient(string connectionString) { }
        public NotificationMessagesClient(string connectionString, Azure.Communication.Messages.CommunicationMessagesClientOptions options) { }
        public NotificationMessagesClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public NotificationMessagesClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.Messages.CommunicationMessagesClientOptions options = null) { }
        public NotificationMessagesClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public NotificationMessagesClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.Messages.CommunicationMessagesClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<System.IO.Stream> DownloadMedia(string mediaContentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadMediaAsync(string mediaContentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadMediaTo(string mediaContentId, System.IO.Stream destinationStream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadMediaTo(string mediaContentId, string destinationPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadMediaToAsync(string mediaContentId, System.IO.Stream destinationStream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadMediaToAsync(string mediaContentId, string destinationPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Messages.SendMessageResult> Send(Azure.Communication.Messages.NotificationContent notificationContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Send(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Messages.SendMessageResult>> SendAsync(Azure.Communication.Messages.NotificationContent notificationContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class ReactionNotificationContent : Azure.Communication.Messages.NotificationContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ReactionNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ReactionNotificationContent>
    {
        public ReactionNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, string emoji, string messageId) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string Emoji { get { throw null; } }
        public string MessageId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ReactionNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ReactionNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.ReactionNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.ReactionNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ReactionNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ReactionNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.ReactionNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SendMessageResult : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.SendMessageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.SendMessageResult>
    {
        internal SendMessageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Messages.MessageReceipt> Receipts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.SendMessageResult System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.SendMessageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.SendMessageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.SendMessageResult System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.SendMessageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.SendMessageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.SendMessageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StickerNotificationContent : Azure.Communication.Messages.NotificationContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.StickerNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.StickerNotificationContent>
    {
        public StickerNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, System.Uri mediaUri) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public System.Uri MediaUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.StickerNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.StickerNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.StickerNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.StickerNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.StickerNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.StickerNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.StickerNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateNotificationContent : Azure.Communication.Messages.NotificationContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.TemplateNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TemplateNotificationContent>
    {
        public TemplateNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, Azure.Communication.Messages.MessageTemplate template) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public Azure.Communication.Messages.MessageTemplate Template { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.TemplateNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.TemplateNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.TemplateNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.TemplateNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TemplateNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TemplateNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TemplateNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextMessageContent : Azure.Communication.Messages.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.TextMessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TextMessageContent>
    {
        public TextMessageContent(string text) { }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.TextMessageContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.TextMessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.TextMessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.TextMessageContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TextMessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TextMessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TextMessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextNotificationContent : Azure.Communication.Messages.NotificationContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.TextNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TextNotificationContent>
    {
        public TextNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, string content) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string Content { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.TextNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.TextNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.TextNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.TextNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TextNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TextNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.TextNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoMessageContent : Azure.Communication.Messages.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.VideoMessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.VideoMessageContent>
    {
        public VideoMessageContent(System.Uri mediaUri) { }
        public System.Uri MediaUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.VideoMessageContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.VideoMessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.VideoMessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.VideoMessageContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.VideoMessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.VideoMessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.VideoMessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoNotificationContent : Azure.Communication.Messages.NotificationContent, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.VideoNotificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.VideoNotificationContent>
    {
        public VideoNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, System.Uri mediaUri) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string Caption { get { throw null; } set { } }
        public System.Uri MediaUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.VideoNotificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.VideoNotificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.VideoNotificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.VideoNotificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.VideoNotificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.VideoNotificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.VideoNotificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.Communication.Messages.Models.Channels
{
    public partial class WhatsAppButtonActionBindings : Azure.Communication.Messages.ActionBindings, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppButtonActionBindings>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppButtonActionBindings>
    {
        public WhatsAppButtonActionBindings(Azure.Communication.Messages.ButtonSetContent content) { }
        public Azure.Communication.Messages.ButtonSetContent Content { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppButtonActionBindings System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppButtonActionBindings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppButtonActionBindings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppButtonActionBindings System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppButtonActionBindings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppButtonActionBindings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppButtonActionBindings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WhatsAppListActionBindings : Azure.Communication.Messages.ActionBindings, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppListActionBindings>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppListActionBindings>
    {
        public WhatsAppListActionBindings(Azure.Communication.Messages.ActionGroupContent content) { }
        public Azure.Communication.Messages.ActionGroupContent Content { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppListActionBindings System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppListActionBindings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppListActionBindings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppListActionBindings System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppListActionBindings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppListActionBindings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppListActionBindings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WhatsAppMessageButtonSubType : System.IEquatable<Azure.Communication.Messages.Models.Channels.WhatsAppMessageButtonSubType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WhatsAppMessageButtonSubType(string value) { throw null; }
        public static Azure.Communication.Messages.Models.Channels.WhatsAppMessageButtonSubType QuickReply { get { throw null; } }
        public static Azure.Communication.Messages.Models.Channels.WhatsAppMessageButtonSubType Url { get { throw null; } }
        public bool Equals(Azure.Communication.Messages.Models.Channels.WhatsAppMessageButtonSubType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Messages.Models.Channels.WhatsAppMessageButtonSubType left, Azure.Communication.Messages.Models.Channels.WhatsAppMessageButtonSubType right) { throw null; }
        public static implicit operator Azure.Communication.Messages.Models.Channels.WhatsAppMessageButtonSubType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Messages.Models.Channels.WhatsAppMessageButtonSubType left, Azure.Communication.Messages.Models.Channels.WhatsAppMessageButtonSubType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WhatsAppMessageTemplateBindings : Azure.Communication.Messages.MessageTemplateBindings, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindings>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindings>
    {
        public WhatsAppMessageTemplateBindings() { }
        public System.Collections.Generic.IList<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent> Body { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton> Buttons { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent> Footer { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent> Header { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindings System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindings System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WhatsAppMessageTemplateBindingsButton : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton>
    {
        public WhatsAppMessageTemplateBindingsButton(string subType, string refValue) { }
        public string RefValue { get { throw null; } }
        public string SubType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WhatsAppMessageTemplateBindingsComponent : System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent>
    {
        public WhatsAppMessageTemplateBindingsComponent(string refValue) { }
        public string RefValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WhatsAppMessageTemplateItem : Azure.Communication.Messages.MessageTemplateItem, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem>
    {
        internal WhatsAppMessageTemplateItem() : base (default(string), default(Azure.Communication.Messages.MessageTemplateStatus)) { }
        public System.BinaryData Content { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WhatsAppUrlActionBindings : Azure.Communication.Messages.ActionBindings, System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppUrlActionBindings>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppUrlActionBindings>
    {
        public WhatsAppUrlActionBindings(Azure.Communication.Messages.LinkContent content) { }
        public Azure.Communication.Messages.LinkContent Content { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppUrlActionBindings System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppUrlActionBindings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.Messages.Models.Channels.WhatsAppUrlActionBindings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.Messages.Models.Channels.WhatsAppUrlActionBindings System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppUrlActionBindings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppUrlActionBindings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.Messages.Models.Channels.WhatsAppUrlActionBindings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class CommunicationMessagesClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Messages.MessageTemplateClient, Azure.Communication.Messages.CommunicationMessagesClientOptions> AddMessageTemplateClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Messages.MessageTemplateClient, Azure.Communication.Messages.CommunicationMessagesClientOptions> AddMessageTemplateClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Messages.MessageTemplateClient, Azure.Communication.Messages.CommunicationMessagesClientOptions> AddMessageTemplateClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Messages.NotificationMessagesClient, Azure.Communication.Messages.CommunicationMessagesClientOptions> AddNotificationMessagesClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Messages.NotificationMessagesClient, Azure.Communication.Messages.CommunicationMessagesClientOptions> AddNotificationMessagesClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Messages.NotificationMessagesClient, Azure.Communication.Messages.CommunicationMessagesClientOptions> AddNotificationMessagesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
