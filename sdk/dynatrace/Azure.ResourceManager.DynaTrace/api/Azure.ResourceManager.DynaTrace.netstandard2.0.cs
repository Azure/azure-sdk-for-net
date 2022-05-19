namespace Azure.ResourceManager.DynaTrace
{
    public static partial class DynaTraceExtensions
    {
        public static Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource GetDynatraceSingleSignOnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DynaTrace.MonitorResource GetMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource> GetMonitorResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource>> GetMonitorResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DynaTrace.MonitorResourceCollection GetMonitorResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DynaTrace.MonitorResource> GetMonitorResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DynaTrace.MonitorResource> GetMonitorResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DynaTrace.TagRuleResource GetTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DynatraceSingleSignOnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DynatraceSingleSignOnResource() { }
        public virtual Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DynatraceSingleSignOnResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource>, System.Collections.IEnumerable
    {
        protected DynatraceSingleSignOnResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DynatraceSingleSignOnResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DynatraceSingleSignOnResourceData() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public System.Guid? EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
    }
    public partial class MonitorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorResource() { }
        public virtual Azure.ResourceManager.DynaTrace.MonitorResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.Models.AccountInfoSecure> GetAccountCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.Models.AccountInfoSecure>> GetAccountCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DynaTrace.Models.AppServiceInfo> GetAppServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DynaTrace.Models.AppServiceInfo> GetAppServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource> GetDynatraceSingleSignOnResource(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResource>> GetDynatraceSingleSignOnResourceAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DynaTrace.DynatraceSingleSignOnResourceCollection GetDynatraceSingleSignOnResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DynaTrace.Models.VmInfo> GetHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DynaTrace.Models.VmInfo> GetHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DynaTrace.Models.LinkableEnvironmentResult> GetLinkableEnvironments(Azure.ResourceManager.DynaTrace.Models.LinkableEnvironmentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DynaTrace.Models.LinkableEnvironmentResult> GetLinkableEnvironmentsAsync(Azure.ResourceManager.DynaTrace.Models.LinkableEnvironmentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DynaTrace.Models.MonitoredResourceDetails> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DynaTrace.Models.MonitoredResourceDetails> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.Models.SsoDetailsResult> GetSsoDetails(Azure.ResourceManager.DynaTrace.Models.SsoDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.Models.SsoDetailsResult>> GetSsoDetailsAsync(Azure.ResourceManager.DynaTrace.Models.SsoDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.TagRuleResource> GetTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.TagRuleResource>> GetTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DynaTrace.TagRuleCollection GetTagRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.Models.VmExtensionPayload> GetVmHostPayload(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.Models.VmExtensionPayload>> GetVmHostPayloadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource> Update(Azure.ResourceManager.DynaTrace.Models.MonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource>> UpdateAsync(Azure.ResourceManager.DynaTrace.Models.MonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitorResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DynaTrace.MonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DynaTrace.MonitorResource>, System.Collections.IEnumerable
    {
        protected MonitorResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DynaTrace.MonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.DynaTrace.MonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DynaTrace.MonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.DynaTrace.MonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DynaTrace.MonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DynaTrace.MonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.MonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DynaTrace.MonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DynaTrace.MonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DynaTrace.MonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DynaTrace.MonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MonitorResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DynaTrace.Models.DynatraceEnvironmentProperties DynatraceEnvironmentProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.IdentityProperties Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.LiftrResourceCategories? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.MonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.PlanData PlanData { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.UserInfo UserInfo { get { throw null; } set { } }
    }
    public partial class TagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DynaTrace.TagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DynaTrace.TagRuleResource>, System.Collections.IEnumerable
    {
        protected TagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DynaTrace.TagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.DynaTrace.TagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DynaTrace.TagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.DynaTrace.TagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.TagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DynaTrace.TagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DynaTrace.TagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.TagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DynaTrace.TagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DynaTrace.TagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DynaTrace.TagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DynaTrace.TagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TagRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public TagRuleData() { }
        public Azure.ResourceManager.DynaTrace.Models.LogRules LogRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DynaTrace.Models.FilteringTag> MetricRulesFilteringTags { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class TagRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TagRuleResource() { }
        public virtual Azure.ResourceManager.DynaTrace.TagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.TagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.TagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DynaTrace.TagRuleResource> Update(Azure.ResourceManager.DynaTrace.Models.TagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DynaTrace.TagRuleResource>> UpdateAsync(Azure.ResourceManager.DynaTrace.Models.TagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DynaTrace.Models
{
    public partial class AccountInfo
    {
        public AccountInfo() { }
        public string AccountId { get { throw null; } set { } }
        public string RegionId { get { throw null; } set { } }
    }
    public partial class AccountInfoSecure
    {
        internal AccountInfoSecure() { }
        public string AccountId { get { throw null; } }
        public string ApiKey { get { throw null; } }
        public string RegionId { get { throw null; } }
    }
    public partial class AppServiceInfo
    {
        internal AppServiceInfo() { }
        public Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting? AutoUpdateSetting { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.AvailabilityState? AvailabilityState { get { throw null; } }
        public string HostGroup { get { throw null; } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.LogModule? LogModule { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.MonitoringType? MonitoringType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.UpdateStatus? UpdateStatus { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoUpdateSetting : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoUpdateSetting(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting Disabled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting left, Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting left, Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityState : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.AvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.AvailabilityState Crashed { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.AvailabilityState Lost { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.AvailabilityState Monitored { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.AvailabilityState PreMonitored { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.AvailabilityState Shutdown { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.AvailabilityState UnexpectedShutdown { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.AvailabilityState Unknown { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.AvailabilityState Unmonitored { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.AvailabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.AvailabilityState left, Azure.ResourceManager.DynaTrace.Models.AvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.AvailabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.AvailabilityState left, Azure.ResourceManager.DynaTrace.Models.AvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynatraceEnvironmentProperties
    {
        public DynatraceEnvironmentProperties() { }
        public Azure.ResourceManager.DynaTrace.Models.AccountInfo AccountInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.EnvironmentInfo EnvironmentInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.DynatraceSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class DynatraceSingleSignOnProperties
    {
        public DynatraceSingleSignOnProperties() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public System.Guid? EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
    }
    public partial class EnvironmentInfo
    {
        public EnvironmentInfo() { }
        public string EnvironmentId { get { throw null; } set { } }
        public string IngestionKey { get { throw null; } set { } }
        public System.Uri LandingUri { get { throw null; } set { } }
        public string LogsIngestionEndpoint { get { throw null; } set { } }
    }
    public partial class FilteringTag
    {
        public FilteringTag() { }
        public Azure.ResourceManager.DynaTrace.Models.TagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class IdentityProperties
    {
        public IdentityProperties(Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType managedIdentityType) { }
        public Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType ManagedIdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiftrResourceCategories : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.LiftrResourceCategories>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiftrResourceCategories(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.LiftrResourceCategories MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.LiftrResourceCategories Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.LiftrResourceCategories other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.LiftrResourceCategories left, Azure.ResourceManager.DynaTrace.Models.LiftrResourceCategories right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.LiftrResourceCategories (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.LiftrResourceCategories left, Azure.ResourceManager.DynaTrace.Models.LiftrResourceCategories right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkableEnvironmentContent
    {
        public LinkableEnvironmentContent() { }
        public Azure.Core.AzureLocation? Region { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string UserPrincipal { get { throw null; } set { } }
    }
    public partial class LinkableEnvironmentResult
    {
        internal LinkableEnvironmentResult() { }
        public string EnvironmentId { get { throw null; } }
        public string EnvironmentName { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.PlanData PlanData { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogModule : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.LogModule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogModule(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.LogModule Disabled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.LogModule Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.LogModule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.LogModule left, Azure.ResourceManager.DynaTrace.Models.LogModule right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.LogModule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.LogModule left, Azure.ResourceManager.DynaTrace.Models.LogModule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogRules
    {
        public LogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DynaTrace.Models.FilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.SendAadLogsStatus? SendAadLogs { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.SendActivityLogsStatus? SendActivityLogs { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.SendSubscriptionLogsStatus? SendSubscriptionLogs { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityType : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType SystemAndUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType left, Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType left, Azure.ResourceManager.DynaTrace.Models.ManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus Active { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitoredResourceDetails
    {
        internal MonitoredResourceDetails() { }
        public string Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public string ReasonForMetricsStatus { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.SendingLogsStatus? SendingLogsStatus { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.SendingMetricsStatus? SendingMetricsStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringStatus : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.MonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.MonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.MonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.MonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.MonitoringStatus left, Azure.ResourceManager.DynaTrace.Models.MonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.MonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.MonitoringStatus left, Azure.ResourceManager.DynaTrace.Models.MonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringType : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.MonitoringType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringType(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.MonitoringType CloudInfrastructure { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.MonitoringType FullStack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.MonitoringType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.MonitoringType left, Azure.ResourceManager.DynaTrace.Models.MonitoringType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.MonitoringType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.MonitoringType left, Azure.ResourceManager.DynaTrace.Models.MonitoringType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorResourcePatch
    {
        public MonitorResourcePatch() { }
        public Azure.ResourceManager.DynaTrace.Models.DynatraceEnvironmentProperties DynatraceEnvironmentProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.MonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DynaTrace.Models.PlanData PlanData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.UserInfo UserInfo { get { throw null; } set { } }
    }
    public partial class PlanData
    {
        public PlanData() { }
        public string BillingCycle { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } set { } }
        public string PlanDetails { get { throw null; } set { } }
        public string UsageType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.ProvisioningState left, Azure.ResourceManager.DynaTrace.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.ProvisioningState left, Azure.ResourceManager.DynaTrace.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendAadLogsStatus : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.SendAadLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendAadLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.SendAadLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.SendAadLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.SendAadLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.SendAadLogsStatus left, Azure.ResourceManager.DynaTrace.Models.SendAadLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.SendAadLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.SendAadLogsStatus left, Azure.ResourceManager.DynaTrace.Models.SendAadLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendActivityLogsStatus : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.SendActivityLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendActivityLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.SendActivityLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.SendActivityLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.SendActivityLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.SendActivityLogsStatus left, Azure.ResourceManager.DynaTrace.Models.SendActivityLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.SendActivityLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.SendActivityLogsStatus left, Azure.ResourceManager.DynaTrace.Models.SendActivityLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingLogsStatus : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.SendingLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.SendingLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.SendingLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.SendingLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.SendingLogsStatus left, Azure.ResourceManager.DynaTrace.Models.SendingLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.SendingLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.SendingLogsStatus left, Azure.ResourceManager.DynaTrace.Models.SendingLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingMetricsStatus : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.SendingMetricsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingMetricsStatus(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.SendingMetricsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.SendingMetricsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.SendingMetricsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.SendingMetricsStatus left, Azure.ResourceManager.DynaTrace.Models.SendingMetricsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.SendingMetricsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.SendingMetricsStatus left, Azure.ResourceManager.DynaTrace.Models.SendingMetricsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendSubscriptionLogsStatus : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.SendSubscriptionLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendSubscriptionLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.SendSubscriptionLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.SendSubscriptionLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.SendSubscriptionLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.SendSubscriptionLogsStatus left, Azure.ResourceManager.DynaTrace.Models.SendSubscriptionLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.SendSubscriptionLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.SendSubscriptionLogsStatus left, Azure.ResourceManager.DynaTrace.Models.SendSubscriptionLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnStates : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnStates(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates Disable { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates Enable { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates Existing { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates left, Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates left, Azure.ResourceManager.DynaTrace.Models.SingleSignOnStates right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SsoDetailsContent
    {
        public SsoDetailsContent() { }
        public string UserPrincipal { get { throw null; } set { } }
    }
    public partial class SsoDetailsResult
    {
        internal SsoDetailsResult() { }
        public System.Collections.Generic.IReadOnlyList<string> AadDomains { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AdminUsers { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.SsoStatus? IsSsoEnabled { get { throw null; } }
        public System.Uri MetadataUri { get { throw null; } }
        public System.Uri SingleSignOnUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsoStatus : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.SsoStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsoStatus(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.SsoStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.SsoStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.SsoStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.SsoStatus left, Azure.ResourceManager.DynaTrace.Models.SsoStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.SsoStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.SsoStatus left, Azure.ResourceManager.DynaTrace.Models.SsoStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagAction : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.TagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagAction(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.TagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.TagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.TagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.TagAction left, Azure.ResourceManager.DynaTrace.Models.TagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.TagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.TagAction left, Azure.ResourceManager.DynaTrace.Models.TagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagRulePatch
    {
        public TagRulePatch() { }
        public Azure.ResourceManager.DynaTrace.Models.LogRules LogRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DynaTrace.Models.FilteringTag> MetricRulesFilteringTags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateStatus : System.IEquatable<Azure.ResourceManager.DynaTrace.Models.UpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.DynaTrace.Models.UpdateStatus Incompatible { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.UpdateStatus Outdated { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.UpdateStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.UpdateStatus Suppressed { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.UpdateStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.UpdateStatus UP2Date { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.UpdateStatus UpdateINProgress { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.UpdateStatus UpdatePending { get { throw null; } }
        public static Azure.ResourceManager.DynaTrace.Models.UpdateStatus UpdateProblem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DynaTrace.Models.UpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DynaTrace.Models.UpdateStatus left, Azure.ResourceManager.DynaTrace.Models.UpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DynaTrace.Models.UpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DynaTrace.Models.UpdateStatus left, Azure.ResourceManager.DynaTrace.Models.UpdateStatus right) { throw null; }
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
        public string EnvironmentId { get { throw null; } }
        public string IngestionKey { get { throw null; } }
    }
    public partial class VmInfo
    {
        internal VmInfo() { }
        public Azure.ResourceManager.DynaTrace.Models.AutoUpdateSetting? AutoUpdateSetting { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.AvailabilityState? AvailabilityState { get { throw null; } }
        public string HostGroup { get { throw null; } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.LogModule? LogModule { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.MonitoringType? MonitoringType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.DynaTrace.Models.UpdateStatus? UpdateStatus { get { throw null; } }
        public string Version { get { throw null; } }
    }
}
