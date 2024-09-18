namespace Azure.ResourceManager.Elastic
{
    public static partial class ElasticExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse> GetApiKeyOrganization(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Elastic.Models.UserEmailId body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse>> GetApiKeyOrganizationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Elastic.Models.UserEmailId body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticMonitorResource GetElasticMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetElasticMonitorResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticMonitorResourceCollection GetElasticMonitorResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse> GetElasticToAzureSubscriptionMappingOrganization(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse>> GetElasticToAzureSubscriptionMappingOrganizationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat> GetElasticVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string region, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat> GetElasticVersionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string region, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource GetMonitoredSubscriptionPropertyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Elastic.MonitoringTagRuleResource GetMonitoringTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource GetOpenAIIntegrationRPModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ElasticMonitorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticMonitorResource() { }
        public virtual Azure.ResourceManager.Elastic.ElasticMonitorResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation AssociateAssociateTrafficFilter(Azure.WaitUntil waitUntil, string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AssociateAssociateTrafficFilterAsync(Azure.WaitUntil waitUntil, string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateCreateAndAssociateIPFilter(Azure.WaitUntil waitUntil, string ips = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateCreateAndAssociateIPFilterAsync(Azure.WaitUntil waitUntil, string ips = null, string name = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateCreateAndAssociatePLFilter(Azure.WaitUntil waitUntil, string name = null, string privateEndpointGuid = null, string privateEndpointName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateCreateAndAssociatePLFilterAsync(Azure.WaitUntil waitUntil, string name = null, string privateEndpointGuid = null, string privateEndpointName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse> CreateOrUpdateExternalUser(Azure.ResourceManager.Elastic.Models.ExternalUserContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse>> CreateOrUpdateExternalUserAsync(Azure.ResourceManager.Elastic.Models.ExternalUserContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDetachAndDeleteTrafficFilter(string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDetachAndDeleteTrafficFilterAsync(string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteTrafficFilter(string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTrafficFilterAsync(string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.UpgradableVersionsList> DetailsUpgradableVersion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.UpgradableVersionsList>> DetailsUpgradableVersionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse> DetailsVMIngestion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>> DetailsVMIngestionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse> GetAllTrafficFilter(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse>> GetAllTrafficFilterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.BillingInfoResponse> GetBillingInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.BillingInfoResponse>> GetBillingInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat> GetConnectedPartnerResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat> GetConnectedPartnerResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse> GetDeploymentInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>> GetDeploymentInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse> GetListAssociatedTrafficFilter(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse>> GetListAssociatedTrafficFilterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyCollection GetMonitoredSubscriptionProperties() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource> GetMonitoredSubscriptionProperty(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource>> GetMonitoredSubscriptionPropertyAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> GetMonitoringTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> GetMonitoringTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Elastic.MonitoringTagRuleCollection GetMonitoringTagRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource> GetOpenAIIntegrationRPModel(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource>> GetOpenAIIntegrationRPModelAsync(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelCollection GetOpenAIIntegrationRPModels() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.VmResources> GetVMHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.VmResources> GetVMHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource> ResubscribeOrganization(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ResubscribeProperties body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource>> ResubscribeOrganizationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ResubscribeProperties body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Elastic.ElasticMonitorResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticMonitorResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateDetachTrafficFilter(Azure.WaitUntil waitUntil, string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateDetachTrafficFilterAsync(Azure.WaitUntil waitUntil, string rulesetId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateVMCollection(Azure.ResourceManager.Elastic.Models.VmCollectionUpdate body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateVMCollectionAsync(Azure.ResourceManager.Elastic.Models.VmCollectionUpdate body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeMonitor(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeMonitorAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticMonitorResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>, System.Collections.IEnumerable
    {
        protected ElasticMonitorResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Elastic.ElasticMonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Elastic.ElasticMonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ElasticMonitorResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>
    {
        public ElasticMonitorResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.MonitorProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.ElasticMonitorResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticMonitorResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MonitoringTagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>, System.Collections.IEnumerable
    {
        protected MonitoringTagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Elastic.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Elastic.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> GetIfExists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> GetIfExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitoringTagRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>
    {
        public MonitoringTagRuleData() { }
        public Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.MonitoringTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.MonitoringTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoringTagRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitoringTagRuleResource() { }
        public virtual Azure.ResourceManager.Elastic.MonitoringTagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Elastic.MonitoringTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.MonitoringTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenAIIntegrationRPModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource>, System.Collections.IEnumerable
    {
        protected OpenAIIntegrationRPModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationName, Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationName, Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource> Get(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource>> GetAsync(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource> GetIfExists(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource>> GetIfExistsAsync(string integrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OpenAIIntegrationRPModelData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>
    {
        public OpenAIIntegrationRPModelData() { }
        public Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAIIntegrationRPModelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OpenAIIntegrationRPModelResource() { }
        public virtual Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string integrationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse> GetStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse>> GetStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Elastic.Mocking
{
    public partial class MockableElasticArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticArmClient() { }
        public virtual Azure.ResourceManager.Elastic.ElasticMonitorResource GetElasticMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyResource GetMonitoredSubscriptionPropertyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Elastic.MonitoringTagRuleResource GetMonitoringTagRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelResource GetOpenAIIntegrationRPModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableElasticResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResource(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetElasticMonitorResourceAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Elastic.ElasticMonitorResourceCollection GetElasticMonitorResources() { throw null; }
    }
    public partial class MockableElasticSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse> GetApiKeyOrganization(Azure.ResourceManager.Elastic.Models.UserEmailId body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse>> GetApiKeyOrganizationAsync(Azure.ResourceManager.Elastic.Models.UserEmailId body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse> GetElasticToAzureSubscriptionMappingOrganization(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse>> GetElasticToAzureSubscriptionMappingOrganizationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat> GetElasticVersions(string region, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat> GetElasticVersionsAsync(string region, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Elastic.Models
{
    public static partial class ArmElasticModelFactory
    {
        public static Azure.ResourceManager.Elastic.Models.BillingInfoResponse BillingInfoResponse(Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo marketplaceSaasInfo = null, Azure.ResourceManager.Elastic.Models.PartnerBillingEntity partnerBillingEntity = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties ConnectedPartnerResourceProperties(string partnerDeploymentName = null, System.Uri partnerDeploymentUri = null, string azureResourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat ConnectedPartnerResourcesListFormat(Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse DeploymentInfoResponse(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus? status = default(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus?), string version = null, string memoryCapacity = null, string diskCapacity = null, string elasticsearchEndPoint = null, System.Uri deploymentUri = null, Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo marketplaceSaasInfo = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment ElasticCloudDeployment(string name = null, string deploymentId = null, string azureSubscriptionId = null, string elasticsearchRegion = null, System.Uri elasticsearchServiceUri = null, System.Uri kibanaServiceUri = null, System.Uri kibanaSsoUri = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticCloudUser ElasticCloudUser(string emailAddress = null, string id = null, System.Uri elasticCloudSsoDefaultUri = null) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticMonitorResourceData ElasticMonitorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string skuName = null, Azure.ResourceManager.Elastic.Models.MonitorProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse ElasticOrganizationToAzureSubscriptionMappingResponse(Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties ElasticOrganizationToAzureSubscriptionMappingResponseProperties(string billedAzureSubscriptionId = null, Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo marketplaceSaasInfo = null, string elasticOrganizationId = null, string elasticOrganizationName = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter ElasticTrafficFilter(string id = null, string name = null, string description = null, string region = null, Azure.ResourceManager.Elastic.Models.Type? elasticTrafficFilterType = default(Azure.ResourceManager.Elastic.Models.Type?), bool? includeByDefault = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule> rules = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse ElasticTrafficFilterResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter> rulesets = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule ElasticTrafficFilterRule(string source = null, string description = null, string azureEndpointGuid = null, string azureEndpointName = null, string id = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat ElasticVersionListFormat(string version = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse ExternalUserCreationResponse(bool? created = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo MarketplaceSaaSInfo(Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription marketplaceSubscription = null, string marketplaceName = null, string marketplaceResourceId = null, string marketplaceStatus = null, string billedAzureSubscriptionId = null, bool? subscribed = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription MarketplaceSaaSInfoMarketplaceSubscription(string id = null, string publisherId = null, string offerId = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MonitoredResourceContent MonitoredResourceContent(string id = null, Azure.ResourceManager.Elastic.Models.SendingLog? sendingLogs = default(Azure.ResourceManager.Elastic.Models.SendingLog?), string reasonForLogsStatus = null) { throw null; }
        public static Azure.ResourceManager.Elastic.MonitoredSubscriptionPropertyData MonitoredSubscriptionPropertyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Elastic.Models.SubscriptionList properties = null) { throw null; }
        public static Azure.ResourceManager.Elastic.MonitoringTagRuleData MonitoringTagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties MonitoringTagRulesProperties(Azure.ResourceManager.Elastic.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Elastic.Models.ProvisioningState?), Azure.ResourceManager.Elastic.Models.LogRules logRules = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MonitorProperties MonitorProperties(Azure.ResourceManager.Elastic.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Elastic.Models.ProvisioningState?), Azure.ResourceManager.Elastic.Models.MonitoringStatus? monitoringStatus = default(Azure.ResourceManager.Elastic.Models.MonitoringStatus?), Azure.ResourceManager.Elastic.Models.ElasticProperties elasticProperties = null, Azure.ResourceManager.Elastic.Models.UserInfo userInfo = null, Azure.ResourceManager.Elastic.Models.PlanDetails planDetails = null, string version = null, string subscriptionState = null, string saaSAzureSubscriptionStatus = null, string sourceCampaignName = null, string sourceCampaignId = null, Azure.ResourceManager.Elastic.Models.LiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.Elastic.Models.LiftrResourceCategory?), int? liftrResourcePreference = default(int?), bool? generateApiKey = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties OpenAIIntegrationProperties(string openAIResourceId = null, string openAIResourceEndpoint = null, string openAIConnectorId = null, string key = null, System.DateTimeOffset? lastRefreshOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Elastic.OpenAIIntegrationRPModelData OpenAIIntegrationRPModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse OpenAIIntegrationStatusResponse(string status = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.PartnerBillingEntity PartnerBillingEntity(string id = null, string name = null, System.Uri partnerEntityUri = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.SubscriptionList SubscriptionList(Azure.ResourceManager.Elastic.Models.Operation? operation = default(Azure.ResourceManager.Elastic.Models.Operation?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.Models.MonitoredSubscription> monitoredSubscriptionList = null, Azure.ResourceManager.Elastic.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Elastic.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.UpgradableVersionsList UpgradableVersionsList(string currentVersion = null, System.Collections.Generic.IEnumerable<string> upgradableVersions = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.UserApiKeyResponse UserApiKeyResponse(string apiKey = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse VmIngestionDetailsResponse(string cloudId = null, string ingestionKey = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.VmResources VmResources(string vmResourceId = null) { throw null; }
    }
    public partial class BillingInfoResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.BillingInfoResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.BillingInfoResponse>
    {
        internal BillingInfoResponse() { }
        public Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo MarketplaceSaasInfo { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.PartnerBillingEntity PartnerBillingEntity { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.BillingInfoResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.BillingInfoResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.BillingInfoResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.BillingInfoResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.BillingInfoResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.BillingInfoResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.BillingInfoResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompanyInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>
    {
        public CompanyInfo() { }
        public string Business { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string EmployeesNumber { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.CompanyInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.CompanyInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedPartnerResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>
    {
        internal ConnectedPartnerResourceProperties() { }
        public string AzureResourceId { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string PartnerDeploymentName { get { throw null; } }
        public System.Uri PartnerDeploymentUri { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedPartnerResourcesListFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat>
    {
        internal ConnectedPartnerResourcesListFormat() { }
        public Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourceProperties Properties { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ConnectedPartnerResourcesListFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentInfoResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>
    {
        internal DeploymentInfoResponse() { }
        public System.Uri DeploymentUri { get { throw null; } }
        public string DiskCapacity { get { throw null; } }
        public string ElasticsearchEndPoint { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo MarketplaceSaasInfo { get { throw null; } }
        public string MemoryCapacity { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticCloudUser : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>
    {
        public ElasticCloudUser() { }
        public System.Uri ElasticCloudSsoDefaultUri { get { throw null; } }
        public string EmailAddress { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticCloudUser System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCloudUser System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ElasticMonitorResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>
    {
        public ElasticMonitorResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticMonitorUpgrade : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>
    {
        public ElasticMonitorUpgrade() { }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorUpgrade>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticOrganizationToAzureSubscriptionMappingResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse>
    {
        internal ElasticOrganizationToAzureSubscriptionMappingResponse() { }
        public Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties Properties { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticOrganizationToAzureSubscriptionMappingResponseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties>
    {
        internal ElasticOrganizationToAzureSubscriptionMappingResponseProperties() { }
        public string BilledAzureSubscriptionId { get { throw null; } }
        public string ElasticOrganizationId { get { throw null; } }
        public string ElasticOrganizationName { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo MarketplaceSaasInfo { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticOrganizationToAzureSubscriptionMappingResponseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>
    {
        public ElasticProperties() { }
        public Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment ElasticCloudDeployment { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticCloudUser ElasticCloudUser { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.ElasticProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticTrafficFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>
    {
        internal ElasticTrafficFilter() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.Type? ElasticTrafficFilterType { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IncludeByDefault { get { throw null; } }
        public string Name { get { throw null; } }
        public string Region { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule> Rules { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticTrafficFilterResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse>
    {
        internal ElasticTrafficFilterResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilter> Rulesets { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticTrafficFilterRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>
    {
        internal ElasticTrafficFilterRule() { }
        public string AzureEndpointGuid { get { throw null; } }
        public string AzureEndpointName { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Source { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticTrafficFilterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticVersionListFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat>
    {
        internal ElasticVersionListFormat() { }
        public string Version { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticVersionListFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalUserContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ExternalUserContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ExternalUserContent>
    {
        public ExternalUserContent() { }
        public string EmailId { get { throw null; } set { } }
        public string FullName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Roles { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.ExternalUserContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ExternalUserContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ExternalUserContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ExternalUserContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ExternalUserContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ExternalUserContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ExternalUserContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalUserCreationResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse>
    {
        internal ExternalUserCreationResponse() { }
        public bool? Created { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ExternalUserCreationResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FilteringTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.FilteringTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.FilteringTag>
    {
        public FilteringTag() { }
        public Azure.ResourceManager.Elastic.Models.TagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.FilteringTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.FilteringTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.FilteringTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.FilteringTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.FilteringTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.FilteringTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.FilteringTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiftrResourceCategory : System.IEquatable<Azure.ResourceManager.Elastic.Models.LiftrResourceCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiftrResourceCategory(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.LiftrResourceCategory MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.LiftrResourceCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.LiftrResourceCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.LiftrResourceCategory left, Azure.ResourceManager.Elastic.Models.LiftrResourceCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.LiftrResourceCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.LiftrResourceCategory left, Azure.ResourceManager.Elastic.Models.LiftrResourceCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.LogRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.LogRules>
    {
        public LogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Elastic.Models.FilteringTag> FilteringTags { get { throw null; } }
        public bool? SendAadLogs { get { throw null; } set { } }
        public bool? SendActivityLogs { get { throw null; } set { } }
        public bool? SendSubscriptionLogs { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.LogRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.LogRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.LogRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.LogRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.LogRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.LogRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.LogRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceSaaSInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfo>
    {
        internal MarketplaceSaaSInfo() { }
        public string BilledAzureSubscriptionId { get { throw null; } }
        public string MarketplaceName { get { throw null; } }
        public string MarketplaceResourceId { get { throw null; } }
        public string MarketplaceStatus { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription MarketplaceSubscription { get { throw null; } }
        public bool? Subscribed { get { throw null; } }
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
        Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MarketplaceSaaSInfoMarketplaceSubscription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoredResourceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>
    {
        internal MonitoredResourceContent() { }
        public string Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.SendingLog? SendingLogs { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.MonitoredResourceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitoredResourceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoredSubscription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>
    {
        public MonitoredSubscription() { }
        public string Error { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.Status? Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties TagRules { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.MonitoredSubscription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitoredSubscription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredSubscription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringStatus : System.IEquatable<Azure.ResourceManager.Elastic.Models.MonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.MonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.MonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.MonitoringStatus left, Azure.ResourceManager.Elastic.Models.MonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.MonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.MonitoringStatus left, Azure.ResourceManager.Elastic.Models.MonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitoringTagRulesProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>
    {
        public MonitoringTagRulesProperties() { }
        public Azure.ResourceManager.Elastic.Models.LogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>
    {
        public MonitorProperties() { }
        public Azure.ResourceManager.Elastic.Models.ElasticProperties ElasticProperties { get { throw null; } set { } }
        public bool? GenerateApiKey { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.LiftrResourceCategory? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.MonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.PlanDetails PlanDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SaaSAzureSubscriptionStatus { get { throw null; } set { } }
        public string SourceCampaignId { get { throw null; } set { } }
        public string SourceCampaignName { get { throw null; } set { } }
        public string SubscriptionState { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.UserInfo UserInfo { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.MonitorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAIIntegrationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties>
    {
        public OpenAIIntegrationProperties() { }
        public string Key { get { throw null; } set { } }
        public System.DateTimeOffset? LastRefreshOn { get { throw null; } }
        public string OpenAIConnectorId { get { throw null; } set { } }
        public string OpenAIResourceEndpoint { get { throw null; } set { } }
        public string OpenAIResourceId { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAIIntegrationStatusResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse>
    {
        internal OpenAIIntegrationStatusResponse() { }
        public string Status { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.OpenAIIntegrationStatusResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticResourceOperation : System.IEquatable<Azure.ResourceManager.Elastic.Models.Operation>
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationName : System.IEquatable<Azure.ResourceManager.Elastic.Models.OperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationName(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.OperationName Add { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.OperationName Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.OperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.OperationName left, Azure.ResourceManager.Elastic.Models.OperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.OperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.OperationName left, Azure.ResourceManager.Elastic.Models.OperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerBillingEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>
    {
        internal PartnerBillingEntity() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Uri PartnerEntityUri { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.PartnerBillingEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.PartnerBillingEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PartnerBillingEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlanDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.PlanDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PlanDetails>
    {
        public PlanDetails() { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.PlanDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.PlanDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.PlanDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.PlanDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PlanDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PlanDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.PlanDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Elastic.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.ProvisioningState left, Azure.ResourceManager.Elastic.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.ProvisioningState left, Azure.ResourceManager.Elastic.Models.ProvisioningState right) { throw null; }
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
        Azure.ResourceManager.Elastic.Models.ResubscribeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ResubscribeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ResubscribeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingLog : System.IEquatable<Azure.ResourceManager.Elastic.Models.SendingLog>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingLog(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.SendingLog False { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.SendingLog True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.SendingLog other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.SendingLog left, Azure.ResourceManager.Elastic.Models.SendingLog right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.SendingLog (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.SendingLog left, Azure.ResourceManager.Elastic.Models.SendingLog right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticResourceStatus : System.IEquatable<Azure.ResourceManager.Elastic.Models.Status>
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
    public partial class ElasticResourceSubscriptionList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>
    {
        public SubscriptionList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Elastic.Models.MonitoredSubscription> MonitoredSubscriptionList { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.Operation? Operation { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.SubscriptionList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.SubscriptionList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.SubscriptionList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagAction : System.IEquatable<Azure.ResourceManager.Elastic.Models.TagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagAction(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.TagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.TagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.TagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.TagAction left, Azure.ResourceManager.Elastic.Models.TagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.TagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.TagAction left, Azure.ResourceManager.Elastic.Models.TagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticResourceType : System.IEquatable<Azure.ResourceManager.Elastic.Models.Type>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Type(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.Type AzurePrivateEndpoint { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.Type IP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.Type other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.Type left, Azure.ResourceManager.Elastic.Models.Type right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.Type (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.Type left, Azure.ResourceManager.Elastic.Models.Type right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpgradableVersionsList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionsList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionsList>
    {
        internal UpgradableVersionsList() { }
        public string CurrentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> UpgradableVersions { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.UpgradableVersionsList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionsList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionsList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.UpgradableVersionsList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionsList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionsList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UpgradableVersionsList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserApiKeyResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse>
    {
        internal UserApiKeyResponse() { }
        public string ApiKey { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.UserApiKeyResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.UserApiKeyResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserApiKeyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticAssociatedEmailId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserEmailId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserEmailId>
    {
        public UserEmailId() { }
        public string EmailId { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.UserEmailId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserEmailId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserEmailId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.UserEmailId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserEmailId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserEmailId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserEmailId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserInfo>
    {
        public UserInfo() { }
        public Azure.ResourceManager.Elastic.Models.CompanyInfo CompanyInfo { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.UserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.UserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmCollectionUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>
    {
        public VmCollectionUpdate() { }
        public Azure.ResourceManager.Elastic.Models.OperationName? OperationName { get { throw null; } set { } }
        public string VmResourceId { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.VmCollectionUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.VmCollectionUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmIngestionDetailsResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>
    {
        internal VmIngestionDetailsResponse() { }
        public string CloudId { get { throw null; } }
        public string IngestionKey { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmResources : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmResources>
    {
        internal VmResources() { }
        public string VmResourceId { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.VmResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.VmResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
