namespace Azure.ResourceManager.Dynatrace
{
    public static partial class DynatraceExtensions
    {
        public static Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource GetDynatraceSingleSignOnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dynatrace.MonitorResource GetMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource> GetMonitorResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource>> GetMonitorResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dynatrace.MonitorResourceCollection GetMonitorResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Dynatrace.MonitorResource> GetMonitorResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.MonitorResource> GetMonitorResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dynatrace.TagRuleResource GetTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DynatraceSingleSignOnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DynatraceSingleSignOnResource() { }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DynatraceSingleSignOnResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>, System.Collections.IEnumerable
    {
        protected DynatraceSingleSignOnResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DynatraceSingleSignOnResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public DynatraceSingleSignOnResourceData() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public System.Guid? EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
    }
    public partial class MonitorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorResource() { }
        public virtual Azure.ResourceManager.Dynatrace.MonitorResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.Models.AccountInfoSecure> GetAccountCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.Models.AccountInfoSecure>> GetAccountCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.Models.AppServiceInfo> GetAppServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.Models.AppServiceInfo> GetAppServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> GetDynatraceSingleSignOnResource(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> GetDynatraceSingleSignOnResourceAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResourceCollection GetDynatraceSingleSignOnResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.Models.VmInfo> GetHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.Models.VmInfo> GetHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult> GetLinkableEnvironments(Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult> GetLinkableEnvironmentsAsync(Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.Models.MonitoredResourceDetails> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.Models.MonitoredResourceDetails> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.Models.SsoDetailsResult> GetSsoDetails(Azure.ResourceManager.Dynatrace.Models.SsoDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.Models.SsoDetailsResult>> GetSsoDetailsAsync(Azure.ResourceManager.Dynatrace.Models.SsoDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.TagRuleResource> GetTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.TagRuleResource>> GetTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dynatrace.TagRuleCollection GetTagRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.Models.VmExtensionPayload> GetVmHostPayload(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.Models.VmExtensionPayload>> GetVmHostPayloadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource> Update(Azure.ResourceManager.Dynatrace.Models.MonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource>> UpdateAsync(Azure.ResourceManager.Dynatrace.Models.MonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitorResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.MonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.MonitorResource>, System.Collections.IEnumerable
    {
        protected MonitorResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.MonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Dynatrace.MonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.MonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Dynatrace.MonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.MonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.MonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.MonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dynatrace.MonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.MonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dynatrace.MonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.MonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MonitorResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties DynatraceEnvironmentProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.IdentityProperties Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategories? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.MonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.PlanData PlanData { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.UserInfo UserInfo { get { throw null; } set { } }
    }
    public partial class TagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.TagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.TagRuleResource>, System.Collections.IEnumerable
    {
        protected TagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.TagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Dynatrace.TagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.TagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Dynatrace.TagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.TagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.TagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.TagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.TagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dynatrace.TagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.TagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dynatrace.TagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.TagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TagRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public TagRuleData() { }
        public Azure.ResourceManager.Dynatrace.Models.LogRules LogRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dynatrace.Models.FilteringTag> MetricRulesFilteringTags { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class TagRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TagRuleResource() { }
        public virtual Azure.ResourceManager.Dynatrace.TagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.TagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.TagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.TagRuleResource> Update(Azure.ResourceManager.Dynatrace.Models.TagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.TagRuleResource>> UpdateAsync(Azure.ResourceManager.Dynatrace.Models.TagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dynatrace.Models
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
        public Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting? AutoUpdateSetting { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.AvailabilityState? AvailabilityState { get { throw null; } }
        public string HostGroup { get { throw null; } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.LogModule? LogModule { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.MonitoringType? MonitoringType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.UpdateStatus? UpdateStatus { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoUpdateSetting : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoUpdateSetting(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting left, Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting left, Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityState : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.AvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.AvailabilityState Crashed { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.AvailabilityState Lost { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.AvailabilityState Monitored { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.AvailabilityState PreMonitored { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.AvailabilityState Shutdown { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.AvailabilityState UnexpectedShutdown { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.AvailabilityState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.AvailabilityState Unmonitored { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.AvailabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.AvailabilityState left, Azure.ResourceManager.Dynatrace.Models.AvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.AvailabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.AvailabilityState left, Azure.ResourceManager.Dynatrace.Models.AvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynatraceEnvironmentProperties
    {
        public DynatraceEnvironmentProperties() { }
        public Azure.ResourceManager.Dynatrace.Models.AccountInfo AccountInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.EnvironmentInfo EnvironmentInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class DynatraceSingleSignOnProperties
    {
        public DynatraceSingleSignOnProperties() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public System.Guid? EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates? SingleSignOnState { get { throw null; } set { } }
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
        public Azure.ResourceManager.Dynatrace.Models.TagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class IdentityProperties
    {
        public IdentityProperties(Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType managedIdentityType) { }
        public Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType ManagedIdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiftrResourceCategories : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategories>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiftrResourceCategories(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategories MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategories Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategories other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategories left, Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategories right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategories (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategories left, Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategories right) { throw null; }
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
        public Azure.ResourceManager.Dynatrace.Models.PlanData PlanData { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogModule : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.LogModule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogModule(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.LogModule Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.LogModule Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.LogModule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.LogModule left, Azure.ResourceManager.Dynatrace.Models.LogModule right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.LogModule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.LogModule left, Azure.ResourceManager.Dynatrace.Models.LogModule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogRules
    {
        public LogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dynatrace.Models.FilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.SendAadLogsStatus? SendAadLogs { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.SendActivityLogsStatus? SendActivityLogs { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.SendSubscriptionLogsStatus? SendSubscriptionLogs { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityType : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType SystemAndUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType left, Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType left, Azure.ResourceManager.Dynatrace.Models.ManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitoredResourceDetails
    {
        internal MonitoredResourceDetails() { }
        public string Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public string ReasonForMetricsStatus { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.SendingLogsStatus? SendingLogsStatus { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.SendingMetricsStatus? SendingMetricsStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.MonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.MonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.MonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.MonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.MonitoringStatus left, Azure.ResourceManager.Dynatrace.Models.MonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.MonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.MonitoringStatus left, Azure.ResourceManager.Dynatrace.Models.MonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringType : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.MonitoringType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringType(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.MonitoringType CloudInfrastructure { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.MonitoringType FullStack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.MonitoringType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.MonitoringType left, Azure.ResourceManager.Dynatrace.Models.MonitoringType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.MonitoringType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.MonitoringType left, Azure.ResourceManager.Dynatrace.Models.MonitoringType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitorResourcePatch
    {
        public MonitorResourcePatch() { }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties DynatraceEnvironmentProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.MonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.PlanData PlanData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.UserInfo UserInfo { get { throw null; } set { } }
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
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.ProvisioningState left, Azure.ResourceManager.Dynatrace.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.ProvisioningState left, Azure.ResourceManager.Dynatrace.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendAadLogsStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.SendAadLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendAadLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.SendAadLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.SendAadLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.SendAadLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.SendAadLogsStatus left, Azure.ResourceManager.Dynatrace.Models.SendAadLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.SendAadLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.SendAadLogsStatus left, Azure.ResourceManager.Dynatrace.Models.SendAadLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendActivityLogsStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.SendActivityLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendActivityLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.SendActivityLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.SendActivityLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.SendActivityLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.SendActivityLogsStatus left, Azure.ResourceManager.Dynatrace.Models.SendActivityLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.SendActivityLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.SendActivityLogsStatus left, Azure.ResourceManager.Dynatrace.Models.SendActivityLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingLogsStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.SendingLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.SendingLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.SendingLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.SendingLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.SendingLogsStatus left, Azure.ResourceManager.Dynatrace.Models.SendingLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.SendingLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.SendingLogsStatus left, Azure.ResourceManager.Dynatrace.Models.SendingLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingMetricsStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.SendingMetricsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingMetricsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.SendingMetricsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.SendingMetricsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.SendingMetricsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.SendingMetricsStatus left, Azure.ResourceManager.Dynatrace.Models.SendingMetricsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.SendingMetricsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.SendingMetricsStatus left, Azure.ResourceManager.Dynatrace.Models.SendingMetricsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendSubscriptionLogsStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.SendSubscriptionLogsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendSubscriptionLogsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.SendSubscriptionLogsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.SendSubscriptionLogsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.SendSubscriptionLogsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.SendSubscriptionLogsStatus left, Azure.ResourceManager.Dynatrace.Models.SendSubscriptionLogsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.SendSubscriptionLogsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.SendSubscriptionLogsStatus left, Azure.ResourceManager.Dynatrace.Models.SendSubscriptionLogsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnStates : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnStates(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates Disable { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates Enable { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates Existing { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates left, Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates left, Azure.ResourceManager.Dynatrace.Models.SingleSignOnStates right) { throw null; }
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
        public Azure.ResourceManager.Dynatrace.Models.SsoStatus? IsSsoEnabled { get { throw null; } }
        public System.Uri MetadataUri { get { throw null; } }
        public System.Uri SingleSignOnUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SsoStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.SsoStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SsoStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.SsoStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.SsoStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.SsoStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.SsoStatus left, Azure.ResourceManager.Dynatrace.Models.SsoStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.SsoStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.SsoStatus left, Azure.ResourceManager.Dynatrace.Models.SsoStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagAction : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.TagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagAction(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.TagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.TagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.TagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.TagAction left, Azure.ResourceManager.Dynatrace.Models.TagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.TagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.TagAction left, Azure.ResourceManager.Dynatrace.Models.TagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagRulePatch
    {
        public TagRulePatch() { }
        public Azure.ResourceManager.Dynatrace.Models.LogRules LogRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dynatrace.Models.FilteringTag> MetricRulesFilteringTags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.UpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.UpdateStatus Incompatible { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.UpdateStatus Outdated { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.UpdateStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.UpdateStatus Suppressed { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.UpdateStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.UpdateStatus UP2Date { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.UpdateStatus UpdateINProgress { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.UpdateStatus UpdatePending { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.UpdateStatus UpdateProblem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.UpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.UpdateStatus left, Azure.ResourceManager.Dynatrace.Models.UpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.UpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.UpdateStatus left, Azure.ResourceManager.Dynatrace.Models.UpdateStatus right) { throw null; }
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
        public Azure.ResourceManager.Dynatrace.Models.AutoUpdateSetting? AutoUpdateSetting { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.AvailabilityState? AvailabilityState { get { throw null; } }
        public string HostGroup { get { throw null; } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.LogModule? LogModule { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.MonitoringType? MonitoringType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.UpdateStatus? UpdateStatus { get { throw null; } }
        public string Version { get { throw null; } }
    }
}
