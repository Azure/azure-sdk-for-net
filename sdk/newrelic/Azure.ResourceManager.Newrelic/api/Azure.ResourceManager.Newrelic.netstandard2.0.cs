namespace Azure.ResourceManager.Newrelic
{
    public static partial class NewrelicExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Newrelic.Models.AccountResource> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Newrelic.Models.AccountResource> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Newrelic.NewRelicMonitorResource GetNewRelicMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> GetNewRelicMonitorResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>> GetNewRelicMonitorResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Newrelic.NewRelicMonitorResourceCollection GetNewRelicMonitorResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> GetNewRelicMonitorResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> GetNewRelicMonitorResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Newrelic.Models.OrganizationResource> GetOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Newrelic.Models.OrganizationResource> GetOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Newrelic.Models.PlanDataResource> GetPlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string accountId = null, string organizationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Newrelic.Models.PlanDataResource> GetPlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string accountId = null, string organizationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Newrelic.TagRuleResource GetTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class NewRelicMonitorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NewRelicMonitorResource() { }
        public virtual Azure.ResourceManager.Newrelic.NewRelicMonitorResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string userEmail, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string userEmail, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Newrelic.Models.AppServiceInfo> GetAppServices(Azure.ResourceManager.Newrelic.Models.AppServicesGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Newrelic.Models.AppServiceInfo> GetAppServicesAsync(Azure.ResourceManager.Newrelic.Models.AppServicesGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Newrelic.Models.VmInfo> GetHosts(Azure.ResourceManager.Newrelic.Models.HostsGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Newrelic.Models.VmInfo> GetHostsAsync(Azure.ResourceManager.Newrelic.Models.HostsGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.Models.MetricRules> GetMetricRules(Azure.ResourceManager.Newrelic.Models.MetricsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.Models.MetricRules>> GetMetricRulesAsync(Azure.ResourceManager.Newrelic.Models.MetricsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.Models.MetricsStatusResponse> GetMetricStatus(Azure.ResourceManager.Newrelic.Models.MetricsStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.Models.MetricsStatusResponse>> GetMetricStatusAsync(Azure.ResourceManager.Newrelic.Models.MetricsStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Newrelic.Models.MonitoredResource> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Newrelic.Models.MonitoredResource> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.TagRuleResource> GetTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.TagRuleResource>> GetTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Newrelic.TagRuleCollection GetTagRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> SwitchBilling(Azure.ResourceManager.Newrelic.Models.SwitchBillingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>> SwitchBillingAsync(Azure.ResourceManager.Newrelic.Models.SwitchBillingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> Update(Azure.ResourceManager.Newrelic.Models.NewRelicMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>> UpdateAsync(Azure.ResourceManager.Newrelic.Models.NewRelicMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.Models.VmExtensionPayload> VmHostPayload(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.Models.VmExtensionPayload>> VmHostPayloadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NewRelicMonitorResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>, System.Collections.IEnumerable
    {
        protected NewRelicMonitorResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Newrelic.NewRelicMonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Newrelic.NewRelicMonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Newrelic.NewRelicMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Newrelic.NewRelicMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NewRelicMonitorResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NewRelicMonitorResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Newrelic.Models.AccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public string MarketplaceSubscriptionId { get { throw null; } }
        public Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } }
        public Azure.ResourceManager.Newrelic.Models.MonitoringStatus? MonitoringStatus { get { throw null; } }
        public Azure.ResourceManager.Newrelic.Models.NewRelicAccountProperties NewRelicAccountProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.OrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.PlanData PlanData { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Newrelic.Models.UserInfo UserInfo { get { throw null; } set { } }
    }
    public partial class TagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Newrelic.TagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Newrelic.TagRuleResource>, System.Collections.IEnumerable
    {
        protected TagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Newrelic.TagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Newrelic.TagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Newrelic.TagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Newrelic.TagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.TagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Newrelic.TagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Newrelic.TagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.TagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Newrelic.TagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Newrelic.TagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Newrelic.TagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Newrelic.TagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TagRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public TagRuleData() { }
        public Azure.ResourceManager.Newrelic.Models.LogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.MetricRules MetricRules { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class TagRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TagRuleResource() { }
        public virtual Azure.ResourceManager.Newrelic.TagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.TagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.TagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Newrelic.TagRuleResource> Update(Azure.ResourceManager.Newrelic.Models.TagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Newrelic.TagRuleResource>> UpdateAsync(Azure.ResourceManager.Newrelic.Models.TagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Newrelic.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccountCreationSource : System.IEquatable<Azure.ResourceManager.Newrelic.Models.AccountCreationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccountCreationSource(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.AccountCreationSource Liftr { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.AccountCreationSource Newrelic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.AccountCreationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.AccountCreationSource left, Azure.ResourceManager.Newrelic.Models.AccountCreationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.AccountCreationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.AccountCreationSource left, Azure.ResourceManager.Newrelic.Models.AccountCreationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccountInfo
    {
        public AccountInfo() { }
        public string AccountId { get { throw null; } set { } }
        public string IngestionKey { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
    }
    public partial class AccountResource : Azure.ResourceManager.Models.ResourceData
    {
        public AccountResource() { }
        public string AccountId { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
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
    public static partial class ArmNewrelicModelFactory
    {
        public static Azure.ResourceManager.Newrelic.Models.AccountResource AccountResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string organizationId = null, string accountId = null, string accountName = null, string region = null) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.AppServiceInfo AppServiceInfo(string azureResourceId = null, string agentVersion = null, string agentStatus = null) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.MetricsStatusResponse MetricsStatusResponse(System.Collections.Generic.IEnumerable<string> azureResourceIds = null) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.MonitoredResource MonitoredResource(string id = null, Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus? sendingMetrics = default(Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus?), string reasonForMetricsStatus = null, Azure.ResourceManager.Newrelic.Models.SendingLogsStatus? sendingLogs = default(Azure.ResourceManager.Newrelic.Models.SendingLogsStatus?), string reasonForLogsStatus = null) { throw null; }
        public static Azure.ResourceManager.Newrelic.NewRelicMonitorResourceData NewRelicMonitorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Newrelic.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Newrelic.Models.ProvisioningState?), Azure.ResourceManager.Newrelic.Models.MonitoringStatus? monitoringStatus = default(Azure.ResourceManager.Newrelic.Models.MonitoringStatus?), Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus?), string marketplaceSubscriptionId = null, Azure.ResourceManager.Newrelic.Models.NewRelicAccountProperties newRelicAccountProperties = null, Azure.ResourceManager.Newrelic.Models.UserInfo userInfo = null, Azure.ResourceManager.Newrelic.Models.PlanData planData = null, Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory?), int? liftrResourcePreference = default(int?), Azure.ResourceManager.Newrelic.Models.OrgCreationSource? orgCreationSource = default(Azure.ResourceManager.Newrelic.Models.OrgCreationSource?), Azure.ResourceManager.Newrelic.Models.AccountCreationSource? accountCreationSource = default(Azure.ResourceManager.Newrelic.Models.AccountCreationSource?)) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.OrganizationResource OrganizationResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string organizationId = null, string organizationName = null, Azure.ResourceManager.Newrelic.Models.BillingSource? billingSource = default(Azure.ResourceManager.Newrelic.Models.BillingSource?)) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.PlanDataResource PlanDataResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Newrelic.Models.PlanData planData = null, Azure.ResourceManager.Newrelic.Models.OrgCreationSource? orgCreationSource = default(Azure.ResourceManager.Newrelic.Models.OrgCreationSource?), Azure.ResourceManager.Newrelic.Models.AccountCreationSource? accountCreationSource = default(Azure.ResourceManager.Newrelic.Models.AccountCreationSource?)) { throw null; }
        public static Azure.ResourceManager.Newrelic.TagRuleData TagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Newrelic.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Newrelic.Models.ProvisioningState?), Azure.ResourceManager.Newrelic.Models.LogRules logRules = null, Azure.ResourceManager.Newrelic.Models.MetricRules metricRules = null) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.VmExtensionPayload VmExtensionPayload(string ingestionKey = null) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.VmInfo VmInfo(string vmId = null, string agentVersion = null, string agentStatus = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingCycle : System.IEquatable<Azure.ResourceManager.Newrelic.Models.BillingCycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingCycle(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.BillingCycle Monthly { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.BillingCycle Weekly { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.BillingCycle Yearly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.BillingCycle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.BillingCycle left, Azure.ResourceManager.Newrelic.Models.BillingCycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.BillingCycle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.BillingCycle left, Azure.ResourceManager.Newrelic.Models.BillingCycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingSource : System.IEquatable<Azure.ResourceManager.Newrelic.Models.BillingSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingSource(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.BillingSource Azure { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.BillingSource Newrelic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.BillingSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.BillingSource left, Azure.ResourceManager.Newrelic.Models.BillingSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.BillingSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.BillingSource left, Azure.ResourceManager.Newrelic.Models.BillingSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FilteringTag
    {
        public FilteringTag() { }
        public Azure.ResourceManager.Newrelic.Models.TagAction? Action { get { throw null; } set { } }
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
    public readonly partial struct LiftrResourceCategory : System.IEquatable<Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiftrResourceCategory(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory left, Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory left, Azure.ResourceManager.Newrelic.Models.LiftrResourceCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogRules
    {
        public LogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Newrelic.Models.FilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.Newrelic.Models.SendAadLogsStatus? SendAadLogs { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.SendActivityLogsStatus? SendActivityLogs { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.SendSubscriptionLogsStatus? SendSubscriptionLogs { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Newrelic.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricRules
    {
        public MetricRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Newrelic.Models.FilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.Newrelic.Models.SendMetricsStatus? SendMetrics { get { throw null; } set { } }
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
    public partial class MetricsStatusResponse
    {
        internal MetricsStatusResponse() { }
        public System.Collections.Generic.IReadOnlyList<string> AzureResourceIds { get { throw null; } }
    }
    public partial class MonitoredResource
    {
        internal MonitoredResource() { }
        public string Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public string ReasonForMetricsStatus { get { throw null; } }
        public Azure.ResourceManager.Newrelic.Models.SendingLogsStatus? SendingLogs { get { throw null; } }
        public Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus? SendingMetrics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringStatus : System.IEquatable<Azure.ResourceManager.Newrelic.Models.MonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.MonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.MonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.MonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.MonitoringStatus left, Azure.ResourceManager.Newrelic.Models.MonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.MonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.MonitoringStatus left, Azure.ResourceManager.Newrelic.Models.MonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicAccountProperties
    {
        public NewRelicAccountProperties() { }
        public Azure.ResourceManager.Newrelic.Models.AccountInfo AccountInfo { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.NewRelicSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class NewRelicMonitorResourcePatch
    {
        public NewRelicMonitorResourcePatch() { }
        public Azure.ResourceManager.Newrelic.Models.AccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.NewRelicAccountProperties NewRelicAccountProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.OrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.PlanData PlanData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Newrelic.Models.UserInfo UserInfo { get { throw null; } set { } }
    }
    public partial class NewRelicSingleSignOnProperties
    {
        public NewRelicSingleSignOnProperties() { }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.SingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
    }
    public partial class OrganizationResource : Azure.ResourceManager.Models.ResourceData
    {
        public OrganizationResource() { }
        public Azure.ResourceManager.Newrelic.Models.BillingSource? BillingSource { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrgCreationSource : System.IEquatable<Azure.ResourceManager.Newrelic.Models.OrgCreationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrgCreationSource(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.OrgCreationSource Liftr { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.OrgCreationSource Newrelic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.OrgCreationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.OrgCreationSource left, Azure.ResourceManager.Newrelic.Models.OrgCreationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.OrgCreationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.OrgCreationSource left, Azure.ResourceManager.Newrelic.Models.OrgCreationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlanData
    {
        public PlanData() { }
        public Azure.ResourceManager.Newrelic.Models.BillingCycle? BillingCycle { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } set { } }
        public string PlanDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.UsageType? UsageType { get { throw null; } set { } }
    }
    public partial class PlanDataResource : Azure.ResourceManager.Models.ResourceData
    {
        public PlanDataResource() { }
        public Azure.ResourceManager.Newrelic.Models.AccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.OrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.PlanData PlanData { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Newrelic.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.ProvisioningState left, Azure.ResourceManager.Newrelic.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.ProvisioningState left, Azure.ResourceManager.Newrelic.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendAadLogsStatus : System.IEquatable<Azure.ResourceManager.Newrelic.Models.SendAadLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendAadLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.SendAadLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.SendAadLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.SendAadLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.SendAadLogsStatus left, Azure.ResourceManager.Newrelic.Models.SendAadLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.SendAadLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.SendAadLogsStatus left, Azure.ResourceManager.Newrelic.Models.SendAadLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendActivityLogsStatus : System.IEquatable<Azure.ResourceManager.Newrelic.Models.SendActivityLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendActivityLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.SendActivityLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.SendActivityLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.SendActivityLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.SendActivityLogsStatus left, Azure.ResourceManager.Newrelic.Models.SendActivityLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.SendActivityLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.SendActivityLogsStatus left, Azure.ResourceManager.Newrelic.Models.SendActivityLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingLogsStatus : System.IEquatable<Azure.ResourceManager.Newrelic.Models.SendingLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.SendingLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.SendingLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.SendingLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.SendingLogsStatus left, Azure.ResourceManager.Newrelic.Models.SendingLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.SendingLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.SendingLogsStatus left, Azure.ResourceManager.Newrelic.Models.SendingLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingMetricsStatus : System.IEquatable<Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingMetricsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus left, Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus left, Azure.ResourceManager.Newrelic.Models.SendingMetricsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendMetricsStatus : System.IEquatable<Azure.ResourceManager.Newrelic.Models.SendMetricsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendMetricsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.SendMetricsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.SendMetricsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.SendMetricsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.SendMetricsStatus left, Azure.ResourceManager.Newrelic.Models.SendMetricsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.SendMetricsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.SendMetricsStatus left, Azure.ResourceManager.Newrelic.Models.SendMetricsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendSubscriptionLogsStatus : System.IEquatable<Azure.ResourceManager.Newrelic.Models.SendSubscriptionLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendSubscriptionLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.SendSubscriptionLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.SendSubscriptionLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.SendSubscriptionLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.SendSubscriptionLogsStatus left, Azure.ResourceManager.Newrelic.Models.SendSubscriptionLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.SendSubscriptionLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.SendSubscriptionLogsStatus left, Azure.ResourceManager.Newrelic.Models.SendSubscriptionLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnState : System.IEquatable<Azure.ResourceManager.Newrelic.Models.SingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.SingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.SingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.SingleSignOnState Existing { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.SingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.SingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.SingleSignOnState left, Azure.ResourceManager.Newrelic.Models.SingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.SingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.SingleSignOnState left, Azure.ResourceManager.Newrelic.Models.SingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SwitchBillingContent
    {
        public SwitchBillingContent(string userEmail) { }
        public string AzureResourceId { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.PlanData PlanData { get { throw null; } set { } }
        public string UserEmail { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagAction : System.IEquatable<Azure.ResourceManager.Newrelic.Models.TagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagAction(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.TagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.TagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.TagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.TagAction left, Azure.ResourceManager.Newrelic.Models.TagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.TagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.TagAction left, Azure.ResourceManager.Newrelic.Models.TagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagRulePatch
    {
        public TagRulePatch() { }
        public Azure.ResourceManager.Newrelic.Models.LogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.Newrelic.Models.MetricRules MetricRules { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageType : System.IEquatable<Azure.ResourceManager.Newrelic.Models.UsageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageType(string value) { throw null; }
        public static Azure.ResourceManager.Newrelic.Models.UsageType Committed { get { throw null; } }
        public static Azure.ResourceManager.Newrelic.Models.UsageType Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Newrelic.Models.UsageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Newrelic.Models.UsageType left, Azure.ResourceManager.Newrelic.Models.UsageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Newrelic.Models.UsageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Newrelic.Models.UsageType left, Azure.ResourceManager.Newrelic.Models.UsageType right) { throw null; }
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
        public string VmId { get { throw null; } }
    }
}
