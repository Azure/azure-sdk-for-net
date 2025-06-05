namespace Azure.Data.AppConfiguration
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationAudience : System.IEquatable<Azure.Data.AppConfiguration.AppConfigurationAudience>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationAudience(string value) { throw null; }
        public static Azure.Data.AppConfiguration.AppConfigurationAudience AzureChina { get { throw null; } }
        public static Azure.Data.AppConfiguration.AppConfigurationAudience AzureGovernment { get { throw null; } }
        public static Azure.Data.AppConfiguration.AppConfigurationAudience AzurePublicCloud { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.AppConfigurationAudience other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.AppConfigurationAudience left, Azure.Data.AppConfiguration.AppConfigurationAudience right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.AppConfigurationAudience (string value) { throw null; }
        public static bool operator !=(Azure.Data.AppConfiguration.AppConfigurationAudience left, Azure.Data.AppConfiguration.AppConfigurationAudience right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureDataAppConfigurationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureDataAppConfigurationContext() { }
        public static Azure.Data.AppConfiguration.AzureDataAppConfigurationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
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
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot> ArchiveSnapshot(string snapshotName, Azure.MatchConditions matchConditions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot> ArchiveSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot>> ArchiveSnapshotAsync(string snapshotName, Azure.MatchConditions matchConditions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot>> ArchiveSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Data.AppConfiguration.CreateSnapshotOperation CreateSnapshot(Azure.WaitUntil wait, string snapshotName, Azure.Data.AppConfiguration.ConfigurationSnapshot snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Data.AppConfiguration.CreateSnapshotOperation> CreateSnapshotAsync(Azure.WaitUntil wait, string snapshotName, Azure.Data.AppConfiguration.ConfigurationSnapshot snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSettingsForSnapshot(string snapshotName, Azure.Data.AppConfiguration.SettingFields fields, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSettingsForSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSettingsForSnapshotAsync(string snapshotName, Azure.Data.AppConfiguration.SettingFields fields, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetConfigurationSettingsForSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.SettingLabel> GetLabels(Azure.Data.AppConfiguration.SettingLabelSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.SettingLabel> GetLabelsAsync(Azure.Data.AppConfiguration.SettingLabelSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisions(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisions(string keyFilter, string labelFilter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisionsAsync(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> GetRevisionsAsync(string keyFilter, string labelFilter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot> GetSnapshot(string snapshotName, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotFields> fields = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot>> GetSnapshotAsync(string snapshotName, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SnapshotFields> fields = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSnapshot> GetSnapshots(Azure.Data.AppConfiguration.SnapshotSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSnapshot> GetSnapshotsAsync(Azure.Data.AppConfiguration.SnapshotSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot> RecoverSnapshot(string snapshotName, Azure.MatchConditions matchConditions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot> RecoverSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot>> RecoverSnapshotAsync(string snapshotName, Azure.MatchConditions matchConditions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot>> RecoverSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class ConfigurationClientExtensions
    {
        public static System.Collections.Generic.IAsyncEnumerable<Azure.Page<Azure.Data.AppConfiguration.ConfigurationSetting>> AsPages(this Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> pageable, System.Collections.Generic.IEnumerable<Azure.MatchConditions> conditions, string continuationToken = null, int? pageSizeHint = default(int?)) { throw null; }
        public static System.Collections.Generic.IEnumerable<Azure.Page<Azure.Data.AppConfiguration.ConfigurationSetting>> AsPages(this Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> pageable, System.Collections.Generic.IEnumerable<Azure.MatchConditions> conditions, string continuationToken = null, int? pageSizeHint = default(int?)) { throw null; }
    }
    public partial class ConfigurationClientOptions : Azure.Core.ClientOptions
    {
        public ConfigurationClientOptions(Azure.Data.AppConfiguration.ConfigurationClientOptions.ServiceVersion version = Azure.Data.AppConfiguration.ConfigurationClientOptions.ServiceVersion.V2023_11_01) { }
        public Azure.Data.AppConfiguration.AppConfigurationAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1_0 = 0,
            V2023_10_01 = 1,
            V2023_11_01 = 2,
        }
    }
    public static partial class ConfigurationModelFactory
    {
        public static Azure.Data.AppConfiguration.ConfigurationSetting ConfigurationSetting(string key, string value, string label = null, string contentType = null, Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), bool? isReadOnly = default(bool?)) { throw null; }
        public static Azure.Data.AppConfiguration.FeatureFlagConfigurationSetting FeatureFlagConfigurationSetting(string featureId, bool isEnabled, string label = null, Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), bool? isReadOnly = default(bool?)) { throw null; }
        public static Azure.Data.AppConfiguration.SecretReferenceConfigurationSetting SecretReferenceConfigurationSetting(string key, System.Uri secretId, string label = null, Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), bool? isReadOnly = default(bool?)) { throw null; }
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
    public partial class ConfigurationSettingsFilter
    {
        public ConfigurationSettingsFilter(string key) { }
        public string Key { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
    }
    public partial class ConfigurationSnapshot
    {
        public ConfigurationSnapshot(System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.ConfigurationSettingsFilter> filters) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.ConfigurationSettingsFilter> Filters { get { throw null; } }
        public long? ItemCount { get { throw null; } }
        public string Name { get { throw null; } }
        public System.TimeSpan? RetentionPeriod { get { throw null; } set { } }
        public long? SizeInBytes { get { throw null; } }
        public Azure.Data.AppConfiguration.SnapshotComposition? SnapshotComposition { get { throw null; } set { } }
        public Azure.Data.AppConfiguration.ConfigurationSnapshotStatus? Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationSnapshotStatus : System.IEquatable<Azure.Data.AppConfiguration.ConfigurationSnapshotStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationSnapshotStatus(string value) { throw null; }
        public static Azure.Data.AppConfiguration.ConfigurationSnapshotStatus Archived { get { throw null; } }
        public static Azure.Data.AppConfiguration.ConfigurationSnapshotStatus Failed { get { throw null; } }
        public static Azure.Data.AppConfiguration.ConfigurationSnapshotStatus Provisioning { get { throw null; } }
        public static Azure.Data.AppConfiguration.ConfigurationSnapshotStatus Ready { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.ConfigurationSnapshotStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.ConfigurationSnapshotStatus left, Azure.Data.AppConfiguration.ConfigurationSnapshotStatus right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.ConfigurationSnapshotStatus (string value) { throw null; }
        public static bool operator !=(Azure.Data.AppConfiguration.ConfigurationSnapshotStatus left, Azure.Data.AppConfiguration.ConfigurationSnapshotStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateSnapshotOperation : Azure.Operation<Azure.Data.AppConfiguration.ConfigurationSnapshot>
    {
        protected CreateSnapshotOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Data.AppConfiguration.ConfigurationSnapshot Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Data.AppConfiguration.ConfigurationSnapshot>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class FeatureFlagConfigurationSetting : Azure.Data.AppConfiguration.ConfigurationSetting
    {
        public FeatureFlagConfigurationSetting(string featureId, bool isEnabled, string label = null) : base (default(string), default(string), default(string)) { }
        public FeatureFlagConfigurationSetting(string featureId, bool isEnabled, string label, Azure.ETag etag) : base (default(string), default(string), default(string)) { }
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
        public SecretReferenceConfigurationSetting(string key, System.Uri secretId, string label, Azure.ETag etag) : base (default(string), default(string), default(string)) { }
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
    public partial class SettingLabel
    {
        internal SettingLabel() { }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SettingLabelFields : System.IEquatable<Azure.Data.AppConfiguration.SettingLabelFields>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SettingLabelFields(string value) { throw null; }
        public static Azure.Data.AppConfiguration.SettingLabelFields Name { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.SettingLabelFields other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.SettingLabelFields left, Azure.Data.AppConfiguration.SettingLabelFields right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.SettingLabelFields (string value) { throw null; }
        public static bool operator !=(Azure.Data.AppConfiguration.SettingLabelFields left, Azure.Data.AppConfiguration.SettingLabelFields right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SettingLabelSelector
    {
        public SettingLabelSelector() { }
        public System.DateTimeOffset? AcceptDateTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.SettingLabelFields> Fields { get { throw null; } }
        public string NameFilter { get { throw null; } set { } }
    }
    public partial class SettingSelector
    {
        public static readonly string Any;
        public SettingSelector() { }
        public System.DateTimeOffset? AcceptDateTime { get { throw null; } set { } }
        public Azure.Data.AppConfiguration.SettingFields Fields { get { throw null; } set { } }
        public string KeyFilter { get { throw null; } set { } }
        public string LabelFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TagsFilter { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SnapshotComposition : System.IEquatable<Azure.Data.AppConfiguration.SnapshotComposition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SnapshotComposition(string value) { throw null; }
        public static Azure.Data.AppConfiguration.SnapshotComposition Key { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotComposition KeyLabel { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.SnapshotComposition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.SnapshotComposition left, Azure.Data.AppConfiguration.SnapshotComposition right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.SnapshotComposition (string value) { throw null; }
        public static bool operator !=(Azure.Data.AppConfiguration.SnapshotComposition left, Azure.Data.AppConfiguration.SnapshotComposition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SnapshotFields : System.IEquatable<Azure.Data.AppConfiguration.SnapshotFields>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SnapshotFields(string value) { throw null; }
        public static Azure.Data.AppConfiguration.SnapshotFields CreatedOn { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields ETag { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields ExpiresOn { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Filters { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields ItemCount { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Name { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields RetentionPeriod { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields SizeInBytes { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields SnapshotComposition { get { throw null; } }
        public static Azure.Data.AppConfiguration.SnapshotFields Status { get { throw null; } }
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
    public partial class SnapshotSelector
    {
        public SnapshotSelector() { }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.SnapshotFields> Fields { get { throw null; } }
        public string NameFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.ConfigurationSnapshotStatus> Status { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ConfigurationClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.AppConfiguration.ConfigurationClient, Azure.Data.AppConfiguration.ConfigurationClientOptions> AddConfigurationClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.AppConfiguration.ConfigurationClient, Azure.Data.AppConfiguration.ConfigurationClientOptions> AddConfigurationClient<TBuilder>(this TBuilder builder, System.Uri configurationUri) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Data.AppConfiguration.ConfigurationClient, Azure.Data.AppConfiguration.ConfigurationClientOptions> AddConfigurationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
