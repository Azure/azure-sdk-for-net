namespace Azure.ResourceManager.Dynatrace
{
    public partial class AzureResourceManagerDynatraceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDynatraceContext() { }
        public static Azure.ResourceManager.Dynatrace.AzureResourceManagerDynatraceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DynatraceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> GetDynatraceMonitor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>> GetDynatraceMonitorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dynatrace.DynatraceMonitorResource GetDynatraceMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dynatrace.DynatraceMonitorCollection GetDynatraceMonitors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> GetDynatraceMonitors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> GetDynatraceMonitorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource GetDynatraceSingleSignOnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource GetDynatraceTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DynatraceMonitorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>, System.Collections.IEnumerable
    {
        protected DynatraceMonitorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Dynatrace.DynatraceMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Dynatrace.DynatraceMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> GetIfExists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>> GetIfExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DynatraceMonitorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>
    {
        public DynatraceMonitorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties DynatraceEnvironmentProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategory? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo PlanData { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo UserInfo { get { throw null; } set { } }
        Azure.ResourceManager.Dynatrace.DynatraceMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.DynatraceMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceMonitorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DynatraceMonitorResource() { }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceMonitorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo> GetAccountCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo>> GetAccountCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo> GetAppServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo> GetAppServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> GetDynatraceSingleSignOn(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> GetDynatraceSingleSignOnAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnCollection GetDynatraceSingleSignOns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource> GetDynatraceTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource>> GetDynatraceTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceTagRuleCollection GetDynatraceTagRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo> GetHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo> GetHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult> GetLinkableEnvironments(Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult> GetLinkableEnvironmentsAsync(Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult> GetSsoDetails(Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult>> GetSsoDetailsAsync(Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload> GetVmHostPayload(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload>> GetVmHostPayloadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Dynatrace.DynatraceMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.DynatraceMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> Update(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>> UpdateAsync(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DynatraceSingleSignOnCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>, System.Collections.IEnumerable
    {
        protected DynatraceSingleSignOnCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DynatraceSingleSignOnData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>
    {
        public DynatraceSingleSignOnData() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public System.Guid? EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceSingleSignOnResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DynatraceSingleSignOnResource() { }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DynatraceTagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource>, System.Collections.IEnumerable
    {
        protected DynatraceTagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Dynatrace.DynatraceTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Dynatrace.DynatraceTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource> GetIfExists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource>> GetIfExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DynatraceTagRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>
    {
        public DynatraceTagRuleData() { }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules LogRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag> MetricRulesFilteringTags { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.DynatraceTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.DynatraceTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceTagRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DynatraceTagRuleResource() { }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceTagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Dynatrace.DynatraceTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.DynatraceTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.DynatraceTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource> Update(Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource>> UpdateAsync(Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dynatrace.Mocking
{
    public partial class MockableDynatraceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDynatraceArmClient() { }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceMonitorResource GetDynatraceMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnResource GetDynatraceSingleSignOnResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceTagRuleResource GetDynatraceTagRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDynatraceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDynatraceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> GetDynatraceMonitor(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource>> GetDynatraceMonitorAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Dynatrace.DynatraceMonitorCollection GetDynatraceMonitors() { throw null; }
    }
    public partial class MockableDynatraceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDynatraceSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> GetDynatraceMonitors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Dynatrace.DynatraceMonitorResource> GetDynatraceMonitorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Dynatrace.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AadLogsSendingStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.AadLogsSendingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AadLogsSendingStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.AadLogsSendingStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.AadLogsSendingStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.AadLogsSendingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.AadLogsSendingStatus left, Azure.ResourceManager.Dynatrace.Models.AadLogsSendingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.AadLogsSendingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.AadLogsSendingStatus left, Azure.ResourceManager.Dynatrace.Models.AadLogsSendingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivityLogsSendingStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.ActivityLogsSendingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivityLogsSendingStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.ActivityLogsSendingStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.ActivityLogsSendingStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.ActivityLogsSendingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.ActivityLogsSendingStatus left, Azure.ResourceManager.Dynatrace.Models.ActivityLogsSendingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.ActivityLogsSendingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.ActivityLogsSendingStatus left, Azure.ResourceManager.Dynatrace.Models.ActivityLogsSendingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmDynatraceModelFactory
    {
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo DynatraceAccountCredentialsInfo(string accountId = null, string apiKey = null, string regionId = null) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails DynatraceMonitoredResourceDetails(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus? sendingMetricsStatus = default(Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus?), string reasonForMetricsStatus = null, Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus? sendingLogsStatus = default(Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus?), string reasonForLogsStatus = null) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo DynatraceMonitorVmInfo(Azure.Core.ResourceIdentifier resourceId = null, string version = null, Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType? monitoringType = default(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType?), Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting? autoUpdateSetting = default(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting?), Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus? updateStatus = default(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus?), Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState? availabilityState = default(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState?), Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState? logModule = default(Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState?), string hostGroup = null, string hostName = null) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo DynatraceOneAgentEnabledAppServiceInfo(Azure.Core.ResourceIdentifier resourceId = null, string version = null, Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType? monitoringType = default(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType?), Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting? autoUpdateSetting = default(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting?), Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus? updateStatus = default(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus?), Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState? availabilityState = default(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState?), Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState? logModule = default(Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState?), string hostGroup = null, string hostName = null) { throw null; }
        public static Azure.ResourceManager.Dynatrace.DynatraceSingleSignOnData DynatraceSingleSignOnData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState? singleSignOnState = default(Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState?), System.Guid? enterpriseAppId = default(System.Guid?), System.Uri singleSignOnUri = null, System.Collections.Generic.IEnumerable<string> aadDomains = null, Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState? provisioningState = default(Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties DynatraceSingleSignOnProperties(Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState? singleSignOnState = default(Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState?), System.Guid? enterpriseAppId = default(System.Guid?), System.Uri singleSignOnUri = null, System.Collections.Generic.IEnumerable<string> aadDomains = null, Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState? provisioningState = default(Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult DynatraceSsoDetailsResult(Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus? isSsoEnabled = default(Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus?), System.Uri metadataUri = null, System.Uri singleSignOnUri = null, System.Collections.Generic.IEnumerable<string> aadDomains = null, System.Collections.Generic.IEnumerable<string> adminUsers = null) { throw null; }
        public static Azure.ResourceManager.Dynatrace.DynatraceTagRuleData DynatraceTagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules logRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag> metricRulesFilteringTags = null, Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState? provisioningState = default(Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload DynatraceVmExtensionPayload(string ingestionKey = null, string environmentId = null) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult LinkableEnvironmentResult(string environmentId = null, string environmentName = null, Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo planData = null) { throw null; }
    }
    public partial class DynatraceAccountCredentialsInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo>
    {
        internal DynatraceAccountCredentialsInfo() { }
        public string AccountId { get { throw null; } }
        public string ApiKey { get { throw null; } }
        public string RegionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountCredentialsInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceAccountInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountInfo>
    {
        public DynatraceAccountInfo() { }
        public string AccountId { get { throw null; } set { } }
        public string RegionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceAccountInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceAccountInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceAccountInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceBillingPlanInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo>
    {
        public DynatraceBillingPlanInfo() { }
        public string BillingCycle { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } set { } }
        public string PlanDetails { get { throw null; } set { } }
        public string UsageType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceEnvironmentInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentInfo>
    {
        public DynatraceEnvironmentInfo() { }
        public string EnvironmentId { get { throw null; } set { } }
        public string IngestionKey { get { throw null; } set { } }
        public System.Uri LandingUri { get { throw null; } set { } }
        public System.Uri LogsIngestionEndpoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceEnvironmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties>
    {
        public DynatraceEnvironmentProperties() { }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceAccountInfo AccountInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentInfo EnvironmentInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceLogModuleState : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceLogModuleState(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState left, Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState left, Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynatraceMonitoredResourceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails>
    {
        internal DynatraceMonitoredResourceDetails() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public string ReasonForMetricsStatus { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus? SendingLogsStatus { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus? SendingMetricsStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoredResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceMonitoringStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceMonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus left, Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus left, Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceMonitorMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceMonitorMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus left, Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus left, Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynatraceMonitorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch>
    {
        public DynatraceMonitorPatch() { }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceEnvironmentProperties DynatraceEnvironmentProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorMarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo PlanData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo UserInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceMonitorResourceFilteringTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag>
    {
        public DynatraceMonitorResourceFilteringTag() { }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceTagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceMonitorResourceLogRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules>
    {
        public DynatraceMonitorResourceLogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.AadLogsSendingStatus? SendAadLogs { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.ActivityLogsSendingStatus? SendActivityLogs { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.SubscriptionLogsSendingStatus? SendSubscriptionLogs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceMonitorResourceTagAction : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceTagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceMonitorResourceTagAction(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceTagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceTagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceTagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceTagAction left, Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceTagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceTagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceTagAction left, Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceTagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynatraceMonitorUserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo>
    {
        public DynatraceMonitorUserInfo() { }
        public string Country { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorUserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceMonitorVmInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo>
    {
        internal DynatraceMonitorVmInfo() { }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting? AutoUpdateSetting { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState? AvailabilityState { get { throw null; } }
        public string HostGroup { get { throw null; } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState? LogModule { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType? MonitoringType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus? UpdateStatus { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorVmInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceOneAgentAutoUpdateSetting : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceOneAgentAutoUpdateSetting(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting left, Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting left, Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceOneAgentAvailabilityState : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceOneAgentAvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState Crashed { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState Lost { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState Monitored { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState PreMonitored { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState Shutdown { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState UnexpectedShutdown { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState Unmonitored { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState left, Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState left, Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynatraceOneAgentEnabledAppServiceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo>
    {
        internal DynatraceOneAgentEnabledAppServiceInfo() { }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAutoUpdateSetting? AutoUpdateSetting { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentAvailabilityState? AvailabilityState { get { throw null; } }
        public string HostGroup { get { throw null; } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceLogModuleState? LogModule { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType? MonitoringType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus? UpdateStatus { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentEnabledAppServiceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceOneAgentMonitoringType : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceOneAgentMonitoringType(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType CloudInfrastructure { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType FullStack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType left, Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType left, Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentMonitoringType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceOneAgentUpdateStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceOneAgentUpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus Incompatible { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus Outdated { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus Suppressed { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus UpdateInProgress { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus UpdatePending { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus UpdateProblem { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus UpToDate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus left, Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus left, Azure.ResourceManager.Dynatrace.Models.DynatraceOneAgentUpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceProvisioningState : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState left, Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState left, Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynatraceSingleSignOnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties>
    {
        public DynatraceSingleSignOnProperties() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public System.Guid? EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceSingleSignOnState : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState Existing { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState left, Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState left, Azure.ResourceManager.Dynatrace.Models.DynatraceSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynatraceSsoDetailsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent>
    {
        public DynatraceSsoDetailsContent() { }
        public string UserPrincipal { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceSsoDetailsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult>
    {
        internal DynatraceSsoDetailsResult() { }
        public System.Collections.Generic.IReadOnlyList<string> AadDomains { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AdminUsers { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus? IsSsoEnabled { get { throw null; } }
        public System.Uri MetadataUri { get { throw null; } }
        public System.Uri SingleSignOnUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoDetailsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynatraceSsoStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynatraceSsoStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus left, Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus left, Azure.ResourceManager.Dynatrace.Models.DynatraceSsoStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynatraceTagRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch>
    {
        public DynatraceTagRulePatch() { }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceLogRules LogRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Dynatrace.Models.DynatraceMonitorResourceFilteringTag> MetricRulesFilteringTags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceTagRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynatraceVmExtensionPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload>
    {
        internal DynatraceVmExtensionPayload() { }
        public string EnvironmentId { get { throw null; } }
        public string IngestionKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.DynatraceVmExtensionPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiftrResourceCategory : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiftrResourceCategory(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategory MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategory left, Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategory left, Azure.ResourceManager.Dynatrace.Models.LiftrResourceCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkableEnvironmentContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent>
    {
        public LinkableEnvironmentContent() { }
        public Azure.Core.AzureLocation? Region { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string UserPrincipal { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkableEnvironmentResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult>
    {
        internal LinkableEnvironmentResult() { }
        public string EnvironmentId { get { throw null; } }
        public string EnvironmentName { get { throw null; } }
        public Azure.ResourceManager.Dynatrace.Models.DynatraceBillingPlanInfo PlanData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Dynatrace.Models.LinkableEnvironmentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogsSendingStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogsSendingStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus left, Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus left, Azure.ResourceManager.Dynatrace.Models.LogsSendingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricsSendingStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricsSendingStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus left, Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus left, Azure.ResourceManager.Dynatrace.Models.MetricsSendingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionLogsSendingStatus : System.IEquatable<Azure.ResourceManager.Dynatrace.Models.SubscriptionLogsSendingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionLogsSendingStatus(string value) { throw null; }
        public static Azure.ResourceManager.Dynatrace.Models.SubscriptionLogsSendingStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Dynatrace.Models.SubscriptionLogsSendingStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Dynatrace.Models.SubscriptionLogsSendingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Dynatrace.Models.SubscriptionLogsSendingStatus left, Azure.ResourceManager.Dynatrace.Models.SubscriptionLogsSendingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Dynatrace.Models.SubscriptionLogsSendingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Dynatrace.Models.SubscriptionLogsSendingStatus left, Azure.ResourceManager.Dynatrace.Models.SubscriptionLogsSendingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
