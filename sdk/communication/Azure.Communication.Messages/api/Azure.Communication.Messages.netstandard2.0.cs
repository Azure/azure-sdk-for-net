namespace Azure.Communication.Messages
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationMessagesChannelType : System.IEquatable<Azure.Communication.Messages.CommunicationMessagesChannelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationMessagesChannelType(string value) { throw null; }
        public static Azure.Communication.Messages.CommunicationMessagesChannelType WhatsApp { get { throw null; } }
        public bool Equals(Azure.Communication.Messages.CommunicationMessagesChannelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Messages.CommunicationMessagesChannelType left, Azure.Communication.Messages.CommunicationMessagesChannelType right) { throw null; }
        public static implicit operator Azure.Communication.Messages.CommunicationMessagesChannelType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Messages.CommunicationMessagesChannelType left, Azure.Communication.Messages.CommunicationMessagesChannelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommunicationMessagesClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationMessagesClientOptions(Azure.Communication.Messages.CommunicationMessagesClientOptions.ServiceVersion version = Azure.Communication.Messages.CommunicationMessagesClientOptions.ServiceVersion.V2023_08_24_Preview) { }
        public enum ServiceVersion
        {
            V2023_08_24_Preview = 1,
        }
    }
    public static partial class CommunicationMessagesModelFactory
    {
        public static Azure.Communication.Messages.MessageReceipt MessageReceipt(string messageId = null, string to = null) { throw null; }
        public static Azure.Communication.Messages.SendMessageResult SendMessageResult(System.Collections.Generic.IEnumerable<Azure.Communication.Messages.MessageReceipt> receipts = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationMessageType : System.IEquatable<Azure.Communication.Messages.CommunicationMessageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationMessageType(string value) { throw null; }
        public static Azure.Communication.Messages.CommunicationMessageType Image { get { throw null; } }
        public static Azure.Communication.Messages.CommunicationMessageType Template { get { throw null; } }
        public static Azure.Communication.Messages.CommunicationMessageType Text { get { throw null; } }
        public bool Equals(Azure.Communication.Messages.CommunicationMessageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Messages.CommunicationMessageType left, Azure.Communication.Messages.CommunicationMessageType right) { throw null; }
        public static implicit operator Azure.Communication.Messages.CommunicationMessageType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Messages.CommunicationMessageType left, Azure.Communication.Messages.CommunicationMessageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageReceipt
    {
        internal MessageReceipt() { }
        public string MessageId { get { throw null; } }
        public string To { get { throw null; } }
    }
    public partial class MessageTemplate
    {
        public MessageTemplate(string name, string language, System.Collections.Generic.IEnumerable<Azure.Communication.Messages.MessageTemplateValue> values = null, Azure.Communication.Messages.MessageTemplateBindings bindings = null) { }
        public Azure.Communication.Messages.MessageTemplateBindings Bindings { get { throw null; } }
        public string Language { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.Communication.Messages.MessageTemplateValue> Values { get { throw null; } }
    }
    public abstract partial class MessageTemplateBindings
    {
        public MessageTemplateBindings() { }
        internal abstract Azure.Communication.Messages.MessageTemplateBindingsInternal ToMessageTemplateBindingsInternal();
    }
    public partial class MessageTemplateClient
    {
        protected MessageTemplateClient() { }
        public MessageTemplateClient(string connectionString) { }
        public MessageTemplateClient(string connectionString, Azure.Communication.Messages.CommunicationMessagesClientOptions options) { }
        public MessageTemplateClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Messages.CommunicationMessagesClientOptions options = null) { }
        public virtual Azure.Pageable<Azure.Communication.Messages.MessageTemplateItem> GetTemplates(string channelRegistrationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Messages.MessageTemplateItem> GetTemplatesAsync(string channelRegistrationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MessageTemplateDocument : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateDocument(string name, System.Uri uri, string caption = null, string fileName = null) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MessageTemplateImage : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateImage(string name, System.Uri uri, string caption = null, string fileName = null) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MessageTemplateItem
    {
        internal MessageTemplateItem() { }
        public Azure.Communication.Messages.CommunicationMessagesChannelType? ChannelType { get { throw null; } }
        public string Language { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Communication.Messages.TemplateStatus? Status { get { throw null; } }
        public Azure.Communication.Messages.MessageTemplateItemWhatsApp WhatsApp { get { throw null; } }
    }
    public partial class MessageTemplateItemWhatsApp
    {
        internal MessageTemplateItemWhatsApp() { }
        public System.BinaryData Content { get { throw null; } }
    }
    public partial class MessageTemplateLocation : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateLocation(string name, double latitude, double longitude, string locationName = null, string address = null) : base (default(string)) { }
        public string Address { get { throw null; } set { } }
        public double Latitude { get { throw null; } set { } }
        public string LocationName { get { throw null; } set { } }
        public double Longitude { get { throw null; } set { } }
    }
    public partial class MessageTemplateQuickAction : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateQuickAction(string name, string text = null, string payload = null) : base (default(string)) { }
        public string Payload { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
    }
    public partial class MessageTemplateText : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateText(string name, string text) : base (default(string)) { }
        public string Text { get { throw null; } set { } }
    }
    public abstract partial class MessageTemplateValue
    {
        public MessageTemplateValue(string name) { }
        public string Name { get { throw null; } }
        internal abstract Azure.Communication.Messages.MessageTemplateValueInternal ToMessageTemplateValueInternal();
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageTemplateValueKind : System.IEquatable<Azure.Communication.Messages.MessageTemplateValueKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageTemplateValueKind(string value) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateValueKind Document { get { throw null; } }
        public static Azure.Communication.Messages.MessageTemplateValueKind Image { get { throw null; } }
        public static Azure.Communication.Messages.MessageTemplateValueKind Location { get { throw null; } }
        public static Azure.Communication.Messages.MessageTemplateValueKind QuickAction { get { throw null; } }
        public static Azure.Communication.Messages.MessageTemplateValueKind Text { get { throw null; } }
        public static Azure.Communication.Messages.MessageTemplateValueKind Video { get { throw null; } }
        public bool Equals(Azure.Communication.Messages.MessageTemplateValueKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Messages.MessageTemplateValueKind left, Azure.Communication.Messages.MessageTemplateValueKind right) { throw null; }
        public static implicit operator Azure.Communication.Messages.MessageTemplateValueKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Messages.MessageTemplateValueKind left, Azure.Communication.Messages.MessageTemplateValueKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageTemplateValueWhatsAppSubType : System.IEquatable<Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageTemplateValueWhatsAppSubType(string value) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType QuickReply { get { throw null; } }
        public static Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType Url { get { throw null; } }
        public bool Equals(Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType left, Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType right) { throw null; }
        public static implicit operator Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType left, Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageTemplateVideo : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateVideo(string name, System.Uri uri, string caption = null, string fileName = null) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MessageTemplateWhatsAppBindings : Azure.Communication.Messages.MessageTemplateBindings
    {
        public MessageTemplateWhatsAppBindings(System.Collections.Generic.IEnumerable<string> header = null, System.Collections.Generic.IEnumerable<string> body = null, System.Collections.Generic.IEnumerable<string> footer = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType>> button = null) { }
        public System.Collections.Generic.IEnumerable<string> Body { get { throw null; } }
        public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.Communication.Messages.MessageTemplateValueWhatsAppSubType>> Button { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Footer { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Header { get { throw null; } }
    }
    public partial class NotificationMessagesClient
    {
        protected NotificationMessagesClient() { }
        public NotificationMessagesClient(string connectionString) { }
        public NotificationMessagesClient(string connectionString, Azure.Communication.Messages.CommunicationMessagesClientOptions options) { }
        public NotificationMessagesClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Messages.CommunicationMessagesClientOptions options = null) { }
        public virtual Azure.Response<System.IO.Stream> DownloadMedia(string mediaContentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> DownloadMediaAsync(string mediaContentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadMediaTo(string mediaContentId, System.IO.Stream destinationStream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadMediaTo(string mediaContentId, string destinationPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadMediaToAsync(string mediaContentId, System.IO.Stream destinationStream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadMediaToAsync(string mediaContentId, string destinationPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Messages.SendMessageResult> SendMessage(Azure.Communication.Messages.SendMessageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Messages.SendMessageResult>> SendMessageAsync(Azure.Communication.Messages.SendMessageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SendMessageOptions
    {
        public SendMessageOptions(string channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, Azure.Communication.Messages.MessageTemplate template) { }
        public SendMessageOptions(string channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, string content) { }
        public SendMessageOptions(string channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, System.Uri mediaUri, string content = null) { }
        public string ChannelRegistrationId { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Uri MediaUri { get { throw null; } }
        public Azure.Communication.Messages.CommunicationMessageType MessageType { get { throw null; } }
        public Azure.Communication.Messages.MessageTemplate Template { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> To { get { throw null; } }
    }
    public partial class SendMessageResult
    {
        internal SendMessageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Messages.MessageReceipt> Receipts { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateStatus : System.IEquatable<Azure.Communication.Messages.TemplateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateStatus(string value) { throw null; }
        public static Azure.Communication.Messages.TemplateStatus Approved { get { throw null; } }
        public static Azure.Communication.Messages.TemplateStatus Paused { get { throw null; } }
        public static Azure.Communication.Messages.TemplateStatus Pending { get { throw null; } }
        public static Azure.Communication.Messages.TemplateStatus Rejected { get { throw null; } }
        public bool Equals(Azure.Communication.Messages.TemplateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Messages.TemplateStatus left, Azure.Communication.Messages.TemplateStatus right) { throw null; }
        public static implicit operator Azure.Communication.Messages.TemplateStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Messages.TemplateStatus left, Azure.Communication.Messages.TemplateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
