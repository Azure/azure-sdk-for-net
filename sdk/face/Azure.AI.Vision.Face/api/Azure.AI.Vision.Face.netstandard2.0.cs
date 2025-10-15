namespace Azure.AI.Vision.Face
{
    public partial class AbuseMonitoringResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.AbuseMonitoringResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AbuseMonitoringResult>
    {
        internal AbuseMonitoringResult() { }
        public bool IsAbuseDetected { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.OtherFlaggedSessions> OtherFlaggedSessions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.AbuseMonitoringResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.AbuseMonitoringResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.AbuseMonitoringResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.AbuseMonitoringResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AbuseMonitoringResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AbuseMonitoringResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AbuseMonitoringResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessoryItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.AccessoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AccessoryItem>
    {
        internal AccessoryItem() { }
        public float Confidence { get { throw null; } }
        public Azure.AI.Vision.Face.AccessoryType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.AccessoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.AccessoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.AccessoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.AccessoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AccessoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AccessoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AccessoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessoryType : System.IEquatable<Azure.AI.Vision.Face.AccessoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessoryType(string value) { throw null; }
        public static Azure.AI.Vision.Face.AccessoryType Glasses { get { throw null; } }
        public static Azure.AI.Vision.Face.AccessoryType Headwear { get { throw null; } }
        public static Azure.AI.Vision.Face.AccessoryType Mask { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.AccessoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.AccessoryType left, Azure.AI.Vision.Face.AccessoryType right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.AccessoryType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.AccessoryType left, Azure.AI.Vision.Face.AccessoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AddFaceResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.AddFaceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AddFaceResult>
    {
        internal AddFaceResult() { }
        public System.Guid PersistedFaceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.AddFaceResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.AddFaceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.AddFaceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.AddFaceResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AddFaceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AddFaceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.AddFaceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AIVisionFaceModelFactory
    {
        public static Azure.AI.Vision.Face.AbuseMonitoringResult AbuseMonitoringResult(bool isAbuseDetected = false, System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.OtherFlaggedSessions> otherFlaggedSessions = null) { throw null; }
        public static Azure.AI.Vision.Face.AccessoryItem AccessoryItem(Azure.AI.Vision.Face.AccessoryType type = default(Azure.AI.Vision.Face.AccessoryType), float confidence = 0f) { throw null; }
        public static Azure.AI.Vision.Face.AddFaceResult AddFaceResult(System.Guid persistedFaceId = default(System.Guid)) { throw null; }
        public static Azure.AI.Vision.Face.BlurProperties BlurProperties(Azure.AI.Vision.Face.BlurLevel blurLevel = default(Azure.AI.Vision.Face.BlurLevel), float value = 0f) { throw null; }
        public static Azure.AI.Vision.Face.ClientInformation ClientInformation(string ip = null) { throw null; }
        public static Azure.AI.Vision.Face.CreateLivenessSessionContent CreateLivenessSessionContent(Azure.AI.Vision.Face.LivenessOperationMode livenessOperationMode = default(Azure.AI.Vision.Face.LivenessOperationMode), bool? deviceCorrelationIdSetInClient = default(bool?), bool? enableSessionImage = default(bool?), Azure.AI.Vision.Face.LivenessModel? livenessModelVersion = default(Azure.AI.Vision.Face.LivenessModel?), string deviceCorrelationId = null, int? authTokenTimeToLiveInSeconds = default(int?), int numberOfClientAttemptsAllowed = 0, string userCorrelationId = null, bool? userCorrelationIdSetInClient = default(bool?), string expectedClientIpAddress = null) { throw null; }
        public static Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent CreateLivenessWithVerifySessionContent(Azure.AI.Vision.Face.LivenessOperationMode livenessOperationMode = default(Azure.AI.Vision.Face.LivenessOperationMode), bool? deviceCorrelationIdSetInClient = default(bool?), bool? enableSessionImage = default(bool?), Azure.AI.Vision.Face.LivenessModel? livenessModelVersion = default(Azure.AI.Vision.Face.LivenessModel?), bool? returnVerifyImageHash = default(bool?), float? verifyConfidenceThreshold = default(float?), System.IO.Stream verifyImage = null, string deviceCorrelationId = null, int? authTokenTimeToLiveInSeconds = default(int?), int? numberOfClientAttemptsAllowed = default(int?)) { throw null; }
        public static Azure.AI.Vision.Face.CreatePersonResult CreatePersonResult(System.Guid personId = default(System.Guid)) { throw null; }
        public static Azure.AI.Vision.Face.ExposureProperties ExposureProperties(Azure.AI.Vision.Face.ExposureLevel exposureLevel = default(Azure.AI.Vision.Face.ExposureLevel), float value = 0f) { throw null; }
        public static Azure.AI.Vision.Face.FaceAttributes FaceAttributes(float? age = default(float?), float? smile = default(float?), Azure.AI.Vision.Face.FacialHair facialHair = null, Azure.AI.Vision.Face.GlassesType? glasses = default(Azure.AI.Vision.Face.GlassesType?), Azure.AI.Vision.Face.HeadPose headPose = null, Azure.AI.Vision.Face.HairProperties hair = null, Azure.AI.Vision.Face.OcclusionProperties occlusion = null, System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.AccessoryItem> accessories = null, Azure.AI.Vision.Face.BlurProperties blur = null, Azure.AI.Vision.Face.ExposureProperties exposure = null, Azure.AI.Vision.Face.NoiseProperties noise = null, Azure.AI.Vision.Face.MaskProperties mask = null, Azure.AI.Vision.Face.QualityForRecognition? qualityForRecognition = default(Azure.AI.Vision.Face.QualityForRecognition?)) { throw null; }
        public static Azure.AI.Vision.Face.FaceDetectionResult FaceDetectionResult(System.Guid? faceId = default(System.Guid?), Azure.AI.Vision.Face.FaceRecognitionModel? recognitionModel = default(Azure.AI.Vision.Face.FaceRecognitionModel?), Azure.AI.Vision.Face.FaceRectangle faceRectangle = null, Azure.AI.Vision.Face.FaceLandmarks faceLandmarks = null, Azure.AI.Vision.Face.FaceAttributes faceAttributes = null) { throw null; }
        public static Azure.AI.Vision.Face.FaceFindSimilarResult FaceFindSimilarResult(float confidence = 0f, System.Guid? faceId = default(System.Guid?), System.Guid? persistedFaceId = default(System.Guid?)) { throw null; }
        public static Azure.AI.Vision.Face.FaceGroupingResult FaceGroupingResult(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.Guid>> groups = null, System.Collections.Generic.IEnumerable<System.Guid> messyGroup = null) { throw null; }
        public static Azure.AI.Vision.Face.FaceIdentificationCandidate FaceIdentificationCandidate(System.Guid personId = default(System.Guid), float confidence = 0f) { throw null; }
        public static Azure.AI.Vision.Face.FaceIdentificationResult FaceIdentificationResult(System.Guid faceId = default(System.Guid), System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.FaceIdentificationCandidate> candidates = null) { throw null; }
        public static Azure.AI.Vision.Face.FaceLandmarks FaceLandmarks(Azure.AI.Vision.Face.LandmarkCoordinate pupilLeft = null, Azure.AI.Vision.Face.LandmarkCoordinate pupilRight = null, Azure.AI.Vision.Face.LandmarkCoordinate noseTip = null, Azure.AI.Vision.Face.LandmarkCoordinate mouthLeft = null, Azure.AI.Vision.Face.LandmarkCoordinate mouthRight = null, Azure.AI.Vision.Face.LandmarkCoordinate eyebrowLeftOuter = null, Azure.AI.Vision.Face.LandmarkCoordinate eyebrowLeftInner = null, Azure.AI.Vision.Face.LandmarkCoordinate eyeLeftOuter = null, Azure.AI.Vision.Face.LandmarkCoordinate eyeLeftTop = null, Azure.AI.Vision.Face.LandmarkCoordinate eyeLeftBottom = null, Azure.AI.Vision.Face.LandmarkCoordinate eyeLeftInner = null, Azure.AI.Vision.Face.LandmarkCoordinate eyebrowRightInner = null, Azure.AI.Vision.Face.LandmarkCoordinate eyebrowRightOuter = null, Azure.AI.Vision.Face.LandmarkCoordinate eyeRightInner = null, Azure.AI.Vision.Face.LandmarkCoordinate eyeRightTop = null, Azure.AI.Vision.Face.LandmarkCoordinate eyeRightBottom = null, Azure.AI.Vision.Face.LandmarkCoordinate eyeRightOuter = null, Azure.AI.Vision.Face.LandmarkCoordinate noseRootLeft = null, Azure.AI.Vision.Face.LandmarkCoordinate noseRootRight = null, Azure.AI.Vision.Face.LandmarkCoordinate noseLeftAlarTop = null, Azure.AI.Vision.Face.LandmarkCoordinate noseRightAlarTop = null, Azure.AI.Vision.Face.LandmarkCoordinate noseLeftAlarOutTip = null, Azure.AI.Vision.Face.LandmarkCoordinate noseRightAlarOutTip = null, Azure.AI.Vision.Face.LandmarkCoordinate upperLipTop = null, Azure.AI.Vision.Face.LandmarkCoordinate upperLipBottom = null, Azure.AI.Vision.Face.LandmarkCoordinate underLipTop = null, Azure.AI.Vision.Face.LandmarkCoordinate underLipBottom = null) { throw null; }
        public static Azure.AI.Vision.Face.FaceRectangle FaceRectangle(int top = 0, int left = 0, int width = 0, int height = 0) { throw null; }
        public static Azure.AI.Vision.Face.FaceTrainingResult FaceTrainingResult(Azure.AI.Vision.Face.FaceOperationStatus status = default(Azure.AI.Vision.Face.FaceOperationStatus), System.DateTimeOffset createdDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastActionDateTime = default(System.DateTimeOffset), System.DateTimeOffset lastSuccessfulTrainingDateTime = default(System.DateTimeOffset), string message = null) { throw null; }
        public static Azure.AI.Vision.Face.FaceVerificationResult FaceVerificationResult(bool isIdentical = false, float confidence = 0f) { throw null; }
        public static Azure.AI.Vision.Face.FacialHair FacialHair(float moustache = 0f, float beard = 0f, float sideburns = 0f) { throw null; }
        public static Azure.AI.Vision.Face.HairColor HairColor(Azure.AI.Vision.Face.HairColorType color = default(Azure.AI.Vision.Face.HairColorType), float confidence = 0f) { throw null; }
        public static Azure.AI.Vision.Face.HairProperties HairProperties(float bald = 0f, bool invisible = false, System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.HairColor> hairColor = null) { throw null; }
        public static Azure.AI.Vision.Face.HeadPose HeadPose(float pitch = 0f, float roll = 0f, float yaw = 0f) { throw null; }
        public static Azure.AI.Vision.Face.LandmarkCoordinate LandmarkCoordinate(float x = 0f, float y = 0f) { throw null; }
        public static Azure.AI.Vision.Face.LargeFaceList LargeFaceList(string name = null, string userData = null, Azure.AI.Vision.Face.FaceRecognitionModel? recognitionModel = default(Azure.AI.Vision.Face.FaceRecognitionModel?), string largeFaceListId = null) { throw null; }
        public static Azure.AI.Vision.Face.LargeFaceListFace LargeFaceListFace(System.Guid persistedFaceId = default(System.Guid), string userData = null) { throw null; }
        public static Azure.AI.Vision.Face.LargePersonGroup LargePersonGroup(string name = null, string userData = null, Azure.AI.Vision.Face.FaceRecognitionModel? recognitionModel = default(Azure.AI.Vision.Face.FaceRecognitionModel?), string largePersonGroupId = null) { throw null; }
        public static Azure.AI.Vision.Face.LargePersonGroupPerson LargePersonGroupPerson(System.Guid personId = default(System.Guid), string name = null, string userData = null, System.Collections.Generic.IEnumerable<System.Guid> persistedFaceIds = null) { throw null; }
        public static Azure.AI.Vision.Face.LargePersonGroupPersonFace LargePersonGroupPersonFace(System.Guid persistedFaceId = default(System.Guid), string userData = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessColorDecisionTarget LivenessColorDecisionTarget(Azure.AI.Vision.Face.FaceRectangle faceRectangle = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessDecisionTargets LivenessDecisionTargets(Azure.AI.Vision.Face.LivenessColorDecisionTarget color = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessError LivenessError(string code = null, string message = null, Azure.AI.Vision.Face.LivenessDecisionTargets targets = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessResult LivenessResult(Azure.AI.Vision.Face.FaceLivenessDecision? livenessDecision = default(Azure.AI.Vision.Face.FaceLivenessDecision?), Azure.AI.Vision.Face.LivenessDecisionTargets targets = null, string digest = null, string sessionImageId = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessSession LivenessSession(string sessionId = null, string authToken = null, Azure.AI.Vision.Face.OperationState status = default(Azure.AI.Vision.Face.OperationState), Azure.AI.Vision.Face.LivenessModel? modelVersion = default(Azure.AI.Vision.Face.LivenessModel?), bool isAbuseMonitoringEnabled = false, string expectedClientIpAddress = null, Azure.AI.Vision.Face.LivenessSessionResults results = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessSessionAttempt LivenessSessionAttempt(int attemptId = 0, Azure.AI.Vision.Face.OperationState attemptStatus = default(Azure.AI.Vision.Face.OperationState), Azure.AI.Vision.Face.LivenessResult result = null, Azure.AI.Vision.Face.LivenessError error = null, System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.ClientInformation> clientInformation = null, Azure.AI.Vision.Face.AbuseMonitoringResult abuseMonitoringResult = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessSessionResults LivenessSessionResults(System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.LivenessSessionAttempt> attempts = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessWithVerifyOutputs LivenessWithVerifyOutputs(float matchConfidence = 0f, bool isIdentical = false) { throw null; }
        public static Azure.AI.Vision.Face.LivenessWithVerifyReference LivenessWithVerifyReference(Azure.AI.Vision.Face.FaceImageType referenceType = default(Azure.AI.Vision.Face.FaceImageType), Azure.AI.Vision.Face.FaceRectangle faceRectangle = null, Azure.AI.Vision.Face.QualityForRecognition qualityForRecognition = default(Azure.AI.Vision.Face.QualityForRecognition)) { throw null; }
        public static Azure.AI.Vision.Face.LivenessWithVerifyResult LivenessWithVerifyResult(Azure.AI.Vision.Face.FaceLivenessDecision? livenessDecision = default(Azure.AI.Vision.Face.FaceLivenessDecision?), Azure.AI.Vision.Face.LivenessDecisionTargets targets = null, string digest = null, string sessionImageId = null, Azure.AI.Vision.Face.LivenessWithVerifyOutputs verifyResult = null, string verifyImageHash = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessWithVerifySession LivenessWithVerifySession(string sessionId = null, string authToken = null, Azure.AI.Vision.Face.OperationState status = default(Azure.AI.Vision.Face.OperationState), Azure.AI.Vision.Face.LivenessModel? modelVersion = default(Azure.AI.Vision.Face.LivenessModel?), bool isAbuseMonitoringEnabled = false, string expectedClientIpAddress = null, Azure.AI.Vision.Face.LivenessWithVerifySessionResults results = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt LivenessWithVerifySessionAttempt(int attemptId = 0, Azure.AI.Vision.Face.OperationState attemptStatus = default(Azure.AI.Vision.Face.OperationState), Azure.AI.Vision.Face.LivenessWithVerifyResult result = null, Azure.AI.Vision.Face.LivenessError error = null, System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.ClientInformation> clientInformation = null, Azure.AI.Vision.Face.AbuseMonitoringResult abuseMonitoringResult = null) { throw null; }
        public static Azure.AI.Vision.Face.LivenessWithVerifySessionResults LivenessWithVerifySessionResults(System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.LivenessWithVerifyReference> verifyReferences = null, System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt> attempts = null) { throw null; }
        public static Azure.AI.Vision.Face.MaskProperties MaskProperties(bool noseAndMouthCovered = false, Azure.AI.Vision.Face.MaskType type = default(Azure.AI.Vision.Face.MaskType)) { throw null; }
        public static Azure.AI.Vision.Face.NoiseProperties NoiseProperties(Azure.AI.Vision.Face.NoiseLevel noiseLevel = default(Azure.AI.Vision.Face.NoiseLevel), float value = 0f) { throw null; }
        public static Azure.AI.Vision.Face.OcclusionProperties OcclusionProperties(bool foreheadOccluded = false, bool eyeOccluded = false, bool mouthOccluded = false) { throw null; }
        public static Azure.AI.Vision.Face.OtherFlaggedSessions OtherFlaggedSessions(int attemptId = 0, string sessionId = null, string sessionImageId = null) { throw null; }
    }
    public partial class AzureAIVisionFaceClientOptions : Azure.Core.ClientOptions
    {
        public AzureAIVisionFaceClientOptions(Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions.ServiceVersion version = Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions.ServiceVersion.V1_3_Preview_1) { }
        public enum ServiceVersion
        {
            V1_1_Preview_1 = 1,
            V1_2_Preview_1 = 2,
            V1_2 = 3,
            V1_3_Preview_1 = 4,
        }
    }
    public partial class AzureAIVisionFaceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIVisionFaceContext() { }
        public static Azure.AI.Vision.Face.AzureAIVisionFaceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlurLevel : System.IEquatable<Azure.AI.Vision.Face.BlurLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlurLevel(string value) { throw null; }
        public static Azure.AI.Vision.Face.BlurLevel High { get { throw null; } }
        public static Azure.AI.Vision.Face.BlurLevel Low { get { throw null; } }
        public static Azure.AI.Vision.Face.BlurLevel Medium { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.BlurLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.BlurLevel left, Azure.AI.Vision.Face.BlurLevel right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.BlurLevel (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.BlurLevel left, Azure.AI.Vision.Face.BlurLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlurProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.BlurProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.BlurProperties>
    {
        internal BlurProperties() { }
        public Azure.AI.Vision.Face.BlurLevel BlurLevel { get { throw null; } }
        public float Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.BlurProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.BlurProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.BlurProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.BlurProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.BlurProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.BlurProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.BlurProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClientInformation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.ClientInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.ClientInformation>
    {
        internal ClientInformation() { }
        public string Ip { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.ClientInformation System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.ClientInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.ClientInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.ClientInformation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.ClientInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.ClientInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.ClientInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateLivenessSessionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.CreateLivenessSessionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreateLivenessSessionContent>
    {
        public CreateLivenessSessionContent(Azure.AI.Vision.Face.LivenessOperationMode livenessOperationMode) { }
        public int? AuthTokenTimeToLiveInSeconds { get { throw null; } set { } }
        public string DeviceCorrelationId { get { throw null; } set { } }
        public bool? DeviceCorrelationIdSetInClient { get { throw null; } set { } }
        public bool? EnableSessionImage { get { throw null; } set { } }
        public string ExpectedClientIpAddress { get { throw null; } set { } }
        public Azure.AI.Vision.Face.LivenessModel? LivenessModelVersion { get { throw null; } set { } }
        public Azure.AI.Vision.Face.LivenessOperationMode LivenessOperationMode { get { throw null; } }
        public int NumberOfClientAttemptsAllowed { get { throw null; } set { } }
        public string UserCorrelationId { get { throw null; } set { } }
        public bool? UserCorrelationIdSetInClient { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.CreateLivenessSessionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.CreateLivenessSessionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.CreateLivenessSessionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.CreateLivenessSessionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreateLivenessSessionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreateLivenessSessionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreateLivenessSessionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateLivenessWithVerifySessionContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent>
    {
        public CreateLivenessWithVerifySessionContent(Azure.AI.Vision.Face.LivenessOperationMode livenessOperationMode, System.IO.Stream verifyImage) { }
        public int? AuthTokenTimeToLiveInSeconds { get { throw null; } set { } }
        public string DeviceCorrelationId { get { throw null; } set { } }
        public bool? DeviceCorrelationIdSetInClient { get { throw null; } set { } }
        public bool? EnableSessionImage { get { throw null; } set { } }
        public Azure.AI.Vision.Face.LivenessModel? LivenessModelVersion { get { throw null; } set { } }
        public Azure.AI.Vision.Face.LivenessOperationMode LivenessOperationMode { get { throw null; } }
        public int? NumberOfClientAttemptsAllowed { get { throw null; } set { } }
        public bool? ReturnVerifyImageHash { get { throw null; } set { } }
        public float? VerifyConfidenceThreshold { get { throw null; } set { } }
        public System.IO.Stream VerifyImage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreatePersonResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.CreatePersonResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreatePersonResult>
    {
        internal CreatePersonResult() { }
        public System.Guid PersonId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.CreatePersonResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.CreatePersonResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.CreatePersonResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.CreatePersonResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreatePersonResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreatePersonResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.CreatePersonResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExposureLevel : System.IEquatable<Azure.AI.Vision.Face.ExposureLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExposureLevel(string value) { throw null; }
        public static Azure.AI.Vision.Face.ExposureLevel GoodExposure { get { throw null; } }
        public static Azure.AI.Vision.Face.ExposureLevel OverExposure { get { throw null; } }
        public static Azure.AI.Vision.Face.ExposureLevel UnderExposure { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.ExposureLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.ExposureLevel left, Azure.AI.Vision.Face.ExposureLevel right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.ExposureLevel (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.ExposureLevel left, Azure.AI.Vision.Face.ExposureLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExposureProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.ExposureProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.ExposureProperties>
    {
        internal ExposureProperties() { }
        public Azure.AI.Vision.Face.ExposureLevel ExposureLevel { get { throw null; } }
        public float Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.ExposureProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.ExposureProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.ExposureProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.ExposureProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.ExposureProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.ExposureProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.ExposureProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FaceAdministrationClient
    {
        protected FaceAdministrationClient() { }
        public FaceAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public FaceAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions options) { }
        public FaceAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public FaceAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Vision.Face.LargeFaceListClient GetLargeFaceListClient(string largeFaceListId) { throw null; }
        public virtual Azure.AI.Vision.Face.LargePersonGroupClient GetLargePersonGroupClient(string largePersonGroupId) { throw null; }
    }
    public partial class FaceAttributes : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceAttributes>
    {
        internal FaceAttributes() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.AccessoryItem> Accessories { get { throw null; } }
        public float? Age { get { throw null; } }
        public Azure.AI.Vision.Face.BlurProperties Blur { get { throw null; } }
        public Azure.AI.Vision.Face.ExposureProperties Exposure { get { throw null; } }
        public Azure.AI.Vision.Face.FacialHair FacialHair { get { throw null; } }
        public Azure.AI.Vision.Face.GlassesType? Glasses { get { throw null; } }
        public Azure.AI.Vision.Face.HairProperties Hair { get { throw null; } }
        public Azure.AI.Vision.Face.HeadPose HeadPose { get { throw null; } }
        public Azure.AI.Vision.Face.MaskProperties Mask { get { throw null; } }
        public Azure.AI.Vision.Face.NoiseProperties Noise { get { throw null; } }
        public Azure.AI.Vision.Face.OcclusionProperties Occlusion { get { throw null; } }
        public Azure.AI.Vision.Face.QualityForRecognition? QualityForRecognition { get { throw null; } }
        public float? Smile { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceAttributes System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceAttributes System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FaceAttributeType : System.IEquatable<Azure.AI.Vision.Face.FaceAttributeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FaceAttributeType(string value) { throw null; }
        public static Azure.AI.Vision.Face.FaceAttributeType Accessories { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType Age { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType Blur { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType Exposure { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType FacialHair { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType Glasses { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType Hair { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType HeadPose { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType Mask { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType Noise { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType Occlusion { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType QualityForRecognition { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceAttributeType Smile { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.FaceAttributeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.FaceAttributeType left, Azure.AI.Vision.Face.FaceAttributeType right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.FaceAttributeType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.FaceAttributeType left, Azure.AI.Vision.Face.FaceAttributeType right) { throw null; }
        public override string ToString() { throw null; }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
        public partial struct Detection01
        {
            public static Azure.AI.Vision.Face.FaceAttributeType Accessories { get { throw null; } }
            public static Azure.AI.Vision.Face.FaceAttributeType Blur { get { throw null; } }
            public static Azure.AI.Vision.Face.FaceAttributeType Exposure { get { throw null; } }
            public static Azure.AI.Vision.Face.FaceAttributeType Glasses { get { throw null; } }
            public static Azure.AI.Vision.Face.FaceAttributeType HeadPose { get { throw null; } }
            public static Azure.AI.Vision.Face.FaceAttributeType Noise { get { throw null; } }
            public static Azure.AI.Vision.Face.FaceAttributeType Occlusion { get { throw null; } }
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
        public partial struct Detection03
        {
            public static Azure.AI.Vision.Face.FaceAttributeType Blur { get { throw null; } }
            public static Azure.AI.Vision.Face.FaceAttributeType HeadPose { get { throw null; } }
            public static Azure.AI.Vision.Face.FaceAttributeType Mask { get { throw null; } }
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
        public partial struct Recognition03
        {
            public static Azure.AI.Vision.Face.FaceAttributeType QualityForRecognition { get { throw null; } }
        }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, Size=1)]
        public partial struct Recognition04
        {
            public static Azure.AI.Vision.Face.FaceAttributeType QualityForRecognition { get { throw null; } }
        }
    }
    public partial class FaceClient
    {
        protected FaceClient() { }
        public FaceClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public FaceClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions options) { }
        public FaceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public FaceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceDetectionResult>> Detect(System.BinaryData imageContent, Azure.AI.Vision.Face.FaceDetectionModel detectionModel, Azure.AI.Vision.Face.FaceRecognitionModel recognitionModel, bool returnFaceId, System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.FaceAttributeType> returnFaceAttributes = null, bool? returnFaceLandmarks = default(bool?), bool? returnRecognitionModel = default(bool?), int? faceIdTimeToLive = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceDetectionResult>> Detect(System.Uri url, Azure.AI.Vision.Face.FaceDetectionModel detectionModel, Azure.AI.Vision.Face.FaceRecognitionModel recognitionModel, bool returnFaceId, System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.FaceAttributeType> returnFaceAttributes = null, bool? returnFaceLandmarks = default(bool?), bool? returnRecognitionModel = default(bool?), int? faceIdTimeToLive = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceDetectionResult>>> DetectAsync(System.BinaryData imageContent, Azure.AI.Vision.Face.FaceDetectionModel detectionModel, Azure.AI.Vision.Face.FaceRecognitionModel recognitionModel, bool returnFaceId, System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.FaceAttributeType> returnFaceAttributes = null, bool? returnFaceLandmarks = default(bool?), bool? returnRecognitionModel = default(bool?), int? faceIdTimeToLive = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceDetectionResult>>> DetectAsync(System.Uri url, Azure.AI.Vision.Face.FaceDetectionModel detectionModel, Azure.AI.Vision.Face.FaceRecognitionModel recognitionModel, bool returnFaceId, System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.FaceAttributeType> returnFaceAttributes = null, bool? returnFaceLandmarks = default(bool?), bool? returnRecognitionModel = default(bool?), int? faceIdTimeToLive = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response FindSimilar(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceFindSimilarResult>> FindSimilar(System.Guid faceId, System.Collections.Generic.IEnumerable<System.Guid> faceIds, int? maxNumOfCandidatesReturned = default(int?), Azure.AI.Vision.Face.FindSimilarMatchMode? mode = default(Azure.AI.Vision.Face.FindSimilarMatchMode?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> FindSimilarAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceFindSimilarResult>>> FindSimilarAsync(System.Guid faceId, System.Collections.Generic.IEnumerable<System.Guid> faceIds, int? maxNumOfCandidatesReturned = default(int?), Azure.AI.Vision.Face.FindSimilarMatchMode? mode = default(Azure.AI.Vision.Face.FindSimilarMatchMode?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response FindSimilarFromLargeFaceList(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceFindSimilarResult>> FindSimilarFromLargeFaceList(System.Guid faceId, string largeFaceListId, int? maxNumOfCandidatesReturned = default(int?), Azure.AI.Vision.Face.FindSimilarMatchMode? mode = default(Azure.AI.Vision.Face.FindSimilarMatchMode?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> FindSimilarFromLargeFaceListAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceFindSimilarResult>>> FindSimilarFromLargeFaceListAsync(System.Guid faceId, string largeFaceListId, int? maxNumOfCandidatesReturned = default(int?), Azure.AI.Vision.Face.FindSimilarMatchMode? mode = default(Azure.AI.Vision.Face.FindSimilarMatchMode?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Group(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.FaceGroupingResult> Group(System.Collections.Generic.IEnumerable<System.Guid> faceIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GroupAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.FaceGroupingResult>> GroupAsync(System.Collections.Generic.IEnumerable<System.Guid> faceIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response IdentifyFromLargePersonGroup(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceIdentificationResult>> IdentifyFromLargePersonGroup(System.Collections.Generic.IEnumerable<System.Guid> faceIds, string largePersonGroupId, int? maxNumOfCandidatesReturned = default(int?), float? confidenceThreshold = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> IdentifyFromLargePersonGroupAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceIdentificationResult>>> IdentifyFromLargePersonGroupAsync(System.Collections.Generic.IEnumerable<System.Guid> faceIds, string largePersonGroupId, int? maxNumOfCandidatesReturned = default(int?), float? confidenceThreshold = default(float?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response VerifyFaceToFace(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.FaceVerificationResult> VerifyFaceToFace(System.Guid faceId1, System.Guid faceId2, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> VerifyFaceToFaceAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.FaceVerificationResult>> VerifyFaceToFaceAsync(System.Guid faceId1, System.Guid faceId2, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response VerifyFromLargePersonGroup(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.FaceVerificationResult> VerifyFromLargePersonGroup(System.Guid faceId, string largePersonGroupId, System.Guid personId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> VerifyFromLargePersonGroupAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.FaceVerificationResult>> VerifyFromLargePersonGroupAsync(System.Guid faceId, string largePersonGroupId, System.Guid personId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FaceDetectionModel : System.IEquatable<Azure.AI.Vision.Face.FaceDetectionModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FaceDetectionModel(string value) { throw null; }
        public static Azure.AI.Vision.Face.FaceDetectionModel Detection01 { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceDetectionModel Detection02 { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceDetectionModel Detection03 { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.FaceDetectionModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.FaceDetectionModel left, Azure.AI.Vision.Face.FaceDetectionModel right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.FaceDetectionModel (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.FaceDetectionModel left, Azure.AI.Vision.Face.FaceDetectionModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FaceDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceDetectionResult>
    {
        internal FaceDetectionResult() { }
        public Azure.AI.Vision.Face.FaceAttributes FaceAttributes { get { throw null; } }
        public System.Guid? FaceId { get { throw null; } }
        public Azure.AI.Vision.Face.FaceLandmarks FaceLandmarks { get { throw null; } }
        public Azure.AI.Vision.Face.FaceRectangle FaceRectangle { get { throw null; } }
        public Azure.AI.Vision.Face.FaceRecognitionModel? RecognitionModel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FaceFindSimilarResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceFindSimilarResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceFindSimilarResult>
    {
        internal FaceFindSimilarResult() { }
        public float Confidence { get { throw null; } }
        public System.Guid? FaceId { get { throw null; } }
        public System.Guid? PersistedFaceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceFindSimilarResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceFindSimilarResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceFindSimilarResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceFindSimilarResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceFindSimilarResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceFindSimilarResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceFindSimilarResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FaceGroupingResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceGroupingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceGroupingResult>
    {
        internal FaceGroupingResult() { }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<System.Guid>> Groups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Guid> MessyGroup { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceGroupingResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceGroupingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceGroupingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceGroupingResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceGroupingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceGroupingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceGroupingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FaceIdentificationCandidate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceIdentificationCandidate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceIdentificationCandidate>
    {
        internal FaceIdentificationCandidate() { }
        public float Confidence { get { throw null; } }
        public System.Guid PersonId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceIdentificationCandidate System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceIdentificationCandidate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceIdentificationCandidate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceIdentificationCandidate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceIdentificationCandidate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceIdentificationCandidate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceIdentificationCandidate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FaceIdentificationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceIdentificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceIdentificationResult>
    {
        internal FaceIdentificationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceIdentificationCandidate> Candidates { get { throw null; } }
        public System.Guid FaceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceIdentificationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceIdentificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceIdentificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceIdentificationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceIdentificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceIdentificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceIdentificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FaceImageType : System.IEquatable<Azure.AI.Vision.Face.FaceImageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FaceImageType(string value) { throw null; }
        public static Azure.AI.Vision.Face.FaceImageType Color { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceImageType Depth { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceImageType Infrared { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.FaceImageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.FaceImageType left, Azure.AI.Vision.Face.FaceImageType right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.FaceImageType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.FaceImageType left, Azure.AI.Vision.Face.FaceImageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FaceLandmarks : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceLandmarks>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceLandmarks>
    {
        internal FaceLandmarks() { }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyebrowLeftInner { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyebrowLeftOuter { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyebrowRightInner { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyebrowRightOuter { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyeLeftBottom { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyeLeftInner { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyeLeftOuter { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyeLeftTop { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyeRightBottom { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyeRightInner { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyeRightOuter { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate EyeRightTop { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate MouthLeft { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate MouthRight { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate NoseLeftAlarOutTip { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate NoseLeftAlarTop { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate NoseRightAlarOutTip { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate NoseRightAlarTop { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate NoseRootLeft { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate NoseRootRight { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate NoseTip { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate PupilLeft { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate PupilRight { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate UnderLipBottom { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate UnderLipTop { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate UpperLipBottom { get { throw null; } }
        public Azure.AI.Vision.Face.LandmarkCoordinate UpperLipTop { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceLandmarks System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceLandmarks>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceLandmarks>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceLandmarks System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceLandmarks>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceLandmarks>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceLandmarks>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FaceLivenessDecision : System.IEquatable<Azure.AI.Vision.Face.FaceLivenessDecision>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FaceLivenessDecision(string value) { throw null; }
        public static Azure.AI.Vision.Face.FaceLivenessDecision RealFace { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceLivenessDecision SpoofFace { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceLivenessDecision Uncertain { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.FaceLivenessDecision other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.FaceLivenessDecision left, Azure.AI.Vision.Face.FaceLivenessDecision right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.FaceLivenessDecision (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.FaceLivenessDecision left, Azure.AI.Vision.Face.FaceLivenessDecision right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FaceOperationStatus : System.IEquatable<Azure.AI.Vision.Face.FaceOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FaceOperationStatus(string value) { throw null; }
        public static Azure.AI.Vision.Face.FaceOperationStatus Failed { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceOperationStatus NotStarted { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceOperationStatus Running { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.FaceOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.FaceOperationStatus left, Azure.AI.Vision.Face.FaceOperationStatus right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.FaceOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.FaceOperationStatus left, Azure.AI.Vision.Face.FaceOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FaceRecognitionModel : System.IEquatable<Azure.AI.Vision.Face.FaceRecognitionModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FaceRecognitionModel(string value) { throw null; }
        public static Azure.AI.Vision.Face.FaceRecognitionModel Recognition01 { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceRecognitionModel Recognition02 { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceRecognitionModel Recognition03 { get { throw null; } }
        public static Azure.AI.Vision.Face.FaceRecognitionModel Recognition04 { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.FaceRecognitionModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.FaceRecognitionModel left, Azure.AI.Vision.Face.FaceRecognitionModel right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.FaceRecognitionModel (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.FaceRecognitionModel left, Azure.AI.Vision.Face.FaceRecognitionModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FaceRectangle : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceRectangle>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceRectangle>
    {
        internal FaceRectangle() { }
        public int Height { get { throw null; } }
        public int Left { get { throw null; } }
        public int Top { get { throw null; } }
        public int Width { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceRectangle System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceRectangle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceRectangle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceRectangle System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceRectangle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceRectangle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceRectangle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FaceSessionClient
    {
        protected FaceSessionClient() { }
        public FaceSessionClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public FaceSessionClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions options) { }
        public FaceSessionClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public FaceSessionClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Vision.Face.LivenessSession> CreateLivenessSession(Azure.AI.Vision.Face.CreateLivenessSessionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateLivenessSession(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.LivenessSession>> CreateLivenessSessionAsync(Azure.AI.Vision.Face.CreateLivenessSessionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateLivenessSessionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.LivenessWithVerifySession> CreateLivenessWithVerifySession(Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateLivenessWithVerifySession(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.LivenessWithVerifySession>> CreateLivenessWithVerifySessionAsync(Azure.AI.Vision.Face.CreateLivenessWithVerifySessionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateLivenessWithVerifySessionAsync(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteLivenessSession(string sessionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLivenessSessionAsync(string sessionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteLivenessWithVerifySession(string sessionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteLivenessWithVerifySessionAsync(string sessionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DetectFromSessionImage(Azure.Core.RequestContent content, string detectionModel = null, string recognitionModel = null, bool? returnFaceId = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.FaceAttributeType> returnFaceAttributes = null, bool? returnFaceLandmarks = default(bool?), bool? returnRecognitionModel = default(bool?), int? faceIdTimeToLive = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceDetectionResult>> DetectFromSessionImage(string sessionImageId, Azure.AI.Vision.Face.FaceDetectionModel? detectionModel = default(Azure.AI.Vision.Face.FaceDetectionModel?), Azure.AI.Vision.Face.FaceRecognitionModel? recognitionModel = default(Azure.AI.Vision.Face.FaceRecognitionModel?), bool? returnFaceId = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.FaceAttributeType> returnFaceAttributes = null, bool? returnFaceLandmarks = default(bool?), bool? returnRecognitionModel = default(bool?), int? faceIdTimeToLive = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectFromSessionImageAsync(Azure.Core.RequestContent content, string detectionModel = null, string recognitionModel = null, bool? returnFaceId = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.FaceAttributeType> returnFaceAttributes = null, bool? returnFaceLandmarks = default(bool?), bool? returnRecognitionModel = default(bool?), int? faceIdTimeToLive = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.FaceDetectionResult>>> DetectFromSessionImageAsync(string sessionImageId, Azure.AI.Vision.Face.FaceDetectionModel? detectionModel = default(Azure.AI.Vision.Face.FaceDetectionModel?), Azure.AI.Vision.Face.FaceRecognitionModel? recognitionModel = default(Azure.AI.Vision.Face.FaceRecognitionModel?), bool? returnFaceId = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Vision.Face.FaceAttributeType> returnFaceAttributes = null, bool? returnFaceLandmarks = default(bool?), bool? returnRecognitionModel = default(bool?), int? faceIdTimeToLive = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLivenessSessionResult(string sessionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.LivenessSession> GetLivenessSessionResult(string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLivenessSessionResultAsync(string sessionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.LivenessSession>> GetLivenessSessionResultAsync(string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLivenessWithVerifySessionResult(string sessionId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.LivenessWithVerifySession> GetLivenessWithVerifySessionResult(string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLivenessWithVerifySessionResultAsync(string sessionId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.LivenessWithVerifySession>> GetLivenessWithVerifySessionResultAsync(string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSessionImage(string sessionImageId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetSessionImage(string sessionImageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSessionImageAsync(string sessionImageId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetSessionImageAsync(string sessionImageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FaceTrainingResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceTrainingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceTrainingResult>
    {
        internal FaceTrainingResult() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public System.DateTimeOffset LastActionDateTime { get { throw null; } }
        public System.DateTimeOffset LastSuccessfulTrainingDateTime { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.AI.Vision.Face.FaceOperationStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceTrainingResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceTrainingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceTrainingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceTrainingResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceTrainingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceTrainingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceTrainingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FaceVerificationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceVerificationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceVerificationResult>
    {
        internal FaceVerificationResult() { }
        public float Confidence { get { throw null; } }
        public bool IsIdentical { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceVerificationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceVerificationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FaceVerificationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FaceVerificationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceVerificationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceVerificationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FaceVerificationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacialHair : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FacialHair>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FacialHair>
    {
        internal FacialHair() { }
        public float Beard { get { throw null; } }
        public float Moustache { get { throw null; } }
        public float Sideburns { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FacialHair System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FacialHair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.FacialHair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.FacialHair System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FacialHair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FacialHair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.FacialHair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FindSimilarMatchMode : System.IEquatable<Azure.AI.Vision.Face.FindSimilarMatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FindSimilarMatchMode(string value) { throw null; }
        public static Azure.AI.Vision.Face.FindSimilarMatchMode MatchFace { get { throw null; } }
        public static Azure.AI.Vision.Face.FindSimilarMatchMode MatchPerson { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.FindSimilarMatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.FindSimilarMatchMode left, Azure.AI.Vision.Face.FindSimilarMatchMode right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.FindSimilarMatchMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.FindSimilarMatchMode left, Azure.AI.Vision.Face.FindSimilarMatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GlassesType : System.IEquatable<Azure.AI.Vision.Face.GlassesType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GlassesType(string value) { throw null; }
        public static Azure.AI.Vision.Face.GlassesType NoGlasses { get { throw null; } }
        public static Azure.AI.Vision.Face.GlassesType ReadingGlasses { get { throw null; } }
        public static Azure.AI.Vision.Face.GlassesType Sunglasses { get { throw null; } }
        public static Azure.AI.Vision.Face.GlassesType SwimmingGoggles { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.GlassesType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.GlassesType left, Azure.AI.Vision.Face.GlassesType right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.GlassesType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.GlassesType left, Azure.AI.Vision.Face.GlassesType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HairColor : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.HairColor>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HairColor>
    {
        internal HairColor() { }
        public Azure.AI.Vision.Face.HairColorType Color { get { throw null; } }
        public float Confidence { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.HairColor System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.HairColor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.HairColor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.HairColor System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HairColor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HairColor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HairColor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HairColorType : System.IEquatable<Azure.AI.Vision.Face.HairColorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HairColorType(string value) { throw null; }
        public static Azure.AI.Vision.Face.HairColorType Black { get { throw null; } }
        public static Azure.AI.Vision.Face.HairColorType Blond { get { throw null; } }
        public static Azure.AI.Vision.Face.HairColorType Brown { get { throw null; } }
        public static Azure.AI.Vision.Face.HairColorType Gray { get { throw null; } }
        public static Azure.AI.Vision.Face.HairColorType Other { get { throw null; } }
        public static Azure.AI.Vision.Face.HairColorType Red { get { throw null; } }
        public static Azure.AI.Vision.Face.HairColorType UnknownHairColor { get { throw null; } }
        public static Azure.AI.Vision.Face.HairColorType White { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.HairColorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.HairColorType left, Azure.AI.Vision.Face.HairColorType right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.HairColorType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.HairColorType left, Azure.AI.Vision.Face.HairColorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HairProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.HairProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HairProperties>
    {
        internal HairProperties() { }
        public float Bald { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.HairColor> HairColor { get { throw null; } }
        public bool Invisible { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.HairProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.HairProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.HairProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.HairProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HairProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HairProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HairProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HeadPose : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.HeadPose>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HeadPose>
    {
        internal HeadPose() { }
        public float Pitch { get { throw null; } }
        public float Roll { get { throw null; } }
        public float Yaw { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.HeadPose System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.HeadPose>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.HeadPose>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.HeadPose System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HeadPose>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HeadPose>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.HeadPose>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LandmarkCoordinate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LandmarkCoordinate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LandmarkCoordinate>
    {
        internal LandmarkCoordinate() { }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LandmarkCoordinate System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LandmarkCoordinate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LandmarkCoordinate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LandmarkCoordinate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LandmarkCoordinate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LandmarkCoordinate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LandmarkCoordinate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeFaceList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargeFaceList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargeFaceList>
    {
        internal LargeFaceList() { }
        public string LargeFaceListId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Vision.Face.FaceRecognitionModel? RecognitionModel { get { throw null; } }
        public string UserData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LargeFaceList System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargeFaceList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargeFaceList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LargeFaceList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargeFaceList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargeFaceList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargeFaceList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargeFaceListClient
    {
        protected LargeFaceListClient() { }
        public LargeFaceListClient(System.Uri endpoint, Azure.AzureKeyCredential credential, string largeFaceListId) { }
        public LargeFaceListClient(System.Uri endpoint, Azure.AzureKeyCredential credential, string largeFaceListId, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions options) { }
        public LargeFaceListClient(System.Uri endpoint, Azure.Core.TokenCredential credential, string largeFaceListId) { }
        public LargeFaceListClient(System.Uri endpoint, Azure.Core.TokenCredential credential, string largeFaceListId, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddFace(Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<int> targetFace = null, string detectionModel = null, string userData = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.AddFaceResult> AddFace(System.BinaryData imageContent, System.Collections.Generic.IEnumerable<int> targetFace = null, Azure.AI.Vision.Face.FaceDetectionModel? detectionModel = default(Azure.AI.Vision.Face.FaceDetectionModel?), string userData = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.AddFaceResult> AddFace(System.Uri uri, System.Collections.Generic.IEnumerable<int> targetFace = null, Azure.AI.Vision.Face.FaceDetectionModel? detectionModel = default(Azure.AI.Vision.Face.FaceDetectionModel?), string userData = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddFaceAsync(Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<int> targetFace = null, string detectionModel = null, string userData = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.AddFaceResult>> AddFaceAsync(System.BinaryData imageContent, System.Collections.Generic.IEnumerable<int> targetFace = null, Azure.AI.Vision.Face.FaceDetectionModel? detectionModel = default(Azure.AI.Vision.Face.FaceDetectionModel?), string userData = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.AddFaceResult>> AddFaceAsync(System.Uri uri, System.Collections.Generic.IEnumerable<int> targetFace = null, Azure.AI.Vision.Face.FaceDetectionModel? detectionModel = default(Azure.AI.Vision.Face.FaceDetectionModel?), string userData = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Create(string name, string userData = null, Azure.AI.Vision.Face.FaceRecognitionModel? recognitionModel = default(Azure.AI.Vision.Face.FaceRecognitionModel?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(string name, string userData = null, Azure.AI.Vision.Face.FaceRecognitionModel? recognitionModel = default(Azure.AI.Vision.Face.FaceRecognitionModel?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteFace(System.Guid persistedFaceId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFaceAsync(System.Guid persistedFaceId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetFace(System.Guid persistedFaceId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.LargeFaceListFace> GetFace(System.Guid persistedFaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFaceAsync(System.Guid persistedFaceId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.LargeFaceListFace>> GetFaceAsync(System.Guid persistedFaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFaces(string start, int? top, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LargeFaceListFace>> GetFaces(string start = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFacesAsync(string start, int? top, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LargeFaceListFace>>> GetFacesAsync(string start = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLargeFaceList(bool? returnRecognitionModel, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.LargeFaceList> GetLargeFaceList(bool? returnRecognitionModel = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLargeFaceListAsync(bool? returnRecognitionModel, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.LargeFaceList>> GetLargeFaceListAsync(bool? returnRecognitionModel = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLargeFaceLists(string start, int? top, bool? returnRecognitionModel, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LargeFaceList>> GetLargeFaceLists(string start = null, int? top = default(int?), bool? returnRecognitionModel = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLargeFaceListsAsync(string start, int? top, bool? returnRecognitionModel, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LargeFaceList>>> GetLargeFaceListsAsync(string start = null, int? top = default(int?), bool? returnRecognitionModel = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainingStatus(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.FaceTrainingResult> GetTrainingStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingStatusAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.FaceTrainingResult>> GetTrainingStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Train(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> TrainAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Update(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateFace(System.Guid persistedFaceId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateFaceAsync(System.Guid persistedFaceId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class LargeFaceListFace : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargeFaceListFace>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargeFaceListFace>
    {
        internal LargeFaceListFace() { }
        public System.Guid PersistedFaceId { get { throw null; } }
        public string UserData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LargeFaceListFace System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargeFaceListFace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargeFaceListFace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LargeFaceListFace System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargeFaceListFace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargeFaceListFace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargeFaceListFace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargePersonGroup : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargePersonGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroup>
    {
        internal LargePersonGroup() { }
        public string LargePersonGroupId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Vision.Face.FaceRecognitionModel? RecognitionModel { get { throw null; } }
        public string UserData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LargePersonGroup System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargePersonGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargePersonGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LargePersonGroup System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargePersonGroupClient
    {
        protected LargePersonGroupClient() { }
        public LargePersonGroupClient(System.Uri endpoint, Azure.AzureKeyCredential credential, string largePersonGroupId) { }
        public LargePersonGroupClient(System.Uri endpoint, Azure.AzureKeyCredential credential, string largePersonGroupId, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions options) { }
        public LargePersonGroupClient(System.Uri endpoint, Azure.Core.TokenCredential credential, string largePersonGroupId) { }
        public LargePersonGroupClient(System.Uri endpoint, Azure.Core.TokenCredential credential, string largePersonGroupId, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddFace(System.Guid personId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<int> targetFace = null, string detectionModel = null, string userData = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.AddFaceResult> AddFace(System.Guid personId, System.BinaryData imageContent, System.Collections.Generic.IEnumerable<int> targetFace = null, Azure.AI.Vision.Face.FaceDetectionModel? detectionModel = default(Azure.AI.Vision.Face.FaceDetectionModel?), string userData = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.AddFaceResult> AddFace(System.Guid personId, System.Uri uri, System.Collections.Generic.IEnumerable<int> targetFace = null, Azure.AI.Vision.Face.FaceDetectionModel? detectionModel = default(Azure.AI.Vision.Face.FaceDetectionModel?), string userData = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddFaceAsync(System.Guid personId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<int> targetFace = null, string detectionModel = null, string userData = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.AddFaceResult>> AddFaceAsync(System.Guid personId, System.BinaryData imageContent, System.Collections.Generic.IEnumerable<int> targetFace = null, Azure.AI.Vision.Face.FaceDetectionModel? detectionModel = default(Azure.AI.Vision.Face.FaceDetectionModel?), string userData = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.AddFaceResult>> AddFaceAsync(System.Guid personId, System.Uri uri, System.Collections.Generic.IEnumerable<int> targetFace = null, Azure.AI.Vision.Face.FaceDetectionModel? detectionModel = default(Azure.AI.Vision.Face.FaceDetectionModel?), string userData = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Create(string name, string userData = null, Azure.AI.Vision.Face.FaceRecognitionModel? recognitionModel = default(Azure.AI.Vision.Face.FaceRecognitionModel?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(string name, string userData = null, Azure.AI.Vision.Face.FaceRecognitionModel? recognitionModel = default(Azure.AI.Vision.Face.FaceRecognitionModel?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreatePerson(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.CreatePersonResult> CreatePerson(string name, string userData = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreatePersonAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.CreatePersonResult>> CreatePersonAsync(string name, string userData = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteFace(System.Guid personId, System.Guid persistedFaceId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFaceAsync(System.Guid personId, System.Guid persistedFaceId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeletePerson(System.Guid personId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeletePersonAsync(System.Guid personId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetFace(System.Guid personId, System.Guid persistedFaceId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.LargePersonGroupPersonFace> GetFace(System.Guid personId, System.Guid persistedFaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFaceAsync(System.Guid personId, System.Guid persistedFaceId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.LargePersonGroupPersonFace>> GetFaceAsync(System.Guid personId, System.Guid persistedFaceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLargePersonGroup(bool? returnRecognitionModel, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.LargePersonGroup> GetLargePersonGroup(bool? returnRecognitionModel = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLargePersonGroupAsync(bool? returnRecognitionModel, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.LargePersonGroup>> GetLargePersonGroupAsync(bool? returnRecognitionModel = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetLargePersonGroups(string start, int? top, bool? returnRecognitionModel, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LargePersonGroup>> GetLargePersonGroups(string start = null, int? top = default(int?), bool? returnRecognitionModel = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLargePersonGroupsAsync(string start, int? top, bool? returnRecognitionModel, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LargePersonGroup>>> GetLargePersonGroupsAsync(string start = null, int? top = default(int?), bool? returnRecognitionModel = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPerson(System.Guid personId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.LargePersonGroupPerson> GetPerson(System.Guid personId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPersonAsync(System.Guid personId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.LargePersonGroupPerson>> GetPersonAsync(System.Guid personId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPersons(string start, int? top, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LargePersonGroupPerson>> GetPersons(string start = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPersonsAsync(string start, int? top, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LargePersonGroupPerson>>> GetPersonsAsync(string start = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTrainingStatus(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.Face.FaceTrainingResult> GetTrainingStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTrainingStatusAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.Face.FaceTrainingResult>> GetTrainingStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Train(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> TrainAsync(Azure.WaitUntil waitUntil, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Update(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateFace(System.Guid personId, System.Guid persistedFaceId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateFaceAsync(System.Guid personId, System.Guid persistedFaceId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdatePerson(System.Guid personId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdatePersonAsync(System.Guid personId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class LargePersonGroupPerson : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargePersonGroupPerson>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroupPerson>
    {
        internal LargePersonGroupPerson() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Guid> PersistedFaceIds { get { throw null; } }
        public System.Guid PersonId { get { throw null; } }
        public string UserData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LargePersonGroupPerson System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargePersonGroupPerson>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargePersonGroupPerson>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LargePersonGroupPerson System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroupPerson>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroupPerson>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroupPerson>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LargePersonGroupPersonFace : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargePersonGroupPersonFace>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroupPersonFace>
    {
        internal LargePersonGroupPersonFace() { }
        public System.Guid PersistedFaceId { get { throw null; } }
        public string UserData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LargePersonGroupPersonFace System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargePersonGroupPersonFace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LargePersonGroupPersonFace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LargePersonGroupPersonFace System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroupPersonFace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroupPersonFace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LargePersonGroupPersonFace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessColorDecisionTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessColorDecisionTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessColorDecisionTarget>
    {
        internal LivenessColorDecisionTarget() { }
        public Azure.AI.Vision.Face.FaceRectangle FaceRectangle { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessColorDecisionTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessColorDecisionTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessColorDecisionTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessColorDecisionTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessColorDecisionTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessColorDecisionTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessColorDecisionTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessDecisionTargets : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessDecisionTargets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessDecisionTargets>
    {
        internal LivenessDecisionTargets() { }
        public Azure.AI.Vision.Face.LivenessColorDecisionTarget Color { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessDecisionTargets System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessDecisionTargets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessDecisionTargets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessDecisionTargets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessDecisionTargets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessDecisionTargets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessDecisionTargets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessError>
    {
        internal LivenessError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessDecisionTargets Targets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessError System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LivenessModel : System.IEquatable<Azure.AI.Vision.Face.LivenessModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LivenessModel(string value) { throw null; }
        public static Azure.AI.Vision.Face.LivenessModel V20241115 { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.LivenessModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.LivenessModel left, Azure.AI.Vision.Face.LivenessModel right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.LivenessModel (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.LivenessModel left, Azure.AI.Vision.Face.LivenessModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LivenessOperationMode : System.IEquatable<Azure.AI.Vision.Face.LivenessOperationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LivenessOperationMode(string value) { throw null; }
        public static Azure.AI.Vision.Face.LivenessOperationMode Passive { get { throw null; } }
        public static Azure.AI.Vision.Face.LivenessOperationMode PassiveActive { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.LivenessOperationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.LivenessOperationMode left, Azure.AI.Vision.Face.LivenessOperationMode right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.LivenessOperationMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.LivenessOperationMode left, Azure.AI.Vision.Face.LivenessOperationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LivenessResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessResult>
    {
        internal LivenessResult() { }
        public string Digest { get { throw null; } }
        public Azure.AI.Vision.Face.FaceLivenessDecision? LivenessDecision { get { throw null; } }
        public string SessionImageId { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessDecisionTargets Targets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessSession : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessSession>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSession>
    {
        internal LivenessSession() { }
        public string AuthToken { get { throw null; } }
        public string ExpectedClientIpAddress { get { throw null; } }
        public bool IsAbuseMonitoringEnabled { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessModel? ModelVersion { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessSessionResults Results { get { throw null; } }
        public string SessionId { get { throw null; } }
        public Azure.AI.Vision.Face.OperationState Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessSession System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessSession System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessSessionAttempt : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessSessionAttempt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSessionAttempt>
    {
        internal LivenessSessionAttempt() { }
        public Azure.AI.Vision.Face.AbuseMonitoringResult AbuseMonitoringResult { get { throw null; } }
        public int AttemptId { get { throw null; } }
        public Azure.AI.Vision.Face.OperationState AttemptStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.ClientInformation> ClientInformation { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessError Error { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessResult Result { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessSessionAttempt System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessSessionAttempt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessSessionAttempt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessSessionAttempt System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSessionAttempt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSessionAttempt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSessionAttempt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessSessionResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessSessionResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSessionResults>
    {
        internal LivenessSessionResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LivenessSessionAttempt> Attempts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessSessionResults System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessSessionResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessSessionResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessSessionResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSessionResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSessionResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessSessionResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessWithVerifyOutputs : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifyOutputs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyOutputs>
    {
        internal LivenessWithVerifyOutputs() { }
        public bool IsIdentical { get { throw null; } }
        public float MatchConfidence { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifyOutputs System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifyOutputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifyOutputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifyOutputs System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyOutputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyOutputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyOutputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessWithVerifyReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyReference>
    {
        internal LivenessWithVerifyReference() { }
        public Azure.AI.Vision.Face.FaceRectangle FaceRectangle { get { throw null; } }
        public Azure.AI.Vision.Face.QualityForRecognition QualityForRecognition { get { throw null; } }
        public Azure.AI.Vision.Face.FaceImageType ReferenceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifyReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifyReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessWithVerifyResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyResult>
    {
        internal LivenessWithVerifyResult() { }
        public string Digest { get { throw null; } }
        public Azure.AI.Vision.Face.FaceLivenessDecision? LivenessDecision { get { throw null; } }
        public string SessionImageId { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessDecisionTargets Targets { get { throw null; } }
        public string VerifyImageHash { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessWithVerifyOutputs VerifyResult { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifyResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifyResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifyResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifyResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifyResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessWithVerifySession : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifySession>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySession>
    {
        internal LivenessWithVerifySession() { }
        public string AuthToken { get { throw null; } }
        public string ExpectedClientIpAddress { get { throw null; } }
        public bool IsAbuseMonitoringEnabled { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessModel? ModelVersion { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessWithVerifySessionResults Results { get { throw null; } }
        public string SessionId { get { throw null; } }
        public Azure.AI.Vision.Face.OperationState Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifySession System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifySession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifySession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifySession System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessWithVerifySessionAttempt : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt>
    {
        internal LivenessWithVerifySessionAttempt() { }
        public Azure.AI.Vision.Face.AbuseMonitoringResult AbuseMonitoringResult { get { throw null; } }
        public int AttemptId { get { throw null; } }
        public Azure.AI.Vision.Face.OperationState AttemptStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.ClientInformation> ClientInformation { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessError Error { get { throw null; } }
        public Azure.AI.Vision.Face.LivenessWithVerifyResult Result { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LivenessWithVerifySessionResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifySessionResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySessionResults>
    {
        internal LivenessWithVerifySessionResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LivenessWithVerifySessionAttempt> Attempts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.Face.LivenessWithVerifyReference> VerifyReferences { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifySessionResults System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifySessionResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.LivenessWithVerifySessionResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.LivenessWithVerifySessionResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySessionResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySessionResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.LivenessWithVerifySessionResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaskProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.MaskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.MaskProperties>
    {
        internal MaskProperties() { }
        public bool NoseAndMouthCovered { get { throw null; } }
        public Azure.AI.Vision.Face.MaskType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.MaskProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.MaskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.MaskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.MaskProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.MaskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.MaskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.MaskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaskType : System.IEquatable<Azure.AI.Vision.Face.MaskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaskType(string value) { throw null; }
        public static Azure.AI.Vision.Face.MaskType FaceMask { get { throw null; } }
        public static Azure.AI.Vision.Face.MaskType NoMask { get { throw null; } }
        public static Azure.AI.Vision.Face.MaskType OtherMaskOrOcclusion { get { throw null; } }
        public static Azure.AI.Vision.Face.MaskType Uncertain { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.MaskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.MaskType left, Azure.AI.Vision.Face.MaskType right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.MaskType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.MaskType left, Azure.AI.Vision.Face.MaskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NoiseLevel : System.IEquatable<Azure.AI.Vision.Face.NoiseLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NoiseLevel(string value) { throw null; }
        public static Azure.AI.Vision.Face.NoiseLevel High { get { throw null; } }
        public static Azure.AI.Vision.Face.NoiseLevel Low { get { throw null; } }
        public static Azure.AI.Vision.Face.NoiseLevel Medium { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.NoiseLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.NoiseLevel left, Azure.AI.Vision.Face.NoiseLevel right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.NoiseLevel (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.NoiseLevel left, Azure.AI.Vision.Face.NoiseLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NoiseProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.NoiseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.NoiseProperties>
    {
        internal NoiseProperties() { }
        public Azure.AI.Vision.Face.NoiseLevel NoiseLevel { get { throw null; } }
        public float Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.NoiseProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.NoiseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.NoiseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.NoiseProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.NoiseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.NoiseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.NoiseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OcclusionProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.OcclusionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.OcclusionProperties>
    {
        internal OcclusionProperties() { }
        public bool EyeOccluded { get { throw null; } }
        public bool ForeheadOccluded { get { throw null; } }
        public bool MouthOccluded { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.OcclusionProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.OcclusionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.OcclusionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.OcclusionProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.OcclusionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.OcclusionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.OcclusionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationState : System.IEquatable<Azure.AI.Vision.Face.OperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationState(string value) { throw null; }
        public static Azure.AI.Vision.Face.OperationState Canceled { get { throw null; } }
        public static Azure.AI.Vision.Face.OperationState Failed { get { throw null; } }
        public static Azure.AI.Vision.Face.OperationState NotStarted { get { throw null; } }
        public static Azure.AI.Vision.Face.OperationState Running { get { throw null; } }
        public static Azure.AI.Vision.Face.OperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.OperationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.OperationState left, Azure.AI.Vision.Face.OperationState right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.OperationState (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.OperationState left, Azure.AI.Vision.Face.OperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OtherFlaggedSessions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.OtherFlaggedSessions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.OtherFlaggedSessions>
    {
        internal OtherFlaggedSessions() { }
        public int AttemptId { get { throw null; } }
        public string SessionId { get { throw null; } }
        public string SessionImageId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.OtherFlaggedSessions System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.OtherFlaggedSessions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.Face.OtherFlaggedSessions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.Face.OtherFlaggedSessions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.OtherFlaggedSessions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.OtherFlaggedSessions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.Face.OtherFlaggedSessions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QualityForRecognition : System.IEquatable<Azure.AI.Vision.Face.QualityForRecognition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QualityForRecognition(string value) { throw null; }
        public static Azure.AI.Vision.Face.QualityForRecognition High { get { throw null; } }
        public static Azure.AI.Vision.Face.QualityForRecognition Low { get { throw null; } }
        public static Azure.AI.Vision.Face.QualityForRecognition Medium { get { throw null; } }
        public bool Equals(Azure.AI.Vision.Face.QualityForRecognition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Vision.Face.QualityForRecognition left, Azure.AI.Vision.Face.QualityForRecognition right) { throw null; }
        public static implicit operator Azure.AI.Vision.Face.QualityForRecognition (string value) { throw null; }
        public static bool operator !=(Azure.AI.Vision.Face.QualityForRecognition left, Azure.AI.Vision.Face.QualityForRecognition right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIVisionFaceClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.Face.FaceAdministrationClient, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions> AddFaceAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.Face.FaceAdministrationClient, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions> AddFaceAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.Face.FaceAdministrationClient, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions> AddFaceAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.Face.FaceClient, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions> AddFaceClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.Face.FaceClient, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions> AddFaceClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.Face.FaceClient, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions> AddFaceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.Face.FaceSessionClient, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions> AddFaceSessionClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.Face.FaceSessionClient, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions> AddFaceSessionClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.Face.FaceSessionClient, Azure.AI.Vision.Face.AzureAIVisionFaceClientOptions> AddFaceSessionClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
