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
namespace Azure.Core.Dynamic
{
    public static partial class BinaryDataExtensions
    {
        public static dynamic ToDynamic(this System.BinaryData data) { throw null; }
    }
    public abstract partial class DynamicData
    {
        protected DynamicData() { }
        internal abstract void WriteTo(System.Text.Json.Utf8JsonWriter writer);
        public static void WriteTo(System.Text.Json.Utf8JsonWriter writer, Azure.Core.Dynamic.DynamicData data) { }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{DebuggerDisplay,nq}")]
    public partial class JsonData : Azure.Core.Dynamic.DynamicData, System.Dynamic.IDynamicMetaObjectProvider, System.IEquatable<Azure.Core.Dynamic.JsonData>
    {
        internal JsonData() { }
        public bool Equals(Azure.Core.Dynamic.JsonData other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Dynamic.JsonData? left, bool right) { throw null; }
        public static bool operator ==(Azure.Core.Dynamic.JsonData? left, double right) { throw null; }
        public static bool operator ==(Azure.Core.Dynamic.JsonData? left, int right) { throw null; }
        public static bool operator ==(Azure.Core.Dynamic.JsonData? left, long right) { throw null; }
        public static bool operator ==(Azure.Core.Dynamic.JsonData? left, float right) { throw null; }
        public static bool operator ==(Azure.Core.Dynamic.JsonData? left, string? right) { throw null; }
        public static bool operator ==(bool left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static bool operator ==(double left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static bool operator ==(int left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static bool operator ==(long left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static bool operator ==(float left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static bool operator ==(string? left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static implicit operator bool (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static implicit operator double (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static implicit operator int (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static implicit operator long (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static implicit operator bool? (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static implicit operator double? (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static implicit operator int? (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static implicit operator long? (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static implicit operator float? (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static implicit operator float (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static implicit operator string (Azure.Core.Dynamic.JsonData json) { throw null; }
        public static bool operator !=(Azure.Core.Dynamic.JsonData? left, bool right) { throw null; }
        public static bool operator !=(Azure.Core.Dynamic.JsonData? left, double right) { throw null; }
        public static bool operator !=(Azure.Core.Dynamic.JsonData? left, int right) { throw null; }
        public static bool operator !=(Azure.Core.Dynamic.JsonData? left, long right) { throw null; }
        public static bool operator !=(Azure.Core.Dynamic.JsonData? left, float right) { throw null; }
        public static bool operator !=(Azure.Core.Dynamic.JsonData? left, string? right) { throw null; }
        public static bool operator !=(bool left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static bool operator !=(double left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static bool operator !=(int left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static bool operator !=(long left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static bool operator !=(float left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        public static bool operator !=(string? left, Azure.Core.Dynamic.JsonData? right) { throw null; }
        System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public override string ToString() { throw null; }
    }
}
