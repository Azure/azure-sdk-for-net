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
        public Azure.ResourceManager.ApplicationInsights.Models.ApplicationType? ApplicationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.FlowType? FlowType { get { throw null; } set { } }
        public string HockeyAppId { get { throw null; } set { } }
        public string HockeyAppToken { get { throw null; } }
        public Azure.ResourceManager.ApplicationInsights.Models.IngestionMode? IngestionMode { get { throw null; } set { } }
        public string InstrumentationKey { get { throw null; } }
        public bool? IsDisableIPMasking { get { throw null; } set { } }
        public bool? IsDisableLocalAuth { get { throw null; } set { } }
        public bool? IsForceCustomerStorageForProfiler { get { throw null; } set { } }
        public bool? IsImmediatePurgeDataOn30Days { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LaMigrationOn { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent> PrivateLinkScopedResources { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType? PublicNetworkAccessForIngestion { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType? PublicNetworkAccessForQuery { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.RequestSource? RequestSource { get { throw null; } set { } }
        public int? RetentionInDays { get { throw null; } set { } }
        public double? SamplingPercentage { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public string WorkspaceResourceId { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationInsightsComponentResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite> AddFavorite(string favoriteId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite favoriteProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>> AddFavoriteAsync(string favoriteId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite favoriteProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.Annotation> CreateAnnotations(Azure.ResourceManager.ApplicationInsights.Models.Annotation annotationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.Annotation> CreateAnnotationsAsync(Azure.ResourceManager.ApplicationInsights.Models.Annotation annotationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey> CreateAPIKey(Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey>> CreateAPIKeyAsync(Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> CreateExportConfigurations(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest exportProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> CreateExportConfigurationsAsync(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest exportProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration> CreateWorkItemConfiguration(Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration workItemConfigurationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>> CreateWorkItemConfigurationAsync(Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration workItemConfigurationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAnalyticsItem(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath scopePath, string id = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAnalyticsItemAsync(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath scopePath, string id = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAnnotation(string annotationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAnnotationAsync(string annotationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey> DeleteAPIKey(string keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey>> DeleteAPIKeyAsync(string keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> DeleteExportConfiguration(string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>> DeleteExportConfigurationAsync(string exportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteFavorite(string favoriteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteFavoriteAsync(string favoriteId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteWorkItemConfiguration(string workItemConfigId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteWorkItemConfigurationAsync(string workItemConfigId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem> GetAnalyticsItem(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath scopePath, string id = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>> GetAnalyticsItemAsync(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath scopePath, string id = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem> GetAnalyticsItems(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath scopePath, Azure.ResourceManager.ApplicationInsights.Models.ItemScope? scope = default(Azure.ResourceManager.ApplicationInsights.Models.ItemScope?), Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter? type = default(Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter?), bool? includeContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem> GetAnalyticsItemsAsync(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath scopePath, Azure.ResourceManager.ApplicationInsights.Models.ItemScope? scope = default(Azure.ResourceManager.ApplicationInsights.Models.ItemScope?), Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter? type = default(Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter?), bool? includeContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.Annotation> GetAnnotations(string start, string end, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.Annotation> GetAnnotations(string annotationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.Annotation> GetAnnotationsAsync(string start, string end, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.Annotation> GetAnnotationsAsync(string annotationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey> GetAPIKey(string keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey>> GetAPIKeyAsync(string keyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey> GetAPIKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey> GetAPIKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures> GetComponentAvailableFeature(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>> GetComponentAvailableFeatureAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures> GetComponentCurrentBillingFeature(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>> GetComponentCurrentBillingFeatureAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities> GetComponentFeatureCapability(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities>> GetComponentFeatureCapabilityAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> GetComponentLinkedStorageAccount(Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> GetComponentLinkedStorageAccountAsync(Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountCollection GetComponentLinkedStorageAccounts() { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite> GetFavorites(Azure.ResourceManager.ApplicationInsights.Models.FavoriteType? favoriteType = default(Azure.ResourceManager.ApplicationInsights.Models.FavoriteType?), Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType? sourceType = default(Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType?), bool? canFetchContent = default(bool?), System.Collections.Generic.IEnumerable<string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite> GetFavoritesAsync(Azure.ResourceManager.ApplicationInsights.Models.FavoriteType? favoriteType = default(Azure.ResourceManager.ApplicationInsights.Models.FavoriteType?), Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType? sourceType = default(Azure.ResourceManager.ApplicationInsights.Models.FavoriteSourceType?), bool? canFetchContent = default(bool?), System.Collections.Generic.IEnumerable<string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration> GetItemWorkItemConfiguration(string workItemConfigId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration>> GetItemWorkItemConfigurationAsync(string workItemConfigId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration> GetProactiveDetectionConfiguration(string configurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration>> GetProactiveDetectionConfigurationAsync(string configurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration> GetProactiveDetectionConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfiguration> GetProactiveDetectionConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse> GetPurgeStatus(string purgeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse>> GetPurgeStatusAsync(string purgeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation> GetWebTestLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation> GetWebTestLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetWebTests(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetWebTestsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration> GetWorkItemConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration> GetWorkItemConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse> Purge(Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse>> PurgeAsync(Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem> PutAnalyticsItem(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath scopePath, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem itemProperties, bool? overrideItem = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>> PutAnalyticsItemAsync(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath scopePath, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem itemProperties, bool? overrideItem = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> Update(Azure.ResourceManager.ApplicationInsights.Models.ComponentTag componentTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.Models.ComponentTag componentTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures> UpdateComponentCurrentBillingFeature(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures billingFeaturesProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures>> UpdateComponentCurrentBillingFeatureAsync(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentBillingFeatures billingFeaturesProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration> UpdateExportConfiguration(string exportId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest exportProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>> UpdateExportConfigurationAsync(string exportId, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest exportProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource GetComponentLinkedStorageAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse> GetLiveToken(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse>> GetLiveTokenAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> GetMyWorkbook(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource>> GetMyWorkbookAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.MyWorkbookResource GetMyWorkbookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.MyWorkbookCollection GetMyWorkbooks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> GetMyWorkbooks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> GetMyWorkbooksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetWebTest(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource>> GetWebTestAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.WebTestResource GetWebTestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.WebTestCollection GetWebTests(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetWebTests(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetWebTestsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource> GetWorkbook(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource>> GetWorkbookAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.WorkbookResource GetWorkbookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource GetWorkbookRevisionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.WorkbookCollection GetWorkbooks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApplicationInsights.WorkbookResource> GetWorkbooks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.WorkbookResource> GetWorkbooksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> GetWorkbookTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>> GetWorkbookTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource GetWorkbookTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.WorkbookTemplateCollection GetWorkbookTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
    }
    public partial class ComponentLinkedStorageAccountCollection : Azure.ResourceManager.ArmCollection
    {
        protected ComponentLinkedStorageAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> Get(Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> GetAsync(Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> GetIfExists(Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> GetIfExistsAsync(Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComponentLinkedStorageAccountData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData>
    {
        public ComponentLinkedStorageAccountData() { }
        public string LinkedStorageAccount { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentLinkedStorageAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComponentLinkedStorageAccountResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, Azure.ResourceManager.ApplicationInsights.Models.StorageType storageType) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource> Update(Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MyWorkbookCollection : Azure.ResourceManager.ArmCollection
    {
        protected MyWorkbookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.MyWorkbookData data, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.MyWorkbookData data, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> GetAll(Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, string sourceId = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> GetAllAsync(Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, string sourceId = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MyWorkbookData : Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookResourceContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.MyWorkbookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.MyWorkbookData>
    {
        public MyWorkbookData() { }
        public string Category { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind? Kind { get { throw null; } set { } }
        public string SerializedData { get { throw null; } set { } }
        public string SourceId { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
        public string TimeModified { get { throw null; } }
        public string UserId { get { throw null; } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.MyWorkbookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.MyWorkbookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.MyWorkbookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.MyWorkbookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.MyWorkbookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.MyWorkbookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.MyWorkbookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MyWorkbookResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MyWorkbookResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.MyWorkbookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> Update(Azure.ResourceManager.ApplicationInsights.MyWorkbookData data, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.MyWorkbookData data, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebTestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.WebTestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.WebTestResource>, System.Collections.IEnumerable
    {
        protected WebTestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.WebTestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string webTestName, Azure.ResourceManager.ApplicationInsights.WebTestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.WebTestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string webTestName, Azure.ResourceManager.ApplicationInsights.WebTestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource> Get(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource>> GetAsync(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetIfExists(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.WebTestResource>> GetIfExistsAsync(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApplicationInsights.WebTestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.WebTestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApplicationInsights.WebTestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.WebTestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebTestData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.WebTestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WebTestData>
    {
        public WebTestData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public int? FrequencyInSeconds { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsRetryEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WebTestKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation> Locations { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest Request { get { throw null; } set { } }
        public string SyntheticMonitorId { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules ValidationRules { get { throw null; } set { } }
        public string WebTest { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WebTestKind? WebTestKind { get { throw null; } set { } }
        public string WebTestName { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.WebTestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.WebTestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.WebTestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.WebTestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WebTestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WebTestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WebTestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebTestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebTestResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.WebTestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string webTestName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource> Update(Azure.ResourceManager.ApplicationInsights.Models.ComponentTag webTestTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.Models.ComponentTag webTestTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkbookCollection : Azure.ResourceManager.ArmCollection
    {
        protected WorkbookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.WorkbookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.WorkbookData data, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.WorkbookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.WorkbookData data, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource> Get(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.WorkbookResource> GetAll(Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, string sourceId = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.WorkbookResource> GetAllAsync(Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, string sourceId = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource>> GetAsync(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.WorkbookResource> GetIfExists(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.WorkbookResource>> GetIfExistsAsync(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkbookData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.WorkbookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WorkbookData>
    {
        public WorkbookData(Azure.Core.AzureLocation location) { }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind? Kind { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string Revision { get { throw null; } }
        public string SerializedData { get { throw null; } set { } }
        public string SourceId { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
        public string UserId { get { throw null; } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.WorkbookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.WorkbookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.WorkbookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.WorkbookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WorkbookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WorkbookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WorkbookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkbookResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkbookResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.WorkbookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource> Get(bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource>> GetAsync(bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource> GetWorkbookRevision(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource>> GetWorkbookRevisionAsync(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.WorkbookRevisionCollection GetWorkbookRevisions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource> Update(Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch patch, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch patch, string sourceId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkbookRevisionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource>, System.Collections.IEnumerable
    {
        protected WorkbookRevisionCollection() { }
        public virtual Azure.Response<bool> Exists(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource> Get(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource>> GetAsync(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource> GetIfExists(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource>> GetIfExistsAsync(string revisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkbookRevisionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkbookRevisionResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.WorkbookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string revisionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkbookTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>, System.Collections.IEnumerable
    {
        protected WorkbookTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkbookTemplateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData>
    {
        public WorkbookTemplateData(Azure.Core.AzureLocation location) { }
        public string Author { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery> Galleries { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>> LocalizedGalleries { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public System.BinaryData TemplateData { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkbookTemplateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkbookTemplateResource() { }
        public virtual Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> Update(Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>> UpdateAsync(Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ApplicationInsights.Mocking
{
    public partial class MockableApplicationInsightsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableApplicationInsightsArmClient() { }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource GetApplicationInsightsComponentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountResource GetComponentLinkedStorageAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse> GetLiveToken(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse>> GetLiveTokenAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.MyWorkbookResource GetMyWorkbookResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.WebTestResource GetWebTestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.WorkbookResource GetWorkbookResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.WorkbookRevisionResource GetWorkbookRevisionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource GetWorkbookTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableApplicationInsightsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApplicationInsightsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetApplicationInsightsComponent(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource>> GetApplicationInsightsComponentAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentCollection GetApplicationInsightsComponents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> GetMyWorkbook(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource>> GetMyWorkbookAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.MyWorkbookCollection GetMyWorkbooks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetWebTest(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WebTestResource>> GetWebTestAsync(string webTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.WebTestCollection GetWebTests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource> GetWorkbook(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookResource>> GetWorkbookAsync(string resourceName, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.WorkbookCollection GetWorkbooks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource> GetWorkbookTemplate(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApplicationInsights.WorkbookTemplateResource>> GetWorkbookTemplateAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApplicationInsights.WorkbookTemplateCollection GetWorkbookTemplates() { throw null; }
    }
    public partial class MockableApplicationInsightsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableApplicationInsightsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetApplicationInsightsComponents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentResource> GetApplicationInsightsComponentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> GetMyWorkbooks(Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.MyWorkbookResource> GetMyWorkbooksAsync(Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetWebTests(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.WebTestResource> GetWebTestsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApplicationInsights.WorkbookResource> GetWorkbooks(Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApplicationInsights.WorkbookResource> GetWorkbooksAsync(Azure.ResourceManager.ApplicationInsights.Models.CategoryType category, System.Collections.Generic.IEnumerable<string> tags = null, bool? canFetchContent = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ApplicationInsights.Models
{
    public partial class Annotation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.Annotation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.Annotation>
    {
        public Annotation() { }
        public string AnnotationName { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public System.DateTimeOffset? EventOn { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Properties { get { throw null; } set { } }
        public string RelatedAnnotation { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.Annotation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.Annotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.Annotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.Annotation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.Annotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.Annotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.Annotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class APIKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent>
    {
        public APIKeyContent() { }
        public System.Collections.Generic.IList<string> LinkedReadProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> LinkedWriteProperties { get { throw null; } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.APIKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentAnalyticsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>
    {
        public ApplicationInsightsComponentAnalyticsItem() { }
        public string ApplicationInsightsComponentAnalyticsItemFunctionAlias { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.ItemType? ItemType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.ItemScope? Scope { get { throw null; } set { } }
        public string TimeCreated { get { throw null; } }
        public string TimeModified { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentAPIKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey>
    {
        internal ApplicationInsightsComponentAPIKey() { }
        public string ApiKey { get { throw null; } }
        public string CreatedDate { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LinkedReadProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LinkedWriteProperties { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentAvailableFeatures : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures>
    {
        internal ApplicationInsightsComponentAvailableFeatures() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature> Result { get { throw null; } }
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
        public string DestinationAccountId { get { throw null; } }
        public string DestinationStorageLocationId { get { throw null; } }
        public string DestinationStorageSubscriptionId { get { throw null; } }
        public string DestinationType { get { throw null; } }
        public string ExportId { get { throw null; } }
        public string ExportStatus { get { throw null; } }
        public string InstrumentationKey { get { throw null; } }
        public string IsUserEnabled { get { throw null; } }
        public string LastGapTime { get { throw null; } }
        public string LastSuccessTime { get { throw null; } }
        public string LastUserUpdate { get { throw null; } }
        public string NotificationQueueEnabled { get { throw null; } }
        public string PermanentErrorReason { get { throw null; } }
        public string RecordTypes { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string StorageName { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentExportRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest>
    {
        public ApplicationInsightsComponentExportRequest() { }
        public string DestinationAccountId { get { throw null; } set { } }
        public string DestinationAddress { get { throw null; } set { } }
        public string DestinationStorageLocationId { get { throw null; } set { } }
        public string DestinationStorageSubscriptionId { get { throw null; } set { } }
        public string DestinationType { get { throw null; } set { } }
        public string IsEnabled { get { throw null; } set { } }
        public string NotificationQueueEnabled { get { throw null; } set { } }
        public System.Uri NotificationQueueUri { get { throw null; } set { } }
        public string RecordTypes { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsComponentFavorite : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite>
    {
        public ApplicationInsightsComponentFavorite() { }
        public string Category { get { throw null; } set { } }
        public string Config { get { throw null; } set { } }
        public string FavoriteId { get { throw null; } }
        public Azure.ResourceManager.ApplicationInsights.Models.FavoriteType? FavoriteType { get { throw null; } set { } }
        public bool? IsGeneratedFromTemplate { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SourceType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        public string TimeModified { get { throw null; } }
        public string UserId { get { throw null; } }
        public string Version { get { throw null; } set { } }
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
        public string ResourceId { get { throw null; } }
        public string SupportedAddonFeatures { get { throw null; } }
        public string Title { get { throw null; } }
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
        public bool? LiveStreamMetrics { get { throw null; } }
        public string MetadataClass { get { throw null; } }
        public bool? MultipleStepWebTest { get { throw null; } }
        public bool? OpenSchema { get { throw null; } }
        public bool? PowerBIIntegration { get { throw null; } }
        public bool? ProactiveDetection { get { throw null; } }
        public bool? SupportExportData { get { throw null; } }
        public float? ThrottleRate { get { throw null; } }
        public string TrackingType { get { throw null; } }
        public bool? WorkItemIntegration { get { throw null; } }
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
        public string LastUpdatedTime { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentProactiveDetectionConfigurationRuleDefinitions RuleDefinitions { get { throw null; } set { } }
        public bool? SendEmailsToSubscriptionOwners { get { throw null; } set { } }
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
        public bool? IsEnabledByDefault { get { throw null; } set { } }
        public bool? IsHidden { get { throw null; } set { } }
        public bool? IsInPreview { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? SupportsEmailNotifications { get { throw null; } set { } }
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
        public string ExpirationTime { get { throw null; } }
        public bool? ShouldBeThrottled { get { throw null; } }
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
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationInsightsKind : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationInsightsKind(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind Shared { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind left, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind left, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationType Other { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationType Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ApplicationType left, Azure.ResourceManager.ApplicationInsights.Models.ApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ApplicationType left, Azure.ResourceManager.ApplicationInsights.Models.ApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmApplicationInsightsModelFactory
    {
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAnalyticsItem ApplicationInsightsComponentAnalyticsItem(string id = null, string name = null, string content = null, string version = null, Azure.ResourceManager.ApplicationInsights.Models.ItemScope? scope = default(Azure.ResourceManager.ApplicationInsights.Models.ItemScope?), Azure.ResourceManager.ApplicationInsights.Models.ItemType? itemType = default(Azure.ResourceManager.ApplicationInsights.Models.ItemType?), string timeCreated = null, string timeModified = null, string applicationInsightsComponentAnalyticsItemFunctionAlias = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAPIKey ApplicationInsightsComponentAPIKey(string id = null, string apiKey = null, string createdDate = null, string name = null, System.Collections.Generic.IEnumerable<string> linkedReadProperties = null, System.Collections.Generic.IEnumerable<string> linkedWriteProperties = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentAvailableFeatures ApplicationInsightsComponentAvailableFeatures(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature> result = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData ApplicationInsightsComponentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string kind = null, Azure.ETag? etag = default(Azure.ETag?), string applicationId = null, string appId = null, string namePropertiesName = null, Azure.ResourceManager.ApplicationInsights.Models.ApplicationType? applicationType = default(Azure.ResourceManager.ApplicationInsights.Models.ApplicationType?), Azure.ResourceManager.ApplicationInsights.Models.FlowType? flowType = default(Azure.ResourceManager.ApplicationInsights.Models.FlowType?), Azure.ResourceManager.ApplicationInsights.Models.RequestSource? requestSource = default(Azure.ResourceManager.ApplicationInsights.Models.RequestSource?), string instrumentationKey = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Guid? tenantId = default(System.Guid?), string hockeyAppId = null, string hockeyAppToken = null, string provisioningState = null, double? samplingPercentage = default(double?), string connectionString = null, int? retentionInDays = default(int?), bool? isDisableIPMasking = default(bool?), bool? isImmediatePurgeDataOn30Days = default(bool?), string workspaceResourceId = null, System.DateTimeOffset? laMigrationOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent> privateLinkScopedResources = null, Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType? publicNetworkAccessForIngestion = default(Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType?), Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType? publicNetworkAccessForQuery = default(Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType?), Azure.ResourceManager.ApplicationInsights.Models.IngestionMode? ingestionMode = default(Azure.ResourceManager.ApplicationInsights.Models.IngestionMode?), bool? isDisableLocalAuth = default(bool?), bool? isForceCustomerStorageForProfiler = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentDataVolumeCap ApplicationInsightsComponentDataVolumeCap(float? cap = default(float?), int? resetTime = default(int?), int? warningThreshold = default(int?), bool? isStopSendNotificationWhenHitThreshold = default(bool?), bool? isStopSendNotificationWhenHitCap = default(bool?), float? maxHistoryCap = default(float?)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentExportConfiguration ApplicationInsightsComponentExportConfiguration(string exportId = null, string instrumentationKey = null, string recordTypes = null, string applicationName = null, string subscriptionId = null, string resourceGroup = null, string destinationStorageSubscriptionId = null, string destinationStorageLocationId = null, string destinationAccountId = null, string destinationType = null, string isUserEnabled = null, string lastUserUpdate = null, string notificationQueueEnabled = null, string exportStatus = null, string lastSuccessTime = null, string lastGapTime = null, string permanentErrorReason = null, string storageName = null, string containerName = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFavorite ApplicationInsightsComponentFavorite(string name = null, string config = null, string version = null, string favoriteId = null, Azure.ResourceManager.ApplicationInsights.Models.FavoriteType? favoriteType = default(Azure.ResourceManager.ApplicationInsights.Models.FavoriteType?), string sourceType = null, string timeModified = null, System.Collections.Generic.IEnumerable<string> tags = null, string category = null, bool? isGeneratedFromTemplate = default(bool?), string userId = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeature ApplicationInsightsComponentFeature(string featureName = null, string meterId = null, string meterRateFrequency = null, string resourceId = null, bool? isHidden = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability> capabilities = null, string title = null, bool? isMainFeature = default(bool?), string supportedAddonFeatures = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapabilities ApplicationInsightsComponentFeatureCapabilities(bool? supportExportData = default(bool?), string burstThrottlePolicy = null, string metadataClass = null, bool? liveStreamMetrics = default(bool?), bool? applicationMap = default(bool?), bool? workItemIntegration = default(bool?), bool? powerBIIntegration = default(bool?), bool? openSchema = default(bool?), bool? proactiveDetection = default(bool?), bool? analyticsIntegration = default(bool?), bool? multipleStepWebTest = default(bool?), string apiAccessLevel = null, string trackingType = null, float? dailyCap = default(float?), float? dailyCapResetTime = default(float?), float? throttleRate = default(float?)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentFeatureCapability ApplicationInsightsComponentFeatureCapability(string name = null, string description = null, string value = null, string unit = null, string meterId = null, string meterRateFrequency = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentQuotaStatus ApplicationInsightsComponentQuotaStatus(string appId = null, bool? shouldBeThrottled = default(bool?), string expirationTime = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsComponentWebTestLocation ApplicationInsightsComponentWebTestLocation(string displayName = null, string tag = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.ComponentLinkedStorageAccountData ComponentLinkedStorageAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string linkedStorageAccount = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse ComponentPurgeResponse(string operationId = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse ComponentPurgeStatusResponse(Azure.ResourceManager.ApplicationInsights.Models.PurgeState status = default(Azure.ResourceManager.ApplicationInsights.Models.PurgeState)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse LiveTokenResponse(string liveToken = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.MyWorkbookData MyWorkbookData(Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity identity = null, string id = null, string name = null, string resourceType = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> etag = null, Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind? kind = default(Azure.ResourceManager.ApplicationInsights.Models.ApplicationInsightsKind?), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string serializedData = null, string version = null, string timeModified = null, string category = null, string userId = null, string sourceId = null, System.Uri storageUri = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities MyWorkbookUserAssignedIdentities(string principalId = null, System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent PrivateLinkScopedResourceContent(string resourceId = null, string scopeId = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.WebTestData WebTestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ApplicationInsights.Models.WebTestKind? kind = default(Azure.ResourceManager.ApplicationInsights.Models.WebTestKind?), string syntheticMonitorId = null, string webTestName = null, string description = null, bool? isEnabled = default(bool?), int? frequencyInSeconds = default(int?), int? timeoutInSeconds = default(int?), Azure.ResourceManager.ApplicationInsights.Models.WebTestKind? webTestKind = default(Azure.ResourceManager.ApplicationInsights.Models.WebTestKind?), bool? isRetryEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation> locations = null, string webTest = null, string provisioningState = null, Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest request = null, Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules validationRules = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.WorkbookData WorkbookData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string displayName = null, string serializedData = null, string version = null, System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string category = null, string userId = null, string sourceId = null, System.Uri storageUri = null, string description = null, string revision = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind? kind = default(Azure.ResourceManager.ApplicationInsights.Models.WorkbookSharedTypeKind?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.WorkbookTemplateData WorkbookTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? priority = default(int?), string author = null, System.BinaryData templateData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery> galleries = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>> localizedGalleries = null) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.WorkItemConfiguration WorkItemConfiguration(string connectorId = null, string configDisplayName = null, bool? isDefault = default(bool?), string id = null, string configProperties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CategoryType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.CategoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CategoryType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.CategoryType Performance { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.CategoryType Retention { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.CategoryType TSG { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.CategoryType Workbook { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.CategoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.CategoryType left, Azure.ResourceManager.ApplicationInsights.Models.CategoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.CategoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.CategoryType left, Azure.ResourceManager.ApplicationInsights.Models.CategoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComponentLinkedStorageAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch>
    {
        public ComponentLinkedStorageAccountPatch() { }
        public string LinkedStorageAccount { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentLinkedStorageAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPurgeBody : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody>
    {
        public ComponentPurgeBody(string table, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters> filters) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters> Filters { get { throw null; } }
        public string Table { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPurgeBodyFilters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters>
    {
        public ComponentPurgeBodyFilters() { }
        public string Column { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string Operator { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeBodyFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPurgeResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse>
    {
        internal ComponentPurgeResponse() { }
        public string OperationId { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPurgeStatusResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse>
    {
        internal ComponentPurgeStatusResponse() { }
        public Azure.ResourceManager.ApplicationInsights.Models.PurgeState Status { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentPurgeStatusResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentTag>
    {
        public ComponentTag() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.ComponentTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.ComponentTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public enum FavoriteType
    {
        Shared = 0,
        User = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FlowType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.FlowType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FlowType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.FlowType Bluefield { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.FlowType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.FlowType left, Azure.ResourceManager.ApplicationInsights.Models.FlowType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.FlowType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.FlowType left, Azure.ResourceManager.ApplicationInsights.Models.FlowType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HeaderField : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.HeaderField>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.HeaderField>
    {
        public HeaderField() { }
        public string HeaderFieldName { get { throw null; } set { } }
        public string HeaderFieldValue { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.HeaderField System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.HeaderField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.HeaderField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.HeaderField System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.HeaderField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.HeaderField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.HeaderField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionMode : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.IngestionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionMode(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.IngestionMode ApplicationInsights { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.IngestionMode ApplicationInsightsWithDiagnosticSettings { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.IngestionMode LogAnalytics { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.IngestionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.IngestionMode left, Azure.ResourceManager.ApplicationInsights.Models.IngestionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.IngestionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.IngestionMode left, Azure.ResourceManager.ApplicationInsights.Models.IngestionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ItemScope : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ItemScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ItemScope(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemScope Shared { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemScope User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ItemScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ItemScope left, Azure.ResourceManager.ApplicationInsights.Models.ItemScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ItemScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ItemScope left, Azure.ResourceManager.ApplicationInsights.Models.ItemScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ItemScopePath : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ItemScopePath(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath AnalyticsItems { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath MyAnalyticsItems { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath left, Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath left, Azure.ResourceManager.ApplicationInsights.Models.ItemScopePath right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ItemType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ItemType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemType Function { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemType None { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemType Query { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemType Recent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ItemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ItemType left, Azure.ResourceManager.ApplicationInsights.Models.ItemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ItemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ItemType left, Azure.ResourceManager.ApplicationInsights.Models.ItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ItemTypeParameter : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ItemTypeParameter(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter Folder { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter Function { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter None { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter Query { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter Recent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter left, Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter left, Azure.ResourceManager.ApplicationInsights.Models.ItemTypeParameter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LiveTokenResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse>
    {
        internal LiveTokenResponse() { }
        public string LiveToken { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.LiveTokenResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MyWorkbookManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity>
    {
        public MyWorkbookManagedIdentity() { }
        public Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentityType? IdentityType { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities UserAssignedIdentities { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MyWorkbookManagedIdentityType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MyWorkbookManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentityType left, Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentityType left, Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MyWorkbookResourceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookResourceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookResourceContent>
    {
        public MyWorkbookResourceContent() { }
        public System.Collections.Generic.IDictionary<string, string> ETag { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookManagedIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookResourceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookResourceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookResourceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookResourceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookResourceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookResourceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookResourceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MyWorkbookUserAssignedIdentities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities>
    {
        public MyWorkbookUserAssignedIdentities() { }
        public string PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.MyWorkbookUserAssignedIdentities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateLinkScopedResourceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent>
    {
        internal PrivateLinkScopedResourceContent() { }
        public string ResourceId { get { throw null; } }
        public string ScopeId { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.PrivateLinkScopedResourceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType left, Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType left, Azure.ResourceManager.ApplicationInsights.Models.PublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurgeState : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.PurgeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurgeState(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.PurgeState Completed { get { throw null; } }
        public static Azure.ResourceManager.ApplicationInsights.Models.PurgeState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.PurgeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.PurgeState left, Azure.ResourceManager.ApplicationInsights.Models.PurgeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.PurgeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.PurgeState left, Azure.ResourceManager.ApplicationInsights.Models.PurgeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequestSource : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.RequestSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequestSource(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.RequestSource Rest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.RequestSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.RequestSource left, Azure.ResourceManager.ApplicationInsights.Models.RequestSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.RequestSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.RequestSource left, Azure.ResourceManager.ApplicationInsights.Models.RequestSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageType : System.IEquatable<Azure.ResourceManager.ApplicationInsights.Models.StorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageType(string value) { throw null; }
        public static Azure.ResourceManager.ApplicationInsights.Models.StorageType ServiceProfiler { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApplicationInsights.Models.StorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApplicationInsights.Models.StorageType left, Azure.ResourceManager.ApplicationInsights.Models.StorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApplicationInsights.Models.StorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApplicationInsights.Models.StorageType left, Azure.ResourceManager.ApplicationInsights.Models.StorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebTestGeolocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>
    {
        public WebTestGeolocation() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestGeolocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WebTestKind
    {
        Ping = 0,
        Multistep = 1,
        Standard = 2,
    }
    public partial class WebTestPropertiesRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest>
    {
        public WebTestPropertiesRequest() { }
        public bool? FollowRedirects { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.HeaderField> Headers { get { throw null; } }
        public string HttpVerb { get { throw null; } set { } }
        public bool? ParseDependentRequests { get { throw null; } set { } }
        public string RequestBody { get { throw null; } set { } }
        public System.Uri RequestUri { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebTestPropertiesValidationRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules>
    {
        public WebTestPropertiesValidationRules() { }
        public bool? CheckSsl { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRulesContentValidation ContentValidation { get { throw null; } set { } }
        public int? ExpectedHttpStatusCode { get { throw null; } set { } }
        public bool? IgnoreHttpStatusCode { get { throw null; } set { } }
        public int? SSLCertRemainingLifetimeCheck { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebTestPropertiesValidationRulesContentValidation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRulesContentValidation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRulesContentValidation>
    {
        public WebTestPropertiesValidationRulesContentValidation() { }
        public string ContentMatch { get { throw null; } set { } }
        public bool? IgnoreCase { get { throw null; } set { } }
        public bool? PassIfTextFound { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRulesContentValidation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRulesContentValidation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRulesContentValidation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRulesContentValidation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRulesContentValidation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRulesContentValidation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WebTestPropertiesValidationRulesContentValidation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkbookPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch>
    {
        public WorkbookPatch() { }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApplicationInsights.Models.WorkbookUpdateSharedTypeKind? Kind { get { throw null; } set { } }
        public string Revision { get { throw null; } set { } }
        public string SerializedData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> TagsPropertiesTags { get { throw null; } }
        Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string WorkbookTemplateGalleryType { get { throw null; } set { } }
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
        Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkbookTemplatePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch>
    {
        public WorkbookTemplatePatch() { }
        public string Author { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateGallery> Galleries { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplateLocalizedGallery>> Localized { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.BinaryData TemplateData { get { throw null; } set { } }
        Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkbookTemplatePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ApplicationInsights.Models.WorkItemCreateConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
