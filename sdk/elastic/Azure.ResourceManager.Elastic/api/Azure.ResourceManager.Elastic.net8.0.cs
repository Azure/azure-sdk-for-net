namespace Azure.ResourceManager.Elastic
{
    public partial class AzureResourceManagerElasticContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerElasticContext() { }
        public static Azure.ResourceManager.Elastic.AzureResourceManagerElasticContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ElasticExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult> GetApiKey(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Elastic.Models.ElasticUserEmailId body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult>> GetApiKeyAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Elastic.Models.ElasticUserEmailId body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetElasticMonitorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticMonitorResource GetElasticMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticMonitorCollection GetElasticMonitors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource GetElasticOpenAIIntegrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticTagRuleResource GetElasticTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult> GetElasticToAzureSubscriptionMapping(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult>> GetElasticToAzureSubscriptionMappingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Elastic.Models.ElasticVersion> GetElasticVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string region, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.ElasticVersion> GetElasticVersionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string region, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource GetMonitoredSubscriptionPropertyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ElasticMonitorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>, System.Collections.IEnumerable
    {
        protected ElasticMonitorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Elastic.ElasticMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Elastic.ElasticMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetIfExists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetIfExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Elastic.ElasticMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Elastic.ElasticMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticMonitorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorData>
    {
        public ElasticMonitorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticMonitorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticMonitorResource() { }
        public virtual Azure.ResourceManager.Elastic.ElasticMonitorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation AssociateTrafficFilter(Azure.WaitUntil waitUntil, string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AssociateTrafficFilterAsync(Azure.WaitUntil waitUntil, string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateAndAssociateIPFilter(Azure.WaitUntil waitUntil, string ips = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateAndAssociateIPFilterAsync(Azure.WaitUntil waitUntil, string ips = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateAndAssociatePrivateLinkFilter(Azure.WaitUntil waitUntil, string name = null, string privateEndpointGuid = null, string privateEndpointName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateAndAssociatePrivateLinkFilterAsync(Azure.WaitUntil waitUntil, string name = null, string privateEndpointGuid = null, string privateEndpointName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult> CreateOrUpdateExternalUser(Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult>> CreateOrUpdateExternalUserAsync(Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTrafficFilter(string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrafficFilterAsync(string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetachAndDeleteTrafficFilter(string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetachAndDeleteTrafficFilterAsync(string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DetachTrafficFilter(Azure.WaitUntil waitUntil, string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachTrafficFilterAsync(Azure.WaitUntil waitUntil, string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult> GetAllTrafficFilter(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult>> GetAllTrafficFilterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult> GetAssociatedTrafficFilters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult>> GetAssociatedTrafficFiltersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult> GetBillingInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult>> GetBillingInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo> GetConnectedPartnerResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo> GetConnectedPartnerResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult> GetDeploymentInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult>> GetDeploymentInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource> GetElasticOpenAIIntegration(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource>> GetElasticOpenAIIntegrationAsync(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationCollection GetElasticOpenAIIntegrations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticTagRuleResource> GetElasticTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticTagRuleResource>> GetElasticTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Elastic.ElasticTagRuleCollection GetElasticTagRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyCollection GetMonitoredSubscriptionProperties() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> GetMonitoredSubscriptionProperty(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>> GetMonitoredSubscriptionPropertyAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult> GetUpgradableVersionDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult>> GetUpgradableVersionDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo> GetVmHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo> GetVmHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult> GetVmIngestionDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult>> GetVmIngestionDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource> ResubscribeOrganization(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ResubscribeProperties body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource>> ResubscribeOrganizationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ResubscribeProperties body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Elastic.ElasticMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateVmCollection(Azure.ResourceManager.Elastic.Models.VmCollectionContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateVmCollectionAsync(Azure.ResourceManager.Elastic.Models.VmCollectionContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeMonitor(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeMonitorAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticOpenAIIntegrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource>, System.Collections.IEnumerable
    {
        protected ElasticOpenAIIntegrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationName, Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationName, Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource> Get(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource>> GetAsync(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource> GetIfExists(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource>> GetIfExistsAsync(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticOpenAIIntegrationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>
    {
        public ElasticOpenAIIntegrationData() { }
        public Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticOpenAIIntegrationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticOpenAIIntegrationResource() { }
        public virtual Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string integrationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult> GetStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult>> GetStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticTagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.ElasticTagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.ElasticTagRuleResource>, System.Collections.IEnumerable
    {
        protected ElasticTagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticTagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Elastic.ElasticTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticTagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Elastic.ElasticTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticTagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.ElasticTagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticTagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticTagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Elastic.ElasticTagRuleResource> GetIfExists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Elastic.ElasticTagRuleResource>> GetIfExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Elastic.ElasticTagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.ElasticTagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Elastic.ElasticTagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.ElasticTagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticTagRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>
    {
        public ElasticTagRuleData() { }
        public Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticTagRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticTagRuleResource() { }
        public virtual Azure.ResourceManager.Elastic.ElasticTagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticTagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticTagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Elastic.ElasticTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticTagRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.ElasticTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticTagRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.ElasticTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitoredSubscriptionPropertyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>, System.Collections.IEnumerable
    {
        protected MonitoredSubscriptionPropertyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitoredSubscriptionPropertyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>
    {
        public MonitoredSubscriptionPropertyData() { }
        public Azure.ResourceManager.Elastic.Models.SubscriptionList Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoredSubscriptionPropertyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitoredSubscriptionPropertyResource() { }
        public virtual Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string configurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Elastic.Mocking
{
    public partial class MockableElasticArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticArmClient() { }
        public virtual Azure.ResourceManager.Elastic.ElasticMonitorResource GetElasticMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationResource GetElasticOpenAIIntegrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Elastic.ElasticTagRuleResource GetElasticTagRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource GetMonitoredSubscriptionPropertyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableElasticResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitor(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetElasticMonitorAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Elastic.ElasticMonitorCollection GetElasticMonitors() { throw null; }
    }
    public partial class MockableElasticSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult> GetApiKey(Azure.ResourceManager.Elastic.Models.ElasticUserEmailId body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult>> GetApiKeyAsync(Azure.ResourceManager.Elastic.Models.ElasticUserEmailId body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult> GetElasticToAzureSubscriptionMapping(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult>> GetElasticToAzureSubscriptionMappingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.ElasticVersion> GetElasticVersions(string region, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.ElasticVersion> GetElasticVersionsAsync(string region, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Elastic.Models
{
    public static partial class ArmElasticModelFactory
    {
        public static Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo ConnectedPartnerResourceInfo(Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties ConnectedPartnerResourceProperties(string partnerDeploymentName, System.Uri partnerDeploymentUri, Azure.Core.ResourceIdentifier azureResourceId, Azure.Core.AzureLocation? location) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties ConnectedPartnerResourceProperties(string partnerDeploymentName = null, System.Uri partnerDeploymentUri = null, Azure.Core.ResourceIdentifier azureResourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string connectedPartnerResourcePropertiesType = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult ElasticBillingInfoResult(Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo marketplaceSaasInfo = null, Azure.ResourceManager.Elastic.Models.PartnerBillingEntity partnerBillingEntity = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment ElasticCloudDeployment(string name = null, string deploymentId = null, string azureSubscriptionId = null, string elasticsearchRegion = null, System.Uri elasticsearchServiceUri = null, System.Uri kibanaServiceUri = null, System.Uri kibanaSsoUri = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticCloudUser ElasticCloudUser(string emailAddress = null, string id = null, System.Uri elasticCloudSsoDefaultUri = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult ElasticDeploymentInfoResult(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus? status, string version, string memoryCapacity, string diskCapacity, string elasticsearchEndPoint, System.Uri deploymentUri, Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo marketplaceSaasInfo) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult ElasticDeploymentInfoResult(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus? status = default(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus?), string version = null, string memoryCapacity = null, string diskCapacity = null, string elasticsearchEndPoint = null, System.Uri deploymentUri = null, Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo marketplaceSaasInfo = null, string projectType = null, string configurationType = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult ElasticExternalUserCreationResult(bool? isCreated = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Elastic.ElasticMonitorData ElasticMonitorData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string skuName, Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties properties, Azure.ResourceManager.Models.ManagedServiceIdentity identity) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticMonitorData ElasticMonitorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string kind = null, string skuName = null, Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties ElasticMonitorProperties(Azure.ResourceManager.Elastic.Models.ElasticProvisioningState? provisioningState, Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus? monitoringStatus, Azure.ResourceManager.Elastic.Models.ElasticCloudProperties elasticProperties, Azure.ResourceManager.Elastic.Models.ElasticUserInfo userInfo, Azure.ResourceManager.Elastic.Models.ElasticPlanDetails planDetails, string version, string subscriptionState, string saaSAzureSubscriptionStatus, string sourceCampaignName, string sourceCampaignId, Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory? liftrResourceCategory, int? liftrResourcePreference, bool? isApiKeyGenerated) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties ElasticMonitorProperties(Azure.ResourceManager.Elastic.Models.ElasticProvisioningState? provisioningState = default(Azure.ResourceManager.Elastic.Models.ElasticProvisioningState?), Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus? monitoringStatus = default(Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus?), Azure.ResourceManager.Elastic.Models.ElasticCloudProperties elasticProperties = null, Azure.ResourceManager.Elastic.Models.ElasticUserInfo userInfo = null, Azure.ResourceManager.Elastic.Models.ElasticPlanDetails planDetails = null, string version = null, string subscriptionState = null, string saaSAzureSubscriptionStatus = null, string sourceCampaignName = null, string sourceCampaignId = null, Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory?), int? liftrResourcePreference = default(int?), bool? isApiKeyGenerated = default(bool?), Azure.ResourceManager.Elastic.Models.HostingType? hostingType = default(Azure.ResourceManager.Elastic.Models.HostingType?), Azure.ResourceManager.Elastic.Models.ProjectDetails projectDetails = null) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticOpenAIIntegrationData ElasticOpenAIIntegrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties ElasticOpenAIIntegrationProperties(string openAIResourceId = null, string openAIResourceEndpoint = null, string openAIConnectorId = null, string key = null, System.DateTimeOffset? lastRefreshOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult ElasticOpenAIIntegrationStatusResult(string elasticOpenAIIntegrationStatus = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties ElasticOrganizationToAzureSubscriptionMappingProperties(string billedAzureSubscriptionId = null, Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo marketplaceSaasInfo = null, string elasticOrganizationId = null, string elasticOrganizationName = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult ElasticOrganizationToAzureSubscriptionMappingResult(Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticTagRuleData ElasticTagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties ElasticTagRuleProperties(Azure.ResourceManager.Elastic.Models.ElasticProvisioningState? provisioningState = default(Azure.ResourceManager.Elastic.Models.ElasticProvisioningState?), Azure.ResourceManager.Elastic.Models.ElasticLogRules logRules = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter ElasticTrafficFilter(string id = null, string name = null, string description = null, string region = null, Azure.ResourceManager.Elastic.Models.ElasticFilterType? filterType = default(Azure.ResourceManager.Elastic.Models.ElasticFilterType?), bool? doesIncludeByDefault = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule> rules = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult ElasticTrafficFilterListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter> rulesets = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule ElasticTrafficFilterRule(string source = null, string description = null, string azureEndpointGuid = null, string azureEndpointName = null, string id = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult ElasticUserApiKeyResult(string elasticUserApiKey = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticVersion ElasticVersion(string availableVersion = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo ElasticVmResourceInfo(Azure.Core.ResourceIdentifier vmResourceId = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo MarketplaceSaaSInfo(Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription marketplaceSubscription = null, string marketplaceName = null, string marketplaceResourceId = null, string marketplaceStatus = null, string billedAzureSubscriptionId = null, bool? isSubscribed = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription MarketplaceSaaSInfoMarketplaceSubscription(string id = null, string publisherId = null, string offerId = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo MonitoredResourceInfo(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Elastic.Models.SendingLogsStatus? sendingLogs = default(Azure.ResourceManager.Elastic.Models.SendingLogsStatus?), string reasonForLogsStatus = null) { throw null; }
        public static Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData MonitoredSubscriptionPropertyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Elastic.Models.SubscriptionList properties = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.PartnerBillingEntity PartnerBillingEntity(string id = null, string name = null, System.Uri partnerEntityUri = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.SubscriptionList SubscriptionList(Azure.ResourceManager.Elastic.Models.Operation? operation = default(Azure.ResourceManager.Elastic.Models.Operation?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.Models.MonitoredSubscription> monitoredSubscriptionList = null, Azure.ResourceManager.Elastic.Models.ElasticProvisioningState? provisioningState = default(Azure.ResourceManager.Elastic.Models.ElasticProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult UpgradableVersionListResult(string currentVersion = null, System.Collections.Generic.IEnumerable<string> upgradableVersions = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult VmIngestionDetailsResult(string cloudId = null, string ingestionKey = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationType : System.IEquatable<Azure.ResourceManager.Elastic.Models.ConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ConfigurationType GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ConfigurationType NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ConfigurationType TimeSeries { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ConfigurationType Vector { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.ConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.ConfigurationType left, Azure.ResourceManager.Elastic.Models.ConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.ConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.ConfigurationType left, Azure.ResourceManager.Elastic.Models.ConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedPartnerResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo>
    {
        internal ConnectedPartnerResourceInfo() { }
        public Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedPartnerResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>
    {
        internal ConnectedPartnerResourceProperties() { }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } }
        public string ConnectedPartnerResourcePropertiesType { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string PartnerDeploymentName { get { throw null; } }
        public System.Uri PartnerDeploymentUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticBillingInfoResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult>
    {
        internal ElasticBillingInfoResult() { }
        public Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo MarketplaceSaasInfo { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.PartnerBillingEntity PartnerBillingEntity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticBillingInfoResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticCloudDeployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>
    {
        public ElasticCloudDeployment() { }
        public string AzureSubscriptionId { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public string ElasticsearchRegion { get { throw null; } }
        public System.Uri ElasticsearchServiceUri { get { throw null; } }
        public System.Uri KibanaServiceUri { get { throw null; } }
        public System.Uri KibanaSsoUri { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticCloudProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudProperties>
    {
        public ElasticCloudProperties() { }
        public Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment ElasticCloudDeployment { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticCloudUser ElasticCloudUser { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCloudProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCloudProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticCloudUser : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>
    {
        public ElasticCloudUser() { }
        public System.Uri ElasticCloudSsoDefaultUri { get { throw null; } }
        public string EmailAddress { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCloudUser System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCloudUser System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticCompanyInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCompanyInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCompanyInfo>
    {
        public ElasticCompanyInfo() { }
        public string Business { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string EmployeesNumber { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCompanyInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCompanyInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCompanyInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCompanyInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCompanyInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCompanyInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCompanyInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticDeploymentInfoResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult>
    {
        internal ElasticDeploymentInfoResult() { }
        public string ConfigurationType { get { throw null; } }
        public System.Uri DeploymentUri { get { throw null; } }
        public string DiskCapacity { get { throw null; } }
        public string ElasticsearchEndPoint { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo MarketplaceSaasInfo { get { throw null; } }
        public string MemoryCapacity { get { throw null; } }
        public string ProjectType { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticDeploymentInfoResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticDeploymentStatus : System.IEquatable<Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticDeploymentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus left, Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus left, Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticExternalUserContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent>
    {
        public ElasticExternalUserContent() { }
        public string EmailId { get { throw null; } set { } }
        public string FullName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticExternalUserCreationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult>
    {
        internal ElasticExternalUserCreationResult() { }
        public bool? IsCreated { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticExternalUserCreationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticFilteringTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticFilteringTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticFilteringTag>
    {
        public ElasticFilteringTag() { }
        public Azure.ResourceManager.Elastic.Models.FilteringTagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticFilteringTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticFilteringTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticFilteringTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticFilteringTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticFilteringTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticFilteringTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticFilteringTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticFilterType : System.IEquatable<Azure.ResourceManager.Elastic.Models.ElasticFilterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticFilterType(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticFilterType AzurePrivateEndpoint { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticFilterType IP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.ElasticFilterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.ElasticFilterType left, Azure.ResourceManager.Elastic.Models.ElasticFilterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.ElasticFilterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.ElasticFilterType left, Azure.ResourceManager.Elastic.Models.ElasticFilterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticLiftrResourceCategory : System.IEquatable<Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticLiftrResourceCategory(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory left, Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory left, Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticLogRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticLogRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticLogRules>
    {
        public ElasticLogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Elastic.Models.ElasticFilteringTag> FilteringTags { get { throw null; } }
        public bool? ShouldAadLogsBeSent { get { throw null; } set { } }
        public bool? ShouldActivityLogsBeSent { get { throw null; } set { } }
        public bool? ShouldSubscriptionLogsBeSent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticLogRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticLogRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticLogRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticLogRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticLogRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticLogRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticLogRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticMonitoringStatus : System.IEquatable<Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticMonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus left, Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus left, Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticMonitorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch>
    {
        public ElasticMonitorPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticMonitorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties>
    {
        public ElasticMonitorProperties() { }
        public Azure.ResourceManager.Elastic.Models.ElasticCloudProperties ElasticProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.HostingType? HostingType { get { throw null; } set { } }
        public bool? IsApiKeyGenerated { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticLiftrResourceCategory? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.ElasticMonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticPlanDetails PlanDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ProjectDetails ProjectDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticProvisioningState? ProvisioningState { get { throw null; } }
        public string SaaSAzureSubscriptionStatus { get { throw null; } set { } }
        public string SourceCampaignId { get { throw null; } set { } }
        public string SourceCampaignName { get { throw null; } set { } }
        public string SubscriptionState { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticUserInfo UserInfo { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticMonitorUpgrade : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>
    {
        public ElasticMonitorUpgrade() { }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticOpenAIIntegrationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties>
    {
        public ElasticOpenAIIntegrationProperties() { }
        public string Key { get { throw null; } set { } }
        public System.DateTimeOffset? LastRefreshOn { get { throw null; } }
        public string OpenAIConnectorId { get { throw null; } set { } }
        public string OpenAIResourceEndpoint { get { throw null; } set { } }
        public string OpenAIResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticOpenAIIntegrationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult>
    {
        internal ElasticOpenAIIntegrationStatusResult() { }
        public string ElasticOpenAIIntegrationStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOpenAIIntegrationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticOrganizationToAzureSubscriptionMappingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties>
    {
        internal ElasticOrganizationToAzureSubscriptionMappingProperties() { }
        public string BilledAzureSubscriptionId { get { throw null; } }
        public string ElasticOrganizationId { get { throw null; } }
        public string ElasticOrganizationName { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo MarketplaceSaasInfo { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticOrganizationToAzureSubscriptionMappingResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult>
    {
        internal ElasticOrganizationToAzureSubscriptionMappingResult() { }
        public Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticPlanDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticPlanDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticPlanDetails>
    {
        public ElasticPlanDetails() { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticPlanDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticPlanDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticPlanDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticPlanDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticPlanDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticPlanDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticPlanDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticProvisioningState : System.IEquatable<Azure.ResourceManager.Elastic.Models.ElasticProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.ElasticProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.ElasticProvisioningState left, Azure.ResourceManager.Elastic.Models.ElasticProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.ElasticProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.ElasticProvisioningState left, Azure.ResourceManager.Elastic.Models.ElasticProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticTagRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties>
    {
        public ElasticTagRuleProperties() { }
        public Azure.ResourceManager.Elastic.Models.ElasticLogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticTrafficFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>
    {
        internal ElasticTrafficFilter() { }
        public string Description { get { throw null; } }
        public bool? DoesIncludeByDefault { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.ElasticFilterType? FilterType { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Region { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule> Rules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticTrafficFilterListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult>
    {
        internal ElasticTrafficFilterListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter> Rulesets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticTrafficFilterRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>
    {
        internal ElasticTrafficFilterRule() { }
        public string AzureEndpointGuid { get { throw null; } }
        public string AzureEndpointName { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Source { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticUserApiKeyResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult>
    {
        internal ElasticUserApiKeyResult() { }
        public string ElasticUserApiKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserApiKeyResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticUserEmailId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticUserEmailId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserEmailId>
    {
        public ElasticUserEmailId() { }
        public string EmailId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticUserEmailId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticUserEmailId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticUserEmailId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticUserEmailId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserEmailId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserEmailId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserEmailId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticUserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticUserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserInfo>
    {
        public ElasticUserInfo() { }
        public Azure.ResourceManager.Elastic.Models.ElasticCompanyInfo CompanyInfo { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticUserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticUserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticUserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticUserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticUserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVersion>
    {
        internal ElasticVersion() { }
        public string AvailableVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticVmResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo>
    {
        internal ElasticVmResourceInfo() { }
        public Azure.Core.ResourceIdentifier VmResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVmResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilteringTagAction : System.IEquatable<Azure.ResourceManager.Elastic.Models.FilteringTagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilteringTagAction(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.FilteringTagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.FilteringTagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.FilteringTagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.FilteringTagAction left, Azure.ResourceManager.Elastic.Models.FilteringTagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.FilteringTagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.FilteringTagAction left, Azure.ResourceManager.Elastic.Models.FilteringTagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostingType : System.IEquatable<Azure.ResourceManager.Elastic.Models.HostingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostingType(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.HostingType Hosted { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.HostingType Serverless { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.HostingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.HostingType left, Azure.ResourceManager.Elastic.Models.HostingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.HostingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.HostingType left, Azure.ResourceManager.Elastic.Models.HostingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MarketplaceSaaSInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo>
    {
        internal MarketplaceSaaSInfo() { }
        public string BilledAzureSubscriptionId { get { throw null; } }
        public bool? IsSubscribed { get { throw null; } }
        public string MarketplaceName { get { throw null; } }
        public string MarketplaceResourceId { get { throw null; } }
        public string MarketplaceStatus { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription MarketplaceSubscription { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceSaaSInfoMarketplaceSubscription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>
    {
        internal MarketplaceSaaSInfoMarketplaceSubscription() { }
        public string Id { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string PublisherId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoredResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo>
    {
        internal MonitoredResourceInfo() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.SendingLogsStatus? SendingLogs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoredSubscription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>
    {
        public MonitoredSubscription() { }
        public string Error { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.Status? Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticTagRuleProperties TagRules { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitoredSubscription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitoredSubscription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Operation : System.IEquatable<Azure.ResourceManager.Elastic.Models.Operation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Operation(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.Operation Active { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.Operation AddBegin { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.Operation AddComplete { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.Operation DeleteBegin { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.Operation DeleteComplete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.Operation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.Operation left, Azure.ResourceManager.Elastic.Models.Operation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.Operation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.Operation left, Azure.ResourceManager.Elastic.Models.Operation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerBillingEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>
    {
        internal PartnerBillingEntity() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Uri PartnerEntityUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.PartnerBillingEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.PartnerBillingEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ProjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ProjectDetails>
    {
        public ProjectDetails() { }
        public Azure.ResourceManager.Elastic.Models.ConfigurationType? ConfigurationType { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ProjectType? ProjectType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ProjectDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ProjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ProjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ProjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ProjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ProjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ProjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectType : System.IEquatable<Azure.ResourceManager.Elastic.Models.ProjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectType(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ProjectType Elasticsearch { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProjectType NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProjectType Observability { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProjectType Security { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.ProjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.ProjectType left, Azure.ResourceManager.Elastic.Models.ProjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.ProjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.ProjectType left, Azure.ResourceManager.Elastic.Models.ProjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResubscribeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>
    {
        public ResubscribeProperties() { }
        public string OrganizationId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string Term { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ResubscribeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ResubscribeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingLogsStatus : System.IEquatable<Azure.ResourceManager.Elastic.Models.SendingLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.SendingLogsStatus False { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.SendingLogsStatus True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.SendingLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.SendingLogsStatus left, Azure.ResourceManager.Elastic.Models.SendingLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.SendingLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.SendingLogsStatus left, Azure.ResourceManager.Elastic.Models.SendingLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Elastic.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.Status Active { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.Status Deleting { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.Status Failed { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.Status InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.Status left, Azure.ResourceManager.Elastic.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.Status left, Azure.ResourceManager.Elastic.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>
    {
        public SubscriptionList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Elastic.Models.MonitoredSubscription> MonitoredSubscriptionList { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.Operation? Operation { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.SubscriptionList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.SubscriptionList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradableVersionListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult>
    {
        internal UpgradableVersionListResult() { }
        public string CurrentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> UpgradableVersions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmCollectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmCollectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionContent>
    {
        public VmCollectionContent() { }
        public Azure.ResourceManager.Elastic.Models.VmCollectionUpdateOperationName? OperationName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.VmCollectionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmCollectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmCollectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.VmCollectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmCollectionUpdateOperationName : System.IEquatable<Azure.ResourceManager.Elastic.Models.VmCollectionUpdateOperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmCollectionUpdateOperationName(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.VmCollectionUpdateOperationName Add { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.VmCollectionUpdateOperationName Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.VmCollectionUpdateOperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.VmCollectionUpdateOperationName left, Azure.ResourceManager.Elastic.Models.VmCollectionUpdateOperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.VmCollectionUpdateOperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.VmCollectionUpdateOperationName left, Azure.ResourceManager.Elastic.Models.VmCollectionUpdateOperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmIngestionDetailsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult>
    {
        internal VmIngestionDetailsResult() { }
        public string CloudId { get { throw null; } }
        public string IngestionKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
