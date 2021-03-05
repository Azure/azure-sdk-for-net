namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    public partial class AssetConversionConfiguration
    {
        internal AssetConversionConfiguration() { }
        public System.Numerics.Vector3? AssetDimensions { get { throw null; } }
        public System.Numerics.Vector3? BoundingBoxCenter { get { throw null; } }
        public System.Numerics.Vector3 Gravity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.MixedReality.ObjectAnchors.Conversion.TrajectoryPose> GroundTruthTrajectoryCameraPoses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> KeyFrameIndexes { get { throw null; } }
        public System.Numerics.Quaternion? PrincipalAxis { get { throw null; } }
        public float Scale { get { throw null; } }
        public System.Numerics.Vector4? SupportingPlane { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.MixedReality.ObjectAnchors.Conversion.TrajectoryPose> TestTrajectoryCameraPoses { get { throw null; } }
    }
    public partial class AssetConversionOperation : Azure.Operation<Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionProperties>
    {
        public AssetConversionOperation(System.Guid jobId, Azure.MixedReality.ObjectAnchors.Conversion.ObjectAnchorsConversionClient objectAnchorsConversionClient) { }
        public override bool HasCompleted { get { throw null; } }
        public bool HasCompletedSuccessfully { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionProperties Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionProperties>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionProperties>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class AssetConversionOptions
    {
        public AssetConversionOptions(System.Uri inputAssetUri, Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType inputAssetFileType, System.Numerics.Vector3 assetGravity, Azure.MixedReality.ObjectAnchors.Conversion.AssetLengthUnit unit) { }
        public AssetConversionOptions(System.Uri inputAssetUri, Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType inputAssetFileType, System.Numerics.Vector3 assetGravity, float assetScale) { }
        public System.Numerics.Vector3 Gravity { get { throw null; } }
        public Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType InputAssetFileType { get { throw null; } }
        public System.Uri InputAssetUri { get { throw null; } }
        public System.Guid JobId { get { throw null; } set { } }
        public float Scale { get { throw null; } }
    }
    public partial class AssetConversionProperties
    {
        internal AssetConversionProperties() { }
        public System.Guid AccountId { get { throw null; } set { } }
        public string ClientErrorDetails { get { throw null; } }
        public Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionConfiguration ConversionConfiguration { get { throw null; } }
        public Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionStatus? ConversionStatus { get { throw null; } }
        public Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType InputAssetFileType { get { throw null; } }
        public System.Uri InputAssetUri { get { throw null; } }
        public System.Guid JobId { get { throw null; } set { } }
        public System.Uri OutputModelUri { get { throw null; } }
        public string ServerErrorDetails { get { throw null; } }
    }
    public enum AssetConversionStatus
    {
        NotStarted = 0,
        Running = 1,
        Succeeded = 2,
        Failed = 3,
        Cancelled = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetFileType : System.IEquatable<Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetFileType(string value) { throw null; }
        public static Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType Fbx { get { throw null; } }
        public static Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType Glb { get { throw null; } }
        public static Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType Gltf { get { throw null; } }
        public static Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType Obj { get { throw null; } }
        public static Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType Ply { get { throw null; } }
        public bool Equals(Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public static Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType FromFilePath(string assetFilePath) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType left, Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType right) { throw null; }
        public static bool operator !=(Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType left, Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum AssetLengthUnit
    {
        Meters = 0,
        Centimeters = 1,
        Decimeters = 2,
        Feet = 3,
        Inches = 4,
        Kilometers = 5,
        Millimeters = 6,
        Yards = 7,
    }
    public partial class AssetUploadUriResult
    {
        internal AssetUploadUriResult() { }
        public System.Uri UploadUri { get { throw null; } }
    }
    public partial class ObjectAnchorsConversionClient
    {
        protected ObjectAnchorsConversionClient() { }
        public ObjectAnchorsConversionClient(System.Guid accountId, string accountDomain, Azure.AzureKeyCredential keyCredential) { }
        public ObjectAnchorsConversionClient(System.Guid accountId, string accountDomain, Azure.AzureKeyCredential keyCredential, Azure.MixedReality.ObjectAnchors.Conversion.ObjectAnchorsConversionClientOptions options) { }
        public ObjectAnchorsConversionClient(System.Guid accountId, string accountDomain, Azure.Core.AccessToken token, Azure.MixedReality.ObjectAnchors.Conversion.ObjectAnchorsConversionClientOptions options = null) { }
        public ObjectAnchorsConversionClient(System.Guid accountId, string accountDomain, Azure.Core.TokenCredential credential, Azure.MixedReality.ObjectAnchors.Conversion.ObjectAnchorsConversionClientOptions options = null) { }
        public string AccountDomain { get { throw null; } }
        public System.Guid AccountId { get { throw null; } }
        public virtual Azure.Response<Azure.MixedReality.ObjectAnchors.Conversion.AssetUploadUriResult> GetAssetUploadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.MixedReality.ObjectAnchors.Conversion.AssetUploadUriResult>> GetAssetUploadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionOperation StartAssetConversion(Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionOperation> StartAssetConversionAsync(Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ObjectAnchorsConversionClientOptions : Azure.Core.ClientOptions
    {
        public ObjectAnchorsConversionClientOptions(Azure.MixedReality.ObjectAnchors.Conversion.ObjectAnchorsConversionClientOptions.ServiceVersion version = Azure.MixedReality.ObjectAnchors.Conversion.ObjectAnchorsConversionClientOptions.ServiceVersion.V0_2_preview_0) { }
        public System.Uri MixedRealityAuthenticationEndpoint { get { throw null; } set { } }
        public Azure.MixedReality.Authentication.MixedRealityStsClientOptions MixedRealityAuthenticationOptions { get { throw null; } set { } }
        public System.Uri ServiceEndpoint { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V0_2_preview_0 = 1,
        }
    }
    public static partial class ObjectAnchorsConversionModelFactory
    {
        public static Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionConfiguration AssetConversionConfiguration(System.Numerics.Vector3 assetDimensions, System.Numerics.Vector3 boundingBoxCenter, System.Numerics.Vector3 gravity, System.Collections.Generic.IReadOnlyList<int> keyFrameIndexes, System.Collections.Generic.IReadOnlyList<Azure.MixedReality.ObjectAnchors.Conversion.TrajectoryPose> groundTruthTrajectoryCameraPoses, System.Numerics.Quaternion principalAxis, float scale, System.Numerics.Vector4 supportingPlane, System.Collections.Generic.IReadOnlyList<Azure.MixedReality.ObjectAnchors.Conversion.TrajectoryPose> testTrajectoryCameraPoses) { throw null; }
        public static Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionProperties AssetConversionProperties(string clientErrorDetails, string serverErrorDetails, System.Guid? jobId, System.Uri outputModelUri, Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionStatus? assetConversionStatus, Azure.MixedReality.ObjectAnchors.Conversion.AssetFileType assetFileType, System.Uri uploadedInputAssetUri, System.Guid? accountId, Azure.MixedReality.ObjectAnchors.Conversion.AssetConversionConfiguration assetConversionConfiguration) { throw null; }
        public static Azure.MixedReality.ObjectAnchors.Conversion.AssetUploadUriResult GetAssetUploadUriResult(System.Uri uploadedInputAssetUri) { throw null; }
        public static Azure.MixedReality.ObjectAnchors.Conversion.TrajectoryPose TrajectoryPose(System.Numerics.Quaternion rotation, System.Numerics.Vector3 translation) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrajectoryPose : System.IEquatable<Azure.MixedReality.ObjectAnchors.Conversion.TrajectoryPose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public System.Numerics.Quaternion Rotation { get { throw null; } }
        public System.Numerics.Vector3 Translation { get { throw null; } }
        public bool Equals(Azure.MixedReality.ObjectAnchors.Conversion.TrajectoryPose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
    }
}
