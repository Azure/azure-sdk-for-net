namespace Azure.Communication.Email
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmailAddress
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmailAddress(string address) { throw null; }
        public EmailAddress(string address, string displayName) { throw null; }
        public string Address { get { throw null; } }
        public string DisplayName { get { throw null; } }
    }
    public partial class EmailAttachment
    {
        public EmailAttachment(string name, string contentType, System.BinaryData content) { }
        public System.BinaryData Content { get { throw null; } }
        public string ContentType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class EmailClient
    {
        protected EmailClient() { }
        public EmailClient(string connectionString) { }
        public EmailClient(string connectionString, Azure.Communication.Email.EmailClientOptions options) { }
        public EmailClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.Email.EmailClientOptions options = null) { }
        public EmailClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.Email.EmailClientOptions options = null) { }
        public virtual Azure.Communication.Email.EmailSendOperation Send(Azure.WaitUntil wait, Azure.Communication.Email.EmailMessage message, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.Email.EmailSendOperation Send(Azure.WaitUntil wait, Azure.Communication.Email.EmailMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.Email.EmailSendOperation Send(Azure.WaitUntil wait, string senderAddress, string recipientAddress, string subject, string htmlContent, System.Guid operationId, string plainTextContent = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Communication.Email.EmailSendOperation Send(Azure.WaitUntil wait, string senderAddress, string recipientAddress, string subject, string htmlContent, string plainTextContent = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.Email.EmailSendOperation> SendAsync(Azure.WaitUntil wait, Azure.Communication.Email.EmailMessage message, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.Email.EmailSendOperation> SendAsync(Azure.WaitUntil wait, Azure.Communication.Email.EmailMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.Email.EmailSendOperation> SendAsync(Azure.WaitUntil wait, string senderAddress, string recipientAddress, string subject, string htmlContent, System.Guid operationId, string plainTextContent = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Communication.Email.EmailSendOperation> SendAsync(Azure.WaitUntil wait, string senderAddress, string recipientAddress, string subject, string htmlContent, string plainTextContent = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmailClientOptions : Azure.Core.ClientOptions
    {
        public EmailClientOptions(Azure.Communication.Email.EmailClientOptions.ServiceVersion version = Azure.Communication.Email.EmailClientOptions.ServiceVersion.V2023_03_31) { }
        public enum ServiceVersion
        {
            V2021_10_01_Preview = 1,
            V2023_01_15_Preview = 2,
            V2023_03_31 = 3,
        }
    }
    public partial class EmailContent
    {
        public EmailContent(string subject) { }
        public string Html { get { throw null; } set { } }
        public string PlainText { get { throw null; } set { } }
        public string Subject { get { throw null; } }
    }
    public partial class EmailMessage
    {
        public EmailMessage(string senderAddress, Azure.Communication.Email.EmailRecipients recipients, Azure.Communication.Email.EmailContent content) { }
        public EmailMessage(string senderAddress, string recipientAddress, Azure.Communication.Email.EmailContent content) { }
        public System.Collections.Generic.IList<Azure.Communication.Email.EmailAttachment> Attachments { get { throw null; } }
        public Azure.Communication.Email.EmailContent Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } }
        public Azure.Communication.Email.EmailRecipients Recipients { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Email.EmailAddress> ReplyTo { get { throw null; } }
        public string SenderAddress { get { throw null; } }
        public bool? UserEngagementTrackingDisabled { get { throw null; } set { } }
    }
    public static partial class EmailModelFactory
    {
        public static Azure.Communication.Email.EmailSendResult EmailSendResult(string id = null, Azure.Communication.Email.EmailSendStatus status = default(Azure.Communication.Email.EmailSendStatus)) { throw null; }
    }
    public partial class EmailRecipients
    {
        public EmailRecipients(System.Collections.Generic.IEnumerable<Azure.Communication.Email.EmailAddress> to) { }
        public EmailRecipients(System.Collections.Generic.IEnumerable<Azure.Communication.Email.EmailAddress> to = null, System.Collections.Generic.IEnumerable<Azure.Communication.Email.EmailAddress> cc = null, System.Collections.Generic.IEnumerable<Azure.Communication.Email.EmailAddress> bcc = null) { }
        public System.Collections.Generic.IList<Azure.Communication.Email.EmailAddress> BCC { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Email.EmailAddress> CC { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Email.EmailAddress> To { get { throw null; } }
    }
    public partial class EmailSendOperation : Azure.Operation<Azure.Communication.Email.EmailSendResult>
    {
        protected EmailSendOperation() { }
        public EmailSendOperation(string id, Azure.Communication.Email.EmailClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Communication.Email.EmailSendResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Communication.Email.EmailSendResult> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Communication.Email.EmailSendResult> WaitForCompletion(System.TimeSpan suggestedPollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.Email.EmailSendResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Communication.Email.EmailSendResult>> WaitForCompletionAsync(System.TimeSpan suggestedPollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class EmailSendResult
    {
        internal EmailSendResult() { }
        public Azure.Communication.Email.EmailSendStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmailSendStatus : System.IEquatable<Azure.Communication.Email.EmailSendStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmailSendStatus(string value) { throw null; }
        public static Azure.Communication.Email.EmailSendStatus Canceled { get { throw null; } }
        public static Azure.Communication.Email.EmailSendStatus Failed { get { throw null; } }
        public static Azure.Communication.Email.EmailSendStatus NotStarted { get { throw null; } }
        public static Azure.Communication.Email.EmailSendStatus Running { get { throw null; } }
        public static Azure.Communication.Email.EmailSendStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.Communication.Email.EmailSendStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Email.EmailSendStatus left, Azure.Communication.Email.EmailSendStatus right) { throw null; }
        public static implicit operator Azure.Communication.Email.EmailSendStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Email.EmailSendStatus left, Azure.Communication.Email.EmailSendStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class EmailClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Email.EmailClient, Azure.Communication.Email.EmailClientOptions> AddEmailClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Email.EmailClient, Azure.Communication.Email.EmailClientOptions> AddEmailClient<TBuilder>(this TBuilder builder, System.Uri serviceUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Email.EmailClient, Azure.Communication.Email.EmailClientOptions> AddEmailClient<TBuilder>(this TBuilder builder, System.Uri serviceUri, Azure.AzureKeyCredential azureKeyCredential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.Email.EmailClient, Azure.Communication.Email.EmailClientOptions> AddEmailClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
