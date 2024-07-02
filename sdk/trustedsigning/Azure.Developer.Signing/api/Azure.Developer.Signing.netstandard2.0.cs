namespace Azure.Developer.Signing
{
    public partial class CertificateProfile
    {
        protected CertificateProfile() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetExtendedKeyUsages(string accountName, string certificateProfile, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Developer.Signing.ExtendedKeyUsage> GetExtendedKeyUsages(string accountName, string certificateProfile, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetExtendedKeyUsagesAsync(string accountName, string certificateProfile, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Developer.Signing.ExtendedKeyUsage> GetExtendedKeyUsagesAsync(string accountName, string certificateProfile, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSigningStatus(string accountName, string certificateProfile, string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Developer.Signing.OperationStatusSignResultError> GetSigningStatus(string accountName, string certificateProfile, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSigningStatusAsync(string accountName, string certificateProfile, string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Developer.Signing.OperationStatusSignResultError>> GetSigningStatusAsync(string accountName, string certificateProfile, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSignRootCertificate(string accountName, string certificateProfile, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetSignRootCertificate(string accountName, string certificateProfile, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSignRootCertificateAsync(string accountName, string certificateProfile, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetSignRootCertificateAsync(string accountName, string certificateProfile, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Sign(Azure.WaitUntil waitUntil, string accountName, string certificateProfile, Azure.Core.RequestContent content, string clientVersion = null, string xCorrelationId = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.Developer.Signing.SignResult> Sign(Azure.WaitUntil waitUntil, string accountName, string certificateProfile, Azure.Developer.Signing.SigningPayloadOptions signingPayloadOptions, string clientVersion = null, string xCorrelationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> SignAsync(Azure.WaitUntil waitUntil, string accountName, string certificateProfile, Azure.Core.RequestContent content, string clientVersion = null, string xCorrelationId = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.Developer.Signing.SignResult>> SignAsync(Azure.WaitUntil waitUntil, string accountName, string certificateProfile, Azure.Developer.Signing.SigningPayloadOptions signingPayloadOptions, string clientVersion = null, string xCorrelationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DeveloperSigningModelFactory
    {
        public static Azure.Developer.Signing.ExtendedKeyUsage ExtendedKeyUsage(string eku = null) { throw null; }
        public static Azure.Developer.Signing.OperationStatusSignResultError OperationStatusSignResultError(string id = null, Azure.Developer.Signing.OperationState status = Azure.Developer.Signing.OperationState.NotStarted, Azure.ResponseError error = null, Azure.Developer.Signing.SignResult result = null) { throw null; }
        public static Azure.Developer.Signing.SigningPayloadOptions SigningPayloadOptions(Azure.Developer.Signing.SignatureAlgorithm signatureAlgorithm = Azure.Developer.Signing.SignatureAlgorithm.RS256, System.BinaryData digest = null, System.Collections.Generic.IEnumerable<System.BinaryData> fileHashList = null, System.Collections.Generic.IEnumerable<System.BinaryData> authenticodeHashList = null) { throw null; }
        public static Azure.Developer.Signing.SignResult SignResult(System.BinaryData signature = null, System.BinaryData signingCertificate = null) { throw null; }
    }
    public partial class ExtendedKeyUsage : System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.ExtendedKeyUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.ExtendedKeyUsage>
    {
        internal ExtendedKeyUsage() { }
        public string Eku { get { throw null; } }
        Azure.Developer.Signing.ExtendedKeyUsage System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.ExtendedKeyUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.ExtendedKeyUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.Signing.ExtendedKeyUsage System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.ExtendedKeyUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.ExtendedKeyUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.ExtendedKeyUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum OperationState
    {
        NotStarted = 0,
        Running = 1,
        Succeeded = 2,
        Failed = 3,
        Canceled = 4,
    }
    public partial class OperationStatusSignResultError : System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.OperationStatusSignResultError>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.OperationStatusSignResultError>
    {
        internal OperationStatusSignResultError() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Developer.Signing.SignResult Result { get { throw null; } }
        public Azure.Developer.Signing.OperationState Status { get { throw null; } }
        Azure.Developer.Signing.OperationStatusSignResultError System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.OperationStatusSignResultError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.OperationStatusSignResultError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.Signing.OperationStatusSignResultError System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.OperationStatusSignResultError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.OperationStatusSignResultError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.OperationStatusSignResultError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SignatureAlgorithm
    {
        RS256 = 0,
        RS384 = 1,
        RS512 = 2,
        PS256 = 3,
        PS384 = 4,
        PS512 = 5,
        ES256 = 6,
        ES384 = 7,
        ES512 = 8,
        ES256K = 9,
    }
    public partial class SigningClient
    {
        protected SigningClient() { }
        public SigningClient(Azure.Core.TokenCredential credential) { }
        public SigningClient(Azure.Core.TokenCredential credential, Azure.Developer.Signing.SigningClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Developer.Signing.CertificateProfile GetCertificateProfileClient(string region, string apiVersion = "2023-06-15-preview") { throw null; }
    }
    public partial class SigningClientOptions : Azure.Core.ClientOptions
    {
        public SigningClientOptions(Azure.Developer.Signing.SigningClientOptions.ServiceVersion version = Azure.Developer.Signing.SigningClientOptions.ServiceVersion.V2023_06_15_Preview) { }
        public enum ServiceVersion
        {
            V2023_06_15_Preview = 1,
        }
    }
    public partial class SigningPayloadOptions : System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.SigningPayloadOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.SigningPayloadOptions>
    {
        public SigningPayloadOptions(Azure.Developer.Signing.SignatureAlgorithm signatureAlgorithm, System.BinaryData digest) { }
        public System.Collections.Generic.IList<System.BinaryData> AuthenticodeHashList { get { throw null; } }
        public System.BinaryData Digest { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> FileHashList { get { throw null; } }
        public Azure.Developer.Signing.SignatureAlgorithm SignatureAlgorithm { get { throw null; } }
        Azure.Developer.Signing.SigningPayloadOptions System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.SigningPayloadOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.SigningPayloadOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.Signing.SigningPayloadOptions System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.SigningPayloadOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.SigningPayloadOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.SigningPayloadOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignResult : System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.SignResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.SignResult>
    {
        internal SignResult() { }
        public System.BinaryData Signature { get { throw null; } }
        public System.BinaryData SigningCertificate { get { throw null; } }
        Azure.Developer.Signing.SignResult System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.SignResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Developer.Signing.SignResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Developer.Signing.SignResult System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.SignResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.SignResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Developer.Signing.SignResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class DeveloperSigningClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.Signing.SigningClient, Azure.Developer.Signing.SigningClientOptions> AddSigningClient<TBuilder>(this TBuilder builder) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.Signing.SigningClient, Azure.Developer.Signing.SigningClientOptions> AddSigningClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
