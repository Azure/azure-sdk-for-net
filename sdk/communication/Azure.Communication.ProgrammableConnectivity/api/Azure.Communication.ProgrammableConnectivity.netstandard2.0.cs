namespace Azure.Communication.ProgrammableConnectivity
{
    public partial class AzureCommunicationProgrammableConnectivityContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureCommunicationProgrammableConnectivityContext() { }
        public static Azure.Communication.ProgrammableConnectivity.AzureCommunicationProgrammableConnectivityContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class CommunicationProgrammableConnectivityModelFactory
    {
        public static Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult DeviceLocationVerificationResult(bool verificationResult = false) { throw null; }
        public static Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult NetworkRetrievalResult(string networkCode = null) { throw null; }
        public static Azure.Communication.ProgrammableConnectivity.NumberVerificationResult NumberVerificationResult(bool verificationResult = false) { throw null; }
        public static Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent NumberVerificationWithoutCodeContent(Azure.Communication.ProgrammableConnectivity.NetworkIdentifier networkIdentifier = null, string phoneNumber = null, string hashedPhoneNumber = null, System.Uri redirectUri = null) { throw null; }
        public static Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent SimSwapRetrievalContent(string phoneNumber = null, Azure.Communication.ProgrammableConnectivity.NetworkIdentifier networkIdentifier = null) { throw null; }
        public static Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult SimSwapRetrievalResult(System.DateTimeOffset? date = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent SimSwapVerificationContent(string phoneNumber = null, int? maxAgeHours = default(int?), Azure.Communication.ProgrammableConnectivity.NetworkIdentifier networkIdentifier = null) { throw null; }
        public static Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult SimSwapVerificationResult(bool verificationResult = false) { throw null; }
    }
    public partial class DeviceLocation
    {
        protected DeviceLocation() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult> Verify(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Verify(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult>> VerifyAsync(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> VerifyAsync(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DeviceLocationVerificationContent : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent>
    {
        public DeviceLocationVerificationContent(Azure.Communication.ProgrammableConnectivity.NetworkIdentifier networkIdentifier, double latitude, double longitude, int accuracy, Azure.Communication.ProgrammableConnectivity.LocationDevice device) { }
        public int Accuracy { get { throw null; } }
        public Azure.Communication.ProgrammableConnectivity.LocationDevice Device { get { throw null; } }
        public double Latitude { get { throw null; } }
        public double Longitude { get { throw null; } }
        public Azure.Communication.ProgrammableConnectivity.NetworkIdentifier NetworkIdentifier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceLocationVerificationResult : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult>
    {
        internal DeviceLocationVerificationResult() { }
        public bool VerificationResult { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.DeviceLocationVerificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceNetwork
    {
        protected DeviceNetwork() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult> Retrieve(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.NetworkIdentifier body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Retrieve(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult>> RetrieveAsync(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.NetworkIdentifier body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RetrieveAsync(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class Ipv4Address : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.Ipv4Address>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.Ipv4Address>
    {
        public Ipv4Address(string ipv4, int port) { }
        public string Ipv4 { get { throw null; } }
        public int Port { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.Ipv4Address System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.Ipv4Address>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.Ipv4Address>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.Ipv4Address System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.Ipv4Address>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.Ipv4Address>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.Ipv4Address>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Ipv6Address : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.Ipv6Address>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.Ipv6Address>
    {
        public Ipv6Address(string ipv6, int port) { }
        public string Ipv6 { get { throw null; } }
        public int Port { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.Ipv6Address System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.Ipv6Address>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.Ipv6Address>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.Ipv6Address System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.Ipv6Address>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.Ipv6Address>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.Ipv6Address>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocationDevice : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.LocationDevice>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.LocationDevice>
    {
        public LocationDevice() { }
        public Azure.Communication.ProgrammableConnectivity.Ipv4Address Ipv4Address { get { throw null; } set { } }
        public Azure.Communication.ProgrammableConnectivity.Ipv6Address Ipv6Address { get { throw null; } set { } }
        public string NetworkAccessIdentifier { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.LocationDevice System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.LocationDevice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.LocationDevice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.LocationDevice System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.LocationDevice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.LocationDevice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.LocationDevice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NetworkIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NetworkIdentifier>
    {
        public NetworkIdentifier(string identifierType, string identifier) { }
        public string Identifier { get { throw null; } }
        public string IdentifierType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.NetworkIdentifier System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NetworkIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NetworkIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.NetworkIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NetworkIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NetworkIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NetworkIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkRetrievalResult : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult>
    {
        internal NetworkRetrievalResult() { }
        public string NetworkCode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NetworkRetrievalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberVerification
    {
        protected NumberVerification() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.ProgrammableConnectivity.NumberVerificationResult> VerifyWithCode(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response VerifyWithCode(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.ProgrammableConnectivity.NumberVerificationResult>> VerifyWithCodeAsync(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> VerifyWithCodeAsync(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response VerifyWithoutCode(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent numberVerificationWithoutCodeContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response VerifyWithoutCode(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> VerifyWithoutCodeAsync(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent numberVerificationWithoutCodeContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> VerifyWithoutCodeAsync(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class NumberVerificationResult : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationResult>
    {
        internal NumberVerificationResult() { }
        public bool VerificationResult { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.NumberVerificationResult System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.NumberVerificationResult System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberVerificationWithCodeContent : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent>
    {
        public NumberVerificationWithCodeContent(string apcCode) { }
        public string ApcCode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithCodeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberVerificationWithoutCodeContent : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent>
    {
        public NumberVerificationWithoutCodeContent(Azure.Communication.ProgrammableConnectivity.NetworkIdentifier networkIdentifier, System.Uri redirectUri) { }
        public string HashedPhoneNumber { get { throw null; } set { } }
        public Azure.Communication.ProgrammableConnectivity.NetworkIdentifier NetworkIdentifier { get { throw null; } }
        public string PhoneNumber { get { throw null; } set { } }
        public System.Uri RedirectUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.NumberVerificationWithoutCodeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProgrammableConnectivityClient
    {
        protected ProgrammableConnectivityClient() { }
        public ProgrammableConnectivityClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ProgrammableConnectivityClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.ProgrammableConnectivity.ProgrammableConnectivityClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Communication.ProgrammableConnectivity.DeviceLocation GetDeviceLocationClient(string apiVersion = "2024-02-09-preview") { throw null; }
        public virtual Azure.Communication.ProgrammableConnectivity.DeviceNetwork GetDeviceNetworkClient(string apiVersion = "2024-02-09-preview") { throw null; }
        public virtual Azure.Communication.ProgrammableConnectivity.NumberVerification GetNumberVerificationClient(string apiVersion = "2024-02-09-preview") { throw null; }
        public virtual Azure.Communication.ProgrammableConnectivity.SimSwap GetSimSwapClient(string apiVersion = "2024-02-09-preview") { throw null; }
    }
    public partial class ProgrammableConnectivityClientOptions : Azure.Core.ClientOptions
    {
        public ProgrammableConnectivityClientOptions(Azure.Communication.ProgrammableConnectivity.ProgrammableConnectivityClientOptions.ServiceVersion version = Azure.Communication.ProgrammableConnectivity.ProgrammableConnectivityClientOptions.ServiceVersion.V2024_02_09_Preview) { }
        public enum ServiceVersion
        {
            V2024_02_09_Preview = 1,
        }
    }
    public partial class SimSwap
    {
        protected SimSwap() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult> Retrieve(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Retrieve(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult>> RetrieveAsync(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RetrieveAsync(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult> Verify(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Verify(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult>> VerifyAsync(string apcGatewayId, Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> VerifyAsync(string apcGatewayId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SimSwapRetrievalContent : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent>
    {
        public SimSwapRetrievalContent(Azure.Communication.ProgrammableConnectivity.NetworkIdentifier networkIdentifier) { }
        public Azure.Communication.ProgrammableConnectivity.NetworkIdentifier NetworkIdentifier { get { throw null; } }
        public string PhoneNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimSwapRetrievalResult : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult>
    {
        internal SimSwapRetrievalResult() { }
        public System.DateTimeOffset? Date { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapRetrievalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimSwapVerificationContent : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent>
    {
        public SimSwapVerificationContent(Azure.Communication.ProgrammableConnectivity.NetworkIdentifier networkIdentifier) { }
        public int? MaxAgeHours { get { throw null; } set { } }
        public Azure.Communication.ProgrammableConnectivity.NetworkIdentifier NetworkIdentifier { get { throw null; } }
        public string PhoneNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimSwapVerificationResult : System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult>
    {
        internal SimSwapVerificationResult() { }
        public bool VerificationResult { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.ProgrammableConnectivity.SimSwapVerificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class CommunicationProgrammableConnectivityClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.ProgrammableConnectivity.ProgrammableConnectivityClient, Azure.Communication.ProgrammableConnectivity.ProgrammableConnectivityClientOptions> AddProgrammableConnectivityClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.ProgrammableConnectivity.ProgrammableConnectivityClient, Azure.Communication.ProgrammableConnectivity.ProgrammableConnectivityClientOptions> AddProgrammableConnectivityClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
