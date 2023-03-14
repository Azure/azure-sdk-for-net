namespace Azure.Data.AppConfiguration
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompositionType : System.IEquatable<Azure.Data.AppConfiguration.CompositionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompositionType(string value) { throw null; }
        public static Azure.Data.AppConfiguration.CompositionType All { get { throw null; } }
        public static Azure.Data.AppConfiguration.CompositionType GroupByKey { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.CompositionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.CompositionType left, Azure.Data.AppConfiguration.CompositionType right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.CompositionType (string value) { throw null; }
        public static bool operator !=(Azure.Data.AppConfiguration.CompositionType left, Azure.Data.AppConfiguration.CompositionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationClient
    {
        protected ConfigurationClient() { }
        public ConfigurationClient(string connectionString) { }
        public ConfigurationClient(string connectionString, Azure.Data.AppConfiguration.ConfigurationClientOptions options) { }
        public ConfigurationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConfigurationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Data.AppConfiguration.ConfigurationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> AddConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> AddConfigurationSetting(string key, string value, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> AddConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> AddConfigurationSettingAsync(string key, string value, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> ArchiveSnapshot(Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot snapshot, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> ArchiveSnapshot(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot>> ArchiveSnapshotAsync(Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot snapshot, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot>> ArchiveSnapshotAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Data.AppConfiguration.CreateSnapshotOperation CreateSnapshot(Azure.WaitUntil wait, string name, Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Data.AppConfiguration.CreateSnapshotOperation> CreateSnapshotAsync(Azure.WaitUntil wait, string name, Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteConfigurationSetting(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConfigurationSettingAsync(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfChanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, System.DateTimeOffset acceptDateTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSetting(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> GetConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfChanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> GetConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, System.DateTimeOffset acceptDateTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> GetConfigurationSettingAsync(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSettings(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSettingsAsync(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisions(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisions(string keyFilter, string labelFilter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisionsAsync(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisionsAsync(string keyFilter, string labelFilter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> GetSnapshot(string name, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotFields> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot>> GetSnapshotAsync(string name, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotFields> select = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> GetSnapshots(string name = null, string after = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotFields> select = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotStatus> status = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> GetSnapshotsAsync(string name = null, string after = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotFields> select = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotStatus> status = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> RecoverSnapshot(Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot snapshot, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> RecoverSnapshot(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot>> RecoverSnapshotAsync(Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot snapshot, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot>> RecoverSnapshotAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetConfigurationSetting(string key, string value, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetConfigurationSettingAsync(string key, string value, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetReadOnly(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool isReadOnly, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetReadOnly(string key, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetReadOnly(string key, string label, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetReadOnlyAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool isReadOnly, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetReadOnlyAsync(string key, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetReadOnlyAsync(string key, string label, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        public virtual void UpdateSyncToken(string token) { }
    }
    public partial class ConfigurationClientOptions : Azure.Core.ClientOptions
    {
        public ConfigurationClientOptions(Azure.Data.AppConfiguration.ConfigurationClientOptions.ServiceVersion version = Azure.Data.AppConfiguration.ConfigurationClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 0,
        }
    }
    public static partial class ConfigurationModelFactory
    {
        public static Azure.Data.AppConfiguration.ConfigurationSetting ConfigurationSetting(string key, string value, string label = null, string contentType = null, Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), bool? isReadOnly = default(bool?)) { throw null; }
    }
    public partial class ConfigurationSetting
    {
        public ConfigurationSetting(string key, string value, string label = null) { }
        public ConfigurationSetting(string key, string value, string label, Azure.ETag etag) { }
        public string ContentType { get { throw null; } set { } }
        public Azure.ETag ETag { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationSettingsSnapshot
    {
        public ConfigurationSettingsSnapshot(System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotSettingFilter> filters) { }
        public Azure.Data.AppConfiguration.CompositionType? CompositionType { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public Azure.ETag Etag { get { throw null; } }
        public System.DateTimeOffset? Expires { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.SnapshotSettingFilter> Filters { get { throw null; } }
        public long? ItemCount { get { throw null; } }
        public string Name { get { throw null; } }
        public System.TimeSpan? RetentionPeriod { get { throw null; } set { } }
        public long? Size { get { throw null; } }
        public Azure.Data.AppConfiguration.SnapshotStatus? Status { get { throw null; } }
        public int? StatusCode { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CreateSnapshotOperation : Azure.Operation<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot>
    {
        protected CreateSnapshotOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FeatureFlagConfigurationSetting : Azure.Data.AppConfiguration.ConfigurationSetting
    {
        public FeatureFlagConfigurationSetting(string featureId, bool isEnabled, string label = null) : base (default(string), default(string), default(string)) { }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.FeatureFlagFilter> ClientFilters { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string FeatureId { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public static string KeyPrefix { get { throw null; } }
    }
    public partial class FeatureFlagFilter
    {
        public FeatureFlagFilter(string name) { }
        public FeatureFlagFilter(string name, System.Collections.Generic.IDictionary<string, object> parameters) { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
    }
    public partial class SecretReferenceConfigurationSetting : Azure.Data.AppConfiguration.ConfigurationSetting
    {
        public SecretReferenceConfigurationSetting(string key, System.Uri secretId, string label = null) : base (default(string), default(string), default(string)) { }
        public System.Uri SecretId { get { throw null; } set { } }
    }
    [System.FlagsAttribute]
    public enum SettingFields : uint
    {
        Key = (uint)1,
        Label = (uint)2,
        Value = (uint)4,
        ContentType = (uint)8,
        ETag = (uint)16,
        LastModified = (uint)32,
        IsReadOnly = (uint)64,
        Tags = (uint)128,
        All = (uint)4294967295,
    }
    public partial class SettingSelector
    {
        public static readonly string Any;
        public SettingSelector() { }
        public System.DateTimeOffset? AcceptDateTime { get { throw null; } set { } }
        public Azure.Data.AppConfiguration.SettingFields Fields { get { throw null; } set { } }
        public string KeyFilter { get { throw null; } set { } }
        public string LabelFilter { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SnapshotFields : System.IEquatable<Azure.Data.AppConfiguration.SnapshotFields>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SnapshotFields(string value) { throw null; }
        public static Azure.Data.AppConfiguration.SnapshotFields CompositionType { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Created { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Etag { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Expires { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Filters { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields ItemsCount { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Name { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields RetentionPeriod { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Size { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Status { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields StatusCode { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Tags { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.SnapshotFields other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.SnapshotFields left, Azure.Data.AppConfiguration.SnapshotFields right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.SnapshotFields (string value) { throw null; }
        public static bool operator !=(Azure.Data.AppConfiguration.SnapshotFields left, Azure.Data.AppConfiguration.SnapshotFields right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SnapshotSettingFilter
    {
        public SnapshotSettingFilter(string key) { }
        public string Key { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SnapshotStatus : System.IEquatable<Azure.Data.AppConfiguration.SnapshotStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SnapshotStatus(string value) { throw null; }
        public static Azure.Data.AppConfiguration.SnapshotStatus Archived { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotStatus Failed { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotStatus Provisioning { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotStatus Ready { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.SnapshotStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.SnapshotStatus left, Azure.Data.AppConfiguration.SnapshotStatus right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.SnapshotStatus (string value) { throw null; }
        public static bool operator !=(Azure.Data.AppConfiguration.SnapshotStatus left, Azure.Data.AppConfiguration.SnapshotStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SnapshotUpdateParameters
    {
        public SnapshotUpdateParameters() { }
        public Azure.Data.AppConfiguration.SnapshotStatus? Status { get { throw null; } set { } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ConfigurationClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.AppConfiguration.ConfigurationClient, Azure.Data.AppConfiguration.ConfigurationClientOptions> AddConfigurationClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.AppConfiguration.ConfigurationClient, Azure.Data.AppConfiguration.ConfigurationClientOptions> AddConfigurationClient<TBuilder>(this TBuilder builder, System.Uri configurationUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.AppConfiguration.ConfigurationClient, Azure.Data.AppConfiguration.ConfigurationClientOptions> AddConfigurationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
