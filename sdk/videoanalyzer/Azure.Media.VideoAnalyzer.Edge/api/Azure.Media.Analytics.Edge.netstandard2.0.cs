namespace Azure.Media.Analytics.Edge.Models
{
    public partial class ItemNonSetRequestBase : Azure.Media.Analytics.Edge.Models.MethodRequest
    {
        public ItemNonSetRequestBase(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class MediaGraphAssetSink : Azure.Media.Analytics.Edge.Models.MediaGraphSink
    {
        public MediaGraphAssetSink(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs, string assetNamePattern, string localMediaCachePath, string localMediaCacheMaximumSizeMiB) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput>)) { }
        public string AssetNamePattern { get { throw null; } set { } }
        public string LocalMediaCacheMaximumSizeMiB { get { throw null; } set { } }
        public string LocalMediaCachePath { get { throw null; } set { } }
        public string SegmentLength { get { throw null; } set { } }
    }
    public partial class MediaGraphCertificateSource
    {
        public MediaGraphCertificateSource() { }
    }
    public partial class MediaGraphCognitiveServicesVisionExtension : Azure.Media.Analytics.Edge.Models.MediaGraphExtensionProcessorBase
    {
        public MediaGraphCognitiveServicesVisionExtension(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs, Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint endpoint, Azure.Media.Analytics.Edge.Models.MediaGraphImage image) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput>), default(Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint), default(Azure.Media.Analytics.Edge.Models.MediaGraphImage)) { }
    }
    public partial class MediaGraphCredentials
    {
        public MediaGraphCredentials() { }
    }
    public partial class MediaGraphEndpoint
    {
        public MediaGraphEndpoint(string url) { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphCredentials Credentials { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
    }
    public partial class MediaGraphExtensionProcessorBase : Azure.Media.Analytics.Edge.Models.MediaGraphProcessor
    {
        public MediaGraphExtensionProcessorBase(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs, Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint endpoint, Azure.Media.Analytics.Edge.Models.MediaGraphImage image) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput>)) { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint Endpoint { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphImage Image { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphSamplingOptions SamplingOptions { get { throw null; } set { } }
    }
    public partial class MediaGraphFileSink : Azure.Media.Analytics.Edge.Models.MediaGraphSink
    {
        public MediaGraphFileSink(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs, string baseDirectoryPath, string fileNamePattern, string maximumSizeMiB) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput>)) { }
        public string BaseDirectoryPath { get { throw null; } set { } }
        public string FileNamePattern { get { throw null; } set { } }
        public string MaximumSizeMiB { get { throw null; } set { } }
    }
    public partial class MediaGraphGrpcExtension : Azure.Media.Analytics.Edge.Models.MediaGraphExtensionProcessorBase
    {
        public MediaGraphGrpcExtension(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs, Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint endpoint, Azure.Media.Analytics.Edge.Models.MediaGraphImage image, Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransfer dataTransfer) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput>), default(Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint), default(Azure.Media.Analytics.Edge.Models.MediaGraphImage)) { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransfer DataTransfer { get { throw null; } set { } }
        public string ExtensionConfiguration { get { throw null; } set { } }
    }
    public partial class MediaGraphGrpcExtensionDataTransfer
    {
        public MediaGraphGrpcExtensionDataTransfer(Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode mode) { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode Mode { get { throw null; } set { } }
        public string SharedMemorySizeMiB { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaGraphGrpcExtensionDataTransferMode : System.IEquatable<Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaGraphGrpcExtensionDataTransferMode(string value) { throw null; }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode Embedded { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode SharedMemory { get { throw null; } }
        public bool Equals(Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode left, Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode right) { throw null; }
        public static implicit operator Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode (string value) { throw null; }
        public static bool operator !=(Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode left, Azure.Media.Analytics.Edge.Models.MediaGraphGrpcExtensionDataTransferMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaGraphHttpExtension : Azure.Media.Analytics.Edge.Models.MediaGraphExtensionProcessorBase
    {
        public MediaGraphHttpExtension(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs, Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint endpoint, Azure.Media.Analytics.Edge.Models.MediaGraphImage image) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput>), default(Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint), default(Azure.Media.Analytics.Edge.Models.MediaGraphImage)) { }
    }
    public partial class MediaGraphHttpHeaderCredentials : Azure.Media.Analytics.Edge.Models.MediaGraphCredentials
    {
        public MediaGraphHttpHeaderCredentials(string headerName, string headerValue) { }
        public string HeaderName { get { throw null; } set { } }
        public string HeaderValue { get { throw null; } set { } }
    }
    public partial class MediaGraphImage
    {
        public MediaGraphImage() { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphImageFormat Format { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphImageScale Scale { get { throw null; } set { } }
    }
    public partial class MediaGraphImageFormat
    {
        public MediaGraphImageFormat() { }
    }
    public partial class MediaGraphImageFormatBmp : Azure.Media.Analytics.Edge.Models.MediaGraphImageFormat
    {
        public MediaGraphImageFormatBmp() { }
    }
    public partial class MediaGraphImageFormatJpeg : Azure.Media.Analytics.Edge.Models.MediaGraphImageFormat
    {
        public MediaGraphImageFormatJpeg() { }
        public string Quality { get { throw null; } set { } }
    }
    public partial class MediaGraphImageFormatPng : Azure.Media.Analytics.Edge.Models.MediaGraphImageFormat
    {
        public MediaGraphImageFormatPng() { }
    }
    public partial class MediaGraphImageFormatRaw : Azure.Media.Analytics.Edge.Models.MediaGraphImageFormat
    {
        public MediaGraphImageFormatRaw(Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat pixelFormat) { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat PixelFormat { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaGraphImageFormatRawPixelFormat : System.IEquatable<Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaGraphImageFormatRawPixelFormat(string value) { throw null; }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Abgr { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Argb { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Bgr24 { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Bgra { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Rgb24 { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Rgb555Be { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Rgb555Le { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Rgb565Be { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Rgb565Le { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Rgba { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat Yuv420P { get { throw null; } }
        public bool Equals(Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat left, Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat right) { throw null; }
        public static implicit operator Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat (string value) { throw null; }
        public static bool operator !=(Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat left, Azure.Media.Analytics.Edge.Models.MediaGraphImageFormatRawPixelFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaGraphImageScale
    {
        public MediaGraphImageScale() { }
        public string Height { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode? Mode { get { throw null; } set { } }
        public string Width { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaGraphImageScaleMode : System.IEquatable<Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaGraphImageScaleMode(string value) { throw null; }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode Pad { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode PreserveAspectRatio { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode Stretch { get { throw null; } }
        public bool Equals(Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode left, Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode right) { throw null; }
        public static implicit operator Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode (string value) { throw null; }
        public static bool operator !=(Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode left, Azure.Media.Analytics.Edge.Models.MediaGraphImageScaleMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaGraphInstance
    {
        public MediaGraphInstance(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphInstanceProperties Properties { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphSystemData SystemData { get { throw null; } set { } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphInstance Deserialize(string json) { throw null; }
    }
    public partial class MediaGraphInstanceActivateRequest : Azure.Media.Analytics.Edge.Models.ItemNonSetRequestBase
    {
        public MediaGraphInstanceActivateRequest(string name) : base (default(string)) { }
    }
    public partial class MediaGraphInstanceCollection
    {
        public MediaGraphInstanceCollection() { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.Analytics.Edge.Models.MediaGraphInstance> Value { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphInstanceCollection Deserialize(string json) { throw null; }
    }
    public partial class MediaGraphInstanceDeActivateRequest : Azure.Media.Analytics.Edge.Models.ItemNonSetRequestBase
    {
        public MediaGraphInstanceDeActivateRequest(string name) : base (default(string)) { }
    }
    public partial class MediaGraphInstanceDeleteRequest : Azure.Media.Analytics.Edge.Models.ItemNonSetRequestBase
    {
        public MediaGraphInstanceDeleteRequest(string name) : base (default(string)) { }
    }
    public partial class MediaGraphInstanceGetRequest : Azure.Media.Analytics.Edge.Models.ItemNonSetRequestBase
    {
        public MediaGraphInstanceGetRequest(string name) : base (default(string)) { }
    }
    public partial class MediaGraphInstanceListRequest : Azure.Media.Analytics.Edge.Models.MethodRequest
    {
        public MediaGraphInstanceListRequest() { }
    }
    public partial class MediaGraphInstanceProperties
    {
        public MediaGraphInstanceProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.Analytics.Edge.Models.MediaGraphParameterDefinition> Parameters { get { throw null; } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState? State { get { throw null; } set { } }
        public string TopologyName { get { throw null; } set { } }
    }
    public partial class MediaGraphInstanceSetRequest : Azure.Media.Analytics.Edge.Models.MethodRequest
    {
        public MediaGraphInstanceSetRequest(Azure.Media.Analytics.Edge.Models.MediaGraphInstance instance) { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphInstance Instance { get { throw null; } set { } }
        public override string GetPayloadAsJson() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaGraphInstanceState : System.IEquatable<Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaGraphInstanceState(string value) { throw null; }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState Activating { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState Active { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState Deactivating { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState Inactive { get { throw null; } }
        public bool Equals(Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState left, Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState right) { throw null; }
        public static implicit operator Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState left, Azure.Media.Analytics.Edge.Models.MediaGraphInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaGraphIoTHubMessageSink : Azure.Media.Analytics.Edge.Models.MediaGraphSink
    {
        public MediaGraphIoTHubMessageSink(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs, string hubOutputName) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput>)) { }
        public string HubOutputName { get { throw null; } set { } }
    }
    public partial class MediaGraphIoTHubMessageSource : Azure.Media.Analytics.Edge.Models.MediaGraphSource
    {
        public MediaGraphIoTHubMessageSource(string name) : base (default(string)) { }
        public string HubInputName { get { throw null; } set { } }
    }
    public partial class MediaGraphMotionDetectionProcessor : Azure.Media.Analytics.Edge.Models.MediaGraphProcessor
    {
        public MediaGraphMotionDetectionProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput>)) { }
        public string EventAggregationWindow { get { throw null; } set { } }
        public bool? OutputMotionRegion { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity? Sensitivity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaGraphMotionDetectionSensitivity : System.IEquatable<Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaGraphMotionDetectionSensitivity(string value) { throw null; }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity High { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity Low { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity Medium { get { throw null; } }
        public bool Equals(Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity left, Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity right) { throw null; }
        public static implicit operator Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity (string value) { throw null; }
        public static bool operator !=(Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity left, Azure.Media.Analytics.Edge.Models.MediaGraphMotionDetectionSensitivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaGraphNodeInput
    {
        public MediaGraphNodeInput(string nodeName) { }
        public string NodeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelector> OutputSelectors { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput FromNodeName(string nodeName) { throw null; }
        public static implicit operator Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput (string nodeName) { throw null; }
    }
    public partial class MediaGraphOutputSelector
    {
        public MediaGraphOutputSelector() { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorOperator? Operator { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorProperty? Property { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaGraphOutputSelectorOperator : System.IEquatable<Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaGraphOutputSelectorOperator(string value) { throw null; }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorOperator Is { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorOperator IsNot { get { throw null; } }
        public bool Equals(Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorOperator left, Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorOperator right) { throw null; }
        public static implicit operator Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorOperator (string value) { throw null; }
        public static bool operator !=(Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorOperator left, Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaGraphOutputSelectorProperty : System.IEquatable<Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorProperty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaGraphOutputSelectorProperty(string value) { throw null; }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorProperty MediaType { get { throw null; } }
        public bool Equals(Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorProperty other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorProperty left, Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorProperty right) { throw null; }
        public static implicit operator Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorProperty (string value) { throw null; }
        public static bool operator !=(Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorProperty left, Azure.Media.Analytics.Edge.Models.MediaGraphOutputSelectorProperty right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaGraphParameterDeclaration
    {
        public MediaGraphParameterDeclaration(string name, Azure.Media.Analytics.Edge.Models.MediaGraphParameterType type) { }
        public string Default { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphParameterType Type { get { throw null; } set { } }
    }
    public partial class MediaGraphParameterDefinition
    {
        public MediaGraphParameterDefinition(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaGraphParameterType : System.IEquatable<Azure.Media.Analytics.Edge.Models.MediaGraphParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaGraphParameterType(string value) { throw null; }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphParameterType Bool { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphParameterType Double { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphParameterType Int { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphParameterType SecretString { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphParameterType String { get { throw null; } }
        public bool Equals(Azure.Media.Analytics.Edge.Models.MediaGraphParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.Analytics.Edge.Models.MediaGraphParameterType left, Azure.Media.Analytics.Edge.Models.MediaGraphParameterType right) { throw null; }
        public static implicit operator Azure.Media.Analytics.Edge.Models.MediaGraphParameterType (string value) { throw null; }
        public static bool operator !=(Azure.Media.Analytics.Edge.Models.MediaGraphParameterType left, Azure.Media.Analytics.Edge.Models.MediaGraphParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaGraphPemCertificateList : Azure.Media.Analytics.Edge.Models.MediaGraphCertificateSource
    {
        public MediaGraphPemCertificateList(System.Collections.Generic.IEnumerable<string> certificates) { }
        public MediaGraphPemCertificateList(System.Collections.Generic.IList<System.Security.Cryptography.X509Certificates.X509Certificate2> certificates) { }
        public MediaGraphPemCertificateList(params System.Security.Cryptography.X509Certificates.X509Certificate2[] certificates) { }
        public System.Collections.Generic.IList<string> Certificates { get { throw null; } }
    }
    public partial class MediaGraphProcessor
    {
        public MediaGraphProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs) { }
        public System.Collections.Generic.IList<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> Inputs { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MediaGraphRtspSource : Azure.Media.Analytics.Edge.Models.MediaGraphSource
    {
        public MediaGraphRtspSource(string name, Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint endpoint) : base (default(string)) { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint Endpoint { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphRtspTransport? Transport { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaGraphRtspTransport : System.IEquatable<Azure.Media.Analytics.Edge.Models.MediaGraphRtspTransport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaGraphRtspTransport(string value) { throw null; }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphRtspTransport Http { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphRtspTransport Tcp { get { throw null; } }
        public bool Equals(Azure.Media.Analytics.Edge.Models.MediaGraphRtspTransport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Media.Analytics.Edge.Models.MediaGraphRtspTransport left, Azure.Media.Analytics.Edge.Models.MediaGraphRtspTransport right) { throw null; }
        public static implicit operator Azure.Media.Analytics.Edge.Models.MediaGraphRtspTransport (string value) { throw null; }
        public static bool operator !=(Azure.Media.Analytics.Edge.Models.MediaGraphRtspTransport left, Azure.Media.Analytics.Edge.Models.MediaGraphRtspTransport right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaGraphSamplingOptions
    {
        public MediaGraphSamplingOptions() { }
        public string MaximumSamplesPerSecond { get { throw null; } set { } }
        public string SkipSamplesWithoutAnnotation { get { throw null; } set { } }
    }
    public partial class MediaGraphSignalGateProcessor : Azure.Media.Analytics.Edge.Models.MediaGraphProcessor
    {
        public MediaGraphSignalGateProcessor(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs) : base (default(string), default(System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput>)) { }
        public string ActivationEvaluationWindow { get { throw null; } set { } }
        public string ActivationSignalOffset { get { throw null; } set { } }
        public string MaximumActivationTime { get { throw null; } set { } }
        public string MinimumActivationTime { get { throw null; } set { } }
    }
    public partial class MediaGraphSink
    {
        public MediaGraphSink(string name, System.Collections.Generic.IEnumerable<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> inputs) { }
        public System.Collections.Generic.IList<Azure.Media.Analytics.Edge.Models.MediaGraphNodeInput> Inputs { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MediaGraphSource
    {
        public MediaGraphSource(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class MediaGraphSystemData
    {
        public MediaGraphSystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } set { } }
    }
    public partial class MediaGraphTlsEndpoint : Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint
    {
        public MediaGraphTlsEndpoint(string url) : base (default(string)) { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphCertificateSource TrustedCertificates { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphTlsValidationOptions ValidationOptions { get { throw null; } set { } }
    }
    public partial class MediaGraphTlsValidationOptions
    {
        public MediaGraphTlsValidationOptions() { }
        public string IgnoreHostname { get { throw null; } set { } }
        public string IgnoreSignature { get { throw null; } set { } }
    }
    public partial class MediaGraphTopology
    {
        public MediaGraphTopology(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphTopologyProperties Properties { get { throw null; } set { } }
        public Azure.Media.Analytics.Edge.Models.MediaGraphSystemData SystemData { get { throw null; } set { } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphTopology Deserialize(string json) { throw null; }
    }
    public partial class MediaGraphTopologyCollection
    {
        public MediaGraphTopologyCollection() { }
        public string ContinuationToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.Analytics.Edge.Models.MediaGraphTopology> Value { get { throw null; } }
        public static Azure.Media.Analytics.Edge.Models.MediaGraphTopologyCollection Deserialize(string json) { throw null; }
    }
    public partial class MediaGraphTopologyDeleteRequest : Azure.Media.Analytics.Edge.Models.ItemNonSetRequestBase
    {
        public MediaGraphTopologyDeleteRequest(string name) : base (default(string)) { }
    }
    public partial class MediaGraphTopologyGetRequest : Azure.Media.Analytics.Edge.Models.ItemNonSetRequestBase
    {
        public MediaGraphTopologyGetRequest(string name) : base (default(string)) { }
    }
    public partial class MediaGraphTopologyListRequest : Azure.Media.Analytics.Edge.Models.MethodRequest
    {
        public MediaGraphTopologyListRequest() { }
    }
    public partial class MediaGraphTopologyProperties
    {
        public MediaGraphTopologyProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Media.Analytics.Edge.Models.MediaGraphParameterDeclaration> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Media.Analytics.Edge.Models.MediaGraphProcessor> Processors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Media.Analytics.Edge.Models.MediaGraphSink> Sinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Media.Analytics.Edge.Models.MediaGraphSource> Sources { get { throw null; } }
    }
    public partial class MediaGraphTopologySetRequest : Azure.Media.Analytics.Edge.Models.MethodRequest
    {
        public MediaGraphTopologySetRequest(Azure.Media.Analytics.Edge.Models.MediaGraphTopology graph) { }
        public Azure.Media.Analytics.Edge.Models.MediaGraphTopology Graph { get { throw null; } set { } }
        public override string GetPayloadAsJson() { throw null; }
    }
    public partial class MediaGraphUnsecuredEndpoint : Azure.Media.Analytics.Edge.Models.MediaGraphEndpoint
    {
        public MediaGraphUnsecuredEndpoint(string url) : base (default(string)) { }
    }
    public partial class MediaGraphUsernamePasswordCredentials : Azure.Media.Analytics.Edge.Models.MediaGraphCredentials
    {
        public MediaGraphUsernamePasswordCredentials(string username, string password) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class MethodRequest
    {
        public MethodRequest() { }
        public string ApiVersion { get { throw null; } set { } }
        public string MethodName { get { throw null; } set { } }
        public virtual string GetPayloadAsJson() { throw null; }
    }
}
