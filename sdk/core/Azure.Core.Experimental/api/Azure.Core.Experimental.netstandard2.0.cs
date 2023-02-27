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
        public static dynamic ToDynamic(this System.BinaryData data, Azure.Core.Dynamic.DynamicJsonNameMapping propertyNameCasing) { throw null; }
        public static dynamic ToDynamic(this System.BinaryData data, Azure.Core.Dynamic.DynamicJsonOptions options) { throw null; }
    }
    public abstract partial class DynamicData
    {
        protected DynamicData() { }
        internal abstract void WriteTo(System.IO.Stream stream);
        public static void WriteTo(System.IO.Stream stream, Azure.Core.Dynamic.DynamicData data) { }
    }
    public sealed partial class DynamicJson : Azure.Core.Dynamic.DynamicData, System.Dynamic.IDynamicMetaObjectProvider, System.IDisposable
    {
        internal DynamicJson() { }
        public void Dispose() { }
        public static implicit operator bool (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        public static implicit operator double (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        public static implicit operator int (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        public static implicit operator long (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        public static implicit operator bool? (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        public static implicit operator double? (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        public static implicit operator int? (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        public static implicit operator long? (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        public static implicit operator float? (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        public static implicit operator float (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        public static implicit operator string (Azure.Core.Dynamic.DynamicJson value) { throw null; }
        System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public override string ToString() { throw null; }
        [System.Diagnostics.DebuggerDisplayAttribute("{Current,nq}")]
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct ArrayEnumerator : System.Collections.Generic.IEnumerable<Azure.Core.Dynamic.DynamicJson>, System.Collections.Generic.IEnumerator<Azure.Core.Dynamic.DynamicJson>, System.Collections.IEnumerable, System.Collections.IEnumerator, System.IDisposable
        {
            private object _dummy;
            private int _dummyPrimitive;
            public Azure.Core.Dynamic.DynamicJson Current { get { throw null; } }
            object System.Collections.IEnumerator.Current { get { throw null; } }
            public void Dispose() { }
            public Azure.Core.Dynamic.DynamicJson.ArrayEnumerator GetEnumerator() { throw null; }
            public bool MoveNext() { throw null; }
            public void Reset() { }
            System.Collections.Generic.IEnumerator<Azure.Core.Dynamic.DynamicJson> System.Collections.Generic.IEnumerable<Azure.Core.Dynamic.DynamicJson>.GetEnumerator() { throw null; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        }
    }
    public enum DynamicJsonNameMapping
    {
        None = 0,
        PascalCaseGetters = 1,
        PascalCaseGettersCamelCaseSetters = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct DynamicJsonOptions
    {
        private int _dummyPrimitive;
        public DynamicJsonOptions() { throw null; }
        public Azure.Core.Dynamic.DynamicJsonNameMapping PropertyNameCasing { get { throw null; } set { } }
    }
}
namespace Azure.Core.Json
{
    public sealed partial class MutableJsonDocument : System.IDisposable
    {
        internal MutableJsonDocument() { }
        public Azure.Core.Json.MutableJsonElement RootElement { get { throw null; } }
        public void Dispose() { }
        public static Azure.Core.Json.MutableJsonDocument Parse(System.BinaryData utf8Json) { throw null; }
        public static Azure.Core.Json.MutableJsonDocument Parse(string json) { throw null; }
        public void WriteTo(System.IO.Stream stream, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MutableJsonElement
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public System.Text.Json.JsonValueKind ValueKind { get { throw null; } }
        public Azure.Core.Json.MutableJsonElement.ArrayEnumerator EnumerateArray() { throw null; }
        public bool GetBoolean() { throw null; }
        public double GetDouble() { throw null; }
        public int GetInt32() { throw null; }
        public long GetInt64() { throw null; }
        public Azure.Core.Json.MutableJsonElement GetProperty(string name) { throw null; }
        public float GetSingle() { throw null; }
        public string? GetString() { throw null; }
        public void RemoveProperty(string name) { }
        public void Set(Azure.Core.Json.MutableJsonElement value) { }
        public void Set(bool value) { }
        public void Set(double value) { }
        public void Set(int value) { }
        public void Set(long value) { }
        public void Set(object value) { }
        public void Set(float value) { }
        public void Set(string value) { }
        public Azure.Core.Json.MutableJsonElement SetProperty(string name, object value) { throw null; }
        public override string ToString() { throw null; }
        public bool TryGetProperty(string name, out Azure.Core.Json.MutableJsonElement value) { throw null; }
        [System.Diagnostics.DebuggerDisplayAttribute("{Current,nq}")]
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct ArrayEnumerator : System.Collections.Generic.IEnumerable<Azure.Core.Json.MutableJsonElement>, System.Collections.Generic.IEnumerator<Azure.Core.Json.MutableJsonElement>, System.Collections.IEnumerable, System.Collections.IEnumerator, System.IDisposable
        {
            private object _dummy;
            private int _dummyPrimitive;
            public Azure.Core.Json.MutableJsonElement Current { get { throw null; } }
            object System.Collections.IEnumerator.Current { get { throw null; } }
            public void Dispose() { }
            public Azure.Core.Json.MutableJsonElement.ArrayEnumerator GetEnumerator() { throw null; }
            public bool MoveNext() { throw null; }
            public void Reset() { }
            System.Collections.Generic.IEnumerator<Azure.Core.Json.MutableJsonElement> System.Collections.Generic.IEnumerable<Azure.Core.Json.MutableJsonElement>.GetEnumerator() { throw null; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        }
    }
}
