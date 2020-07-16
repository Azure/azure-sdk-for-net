namespace Azure.Core
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BinaryData
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BinaryData(System.ReadOnlyMemory<byte> data) { throw null; }
        public BinaryData(string data) { throw null; }
        public BinaryData(string data, System.Text.Encoding encoding) { throw null; }
        public System.ReadOnlyMemory<byte> AsBytes() { throw null; }
        public System.Threading.Tasks.ValueTask<T> DeserializeAsync<T>(Azure.Core.ObjectSerializer serializer) { throw null; }
        public T Deserialize<T>(Azure.Core.ObjectSerializer serializer) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Core.BinaryData> FromSerializableAsync<T>(T data, Azure.Core.ObjectSerializer serializer) { throw null; }
        public static Azure.Core.BinaryData FromSerializable<T>(T data, Azure.Core.ObjectSerializer serializer) { throw null; }
        public static Azure.Core.BinaryData FromStream(System.IO.Stream stream) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Core.BinaryData> FromStreamAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator System.ReadOnlyMemory<byte> (Azure.Core.BinaryData data) { throw null; }
        public System.IO.Stream ToStream() { throw null; }
        public override string ToString() { throw null; }
        public string ToString(System.Text.Encoding encoding) { throw null; }
    }
    public partial class DynamicJson : System.Dynamic.IDynamicMetaObjectProvider
    {
        public DynamicJson(string json) { }
        public DynamicJson(System.Text.Json.JsonElement element) { }
        public Azure.Core.DynamicJson this[int arrayIndex] { get { throw null; } set { } }
        public Azure.Core.DynamicJson this[string propertyName] { get { throw null; } set { } }
        public static Azure.Core.DynamicJson Array() { throw null; }
        public static Azure.Core.DynamicJson Array(params Azure.Core.DynamicJson[] values) { throw null; }
        public static Azure.Core.DynamicJson Array(System.Collections.Generic.IEnumerable<Azure.Core.DynamicJson> values) { throw null; }
        public static Azure.Core.DynamicJson Create(System.Text.Json.JsonElement element) { throw null; }
        public System.Threading.Tasks.Task<T> DeserializeAsync<T>(Azure.Core.ObjectSerializer serializer) { throw null; }
        public T Deserialize<T>(Azure.Core.ObjectSerializer serializer) { throw null; }
        public T Deserialize<T>(System.Text.Json.JsonSerializerOptions? options = null) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.Core.DynamicJson> EnumerateArray() { throw null; }
        public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.Core.DynamicJson>> EnumerateObject() { throw null; }
        public int GetArrayLength() { throw null; }
        public bool GetBoolean() { throw null; }
        public double GetDouble() { throw null; }
        public float GetFloat() { throw null; }
        public int GetIn32() { throw null; }
        public long GetLong() { throw null; }
        public Azure.Core.DynamicJson GetProperty(string name) { throw null; }
        public string? GetString() { throw null; }
        public static Azure.Core.DynamicJson Object() { throw null; }
        public static Azure.Core.DynamicJson Object(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, Azure.Core.DynamicJson>> values) { throw null; }
        public static explicit operator bool (Azure.Core.DynamicJson json) { throw null; }
        public static explicit operator double (Azure.Core.DynamicJson json) { throw null; }
        public static explicit operator int (Azure.Core.DynamicJson json) { throw null; }
        public static explicit operator long (Azure.Core.DynamicJson json) { throw null; }
        public static explicit operator bool? (Azure.Core.DynamicJson json) { throw null; }
        public static explicit operator double? (Azure.Core.DynamicJson json) { throw null; }
        public static explicit operator int? (Azure.Core.DynamicJson json) { throw null; }
        public static explicit operator long? (Azure.Core.DynamicJson json) { throw null; }
        public static explicit operator float? (Azure.Core.DynamicJson json) { throw null; }
        public static explicit operator float (Azure.Core.DynamicJson json) { throw null; }
        public static explicit operator string (Azure.Core.DynamicJson json) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (bool value) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (double value) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (int value) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (long value) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (bool? value) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (double? value) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (int? value) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (long? value) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (float? value) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (float value) { throw null; }
        public static implicit operator Azure.Core.DynamicJson (string? value) { throw null; }
        public static Azure.Core.DynamicJson Parse(string json) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Core.DynamicJson> SerializeAsync<T>(T value, Azure.Core.ObjectSerializer serializer) { throw null; }
        public static Azure.Core.DynamicJson Serialize<T>(T value, Azure.Core.ObjectSerializer serializer) { throw null; }
        public static Azure.Core.DynamicJson Serialize<T>(T value, System.Text.Json.JsonSerializerOptions? options = null) { throw null; }
        System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public System.Text.Json.JsonElement ToJsonElement() { throw null; }
        public override string ToString() { throw null; }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer) { }
    }
    public partial class JsonObjectSerializer : Azure.Core.ObjectSerializer
    {
        public JsonObjectSerializer() { }
        public JsonObjectSerializer(System.Text.Json.JsonSerializerOptions options) { }
        public override object Deserialize(System.IO.Stream stream, System.Type returnType) { throw null; }
        public override System.Threading.Tasks.ValueTask<object> DeserializeAsync(System.IO.Stream stream, System.Type returnType) { throw null; }
        public override void Serialize(System.IO.Stream stream, object? value, System.Type inputType) { }
        public override System.Threading.Tasks.ValueTask SerializeAsync(System.IO.Stream stream, object? value, System.Type inputType) { throw null; }
    }
    public abstract partial class ObjectSerializer
    {
        protected ObjectSerializer() { }
        public abstract object Deserialize(System.IO.Stream stream, System.Type returnType);
        public abstract System.Threading.Tasks.ValueTask<object> DeserializeAsync(System.IO.Stream stream, System.Type returnType);
        public abstract void Serialize(System.IO.Stream stream, object? value, System.Type inputType);
        public abstract System.Threading.Tasks.ValueTask SerializeAsync(System.IO.Stream stream, object? value, System.Type inputType);
    }
}
namespace Azure.Core.Spatial
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoBoundingBox : System.IEquatable<Azure.Core.Spatial.GeoBoundingBox>
    {
        private readonly int _dummyPrimitive;
        public GeoBoundingBox(Azure.Core.Spatial.GeographyBoundingBox boundingBox) { throw null; }
        public GeoBoundingBox(Azure.Core.Spatial.GeometryBoundingBox boundingBox) { throw null; }
        public GeoBoundingBox(double c1, double c2, double c3, double c4) { throw null; }
        public GeoBoundingBox(double c1, double c2, double? c3, double c4, double c5, double? c6) { throw null; }
        public Azure.Core.Spatial.GeographyBoundingBox AsGeographyBoundingBox() { throw null; }
        public Azure.Core.Spatial.GeometryBoundingBox AsGeometryBoundingBox() { throw null; }
        public bool Equals(Azure.Core.Spatial.GeoBoundingBox other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class GeoCollection : Azure.Core.Spatial.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoObject>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.Spatial.GeoObject>, System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.GeoObject>, System.Collections.IEnumerable
    {
        public GeoCollection(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoObject> geometries) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoCollection(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoObject> geometries, Azure.Core.Spatial.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public int Count { get { throw null; } }
        public Azure.Core.Spatial.GeoObject this[int index] { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.Spatial.GeoObject> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoCoordinate : System.IEquatable<Azure.Core.Spatial.GeoCoordinate>
    {
        private readonly int _dummyPrimitive;
        public GeoCoordinate(Azure.Core.Spatial.GeographyCoordinate coordinate) { throw null; }
        public GeoCoordinate(Azure.Core.Spatial.GeometryCoordinate coordinate) { throw null; }
        public double this[int index] { get { throw null; } }
        public Azure.Core.Spatial.GeographyCoordinate AsGeographyCoordinate() { throw null; }
        public Azure.Core.Spatial.GeometryCoordinate AsGeometryCoordinate() { throw null; }
        public bool Equals(Azure.Core.Spatial.GeoCoordinate other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Spatial.GeoCoordinate left, Azure.Core.Spatial.GeoCoordinate right) { throw null; }
        public static bool operator !=(Azure.Core.Spatial.GeoCoordinate left, Azure.Core.Spatial.GeoCoordinate right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeographyBoundingBox : System.IEquatable<Azure.Core.Spatial.GeographyBoundingBox>
    {
        private readonly int _dummyPrimitive;
        public GeographyBoundingBox(double west, double south, double east, double north) { throw null; }
        public GeographyBoundingBox(double west, double south, double east, double north, double? minAltitude, double? maxAltitude) { throw null; }
        public double East { get { throw null; } }
        public double? MaxAltitude { get { throw null; } }
        public double? MinAltitude { get { throw null; } }
        public double North { get { throw null; } }
        public double South { get { throw null; } }
        public double West { get { throw null; } }
        public bool Equals(Azure.Core.Spatial.GeographyBoundingBox other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeographyCoordinate
    {
        private readonly int _dummyPrimitive;
        public GeographyCoordinate(double longitude, double latitude) { throw null; }
        public GeographyCoordinate(double longitude, double latitude, double? altitude) { throw null; }
        public double? Altitude { get { throw null; } }
        public double Latitude { get { throw null; } }
        public double Longitude { get { throw null; } }
        public bool Equals(Azure.Core.Spatial.GeographyCoordinate other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Spatial.GeographyCoordinate left, Azure.Core.Spatial.GeographyCoordinate right) { throw null; }
        public static bool operator !=(Azure.Core.Spatial.GeographyCoordinate left, Azure.Core.Spatial.GeographyCoordinate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GeoJsonConverter : System.Text.Json.Serialization.JsonConverter<Azure.Core.Spatial.GeoObject>
    {
        public GeoJsonConverter() { }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override Azure.Core.Spatial.GeoObject Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, Azure.Core.Spatial.GeoObject value, System.Text.Json.JsonSerializerOptions options) { }
    }
    public sealed partial class GeoLine : Azure.Core.Spatial.GeoObject
    {
        public GeoLine(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeographyCoordinate> coordinates) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoLine(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeographyCoordinate> coordinates, Azure.Core.Spatial.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoLine(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeometryCoordinate> coordinates) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoLine(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeometryCoordinate> coordinates, Azure.Core.Spatial.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.GeoCoordinate> Coordinates { get { throw null; } }
    }
    public sealed partial class GeoLineCollection : Azure.Core.Spatial.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoLine>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.Spatial.GeoLine>, System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.GeoLine>, System.Collections.IEnumerable
    {
        public GeoLineCollection(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoLine> lines) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoLineCollection(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoLine> lines, Azure.Core.Spatial.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public int Count { get { throw null; } }
        public Azure.Core.Spatial.GeoLine this[int index] { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.Spatial.GeoLine> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeometryBoundingBox : System.IEquatable<Azure.Core.Spatial.GeographyBoundingBox>
    {
        private readonly int _dummyPrimitive;
        public GeometryBoundingBox(double minX, double minY, double maxX, double maxY) { throw null; }
        public GeometryBoundingBox(double minX, double minY, double maxX, double maxY, double? minZ, double? maxZ) { throw null; }
        public double MaxX { get { throw null; } }
        public double MaxY { get { throw null; } }
        public double? MaxZ { get { throw null; } }
        public double MinX { get { throw null; } }
        public double MinY { get { throw null; } }
        public double? MinZ { get { throw null; } }
        public bool Equals(Azure.Core.Spatial.GeographyBoundingBox other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeometryCoordinate
    {
        private readonly int _dummyPrimitive;
        public GeometryCoordinate(double x, double y) { throw null; }
        public GeometryCoordinate(double x, double y, double? z) { throw null; }
        public double X { get { throw null; } }
        public double Y { get { throw null; } }
        public double? Z { get { throw null; } }
        public bool Equals(Azure.Core.Spatial.GeometryCoordinate other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Spatial.GeometryCoordinate left, Azure.Core.Spatial.GeometryCoordinate right) { throw null; }
        public static bool operator !=(Azure.Core.Spatial.GeometryCoordinate left, Azure.Core.Spatial.GeometryCoordinate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class GeoMultiPolygon : Azure.Core.Spatial.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoPolygon>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.Spatial.GeoPolygon>, System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.GeoPolygon>, System.Collections.IEnumerable
    {
        public GeoMultiPolygon(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoPolygon> polygons) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoMultiPolygon(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoPolygon> polygons, Azure.Core.Spatial.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public int Count { get { throw null; } }
        public Azure.Core.Spatial.GeoPolygon this[int index] { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.Spatial.GeoPolygon> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class GeoObject
    {
        protected GeoObject(Azure.Core.Spatial.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?> AdditionalProperties { get { throw null; } }
        public Azure.Core.Spatial.GeoBoundingBox? BoundingBox { get { throw null; } }
        public static Azure.Core.Spatial.GeoObject Parse(string json) { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class GeoPoint : Azure.Core.Spatial.GeoObject
    {
        public GeoPoint(Azure.Core.Spatial.GeographyCoordinate coordinate) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPoint(Azure.Core.Spatial.GeographyCoordinate coordinate, Azure.Core.Spatial.GeographyBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPoint(Azure.Core.Spatial.GeometryCoordinate coordinate) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPoint(Azure.Core.Spatial.GeometryCoordinate coordinate, Azure.Core.Spatial.GeometryBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public Azure.Core.Spatial.GeoCoordinate Coordinate { get { throw null; } }
    }
    public sealed partial class GeoPointCollection : Azure.Core.Spatial.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoPoint>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.Spatial.GeoPoint>, System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.GeoPoint>, System.Collections.IEnumerable
    {
        public GeoPointCollection(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoPoint> points) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPointCollection(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoPoint> points, Azure.Core.Spatial.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public int Count { get { throw null; } }
        public Azure.Core.Spatial.GeoPoint this[int index] { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.Spatial.GeoPoint> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public sealed partial class GeoPolygon : Azure.Core.Spatial.GeoObject
    {
        public GeoPolygon(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoLine> rings) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPolygon(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeoLine> rings, Azure.Core.Spatial.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeoBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.GeoLine> Rings { get { throw null; } }
    }
}
