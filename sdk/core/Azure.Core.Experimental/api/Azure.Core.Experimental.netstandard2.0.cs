namespace Azure
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Value
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Value(System.ArraySegment<byte> segment) { throw null; }
        public Value(System.ArraySegment<char> segment) { throw null; }
        public Value(bool value) { throw null; }
        public Value(byte value) { throw null; }
        public Value(char value) { throw null; }
        public Value(System.DateTime value) { throw null; }
        public Value(System.DateTimeOffset value) { throw null; }
        public Value(double value) { throw null; }
        public Value(short value) { throw null; }
        public Value(int value) { throw null; }
        public Value(long value) { throw null; }
        public Value(bool? value) { throw null; }
        public Value(byte? value) { throw null; }
        public Value(char? value) { throw null; }
        public Value(System.DateTimeOffset? value) { throw null; }
        public Value(System.DateTime? value) { throw null; }
        public Value(double? value) { throw null; }
        public Value(short? value) { throw null; }
        public Value(int? value) { throw null; }
        public Value(long? value) { throw null; }
        public Value(sbyte? value) { throw null; }
        public Value(float? value) { throw null; }
        public Value(ushort? value) { throw null; }
        public Value(uint? value) { throw null; }
        public Value(ulong? value) { throw null; }
        public Value(object? value) { throw null; }
        public Value(sbyte value) { throw null; }
        public Value(float value) { throw null; }
        public Value(ushort value) { throw null; }
        public Value(uint value) { throw null; }
        public Value(ulong value) { throw null; }
        public System.Type? Type { get { throw null; } }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]public T As<T>() { throw null; }
        public static Azure.Value Create<T>(T value) { throw null; }
        public static explicit operator System.ArraySegment<byte> (in Azure.Value value) { throw null; }
        public static explicit operator System.ArraySegment<char> (in Azure.Value value) { throw null; }
        public static explicit operator bool (in Azure.Value value) { throw null; }
        public static explicit operator byte (in Azure.Value value) { throw null; }
        public static explicit operator char (in Azure.Value value) { throw null; }
        public static explicit operator System.DateTime (in Azure.Value value) { throw null; }
        public static explicit operator System.DateTimeOffset (in Azure.Value value) { throw null; }
        public static explicit operator decimal (in Azure.Value value) { throw null; }
        public static explicit operator double (in Azure.Value value) { throw null; }
        public static explicit operator short (in Azure.Value value) { throw null; }
        public static explicit operator int (in Azure.Value value) { throw null; }
        public static explicit operator long (in Azure.Value value) { throw null; }
        public static explicit operator bool? (in Azure.Value value) { throw null; }
        public static explicit operator byte? (in Azure.Value value) { throw null; }
        public static explicit operator char? (in Azure.Value value) { throw null; }
        public static explicit operator System.DateTimeOffset? (in Azure.Value value) { throw null; }
        public static explicit operator System.DateTime? (in Azure.Value value) { throw null; }
        public static explicit operator decimal? (in Azure.Value value) { throw null; }
        public static explicit operator double? (in Azure.Value value) { throw null; }
        public static explicit operator short? (in Azure.Value value) { throw null; }
        public static explicit operator int? (in Azure.Value value) { throw null; }
        public static explicit operator long? (in Azure.Value value) { throw null; }
        public static explicit operator sbyte? (in Azure.Value value) { throw null; }
        public static explicit operator float? (in Azure.Value value) { throw null; }
        public static explicit operator ushort? (in Azure.Value value) { throw null; }
        public static explicit operator uint? (in Azure.Value value) { throw null; }
        public static explicit operator ulong? (in Azure.Value value) { throw null; }
        public static explicit operator sbyte (in Azure.Value value) { throw null; }
        public static explicit operator float (in Azure.Value value) { throw null; }
        public static explicit operator ushort (in Azure.Value value) { throw null; }
        public static explicit operator uint (in Azure.Value value) { throw null; }
        public static explicit operator ulong (in Azure.Value value) { throw null; }
        public static implicit operator Azure.Value (System.ArraySegment<byte> value) { throw null; }
        public static implicit operator Azure.Value (System.ArraySegment<char> value) { throw null; }
        public static implicit operator Azure.Value (bool value) { throw null; }
        public static implicit operator Azure.Value (byte value) { throw null; }
        public static implicit operator Azure.Value (char value) { throw null; }
        public static implicit operator Azure.Value (System.DateTime value) { throw null; }
        public static implicit operator Azure.Value (System.DateTimeOffset value) { throw null; }
        public static implicit operator Azure.Value (decimal value) { throw null; }
        public static implicit operator Azure.Value (double value) { throw null; }
        public static implicit operator Azure.Value (short value) { throw null; }
        public static implicit operator Azure.Value (int value) { throw null; }
        public static implicit operator Azure.Value (long value) { throw null; }
        public static implicit operator Azure.Value (bool? value) { throw null; }
        public static implicit operator Azure.Value (byte? value) { throw null; }
        public static implicit operator Azure.Value (char? value) { throw null; }
        public static implicit operator Azure.Value (System.DateTimeOffset? value) { throw null; }
        public static implicit operator Azure.Value (System.DateTime? value) { throw null; }
        public static implicit operator Azure.Value (decimal? value) { throw null; }
        public static implicit operator Azure.Value (double? value) { throw null; }
        public static implicit operator Azure.Value (short? value) { throw null; }
        public static implicit operator Azure.Value (int? value) { throw null; }
        public static implicit operator Azure.Value (long? value) { throw null; }
        public static implicit operator Azure.Value (sbyte? value) { throw null; }
        public static implicit operator Azure.Value (float? value) { throw null; }
        public static implicit operator Azure.Value (ushort? value) { throw null; }
        public static implicit operator Azure.Value (uint? value) { throw null; }
        public static implicit operator Azure.Value (ulong? value) { throw null; }
        public static implicit operator Azure.Value (sbyte value) { throw null; }
        public static implicit operator Azure.Value (float value) { throw null; }
        public static implicit operator Azure.Value (ushort value) { throw null; }
        public static implicit operator Azure.Value (uint value) { throw null; }
        public static implicit operator Azure.Value (ulong value) { throw null; }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]public bool TryGetValue<T>(out T value) { throw null; }
    }
}
namespace Azure.Core
{
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
}
