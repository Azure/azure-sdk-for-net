namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public abstract partial class CertificateSource : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource>
    {
        protected CertificateSource() { }
        Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CognitiveServicesVisionProcessor : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.CognitiveServicesVisionProcessor>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CognitiveServicesVisionProcessor>
    {
        public CognitiveServicesVisionProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint, Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase operation) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase Endpoint { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties Image { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase Operation { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions SamplingOptions { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.CognitiveServicesVisionProcessor System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.CognitiveServicesVisionProcessor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.CognitiveServicesVisionProcessor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.CognitiveServicesVisionProcessor System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CognitiveServicesVisionProcessor>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CognitiveServicesVisionProcessor>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CognitiveServicesVisionProcessor>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CredentialsBase : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase>
    {
        protected CredentialsBase() { }
        Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveredOnvifDevice : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice>
    {
        public DiscoveredOnvifDevice() { }
        public System.Collections.Generic.IList<string> Endpoints { get { throw null; } }
        public string RemoteIPAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public string ServiceIdentifier { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveredOnvifDeviceCollection : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection>
    {
        public DiscoveredOnvifDeviceCollection() { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice> Value { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection Deserialize(string json) { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EndpointBase : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase>
    {
        protected EndpointBase(string url) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase Credentials { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionProcessorBase : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase>
    {
        public ExtensionProcessorBase(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint, Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties image) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase Endpoint { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties Image { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions SamplingOptions { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSink : Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.FileSink>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.FileSink>
    {
        public FileSink(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, string baseDirectoryPath, string fileNamePattern, string maximumSizeMiB) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public string BaseDirectoryPath { get { throw null; } set { } }
        public string FileNamePattern { get { throw null; } set { } }
        public string MaximumSizeMiB { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.FileSink System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.FileSink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.FileSink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.FileSink System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.FileSink>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.FileSink>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.FileSink>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GrpcExtension : Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtension>
    {
        public GrpcExtension(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint, Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties image, Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer dataTransfer) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>), default(Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase), default(Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer DataTransfer { get { throw null; } set { } }
        public string ExtensionConfiguration { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtension System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtension System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtension>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtension>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtension>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GrpcExtensionDataTransfer : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer>
    {
        public GrpcExtensionDataTransfer(Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode mode) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode Mode { get { throw null; } set { } }
        public string SharedMemorySizeMiB { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrpcExtensionDataTransferMode : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrpcExtensionDataTransferMode(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode Embedded { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode SharedMemory { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode left, Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode left, Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class H264Configuration : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration>
    {
        public H264Configuration() { }
        public float? GovLength { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.H264Profile? Profile { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct H264Profile : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.H264Profile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public H264Profile(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.H264Profile Baseline { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.H264Profile Extended { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.H264Profile High { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.H264Profile Main { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.H264Profile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.H264Profile left, Azure.Media.VideoAnalyzer.Edge.Models.H264Profile right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.H264Profile (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.H264Profile left, Azure.Media.VideoAnalyzer.Edge.Models.H264Profile right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpExtension : Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpExtension>
    {
        public HttpExtension(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint, Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties image) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>), default(Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase), default(Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties)) { }
        Azure.Media.VideoAnalyzer.Edge.Models.HttpExtension System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.HttpExtension System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpExtension>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpExtension>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpExtension>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HttpHeaderCredentials : Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpHeaderCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpHeaderCredentials>
    {
        public HttpHeaderCredentials(string headerName, string headerValue) { }
        public string HeaderName { get { throw null; } set { } }
        public string HeaderValue { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.HttpHeaderCredentials System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpHeaderCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpHeaderCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.HttpHeaderCredentials System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpHeaderCredentials>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpHeaderCredentials>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.HttpHeaderCredentials>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageFormatBmp : Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatBmp>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatBmp>
    {
        public ImageFormatBmp() { }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatBmp System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatBmp>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatBmp>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatBmp System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatBmp>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatBmp>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatBmp>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageFormatJpeg : Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatJpeg>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatJpeg>
    {
        public ImageFormatJpeg() { }
        public string Quality { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatJpeg System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatJpeg>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatJpeg>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatJpeg System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatJpeg>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatJpeg>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatJpeg>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageFormatPng : Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatPng>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatPng>
    {
        public ImageFormatPng() { }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatPng System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatPng>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatPng>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatPng System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatPng>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatPng>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatPng>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ImageFormatProperties : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties>
    {
        protected ImageFormatProperties() { }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageFormatRaw : Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRaw>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRaw>
    {
        public ImageFormatRaw(Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat pixelFormat) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat PixelFormat { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRaw System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRaw>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRaw>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRaw System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRaw>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRaw>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRaw>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageFormatRawPixelFormat : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageFormatRawPixelFormat(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Abgr { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Argb { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Bgr24 { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Bgra { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Rgb24 { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Rgb555Be { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Rgb555Le { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Rgb565Be { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Rgb565Le { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Rgba { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat Yuv420P { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat left, Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat left, Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageProperties : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties>
    {
        public ImageProperties() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties Format { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageScale Scale { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageScale : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageScale>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageScale>
    {
        public ImageScale() { }
        public string Height { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode? Mode { get { throw null; } set { } }
        public string Width { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageScale System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageScale>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageScale>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ImageScale System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageScale>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageScale>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ImageScale>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageScaleMode : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageScaleMode(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode Pad { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode PreserveAspectRatio { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode Stretch { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode left, Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode left, Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubDeviceConnection : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection>
    {
        public IotHubDeviceConnection(string deviceId) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase Credentials { get { throw null; } set { } }
        public string DeviceId { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubMessageSink : Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSink>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSink>
    {
        public IotHubMessageSink(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, string hubOutputName) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public string HubOutputName { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSink System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSink System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSink>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSink>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSink>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotHubMessageSource : Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSource>
    {
        public IotHubMessageSource(string name) : base (default(string)) { }
        public string HubInputName { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSource System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSource System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSource>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSource>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.IotHubMessageSource>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LineCrossingProcessor : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LineCrossingProcessor>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LineCrossingProcessor>
    {
        public LineCrossingProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase> lines) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase> Lines { get { throw null; } }
        Azure.Media.VideoAnalyzer.Edge.Models.LineCrossingProcessor System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LineCrossingProcessor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LineCrossingProcessor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LineCrossingProcessor System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LineCrossingProcessor>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LineCrossingProcessor>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LineCrossingProcessor>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivePipeline : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline>
    {
        public LivePipeline(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties Properties { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SystemData SystemData { get { throw null; } set { } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline Deserialize(string json) { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivePipelineActivateRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineActivateRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineActivateRequest>
    {
        public LivePipelineActivateRequest(string name) : base (default(string)) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineActivateRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineActivateRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineActivateRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineActivateRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineActivateRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineActivateRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineActivateRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivePipelineCollection : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection>
    {
        public LivePipelineCollection() { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline> Value { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection Deserialize(string json) { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivePipelineDeactivateRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeactivateRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeactivateRequest>
    {
        public LivePipelineDeactivateRequest(string name) : base (default(string)) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeactivateRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeactivateRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeactivateRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeactivateRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeactivateRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeactivateRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeactivateRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivePipelineDeleteRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeleteRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeleteRequest>
    {
        public LivePipelineDeleteRequest(string name) : base (default(string)) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeleteRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeleteRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeleteRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeleteRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeleteRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeleteRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineDeleteRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivePipelineGetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineGetRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineGetRequest>
    {
        public LivePipelineGetRequest(string name) : base (default(string)) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineGetRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineGetRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineGetRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineGetRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineGetRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineGetRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineGetRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivePipelineListRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineListRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineListRequest>
    {
        public LivePipelineListRequest() { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineListRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineListRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineListRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineListRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineListRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineListRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineListRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivePipelineProperties : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties>
    {
        public LivePipelineProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition> Parameters { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState? State { get { throw null; } set { } }
        public string TopologyName { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivePipelineSetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineSetRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineSetRequest>
    {
        public LivePipelineSetRequest(Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline livePipeline) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline LivePipeline { get { throw null; } set { } }
        public override string GetPayloadAsJson() { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineSetRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineSetRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineSetRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineSetRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineSetRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineSetRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineSetRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LivePipelineState : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LivePipelineState(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState Activating { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState Active { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState Deactivating { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState Inactive { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState left, Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState left, Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaProfile : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile>
    {
        public MediaProfile() { }
        public object MediaUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration VideoEncoderConfiguration { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MediaUri : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaUri>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaUri>
    {
        public MediaUri() { }
        public string Uri { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.MediaUri System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.MediaUri System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaUri>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaUri>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MediaUri>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MethodRequest : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest>
    {
        protected MethodRequest() { }
        public string ApiVersion { get { throw null; } set { } }
        public string MethodName { get { throw null; } set { } }
        public virtual string GetPayloadAsJson() { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MethodRequestEmptyBodyBase : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase>
    {
        public MethodRequestEmptyBodyBase(string name) { }
        public string Name { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MotionDetectionProcessor : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionProcessor>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionProcessor>
    {
        public MotionDetectionProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public string EventAggregationWindow { get { throw null; } set { } }
        public bool? OutputMotionRegion { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity? Sensitivity { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionProcessor System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionProcessor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionProcessor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionProcessor System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionProcessor>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionProcessor>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionProcessor>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MotionDetectionSensitivity : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MotionDetectionSensitivity(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity High { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity Low { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity Medium { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity left, Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity left, Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Mpeg4Configuration : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration>
    {
        public Mpeg4Configuration() { }
        public float? GovLength { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile? Profile { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mpeg4Profile : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mpeg4Profile(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile ASP { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile SP { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile left, Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile left, Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class NamedLineBase : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase>
    {
        protected NamedLineBase(string name) { }
        public string Name { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedLineString : Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineString>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineString>
    {
        public NamedLineString(string name, string line) : base (default(string)) { }
        public string Line { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.NamedLineString System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineString>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineString>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.NamedLineString System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineString>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineString>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineString>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class NamedPolygonBase : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase>
    {
        protected NamedPolygonBase(string name) { }
        public string Name { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedPolygonString : Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonString>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonString>
    {
        public NamedPolygonString(string name, string polygon) : base (default(string)) { }
        public string Polygon { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonString System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonString>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonString>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonString System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonString>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonString>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonString>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeInput : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>
    {
        public NodeInput(string nodeName) { }
        public string NodeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector> OutputSelectors { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.NodeInput FromNodeName(string nodeName) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.NodeInput (string nodeName) { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.NodeInput System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.NodeInput System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObjectTrackingAccuracy : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObjectTrackingAccuracy(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy High { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy Low { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy Medium { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy left, Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy left, Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ObjectTrackingProcessor : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingProcessor>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingProcessor>
    {
        public ObjectTrackingProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy? Accuracy { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingProcessor System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingProcessor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingProcessor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingProcessor System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingProcessor>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingProcessor>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingProcessor>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnvifDevice : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice>
    {
        public OnvifDevice() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns Dns { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName Hostname { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile> MediaProfiles { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime SystemDateTime { get { throw null; } set { } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice Deserialize(string json) { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnvifDeviceDiscoverRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceDiscoverRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceDiscoverRequest>
    {
        public OnvifDeviceDiscoverRequest() { }
        public string DiscoveryDuration { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceDiscoverRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceDiscoverRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceDiscoverRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceDiscoverRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceDiscoverRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceDiscoverRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceDiscoverRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnvifDeviceGetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceGetRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceGetRequest>
    {
        public OnvifDeviceGetRequest(Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase Endpoint { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceGetRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceGetRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceGetRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceGetRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceGetRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceGetRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDeviceGetRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnvifDns : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns>
    {
        public OnvifDns() { }
        public bool? FromDhcp { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ipv4Address { get { throw null; } }
        public System.Collections.Generic.IList<string> Ipv6Address { get { throw null; } }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnvifHostName : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName>
    {
        public OnvifHostName() { }
        public bool? FromDhcp { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnvifSystemDateTime : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime>
    {
        public OnvifSystemDateTime() { }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType? Type { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnvifSystemDateTimeType : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnvifSystemDateTimeType(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType Manual { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType Ntp { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType left, Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType left, Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputSelector : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector>
    {
        public OutputSelector() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator? Operator { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorProperty? Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutputSelectorOperator : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputSelectorOperator(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator Is { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator IsNot { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator left, Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator left, Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutputSelectorProperty : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorProperty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputSelectorProperty(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorProperty MediaType { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorProperty other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorProperty left, Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorProperty right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorProperty (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorProperty left, Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorProperty right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParameterDeclaration : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration>
    {
        public ParameterDeclaration(string name, Azure.Media.VideoAnalyzer.Edge.Models.ParameterType type) { }
        public string Default { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.ParameterType Type { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParameterDefinition : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition>
    {
        public ParameterDefinition(string name) { }
        public ParameterDefinition(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterType : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.ParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterType(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ParameterType Bool { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ParameterType Double { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ParameterType Int { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ParameterType SecretString { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.ParameterType String { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.ParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.ParameterType left, Azure.Media.VideoAnalyzer.Edge.Models.ParameterType right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.ParameterType (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.ParameterType left, Azure.Media.VideoAnalyzer.Edge.Models.ParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PemCertificateList : Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PemCertificateList>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PemCertificateList>
    {
        public PemCertificateList(System.Collections.Generic.IEnumerable<string> certificates) { }
        public PemCertificateList(System.Collections.Generic.IList<System.Security.Cryptography.X509Certificates.X509Certificate2> certificates) { }
        public PemCertificateList(params System.Security.Cryptography.X509Certificates.X509Certificate2[] certificates) { }
        public System.Collections.Generic.IList<string> Certificates { get { throw null; } }
        Azure.Media.VideoAnalyzer.Edge.Models.PemCertificateList System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PemCertificateList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PemCertificateList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.PemCertificateList System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PemCertificateList>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PemCertificateList>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PemCertificateList>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineTopology : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology>
    {
        public PipelineTopology(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties Properties { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SystemData SystemData { get { throw null; } set { } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology Deserialize(string json) { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineTopologyCollection : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection>
    {
        public PipelineTopologyCollection() { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology> Value { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection Deserialize(string json) { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineTopologyDeleteRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyDeleteRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyDeleteRequest>
    {
        public PipelineTopologyDeleteRequest(string name) : base (default(string)) { }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyDeleteRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyDeleteRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyDeleteRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyDeleteRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyDeleteRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyDeleteRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyDeleteRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineTopologyGetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyGetRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyGetRequest>
    {
        public PipelineTopologyGetRequest(string name) : base (default(string)) { }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyGetRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyGetRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyGetRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyGetRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyGetRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyGetRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyGetRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineTopologyListRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyListRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyListRequest>
    {
        public PipelineTopologyListRequest() { }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyListRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyListRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyListRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyListRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyListRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyListRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyListRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineTopologyProperties : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties>
    {
        public PipelineTopologyProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase> Processors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase> Sources { get { throw null; } }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PipelineTopologySetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologySetRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologySetRequest>
    {
        public PipelineTopologySetRequest(Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology pipelineTopology) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology PipelineTopology { get { throw null; } set { } }
        public override string GetPayloadAsJson() { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologySetRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologySetRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologySetRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologySetRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologySetRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologySetRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologySetRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ProcessorNodeBase : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase>
    {
        protected ProcessorNodeBase(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> Inputs { get { throw null; } }
        public string Name { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RateControl : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RateControl>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RateControl>
    {
        public RateControl() { }
        public float? BitRateLimit { get { throw null; } set { } }
        public float? EncodingInterval { get { throw null; } set { } }
        public float? FrameRateLimit { get { throw null; } set { } }
        public bool? GuaranteedFrameRate { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.RateControl System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RateControl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RateControl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RateControl System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RateControl>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RateControl>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RateControl>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteDeviceAdapter : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter>
    {
        public RemoteDeviceAdapter(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties Properties { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SystemData SystemData { get { throw null; } set { } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter Deserialize(string json) { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteDeviceAdapterCollection : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection>
    {
        public RemoteDeviceAdapterCollection() { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter> Value { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection Deserialize(string json) { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteDeviceAdapterDeleteRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterDeleteRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterDeleteRequest>
    {
        public RemoteDeviceAdapterDeleteRequest(string name) : base (default(string)) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterDeleteRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterDeleteRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterDeleteRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterDeleteRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterDeleteRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterDeleteRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterDeleteRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteDeviceAdapterGetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterGetRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterGetRequest>
    {
        public RemoteDeviceAdapterGetRequest(string name) : base (default(string)) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterGetRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterGetRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterGetRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterGetRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterGetRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterGetRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterGetRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteDeviceAdapterListRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterListRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterListRequest>
    {
        public RemoteDeviceAdapterListRequest() { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterListRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterListRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterListRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterListRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterListRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterListRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterListRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteDeviceAdapterProperties : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties>
    {
        public RemoteDeviceAdapterProperties(Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget target, Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection iotHubDeviceConnection) { }
        public string Description { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection IotHubDeviceConnection { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget Target { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteDeviceAdapterSetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterSetRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterSetRequest>
    {
        public RemoteDeviceAdapterSetRequest(Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter remoteDeviceAdapter) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter RemoteDeviceAdapter { get { throw null; } set { } }
        public override string GetPayloadAsJson() { throw null; }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterSetRequest System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterSetRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterSetRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterSetRequest System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterSetRequest>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterSetRequest>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterSetRequest>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteDeviceAdapterTarget : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget>
    {
        public RemoteDeviceAdapterTarget(string host) { }
        public string Host { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RtspSource : Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RtspSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RtspSource>
    {
        public RtspSource(string name, Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint) : base (default(string)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase Endpoint { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport? Transport { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.RtspSource System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RtspSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.RtspSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.RtspSource System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RtspSource>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RtspSource>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.RtspSource>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RtspTransport : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RtspTransport(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport Http { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport Tcp { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport left, Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport left, Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SamplingOptions : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions>
    {
        public SamplingOptions() { }
        public string MaximumSamplesPerSecond { get { throw null; } set { } }
        public string SkipSamplesWithoutAnnotation { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalGateProcessor : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SignalGateProcessor>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SignalGateProcessor>
    {
        public SignalGateProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public string ActivationEvaluationWindow { get { throw null; } set { } }
        public string ActivationSignalOffset { get { throw null; } set { } }
        public string MaximumActivationTime { get { throw null; } set { } }
        public string MinimumActivationTime { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SignalGateProcessor System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SignalGateProcessor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SignalGateProcessor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SignalGateProcessor System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SignalGateProcessor>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SignalGateProcessor>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SignalGateProcessor>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SinkNodeBase : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase>
    {
        protected SinkNodeBase(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> Inputs { get { throw null; } }
        public string Name { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SourceNodeBase : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase>
    {
        protected SourceNodeBase(string name) { }
        public string Name { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisCustomOperation : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisCustomOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisCustomOperation>
    {
        public SpatialAnalysisCustomOperation(string extensionConfiguration) { }
        public string ExtensionConfiguration { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisCustomOperation System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisCustomOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisCustomOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisCustomOperation System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisCustomOperation>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisCustomOperation>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisCustomOperation>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SpatialAnalysisOperationBase : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase>
    {
        protected SpatialAnalysisOperationBase() { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisOperationEventBase : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase>
    {
        public SpatialAnalysisOperationEventBase() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus? Focus { get { throw null; } set { } }
        public string Threshold { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpatialAnalysisOperationFocus : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpatialAnalysisOperationFocus(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus BottomCenter { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus Center { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus Footprint { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus left, Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus left, Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpatialAnalysisPersonCountEvent : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent>
    {
        public SpatialAnalysisPersonCountEvent() { }
        public string OutputFrequency { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger? Trigger { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpatialAnalysisPersonCountEventTrigger : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpatialAnalysisPersonCountEventTrigger(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger Event { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger Interval { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger left, Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger left, Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpatialAnalysisPersonCountOperation : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountOperation>
    {
        public SpatialAnalysisPersonCountOperation(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents> zones) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents> Zones { get { throw null; } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountOperation System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountOperation System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountOperation>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountOperation>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountOperation>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisPersonCountZoneEvents : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents>
    {
        public SpatialAnalysisPersonCountZoneEvents(Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase zone) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent> Events { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase Zone { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisPersonDistanceEvent : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent>
    {
        public SpatialAnalysisPersonDistanceEvent() { }
        public string MaximumDistanceThreshold { get { throw null; } set { } }
        public string MinimumDistanceThreshold { get { throw null; } set { } }
        public string OutputFrequency { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger? Trigger { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpatialAnalysisPersonDistanceEventTrigger : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpatialAnalysisPersonDistanceEventTrigger(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger Event { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger Interval { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger left, Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger left, Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpatialAnalysisPersonDistanceOperation : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceOperation>
    {
        public SpatialAnalysisPersonDistanceOperation(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents> zones) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents> Zones { get { throw null; } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceOperation System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceOperation System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceOperation>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceOperation>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceOperation>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisPersonDistanceZoneEvents : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents>
    {
        public SpatialAnalysisPersonDistanceZoneEvents(Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase zone) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent> Events { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase Zone { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisPersonLineCrossingEvent : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent>
    {
        public SpatialAnalysisPersonLineCrossingEvent() { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisPersonLineCrossingLineEvents : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents>
    {
        public SpatialAnalysisPersonLineCrossingLineEvents(Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase line) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent> Events { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase Line { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisPersonLineCrossingOperation : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingOperation>
    {
        public SpatialAnalysisPersonLineCrossingOperation(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents> lines) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents> Lines { get { throw null; } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingOperation System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingOperation System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingOperation>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingOperation>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingOperation>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisPersonZoneCrossingEvent : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent>
    {
        public SpatialAnalysisPersonZoneCrossingEvent() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType? EventType { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpatialAnalysisPersonZoneCrossingEventType : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpatialAnalysisPersonZoneCrossingEventType(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType ZoneCrossing { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType ZoneDwellTime { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType left, Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType left, Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpatialAnalysisPersonZoneCrossingOperation : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingOperation>
    {
        public SpatialAnalysisPersonZoneCrossingOperation(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents> zones) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents> Zones { get { throw null; } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingOperation System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingOperation System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingOperation>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingOperation>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingOperation>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisPersonZoneCrossingZoneEvents : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents>
    {
        public SpatialAnalysisPersonZoneCrossingZoneEvents(Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase zone) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent> Events { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase Zone { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnalysisTypedOperationBase : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase>
    {
        public SpatialAnalysisTypedOperationBase() { }
        public string CalibrationConfiguration { get { throw null; } set { } }
        public string CameraCalibratorNodeConfiguration { get { throw null; } set { } }
        public string CameraConfiguration { get { throw null; } set { } }
        public string Debug { get { throw null; } set { } }
        public string DetectorNodeConfiguration { get { throw null; } set { } }
        public string EnableFaceMaskClassifier { get { throw null; } set { } }
        public string TrackerNodeConfiguration { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SymmetricKeyCredentials : Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SymmetricKeyCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SymmetricKeyCredentials>
    {
        public SymmetricKeyCredentials(string key) { }
        public string Key { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SymmetricKeyCredentials System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SymmetricKeyCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SymmetricKeyCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SymmetricKeyCredentials System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SymmetricKeyCredentials>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SymmetricKeyCredentials>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SymmetricKeyCredentials>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemData : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SystemData>
    {
        public SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.SystemData System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.SystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.SystemData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SystemData>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SystemData>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.SystemData>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TlsEndpoint : Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsEndpoint>
    {
        public TlsEndpoint(string url) : base (default(string)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource TrustedCertificates { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions ValidationOptions { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.TlsEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.TlsEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsEndpoint>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsEndpoint>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsEndpoint>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TlsValidationOptions : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions>
    {
        public TlsValidationOptions() { }
        public string IgnoreHostname { get { throw null; } set { } }
        public string IgnoreSignature { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnsecuredEndpoint : Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.UnsecuredEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.UnsecuredEndpoint>
    {
        public UnsecuredEndpoint(string url) : base (default(string)) { }
        Azure.Media.VideoAnalyzer.Edge.Models.UnsecuredEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.UnsecuredEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.UnsecuredEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.UnsecuredEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.UnsecuredEndpoint>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.UnsecuredEndpoint>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.UnsecuredEndpoint>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsernamePasswordCredentials : Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.UsernamePasswordCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.UsernamePasswordCredentials>
    {
        public UsernamePasswordCredentials(string username, string password) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.UsernamePasswordCredentials System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.UsernamePasswordCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.UsernamePasswordCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.UsernamePasswordCredentials System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.UsernamePasswordCredentials>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.UsernamePasswordCredentials>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.UsernamePasswordCredentials>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoCreationProperties : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties>
    {
        public VideoCreationProperties() { }
        public string Description { get { throw null; } set { } }
        public string RetentionPeriod { get { throw null; } set { } }
        public string SegmentLength { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoEncoderConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration>
    {
        public VideoEncoderConfiguration() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding? Encoding { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration H264 { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration Mpeg4 { get { throw null; } set { } }
        public float? Quality { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.RateControl RateControl { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution Resolution { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VideoEncoding : System.IEquatable<Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VideoEncoding(string value) { throw null; }
        public static Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding H264 { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding Jpeg { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding Mpeg4 { get { throw null; } }
        public bool Equals(Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding left, Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding right) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding (string value) { throw null; }
        public static bool operator !=(Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding left, Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VideoPublishingOptions : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions>
    {
        public VideoPublishingOptions() { }
        public string EnableVideoPreviewImage { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoResolution : System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution>
    {
        public VideoResolution() { }
        public float? Height { get { throw null; } set { } }
        public float? Width { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoSink : Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase, System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoSink>, System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoSink>
    {
        public VideoSink(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, string videoName, string localMediaCachePath, string localMediaCacheMaximumSizeMiB) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public string LocalMediaCacheMaximumSizeMiB { get { throw null; } set { } }
        public string LocalMediaCachePath { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties VideoCreationProperties { get { throw null; } set { } }
        public string VideoName { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions VideoPublishingOptions { get { throw null; } set { } }
        Azure.Media.VideoAnalyzer.Edge.Models.VideoSink System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoSink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoSink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Media.VideoAnalyzer.Edge.Models.VideoSink System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoSink>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoSink>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Media.VideoAnalyzer.Edge.Models.VideoSink>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
}
