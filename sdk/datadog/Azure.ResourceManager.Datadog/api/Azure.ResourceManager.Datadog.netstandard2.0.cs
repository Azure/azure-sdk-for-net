namespace Azure.ResourceManager.Datadog
{
    public partial class AzureResourceManagerDatadogContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDatadogContext() { }
        public static Azure.ResourceManager.Datadog.AzureResourceManagerDatadogContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DatadogExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties> CreateOrUpdateMarketplaceAgreement(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties>> CreateOrUpdateMarketplaceAgreementAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitorResource GetDatadogMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> GetDatadogMonitorResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitorResourceCollection GetDatadogMonitorResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogSingleSignOnResource GetDatadogSingleSignOnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties> GetMarketplaceAgreements(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties> GetMarketplaceAgreementsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.MonitoringTagRuleResource GetMonitoringTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DatadogMonitorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatadogMonitorResource() { }
        public virtual Azure.ResourceManager.Datadog.DatadogMonitorResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogApiKey> GetApiKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogApiKey> GetApiKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> GetDatadogSingleSignOnResource(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> GetDatadogSingleSignOnResourceAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceCollection GetDatadogSingleSignOnResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogApiKey> GetDefaultKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogApiKey>> GetDefaultKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogHost> GetHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogHost> GetHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetLinkedResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetLinkedResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> GetMonitoringTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>> GetMonitoringTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.MonitoringTagRuleCollection GetMonitoringTagRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink> RefreshSetPasswordLink(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink>> RefreshSetPasswordLinkAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetDefaultKey(Azure.ResourceManager.Datadog.Models.DatadogApiKey body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetDefaultKeyAsync(Azure.ResourceManager.Datadog.Models.DatadogApiKey body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.DatadogMonitorResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogMonitorResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatadogMonitorResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DatadogMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DatadogMonitorResource>, System.Collections.IEnumerable
    {
        protected DatadogMonitorResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Datadog.DatadogMonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Datadog.DatadogMonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetIfExists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Datadog.DatadogMonitorResource>> GetIfExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Datadog.DatadogMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DatadogMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Datadog.DatadogMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DatadogMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatadogMonitorResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>
    {
        public DatadogMonitorResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.MonitorProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogMonitorResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogMonitorResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogSingleSignOnResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatadogSingleSignOnResource() { }
        public virtual Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatadogSingleSignOnResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>, System.Collections.IEnumerable
    {
        protected DatadogSingleSignOnResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatadogSingleSignOnResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>
    {
        public DatadogSingleSignOnResourceData() { }
        public Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoringTagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>, System.Collections.IEnumerable
    {
        protected MonitoringTagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Datadog.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Datadog.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> GetIfExists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>> GetIfExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitoringTagRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>
    {
        public MonitoringTagRuleData() { }
        public Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.MonitoringTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.MonitoringTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoringTagRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitoringTagRuleResource() { }
        public virtual Azure.ResourceManager.Datadog.MonitoringTagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.MonitoringTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.MonitoringTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoringTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Datadog.Mocking
{
    public partial class MockableDatadogArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDatadogArmClient() { }
        public virtual Azure.ResourceManager.Datadog.DatadogMonitorResource GetDatadogMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DatadogSingleSignOnResource GetDatadogSingleSignOnResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Datadog.MonitoringTagRuleResource GetMonitoringTagRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDatadogResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatadogResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResource(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> GetDatadogMonitorResourceAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DatadogMonitorResourceCollection GetDatadogMonitorResources() { throw null; }
    }
    public partial class MockableDatadogSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatadogSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties> CreateOrUpdateMarketplaceAgreement(Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties>> CreateOrUpdateMarketplaceAgreementAsync(Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties> GetMarketplaceAgreements(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties> GetMarketplaceAgreementsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Datadog.Models
{
    public static partial class ArmDatadogModelFactory
    {
        public static Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties DatadogAgreementResourceProperties(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogHost DatadogHost(string name = null, System.Collections.Generic.IEnumerable<string> aliases = null, System.Collections.Generic.IEnumerable<string> apps = null, Azure.ResourceManager.Datadog.Models.DatadogHostMetadata meta = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogHostMetadata DatadogHostMetadata(string agentVersion = null, Azure.ResourceManager.Datadog.Models.DatadogInstallMethod installMethod = null, string logsAgentTransport = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogInstallMethod DatadogInstallMethod(string tool = null, string toolVersion = null, string installerVersion = null) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitorResourceData DatadogMonitorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string skuName = null, Azure.ResourceManager.Datadog.Models.MonitorProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties DatadogOrganizationProperties(string name = null, string id = null, string linkingAuthCode = null, string linkingClientId = null, System.Uri redirectUri = null, string apiKey = null, string applicationKey = null, string enterpriseAppId = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink DatadogSetPasswordLink(string setPasswordLink = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties DatadogSingleSignOnProperties(Azure.ResourceManager.Datadog.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Datadog.Models.ProvisioningState?), Azure.ResourceManager.Datadog.Models.SingleSignOnState? singleSignOnState = default(Azure.ResourceManager.Datadog.Models.SingleSignOnState?), string enterpriseAppId = null, System.Uri singleSignOnUri = null) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData DatadogSingleSignOnResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MonitoredResourceContent MonitoredResourceContent(string id = null, bool? sendingMetrics = default(bool?), string reasonForMetricsStatus = null, bool? sendingLogs = default(bool?), string reasonForLogsStatus = null) { throw null; }
        public static Azure.ResourceManager.Datadog.MonitoringTagRuleData MonitoringTagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties MonitoringTagRulesProperties(Azure.ResourceManager.Datadog.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Datadog.Models.ProvisioningState?), Azure.ResourceManager.Datadog.Models.LogRules logRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.FilteringTag> metricRulesFilteringTags = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MonitorProperties MonitorProperties(Azure.ResourceManager.Datadog.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Datadog.Models.ProvisioningState?), Azure.ResourceManager.Datadog.Models.MonitoringStatus? monitoringStatus = default(Azure.ResourceManager.Datadog.Models.MonitoringStatus?), Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus?), Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties datadogOrganizationProperties = null, Azure.ResourceManager.Datadog.Models.UserInfo userInfo = null, Azure.ResourceManager.Datadog.Models.LiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.Datadog.Models.LiftrResourceCategory?), int? liftrResourcePreference = default(int?)) { throw null; }
    }
    public partial class DatadogAgreementProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties>
    {
        public DatadogAgreementProperties() { }
        public bool? Accepted { get { throw null; } set { } }
        public string LicenseTextLink { get { throw null; } set { } }
        public string Plan { get { throw null; } set { } }
        public string PrivacyPolicyLink { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.DateTimeOffset? RetrieveDatetime { get { throw null; } set { } }
        public string Signature { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogAgreementResourceProperties : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties>
    {
        public DatadogAgreementResourceProperties() { }
        public Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogApiKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogApiKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogApiKey>
    {
        public DatadogApiKey(string key) { }
        public string Created { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogApiKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogApiKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogApiKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogApiKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogApiKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogApiKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogApiKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogHost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogHost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogHost>
    {
        internal DatadogHost() { }
        public System.Collections.Generic.IReadOnlyList<string> Aliases { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Apps { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DatadogHostMetadata Meta { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogHost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogHost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogHost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogHost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogHost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogHost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogHost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogHostMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogHostMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogHostMetadata>
    {
        internal DatadogHostMetadata() { }
        public string AgentVersion { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DatadogInstallMethod InstallMethod { get { throw null; } }
        public string LogsAgentTransport { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogHostMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogHostMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogHostMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogHostMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogHostMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogHostMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogHostMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogInstallMethod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogInstallMethod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogInstallMethod>
    {
        internal DatadogInstallMethod() { }
        public string InstallerVersion { get { throw null; } }
        public string Tool { get { throw null; } }
        public string ToolVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogInstallMethod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogInstallMethod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogInstallMethod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogInstallMethod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogInstallMethod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogInstallMethod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogInstallMethod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogMonitorResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch>
    {
        public DatadogMonitorResourcePatch() { }
        public Azure.ResourceManager.Datadog.Models.MonitoringStatus? MonitorUpdateMonitoringStatus { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties>
    {
        public DatadogOrganizationProperties() { }
        public string ApiKey { get { throw null; } set { } }
        public string ApplicationKey { get { throw null; } set { } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string LinkingAuthCode { get { throw null; } set { } }
        public string LinkingClientId { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Uri RedirectUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogSetPasswordLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink>
    {
        internal DatadogSetPasswordLink() { }
        public string SetPasswordLink { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogSingleSignOnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>
    {
        public DatadogSingleSignOnProperties() { }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.SingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FilteringTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.FilteringTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FilteringTag>
    {
        public FilteringTag() { }
        public Azure.ResourceManager.Datadog.Models.TagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.FilteringTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.FilteringTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.FilteringTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.FilteringTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FilteringTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FilteringTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.FilteringTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiftrResourceCategory : System.IEquatable<Azure.ResourceManager.Datadog.Models.LiftrResourceCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiftrResourceCategory(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.LiftrResourceCategory MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.LiftrResourceCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.LiftrResourceCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.LiftrResourceCategory left, Azure.ResourceManager.Datadog.Models.LiftrResourceCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.LiftrResourceCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.LiftrResourceCategory left, Azure.ResourceManager.Datadog.Models.LiftrResourceCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LogRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LogRules>
    {
        public LogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Datadog.Models.FilteringTag> FilteringTags { get { throw null; } }
        public bool? SendAadLogs { get { throw null; } set { } }
        public bool? SendResourceLogs { get { throw null; } set { } }
        public bool? SendSubscriptionLogs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.LogRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LogRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LogRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.LogRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LogRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LogRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LogRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitoredResourceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>
    {
        internal MonitoredResourceContent() { }
        public string Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public string ReasonForMetricsStatus { get { throw null; } }
        public bool? SendingLogs { get { throw null; } }
        public bool? SendingMetrics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitoredResourceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitoredResourceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringStatus : System.IEquatable<Azure.ResourceManager.Datadog.Models.MonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.MonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.MonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.MonitoringStatus left, Azure.ResourceManager.Datadog.Models.MonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.MonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.MonitoringStatus left, Azure.ResourceManager.Datadog.Models.MonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitoringTagRulesProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties>
    {
        public MonitoringTagRulesProperties() { }
        public Azure.ResourceManager.Datadog.Models.LogRules LogRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Datadog.Models.FilteringTag> MetricRulesFilteringTags { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitorProperties>
    {
        public MonitorProperties() { }
        public Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties DatadogOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.LiftrResourceCategory? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.MonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.UserInfo UserInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Datadog.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.ProvisioningState left, Azure.ResourceManager.Datadog.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.ProvisioningState left, Azure.ResourceManager.Datadog.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnState : System.IEquatable<Azure.ResourceManager.Datadog.Models.SingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.SingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.SingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.SingleSignOnState Existing { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.SingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.SingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.SingleSignOnState left, Azure.ResourceManager.Datadog.Models.SingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.SingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.SingleSignOnState left, Azure.ResourceManager.Datadog.Models.SingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagAction : System.IEquatable<Azure.ResourceManager.Datadog.Models.TagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagAction(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.TagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.TagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.TagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.TagAction left, Azure.ResourceManager.Datadog.Models.TagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.TagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.TagAction left, Azure.ResourceManager.Datadog.Models.TagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.UserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserInfo>
    {
        public UserInfo() { }
        public string EmailAddress { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.UserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.UserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.UserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.UserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.UserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
