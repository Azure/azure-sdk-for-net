namespace Azure.Communication.Sms
{
    public partial class SmsClient
    {
        protected SmsClient() { }
        public SmsClient(string connectionString) { }
        public SmsClient(string connectionString, Azure.Communication.Sms.SmsClientOptions options) { }
        public SmsClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Sms.SmsClientOptions options = null) { }
        public SmsClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Sms.SmsClientOptions options = null) { }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.SmsSendResult>> Send(string from, System.Collections.Generic.IEnumerable<string> to, string message, Azure.Communication.Sms.SmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Sms.SmsSendResult> Send(string from, string to, string message, Azure.Communication.Sms.SmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.SmsSendResult>>> SendAsync(string from, System.Collections.Generic.IEnumerable<string> to, string message, Azure.Communication.Sms.SmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Sms.SmsSendResult>> SendAsync(string from, string to, string message, Azure.Communication.Sms.SmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SmsClientOptions : Azure.Core.ClientOptions
    {
        public SmsClientOptions(Azure.Communication.Sms.SmsClientOptions.ServiceVersion version = Azure.Communication.Sms.SmsClientOptions.ServiceVersion.V2021_03_07) { }
        public enum ServiceVersion
        {
            V2021_03_07 = 1,
        }
    }
    public partial class SmsSendOptions
    {
        public SmsSendOptions(bool enableDeliveryReport) { }
        public bool EnableDeliveryReport { get { throw null; } }
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
    public static partial class SmsModelFactory
    {
        public static Azure.Communication.Sms.SmsSendResult SmsSendResult(string to, string messageId, int httpStatusCode, bool successful, string errorMessage) { throw null; }
    }
}
