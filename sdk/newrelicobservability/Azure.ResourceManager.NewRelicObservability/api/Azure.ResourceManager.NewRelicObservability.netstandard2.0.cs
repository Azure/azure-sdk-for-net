namespace Azure.ResourceManager.NewRelicObservability
{
    public partial class AzureResourceManagerNewRelicObservabilityContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNewRelicObservabilityContext() { }
        public static Azure.ResourceManager.NewRelicObservability.AzureResourceManagerNewRelicObservabilityContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class NewRelicMonitoredSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource>, System.Collections.IEnumerable
    {
        protected NewRelicMonitoredSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName, Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName, Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource> Get(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource>> GetAsync(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource> GetIfExists(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource>> GetIfExistsAsync(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NewRelicMonitoredSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>
    {
        public NewRelicMonitoredSubscriptionData() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicMonitoredSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NewRelicMonitoredSubscriptionResource() { }
        public virtual Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NewRelicMonitorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>
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
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult> GetBillingInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult>> GetBillingInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo> GetConnectedPartnerResources(string body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo> GetConnectedPartnerResourcesAsync(string body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo> GetHosts(Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo> GetHostsAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetLinkedResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetLinkedResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules> GetMetricRules(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules>> GetMetricRulesAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult> GetMetricStatus(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult>> GetMetricStatusAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource> GetNewRelicMonitoredSubscription(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource>> GetNewRelicMonitoredSubscriptionAsync(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionCollection GetNewRelicMonitoredSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> GetNewRelicObservabilityTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>> GetNewRelicObservabilityTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleCollection GetNewRelicObservabilityTagRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult> LatestLinkedSaaS(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult>> LatestLinkedSaaSAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> LinkSaaS(Azure.WaitUntil waitUntil, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> LinkSaaSAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshIngestionKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshIngestionKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> Resubscribe(Azure.WaitUntil waitUntil, Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> ResubscribeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> SwitchBilling(Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> SwitchBillingAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> Update(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> UpdateAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class NewRelicMonitorResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>
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
        public string SaaSAzureSubscriptionStatus { get { throw null; } set { } }
        public string SaaSResourceId { get { throw null; } set { } }
        public string SubscriptionState { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo UserInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class NewRelicObservabilityExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult> ActivateResourceSaaS(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult>> ActivateResourceSaaSAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData> GetNewRelicAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData> GetNewRelicAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string userEmail, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource GetNewRelicMonitoredSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
    public partial class NewRelicObservabilityTagRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>
    {
        public NewRelicObservabilityTagRuleData() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules MetricRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicObservabilityTagRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>
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
        Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource> Update(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleResource>> UpdateAsync(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NewRelicObservability.Mocking
{
    public partial class MockableNewRelicObservabilityArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNewRelicObservabilityArmClient() { }
        public virtual Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionResource GetNewRelicMonitoredSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult> ActivateResourceSaaS(Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult>> ActivateResourceSaaSAsync(Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ActivateSaaSParameterContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent>
    {
        public ActivateSaaSParameterContent(string saasGuid, string publisherId) { }
        public string PublisherId { get { throw null; } }
        public string SaasGuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.ActivateSaaSParameterContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmNewRelicObservabilityModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo MarketplaceSaaSInfo(string marketplaceSubscriptionId, string marketplaceSubscriptionName, string marketplaceResourceId, string marketplaceStatus, string billedAzureSubscriptionId) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo MarketplaceSaaSInfo(string marketplaceSubscriptionId = null, string marketplaceSubscriptionName = null, string marketplaceResourceId = null, string marketplaceStatus = null, string billedAzureSubscriptionId = null, string publisherId = null, string offerId = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData NewRelicAccountResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string organizationId = null, string accountId = null, string accountName = null, Azure.Core.AzureLocation? region = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent NewRelicAppServicesGetContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> azureResourceIds = null, string userEmail = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult NewRelicBillingInfoResult(Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo marketplaceSaasInfo = null, Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity partnerBillingEntity = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo NewRelicConnectedPartnerResourceInfo(Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties NewRelicConnectedPartnerResourceProperties(string accountName = null, string accountId = null, string azureResourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent NewRelicHostsGetContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> vmIds = null, string userEmail = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicLatestLinkedSaaSResult NewRelicLatestLinkedSaaSResult(Azure.Core.ResourceIdentifier saaSResourceId = null, bool? isHiddenSaaS = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent NewRelicMetricsStatusContent(System.Collections.Generic.IEnumerable<string> azureResourceIds = null, string userEmail = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult NewRelicMetricsStatusResult(System.Collections.Generic.IEnumerable<string> azureResourceIds = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitoredSubscriptionData NewRelicMonitoredSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties NewRelicMonitoredSubscriptionProperties(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation? patchOperation = default(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo> monitoredSubscriptionList = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? provisioningState = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules NewRelicMonitoringTagRules(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? provisioningState = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules logRules = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules metricRules = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData NewRelicMonitorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? provisioningState = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus? monitoringStatus = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus?), string marketplaceSubscriptionId = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties newRelicAccountProperties = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo userInfo = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails planData = null, Azure.Core.ResourceIdentifier saaSResourceId = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory?), int? liftrResourcePreference = default(int?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? orgCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? accountCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource?), string subscriptionState = null, string saaSAzureSubscriptionStatus = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData NewRelicMonitorResourceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? provisioningState, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus? monitoringStatus, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus, string marketplaceSubscriptionId, Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties newRelicAccountProperties, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo userInfo, Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails planData, Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory? liftrResourceCategory, int? liftrResourcePreference, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? orgCreationSource, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? accountCreationSource) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData NewRelicMonitorResourceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? provisioningState, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus? monitoringStatus, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus, string marketplaceSubscriptionId, Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties newRelicAccountProperties, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo userInfo, Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails planData, Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory? liftrResourceCategory, int? liftrResourcePreference, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? orgCreationSource, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? accountCreationSource, string subscriptionState, string saaSAzureSubscriptionStatus) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicMonitorResourceData NewRelicMonitorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? provisioningState = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus? monitoringStatus = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMonitoringStatus?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMarketplaceSubscriptionStatus?), string marketplaceSubscriptionId = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties newRelicAccountProperties = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo userInfo = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails planData = null, string saaSResourceId = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicLiftrResourceCategory?), int? liftrResourcePreference = default(int?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? orgCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? accountCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource?), string subscriptionState = null, string saaSAzureSubscriptionStatus = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo NewRelicObservabilityAppServiceInfo(Azure.Core.ResourceIdentifier azureResourceId = null, string agentVersion = null, string agentStatus = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult NewRelicObservabilityLatestLinkedSaaSResult(string saaSResourceId = null, bool? isHiddenSaaS = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult NewRelicObservabilitySaaSResourceDetailsResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string saasId = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.NewRelicObservabilityTagRuleData NewRelicObservabilityTagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? provisioningState = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules logRules = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules metricRules = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload NewRelicObservabilityVmExtensionPayload(string ingestionKey = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo NewRelicObservabilityVmInfo(Azure.Core.ResourceIdentifier vmId = null, string agentVersion = null, string agentStatus = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData NewRelicOrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string organizationId = null, string organizationName = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource? billingSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData NewRelicPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails planData = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? orgCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource?), Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? accountCreationSource = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource?)) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult NewRelicResourceMonitorResult(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus? sendingMetrics = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus?), string reasonForMetricsStatus = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus? sendingLogs = default(Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus?), string reasonForLogsStatus = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSResourceDetailsResult NewRelicSaaSResourceDetailsResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string saasId = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent NewRelicSwitchBillingContent(Azure.Core.ResourceIdentifier azureResourceId = null, string organizationId = null, Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails planData = null, string userEmail = null) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity PartnerBillingEntity(string organizationId = null, string organizationName = null) { throw null; }
    }
    public partial class MarketplaceSaaSInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo>
    {
        internal MarketplaceSaaSInfo() { }
        public string BilledAzureSubscriptionId { get { throw null; } }
        public string MarketplaceResourceId { get { throw null; } }
        public string MarketplaceStatus { get { throw null; } }
        public string MarketplaceSubscriptionId { get { throw null; } }
        public string MarketplaceSubscriptionName { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string PublisherId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoredSubscriptionConfigurationName : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoredSubscriptionConfigurationName(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName left, Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName left, Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionConfigurationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoredSubscriptionPatchOperation : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoredSubscriptionPatchOperation(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation Active { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation AddBegin { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation AddComplete { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation DeleteBegin { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation DeleteComplete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation left, Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation left, Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicAccountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties>
    {
        public NewRelicAccountProperties() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo AccountInfo { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicAccountResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData>
    {
        public NewRelicAccountResourceData() { }
        public string AccountId { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Region { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicAppServicesGetContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent>
    {
        public NewRelicAppServicesGetContent(string userEmail) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> AzureResourceIds { get { throw null; } }
        public string UserEmail { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicAppServicesGetContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicBillingInfoResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult>
    {
        internal NewRelicBillingInfoResult() { }
        public Azure.ResourceManager.NewRelicObservability.Models.MarketplaceSaaSInfo MarketplaceSaasInfo { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity PartnerBillingEntity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicBillingInfoResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicConnectedPartnerResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo>
    {
        internal NewRelicConnectedPartnerResourceInfo() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicConnectedPartnerResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties>
    {
        internal NewRelicConnectedPartnerResourceProperties() { }
        public string AccountId { get { throw null; } }
        public string AccountName { get { throw null; } }
        public string AzureResourceId { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicConnectedPartnerResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicHostsGetContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent>
    {
        public NewRelicHostsGetContent(string userEmail) { }
        public string UserEmail { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VmIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicHostsGetContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicLatestLinkedSaaSResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicLatestLinkedSaaSResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicLatestLinkedSaaSResult>
    {
        internal NewRelicLatestLinkedSaaSResult() { }
        public bool? IsHiddenSaaS { get { throw null; } }
        public Azure.Core.ResourceIdentifier SaaSResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicLatestLinkedSaaSResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicLatestLinkedSaaSResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicLatestLinkedSaaSResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicLatestLinkedSaaSResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicLatestLinkedSaaSResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicLatestLinkedSaaSResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicLatestLinkedSaaSResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NewRelicMetricsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent>
    {
        public NewRelicMetricsContent(string userEmail) { }
        public string UserEmail { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicMetricsStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent>
    {
        public NewRelicMetricsStatusContent(string userEmail) { }
        public System.Collections.Generic.IList<string> AzureResourceIds { get { throw null; } }
        public string UserEmail { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicMetricsStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult>
    {
        internal NewRelicMetricsStatusResult() { }
        public System.Collections.Generic.IReadOnlyList<string> AzureResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMetricsStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicMonitoredSubscriptionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo>
    {
        public NewRelicMonitoredSubscriptionInfo() { }
        public string Error { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus? Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules TagRules { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicMonitoredSubscriptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties>
    {
        public NewRelicMonitoredSubscriptionProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionInfo> MonitoredSubscriptionList { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.MonitoredSubscriptionPatchOperation? PatchOperation { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoredSubscriptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NewRelicMonitoringStatus : System.IEquatable<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NewRelicMonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus Active { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus left, Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NewRelicMonitoringTagRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules>
    {
        public NewRelicMonitoringTagRules() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules MetricRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitoringTagRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicMonitorResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch>
    {
        public NewRelicMonitorResourcePatch() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicAccountProperties NewRelicAccountProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails PlanData { get { throw null; } set { } }
        public string SaaSResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo UserInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicMonitorResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NewRelicObservabilityAccountInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo>
    {
        public NewRelicObservabilityAccountInfo() { }
        public string AccountId { get { throw null; } set { } }
        public string IngestionKey { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Region { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicObservabilityAppServiceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo>
    {
        internal NewRelicObservabilityAppServiceInfo() { }
        public string AgentStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAppServiceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NewRelicObservabilityFilteringTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag>
    {
        public NewRelicObservabilityFilteringTag() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicObservabilityLatestLinkedSaaSResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult>
    {
        internal NewRelicObservabilityLatestLinkedSaaSResult() { }
        public bool? IsHiddenSaaS { get { throw null; } }
        public string SaaSResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLatestLinkedSaaSResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicObservabilityLogRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules>
    {
        public NewRelicObservabilityLogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendAadLogsStatus? SendAadLogs { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendActivityLogsStatus? SendActivityLogs { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendSubscriptionLogsStatus? SendSubscriptionLogs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NewRelicObservabilityMetricRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules>
    {
        public NewRelicObservabilityMetricRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityFilteringTag> FilteringTags { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendMetricsStatus? SendMetrics { get { throw null; } set { } }
        public string UserEmail { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NewRelicObservabilitySaaSContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent>
    {
        public NewRelicObservabilitySaaSContent() { }
        public string SaaSResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicObservabilitySaaSResourceDetailsResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult>
    {
        public NewRelicObservabilitySaaSResourceDetailsResult() { }
        public string SaasId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySaaSResourceDetailsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NewRelicObservabilityTagRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch>
    {
        public NewRelicObservabilityTagRulePatch() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityLogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityMetricRules MetricRules { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityTagRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NewRelicObservabilityUserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo>
    {
        public NewRelicObservabilityUserInfo() { }
        public string Country { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicObservabilityVmExtensionPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload>
    {
        internal NewRelicObservabilityVmExtensionPayload() { }
        public string IngestionKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmExtensionPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicObservabilityVmInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo>
    {
        internal NewRelicObservabilityVmInfo() { }
        public string AgentStatus { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier VmId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityVmInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicOrganizationResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData>
    {
        public NewRelicOrganizationResourceData() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingSource? BillingSource { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicOrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicPlanData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData>
    {
        public NewRelicPlanData() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityAccountCreationSource? AccountCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityOrgCreationSource? OrgCreationSource { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails PlanData { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicPlanDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails>
    {
        public NewRelicPlanDetails() { }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityBillingCycle? BillingCycle { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } set { } }
        public string NewRelicPlanBillingCycle { get { throw null; } set { } }
        public string PlanDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilityUsageType? UsageType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NewRelicResourceMonitorResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult>
    {
        internal NewRelicResourceMonitorResult() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public string ReasonForMetricsStatus { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingLogsStatus? SendingLogs { get { throw null; } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicObservabilitySendingMetricsStatus? SendingMetrics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResourceMonitorResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicResubscribeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResubscribeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResubscribeProperties>
    {
        public NewRelicResubscribeProperties() { }
        public string OfferId { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicResubscribeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResubscribeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResubscribeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicResubscribeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResubscribeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResubscribeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicResubscribeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicSaaSDataDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSDataDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSDataDetails>
    {
        public NewRelicSaaSDataDetails() { }
        public Azure.Core.ResourceIdentifier SaaSResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSDataDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSDataDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSDataDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSDataDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSDataDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSDataDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSDataDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicSaaSResourceDetailsResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSResourceDetailsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSResourceDetailsResult>
    {
        public NewRelicSaaSResourceDetailsResult() { }
        public string SaasId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSResourceDetailsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSResourceDetailsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSResourceDetailsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSResourceDetailsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSResourceDetailsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSResourceDetailsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSaaSResourceDetailsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NewRelicSingleSignOnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties>
    {
        public NewRelicSingleSignOnProperties() { }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NewRelicSwitchBillingContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent>
    {
        public NewRelicSwitchBillingContent(string userEmail) { }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public Azure.ResourceManager.NewRelicObservability.Models.NewRelicPlanDetails PlanData { get { throw null; } set { } }
        public string UserEmail { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.NewRelicSwitchBillingContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerBillingEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity>
    {
        internal PartnerBillingEntity() { }
        public string OrganizationId { get { throw null; } }
        public string OrganizationName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.PartnerBillingEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResubscribeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties>
    {
        public ResubscribeProperties() { }
        public string OfferId { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NewRelicObservability.Models.ResubscribeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
