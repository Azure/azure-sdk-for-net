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
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> ArchiveSnapshot(string name, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot>> ArchiveSnapshotAsync(string name, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckKeys(string name = null, string after = null, string acceptDatetime = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckKeysAsync(string name = null, string after = null, string acceptDatetime = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckKeyValue(string key, string label = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckKeyValueAsync(string key, string label = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckKeyValues(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, string snapshot = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckKeyValuesAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, string snapshot = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckLabels(string name = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckLabelsAsync(string name = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckRevisions(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckRevisionsAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckSnapshot(string name, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckSnapshotAsync(string name, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CheckSnapshots(string after = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckSnapshotsAsync(string after = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateReadOnlyLock(string key, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateReadOnlyLockAsync(string key, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateSnapshot(string name, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> CreateSnapshot(string name, Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSnapshotAsync(string name, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot>> CreateSnapshotAsync(string name, Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteConfigurationSetting(string key, string label, Azure.ETag? ifMatch, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteConfigurationSetting(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConfigurationSettingAsync(string key, string label, Azure.ETag? ifMatch, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConfigurationSettingAsync(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteReadOnlyLock(string key, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteReadOnlyLockAsync(string key, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfChanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, System.DateTimeOffset acceptDateTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConfigurationSetting(string key, string label, string acceptDatetime, System.Collections.Generic.IEnumerable<string> select, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSetting(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> GetConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfChanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> GetConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, System.DateTimeOffset acceptDateTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConfigurationSettingAsync(string key, string label, string acceptDatetime, System.Collections.Generic.IEnumerable<string> select, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> GetConfigurationSettingAsync(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSettings(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetConfigurationSettings(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, string snapshot = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSettingsAsync(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetConfigurationSettingsAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, string snapshot = null, Azure.RequestContext context = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetKeys(string name = null, string after = null, string acceptDatetime = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetKeysAsync(string name = null, string after = null, string acceptDatetime = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLabels(string name = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLabelsAsync(string name = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisions(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRevisions(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisions(string keyFilter, string labelFilter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisionsAsync(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRevisionsAsync(string key = null, string label = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<string> select = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisionsAsync(string keyFilter, string labelFilter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> GetSnapshot(string name, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotFields> select = null, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshot(string name, System.Collections.Generic.IEnumerable<string> select, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot>> GetSnapshotAsync(string name, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotFields> select = null, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotAsync(string name, System.Collections.Generic.IEnumerable<string> select, Azure.MatchConditions matchConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> GetSnapshots(string name = null, string after = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotFields> select = null, Azure.Data.AppConfiguration.SnapshotStatus? status = default(Azure.Data.AppConfiguration.SnapshotStatus?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSnapshots(string name, string after, System.Collections.Generic.IEnumerable<string> select, string status, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> GetSnapshotsAsync(string name = null, string after = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotFields> select = null, Azure.Data.AppConfiguration.SnapshotStatus? status = default(Azure.Data.AppConfiguration.SnapshotStatus?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSnapshotsAsync(string name, string after, System.Collections.Generic.IEnumerable<string> select, string status, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot> RecoverSnapshot(string name, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSettingsSnapshot>> RecoverSnapshotAsync(string name, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetConfigurationSetting(string key, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetConfigurationSetting(string key, string value, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetConfigurationSettingAsync(string key, Azure.Core.RequestContent content, Azure.Core.ContentType contentType, string label = null, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetConfigurationSettingAsync(string key, string value, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetReadOnly(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool isReadOnly, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetReadOnly(string key, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting> SetReadOnly(string key, string label, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetReadOnlyAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool isReadOnly, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetReadOnlyAsync(string key, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSetting>> SetReadOnlyAsync(string key, string label, bool isReadOnly, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
        public virtual Azure.Response UpdateSnapshotStatus(string name, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSnapshotStatusAsync(string name, Azure.Core.RequestContent content, Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
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
    public partial class ConfigurationSettingFilter
    {
        public ConfigurationSettingFilter(string key) { }
        public string Key { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
    }
    public partial class ConfigurationSettingsSnapshot
    {
        public ConfigurationSettingsSnapshot(System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.ConfigurationSettingFilter> filters) { }
        public Azure.Data.AppConfiguration.CompositionType? CompositionType { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public Azure.ETag Etag { get { throw null; } }
        public System.DateTimeOffset? Expires { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.ConfigurationSettingFilter> Filters { get { throw null; } }
        public long? ItemCount { get { throw null; } }
        public string Name { get { throw null; } }
        public long? RetentionPeriod { get { throw null; } set { } }
        public long? Size { get { throw null; } }
        public Azure.Data.AppConfiguration.SnapshotStatus? Status { get { throw null; } }
        public int? StatusCode { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.AppConfiguration.ConfigurationClient, Azure.Data.AppConfiguration.ConfigurationClientOptions> AddConfigurationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string syncToken) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.AppConfiguration.ConfigurationClient, Azure.Data.AppConfiguration.ConfigurationClientOptions> AddConfigurationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
