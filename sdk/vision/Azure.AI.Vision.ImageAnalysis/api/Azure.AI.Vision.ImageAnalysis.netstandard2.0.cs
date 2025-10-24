namespace Azure.AI.Vision.ImageAnalysis
{
    public static partial class AIVisionImageAnalysisModelFactory
    {
        public static Azure.AI.Vision.ImageAnalysis.CaptionResult CaptionResult(float confidence = 0f, string text = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.CropRegion CropRegion(float aspectRatio = 0f, Azure.AI.Vision.ImageAnalysis.ImageBoundingBox boundingBox = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.DenseCaption DenseCaption(float confidence = 0f, string text = null, Azure.AI.Vision.ImageAnalysis.ImageBoundingBox boundingBox = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult DenseCaptionsResult(System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.DenseCaption> values = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.DetectedObject DetectedObject(Azure.AI.Vision.ImageAnalysis.ImageBoundingBox boundingBox = null, System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.DetectedTag> tags = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.DetectedPerson DetectedPerson(Azure.AI.Vision.ImageAnalysis.ImageBoundingBox boundingBox = null, float confidence = 0f) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.DetectedTag DetectedTag(float confidence = 0f, string name = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.DetectedTextBlock DetectedTextBlock(System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.DetectedTextLine> lines = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.DetectedTextLine DetectedTextLine(string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.ImagePoint> boundingPolygon = null, System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.DetectedTextWord> words = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.DetectedTextWord DetectedTextWord(string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.ImagePoint> boundingPolygon = null, float confidence = 0f) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult ImageAnalysisResult(Azure.AI.Vision.ImageAnalysis.CaptionResult caption = null, Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult denseCaptions = null, Azure.AI.Vision.ImageAnalysis.ImageMetadata metadata = null, string modelVersion = null, Azure.AI.Vision.ImageAnalysis.ObjectsResult objects = null, Azure.AI.Vision.ImageAnalysis.PeopleResult people = null, Azure.AI.Vision.ImageAnalysis.ReadResult read = null, Azure.AI.Vision.ImageAnalysis.SmartCropsResult smartCrops = null, Azure.AI.Vision.ImageAnalysis.TagsResult tags = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.ImageBoundingBox ImageBoundingBox(int x = 0, int y = 0, int width = 0, int height = 0) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.ImageMetadata ImageMetadata(int height = 0, int width = 0) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.ImagePoint ImagePoint(int x = 0, int y = 0) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.ObjectsResult ObjectsResult(System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.DetectedObject> values = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.PeopleResult PeopleResult(System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.DetectedPerson> values = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.ReadResult ReadResult(System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.DetectedTextBlock> blocks = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.SmartCropsResult SmartCropsResult(System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.CropRegion> values = null) { throw null; }
        public static Azure.AI.Vision.ImageAnalysis.TagsResult TagsResult(System.Collections.Generic.IEnumerable<Azure.AI.Vision.ImageAnalysis.DetectedTag> values = null) { throw null; }
    }
    public partial class AzureAIVisionImageAnalysisContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIVisionImageAnalysisContext() { }
        public static Azure.AI.Vision.ImageAnalysis.AzureAIVisionImageAnalysisContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CaptionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.CaptionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.CaptionResult>
    {
        internal CaptionResult() { }
        public float Confidence { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.CaptionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.CaptionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.CaptionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.CaptionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.CaptionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.CaptionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.CaptionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.CaptionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.CaptionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CropRegion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.CropRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.CropRegion>
    {
        internal CropRegion() { }
        public float AspectRatio { get { throw null; } }
        public Azure.AI.Vision.ImageAnalysis.ImageBoundingBox BoundingBox { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.CropRegion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.CropRegion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.CropRegion System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.CropRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.CropRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.CropRegion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.CropRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.CropRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.CropRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DenseCaption : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DenseCaption>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DenseCaption>
    {
        internal DenseCaption() { }
        public Azure.AI.Vision.ImageAnalysis.ImageBoundingBox BoundingBox { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.DenseCaption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.DenseCaption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.DenseCaption System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DenseCaption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DenseCaption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.DenseCaption System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DenseCaption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DenseCaption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DenseCaption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DenseCaptionsResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult>
    {
        internal DenseCaptionsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DenseCaption> Values { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectedObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedObject>
    {
        internal DetectedObject() { }
        public Azure.AI.Vision.ImageAnalysis.ImageBoundingBox BoundingBox { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedTag> Tags { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.DetectedObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.DetectedObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectedPerson : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedPerson>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedPerson>
    {
        internal DetectedPerson() { }
        public Azure.AI.Vision.ImageAnalysis.ImageBoundingBox BoundingBox { get { throw null; } }
        public float Confidence { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedPerson JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedPerson PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.DetectedPerson System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedPerson>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedPerson>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.DetectedPerson System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedPerson>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedPerson>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedPerson>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectedTag : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTag>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTag>
    {
        internal DetectedTag() { }
        public float Confidence { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedTag JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedTag PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.DetectedTag System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.DetectedTag System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectedTextBlock : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTextBlock>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextBlock>
    {
        internal DetectedTextBlock() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedTextLine> Lines { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedTextBlock JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedTextBlock PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.DetectedTextBlock System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTextBlock>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTextBlock>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.DetectedTextBlock System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextBlock>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextBlock>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextBlock>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectedTextLine : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTextLine>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextLine>
    {
        internal DetectedTextLine() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.ImagePoint> BoundingPolygon { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedTextWord> Words { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedTextLine JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedTextLine PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.DetectedTextLine System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTextLine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTextLine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.DetectedTextLine System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextLine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextLine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextLine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectedTextWord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTextWord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextWord>
    {
        internal DetectedTextWord() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.ImagePoint> BoundingPolygon { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedTextWord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.DetectedTextWord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.DetectedTextWord System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTextWord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.DetectedTextWord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.DetectedTextWord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextWord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextWord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.DetectedTextWord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageAnalysisClient
    {
        protected ImageAnalysisClient() { }
        public ImageAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ImageAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Vision.ImageAnalysis.ImageAnalysisClientOptions options) { }
        public ImageAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ImageAnalysisClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Vision.ImageAnalysis.ImageAnalysisClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult> Analyze(System.BinaryData imageData, Azure.AI.Vision.ImageAnalysis.VisualFeatures visualFeatures, Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions options = default(Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult> Analyze(System.Uri imageUri, Azure.AI.Vision.ImageAnalysis.VisualFeatures visualFeatures, Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions options = default(Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>> AnalyzeAsync(System.BinaryData imageData, Azure.AI.Vision.ImageAnalysis.VisualFeatures visualFeatures, Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions options = default(Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>> AnalyzeAsync(System.Uri imageUri, Azure.AI.Vision.ImageAnalysis.VisualFeatures visualFeatures, Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions options = default(Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImageAnalysisClientOptions : Azure.Core.ClientOptions
    {
        public ImageAnalysisClientOptions(Azure.AI.Vision.ImageAnalysis.ImageAnalysisClientOptions.ServiceVersion version = Azure.AI.Vision.ImageAnalysis.ImageAnalysisClientOptions.ServiceVersion.V2023_10_01) { }
        public enum ServiceVersion
        {
            V2023_10_01 = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct ImageAnalysisOptions
    {
        private object _dummy;
        private int _dummyPrimitive;
        public bool? GenderNeutralCaption { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<float> SmartCropsAspectRatios { get { throw null; } set { } }
    }
    public partial class ImageAnalysisResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>
    {
        internal ImageAnalysisResult() { }
        public Azure.AI.Vision.ImageAnalysis.CaptionResult Caption { get { throw null; } }
        public Azure.AI.Vision.ImageAnalysis.DenseCaptionsResult DenseCaptions { get { throw null; } }
        public Azure.AI.Vision.ImageAnalysis.ImageMetadata Metadata { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Vision.ImageAnalysis.ObjectsResult Objects { get { throw null; } }
        public Azure.AI.Vision.ImageAnalysis.PeopleResult People { get { throw null; } }
        public Azure.AI.Vision.ImageAnalysis.ReadResult Read { get { throw null; } }
        public Azure.AI.Vision.ImageAnalysis.SmartCropsResult SmartCrops { get { throw null; } }
        public Azure.AI.Vision.ImageAnalysis.TagsResult Tags { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult (Azure.Response result) { throw null; }
        protected virtual Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageBoundingBox : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImageBoundingBox>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageBoundingBox>
    {
        internal ImageBoundingBox() { }
        public int Height { get { throw null; } }
        public int Width { get { throw null; } }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.ImageBoundingBox JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.ImageBoundingBox PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.ImageBoundingBox System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImageBoundingBox>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImageBoundingBox>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.ImageBoundingBox System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageBoundingBox>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageBoundingBox>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageBoundingBox>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImageMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageMetadata>
    {
        internal ImageMetadata() { }
        public int Height { get { throw null; } }
        public int Width { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.ImageMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.ImageMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.ImageMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImageMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImageMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.ImageMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImageMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImagePoint : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImagePoint>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImagePoint>
    {
        internal ImagePoint() { }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.ImagePoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.ImagePoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.ImagePoint System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImagePoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ImagePoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.ImagePoint System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImagePoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImagePoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ImagePoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ObjectsResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ObjectsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ObjectsResult>
    {
        internal ObjectsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedObject> Values { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.ObjectsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.ObjectsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.ObjectsResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ObjectsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ObjectsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.ObjectsResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ObjectsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ObjectsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ObjectsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeopleResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.PeopleResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.PeopleResult>
    {
        internal PeopleResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedPerson> Values { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.PeopleResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.PeopleResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.PeopleResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.PeopleResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.PeopleResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.PeopleResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.PeopleResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.PeopleResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.PeopleResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReadResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ReadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ReadResult>
    {
        internal ReadResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedTextBlock> Blocks { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.ReadResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.ReadResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.ReadResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ReadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.ReadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.ReadResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ReadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ReadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.ReadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SmartCropsResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.SmartCropsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.SmartCropsResult>
    {
        internal SmartCropsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.CropRegion> Values { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.SmartCropsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.SmartCropsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.SmartCropsResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.SmartCropsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.SmartCropsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.SmartCropsResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.SmartCropsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.SmartCropsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.SmartCropsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TagsResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.TagsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.TagsResult>
    {
        internal TagsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedTag> Values { get { throw null; } }
        protected virtual Azure.AI.Vision.ImageAnalysis.TagsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Vision.ImageAnalysis.TagsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Vision.ImageAnalysis.TagsResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.TagsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Vision.ImageAnalysis.TagsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Vision.ImageAnalysis.TagsResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.TagsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.TagsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Vision.ImageAnalysis.TagsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.FlagsAttribute]
    public enum VisualFeatures
    {
        None = 0,
        Tags = 1,
        Caption = 2,
        DenseCaptions = 4,
        Objects = 8,
        Read = 16,
        SmartCrops = 32,
        People = 64,
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIVisionImageAnalysisClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.ImageAnalysis.ImageAnalysisClient, Azure.AI.Vision.ImageAnalysis.ImageAnalysisClientOptions> AddImageAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.ImageAnalysis.ImageAnalysisClient, Azure.AI.Vision.ImageAnalysis.ImageAnalysisClientOptions> AddImageAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.ImageAnalysis.ImageAnalysisClient, Azure.AI.Vision.ImageAnalysis.ImageAnalysisClientOptions> AddImageAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
