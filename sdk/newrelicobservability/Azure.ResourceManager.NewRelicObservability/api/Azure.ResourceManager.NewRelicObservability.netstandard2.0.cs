namespace Azure.ResourceManager.NewRelicObservability
{
    public partial class NewRelicMonitorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NewRelicMonitorResource() { }
        public virtual Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string userEmail, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string userEmail, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo> GetAppServices(Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo> GetAppServicesAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo> GetHosts(Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo> GetHostsAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules> GetMetricRules(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules>> GetMetricRulesAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult> GetMetricStatus(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult>> GetMetricStatusAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> GetNewRelicObservabilityTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>> GetNewRelicObservabilityTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleCollection GetNewRelicObservabilityTagRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> SwitchBilling(Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> SwitchBillingAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> Update(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> UpdateAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload> VmHostPayload(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload>> VmHostPayloadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NewRelicMonitorResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>, System.Collections.IEnumerable
    {
        protected NewRelicMonitorResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetIfExists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> GetIfExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NewRelicMonitorResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NewRelicMonitorResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public string MarketplaceSubscriptionId { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus? MonitoringStatus { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties NewRelicAccountProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails PlanData { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo UserInfo { get { throw null; } set { } }
    }
    public static partial class NewRelicObservabilityExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData> GetNewRelicAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData> GetNewRelicAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource GetNewRelicMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetNewRelicMonitorResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> GetNewRelicMonitorResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceCollection GetNewRelicMonitorResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetNewRelicMonitorResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetNewRelicMonitorResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource GetNewRelicObservabilityTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData> GetNewRelicOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData> GetNewRelicOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData> GetNewRelicPlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string accountId = null, string organizationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData> GetNewRelicPlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string accountId = null, string organizationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NewRelicObservabilityTagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>, System.Collections.IEnumerable
    {
        protected NewRelicObservabilityTagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> GetIfExists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>> GetIfExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NewRelicObservabilityTagRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public NewRelicObservabilityTagRuleData() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules MetricRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class NewRelicObservabilityTagRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NewRelicObservabilityTagRuleResource() { }
        public virtual Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> Update(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>> UpdateAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NewRelicObservability.Mocking
{
    public partial class MockableNewRelicObservabilityArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNewRelicObservabilityArmClient() { }
        public virtual Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource GetNewRelicMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource GetNewRelicObservabilityTagRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNewRelicObservabilityResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNewRelicObservabilityResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetNewRelicMonitorResource(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> GetNewRelicMonitorResourceAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceCollection GetNewRelicMonitorResources() { throw null; }
    }
    public partial class MockableNewRelicObservabilitySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNewRelicObservabilitySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData> GetNewRelicAccounts(string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData> GetNewRelicAccountsAsync(string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetNewRelicMonitorResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetNewRelicMonitorResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData> GetNewRelicOrganizations(string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData> GetNewRelicOrganizationsAsync(string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData> GetNewRelicPlans(string accountId = null, string organizationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData> GetNewRelicPlansAsync(string accountId = null, string organizationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NewRelicObservability.Models
{
    public static partial class ArmNewRelicObservabilityModelFactory
    {
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData NewRelicAccountResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string organizationId = null, string accountId = null, string accountName = null, Azure.Core.AzureLocation? region = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult NewRelicMetricsStatusResult(System.Collections.Generic.IEnumerable<string> azureResourceIds = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData NewRelicMonitorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? provisioningState = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus? monitoringStatus = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus?), string marketplaceSubscriptionId = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties newRelicAccountProperties = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo userInfo = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails planData = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory?), int? liftrResourcePreference = default(int?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? orgCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? accountCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo NewRelicObservabilityAppServiceInfo(Azure.Core.ResourceIdentifier azureResourceId = null, string agentVersion = null, string agentStatus = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData NewRelicObservabilityTagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? provisioningState = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules logRules = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules metricRules = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload NewRelicObservabilityVmExtensionPayload(string ingestionKey = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo NewRelicObservabilityVmInfo(Azure.Core.ResourceIdentifier vmId = null, string agentVersion = null, string agentStatus = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData NewRelicOrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string organizationId = null, string organizationName = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource? billingSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData NewRelicPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails planData = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? orgCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? accountCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult NewRelicResourceMonitorResult(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus? sendingMetrics = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus?), string reasonForMetricsStatus = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus? sendingLogs = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus?), string reasonForLogsStatus = null) { throw null; }
    }
    public partial class NewRelicAccountProperties
    {
        public NewRelicAccountProperties() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo AccountInfo { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class NewRelicAccountResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public NewRelicAccountResourceData() { }
        public string AccountId { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Region { get { throw null; } set { } }
    }
    public partial class NewRelicAppServicesGetContent
    {
        public NewRelicAppServicesGetContent(string userEmail) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> AzureResourceIds { get { throw null; } }
        public string UserEmail { get { throw null; } }
    }
    public partial class NewRelicHostsGetContent
    {
        public NewRelicHostsGetContent(string userEmail) { }
        public string UserEmail { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VmIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicLiftrResourceCategory : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicLiftrResourceCategory(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicMetricsContent
    {
        public NewRelicMetricsContent(string userEmail) { }
        public string UserEmail { get { throw null; } }
    }
    public partial class NewRelicMetricsStatusContent
    {
        public NewRelicMetricsStatusContent(string userEmail) { }
        public System.Collections.Generic.IList<string> AzureResourceIds { get { throw null; } }
        public string UserEmail { get { throw null; } }
    }
    public partial class NewRelicMetricsStatusResult
    {
        internal NewRelicMetricsStatusResult() { }
        public System.Collections.Generic.IReadOnlyList<string> AzureResourceIds { get { throw null; } }
    }
    public partial class NewRelicMonitorResourcePatch
    {
        public NewRelicMonitorResourcePatch() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties NewRelicAccountProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails PlanData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo UserInfo { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilityAccountCreationSource : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilityAccountCreationSource(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource Liftr { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource Newrelic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicObservabilityAccountInfo
    {
        public NewRelicObservabilityAccountInfo() { }
        public string AccountId { get { throw null; } set { } }
        public string IngestionKey { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Region { get { throw null; } set { } }
    }
    public partial class NewRelicObservabilityAppServiceInfo
    {
        internal NewRelicObservabilityAppServiceInfo() { }
        public string AgentStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilityBillingCycle : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilityBillingCycle(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle Monthly { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle Weekly { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle Yearly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilityBillingSource : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilityBillingSource(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource Azure { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource Newrelic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicObservabilityFilteringTag
    {
        public NewRelicObservabilityFilteringTag() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class NewRelicObservabilityLogRules
    {
        public NewRelicObservabilityLogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus? SendAadLogs { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus? SendActivityLogs { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus? SendSubscriptionLogs { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilityMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilityMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus Active { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicObservabilityMetricRules
    {
        public NewRelicObservabilityMetricRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus? SendMetrics { get { throw null; } set { } }
        public string UserEmail { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilityMonitoringStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilityMonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilityOrgCreationSource : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilityOrgCreationSource(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource Liftr { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource Newrelic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilitySendAadLogsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilitySendAadLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilitySendActivityLogsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilitySendActivityLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilitySendingLogsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilitySendingLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilitySendingMetricsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilitySendingMetricsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilitySendMetricsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilitySendMetricsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilitySendSubscriptionLogsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilitySendSubscriptionLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilityTagAction : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilityTagAction(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicObservabilityTagRulePatch
    {
        public NewRelicObservabilityTagRulePatch() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules MetricRules { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicObservabilityUsageType : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicObservabilityUsageType(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType Committed { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicObservabilityUserInfo
    {
        public NewRelicObservabilityUserInfo() { }
        public string Country { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
    }
    public partial class NewRelicObservabilityVmExtensionPayload
    {
        internal NewRelicObservabilityVmExtensionPayload() { }
        public string IngestionKey { get { throw null; } }
    }
    public partial class NewRelicObservabilityVmInfo
    {
        internal NewRelicObservabilityVmInfo() { }
        public string AgentStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier VmId { get { throw null; } }
    }
    public partial class NewRelicOrganizationResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public NewRelicOrganizationResourceData() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource? BillingSource { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
    }
    public partial class NewRelicPlanData : Azure.ResourceManager.Models.ResourceData
    {
        public NewRelicPlanData() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails PlanData { get { throw null; } set { } }
    }
    public partial class NewRelicPlanDetails
    {
        public NewRelicPlanDetails() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle? BillingCycle { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } set { } }
        public string PlanDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType? UsageType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicProvisioningState : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicResourceMonitorResult
    {
        internal NewRelicResourceMonitorResult() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public string ReasonForMetricsStatus { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus? SendingLogs { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus? SendingMetrics { get { throw null; } }
    }
    public partial class NewRelicSingleSignOnProperties
    {
        public NewRelicSingleSignOnProperties() { }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicSingleSignOnState : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState Existing { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicSwitchBillingContent
    {
        public NewRelicSwitchBillingContent(string userEmail) { }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails PlanData { get { throw null; } set { } }
        public string UserEmail { get { throw null; } }
    }
}
