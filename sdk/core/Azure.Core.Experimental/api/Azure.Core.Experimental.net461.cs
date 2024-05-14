namespace Azure
{
    public partial class CloudMachine
    {
        public CloudMachine(System.IO.Stream configurationContent) { }
        public CloudMachine(string? configurationFile = null) { }
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
    public readonly partial struct Variant
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public static readonly Azure.Variant Null;
        public Variant(System.ArraySegment<byte> segment) { throw null; }
        public Variant(System.ArraySegment<char> segment) { throw null; }
        public Variant(bool value) { throw null; }
        public Variant(byte value) { throw null; }
        public Variant(char value) { throw null; }
        public Variant(System.DateTime value) { throw null; }
        public Variant(System.DateTimeOffset value) { throw null; }
        public Variant(double value) { throw null; }
        public Variant(short value) { throw null; }
        public Variant(int value) { throw null; }
        public Variant(long value) { throw null; }
        public Variant(bool? value) { throw null; }
        public Variant(byte? value) { throw null; }
        public Variant(char? value) { throw null; }
        public Variant(System.DateTimeOffset? value) { throw null; }
        public Variant(System.DateTime? value) { throw null; }
        public Variant(double? value) { throw null; }
        public Variant(short? value) { throw null; }
        public Variant(int? value) { throw null; }
        public Variant(long? value) { throw null; }
        public Variant(sbyte? value) { throw null; }
        public Variant(float? value) { throw null; }
        public Variant(ushort? value) { throw null; }
        public Variant(uint? value) { throw null; }
        public Variant(ulong? value) { throw null; }
        public Variant(object? value) { throw null; }
        public Variant(sbyte value) { throw null; }
        public Variant(float value) { throw null; }
        public Variant(ushort value) { throw null; }
        public Variant(uint value) { throw null; }
        public Variant(ulong value) { throw null; }
        public bool IsNull { get { throw null; } }
        public System.Type? Type { get { throw null; } }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]public T As<T>() { throw null; }
        public static Azure.Variant Create<T>(T value) { throw null; }
        public static explicit operator System.ArraySegment<byte> (in Azure.Variant value) { throw null; }
        public static explicit operator System.ArraySegment<char> (in Azure.Variant value) { throw null; }
        public static explicit operator bool (in Azure.Variant value) { throw null; }
        public static explicit operator byte (in Azure.Variant value) { throw null; }
        public static explicit operator char (in Azure.Variant value) { throw null; }
        public static explicit operator System.DateTime (in Azure.Variant value) { throw null; }
        public static explicit operator System.DateTimeOffset (in Azure.Variant value) { throw null; }
        public static explicit operator decimal (in Azure.Variant value) { throw null; }
        public static explicit operator double (in Azure.Variant value) { throw null; }
        public static explicit operator short (in Azure.Variant value) { throw null; }
        public static explicit operator int (in Azure.Variant value) { throw null; }
        public static explicit operator long (in Azure.Variant value) { throw null; }
        public static explicit operator bool? (in Azure.Variant value) { throw null; }
        public static explicit operator byte? (in Azure.Variant value) { throw null; }
        public static explicit operator char? (in Azure.Variant value) { throw null; }
        public static explicit operator System.DateTimeOffset? (in Azure.Variant value) { throw null; }
        public static explicit operator System.DateTime? (in Azure.Variant value) { throw null; }
        public static explicit operator decimal? (in Azure.Variant value) { throw null; }
        public static explicit operator double? (in Azure.Variant value) { throw null; }
        public static explicit operator short? (in Azure.Variant value) { throw null; }
        public static explicit operator int? (in Azure.Variant value) { throw null; }
        public static explicit operator long? (in Azure.Variant value) { throw null; }
        public static explicit operator sbyte? (in Azure.Variant value) { throw null; }
        public static explicit operator float? (in Azure.Variant value) { throw null; }
        public static explicit operator ushort? (in Azure.Variant value) { throw null; }
        public static explicit operator uint? (in Azure.Variant value) { throw null; }
        public static explicit operator ulong? (in Azure.Variant value) { throw null; }
        public static explicit operator sbyte (in Azure.Variant value) { throw null; }
        public static explicit operator float (in Azure.Variant value) { throw null; }
        public static explicit operator string (in Azure.Variant value) { throw null; }
        public static explicit operator ushort (in Azure.Variant value) { throw null; }
        public static explicit operator uint (in Azure.Variant value) { throw null; }
        public static explicit operator ulong (in Azure.Variant value) { throw null; }
        public static implicit operator Azure.Variant (System.ArraySegment<byte> value) { throw null; }
        public static implicit operator Azure.Variant (System.ArraySegment<char> value) { throw null; }
        public static implicit operator Azure.Variant (bool value) { throw null; }
        public static implicit operator Azure.Variant (byte value) { throw null; }
        public static implicit operator Azure.Variant (char value) { throw null; }
        public static implicit operator Azure.Variant (System.DateTime value) { throw null; }
        public static implicit operator Azure.Variant (System.DateTimeOffset value) { throw null; }
        public static implicit operator Azure.Variant (decimal value) { throw null; }
        public static implicit operator Azure.Variant (double value) { throw null; }
        public static implicit operator Azure.Variant (short value) { throw null; }
        public static implicit operator Azure.Variant (int value) { throw null; }
        public static implicit operator Azure.Variant (long value) { throw null; }
        public static implicit operator Azure.Variant (bool? value) { throw null; }
        public static implicit operator Azure.Variant (byte? value) { throw null; }
        public static implicit operator Azure.Variant (char? value) { throw null; }
        public static implicit operator Azure.Variant (System.DateTimeOffset? value) { throw null; }
        public static implicit operator Azure.Variant (System.DateTime? value) { throw null; }
        public static implicit operator Azure.Variant (decimal? value) { throw null; }
        public static implicit operator Azure.Variant (double? value) { throw null; }
        public static implicit operator Azure.Variant (short? value) { throw null; }
        public static implicit operator Azure.Variant (int? value) { throw null; }
        public static implicit operator Azure.Variant (long? value) { throw null; }
        public static implicit operator Azure.Variant (sbyte? value) { throw null; }
        public static implicit operator Azure.Variant (float? value) { throw null; }
        public static implicit operator Azure.Variant (ushort? value) { throw null; }
        public static implicit operator Azure.Variant (uint? value) { throw null; }
        public static implicit operator Azure.Variant (ulong? value) { throw null; }
        public static implicit operator Azure.Variant (sbyte value) { throw null; }
        public static implicit operator Azure.Variant (float value) { throw null; }
        public static implicit operator Azure.Variant (string value) { throw null; }
        public static implicit operator Azure.Variant (ushort value) { throw null; }
        public static implicit operator Azure.Variant (uint value) { throw null; }
        public static implicit operator Azure.Variant (ulong value) { throw null; }
        public override string? ToString() { throw null; }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]public bool TryGetValue<T>(out T value) { throw null; }
    }
}
namespace Azure.Core
{
    public partial interface ISupportsProofOfPossession
    {
        Azure.Core.AccessToken GetToken(Azure.Core.PopTokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken);
        System.Threading.Tasks.ValueTask<Azure.Core.AccessToken> GetTokenAsync(Azure.Core.PopTokenRequestContext requestContext, System.Threading.CancellationToken cancellationToken);
    }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PopTokenRequestContext
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PopTokenRequestContext(string[] scopes, string? parentRequestId = null, string? claims = null, string? tenantId = null, bool isCaeEnabled = false, string? proofOfPossessionNonce = null, Azure.Core.Request? request = null) { throw null; }
        public string? Claims { get { throw null; } }
        public System.Net.Http.HttpMethod? HttpMethod { get { throw null; } }
        public bool IsCaeEnabled { get { throw null; } }
        public string? ParentRequestId { get { throw null; } }
        public string? ProofOfPossessionNonce { get { throw null; } }
        public string[] Scopes { get { throw null; } }
        public string? TenantId { get { throw null; } }
        public System.Uri? Uri { get { throw null; } }
        public static Azure.Core.PopTokenRequestContext FromTokenRequestContext(Azure.Core.TokenRequestContext context, Azure.Core.Request? request = null) { throw null; }
        public static implicit operator Azure.Core.TokenRequestContext (Azure.Core.PopTokenRequestContext context) { throw null; }
        public Azure.Core.TokenRequestContext ToTokenRequestContext() { throw null; }
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
namespace Azure.Core.Pipeline
{
    public partial class PopTokenAuthenticationPolicy : Azure.Core.Pipeline.HttpPipelinePolicy
    {
        public PopTokenAuthenticationPolicy(Azure.Core.ISupportsProofOfPossession credential, string scope) { }
        protected void AuthenticateAndAuthorizeRequest(Azure.Core.HttpMessage message, Azure.Core.PopTokenRequestContext context) { }
        protected System.Threading.Tasks.ValueTask AuthenticateAndAuthorizeRequestAsync(Azure.Core.HttpMessage message, Azure.Core.PopTokenRequestContext context) { throw null; }
        protected void AuthorizeRequest(Azure.Core.HttpMessage message) { }
        protected virtual System.Threading.Tasks.ValueTask AuthorizeRequestAsync(Azure.Core.HttpMessage message) { throw null; }
        protected virtual bool AuthorizeRequestOnChallenge(Azure.Core.HttpMessage message) { throw null; }
        protected virtual System.Threading.Tasks.ValueTask<bool> AuthorizeRequestOnChallengeAsync(Azure.Core.HttpMessage message) { throw null; }
        public override void Process(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { }
        public override System.Threading.Tasks.ValueTask ProcessAsync(Azure.Core.HttpMessage message, System.ReadOnlyMemory<Azure.Core.Pipeline.HttpPipelinePolicy> pipeline) { throw null; }
    }
}
