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
        public override bool Equals(object obj) { throw null; }
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
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public ConfigurationClient(Azure.Data.AppConfiguration.ConfigurationClientSettings settings) { }
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
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> CheckConfigurationSettings(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> CheckConfigurationSettingsAsync(Azure.Data.AppConfiguration.SettingSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckLabels(string name, string syncToken, string after, string acceptDatetime, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SettingLabelFields> select, string resourceType, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response CheckLabels(string name = null, string syncToken = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SettingLabelFields> select = null, string resourceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckLabelsAsync(string name, string syncToken, string after, string acceptDatetime, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SettingLabelFields> select, string resourceType, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckLabelsAsync(string name = null, string syncToken = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SettingLabelFields> select = null, string resourceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Data.AppConfiguration.CreateSnapshotOperation CreateSnapshot(Azure.WaitUntil wait, string snapshotName, Azure.Data.AppConfiguration.ConfigurationSnapshot snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Data.AppConfiguration.CreateSnapshotOperation> CreateSnapshotAsync(Azure.WaitUntil wait, string snapshotName, Azure.Data.AppConfiguration.ConfigurationSnapshot snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteConfigurationSetting(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteConfigurationSetting(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConfigurationSettingAsync(Azure.Data.AppConfiguration.ConfigurationSetting setting, bool onlyIfUnchanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConfigurationSettingAsync(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.FeatureFlag> GetFeatureFlags(Azure.Data.AppConfiguration.FeatureFlagSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.FeatureFlag> GetFeatureFlagsAsync(Azure.Data.AppConfiguration.FeatureFlagSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override int GetHashCode() { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.SettingLabel> GetLabels(Azure.Data.AppConfiguration.SettingLabelSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLabels(string name, string syncToken, string after, string acceptDatetime, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SettingLabelFields> select, string resourceType, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Data.AppConfiguration.SettingLabel> GetLabels(string name = null, string syncToken = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SettingLabelFields> select = null, string resourceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.SettingLabel> GetLabelsAsync(Azure.Data.AppConfiguration.SettingLabelSelector selector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLabelsAsync(string name, string syncToken, string after, string acceptDatetime, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SettingLabelFields> select, string resourceType, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Data.AppConfiguration.SettingLabel> GetLabelsAsync(string name = null, string syncToken = null, string after = null, string acceptDatetime = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.SettingLabelFields> select = null, string resourceType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public override string ToString() { throw null; }
        public virtual void UpdateSyncToken(string token) { }
    }
    public static partial class ConfigurationClientExtensions
    {
        public static System.Collections.Generic.IAsyncEnumerable<Azure.Page<Azure.Data.AppConfiguration.ConfigurationSetting>> AsPages(this Azure.AsyncPageable<Azure.Data.AppConfiguration.ConfigurationSetting> pageable, System.Collections.Generic.IEnumerable<Azure.MatchConditions> conditions, string continuationToken = null, int? pageSizeHint = default(int?)) { throw null; }
        public static System.Collections.Generic.IEnumerable<Azure.Page<Azure.Data.AppConfiguration.ConfigurationSetting>> AsPages(this Azure.Pageable<Azure.Data.AppConfiguration.ConfigurationSetting> pageable, System.Collections.Generic.IEnumerable<Azure.MatchConditions> conditions, string continuationToken = null, int? pageSizeHint = default(int?)) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class ConfigurationClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddConfigurationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddConfigurationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Data.AppConfiguration.ConfigurationClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedConfigurationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedConfigurationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Data.AppConfiguration.ConfigurationClientSettings> configureSettings) { throw null; }
    }
    public partial class ConfigurationClientOptions : Azure.Core.ClientOptions
    {
        public ConfigurationClientOptions(Azure.Data.AppConfiguration.ConfigurationClientOptions.ServiceVersion version = Azure.Data.AppConfiguration.ConfigurationClientOptions.ServiceVersion.V2026_05_01_Preview) { }
        public Azure.Data.AppConfiguration.AppConfigurationAudience? Audience { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1_0 = 0,
            V2023_10_01 = 1,
            V2023_11_01 = 2,
            V2024_09_01 = 3,
            V2026_04_01 = 4,
            V2026_05_01_Preview = 5,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class ConfigurationClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public ConfigurationClientSettings() { }
        public string ConnectionString { get { throw null; } set { } }
        public System.Uri? Endpoint { get { throw null; } set { } }
        public Azure.Data.AppConfiguration.ConfigurationClientOptions? Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public static partial class ConfigurationModelFactory
    {
        public static Azure.Data.AppConfiguration.ConfigurationSetting ConfigurationSetting(string key, string value, string label = null, string contentType = null, Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), bool? isReadOnly = default(bool?)) { throw null; }
        public static Azure.Data.AppConfiguration.ConfigurationSettingsFilter ConfigurationSettingsFilter(string key = null, string label = null, System.Collections.Generic.IEnumerable<string> tags = null) { throw null; }
        public static Azure.Data.AppConfiguration.ConfigurationSnapshot ConfigurationSnapshot(string name, Azure.Data.AppConfiguration.ConfigurationSnapshotStatus? status, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.ConfigurationSettingsFilter> filters, Azure.Data.AppConfiguration.SnapshotComposition? snapshotComposition, System.DateTimeOffset? createdOn, System.DateTimeOffset? expiresOn, System.TimeSpan? retentionPeriod, long? sizeInBytes, long? itemCount, System.Collections.Generic.IDictionary<string, string> tags, Azure.ETag eTag) { throw null; }
        public static Azure.Data.AppConfiguration.ConfigurationSnapshot ConfigurationSnapshot(string name = null, Azure.Data.AppConfiguration.ConfigurationSnapshotStatus? status = default(Azure.Data.AppConfiguration.ConfigurationSnapshotStatus?), System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.ConfigurationSettingsFilter> filters = null, Azure.Data.AppConfiguration.SnapshotComposition? snapshotComposition = default(Azure.Data.AppConfiguration.SnapshotComposition?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), System.TimeSpan? retentionPeriod = default(System.TimeSpan?), long? sizeInBytes = default(long?), long? itemCount = default(long?), System.Collections.Generic.IDictionary<string, string> tags = null, string description = null, Azure.ETag eTag = default(Azure.ETag)) { throw null; }
        public static Azure.Data.AppConfiguration.FeatureFlag FeatureFlag(string name = null, bool? enabled = default(bool?), string label = null, string description = null, Azure.Data.AppConfiguration.FeatureFlagConditions conditions = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.FeatureFlagVariantDefinition> variants = null, Azure.Data.AppConfiguration.FeatureFlagAllocation allocation = null, Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration telemetry = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), string etag = null) { throw null; }
        public static Azure.Data.AppConfiguration.FeatureFlagAllocation FeatureFlagAllocation(string defaultWhenDisabled = null, string defaultWhenEnabled = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.PercentileAllocation> percentile = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.UserAllocation> user = null, System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.GroupAllocation> group = null, string seed = null) { throw null; }
        public static Azure.Data.AppConfiguration.FeatureFlagConditions FeatureFlagConditions(Azure.Data.AppConfiguration.RequirementType? requirementType = default(Azure.Data.AppConfiguration.RequirementType?), System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.FeatureFlagFilter> filters = null) { throw null; }
        public static Azure.Data.AppConfiguration.FeatureFlagConfigurationSetting FeatureFlagConfigurationSetting(string featureId, bool isEnabled, string label = null, Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), bool? isReadOnly = default(bool?)) { throw null; }
        public static Azure.Data.AppConfiguration.FeatureFlagFilter FeatureFlagFilter(string name = null, System.Collections.Generic.IDictionary<string, object> parameters = null) { throw null; }
        public static Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration FeatureFlagTelemetryConfiguration(bool enabled = false, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.Data.AppConfiguration.FeatureFlagVariantDefinition FeatureFlagVariantDefinition(string name = null, string value = null, string contentType = null, Azure.Data.AppConfiguration.StatusOverride? statusOverride = default(Azure.Data.AppConfiguration.StatusOverride?)) { throw null; }
        public static Azure.Data.AppConfiguration.GroupAllocation GroupAllocation(string variant = null, System.Collections.Generic.IEnumerable<string> groups = null) { throw null; }
        public static Azure.Data.AppConfiguration.PercentileAllocation PercentileAllocation(string variant = null, int from = 0, int to = 0) { throw null; }
        public static Azure.Data.AppConfiguration.SecretReferenceConfigurationSetting SecretReferenceConfigurationSetting(string key, System.Uri secretId, string label = null, Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), bool? isReadOnly = default(bool?)) { throw null; }
        public static Azure.Data.AppConfiguration.SettingLabel SettingLabel(string name = null) { throw null; }
        public static Azure.Data.AppConfiguration.UserAllocation UserAllocation(string variant = null, System.Collections.Generic.IEnumerable<string> users = null) { throw null; }
    }
    public partial class ConfigurationSetting : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSetting>
    {
        public ConfigurationSetting(string key, string value, string label = null) { }
        public ConfigurationSetting(string key, string value, string label, Azure.ETag etag) { }
        public string ContentType { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag ETag { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected virtual Azure.Data.AppConfiguration.ConfigurationSetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Data.AppConfiguration.ConfigurationSetting (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Data.AppConfiguration.ConfigurationSetting configurationSetting) { throw null; }
        protected virtual Azure.Data.AppConfiguration.ConfigurationSetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.ConfigurationSetting System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.ConfigurationSetting System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationSettingsFilter : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSettingsFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSettingsFilter>
    {
        public ConfigurationSettingsFilter(string key) { }
        public string Key { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        protected virtual Azure.Data.AppConfiguration.ConfigurationSettingsFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AppConfiguration.ConfigurationSettingsFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.ConfigurationSettingsFilter System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSettingsFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSettingsFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.ConfigurationSettingsFilter System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSettingsFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSettingsFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSettingsFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigurationSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSnapshot>
    {
        public ConfigurationSnapshot(System.Collections.Generic.IEnumerable<Azure.Data.AppConfiguration.ConfigurationSettingsFilter> filters) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
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
        protected virtual Azure.Data.AppConfiguration.ConfigurationSnapshot JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Data.AppConfiguration.ConfigurationSnapshot (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Data.AppConfiguration.ConfigurationSnapshot configurationSnapshot) { throw null; }
        protected virtual Azure.Data.AppConfiguration.ConfigurationSnapshot PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.ConfigurationSnapshot System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.ConfigurationSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.ConfigurationSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.ConfigurationSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.ConfigurationSnapshotStatus left, Azure.Data.AppConfiguration.ConfigurationSnapshotStatus right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.ConfigurationSnapshotStatus (string value) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.ConfigurationSnapshotStatus? (string value) { throw null; }
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
    public partial class FeatureFlag : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlag>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlag>
    {
        public FeatureFlag() { }
        public Azure.Data.AppConfiguration.FeatureFlagAllocation Allocation { get { throw null; } set { } }
        public Azure.Data.AppConfiguration.FeatureFlagConditions Conditions { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string Etag { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration Telemetry { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.FeatureFlagVariantDefinition> Variants { get { throw null; } }
        protected virtual Azure.Data.AppConfiguration.FeatureFlag JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Data.AppConfiguration.FeatureFlag (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Data.AppConfiguration.FeatureFlag featureFlag) { throw null; }
        protected virtual Azure.Data.AppConfiguration.FeatureFlag PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.FeatureFlag System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.FeatureFlag System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FeatureFlagAllocation : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagAllocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagAllocation>
    {
        public FeatureFlagAllocation() { }
        public string DefaultWhenDisabled { get { throw null; } set { } }
        public string DefaultWhenEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.GroupAllocation> Group { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.PercentileAllocation> Percentile { get { throw null; } }
        public string Seed { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.UserAllocation> User { get { throw null; } }
        protected virtual Azure.Data.AppConfiguration.FeatureFlagAllocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AppConfiguration.FeatureFlagAllocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.FeatureFlagAllocation System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagAllocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagAllocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.FeatureFlagAllocation System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagAllocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagAllocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagAllocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FeatureFlagConditions : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagConditions>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagConditions>
    {
        public FeatureFlagConditions() { }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.FeatureFlagFilter> Filters { get { throw null; } }
        public Azure.Data.AppConfiguration.RequirementType? RequirementType { get { throw null; } set { } }
        protected virtual Azure.Data.AppConfiguration.FeatureFlagConditions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AppConfiguration.FeatureFlagConditions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.FeatureFlagConditions System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagConditions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagConditions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.FeatureFlagConditions System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagConditions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagConditions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagConditions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FeatureFlagConfigurationSetting : Azure.Data.AppConfiguration.ConfigurationSetting
    {
        public FeatureFlagConfigurationSetting(string featureId, bool isEnabled, string label = null) : base (default(string), default(string), default(string)) { }
        public FeatureFlagConfigurationSetting(string featureId, bool isEnabled, string label, Azure.ETag etag) : base (default(string), default(string), default(string)) { }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.FeatureFlagFilter> ClientFilters { get { throw null; } }
        public new string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string FeatureId { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public static string KeyPrefix { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureFlagFields : System.IEquatable<Azure.Data.AppConfiguration.FeatureFlagFields>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureFlagFields(string value) { throw null; }
        public static Azure.Data.AppConfiguration.FeatureFlagFields Allocation { get { throw null; } }
        public static Azure.Data.AppConfiguration.FeatureFlagFields Conditions { get { throw null; } }
        public static Azure.Data.AppConfiguration.FeatureFlagFields Description { get { throw null; } }
        public static Azure.Data.AppConfiguration.FeatureFlagFields Enabled { get { throw null; } }
        public static Azure.Data.AppConfiguration.FeatureFlagFields Etag { get { throw null; } }
        public static Azure.Data.AppConfiguration.FeatureFlagFields Label { get { throw null; } }
        public static Azure.Data.AppConfiguration.FeatureFlagFields LastModified { get { throw null; } }
        public static Azure.Data.AppConfiguration.FeatureFlagFields Name { get { throw null; } }
        public static Azure.Data.AppConfiguration.FeatureFlagFields Tags { get { throw null; } }
        public static Azure.Data.AppConfiguration.FeatureFlagFields Telemetry { get { throw null; } }
        public static Azure.Data.AppConfiguration.FeatureFlagFields Variants { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.FeatureFlagFields other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.FeatureFlagFields left, Azure.Data.AppConfiguration.FeatureFlagFields right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.FeatureFlagFields (string value) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.FeatureFlagFields? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AppConfiguration.FeatureFlagFields left, Azure.Data.AppConfiguration.FeatureFlagFields right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FeatureFlagFilter : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagFilter>
    {
        public FeatureFlagFilter(string name) { }
        public FeatureFlagFilter(string name, System.Collections.Generic.IDictionary<string, object> parameters) { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Parameters { get { throw null; } }
        protected virtual Azure.Data.AppConfiguration.FeatureFlagFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AppConfiguration.FeatureFlagFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.FeatureFlagFilter System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.FeatureFlagFilter System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FeatureFlagSelector
    {
        public static readonly string Any;
        public FeatureFlagSelector() { }
        public System.DateTimeOffset? AcceptDateTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Data.AppConfiguration.FeatureFlagFields> Fields { get { throw null; } }
        public string LabelFilter { get { throw null; } set { } }
        public string NameFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TagsFilter { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FeatureFlagTelemetryConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration>
    {
        public FeatureFlagTelemetryConfiguration(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagTelemetryConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FeatureFlagVariantDefinition : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagVariantDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagVariantDefinition>
    {
        public FeatureFlagVariantDefinition(string name) { }
        public string ContentType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Data.AppConfiguration.StatusOverride? StatusOverride { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.Data.AppConfiguration.FeatureFlagVariantDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AppConfiguration.FeatureFlagVariantDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.FeatureFlagVariantDefinition System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagVariantDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.FeatureFlagVariantDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.FeatureFlagVariantDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagVariantDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagVariantDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.FeatureFlagVariantDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupAllocation : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.GroupAllocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.GroupAllocation>
    {
        public GroupAllocation(string variant, System.Collections.Generic.IEnumerable<string> groups) { }
        public System.Collections.Generic.IList<string> Groups { get { throw null; } }
        public string Variant { get { throw null; } set { } }
        protected virtual Azure.Data.AppConfiguration.GroupAllocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AppConfiguration.GroupAllocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.GroupAllocation System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.GroupAllocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.GroupAllocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.GroupAllocation System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.GroupAllocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.GroupAllocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.GroupAllocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PercentileAllocation : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.PercentileAllocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.PercentileAllocation>
    {
        public PercentileAllocation(string variant, int from, int to) { }
        public int From { get { throw null; } set { } }
        public int To { get { throw null; } set { } }
        public string Variant { get { throw null; } set { } }
        protected virtual Azure.Data.AppConfiguration.PercentileAllocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AppConfiguration.PercentileAllocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.PercentileAllocation System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.PercentileAllocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.PercentileAllocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.PercentileAllocation System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.PercentileAllocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.PercentileAllocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.PercentileAllocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequirementType : System.IEquatable<Azure.Data.AppConfiguration.RequirementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequirementType(string value) { throw null; }
        public static Azure.Data.AppConfiguration.RequirementType All { get { throw null; } }
        public static Azure.Data.AppConfiguration.RequirementType Any { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.RequirementType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.RequirementType left, Azure.Data.AppConfiguration.RequirementType right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.RequirementType (string value) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.RequirementType? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AppConfiguration.RequirementType left, Azure.Data.AppConfiguration.RequirementType right) { throw null; }
        public override string ToString() { throw null; }
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
        Description = (uint)256,
        All = (uint)4294967295,
    }
    public partial class SettingLabel : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.SettingLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.SettingLabel>
    {
        internal SettingLabel() { }
        public string Name { get { throw null; } }
        protected virtual Azure.Data.AppConfiguration.SettingLabel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AppConfiguration.SettingLabel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.SettingLabel System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.SettingLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.SettingLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.SettingLabel System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.SettingLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.SettingLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.SettingLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SettingLabelFields : System.IEquatable<Azure.Data.AppConfiguration.SettingLabelFields>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SettingLabelFields(string value) { throw null; }
        public static Azure.Data.AppConfiguration.SettingLabelFields Name { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.SettingLabelFields other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.SettingLabelFields left, Azure.Data.AppConfiguration.SettingLabelFields right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.SettingLabelFields (string value) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.SettingLabelFields? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.SnapshotComposition left, Azure.Data.AppConfiguration.SnapshotComposition right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.SnapshotComposition (string value) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.SnapshotComposition? (string value) { throw null; }
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
        public static Azure.Data.AppConfiguration.SnapshotFields Description { get { throw null; } }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.SnapshotFields left, Azure.Data.AppConfiguration.SnapshotFields right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.SnapshotFields (string value) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.SnapshotFields? (string value) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusOverride : System.IEquatable<Azure.Data.AppConfiguration.StatusOverride>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusOverride(string value) { throw null; }
        public static Azure.Data.AppConfiguration.StatusOverride Disabled { get { throw null; } }
        public static Azure.Data.AppConfiguration.StatusOverride Enabled { get { throw null; } }
        public static Azure.Data.AppConfiguration.StatusOverride None { get { throw null; } }
        public bool Equals(Azure.Data.AppConfiguration.StatusOverride other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Data.AppConfiguration.StatusOverride left, Azure.Data.AppConfiguration.StatusOverride right) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.StatusOverride (string value) { throw null; }
        public static implicit operator Azure.Data.AppConfiguration.StatusOverride? (string value) { throw null; }
        public static bool operator !=(Azure.Data.AppConfiguration.StatusOverride left, Azure.Data.AppConfiguration.StatusOverride right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserAllocation : System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.UserAllocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.UserAllocation>
    {
        public UserAllocation(string variant, System.Collections.Generic.IEnumerable<string> users) { }
        public System.Collections.Generic.IList<string> Users { get { throw null; } }
        public string Variant { get { throw null; } set { } }
        protected virtual Azure.Data.AppConfiguration.UserAllocation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Data.AppConfiguration.UserAllocation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Data.AppConfiguration.UserAllocation System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.UserAllocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Data.AppConfiguration.UserAllocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Data.AppConfiguration.UserAllocation System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.UserAllocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.UserAllocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Data.AppConfiguration.UserAllocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
