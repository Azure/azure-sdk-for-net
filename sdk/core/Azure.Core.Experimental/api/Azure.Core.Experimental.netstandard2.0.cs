namespace Azure.Core
{
    [System.Diagnostics.DebuggerDisplayAttribute("Content: {_body}")]
    public partial class DynamicContent : Azure.Core.RequestContent
    {
        internal DynamicContent() { }
        public static Azure.Core.RequestContent Create(Azure.Core.JsonData body) { throw null; }
        public override void Dispose() { }
        public override bool TryComputeLength(out long length) { throw null; }
        public override void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellation) { }
        public override System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellation) { throw null; }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{DebuggerDisplay,nq}")]
    public partial class DynamicRequest : Azure.Core.Request
    {
        public DynamicRequest(Azure.Core.Request request, Azure.Core.Pipeline.HttpPipeline pipeline) { }
        public Azure.Core.JsonData Body { get { throw null; } set { } }
        public override string ClientRequestId { get { throw null; } set { } }
        public override Azure.Core.RequestContent? Content { get { throw null; } set { } }
        public dynamic DynamicBody { get { throw null; } }
        protected override void AddHeader(string name, string value) { }
        protected override bool ContainsHeader(string name) { throw null; }
        public override void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected override System.Collections.Generic.IEnumerable<Azure.Core.HttpHeader> EnumerateHeaders() { throw null; }
        protected override bool RemoveHeader(string name) { throw null; }
        public Azure.Core.DynamicResponse Send(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<Azure.Core.DynamicResponse> SendAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected override bool TryGetHeader(string name, out string? value) { throw null; }
        protected override bool TryGetHeaderValues(string name, out System.Collections.Generic.IEnumerable<string>? values) { throw null; }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{DebuggerDisplay,nq}")]
    public partial class DynamicResponse : Azure.Response
    {
        public DynamicResponse(Azure.Response response, Azure.Core.JsonData? body) { }
        public Azure.Core.JsonData? Body { get { throw null; } }
        public override string ClientRequestId { get { throw null; } set { } }
        public override System.IO.Stream? ContentStream { get { throw null; } set { } }
        public dynamic? DynamicBody { get { throw null; } }
        public override string ReasonPhrase { get { throw null; } }
        public override int Status { get { throw null; } }
        protected override bool ContainsHeader(string name) { throw null; }
        public override void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected override System.Collections.Generic.IEnumerable<Azure.Core.HttpHeader> EnumerateHeaders() { throw null; }
        protected override bool TryGetHeader(string name, out string? value) { throw null; }
        protected override bool TryGetHeaderValues(string name, out System.Collections.Generic.IEnumerable<string>? values) { throw null; }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{DebuggerDisplay,nq}")]
    public partial class JsonData : System.Dynamic.IDynamicMetaObjectProvider, System.IEquatable<Azure.Core.JsonData>
    {
        public JsonData() { }
        public JsonData(object? value) { }
        public JsonData(object? value, System.Text.Json.JsonSerializerOptions options, System.Type? type = null) { }
        public JsonData(System.Text.Json.JsonDocument jsonDocument) { }
        public Azure.Core.JsonData this[int arrayIndex] { get { throw null; } set { } }
        public Azure.Core.JsonData this[string propertyName] { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.Core.JsonData> Items { get { throw null; } }
        public System.Text.Json.JsonValueKind Kind { get { throw null; } }
        public int Length { get { throw null; } }
        public System.Collections.Generic.IEnumerable<string> Properties { get { throw null; } }
        public void Add(bool value) { }
        public void Add(double value) { }
        public void Add(int value) { }
        public void Add(long value) { }
        public Azure.Core.JsonData Add(object? serializable) { throw null; }
        public Azure.Core.JsonData Add(object? serializable, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public void Add(float value) { }
        public void Add(string? value) { }
        public Azure.Core.JsonData AddEmptyArray() { throw null; }
        public Azure.Core.JsonData AddEmptyObject() { throw null; }
        public Azure.Core.JsonData Add<T>(T[] serializable) { throw null; }
        public Azure.Core.JsonData Add<T>(T[] serializable, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public static Azure.Core.JsonData EmptyArray() { throw null; }
        public static Azure.Core.JsonData EmptyObject() { throw null; }
        public bool Equals(Azure.Core.JsonData other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public static Azure.Core.JsonData FromBytes(byte[] utf8Json) { throw null; }
        public static Azure.Core.JsonData FromBytes(System.ReadOnlyMemory<byte> utf8Json) { throw null; }
        public static Azure.Core.JsonData FromObject<T>(T value, System.Text.Json.JsonSerializerOptions? options = null) { throw null; }
        public static Azure.Core.JsonData FromStream(System.IO.Stream utf8Json) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Core.JsonData> FromStreamAsync(System.IO.Stream utf8JsonStream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.JsonData FromString(string json) { throw null; }
        public Azure.Core.JsonData? Get(string propertyName) { throw null; }
        public override int GetHashCode() { throw null; }
        public T Get<T>(string propertyName) { throw null; }
        public T Get<T>(string propertyName, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public static bool operator ==(Azure.Core.JsonData? left, string? right) { throw null; }
        public static bool operator ==(string? left, Azure.Core.JsonData? right) { throw null; }
        public static explicit operator bool (Azure.Core.JsonData json) { throw null; }
        public static explicit operator double (Azure.Core.JsonData json) { throw null; }
        public static explicit operator int (Azure.Core.JsonData json) { throw null; }
        public static explicit operator long (Azure.Core.JsonData json) { throw null; }
        public static explicit operator bool? (Azure.Core.JsonData json) { throw null; }
        public static explicit operator double? (Azure.Core.JsonData json) { throw null; }
        public static explicit operator int? (Azure.Core.JsonData json) { throw null; }
        public static explicit operator long? (Azure.Core.JsonData json) { throw null; }
        public static explicit operator float? (Azure.Core.JsonData json) { throw null; }
        public static explicit operator float (Azure.Core.JsonData json) { throw null; }
        public static explicit operator string (Azure.Core.JsonData json) { throw null; }
        public static implicit operator Azure.Core.JsonData (bool value) { throw null; }
        public static implicit operator Azure.Core.JsonData (double value) { throw null; }
        public static implicit operator Azure.Core.JsonData (int value) { throw null; }
        public static implicit operator Azure.Core.JsonData (long value) { throw null; }
        public static implicit operator Azure.Core.JsonData (bool? value) { throw null; }
        public static implicit operator Azure.Core.JsonData (double? value) { throw null; }
        public static implicit operator Azure.Core.JsonData (int? value) { throw null; }
        public static implicit operator Azure.Core.JsonData (long? value) { throw null; }
        public static implicit operator Azure.Core.JsonData (float? value) { throw null; }
        public static implicit operator Azure.Core.JsonData (float value) { throw null; }
        public static implicit operator Azure.Core.JsonData (string? value) { throw null; }
        public static bool operator !=(Azure.Core.JsonData? left, string? right) { throw null; }
        public static bool operator !=(string? left, Azure.Core.JsonData? right) { throw null; }
        public void Set(string propertyName, bool value) { }
        public void Set(string propertyName, double value) { }
        public void Set(string propertyName, int value) { }
        public void Set(string propertyName, long value) { }
        public Azure.Core.JsonData Set(string propertyName, object? serializable) { throw null; }
        public Azure.Core.JsonData Set(string propertyName, object? serializable, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public void Set(string propertyName, float value) { }
        public void Set(string propertyName, string? value) { }
        public Azure.Core.JsonData SetEmptyArray(string propertyName) { throw null; }
        public Azure.Core.JsonData SetEmptyObject(string propertyName) { throw null; }
        public Azure.Core.JsonData Set<T>(string propertyName, T[] serializable) { throw null; }
        public Azure.Core.JsonData Set<T>(string propertyName, T[] serializable, System.Text.Json.JsonSerializerOptions options) { throw null; }
        System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public string ToJsonString() { throw null; }
        public override string ToString() { throw null; }
        public T To<T>() { throw null; }
        public T To<T>(System.Text.Json.JsonSerializerOptions options) { throw null; }
        public long WriteTo(System.IO.Stream stream) { throw null; }
        public System.Threading.Tasks.Task<long> WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class ProtocolClientOptions : Azure.Core.ClientOptions
    {
        public ProtocolClientOptions() { }
    }
}
namespace Azure.Core.GeoJson
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoArray<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public int Count { get { throw null; } }
        public T this[int index] { get { throw null; } }
        public Azure.Core.GeoJson.GeoArray<T>.Enumerator GetEnumerator() { throw null; }
        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct Enumerator : System.Collections.Generic.IEnumerator<T>, System.Collections.IEnumerator, System.IDisposable
        {
            private object _dummy;
            private int _dummyPrimitive;
            public T Current { get { throw null; } }
            object System.Collections.IEnumerator.Current { get { throw null; } }
            public void Dispose() { }
            public bool MoveNext() { throw null; }
            public void Reset() { }
        }
    }
    public sealed partial class GeoBoundingBox : System.IEquatable<Azure.Core.GeoJson.GeoBoundingBox>
    {
        public GeoBoundingBox(double west, double south, double east, double north) { }
        public GeoBoundingBox(double west, double south, double east, double north, double? minAltitude, double? maxAltitude) { }
        public double East { get { throw null; } }
        public double this[int index] { get { throw null; } }
        public double? MaxAltitude { get { throw null; } }
        public double? MinAltitude { get { throw null; } }
        public double North { get { throw null; } }
        public double South { get { throw null; } }
        public double West { get { throw null; } }
        public bool Equals(Azure.Core.GeoJson.GeoBoundingBox other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class GeoCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoObject>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoObject>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoObject>, System.Collections.IEnumerable
    {
        public GeoCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoObject> geometries) { }
        public GeoCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoObject> geometries, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoObject this[int index] { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoObject> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public sealed partial class GeoJsonConverter : System.Text.Json.Serialization.JsonConverter<Azure.Core.GeoJson.GeoObject>
    {
        public GeoJsonConverter() { }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override Azure.Core.GeoJson.GeoObject Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, Azure.Core.GeoJson.GeoObject value, System.Text.Json.JsonSerializerOptions options) { }
    }
    public sealed partial class GeoLinearRing
    {
        public GeoLinearRing(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPosition> coordinates) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition> Coordinates { get { throw null; } }
    }
    public sealed partial class GeoLineString : Azure.Core.GeoJson.GeoObject
    {
        public GeoLineString(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPosition> coordinates) { }
        public GeoLineString(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPosition> coordinates, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition> Coordinates { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
    }
    public sealed partial class GeoLineStringCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLineString>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoLineString>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoLineString>, System.Collections.IEnumerable
    {
        public GeoLineStringCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLineString> lines) { }
        public GeoLineStringCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLineString> lines, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition>> Coordinates { get { throw null; } }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoLineString this[int index] { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoLineString> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class GeoObject
    {
        internal GeoObject() { }
        public Azure.Core.GeoJson.GeoBoundingBox? BoundingBox { get { throw null; } }
        public abstract Azure.Core.GeoJson.GeoObjectType Type { get; }
        public static Azure.Core.GeoJson.GeoObject Parse(string json) { throw null; }
        public override string ToString() { throw null; }
        public bool TryGetCustomProperty(string name, out object? value) { throw null; }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer) { }
    }
    public enum GeoObjectType
    {
        Point = 0,
        MultiPoint = 1,
        Polygon = 2,
        MultiPolygon = 3,
        LineString = 4,
        MultiLineString = 5,
        GeometryCollection = 6,
    }
    public sealed partial class GeoPoint : Azure.Core.GeoJson.GeoObject
    {
        public GeoPoint(Azure.Core.GeoJson.GeoPosition position) { }
        public GeoPoint(Azure.Core.GeoJson.GeoPosition position, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public GeoPoint(double longitude, double latitude) { }
        public GeoPoint(double longitude, double latitude, double? altitude) { }
        public Azure.Core.GeoJson.GeoPosition Coordinates { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
    }
    public sealed partial class GeoPointCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPoint>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoPoint>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoPoint>, System.Collections.IEnumerable
    {
        public GeoPointCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPoint> points) { }
        public GeoPointCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPoint> points, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition> Coordinates { get { throw null; } }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoPoint this[int index] { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoPoint> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public sealed partial class GeoPolygon : Azure.Core.GeoJson.GeoObject
    {
        public GeoPolygon(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLinearRing> rings) { }
        public GeoPolygon(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLinearRing> rings, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public GeoPolygon(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPosition> positions) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition>> Coordinates { get { throw null; } }
        public Azure.Core.GeoJson.GeoLinearRing OuterRing { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoLinearRing> Rings { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
    }
    public sealed partial class GeoPolygonCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPolygon>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoPolygon>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoPolygon>, System.Collections.IEnumerable
    {
        public GeoPolygonCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPolygon> polygons) { }
        public GeoPolygonCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPolygon> polygons, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> customProperties) { }
        public Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoArray<Azure.Core.GeoJson.GeoPosition>>> Coordinates { get { throw null; } }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoPolygon this[int index] { get { throw null; } }
        public override Azure.Core.GeoJson.GeoObjectType Type { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoPolygon> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoPosition : System.IEquatable<Azure.Core.GeoJson.GeoPosition>
    {
        private readonly int _dummyPrimitive;
        public GeoPosition(double longitude, double latitude) { throw null; }
        public GeoPosition(double longitude, double latitude, double? altitude) { throw null; }
        public double? Altitude { get { throw null; } }
        public int Count { get { throw null; } }
        public double this[int index] { get { throw null; } }
        public double Latitude { get { throw null; } }
        public double Longitude { get { throw null; } }
        public bool Equals(Azure.Core.GeoJson.GeoPosition other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.GeoJson.GeoPosition left, Azure.Core.GeoJson.GeoPosition right) { throw null; }
        public static bool operator !=(Azure.Core.GeoJson.GeoPosition left, Azure.Core.GeoJson.GeoPosition right) { throw null; }
        public override string ToString() { throw null; }
    }
}
