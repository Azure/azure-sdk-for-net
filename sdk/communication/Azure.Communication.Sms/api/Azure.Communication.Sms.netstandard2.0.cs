namespace Azure.Communication.Sms
{
    public partial class MessagingConnectOptions
    {
        public MessagingConnectOptions(string partner, object partnerParams) { }
        public string Partner { get { throw null; } }
        public object PartnerParams { get { throw null; } }
    }
    public partial class OptOuts
    {
        protected OptOuts() { }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.Models.OptOutAddResponseItem>> Add(string from, System.Collections.Generic.IEnumerable<string> to, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.Models.OptOutAddResponseItem>>> AddAsync(string from, System.Collections.Generic.IEnumerable<string> to, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.Models.OptOutResponseItem>> Check(string from, System.Collections.Generic.IEnumerable<string> to, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.Models.OptOutResponseItem>>> CheckAsync(string from, System.Collections.Generic.IEnumerable<string> to, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.Models.OptOutRemoveResponseItem>> Remove(string from, System.Collections.Generic.IEnumerable<string> to, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.Models.OptOutRemoveResponseItem>>> RemoveAsync(string from, System.Collections.Generic.IEnumerable<string> to, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SmsClient
    {
        protected SmsClient() { }
        public SmsClient(string connectionString) { }
        public SmsClient(string connectionString, Azure.Communication.Sms.SmsClientOptions options) { }
        public SmsClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Sms.SmsClientOptions options = null) { }
        public SmsClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Sms.SmsClientOptions options = null) { }
        public virtual Azure.Communication.Sms.OptOuts OptOuts { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.Sms.Models.DeliveryReport> GetDeliveryReport(string outgoingMessageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Sms.Models.DeliveryReport>> GetDeliveryReportAsync(string outgoingMessageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.SmsSendResult>> Send(string from, System.Collections.Generic.IEnumerable<string> to, string message, Azure.Communication.Sms.SmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Sms.SmsSendResult> Send(string from, string to, string message, Azure.Communication.Sms.SmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.SmsSendResult>>> SendAsync(string from, System.Collections.Generic.IEnumerable<string> to, string message, Azure.Communication.Sms.SmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Sms.SmsSendResult>> SendAsync(string from, string to, string message, Azure.Communication.Sms.SmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SmsClientOptions : Azure.Core.ClientOptions
    {
        public SmsClientOptions(Azure.Communication.Sms.SmsClientOptions.ServiceVersion version = Azure.Communication.Sms.SmsClientOptions.ServiceVersion.V2026_01_23) { }
        public enum ServiceVersion
        {
            V2021_03_07 = 1,
            V2025_05_29_Preview = 2,
            V2026_01_23 = 3,
        }
    }
    public partial class SmsSendOptions
    {
        public SmsSendOptions(bool enableDeliveryReport) { }
        public int? DeliveryReportTimeoutInSeconds { get { throw null; } set { } }
        public bool EnableDeliveryReport { get { throw null; } }
        public Azure.Communication.Sms.MessagingConnectOptions MessagingConnect { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class SmsSendResult
    {
        internal SmsSendResult() { }
        public string ErrorMessage { get { throw null; } }
        public int HttpStatusCode { get { throw null; } }
        public string MessageId { get { throw null; } }
        public bool Successful { get { throw null; } }
        public string To { get { throw null; } }
    }
}
namespace Azure.Communication.Sms.Models
{
    public static partial class CommunicationSmsModelFactory
    {
        public static Azure.Communication.Sms.Models.DeliveryAttempt DeliveryAttempt(System.DateTimeOffset timestamp = default(System.DateTimeOffset), int segmentsSucceeded = 0, int segmentsFailed = 0) { throw null; }
        public static Azure.Communication.Sms.Models.DeliveryReport DeliveryReport(Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus deliveryStatus = default(Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus), string deliveryStatusDetails = null, System.Collections.Generic.IEnumerable<Azure.Communication.Sms.Models.DeliveryAttempt> deliveryAttempts = null, System.DateTimeOffset? receivedTimestamp = default(System.DateTimeOffset?), string tag = null, string messagingConnectPartnerMessageId = null, string messageId = null, string from = null, string to = null) { throw null; }
        public static Azure.Communication.Sms.Models.OptOutResponseItem OptOutResponseItem(string to = null, int httpStatusCode = 0, bool? isOptedOut = default(bool?), string errorMessage = null) { throw null; }
    }
    public partial class DeliveryAttempt
    {
        internal DeliveryAttempt() { }
        public int SegmentsFailed { get { throw null; } }
        public int SegmentsSucceeded { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
    }
    public partial class DeliveryReport
    {
        internal DeliveryReport() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.Models.DeliveryAttempt> DeliveryAttempts { get { throw null; } }
        public Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus DeliveryStatus { get { throw null; } }
        public string DeliveryStatusDetails { get { throw null; } }
        public string From { get { throw null; } }
        public string MessageId { get { throw null; } }
        public string MessagingConnectPartnerMessageId { get { throw null; } }
        public System.DateTimeOffset? ReceivedTimestamp { get { throw null; } }
        public string Tag { get { throw null; } }
        public string To { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeliveryReportDeliveryStatus : System.IEquatable<Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeliveryReportDeliveryStatus(string value) { throw null; }
        public static Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus Delivered { get { throw null; } }
        public static Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus Failed { get { throw null; } }
        public bool Equals(Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus left, Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus right) { throw null; }
        public static implicit operator Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus left, Azure.Communication.Sms.Models.DeliveryReportDeliveryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct OptOutAddResponseItem
    {
        private object _dummy;
        private int _dummyPrimitive;
        public string ErrorMessage { get { throw null; } }
        public int HttpStatusCode { get { throw null; } }
        public string To { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct OptOutRemoveResponseItem
    {
        private object _dummy;
        private int _dummyPrimitive;
        public string ErrorMessage { get { throw null; } }
        public int HttpStatusCode { get { throw null; } }
        public string To { get { throw null; } }
    }
    public partial class OptOutResponseItem
    {
        internal OptOutResponseItem() { }
        public string ErrorMessage { get { throw null; } }
        public int HttpStatusCode { get { throw null; } }
        public bool? IsOptedOut { get { throw null; } }
        public string To { get { throw null; } }
    }
    public static partial class SmsModelFactory
    {
        public static Azure.Communication.Sms.SmsSendResult SmsSendResult(string to, string messageId, int httpStatusCode, bool successful, string errorMessage) { throw null; }
    }
}
