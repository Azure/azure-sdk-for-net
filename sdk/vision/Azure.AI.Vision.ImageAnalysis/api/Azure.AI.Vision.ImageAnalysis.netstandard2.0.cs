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
    public partial class CaptionResult
    {
        internal CaptionResult() { }
        public float Confidence { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class CropRegion
    {
        internal CropRegion() { }
        public float AspectRatio { get { throw null; } }
        public Azure.AI.Vision.ImageAnalysis.ImageBoundingBox BoundingBox { get { throw null; } }
    }
    public partial class DenseCaption
    {
        internal DenseCaption() { }
        public Azure.AI.Vision.ImageAnalysis.ImageBoundingBox BoundingBox { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class DenseCaptionsResult
    {
        internal DenseCaptionsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DenseCaption> Values { get { throw null; } }
    }
    public partial class DetectedObject
    {
        internal DetectedObject() { }
        public Azure.AI.Vision.ImageAnalysis.ImageBoundingBox BoundingBox { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedTag> Tags { get { throw null; } }
    }
    public partial class DetectedPerson
    {
        internal DetectedPerson() { }
        public Azure.AI.Vision.ImageAnalysis.ImageBoundingBox BoundingBox { get { throw null; } }
        public float Confidence { get { throw null; } }
    }
    public partial class DetectedTag
    {
        internal DetectedTag() { }
        public float Confidence { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class DetectedTextBlock
    {
        internal DetectedTextBlock() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedTextLine> Lines { get { throw null; } }
    }
    public partial class DetectedTextLine
    {
        internal DetectedTextLine() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.ImagePoint> BoundingPolygon { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedTextWord> Words { get { throw null; } }
    }
    public partial class DetectedTextWord
    {
        internal DetectedTextWord() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.ImagePoint> BoundingPolygon { get { throw null; } }
        public float Confidence { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class ImageAnalysisClient
    {
        protected ImageAnalysisClient() { }
        public ImageAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ImageAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Vision.ImageAnalysis.ImageAnalysisClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult> Analyze(System.BinaryData imageContent, Azure.AI.Vision.ImageAnalysis.VisualFeatures visualFeatures, Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions options = default(Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult> Analyze(System.Uri imageContent, Azure.AI.Vision.ImageAnalysis.VisualFeatures visualFeatures, Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions options = default(Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>> AnalyzeAsync(System.BinaryData imageContent, Azure.AI.Vision.ImageAnalysis.VisualFeatures visualFeatures, Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions options = default(Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Vision.ImageAnalysis.ImageAnalysisResult>> AnalyzeAsync(System.Uri imageContent, Azure.AI.Vision.ImageAnalysis.VisualFeatures visualFeatures, Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions options = default(Azure.AI.Vision.ImageAnalysis.ImageAnalysisOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ImageAnalysisResult
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
    }
    public partial class ImageBoundingBox
    {
        internal ImageBoundingBox() { }
        public int Height { get { throw null; } }
        public int Width { get { throw null; } }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class ImageMetadata
    {
        internal ImageMetadata() { }
        public int Height { get { throw null; } }
        public int Width { get { throw null; } }
    }
    public partial class ImagePoint
    {
        internal ImagePoint() { }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public partial class ObjectsResult
    {
        internal ObjectsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedObject> Values { get { throw null; } }
    }
    public partial class PeopleResult
    {
        internal PeopleResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedPerson> Values { get { throw null; } }
    }
    public partial class ReadResult
    {
        internal ReadResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedTextBlock> Blocks { get { throw null; } }
    }
    public partial class SmartCropsResult
    {
        internal SmartCropsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.CropRegion> Values { get { throw null; } }
    }
    public partial class TagsResult
    {
        internal TagsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Vision.ImageAnalysis.DetectedTag> Values { get { throw null; } }
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
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.ImageAnalysis.ImageAnalysisClient, Azure.AI.Vision.ImageAnalysis.ImageAnalysisClientOptions> AddImageAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Vision.ImageAnalysis.ImageAnalysisClient, Azure.AI.Vision.ImageAnalysis.ImageAnalysisClientOptions> AddImageAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
