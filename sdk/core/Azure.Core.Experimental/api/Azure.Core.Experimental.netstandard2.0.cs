namespace Azure.Core
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BinaryData
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BinaryData(System.ReadOnlySpan<byte> data) { throw null; }
        public BinaryData(string data) { throw null; }
        public System.ReadOnlyMemory<byte> Bytes { get { throw null; } }
        public System.Threading.Tasks.ValueTask<T> DeserializeAsync<T>(Azure.Core.Serialization.ObjectSerializer serializer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.ValueTask<T> DeserializeAsync<T>(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public T Deserialize<T>(Azure.Core.Serialization.ObjectSerializer serializer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public T Deserialize<T>(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public static Azure.Core.BinaryData FromMemory(System.ReadOnlyMemory<byte> data) { throw null; }
        public static Azure.Core.BinaryData FromStream(System.IO.Stream stream) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Core.BinaryData> FromStreamAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator System.ReadOnlyMemory<byte> (Azure.Core.BinaryData data) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Core.BinaryData> SerializeAsync<T>(T data, Azure.Core.Serialization.ObjectSerializer serializer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Core.BinaryData> SerializeAsync<T>(T data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.BinaryData Serialize<T>(T data, Azure.Core.Serialization.ObjectSerializer serializer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.BinaryData Serialize<T>(T data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.IO.Stream ToStream() { throw null; }
        public override string ToString() { throw null; }
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
        public System.Threading.Tasks.Task<T> DeserializeAsync<T>(Azure.Core.Serialization.ObjectSerializer serializer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public T Deserialize<T>(Azure.Core.Serialization.ObjectSerializer serializer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static System.Threading.Tasks.Task<Azure.Core.DynamicJson> SerializeAsync<T>(T value, Azure.Core.Serialization.ObjectSerializer serializer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.DynamicJson Serialize<T>(T value, Azure.Core.Serialization.ObjectSerializer serializer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.DynamicJson Serialize<T>(T value, System.Text.Json.JsonSerializerOptions? options = null) { throw null; }
        System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public System.Text.Json.JsonElement ToJsonElement() { throw null; }
        public override string ToString() { throw null; }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer) { }
    }
}
namespace Azure.Core.GeoJson
{
    public sealed partial class GeoBoundingBox : System.IEquatable<Azure.Core.GeoJson.GeoBoundingBox>
    {
        public GeoBoundingBox(double west, double south, double east, double north) { }
        public GeoBoundingBox(double west, double south, double east, double north, double? minAltitude, double? maxAltitude) { }
        public double East { get { throw null; } }
        public double? MaxAltitude { get { throw null; } }
        public double? MinAltitude { get { throw null; } }
        public double North { get { throw null; } }
        public double South { get { throw null; } }
        public double West { get { throw null; } }
        public bool Equals(Azure.Core.GeoJson.GeoBoundingBox other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
    }
    public sealed partial class GeoCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoObject>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoObject>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoObject>, System.Collections.IEnumerable
    {
        public GeoCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoObject> geometries) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoObject> geometries, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoObject this[int index] { get { throw null; } }
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
    public sealed partial class GeoLine : Azure.Core.GeoJson.GeoObject
    {
        public GeoLine(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPosition> coordinates) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoLine(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPosition> coordinates, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoPosition> Positions { get { throw null; } }
    }
    public sealed partial class GeoLineCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLine>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoLine>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoLine>, System.Collections.IEnumerable
    {
        public GeoLineCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLine> lines) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoLineCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLine> lines, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoLine this[int index] { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoLine> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class GeoObject
    {
        protected GeoObject(Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?> AdditionalProperties { get { throw null; } }
        public Azure.Core.GeoJson.GeoBoundingBox? BoundingBox { get { throw null; } }
        public static Azure.Core.GeoJson.GeoObject Parse(string json) { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class GeoPoint : Azure.Core.GeoJson.GeoObject
    {
        public GeoPoint(Azure.Core.GeoJson.GeoPosition position) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPoint(Azure.Core.GeoJson.GeoPosition position, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPoint(double longitude, double latitude) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPoint(double longitude, double latitude, double? altitude) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public Azure.Core.GeoJson.GeoPosition Position { get { throw null; } }
    }
    public sealed partial class GeoPointCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPoint>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoPoint>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoPoint>, System.Collections.IEnumerable
    {
        public GeoPointCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPoint> points) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPointCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPoint> points, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoPoint this[int index] { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoPoint> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public sealed partial class GeoPolygon : Azure.Core.GeoJson.GeoObject
    {
        public GeoPolygon(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLine> rings) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPolygon(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoLine> rings, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoLine> Rings { get { throw null; } }
    }
    public sealed partial class GeoPolygonCollection : Azure.Core.GeoJson.GeoObject, System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPolygon>, System.Collections.Generic.IReadOnlyCollection<Azure.Core.GeoJson.GeoPolygon>, System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoPolygon>, System.Collections.IEnumerable
    {
        public GeoPolygonCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPolygon> polygons) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public GeoPolygonCollection(System.Collections.Generic.IEnumerable<Azure.Core.GeoJson.GeoPolygon> polygons, Azure.Core.GeoJson.GeoBoundingBox? boundingBox, System.Collections.Generic.IReadOnlyDictionary<string, object?> additionalProperties) : base (default(Azure.Core.GeoJson.GeoBoundingBox), default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        public int Count { get { throw null; } }
        public Azure.Core.GeoJson.GeoPolygon this[int index] { get { throw null; } }
        public System.Collections.Generic.IEnumerator<Azure.Core.GeoJson.GeoPolygon> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoPosition
    {
        private readonly int _dummyPrimitive;
        public GeoPosition(double longitude, double latitude) { throw null; }
        public GeoPosition(double longitude, double latitude, double? altitude) { throw null; }
        public double? Altitude { get { throw null; } }
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
