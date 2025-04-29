namespace Azure.Media.VideoAnalyzer.Edge
{
    public partial class AzureMediaVideoAnalyzerEdgeContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureMediaVideoAnalyzerEdgeContext() { }
        public static Azure.Media.VideoAnalyzer.Edge.AzureMediaVideoAnalyzerEdgeContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public abstract partial class CertificateSource
    {
        protected CertificateSource() { }
    }
    public partial class CognitiveServicesVisionProcessor : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase
    {
        public CognitiveServicesVisionProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint, Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase operation) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase Endpoint { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties Image { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase Operation { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions SamplingOptions { get { throw null; } set { } }
    }
    public abstract partial class CredentialsBase
    {
        protected CredentialsBase() { }
    }
    public partial class DiscoveredOnvifDevice
    {
        public DiscoveredOnvifDevice() { }
        public System.Collections.Generic.IList<string> Endpoints { get { throw null; } }
        public string RemoteIPAddress { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public string ServiceIdentifier { get { throw null; } set { } }
    }
    public partial class DiscoveredOnvifDeviceCollection
    {
        public DiscoveredOnvifDeviceCollection() { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDevice> Value { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.DiscoveredOnvifDeviceCollection Deserialize(string json) { throw null; }
    }
    public abstract partial class EndpointBase
    {
        protected EndpointBase(string url) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase Credentials { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
    }
    public partial class ExtensionProcessorBase : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase
    {
        public ExtensionProcessorBase(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint, Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties image) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase Endpoint { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties Image { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SamplingOptions SamplingOptions { get { throw null; } set { } }
    }
    public partial class FileSink : Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase
    {
        public FileSink(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, string baseDirectoryPath, string fileNamePattern, string maximumSizeMiB) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public string BaseDirectoryPath { get { throw null; } set { } }
        public string FileNamePattern { get { throw null; } set { } }
        public string MaximumSizeMiB { get { throw null; } set { } }
    }
    public partial class GrpcExtension : Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase
    {
        public GrpcExtension(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint, Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties image, Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer dataTransfer) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>), default(Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase), default(Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransfer DataTransfer { get { throw null; } set { } }
        public string ExtensionConfiguration { get { throw null; } set { } }
    }
    public partial class GrpcExtensionDataTransfer
    {
        public GrpcExtensionDataTransfer(Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode mode) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.GrpcExtensionDataTransferMode Mode { get { throw null; } set { } }
        public string SharedMemorySizeMiB { get { throw null; } set { } }
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
    public partial class H264Configuration
    {
        public H264Configuration() { }
        public float? GovLength { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.H264Profile? Profile { get { throw null; } set { } }
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
    public partial class HttpExtension : Azure.Media.VideoAnalyzer.Edge.Models.ExtensionProcessorBase
    {
        public HttpExtension(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint, Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties image) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>), default(Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase), default(Azure.Media.VideoAnalyzer.Edge.Models.ImageProperties)) { }
    }
    public partial class HttpHeaderCredentials : Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase
    {
        public HttpHeaderCredentials(string headerName, string headerValue) { }
        public string HeaderName { get { throw null; } set { } }
        public string HeaderValue { get { throw null; } set { } }
    }
    public partial class ImageFormatBmp : Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties
    {
        public ImageFormatBmp() { }
    }
    public partial class ImageFormatJpeg : Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties
    {
        public ImageFormatJpeg() { }
        public string Quality { get { throw null; } set { } }
    }
    public partial class ImageFormatPng : Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties
    {
        public ImageFormatPng() { }
    }
    public abstract partial class ImageFormatProperties
    {
        protected ImageFormatProperties() { }
    }
    public partial class ImageFormatRaw : Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties
    {
        public ImageFormatRaw(Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat pixelFormat) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatRawPixelFormat PixelFormat { get { throw null; } set { } }
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
    public partial class ImageProperties
    {
        public ImageProperties() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageFormatProperties Format { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageScale Scale { get { throw null; } set { } }
    }
    public partial class ImageScale
    {
        public ImageScale() { }
        public string Height { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.ImageScaleMode? Mode { get { throw null; } set { } }
        public string Width { get { throw null; } set { } }
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
    public partial class IotHubDeviceConnection
    {
        public IotHubDeviceConnection(string deviceId) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase Credentials { get { throw null; } set { } }
        public string DeviceId { get { throw null; } set { } }
    }
    public partial class IotHubMessageSink : Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase
    {
        public IotHubMessageSink(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, string hubOutputName) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public string HubOutputName { get { throw null; } set { } }
    }
    public partial class IotHubMessageSource : Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase
    {
        public IotHubMessageSource(string name) : base (default(string)) { }
        public string HubInputName { get { throw null; } set { } }
    }
    public partial class LineCrossingProcessor : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase
    {
        public LineCrossingProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase> lines) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase> Lines { get { throw null; } }
    }
    public partial class LivePipeline
    {
        public LivePipeline(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineProperties Properties { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SystemData SystemData { get { throw null; } set { } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline Deserialize(string json) { throw null; }
    }
    public partial class LivePipelineActivateRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase
    {
        public LivePipelineActivateRequest(string name) : base (default(string)) { }
    }
    public partial class LivePipelineCollection
    {
        public LivePipelineCollection() { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline> Value { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineCollection Deserialize(string json) { throw null; }
    }
    public partial class LivePipelineDeactivateRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase
    {
        public LivePipelineDeactivateRequest(string name) : base (default(string)) { }
    }
    public partial class LivePipelineDeleteRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase
    {
        public LivePipelineDeleteRequest(string name) : base (default(string)) { }
    }
    public partial class LivePipelineGetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase
    {
        public LivePipelineGetRequest(string name) : base (default(string)) { }
    }
    public partial class LivePipelineListRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest
    {
        public LivePipelineListRequest() { }
    }
    public partial class LivePipelineProperties
    {
        public LivePipelineProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDefinition> Parameters { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.LivePipelineState? State { get { throw null; } set { } }
        public string TopologyName { get { throw null; } set { } }
    }
    public partial class LivePipelineSetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest
    {
        public LivePipelineSetRequest(Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline livePipeline) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.LivePipeline LivePipeline { get { throw null; } set { } }
        public override string GetPayloadAsJson() { throw null; }
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
    public partial class MediaProfile
    {
        public MediaProfile() { }
        public object MediaUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoderConfiguration VideoEncoderConfiguration { get { throw null; } set { } }
    }
    public partial class MediaUri
    {
        public MediaUri() { }
        public string Uri { get { throw null; } set { } }
    }
    public abstract partial class MethodRequest
    {
        protected MethodRequest() { }
        public string ApiVersion { get { throw null; } set { } }
        public string MethodName { get { throw null; } set { } }
        public virtual string GetPayloadAsJson() { throw null; }
    }
    public partial class MethodRequestEmptyBodyBase : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest
    {
        public MethodRequestEmptyBodyBase(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class MotionDetectionProcessor : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase
    {
        public MotionDetectionProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public string EventAggregationWindow { get { throw null; } set { } }
        public bool? OutputMotionRegion { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.MotionDetectionSensitivity? Sensitivity { get { throw null; } set { } }
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
    public partial class Mpeg4Configuration
    {
        public Mpeg4Configuration() { }
        public float? GovLength { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Profile? Profile { get { throw null; } set { } }
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
    public abstract partial class NamedLineBase
    {
        protected NamedLineBase(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class NamedLineString : Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase
    {
        public NamedLineString(string name, string line) : base (default(string)) { }
        public string Line { get { throw null; } set { } }
    }
    public abstract partial class NamedPolygonBase
    {
        protected NamedPolygonBase(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class NamedPolygonString : Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase
    {
        public NamedPolygonString(string name, string polygon) : base (default(string)) { }
        public string Polygon { get { throw null; } set { } }
    }
    public partial class NodeInput
    {
        public NodeInput(string nodeName) { }
        public string NodeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.OutputSelector> OutputSelectors { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.NodeInput FromNodeName(string nodeName) { throw null; }
        public static implicit operator Azure.Media.VideoAnalyzer.Edge.Models.NodeInput (string nodeName) { throw null; }
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
    public partial class ObjectTrackingProcessor : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase
    {
        public ObjectTrackingProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.ObjectTrackingAccuracy? Accuracy { get { throw null; } set { } }
    }
    public partial class OnvifDevice
    {
        public OnvifDevice() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.OnvifDns Dns { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.OnvifHostName Hostname { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.MediaProfile> MediaProfiles { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTime SystemDateTime { get { throw null; } set { } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.OnvifDevice Deserialize(string json) { throw null; }
    }
    public partial class OnvifDeviceDiscoverRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest
    {
        public OnvifDeviceDiscoverRequest() { }
        public string DiscoveryDuration { get { throw null; } set { } }
    }
    public partial class OnvifDeviceGetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest
    {
        public OnvifDeviceGetRequest(Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase Endpoint { get { throw null; } set { } }
    }
    public partial class OnvifDns
    {
        public OnvifDns() { }
        public bool? FromDhcp { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ipv4Address { get { throw null; } }
        public System.Collections.Generic.IList<string> Ipv6Address { get { throw null; } }
    }
    public partial class OnvifHostName
    {
        public OnvifHostName() { }
        public bool? FromDhcp { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
    }
    public partial class OnvifSystemDateTime
    {
        public OnvifSystemDateTime() { }
        public string Time { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.OnvifSystemDateTimeType? Type { get { throw null; } set { } }
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
    public partial class OutputSelector
    {
        public OutputSelector() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorOperator? Operator { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.OutputSelectorProperty? Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
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
    public partial class ParameterDeclaration
    {
        public ParameterDeclaration(string name, Azure.Media.VideoAnalyzer.Edge.Models.ParameterType type) { }
        public string Default { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.ParameterType Type { get { throw null; } set { } }
    }
    public partial class ParameterDefinition
    {
        public ParameterDefinition(string name) { }
        public ParameterDefinition(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
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
    public partial class PemCertificateList : Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource
    {
        public PemCertificateList(System.Collections.Generic.IEnumerable<string> certificates) { }
        public PemCertificateList(System.Collections.Generic.IList<System.Security.Cryptography.X509Certificates.X509Certificate2> certificates) { }
        public PemCertificateList(params System.Security.Cryptography.X509Certificates.X509Certificate2[] certificates) { }
        public System.Collections.Generic.IList<string> Certificates { get { throw null; } }
    }
    public partial class PipelineTopology
    {
        public PipelineTopology(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyProperties Properties { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SystemData SystemData { get { throw null; } set { } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology Deserialize(string json) { throw null; }
    }
    public partial class PipelineTopologyCollection
    {
        public PipelineTopologyCollection() { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology> Value { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopologyCollection Deserialize(string json) { throw null; }
    }
    public partial class PipelineTopologyDeleteRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase
    {
        public PipelineTopologyDeleteRequest(string name) : base (default(string)) { }
    }
    public partial class PipelineTopologyGetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase
    {
        public PipelineTopologyGetRequest(string name) : base (default(string)) { }
    }
    public partial class PipelineTopologyListRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest
    {
        public PipelineTopologyListRequest() { }
    }
    public partial class PipelineTopologyProperties
    {
        public PipelineTopologyProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.ParameterDeclaration> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase> Processors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase> Sources { get { throw null; } }
    }
    public partial class PipelineTopologySetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest
    {
        public PipelineTopologySetRequest(Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology pipelineTopology) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.PipelineTopology PipelineTopology { get { throw null; } set { } }
        public override string GetPayloadAsJson() { throw null; }
    }
    public abstract partial class ProcessorNodeBase
    {
        protected ProcessorNodeBase(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> Inputs { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class RateControl
    {
        public RateControl() { }
        public float? BitRateLimit { get { throw null; } set { } }
        public float? EncodingInterval { get { throw null; } set { } }
        public float? FrameRateLimit { get { throw null; } set { } }
        public bool? GuaranteedFrameRate { get { throw null; } set { } }
    }
    public partial class RemoteDeviceAdapter
    {
        public RemoteDeviceAdapter(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterProperties Properties { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SystemData SystemData { get { throw null; } set { } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter Deserialize(string json) { throw null; }
    }
    public partial class RemoteDeviceAdapterCollection
    {
        public RemoteDeviceAdapterCollection() { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter> Value { get { throw null; } }
        public static Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterCollection Deserialize(string json) { throw null; }
    }
    public partial class RemoteDeviceAdapterDeleteRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase
    {
        public RemoteDeviceAdapterDeleteRequest(string name) : base (default(string)) { }
    }
    public partial class RemoteDeviceAdapterGetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequestEmptyBodyBase
    {
        public RemoteDeviceAdapterGetRequest(string name) : base (default(string)) { }
    }
    public partial class RemoteDeviceAdapterListRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest
    {
        public RemoteDeviceAdapterListRequest() { }
    }
    public partial class RemoteDeviceAdapterProperties
    {
        public RemoteDeviceAdapterProperties(Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget target, Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection iotHubDeviceConnection) { }
        public string Description { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.IotHubDeviceConnection IotHubDeviceConnection { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapterTarget Target { get { throw null; } set { } }
    }
    public partial class RemoteDeviceAdapterSetRequest : Azure.Media.VideoAnalyzer.Edge.Models.MethodRequest
    {
        public RemoteDeviceAdapterSetRequest(Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter remoteDeviceAdapter) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.RemoteDeviceAdapter RemoteDeviceAdapter { get { throw null; } set { } }
        public override string GetPayloadAsJson() { throw null; }
    }
    public partial class RemoteDeviceAdapterTarget
    {
        public RemoteDeviceAdapterTarget(string host) { }
        public string Host { get { throw null; } set { } }
    }
    public partial class RtspSource : Azure.Media.VideoAnalyzer.Edge.Models.SourceNodeBase
    {
        public RtspSource(string name, Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase endpoint) : base (default(string)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase Endpoint { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.RtspTransport? Transport { get { throw null; } set { } }
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
    public partial class SamplingOptions
    {
        public SamplingOptions() { }
        public string MaximumSamplesPerSecond { get { throw null; } set { } }
        public string SkipSamplesWithoutAnnotation { get { throw null; } set { } }
    }
    public partial class SignalGateProcessor : Azure.Media.VideoAnalyzer.Edge.Models.ProcessorNodeBase
    {
        public SignalGateProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public string ActivationEvaluationWindow { get { throw null; } set { } }
        public string ActivationSignalOffset { get { throw null; } set { } }
        public string MaximumActivationTime { get { throw null; } set { } }
        public string MinimumActivationTime { get { throw null; } set { } }
    }
    public abstract partial class SinkNodeBase
    {
        protected SinkNodeBase(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> Inputs { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public abstract partial class SourceNodeBase
    {
        protected SourceNodeBase(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class SpatialAnalysisCustomOperation : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase
    {
        public SpatialAnalysisCustomOperation(string extensionConfiguration) { }
        public string ExtensionConfiguration { get { throw null; } set { } }
    }
    public abstract partial class SpatialAnalysisOperationBase
    {
        protected SpatialAnalysisOperationBase() { }
    }
    public partial class SpatialAnalysisOperationEventBase
    {
        public SpatialAnalysisOperationEventBase() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationFocus? Focus { get { throw null; } set { } }
        public string Threshold { get { throw null; } set { } }
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
    public partial class SpatialAnalysisPersonCountEvent : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase
    {
        public SpatialAnalysisPersonCountEvent() { }
        public string OutputFrequency { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEventTrigger? Trigger { get { throw null; } set { } }
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
    public partial class SpatialAnalysisPersonCountOperation : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase
    {
        public SpatialAnalysisPersonCountOperation(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents> zones) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountZoneEvents> Zones { get { throw null; } }
    }
    public partial class SpatialAnalysisPersonCountZoneEvents
    {
        public SpatialAnalysisPersonCountZoneEvents(Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase zone) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonCountEvent> Events { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase Zone { get { throw null; } set { } }
    }
    public partial class SpatialAnalysisPersonDistanceEvent : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase
    {
        public SpatialAnalysisPersonDistanceEvent() { }
        public string MaximumDistanceThreshold { get { throw null; } set { } }
        public string MinimumDistanceThreshold { get { throw null; } set { } }
        public string OutputFrequency { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEventTrigger? Trigger { get { throw null; } set { } }
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
    public partial class SpatialAnalysisPersonDistanceOperation : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase
    {
        public SpatialAnalysisPersonDistanceOperation(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents> zones) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceZoneEvents> Zones { get { throw null; } }
    }
    public partial class SpatialAnalysisPersonDistanceZoneEvents
    {
        public SpatialAnalysisPersonDistanceZoneEvents(Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase zone) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonDistanceEvent> Events { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase Zone { get { throw null; } set { } }
    }
    public partial class SpatialAnalysisPersonLineCrossingEvent : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase
    {
        public SpatialAnalysisPersonLineCrossingEvent() { }
    }
    public partial class SpatialAnalysisPersonLineCrossingLineEvents
    {
        public SpatialAnalysisPersonLineCrossingLineEvents(Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase line) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingEvent> Events { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.NamedLineBase Line { get { throw null; } set { } }
    }
    public partial class SpatialAnalysisPersonLineCrossingOperation : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase
    {
        public SpatialAnalysisPersonLineCrossingOperation(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents> lines) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonLineCrossingLineEvents> Lines { get { throw null; } }
    }
    public partial class SpatialAnalysisPersonZoneCrossingEvent : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationEventBase
    {
        public SpatialAnalysisPersonZoneCrossingEvent() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEventType? EventType { get { throw null; } set { } }
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
    public partial class SpatialAnalysisPersonZoneCrossingOperation : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisTypedOperationBase
    {
        public SpatialAnalysisPersonZoneCrossingOperation(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents> zones) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingZoneEvents> Zones { get { throw null; } }
    }
    public partial class SpatialAnalysisPersonZoneCrossingZoneEvents
    {
        public SpatialAnalysisPersonZoneCrossingZoneEvents(Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase zone) { }
        public System.Collections.Generic.IList<Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisPersonZoneCrossingEvent> Events { get { throw null; } }
        public Azure.Media.VideoAnalyzer.Edge.Models.NamedPolygonBase Zone { get { throw null; } set { } }
    }
    public partial class SpatialAnalysisTypedOperationBase : Azure.Media.VideoAnalyzer.Edge.Models.SpatialAnalysisOperationBase
    {
        public SpatialAnalysisTypedOperationBase() { }
        public string CalibrationConfiguration { get { throw null; } set { } }
        public string CameraCalibratorNodeConfiguration { get { throw null; } set { } }
        public string CameraConfiguration { get { throw null; } set { } }
        public string Debug { get { throw null; } set { } }
        public string DetectorNodeConfiguration { get { throw null; } set { } }
        public string EnableFaceMaskClassifier { get { throw null; } set { } }
        public string TrackerNodeConfiguration { get { throw null; } set { } }
    }
    public partial class SymmetricKeyCredentials : Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase
    {
        public SymmetricKeyCredentials(string key) { }
        public string Key { get { throw null; } set { } }
    }
    public partial class SystemData
    {
        public SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
    }
    public partial class TlsEndpoint : Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase
    {
        public TlsEndpoint(string url) : base (default(string)) { }
        public Azure.Media.VideoAnalyzer.Edge.Models.CertificateSource TrustedCertificates { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.TlsValidationOptions ValidationOptions { get { throw null; } set { } }
    }
    public partial class TlsValidationOptions
    {
        public TlsValidationOptions() { }
        public string IgnoreHostname { get { throw null; } set { } }
        public string IgnoreSignature { get { throw null; } set { } }
    }
    public partial class UnsecuredEndpoint : Azure.Media.VideoAnalyzer.Edge.Models.EndpointBase
    {
        public UnsecuredEndpoint(string url) : base (default(string)) { }
    }
    public partial class UsernamePasswordCredentials : Azure.Media.VideoAnalyzer.Edge.Models.CredentialsBase
    {
        public UsernamePasswordCredentials(string username, string password) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class VideoCreationProperties
    {
        public VideoCreationProperties() { }
        public string Description { get { throw null; } set { } }
        public string RetentionPeriod { get { throw null; } set { } }
        public string SegmentLength { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class VideoEncoderConfiguration
    {
        public VideoEncoderConfiguration() { }
        public Azure.Media.VideoAnalyzer.Edge.Models.VideoEncoding? Encoding { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.H264Configuration H264 { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.Mpeg4Configuration Mpeg4 { get { throw null; } set { } }
        public float? Quality { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.RateControl RateControl { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.VideoResolution Resolution { get { throw null; } set { } }
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
    public partial class VideoPublishingOptions
    {
        public VideoPublishingOptions() { }
        public string EnableVideoPreviewImage { get { throw null; } set { } }
    }
    public partial class VideoResolution
    {
        public VideoResolution() { }
        public float? Height { get { throw null; } set { } }
        public float? Width { get { throw null; } set { } }
    }
    public partial class VideoSink : Azure.Media.VideoAnalyzer.Edge.Models.SinkNodeBase
    {
        public VideoSink(string name, System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput> inputs, string videoName, string localMediaCachePath, string localMediaCacheMaximumSizeMiB) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.VideoAnalyzer.Edge.Models.NodeInput>)) { }
        public string LocalMediaCacheMaximumSizeMiB { get { throw null; } set { } }
        public string LocalMediaCachePath { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.VideoCreationProperties VideoCreationProperties { get { throw null; } set { } }
        public string VideoName { get { throw null; } set { } }
        public Azure.Media.VideoAnalyzer.Edge.Models.VideoPublishingOptions VideoPublishingOptions { get { throw null; } set { } }
    }
}
