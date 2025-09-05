namespace Azure.ResourceManager.ApplicationInsights
{
    public partial class ApplicationInsightsComponentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>, System.Collections.IEnumerable
    {
        protected ApplicationInsightsComponentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationInsightsComponentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>
    {
        public ApplicationInsightsComponentData(Azure.Core.AzureLocation location, string kind) { }
        public string AppId { get { throw null; } }
        public string ApplicationId { get { throw null; } }
        public Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType? ApplicationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType? FlowType { get { throw null; } set { } }
        public string HockeyAppId { get { throw null; } set { } }
        public string HockeyAppToken { get { throw null; } }
        public Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode? IngestionMode { get { throw null; } set { } }
        public string InstrumentationKey { get { throw null; } }
        public bool? IsDisableIPMasking { get { throw null; } set { } }
        public bool? IsDisableLocalAuth { get { throw null; } set { } }
        public bool? IsForceCustomerStorageForProfiler { get { throw null; } set { } }
        public bool? IsImmediatePurgeDataOn30Days { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LaMigrationOn { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference> PrivateLinkScopedResources { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType? PublicNetworkAccessForIngestion { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType? PublicNetworkAccessForQuery { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource? RequestSource { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public double? SamplingPercentage { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.Core.ResourceIdentifier WorkspaceResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationInsightsComponentResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite> AddFavorite(string favoriteId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite favoriteProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>> AddFavoriteAsync(string favoriteId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite favoriteProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem> AddOrUpdateAnalyticsItem(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath scopePath, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem itemProperties, bool? overrideItem = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>> AddOrUpdateAnalyticsItemAsync(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath scopePath, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem itemProperties, bool? overrideItem = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation> CreateAnnotations(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation annotationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation> CreateAnnotationsAsync(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation annotationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey> CreateApiKey(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey>> CreateApiKeyAsync(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> CreateExportConfigurations(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> CreateExportConfigurationsAsync(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration> CreateWorkItemConfiguration(Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration workItemConfigurationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>> CreateWorkItemConfigurationAsync(Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration workItemConfigurationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAnalyticsItem(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath scopePath, string id = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAnalyticsItemAsync(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath scopePath, string id = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAnnotation(string annotationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAnnotationAsync(string annotationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey> DeleteApiKey(string keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey>> DeleteApiKeyAsync(string keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> DeleteExportConfiguration(string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>> DeleteExportConfigurationAsync(string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteFavorite(string favoriteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFavoriteAsync(string favoriteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteWorkItemConfiguration(string workItemConfigId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteWorkItemConfigurationAsync(string workItemConfigId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem> GetAnalyticsItem(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath scopePath, string id = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>> GetAnalyticsItemAsync(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath scopePath, string id = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem> GetAnalyticsItems(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath scopePath, Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope? scope = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope?), Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent? type = default(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent?), bool? includeContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem> GetAnalyticsItemsAsync(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath scopePath, Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope? scope = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope?), Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent? type = default(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent?), bool? includeContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation> GetAnnotations(string start, string end, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation> GetAnnotations(string annotationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation> GetAnnotationsAsync(string start, string end, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation> GetAnnotationsAsync(string annotationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey> GetApiKey(string keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey>> GetApiKeyAsync(string keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey> GetApiKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey> GetApiKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures> GetComponentAvailableFeature(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>> GetComponentAvailableFeatureAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures> GetComponentCurrentBillingFeature(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>> GetComponentCurrentBillingFeatureAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities> GetComponentFeatureCapability(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities>> GetComponentFeatureCapabilityAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus> GetComponentQuotaStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus>> GetComponentQuotaStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration> GetDefaultWorkItemConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>> GetDefaultWorkItemConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> GetExportConfiguration(string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>> GetExportConfigurationAsync(string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> GetExportConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> GetExportConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite> GetFavorite(string favoriteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>> GetFavoriteAsync(string favoriteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite> GetFavorites(Azure.ResourceManager.ApplicationInsights.Models.ComponentFavoriteType? favoriteType = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentFavoriteType?), Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType? sourceType = default(Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType?), bool? canFetchContent = default(bool?), System.Collections.Generic.IEnumerable<string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite> GetFavoritesAsync(Azure.ResourceManager.ApplicationInsights.Models.ComponentFavoriteType? favoriteType = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentFavoriteType?), Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType? sourceType = default(Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType?), bool? canFetchContent = default(bool?), System.Collections.Generic.IEnumerable<string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration> GetItemWorkItemConfiguration(string workItemConfigId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>> GetItemWorkItemConfigurationAsync(string workItemConfigId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration> GetProactiveDetectionConfiguration(string configurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration>> GetProactiveDetectionConfigurationAsync(string configurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration> GetProactiveDetectionConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration> GetProactiveDetectionConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult> GetPurgeStatus(string purgeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult>> GetPurgeStatusAsync(string purgeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation> GetWebTestLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation> GetWebTestLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetWebTests(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetWebTestsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration> GetWorkItemConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration> GetWorkItemConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult> Purge(Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult>> PurgeAsync(Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> Update(Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag componentTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag componentTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures> UpdateComponentCurrentBillingFeature(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures billingFeaturesProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>> UpdateComponentCurrentBillingFeatureAsync(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures billingFeaturesProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> UpdateExportConfiguration(string exportId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>> UpdateExportConfigurationAsync(string exportId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite> UpdateFavorite(string favoriteId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite favoriteProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>> UpdateFavoriteAsync(string favoriteId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite favoriteProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration> UpdateItemWorkItemConfiguration(string workItemConfigId, Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration workItemConfigurationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>> UpdateItemWorkItemConfigurationAsync(string workItemConfigId, Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration workItemConfigurationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration> UpdateProactiveDetectionConfiguration(string configurationId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration proactiveDetectionProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration>> UpdateProactiveDetectionConfigurationAsync(string configurationId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration proactiveDetectionProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ApplicationInsightsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetApplicationInsightsComponent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> GetApplicationInsightsComponentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource GetApplicationInsightsComponentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentCollection GetApplicationInsightsComponents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetApplicationInsightsComponents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetApplicationInsightsComponentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetApplicationInsightsWebTest(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>> GetApplicationInsightsWebTestAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource GetApplicationInsightsWebTestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestCollection GetApplicationInsightsWebTests(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetApplicationInsightsWebTests(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetApplicationInsightsWebTestsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> GetApplicationInsightsWorkbook(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource>> GetApplicationInsightsWorkbookAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource GetApplicationInsightsWorkbookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource GetApplicationInsightsWorkbookRevisionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookCollection GetApplicationInsightsWorkbooks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> GetApplicationInsightsWorkbooks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> GetApplicationInsightsWorkbooksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> GetApplicationInsightsWorkbookTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>> GetApplicationInsightsWorkbookTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource GetApplicationInsightsWorkbookTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateCollection GetApplicationInsightsWorkbookTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult> GetLiveToken(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult>> GetLiveTokenAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationInsightsWebTestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>, System.Collections.IEnumerable
    {
        protected ApplicationInsightsWebTestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string webTestName, Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string webTestName, Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> Get(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>> GetAsync(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetIfExists(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>> GetIfExistsAsync(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationInsightsWebTestData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>
    {
        public ApplicationInsightsWebTestData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public int? FrequencyInSeconds { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsRetryEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WebTestKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation> Locations { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest Request { get { throw null; } set { } }
        public string SyntheticMonitorId { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules ValidationRules { get { throw null; } set { } }
        public string WebTest { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WebTestKind? WebTestKind { get { throw null; } set { } }
        public string WebTestName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsWebTestResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationInsightsWebTestResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string webTestName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> Update(Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag webTestTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag webTestTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationInsightsWorkbookCollection : Azure.ResourceManager.ArmCollection
    {
        protected ApplicationInsightsWorkbookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData data, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData data, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> Get(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> GetAll(Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, string sourceId = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> GetAllAsync(Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, string sourceId = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource>> GetAsync(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> GetIfExists(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource>> GetIfExistsAsync(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationInsightsWorkbookData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>
    {
        public ApplicationInsightsWorkbookData(Azure.Core.AzureLocation location) { }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind? Kind { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string Revision { get { throw null; } }
        public string SerializedData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
        public string UserId { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsWorkbookResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationInsightsWorkbookResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> Get(bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource> GetApplicationInsightsWorkbookRevision(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource>> GetApplicationInsightsWorkbookRevisionAsync(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionCollection GetApplicationInsightsWorkbookRevisions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource>> GetAsync(bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> Update(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch patch, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch patch, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationInsightsWorkbookRevisionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource>, System.Collections.IEnumerable
    {
        protected ApplicationInsightsWorkbookRevisionCollection() { }
        public virtual Azure.Response<bool> Exists(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource> Get(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource>> GetAsync(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource> GetIfExists(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource>> GetIfExistsAsync(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationInsightsWorkbookRevisionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationInsightsWorkbookRevisionResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string revisionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsWorkbookTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>, System.Collections.IEnumerable
    {
        protected ApplicationInsightsWorkbookTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationInsightsWorkbookTemplateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>
    {
        public ApplicationInsightsWorkbookTemplateData(Azure.Core.AzureLocation location) { }
        public string Author { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery> Galleries { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>> LocalizedGalleries { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public System.BinaryData TemplateData { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsWorkbookTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationInsightsWorkbookTemplateResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> Update(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerApplicationInsightsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerApplicationInsightsContext() { }
        public static Azure.ResourceManager.ApplicationInsights.AzureResourceManagerApplicationInsightsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.ApplicationInsights.Mocking
{
    public partial class MockableApplicationInsightsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableApplicationInsightsArmClient() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource GetApplicationInsightsComponentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource GetApplicationInsightsWebTestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource GetApplicationInsightsWorkbookResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookRevisionResource GetApplicationInsightsWorkbookRevisionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource GetApplicationInsightsWorkbookTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult> GetLiveToken(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult>> GetLiveTokenAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableApplicationInsightsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApplicationInsightsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetApplicationInsightsComponent(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> GetApplicationInsightsComponentAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentCollection GetApplicationInsightsComponents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetApplicationInsightsWebTest(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource>> GetApplicationInsightsWebTestAsync(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestCollection GetApplicationInsightsWebTests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> GetApplicationInsightsWorkbook(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource>> GetApplicationInsightsWorkbookAsync(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookCollection GetApplicationInsightsWorkbooks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource> GetApplicationInsightsWorkbookTemplate(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateResource>> GetApplicationInsightsWorkbookTemplateAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateCollection GetApplicationInsightsWorkbookTemplates() { throw null; }
    }
    public partial class MockableApplicationInsightsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApplicationInsightsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetApplicationInsightsComponents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetApplicationInsightsComponentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetApplicationInsightsWebTests(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestResource> GetApplicationInsightsWebTestsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> GetApplicationInsightsWorkbooks(Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookResource> GetApplicationInsightsWorkbooksAsync(Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ApplicationInsights.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyticsItemScopePath : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyticsItemScopePath(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath AnalyticsItems { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath MyAnalyticsItems { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath left, Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath left, Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemScopePath right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyticsItemTypeContent : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyticsItemTypeContent(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent Folder { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent Function { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent None { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent Query { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent Recent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent left, Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent left, Azure.ResourceManager.ApplicationInsights.Models.AnalyticsItemTypeContent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationInsightsAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation>
    {
        public ApplicationInsightsAnnotation() { }
        public string AnnotationName { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public System.DateTimeOffset? EventOccurredOn { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Properties { get { throw null; } set { } }
        public string RelatedAnnotation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsApiKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent>
    {
        public ApplicationInsightsApiKeyContent() { }
        public System.Collections.Generic.IList<string> LinkedReadProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> LinkedWriteProperties { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApiKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationInsightsApplicationType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationInsightsApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType Other { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType left, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType left, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationInsightsComponentAnalyticsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>
    {
        public ApplicationInsightsComponentAnalyticsItem() { }
        public string ApplicationInsightsComponentAnalyticsItemFunctionAlias { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType? ComponentItemType { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope? Scope { get { throw null; } set { } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentApiKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey>
    {
        internal ApplicationInsightsComponentApiKey() { }
        public string ApiKey { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LinkedReadProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LinkedWriteProperties { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentAvailableFeatures : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>
    {
        internal ApplicationInsightsComponentAvailableFeatures() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature> Result { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentBillingFeatures : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>
    {
        public ApplicationInsightsComponentBillingFeatures() { }
        public System.Collections.Generic.IList<string> CurrentBillingFeatures { get { throw null; } }
        public Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap DataVolumeCap { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentDataVolumeCap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap>
    {
        public ApplicationInsightsComponentDataVolumeCap() { }
        public float? Cap { get { throw null; } set { } }
        public bool? IsStopSendNotificationWhenHitCap { get { throw null; } set { } }
        public bool? IsStopSendNotificationWhenHitThreshold { get { throw null; } set { } }
        public float? MaxHistoryCap { get { throw null; } }
        public int? ResetTime { get { throw null; } }
        public int? WarningThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentExportConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>
    {
        internal ApplicationInsightsComponentExportConfiguration() { }
        public string ApplicationName { get { throw null; } }
        public string ContainerName { get { throw null; } }
        public Azure.Core.ResourceIdentifier DestinationAccountId { get { throw null; } }
        public string DestinationStorageLocationId { get { throw null; } }
        public string DestinationStorageSubscriptionId { get { throw null; } }
        public string DestinationType { get { throw null; } }
        public string ExportId { get { throw null; } }
        public string ExportStatus { get { throw null; } }
        public string InstrumentationKey { get { throw null; } }
        public string IsNotificationQueueEnabled { get { throw null; } }
        public string IsUserEnabled { get { throw null; } }
        public System.DateTimeOffset? LastGappedOn { get { throw null; } }
        public System.DateTimeOffset? LastSucceededOn { get { throw null; } }
        public System.DateTimeOffset? LastUserUpdatedOn { get { throw null; } }
        public string PermanentErrorReason { get { throw null; } }
        public string RecordTypes { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string StorageName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentExportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent>
    {
        public ApplicationInsightsComponentExportContent() { }
        public Azure.Core.ResourceIdentifier DestinationAccountId { get { throw null; } set { } }
        public string DestinationAddress { get { throw null; } set { } }
        public string DestinationStorageLocationId { get { throw null; } set { } }
        public string DestinationStorageSubscriptionId { get { throw null; } set { } }
        public string DestinationType { get { throw null; } set { } }
        public string IsEnabled { get { throw null; } set { } }
        public string IsNotificationQueueEnabled { get { throw null; } set { } }
        public System.Uri NotificationQueueUri { get { throw null; } set { } }
        public string RecordTypes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentFavorite : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>
    {
        public ApplicationInsightsComponentFavorite() { }
        public string Category { get { throw null; } set { } }
        public string Config { get { throw null; } set { } }
        public string FavoriteId { get { throw null; } }
        public Azure.ResourceManager.ApplicationInsights.Models.ComponentFavoriteType? FavoriteType { get { throw null; } set { } }
        public bool? IsGeneratedFromTemplate { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string SourceType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        public string UserId { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentFeature : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature>
    {
        internal ApplicationInsightsComponentFeature() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability> Capabilities { get { throw null; } }
        public string FeatureName { get { throw null; } }
        public bool? IsHidden { get { throw null; } }
        public bool? IsMainFeature { get { throw null; } }
        public string MeterId { get { throw null; } }
        public string MeterRateFrequency { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string SupportedAddonFeatures { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentFeatureCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities>
    {
        internal ApplicationInsightsComponentFeatureCapabilities() { }
        public bool? AnalyticsIntegration { get { throw null; } }
        public string ApiAccessLevel { get { throw null; } }
        public bool? ApplicationMap { get { throw null; } }
        public string BurstThrottlePolicy { get { throw null; } }
        public float? DailyCap { get { throw null; } }
        public float? DailyCapResetTime { get { throw null; } }
        public bool? IsExportDataSupported { get { throw null; } }
        public bool? LiveStreamMetrics { get { throw null; } }
        public string MetadataClass { get { throw null; } }
        public bool? MultipleStepWebTest { get { throw null; } }
        public bool? OpenSchema { get { throw null; } }
        public bool? PowerBIIntegration { get { throw null; } }
        public bool? ProactiveDetection { get { throw null; } }
        public float? ThrottleRate { get { throw null; } }
        public string TrackingType { get { throw null; } }
        public bool? WorkItemIntegration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentFeatureCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability>
    {
        internal ApplicationInsightsComponentFeatureCapability() { }
        public string Description { get { throw null; } }
        public string MeterId { get { throw null; } }
        public string MeterRateFrequency { get { throw null; } }
        public string Name { get { throw null; } }
        public string Unit { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentProactiveDetectionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration>
    {
        public ApplicationInsightsComponentProactiveDetectionConfiguration() { }
        public System.Collections.Generic.IList<string> CustomEmails { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions RuleDefinitions { get { throw null; } set { } }
        public bool? SendEmailsToSubscriptionOwners { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions>
    {
        public ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri HelpUri { get { throw null; } set { } }
        public bool? IsEmailNotificationsSupported { get { throw null; } set { } }
        public bool? IsEnabledByDefault { get { throw null; } set { } }
        public bool? IsHidden { get { throw null; } set { } }
        public bool? IsInPreview { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentQuotaStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus>
    {
        internal ApplicationInsightsComponentQuotaStatus() { }
        public string AppId { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? ShouldBeThrottled { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentWebTestLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>
    {
        internal ApplicationInsightsComponentWebTestLocation() { }
        public string DisplayName { get { throw null; } }
        public string Tag { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationInsightsPublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationInsightsPublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType left, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType left, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationInsightsWorkbookPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch>
    {
        public ApplicationInsightsWorkbookPatch() { }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WorkbookUpdateSharedTypeKind? Kind { get { throw null; } set { } }
        public string Revision { get { throw null; } set { } }
        public string SerializedData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> TagsPropertiesTags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsWorkbookTemplatePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch>
    {
        public ApplicationInsightsWorkbookTemplatePatch() { }
        public string Author { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery> Galleries { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>> Localized { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.BinaryData TemplateData { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsWorkbookTemplatePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmApplicationInsightsModelFactory
    {
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem ApplicationInsightsComponentAnalyticsItem(string id = null, string name = null, string content = null, string version = null, Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope? scope = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope?), Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType? componentItemType = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string applicationInsightsComponentAnalyticsItemFunctionAlias = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentApiKey ApplicationInsightsComponentApiKey(string id = null, string apiKey = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string name = null, System.Collections.Generic.IEnumerable<string> linkedReadProperties = null, System.Collections.Generic.IEnumerable<string> linkedWriteProperties = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures ApplicationInsightsComponentAvailableFeatures(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature> result = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData ApplicationInsightsComponentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string kind = null, Azure.ETag? etag = default(Azure.ETag?), string applicationId = null, string appId = null, string namePropertiesName = null, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType? applicationType = default(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsApplicationType?), Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType? flowType = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType?), Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource? requestSource = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource?), string instrumentationKey = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Guid? tenantId = default(System.Guid?), string hockeyAppId = null, string hockeyAppToken = null, string provisioningState = null, double? samplingPercentage = default(double?), string connectionString = null, int? retentionInDays = default(int?), bool? isDisableIPMasking = default(bool?), bool? isImmediatePurgeDataOn30Days = default(bool?), Azure.Core.ResourceIdentifier workspaceResourceId = null, System.DateTimeOffset? laMigrationOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference> privateLinkScopedResources = null, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType? publicNetworkAccessForIngestion = default(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType?), Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType? publicNetworkAccessForQuery = default(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsPublicNetworkAccessType?), Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode? ingestionMode = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode?), bool? isDisableLocalAuth = default(bool?), bool? isForceCustomerStorageForProfiler = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap ApplicationInsightsComponentDataVolumeCap(float? cap = default(float?), int? resetTime = default(int?), int? warningThreshold = default(int?), bool? isStopSendNotificationWhenHitThreshold = default(bool?), bool? isStopSendNotificationWhenHitCap = default(bool?), float? maxHistoryCap = default(float?)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration ApplicationInsightsComponentExportConfiguration(string exportId = null, string instrumentationKey = null, string recordTypes = null, string applicationName = null, string subscriptionId = null, string resourceGroup = null, string destinationStorageSubscriptionId = null, string destinationStorageLocationId = null, Azure.Core.ResourceIdentifier destinationAccountId = null, string destinationType = null, string isUserEnabled = null, System.DateTimeOffset? lastUserUpdatedOn = default(System.DateTimeOffset?), string isNotificationQueueEnabled = null, string exportStatus = null, System.DateTimeOffset? lastSucceededOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastGappedOn = default(System.DateTimeOffset?), string permanentErrorReason = null, string storageName = null, string containerName = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite ApplicationInsightsComponentFavorite(string name = null, string config = null, string version = null, string favoriteId = null, Azure.ResourceManager.ApplicationInsights.Models.ComponentFavoriteType? favoriteType = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentFavoriteType?), string sourceType = null, System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> tags = null, string category = null, bool? isGeneratedFromTemplate = default(bool?), string userId = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature ApplicationInsightsComponentFeature(string featureName = null, string meterId = null, string meterRateFrequency = null, Azure.Core.ResourceIdentifier resourceId = null, bool? isHidden = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability> capabilities = null, string title = null, bool? isMainFeature = default(bool?), string supportedAddonFeatures = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities ApplicationInsightsComponentFeatureCapabilities(bool? isExportDataSupported = default(bool?), string burstThrottlePolicy = null, string metadataClass = null, bool? liveStreamMetrics = default(bool?), bool? applicationMap = default(bool?), bool? workItemIntegration = default(bool?), bool? powerBIIntegration = default(bool?), bool? openSchema = default(bool?), bool? proactiveDetection = default(bool?), bool? analyticsIntegration = default(bool?), bool? multipleStepWebTest = default(bool?), string apiAccessLevel = null, string trackingType = null, float? dailyCap = default(float?), float? dailyCapResetTime = default(float?), float? throttleRate = default(float?)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability ApplicationInsightsComponentFeatureCapability(string name = null, string description = null, string value = null, string unit = null, string meterId = null, string meterRateFrequency = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus ApplicationInsightsComponentQuotaStatus(string appId = null, bool? shouldBeThrottled = default(bool?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation ApplicationInsightsComponentWebTestLocation(string displayName = null, string tag = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWebTestData ApplicationInsightsWebTestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ApplicationInsights.Models.WebTestKind? kind = default(Azure.ResourceManager.ApplicationInsights.Models.WebTestKind?), string syntheticMonitorId = null, string webTestName = null, string description = null, bool? isEnabled = default(bool?), int? frequencyInSeconds = default(int?), int? timeoutInSeconds = default(int?), Azure.ResourceManager.ApplicationInsights.Models.WebTestKind? webTestKind = default(Azure.ResourceManager.ApplicationInsights.Models.WebTestKind?), bool? isRetryEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation> locations = null, string webTest = null, string provisioningState = null, Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest request = null, Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules validationRules = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookData ApplicationInsightsWorkbookData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string displayName = null, string serializedData = null, string version = null, System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string category = null, string userId = null, Azure.Core.ResourceIdentifier sourceId = null, System.Uri storageUri = null, string description = null, string revision = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind? kind = default(Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsWorkbookTemplateData ApplicationInsightsWorkbookTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? priority = default(int?), string author = null, System.BinaryData templateData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery> galleries = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>> localizedGalleries = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult ComponentPurgeResult(string operationId = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult ComponentPurgeStatusResult(Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState status = default(Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult LiveTokenResult(string liveToken = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference PrivateLinkScopedResourceReference(Azure.Core.ResourceIdentifier resourceId = null, string scopeId = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration WorkItemConfiguration(string connectorId = null, string configDisplayName = null, bool? isDefault = default(bool?), string id = null, string configProperties = null) { throw null; }
    }
    public enum ComponentFavoriteType
    {
        Shared = 0,
        User = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentFlowType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentFlowType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType Bluefield { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType left, Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType left, Azure.ResourceManager.ApplicationInsights.Models.ComponentFlowType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentIngestionMode : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentIngestionMode(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode ApplicationInsights { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode ApplicationInsightsWithDiagnosticSettings { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode LogAnalytics { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode left, Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode left, Azure.ResourceManager.ApplicationInsights.Models.ComponentIngestionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentItemScope : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentItemScope(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope Shared { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope left, Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope left, Azure.ResourceManager.ApplicationInsights.Models.ComponentItemScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentItemType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentItemType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType Function { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType None { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType Query { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType Recent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType left, Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType left, Azure.ResourceManager.ApplicationInsights.Models.ComponentItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComponentPurgeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent>
    {
        public ComponentPurgeContent(string table, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters> filters) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters> Filters { get { throw null; } }
        public string Table { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPurgeFilters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters>
    {
        public ComponentPurgeFilters() { }
        public string Column { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPurgeResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult>
    {
        internal ComponentPurgeResult() { }
        public string OperationId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentPurgeState : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentPurgeState(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState Completed { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState left, Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState left, Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComponentPurgeStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult>
    {
        internal ComponentPurgeStatusResult() { }
        public Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeState Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentRequestSource : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentRequestSource(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource Rest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource left, Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource left, Azure.ResourceManager.ApplicationInsights.Models.ComponentRequestSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FavoriteSourceType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FavoriteSourceType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType Events { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType Funnel { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType Impact { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType Notebook { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType Retention { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType Segmentation { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType Sessions { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType Userflows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType left, Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType left, Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveTokenResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult>
    {
        internal LiveTokenResult() { }
        public string LiveToken { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateLinkScopedResourceReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference>
    {
        internal PrivateLinkScopedResourceReference() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string ScopeId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebTestComponentTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag>
    {
        public WebTestComponentTag() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestComponentTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebTestContentValidation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestContentValidation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestContentValidation>
    {
        public WebTestContentValidation() { }
        public string ContentMatch { get { throw null; } set { } }
        public bool? IgnoreCase { get { throw null; } set { } }
        public bool? PassIfTextFound { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestContentValidation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestContentValidation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestContentValidation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestContentValidation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestContentValidation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestContentValidation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestContentValidation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebTestGeolocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>
    {
        public WebTestGeolocation() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WebTestKind
    {
        Ping = 0,
        MultiStep = 1,
        Standard = 2,
    }
    public partial class WebTestRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest>
    {
        public WebTestRequest() { }
        public bool? FollowRedirects { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequestHeaderField> Headers { get { throw null; } }
        public string HttpVerb { get { throw null; } set { } }
        public bool? ParseDependentRequests { get { throw null; } set { } }
        public string RequestBody { get { throw null; } set { } }
        public System.Uri RequestUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebTestRequestHeaderField : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequestHeaderField>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequestHeaderField>
    {
        public WebTestRequestHeaderField() { }
        public string HeaderFieldName { get { throw null; } set { } }
        public string HeaderFieldValue { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestRequestHeaderField System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequestHeaderField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequestHeaderField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestRequestHeaderField System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequestHeaderField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequestHeaderField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestRequestHeaderField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebTestValidationRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules>
    {
        public WebTestValidationRules() { }
        public bool? CheckSsl { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WebTestContentValidation ContentValidation { get { throw null; } set { } }
        public int? ExpectedHttpStatusCode { get { throw null; } set { } }
        public bool? IgnoreHttpStatusCode { get { throw null; } set { } }
        public int? SslCertRemainingLifetimeCheck { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestValidationRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkbookCategoryType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkbookCategoryType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType Performance { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType Retention { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType Tsg { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType Workbook { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType left, Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType left, Azure.ResourceManager.ApplicationInsights.Models.WorkbookCategoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkbookSharedTypeKind : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkbookSharedTypeKind(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind left, Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind left, Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkbookTemplateGallery : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery>
    {
        public WorkbookTemplateGallery() { }
        public string Category { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        public string WorkbookType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkbookTemplateLocalizedGallery : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>
    {
        public WorkbookTemplateLocalizedGallery() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery> Galleries { get { throw null; } }
        public System.BinaryData TemplateData { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkbookUpdateSharedTypeKind : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.WorkbookUpdateSharedTypeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkbookUpdateSharedTypeKind(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.WorkbookUpdateSharedTypeKind Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.WorkbookUpdateSharedTypeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.WorkbookUpdateSharedTypeKind left, Azure.ResourceManager.ApplicationInsights.Models.WorkbookUpdateSharedTypeKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.WorkbookUpdateSharedTypeKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.WorkbookUpdateSharedTypeKind left, Azure.ResourceManager.ApplicationInsights.Models.WorkbookUpdateSharedTypeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkItemConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>
    {
        internal WorkItemConfiguration() { }
        public string ConfigDisplayName { get { throw null; } }
        public string ConfigProperties { get { throw null; } }
        public string ConnectorId { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkItemCreateConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>
    {
        public WorkItemCreateConfiguration() { }
        public string ConnectorDataConfiguration { get { throw null; } set { } }
        public string ConnectorId { get { throw null; } set { } }
        public bool? IsValidateOnly { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> WorkItemProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
