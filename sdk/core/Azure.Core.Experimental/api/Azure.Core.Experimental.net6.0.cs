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
        public static dynamic ToDynamic(this System.BinaryData data, Azure.Core.Dynamic.DynamicDataNameMapping propertyNameCasing) { throw null; }
        public static dynamic ToDynamic(this System.BinaryData data, Azure.Core.Dynamic.DynamicDataOptions options) { throw null; }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{DebuggerDisplay,nq}")]
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(System.Text.Json.Serialization.JsonConverter))]
    public sealed partial class DynamicData : System.Dynamic.IDynamicMetaObjectProvider, System.IDisposable
    {
        internal DynamicData() { }
        public void Dispose() { }
        public static implicit operator bool (Azure.Core.Dynamic.DynamicData value) { throw null; }
        public static implicit operator double (Azure.Core.Dynamic.DynamicData value) { throw null; }
        public static implicit operator int (Azure.Core.Dynamic.DynamicData value) { throw null; }
        public static implicit operator long (Azure.Core.Dynamic.DynamicData value) { throw null; }
        public static implicit operator bool? (Azure.Core.Dynamic.DynamicData value) { throw null; }
        public static implicit operator double? (Azure.Core.Dynamic.DynamicData value) { throw null; }
        public static implicit operator int? (Azure.Core.Dynamic.DynamicData value) { throw null; }
        public static implicit operator long? (Azure.Core.Dynamic.DynamicData value) { throw null; }
        public static implicit operator float? (Azure.Core.Dynamic.DynamicData value) { throw null; }
        public static implicit operator float (Azure.Core.Dynamic.DynamicData value) { throw null; }
        public static implicit operator string (Azure.Core.Dynamic.DynamicData value) { throw null; }
        System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(System.Linq.Expressions.Expression parameter) { throw null; }
        public override string? ToString() { throw null; }
        [System.Diagnostics.DebuggerDisplayAttribute("{Current,nq}")]
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct ArrayEnumerator : System.Collections.Generic.IEnumerable<Azure.Core.Dynamic.DynamicData>, System.Collections.Generic.IEnumerator<Azure.Core.Dynamic.DynamicData>, System.Collections.IEnumerable, System.Collections.IEnumerator, System.IDisposable
        {
            private object _dummy;
            private int _dummyPrimitive;
            public Azure.Core.Dynamic.DynamicData Current { get { throw null; } }
            object System.Collections.IEnumerator.Current { get { throw null; } }
            public void Dispose() { }
            public Azure.Core.Dynamic.DynamicData.ArrayEnumerator GetEnumerator() { throw null; }
            public bool MoveNext() { throw null; }
            public void Reset() { }
            System.Collections.Generic.IEnumerator<Azure.Core.Dynamic.DynamicData> System.Collections.Generic.IEnumerable<Azure.Core.Dynamic.DynamicData>.GetEnumerator() { throw null; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        }
        [System.Diagnostics.DebuggerDisplayAttribute("{Current,nq}")]
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct ObjectEnumerator : System.Collections.Generic.IEnumerable<Azure.Core.Dynamic.DynamicDataProperty>, System.Collections.Generic.IEnumerator<Azure.Core.Dynamic.DynamicDataProperty>, System.Collections.IEnumerable, System.Collections.IEnumerator, System.IDisposable
        {
            private object _dummy;
            private int _dummyPrimitive;
            public Azure.Core.Dynamic.DynamicDataProperty Current { get { throw null; } }
            object System.Collections.IEnumerator.Current { get { throw null; } }
            public void Dispose() { }
            public Azure.Core.Dynamic.DynamicData.ObjectEnumerator GetEnumerator() { throw null; }
            public bool MoveNext() { throw null; }
            public void Reset() { }
            System.Collections.Generic.IEnumerator<Azure.Core.Dynamic.DynamicDataProperty> System.Collections.Generic.IEnumerable<Azure.Core.Dynamic.DynamicDataProperty>.GetEnumerator() { throw null; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        }
    }
    public enum DynamicDataNameMapping
    {
        None = 0,
        PascalCaseGetters = 1,
        PascalCaseGettersCamelCaseSetters = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public partial struct DynamicDataOptions
    {
        private int _dummyPrimitive;
        public static readonly Azure.Core.Dynamic.DynamicDataOptions AzureDefault;
        public DynamicDataOptions() { throw null; }
        public Azure.Core.Dynamic.DynamicDataNameMapping PropertyNameCasing { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicDataProperty
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public string Name { get { throw null; } }
        public Azure.Core.Dynamic.DynamicData Value { get { throw null; } }
    }
    public abstract partial class ObjectDocument : System.IDisposable
    {
        protected ObjectDocument() { }
        public abstract T As<T>(object element);
        public abstract void Dispose();
        public abstract Azure.Core.Dynamic.ObjectElement GetIndexElement(object element, int index);
        public abstract bool HasValue(object element);
        public abstract void Set(object element, object value);
        public abstract Azure.Core.Dynamic.ObjectElement SetProperty(object element, string name, object value);
        public abstract string? ToString(object element);
        public abstract bool TryGetArrayLength(object element, out int length);
        public abstract bool TryGetBoolean(object element, out bool value);
        public abstract bool TryGetDouble(object element, out double value);
        public abstract bool TryGetInt64(object element, out long value);
        public abstract bool TryGetProperty(object element, string name, out Azure.Core.Dynamic.ObjectElement value);
        public abstract bool TryGetPropertyNames(object element, out System.Collections.Generic.IEnumerable<string> enumerator);
        public abstract bool TryGetString(object element, out string? value);
        public abstract void WriteTo(object element, System.IO.Stream stream);
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObjectElement
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObjectElement(Azure.Core.Dynamic.ObjectDocument document, object element) { throw null; }
        public bool HasValue { get { throw null; } }
        public T As<T>() { throw null; }
        public void DisposeRoot() { }
        public int GetArrayLength() { throw null; }
        public bool GetBoolean() { throw null; }
        public double GetDouble() { throw null; }
        public Azure.Core.Dynamic.ObjectElement GetIndexElement(int index) { throw null; }
        public int GetInt32() { throw null; }
        public long GetInt64() { throw null; }
        public Azure.Core.Dynamic.ObjectElement GetProperty(string name) { throw null; }
        public System.Collections.Generic.IEnumerable<string> GetPropertyNames() { throw null; }
        public float GetSingle() { throw null; }
        public string? GetString() { throw null; }
        public void Set(object value) { }
        public Azure.Core.Dynamic.ObjectElement SetProperty(string name, object value) { throw null; }
        public override string? ToString() { throw null; }
        public bool TryGetArrayLength(out int length) { throw null; }
        public bool TryGetProperty(string name, out Azure.Core.Dynamic.ObjectElement value) { throw null; }
        public bool TryGetPropertyNames(out System.Collections.Generic.IEnumerable<string> enumerator) { throw null; }
        public void WriteTo(System.IO.Stream stream) { }
    }
}
namespace Azure.Core.Json
{
    public sealed partial class MutableJsonDocument : Azure.Core.Dynamic.ObjectDocument, System.IDisposable
    {
        internal MutableJsonDocument() { }
        public Azure.Core.Json.MutableJsonElement RootElement { get { throw null; } }
        public override T As<T>(object element) { throw null; }
        public override void Dispose() { }
        public override Azure.Core.Dynamic.ObjectElement GetIndexElement(object element, int index) { throw null; }
        public override bool HasValue(object element) { throw null; }
        public static Azure.Core.Json.MutableJsonDocument Parse(System.BinaryData utf8Json) { throw null; }
        public static Azure.Core.Json.MutableJsonDocument Parse(string json) { throw null; }
        public override void Set(object element, object value) { }
        public override Azure.Core.Dynamic.ObjectElement SetProperty(object element, string name, object value) { throw null; }
        public override string? ToString(object element) { throw null; }
        public override bool TryGetArrayLength(object element, out int length) { throw null; }
        public override bool TryGetBoolean(object element, out bool value) { throw null; }
        public override bool TryGetDouble(object element, out double value) { throw null; }
        public override bool TryGetInt64(object element, out long value) { throw null; }
        public override bool TryGetProperty(object element, string name, out Azure.Core.Dynamic.ObjectElement value) { throw null; }
        public override bool TryGetPropertyNames(object element, out System.Collections.Generic.IEnumerable<string> enumerable) { throw null; }
        public override bool TryGetString(object element, out string? value) { throw null; }
        public void WriteTo(System.IO.Stream stream, System.Buffers.StandardFormat format = default(System.Buffers.StandardFormat)) { }
        public override void WriteTo(object element, System.IO.Stream stream) { }
    }
    [System.Diagnostics.DebuggerDisplayAttribute("{DebuggerDisplay,nq}")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MutableJsonElement
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public System.Text.Json.JsonValueKind ValueKind { get { throw null; } }
        public Azure.Core.Json.MutableJsonElement.ArrayEnumerator EnumerateArray() { throw null; }
        public Azure.Core.Json.MutableJsonElement.ObjectEnumerator EnumerateObject() { throw null; }
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
        [System.Diagnostics.DebuggerDisplayAttribute("{Current,nq}")]
        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public partial struct ObjectEnumerator : System.Collections.Generic.IEnumerable<(string, Azure.Core.Json.MutableJsonElement)>, System.Collections.Generic.IEnumerator<(string, Azure.Core.Json.MutableJsonElement)>, System.Collections.IEnumerable, System.Collections.IEnumerator, System.IDisposable
        {
            private object _dummy;
            private int _dummyPrimitive;
            public (string Name, Azure.Core.Json.MutableJsonElement Value) Current { get { throw null; } }
            object System.Collections.IEnumerator.Current { get { throw null; } }
            public void Dispose() { }
            public Azure.Core.Json.MutableJsonElement.ObjectEnumerator GetEnumerator() { throw null; }
            public bool MoveNext() { throw null; }
            public void Reset() { }
            System.Collections.Generic.IEnumerator<(string Name, Azure.Core.Json.MutableJsonElement Value)> System.Collections.Generic.IEnumerable<(string, Azure.Core.Json.MutableJsonElement)>.GetEnumerator() { throw null; }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        }
    }
}
