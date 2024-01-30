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
        public static Azure.Communication.Messages.MessageTemplateItem MessageTemplateItem(string name = null, string language = null, Azure.Communication.Messages.MessageTemplateStatus status = default(Azure.Communication.Messages.MessageTemplateStatus), string kind = "Unknown") { throw null; }
        public static Azure.Communication.Messages.SendMessageResult SendMessageResult(System.Collections.Generic.IEnumerable<Azure.Communication.Messages.MessageReceipt> receipts = null) { throw null; }
        public static Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateItem WhatsAppMessageTemplateItem(string name = null, string language = null, Azure.Communication.Messages.MessageTemplateStatus status = default(Azure.Communication.Messages.MessageTemplateStatus), System.BinaryData content = null) { throw null; }
    }
    public partial class MediaNotificationContent : Azure.Communication.Messages.NotificationContent
    {
        public MediaNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, System.Uri mediaUri) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string Content { get { throw null; } set { } }
        public System.Uri MediaUri { get { throw null; } }
    }
    public partial class MessageReceipt
    {
        internal MessageReceipt() { }
        public string MessageId { get { throw null; } }
        public string To { get { throw null; } }
    }
    public partial class MessageTemplate
    {
        public MessageTemplate(string name, string language) { }
        public Azure.Communication.Messages.MessageTemplateBindings Bindings { get { throw null; } set { } }
        public string Language { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Messages.MessageTemplateValue> Values { get { throw null; } }
    }
    public abstract partial class MessageTemplateBindings
    {
        protected MessageTemplateBindings() { }
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
        public virtual Azure.Pageable<System.BinaryData> GetTemplates(string channelId, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.Messages.MessageTemplateItem> GetTemplates(string channelId, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTemplatesAsync(string channelId, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.Messages.MessageTemplateItem> GetTemplatesAsync(string channelId, int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MessageTemplateDocument : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateDocument(string name, System.Uri uri) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class MessageTemplateImage : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateImage(string name, System.Uri uri) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
    }
    public abstract partial class MessageTemplateItem
    {
        protected MessageTemplateItem(string language, Azure.Communication.Messages.MessageTemplateStatus status) { }
        public string Language { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Communication.Messages.MessageTemplateStatus Status { get { throw null; } }
    }
    public partial class MessageTemplateLocation : Azure.Communication.Messages.MessageTemplateValue
    {
        public MessageTemplateLocation(string name) : base (default(string)) { }
        public string Address { get { throw null; } set { } }
        public string LocationName { get { throw null; } set { } }
        public Azure.Core.GeoJson.GeoPosition Position { get { throw null; } set { } }
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
        public MessageTemplateVideo(string name, System.Uri uri) : base (default(string)) { }
        public string Caption { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
    }
    public abstract partial class NotificationContent
    {
        protected NotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to) { }
        public System.Guid ChannelRegistrationId { get { throw null; } }
        public System.Collections.Generic.IList<string> To { get { throw null; } }
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
    public partial class SendMessageResult
    {
        internal SendMessageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Messages.MessageReceipt> Receipts { get { throw null; } }
    }
    public partial class TemplateNotificationContent : Azure.Communication.Messages.NotificationContent
    {
        public TemplateNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, Azure.Communication.Messages.MessageTemplate template) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public Azure.Communication.Messages.MessageTemplate Template { get { throw null; } }
    }
    public partial class TextNotificationContent : Azure.Communication.Messages.NotificationContent
    {
        public TextNotificationContent(System.Guid channelRegistrationId, System.Collections.Generic.IEnumerable<string> to, string content) : base (default(System.Guid), default(System.Collections.Generic.IEnumerable<string>)) { }
        public string Content { get { throw null; } }
    }
}
namespace Azure.Communication.Messages.Models.Channels
{
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
    public partial class WhatsAppMessageTemplateBindings : Azure.Communication.Messages.MessageTemplateBindings
    {
        public WhatsAppMessageTemplateBindings() { }
        public System.Collections.Generic.IList<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent> Body { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsButton> Buttons { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent> Footer { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Messages.Models.Channels.WhatsAppMessageTemplateBindingsComponent> Header { get { throw null; } }
    }
    public partial class WhatsAppMessageTemplateBindingsButton
    {
        public WhatsAppMessageTemplateBindingsButton(string subType, string refValue) { }
        public string RefValue { get { throw null; } }
        public string SubType { get { throw null; } }
    }
    public partial class WhatsAppMessageTemplateBindingsComponent
    {
        public WhatsAppMessageTemplateBindingsComponent(string refValue) { }
        public string RefValue { get { throw null; } }
    }
    public partial class WhatsAppMessageTemplateItem : Azure.Communication.Messages.MessageTemplateItem
    {
        internal WhatsAppMessageTemplateItem() : base (default(string), default(Azure.Communication.Messages.MessageTemplateStatus)) { }
        public System.BinaryData Content { get { throw null; } }
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
