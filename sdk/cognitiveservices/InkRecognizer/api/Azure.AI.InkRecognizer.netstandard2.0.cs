namespace Azure.AI.InkRecognizer
{
    public enum ApplicationKind
    {
        Mixed = 0,
        Writing = 1,
        Drawing = 2,
    }
    public partial class HttpErrorDetails
    {
        public HttpErrorDetails(string errorJson) { }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct InkPoint : System.IEquatable<Azure.AI.InkRecognizer.InkPoint>
    {
        private int _dummyPrimitive;
        public InkPoint(float x, float y) { throw null; }
        public float X { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public float Y { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool Equals(Azure.AI.InkRecognizer.InkPoint other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object other) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public enum InkPointUnit
    {
        Mm = 0,
        Cm = 1,
        Inch = 2,
    }
    public partial class InkRecognitionRequest
    {
        internal InkRecognitionRequest() { }
    }
    public partial class InkRecognizerClient
    {
        protected InkRecognizerClient() { }
        public InkRecognizerClient(System.Uri endpoint, Azure.AI.InkRecognizer.InkRecognizerCredential credential) { }
        public InkRecognizerClient(System.Uri endpoint, Azure.AI.InkRecognizer.InkRecognizerCredential credential, Azure.AI.InkRecognizer.InkRecognizerClientOptions options) { }
        public virtual Azure.Response<Azure.AI.InkRecognizer.Models.RecognitionRoot> RecognizeInk(System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.InkStroke> strokes, Azure.AI.InkRecognizer.InkPointUnit unit, float unitMultiple, string language, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.InkRecognizer.Models.RecognitionRoot> RecognizeInk(System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.InkStroke> strokes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.InkRecognizer.Models.RecognitionRoot>> RecognizeInkAsync(System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.InkStroke> strokes, Azure.AI.InkRecognizer.InkPointUnit unit, float unitMultiple, string language, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.InkRecognizer.Models.RecognitionRoot>> RecognizeInkAsync(System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.InkStroke> strokes, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InkRecognizerClientOptions : Azure.Core.ClientOptions
    {
        public InkRecognizerClientOptions(Azure.AI.InkRecognizer.InkRecognizerClientOptions.ServiceVersion version = Azure.AI.InkRecognizer.InkRecognizerClientOptions.ServiceVersion.Preview1) { }
        public Azure.AI.InkRecognizer.ApplicationKind ApplicationKind { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.AI.InkRecognizer.InkPointUnit InkPointUnit { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Language { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.Core.RetryOptions RetryOps { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public float UnitMultiple { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.AI.InkRecognizer.InkRecognizerClientOptions.ServiceVersion Version { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public enum ServiceVersion
        {
            Preview1 = 0,
        }
    }
    public partial class InkRecognizerCredential
    {
        public InkRecognizerCredential(string subscriptionKey) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct InkStroke : System.IEquatable<Azure.AI.InkRecognizer.InkStroke>
    {
        private object _dummy;
        private int _dummyPrimitive;
        public InkStroke(System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.InkPoint> points, string language, long id, Azure.AI.InkRecognizer.InkStrokeKind kind = Azure.AI.InkRecognizer.InkStrokeKind.Unknown) { throw null; }
        public long Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public Azure.AI.InkRecognizer.InkStrokeKind Kind { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public string Language { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } [System.Runtime.CompilerServices.CompilerGeneratedAttribute] set { } }
        public bool Equals(Azure.AI.InkRecognizer.InkStroke other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.InkPoint> GetInkPoints() { throw null; }
    }
    public enum InkStrokeKind
    {
        Unknown = 0,
        InkDrawing = 1,
        InkWriting = 2,
    }
}
namespace Azure.AI.InkRecognizer.Models
{
    public partial class InkBullet : Azure.AI.InkRecognizer.Models.InkRecognitionUnit
    {
        internal InkBullet() { }
        public string RecognizedText { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class InkDrawing : Azure.AI.InkRecognizer.Models.InkRecognitionUnit
    {
        internal InkDrawing() { }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.Models.InkDrawing> Alternates { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Drawing.PointF Center { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public float Confidence { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IEnumerable<System.Drawing.PointF> Points { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.InkRecognizer.Models.RecognizedShape RecognizedShape { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public float RotationAngle { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public static partial class InkRecognitionModelFactory
    {
        public static Azure.AI.InkRecognizer.Models.RecognitionRoot InkRecognitionRoot(string responseContent) { throw null; }
    }
    public abstract partial class InkRecognitionUnit : System.IEquatable<Azure.AI.InkRecognizer.Models.InkRecognitionUnit>
    {
        protected InkRecognitionUnit() { }
        public System.Drawing.RectangleF BoundingBox { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.Models.InkRecognitionUnit> Children { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public long Id { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.InkRecognizer.Models.InkRecognitionUnitKind Kind { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.InkRecognizer.Models.InkRecognitionUnit Parent { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IEnumerable<System.Drawing.PointF> RotatedBoundingBox { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IEnumerable<long> StrokeIds { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.AI.InkRecognizer.Models.InkRecognitionUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
    }
    public enum InkRecognitionUnitKind
    {
        RecognizedRoot = 0,
        RecognizedWritingRegion = 1,
        RecognizedParagraph = 2,
        RecognizedLine = 3,
        InkDrawing = 4,
        InkWord = 5,
        InkBullet = 6,
        listItem = 7,
    }
    public partial class InkWord : Azure.AI.InkRecognizer.Models.InkRecognitionUnit
    {
        internal InkWord() { }
        public System.Collections.Generic.IEnumerable<string> Alternates { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public string RecognizedText { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
    }
    public partial class RecognitionRoot : System.IEquatable<Azure.AI.InkRecognizer.Models.RecognitionRoot>
    {
        protected RecognitionRoot() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool Equals(Azure.AI.InkRecognizer.Models.RecognitionRoot other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object other) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.Models.InkWord> FindWord(string word) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.Models.InkDrawing> GetDrawings() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.Models.InkRecognitionUnit> GetInkRecognitionUnits() { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.Models.InkRecognitionUnit> GetInkRecognitionUnits(Azure.AI.InkRecognizer.Models.InkRecognitionUnitKind kind) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.Models.InkWord> GetWords() { throw null; }
    }
    public partial class RecognizedLine : Azure.AI.InkRecognizer.Models.InkRecognitionUnit
    {
        internal RecognizedLine() { }
        public System.Collections.Generic.IEnumerable<string> Alternates { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public Azure.AI.InkRecognizer.Models.InkBullet Bullet { get { throw null; } }
        public string RecognizedText { [System.Runtime.CompilerServices.CompilerGeneratedAttribute] get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.Models.InkWord> Words { get { throw null; } }
    }
    public partial class RecognizedListItem : Azure.AI.InkRecognizer.Models.InkRecognitionUnit
    {
        internal RecognizedListItem() { }
    }
    public partial class RecognizedParagraph : Azure.AI.InkRecognizer.Models.InkRecognitionUnit
    {
        internal RecognizedParagraph() { }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.Models.RecognizedLine> Lines { get { throw null; } }
        public string RecognizedText { get { throw null; } }
    }
    public enum RecognizedShape
    {
        Drawing = 0,
        Square = 1,
        Rectangle = 2,
        Circle = 3,
        Ellipse = 4,
        Triangle = 5,
        Isoscelestriangle = 6,
        EquilateralTriangle = 7,
        RightTriangle = 8,
        Quadrilateral = 9,
        Diamond = 10,
        Trapezoid = 11,
        Parallelogram = 12,
        Pentagon = 13,
        Hexagon = 14,
        Blockarrow = 15,
        Heart = 16,
        Starsimple = 17,
        Starcrossed = 18,
        Cloud = 19,
        Line = 20,
        Curve = 21,
        Polyline = 22,
    }
    public partial class RecognizedWritingRegion : Azure.AI.InkRecognizer.Models.InkRecognitionUnit
    {
        internal RecognizedWritingRegion() { }
        public System.Collections.Generic.IEnumerable<Azure.AI.InkRecognizer.Models.RecognizedParagraph> Paragraphs { get { throw null; } }
        public string RecognizedText { get { throw null; } }
    }
    public partial class Unclassified : Azure.AI.InkRecognizer.Models.InkRecognitionUnit
    {
        internal Unclassified() { }
    }
}
