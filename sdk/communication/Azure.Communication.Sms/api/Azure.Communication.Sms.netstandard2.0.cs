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
        public SmsClientOptions(Azure.Communication.Sms.SmsClientOptions.ServiceVersion version = Azure.Communication.Sms.SmsClientOptions.ServiceVersion.V2024_01_14_Preview) { }
        public enum ServiceVersion
        {
            V2021_03_07 = 1,
            V2024_01_14_Preview = 2,
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

    public partial class MmsClient
    {
        protected MmsClient() { }
        public MmsClient(string connectionString) { }
        public MmsClient(string connectionString, Azure.Communication.Sms.MmsClientOptions options) { }
        public MmsClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.Sms.MmsClientOptions options = null) { }
        public MmsClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.Sms.MmsClientOptions options = null) { }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.MmsSendResult>> Send(string from, System.Collections.Generic.IEnumerable<string> to, string message, Azure.Communication.Sms.MmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.Sms.MmsSendResult> Send(string from, string to, string message, Azure.Communication.Sms.MmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Communication.Sms.MmsSendResult>>> SendAsync(string from, System.Collections.Generic.IEnumerable<string> to, string message, Azure.Communication.Sms.MmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.Sms.MmsSendResult>> SendAsync(string from, string to, string message, Azure.Communication.Sms.MmsSendOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }

    public partial class MmsAttachment
    {
        public MmsAttachment(MmsContentType contentType, byte[] contentInBase64) { }
        public MmsContentType ContentType { get { throw null; } }
        public byte[] ContentInBase64 { get { throw null; } }
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MmsContentType : System.IEquatable<Azure.Communication.Sms.MmsContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MmsContentType(string value) { throw null; }
        public static Azure.Communication.Sms.MmsContentType ImagePng { get { throw null; } }
        public static Azure.Communication.Sms.MmsContentType ImageJpeg { get { throw null; } }
        public static Azure.Communication.Sms.MmsContentType ImageGifValue { get { throw null; } }
        public static Azure.Communication.Sms.MmsContentType ImageBmpValue { get { throw null; } }
        public static Azure.Communication.Sms.MmsContentType AudioWavValue { get { throw null; } }
        public static Azure.Communication.Sms.MmsContentType AudioXWavValue { get { throw null; } }
        public static Azure.Communication.Sms.MmsContentType AudioAc3Value { get { throw null; } }
        public static Azure.Communication.Sms.MmsContentType AudioAmrValue { get { throw null; } }
        public static Azure.Communication.Sms.MmsContentType VideoMp4Value { get { throw null; } }
        public static Azure.Communication.Sms.MmsContentType VideoXMsvideoValue { get { throw null; } }
        public static Azure.Communication.Sms.MmsContentType TextPlainValue { get { throw null; } }
        public bool Equals(Azure.Communication.Sms.MmsContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.Sms.MmsContentType left, Azure.Communication.Sms.MmsContentType right) { throw null; }
        public static implicit operator Azure.Communication.Sms.MmsContentType(string value) { throw null; }
        public static bool operator !=(Azure.Communication.Sms.MmsContentType left, Azure.Communication.Sms.MmsContentType right) { throw null; }
        public override string ToString() { throw null; }
    }

    public partial class MmsClientOptions : Azure.Core.ClientOptions
    {
        public MmsClientOptions(Azure.Communication.Sms.MmsClientOptions.ServiceVersion version = Azure.Communication.Sms.MmsClientOptions.ServiceVersion.V2024_01_14_Preview) { }
        public enum ServiceVersion
        {
            V2024_01_14_Preview = 1,
        }
    }
    public partial class MmsSendOptions
    {
        public MmsSendOptions(bool enableDeliveryReport) { }
        public bool EnableDeliveryReport { get { throw null; } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class MmsSendResult
    {
        internal MmsSendResult() { }
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

    public static class MmsModelFactory
    {
        public static Azure.Communication.Sms.MmsSendResult MmsSendResult(string to, string messageId, int httpStatusCode, bool successful, string errorMessage) { throw null; }
    }
}
