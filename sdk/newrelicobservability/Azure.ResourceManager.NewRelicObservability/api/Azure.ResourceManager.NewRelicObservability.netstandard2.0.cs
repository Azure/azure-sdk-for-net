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
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.AppServiceInfo> GetAppServices(Azure.ResourceManager.NewRelicObservability.Models.AppServicesGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.AppServiceInfo> GetAppServicesAsync(Azure.ResourceManager.NewRelicObservability.Models.AppServicesGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.VmInfo> GetHosts(Azure.ResourceManager.NewRelicObservability.Models.HostsGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.VmInfo> GetHostsAsync(Azure.ResourceManager.NewRelicObservability.Models.HostsGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.MetricRules> GetMetricRules(Azure.ResourceManager.NewRelicObservability.Models.MetricsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.MetricRules>> GetMetricRulesAsync(Azure.ResourceManager.NewRelicObservability.Models.MetricsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.MetricsStatusResult> GetMetricStatus(Azure.ResourceManager.NewRelicObservability.Models.MetricsStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.MetricsStatusResult>> GetMetricStatusAsync(Azure.ResourceManager.NewRelicObservability.Models.MetricsStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.ResourceMonitoredByNewRelic> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.ResourceMonitoredByNewRelic> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.TagRuleResource> GetTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.TagRuleResource>> GetTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NewRelicObservability.TagRuleCollection GetTagRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> SwitchBilling(Azure.ResourceManager.NewRelicObservability.Models.SwitchBillingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> SwitchBillingAsync(Azure.ResourceManager.NewRelicObservability.Models.SwitchBillingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> Update(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> UpdateAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.VmExtensionPayload> VmHostPayload(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.VmExtensionPayload>> VmHostPayloadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NewRelicMonitorResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NewRelicMonitorResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public Azure.Core.ResourceIdentifier MarketplaceSubscriptionId { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus? MonitoringStatus { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties NewRelicAccountProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlan PlanData { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.UserInfo UserInfo { get { throw null; } set { } }
    }
    public static partial class NewRelicObservabilityExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource GetNewRelicMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetNewRelicMonitorResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> GetNewRelicMonitorResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceCollection GetNewRelicMonitorResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetNewRelicMonitorResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> GetNewRelicMonitorResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData> GetOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData> GetOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanResourceData> GetPlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string accountId = null, string organizationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanResourceData> GetPlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string accountId = null, string organizationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.TagRuleResource GetTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class TagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NewRelicObservability.TagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NewRelicObservability.TagRuleResource>, System.Collections.IEnumerable
    {
        protected TagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.TagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.NewRelicObservability.TagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.TagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.NewRelicObservability.TagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.TagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.TagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.TagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.TagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NewRelicObservability.TagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NewRelicObservability.TagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NewRelicObservability.TagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NewRelicObservability.TagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TagRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public TagRuleData() { }
        public Azure.ResourceManager.NewRelicObservability.Models.LogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.MetricRules MetricRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class TagRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TagRuleResource() { }
        public virtual Azure.ResourceManager.NewRelicObservability.TagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.TagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.TagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.TagRuleResource> Update(Azure.ResourceManager.NewRelicObservability.Models.TagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.TagRuleResource>> UpdateAsync(Azure.ResourceManager.NewRelicObservability.Models.TagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NewRelicObservability.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccountCreationSource : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccountCreationSource(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource Liftr { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource Newrelic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource left, Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource left, Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccountInfo
    {
        public AccountInfo() { }
        public string AccountId { get { throw null; } set { } }
        public string IngestionKey { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
    }
    public partial class AppServiceInfo
    {
        internal AppServiceInfo() { }
        public string AgentStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string AzureResourceId { get { throw null; } }
    }
    public partial class AppServicesGetContent
    {
        public AppServicesGetContent(string userEmail) { }
        public System.Collections.Generic.IList<string> AzureResourceIds { get { throw null; } }
        public string UserEmail { get { throw null; } }
    }
    public static partial class ArmNewRelicObservabilityModelFactory
    {
        public static Azure.ResourceManager.NewRelicObservability.Models.AppServiceInfo AppServiceInfo(string azureResourceId = null, string agentVersion = null, string agentStatus = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.MetricsStatusResult MetricsStatusResult(System.Collections.Generic.IEnumerable<string> azureResourceIds = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData NewRelicAccountResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string organizationId = null, string accountId = null, string accountName = null, string region = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData NewRelicMonitorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState? provisioningState = default(Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState?), Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus? monitoringStatus = default(Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus?), Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus?), Azure.Core.ResourceIdentifier marketplaceSubscriptionId = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties newRelicAccountProperties = null, Azure.ResourceManager.NewRelicObservability.Models.UserInfo userInfo = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlan planData = null, Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory?), int? liftrResourcePreference = default(int?), Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource? orgCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource?), Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource? accountCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData NewRelicOrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string organizationId = null, string organizationName = null, Azure.ResourceManager.NewRelicObservability.Models.BillingSource? billingSource = default(Azure.ResourceManager.NewRelicObservability.Models.BillingSource?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanResourceData NewRelicPlanResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlan planData = null, Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource? orgCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource?), Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource? accountCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.ResourceMonitoredByNewRelic ResourceMonitoredByNewRelic(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus? sendingMetrics = default(Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus?), string reasonForMetricsStatus = null, Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus? sendingLogs = default(Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus?), string reasonForLogsStatus = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.TagRuleData TagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState? provisioningState = default(Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState?), Azure.ResourceManager.NewRelicObservability.Models.LogRules logRules = null, Azure.ResourceManager.NewRelicObservability.Models.MetricRules metricRules = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.VmExtensionPayload VmExtensionPayload(string ingestionKey = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.VmInfo VmInfo(Azure.Core.ResourceIdentifier vmId = null, string agentVersion = null, string agentStatus = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingCycle : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.BillingCycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingCycle(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.BillingCycle Monthly { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.BillingCycle Weekly { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.BillingCycle Yearly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.BillingCycle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.BillingCycle left, Azure.ResourceManager.NewRelicObservability.Models.BillingCycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.BillingCycle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.BillingCycle left, Azure.ResourceManager.NewRelicObservability.Models.BillingCycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingSource : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.BillingSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingSource(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.BillingSource Azure { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.BillingSource Newrelic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.BillingSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.BillingSource left, Azure.ResourceManager.NewRelicObservability.Models.BillingSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.BillingSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.BillingSource left, Azure.ResourceManager.NewRelicObservability.Models.BillingSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FilteringTag
    {
        public FilteringTag() { }
        public Azure.ResourceManager.NewRelicObservability.Models.TagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class HostsGetContent
    {
        public HostsGetContent(string userEmail) { }
        public string UserEmail { get { throw null; } }
        public System.Collections.Generic.IList<string> VmIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiftrResourceCategory : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiftrResourceCategory(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory left, Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory left, Azure.ResourceManager.NewRelicObservability.Models.LiftrResourceCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogRules
    {
        public LogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NewRelicObservability.Models.FilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.SendAadLogsStatus? SendAadLogs { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.SendActivityLogsStatus? SendActivityLogs { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.SendSubscriptionLogsStatus? SendSubscriptionLogs { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus Active { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricRules
    {
        public MetricRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NewRelicObservability.Models.FilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.SendMetricsStatus? SendMetrics { get { throw null; } set { } }
        public string UserEmail { get { throw null; } set { } }
    }
    public partial class MetricsContent
    {
        public MetricsContent(string userEmail) { }
        public string UserEmail { get { throw null; } }
    }
    public partial class MetricsStatusContent
    {
        public MetricsStatusContent(string userEmail) { }
        public System.Collections.Generic.IList<string> AzureResourceIds { get { throw null; } }
        public string UserEmail { get { throw null; } }
    }
    public partial class MetricsStatusResult
    {
        internal MetricsStatusResult() { }
        public System.Collections.Generic.IReadOnlyList<string> AzureResourceIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus left, Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus left, Azure.ResourceManager.NewRelicObservability.Models.MonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicAccountProperties
    {
        public NewRelicAccountProperties() { }
        public Azure.ResourceManager.NewRelicObservability.Models.AccountInfo AccountInfo { get { throw null; } set { } }
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
        public string Region { get { throw null; } set { } }
    }
    public partial class NewRelicMonitorResourcePatch
    {
        public NewRelicMonitorResourcePatch() { }
        public Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties NewRelicAccountProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlan PlanData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.UserInfo UserInfo { get { throw null; } set { } }
    }
    public partial class NewRelicOrganizationResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public NewRelicOrganizationResourceData() { }
        public Azure.ResourceManager.NewRelicObservability.Models.BillingSource? BillingSource { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
    }
    public partial class NewRelicPlan
    {
        public NewRelicPlan() { }
        public Azure.ResourceManager.NewRelicObservability.Models.BillingCycle? BillingCycle { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } set { } }
        public string PlanDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.UsageType? UsageType { get { throw null; } set { } }
    }
    public partial class NewRelicPlanResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public NewRelicPlanResourceData() { }
        public Azure.ResourceManager.NewRelicObservability.Models.AccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlan PlanData { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewrelicProvisioningState : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewrelicProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState left, Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState left, Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicSingleSignOnProperties
    {
        public NewRelicSingleSignOnProperties() { }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewrelicProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrgCreationSource : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrgCreationSource(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource Liftr { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource Newrelic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource left, Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource left, Azure.ResourceManager.NewRelicObservability.Models.OrgCreationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceMonitoredByNewRelic
    {
        internal ResourceMonitoredByNewRelic() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public string ReasonForMetricsStatus { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus? SendingLogs { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus? SendingMetrics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendAadLogsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.SendAadLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendAadLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendAadLogsStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendAadLogsStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.SendAadLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.SendAadLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendAadLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.SendAadLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.SendAadLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendAadLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendActivityLogsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.SendActivityLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendActivityLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendActivityLogsStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendActivityLogsStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.SendActivityLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.SendActivityLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendActivityLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.SendActivityLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.SendActivityLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendActivityLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingLogsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendingLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingMetricsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingMetricsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendingMetricsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendMetricsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.SendMetricsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendMetricsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendMetricsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendMetricsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.SendMetricsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.SendMetricsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendMetricsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.SendMetricsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.SendMetricsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendMetricsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendSubscriptionLogsStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.SendSubscriptionLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendSubscriptionLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendSubscriptionLogsStatus IsDisabled { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.SendSubscriptionLogsStatus IsEnabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.SendSubscriptionLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.SendSubscriptionLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendSubscriptionLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.SendSubscriptionLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.SendSubscriptionLogsStatus left, Azure.ResourceManager.NewRelicObservability.Models.SendSubscriptionLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnState : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState Existing { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState left, Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState left, Azure.ResourceManager.NewRelicObservability.Models.SingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SwitchBillingContent
    {
        public SwitchBillingContent(string userEmail) { }
        public string AzureResourceId { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlan PlanData { get { throw null; } set { } }
        public string UserEmail { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagAction : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.TagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagAction(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.TagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.TagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.TagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.TagAction left, Azure.ResourceManager.NewRelicObservability.Models.TagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.TagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.TagAction left, Azure.ResourceManager.NewRelicObservability.Models.TagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagRulePatch
    {
        public TagRulePatch() { }
        public Azure.ResourceManager.NewRelicObservability.Models.LogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.MetricRules MetricRules { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageType : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.UsageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageType(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.UsageType Committed { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.UsageType Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.UsageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.UsageType left, Azure.ResourceManager.NewRelicObservability.Models.UsageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.UsageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.UsageType left, Azure.ResourceManager.NewRelicObservability.Models.UsageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserInfo
    {
        public UserInfo() { }
        public string Country { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
    }
    public partial class VmExtensionPayload
    {
        internal VmExtensionPayload() { }
        public string IngestionKey { get { throw null; } }
    }
    public partial class VmInfo
    {
        internal VmInfo() { }
        public string AgentStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier VmId { get { throw null; } }
    }
}
