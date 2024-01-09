namespace Azure.Communication.Messages
{
    public partial class CommunicationMessagesClientOptions : Azure.Core.ClientOptions
    {
        public CommunicationMessagesClientOptions(Azure.Communication.Messages.CommunicationMessagesClientOptions.ServiceVersion version = Azure.Communication.Messages.CommunicationMessagesClientOptions.ServiceVersion.V2024_02_01) { }
        public enum ServiceVersion
        {
            V2024_02_01 = 1,
        }
    }
    public static partial class CommunicationMessagesModelFactory
    {
        public static Azure.Communication.Messages.MessageReceipt MessageReceipt(string messageId = null, string to = null) { throw null; }
        public static Azure.Communication.Messages.MessageTemplateItem MessageTemplateItem(string kind = null, string name = null, string language = null, Azure.Communication.Messages.MessageTemplateStatus status = default(Azure.Communication.Messages.MessageTemplateStatus)) { throw null; }
        public static Azure.Communication.Messages.SendMessageResult SendMessageResult(System.Collections.Generic.IEnumerable<Azure.Communication.Messages.MessageReceipt> receipts = null) { throw null; }
        public static Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem WhatsAppMessageTemplateItem(string name = null, string language = null, Azure.Communication.Messages.MessageTemplateStatus status = default(Azure.Communication.Messages.MessageTemplateStatus), System.BinaryData content = null) { throw null; }
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
        public MessageTemplate(string name, string language, System.Collections.Generic.IList<Azure.Communication.Messages.MessageTemplateValue> values = null, Azure.Communication.Messages.MessageTemplateBindings bindings = null) { }
        public Azure.Communication.Messages.MessageTemplateBindings Bindings { get { throw null; } }
        public string Language { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Messages.MessageTemplateValue> Values { get { throw null; } }
    }
    public abstract partial class MessageTemplateBindings
    {
        public MessageTemplateBindings(string kind) { }
        internal abstract Azure.Communication.Messages.MessageTemplateBindingsInternal ToMessageTemplateBindingsInternal();
    }
    public partial class MessageTemplateClient
    {
        protected MessageTemplateClient() { }
        public MessageTemplateClient(string connectionString) { }
        public MessageTemplateClient(string connectionString, Azure.Communication.Messages.CommunicationMessagesClientOptions options) { }
        public MessageTemplateClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.Messages.CommunicationMessagesClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<Azure.Communication.Messages.MessageTemplateItem> GetTemplates(string channelRegistrationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Messages.MessageTemplateItem> GetTemplatesAsync(string channelRegistrationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MessageTemplateDocument : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateDocument(string name, System.Uri url) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } }
    }
    public partial class MessageTemplateImage : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateImage(string name, System.Uri url) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } }
    }
    public abstract partial class MessageTemplateItem
    {
        protected MessageTemplateItem(string name, string language, Azure.Communication.Messages.MessageTemplateStatus status) { }
        public string Language { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Communication.Messages.MessageTemplateStatus Status { get { throw null; } }
    }
    public partial class MessageTemplateLocation : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateLocation(string name) : base (default(string)) { }
        public string Address { get { throw null; } set { } }
        public double? Latitude { get { throw null; } set { } }
        public string LocationName { get { throw null; } set { } }
        public double? Longitude { get { throw null; } set { } }
    }
    public partial class MessageTemplateMedia
    {
        internal MessageTemplateMedia() { }
        public string Caption { get { throw null; } }
        public string FileName { get { throw null; } }
        public System.Uri Url { get { throw null; } }
    }
    public partial class MessageTemplateQuickAction : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateQuickAction(string name) : base (default(string)) { }
        public string Payload { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
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
    public partial class MessageTemplateText : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateText(string name, string text) : base (default(string)) { }
        public string Text { get { throw null; } }
    }
    public abstract partial class MessageTemplateValue
    {
        protected MessageTemplateValue(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class MessageTemplateVideo : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateVideo(string name, System.Uri url) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } }
    }
    public partial class NotificationMessagesClient
    {
        protected NotificationMessagesClient() { }
        public NotificationMessagesClient(string connectionString) { }
        public NotificationMessagesClient(string connectionString, Azure.Communication.Messages.CommunicationMessagesClientOptions options) { }
        public NotificationMessagesClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.Messages.CommunicationMessagesClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
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
        public SendMessageOptions(System.Guid channelRegistrationId, System.Collections.Generic.IList<string> to, Azure.Communication.Messages.MessageTemplate template) { }
        public SendMessageOptions(System.Guid channelRegistrationId, System.Collections.Generic.IList<string> to, string content) { }
        public SendMessageOptions(System.Guid channelRegistrationId, System.Collections.Generic.IList<string> to, System.Uri mediaUri, string content = null) { }
        public System.Guid ChannelRegistrationId { get { throw null; } }
        public string Content { get { throw null; } }
        public System.Uri MediaUri { get { throw null; } }
        public Azure.Communication.Messages.CommunicationMessageType MessageType { get { throw null; } }
        public Azure.Communication.Messages.MessageTemplate Template { get { throw null; } }
        public System.Collections.Generic.IList<string> To { get { throw null; } }
    }
    public partial class SendMessageResult
    {
        internal SendMessageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Messages.MessageReceipt> Receipts { get { throw null; } }
    }
    public partial class WhatsAppMessageTemplateBindingsButton
    {
        public WhatsAppMessageTemplateBindingsButton(string refValue) { }
        public string RefValue { get { throw null; } }
        public string SubType { get { throw null; } set { } }
    }
    public partial class WhatsAppMessageTemplateBindingsComponent
    {
        public WhatsAppMessageTemplateBindingsComponent(string refValue) { }
        public string RefValue { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WhatsAppMessageTemplateValueSubType : System.IEquatable<Azure.Communication.Messages.WhatsAppMessageTemplateValueSubType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WhatsAppMessageTemplateValueSubType(string value) { throw null; }
        public static Azure.Communication.Messages.WhatsAppMessageTemplateValueSubType QuickReply { get { throw null; } }
        public static Azure.Communication.Messages.WhatsAppMessageTemplateValueSubType Url { get { throw null; } }
        public bool Equals(Azure.Communication.Messages.WhatsAppMessageTemplateValueSubType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Messages.WhatsAppMessageTemplateValueSubType left, Azure.Communication.Messages.WhatsAppMessageTemplateValueSubType right) { throw null; }
        public static implicit operator Azure.Communication.Messages.WhatsAppMessageTemplateValueSubType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Messages.WhatsAppMessageTemplateValueSubType left, Azure.Communication.Messages.WhatsAppMessageTemplateValueSubType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.Communication.Messages.Models.Channels
{
    public partial class WhatsAppMessageTemplateBindings : Azure.Communication.Messages.MessageTemplateBindings
    {
        public WhatsAppMessageTemplateBindings() : base (default(string)) { }
        public System.Collections.Generic.IList<string> Body { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, Azure.Communication.Messages.WhatsAppMessageTemplateValueSubType>> Buttons { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Footer { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Header { get { throw null; } set { } }
    }
    public partial class WhatsAppMessageTemplateItem : Azure.Communication.Messages.MessageTemplateItem
    {
        internal WhatsAppMessageTemplateItem() : base (default(string), default(string), default(Azure.Communication.Messages.MessageTemplateStatus)) { }
        public System.BinaryData Content { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class CommunicationMessagesClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Messages.MessageTemplateClient, Azure.Communication.Messages.CommunicationMessagesClientOptions> AddMessageTemplateClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Messages.MessageTemplateClient, Azure.Communication.Messages.CommunicationMessagesClientOptions> AddMessageTemplateClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Messages.NotificationMessagesClient, Azure.Communication.Messages.CommunicationMessagesClientOptions> AddNotificationMessagesClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Messages.NotificationMessagesClient, Azure.Communication.Messages.CommunicationMessagesClientOptions> AddNotificationMessagesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
