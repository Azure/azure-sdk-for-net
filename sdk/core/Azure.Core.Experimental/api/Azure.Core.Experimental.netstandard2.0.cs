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
    public sealed partial class CollectionGeometry : Azure.Core.Spatial.Geometry
    {
        public CollectionGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.Geometry> geometries) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public CollectionGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.Geometry> geometries, Azure.Core.Spatial.GeometryBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.Geometry> Geometries { get { throw null; } }
    }
    public abstract partial class Geometry
    {
        protected Geometry(Azure.Core.Spatial.GeometryBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?> AdditionalProperties { get { throw null; } }
        public Azure.Core.Spatial.GeometryBoundingBox? BoundingBox { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeometryBoundingBox : System.IEquatable<Azure.Core.Spatial.GeometryBoundingBox>
    {
        private readonly int _dummyPrimitive;
        public GeometryBoundingBox(double west, double south, double east, double north) { throw null; }
        public GeometryBoundingBox(double west, double south, double east, double north, double? minAltitude, double? maxAltitude) { throw null; }
        public double East { get { throw null; } }
        public double? MaxAltitude { get { throw null; } }
        public double? MinAltitude { get { throw null; } }
        public double North { get { throw null; } }
        public double South { get { throw null; } }
        public double West { get { throw null; } }
        public bool Equals(Azure.Core.Spatial.GeometryBoundingBox other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public partial class GeometryJsonConverter : System.Text.Json.Serialization.JsonConverter<Azure.Core.Spatial.Geometry>
    {
        public GeometryJsonConverter() { }
        public override bool CanConvert(System.Type typeToConvert) { throw null; }
        public override Azure.Core.Spatial.Geometry Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options) { throw null; }
        public override void Write(System.Text.Json.Utf8JsonWriter writer, Azure.Core.Spatial.Geometry value, System.Text.Json.JsonSerializerOptions options) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeometryPosition : System.IEquatable<Azure.Core.Spatial.GeometryPosition>
    {
        private readonly int _dummyPrimitive;
        public GeometryPosition(double longitude, double latitude) { throw null; }
        public GeometryPosition(double longitude, double latitude, double? altitude) { throw null; }
        public double? Altitude { get { throw null; } }
        public double Latitude { get { throw null; } }
        public double Longitude { get { throw null; } }
        public bool Equals(Azure.Core.Spatial.GeometryPosition other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Spatial.GeometryPosition left, Azure.Core.Spatial.GeometryPosition right) { throw null; }
        public static bool operator !=(Azure.Core.Spatial.GeometryPosition left, Azure.Core.Spatial.GeometryPosition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class LineGeometry : Azure.Core.Spatial.Geometry
    {
        public LineGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeometryPosition> positions) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public LineGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.GeometryPosition> positions, Azure.Core.Spatial.GeometryBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.GeometryPosition> Positions { get { throw null; } }
    }
    public sealed partial class MultiLineGeometry : Azure.Core.Spatial.Geometry
    {
        public MultiLineGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.LineGeometry> lines) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public MultiLineGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.LineGeometry> lines, Azure.Core.Spatial.GeometryBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.LineGeometry> Lines { get { throw null; } }
    }
    public sealed partial class MultiPointGeometry : Azure.Core.Spatial.Geometry
    {
        public MultiPointGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.PointGeometry> points) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public MultiPointGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.PointGeometry> points, Azure.Core.Spatial.GeometryBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.PointGeometry> Points { get { throw null; } }
    }
    public sealed partial class MultiPolygonGeometry : Azure.Core.Spatial.Geometry
    {
        public MultiPolygonGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.PolygonGeometry> polygons) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public MultiPolygonGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.PolygonGeometry> polygons, Azure.Core.Spatial.GeometryBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.PolygonGeometry> Polygons { get { throw null; } }
    }
    public sealed partial class PointGeometry : Azure.Core.Spatial.Geometry
    {
        public PointGeometry(Azure.Core.Spatial.GeometryPosition position) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public PointGeometry(Azure.Core.Spatial.GeometryPosition position, Azure.Core.Spatial.GeometryBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public Azure.Core.Spatial.GeometryPosition Position { get { throw null; } }
    }
    public sealed partial class PolygonGeometry : Azure.Core.Spatial.Geometry
    {
        public PolygonGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.LineGeometry> rings) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public PolygonGeometry(System.Collections.Generic.IEnumerable<Azure.Core.Spatial.LineGeometry> rings, Azure.Core.Spatial.GeometryBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.Spatial.GeometryBoundingBox?), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.Spatial.LineGeometry> Rings { get { throw null; } }
    }
}
