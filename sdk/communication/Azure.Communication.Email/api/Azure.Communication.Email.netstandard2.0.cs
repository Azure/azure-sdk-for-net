namespace Azure.Communication.Email
{
    public static partial class CommunicationEmailModelFactory
    {
        public static Azure.Communication.Email.Models.SendEmailResult SendEmailResult(string messageId = null) { throw null; }
        public static Azure.Communication.Email.Models.SendStatusResult SendStatusResult(string messageId = null, Azure.Communication.Email.Models.SendStatus status = default(Azure.Communication.Email.Models.SendStatus)) { throw null; }
    }
    public partial class EmailClient
    {
        protected EmailClient() { }
        public EmailClient(string connectionString) { }
        public EmailClient(string connectionString, Azure.Communication.Email.EmailClientOptions options) { }
        public EmailClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Email.EmailClientOptions options = null) { }
        public EmailClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Email.EmailClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.Email.Models.SendStatusResult> GetSendStatus(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Email.Models.SendStatusResult>> GetSendStatusAsync(string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Email.Models.SendEmailResult> Send(Azure.Communication.Email.Models.EmailMessage emailMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Email.Models.SendEmailResult>> SendAsync(Azure.Communication.Email.Models.EmailMessage emailMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmailClientOptions : Azure.Core.ClientOptions
    {
        public EmailClientOptions(Azure.Communication.Email.EmailClientOptions.ServiceVersion version = Azure.Communication.Email.EmailClientOptions.ServiceVersion.V2021_10_01_Preview) { }
        public enum ServiceVersion
        {
            V2021_10_01_Preview = 1,
        }
    }
}
namespace Azure.Communication.Email.Models
{
    public partial class EmailAddress
    {
        public EmailAddress(string email) { }
        public EmailAddress(string email, string displayName = null) { }
        public string DisplayName { get { throw null; } set { } }
        public string Email { get { throw null; } }
    }
    public partial class EmailAttachment
    {
        public EmailAttachment(string name, Azure.Communication.Email.Models.EmailAttachmentType attachmentType, string contentBytesBase64) { }
        public Azure.Communication.Email.Models.EmailAttachmentType AttachmentType { get { throw null; } }
        public string ContentBytesBase64 { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmailAttachmentType : System.IEquatable<Azure.Communication.Email.Models.EmailAttachmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmailAttachmentType(string value) { throw null; }
        public static Azure.Communication.Email.Models.EmailAttachmentType Avi { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Bmp { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Doc { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Docm { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Docx { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Gif { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Jpeg { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Mp3 { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType One { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Pdf { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Png { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Ppsm { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Ppsx { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Ppt { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Pptm { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Pptx { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Pub { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Rpmsg { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Rtf { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Tif { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Txt { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Vsd { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Wav { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Wma { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Xls { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Xlsb { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Xlsm { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailAttachmentType Xlsx { get { throw null; } }
        public bool Equals(Azure.Communication.Email.Models.EmailAttachmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Email.Models.EmailAttachmentType left, Azure.Communication.Email.Models.EmailAttachmentType right) { throw null; }
        public static implicit operator Azure.Communication.Email.Models.EmailAttachmentType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Email.Models.EmailAttachmentType left, Azure.Communication.Email.Models.EmailAttachmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmailContent
    {
        public EmailContent(string subject) { }
        public string Html { get { throw null; } set { } }
        public string PlainText { get { throw null; } set { } }
        public string Subject { get { throw null; } }
    }
    public partial class EmailCustomHeader
    {
        public EmailCustomHeader(string name, string value) { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmailImportance : System.IEquatable<Azure.Communication.Email.Models.EmailImportance>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmailImportance(string value) { throw null; }
        public static Azure.Communication.Email.Models.EmailImportance High { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailImportance Low { get { throw null; } }
        public static Azure.Communication.Email.Models.EmailImportance Normal { get { throw null; } }
        public bool Equals(Azure.Communication.Email.Models.EmailImportance other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Email.Models.EmailImportance left, Azure.Communication.Email.Models.EmailImportance right) { throw null; }
        public static implicit operator Azure.Communication.Email.Models.EmailImportance (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Email.Models.EmailImportance left, Azure.Communication.Email.Models.EmailImportance right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmailMessage
    {
        public EmailMessage(string sender, Azure.Communication.Email.Models.EmailContent content, Azure.Communication.Email.Models.EmailRecipients recipients) { }
        public System.Collections.Generic.IList<Azure.Communication.Email.Models.EmailAttachment> Attachments { get { throw null; } }
        public Azure.Communication.Email.Models.EmailContent Content { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Email.Models.EmailCustomHeader> CustomHeaders { get { throw null; } }
        public bool? DisableUserEngagementTracking { get { throw null; } set { } }
        public Azure.Communication.Email.Models.EmailImportance? Importance { get { throw null; } set { } }
        public Azure.Communication.Email.Models.EmailRecipients Recipients { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Email.Models.EmailAddress> ReplyTo { get { throw null; } }
        public string Sender { get { throw null; } }
    }
    public partial class EmailRecipients
    {
        public EmailRecipients(System.Collections.Generic.IEnumerable<Azure.Communication.Email.Models.EmailAddress> to) { }
        public EmailRecipients(System.Collections.Generic.IEnumerable<Azure.Communication.Email.Models.EmailAddress> to = null, System.Collections.Generic.IEnumerable<Azure.Communication.Email.Models.EmailAddress> cc = null, System.Collections.Generic.IEnumerable<Azure.Communication.Email.Models.EmailAddress> bcc = null) { }
        public System.Collections.Generic.IList<Azure.Communication.Email.Models.EmailAddress> BCC { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Email.Models.EmailAddress> CC { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.Email.Models.EmailAddress> To { get { throw null; } }
    }
    public partial class SendEmailResult
    {
        internal SendEmailResult() { }
        public string MessageId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendStatus : System.IEquatable<Azure.Communication.Email.Models.SendStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendStatus(string value) { throw null; }
        public static Azure.Communication.Email.Models.SendStatus Dropped { get { throw null; } }
        public static Azure.Communication.Email.Models.SendStatus OutForDelivery { get { throw null; } }
        public static Azure.Communication.Email.Models.SendStatus Queued { get { throw null; } }
        public bool Equals(Azure.Communication.Email.Models.SendStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Email.Models.SendStatus left, Azure.Communication.Email.Models.SendStatus right) { throw null; }
        public static implicit operator Azure.Communication.Email.Models.SendStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Email.Models.SendStatus left, Azure.Communication.Email.Models.SendStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SendStatusResult
    {
        internal SendStatusResult() { }
        public string MessageId { get { throw null; } }
        public Azure.Communication.Email.Models.SendStatus Status { get { throw null; } }
    }
}
