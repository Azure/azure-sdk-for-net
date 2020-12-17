namespace Azure.Communication.Sms
{
    public partial class SendSmsOptions
    {
        public SendSmsOptions() { }
        public bool? EnableDeliveryReport { get { throw null; } set { } }
    }
    public partial class SendSmsResponse
    {
        internal SendSmsResponse() { }
        public string MessageId { get { throw null; } }
    }
    public partial class SmsClient
    {
        protected SmsClient() { }
        public SmsClient(string connectionString, Azure.Communication.Sms.SmsClientOptions? options = null) { }
        public virtual Azure.Response<Azure.Communication.Sms.SendSmsResponse> Send(Azure.Communication.PhoneNumberIdentifier from, Azure.Communication.PhoneNumberIdentifier to, string message, Azure.Communication.Sms.SendSmsOptions? sendSmsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Sms.SendSmsResponse> Send(Azure.Communication.PhoneNumberIdentifier from, System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumberIdentifier> to, string message, Azure.Communication.Sms.SendSmsOptions? sendSmsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Sms.SendSmsResponse>> SendAsync(Azure.Communication.PhoneNumberIdentifier from, Azure.Communication.PhoneNumberIdentifier to, string message, Azure.Communication.Sms.SendSmsOptions? sendSmsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Sms.SendSmsResponse>> SendAsync(Azure.Communication.PhoneNumberIdentifier from, System.Collections.Generic.IEnumerable<Azure.Communication.PhoneNumberIdentifier> to, string message, Azure.Communication.Sms.SendSmsOptions? sendSmsOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SmsClientOptions : Azure.Core.ClientOptions
    {
        public const Azure.Communication.Sms.SmsClientOptions.ServiceVersion LatestVersion = Azure.Communication.Sms.SmsClientOptions.ServiceVersion.V1;
        public SmsClientOptions(Azure.Communication.Sms.SmsClientOptions.ServiceVersion version = Azure.Communication.Sms.SmsClientOptions.ServiceVersion.V1, Azure.Core.RetryOptions? retryOptions = null, Azure.Core.Pipeline.HttpPipelineTransport? transport = null) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
}
namespace Azure.Communication.Sms.Models
{
    public static partial class SmsModelFactory
    {
        public static Azure.Communication.Sms.SendSmsResponse SendSmsResponse(string messageId) { throw null; }
    }
}
