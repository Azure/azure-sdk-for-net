namespace Azure
{
    public partial class CloudMachine
    {
        public CloudMachine(System.IO.Stream configurationContent) { }
        public CloudMachine(string configurationFile = "cloudmachine.json") { }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Region { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public static Azure.CloudMachine Create(string subscriptionId, string region) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Save(System.IO.Stream stream) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public void Save(string filepath) { }
    }
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
    public partial class LruCache<TKey, TValue> : System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.IEnumerable where TKey : notnull
    {
        public LruCache(int capacity) { }
        public int Count { get { throw null; } }
        public int TotalLength { get { throw null; } }
        public void AddOrUpdate(TKey key, TValue? val, int length) { }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGet(TKey key, out TValue? value) { throw null; }
    }
    [System.AttributeUsageAttribute(System.AttributeTargets.Assembly | System.AttributeTargets.Class, Inherited=false, AllowMultiple=true)]
    public partial class ProvisionableTemplateAttribute : System.Attribute
    {
        public ProvisionableTemplateAttribute(string resourceName) { }
        public string ResourceName { get { throw null; } }
    }
    public abstract partial class SchemaValidator
    {
        protected SchemaValidator() { }
        public abstract string GenerateSchema(System.Type dataType);
        public abstract bool TryValidate(object data, System.Type dataType, string schemaDefinition, out System.Collections.Generic.IEnumerable<System.Exception> validationErrors);
        public virtual void Validate(object data, System.Type dataType, string schemaDefinition) { }
    }
}
