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
        public static Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent> CreateOrUpdateMarketplaceAgreement(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent>> CreateOrUpdateMarketplaceAgreementAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult> GetCreationSupported(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult>> GetCreationSupportedAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult> GetCreationSupporteds(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult> GetCreationSupportedsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitorResource GetDatadogMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> GetDatadogMonitorResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitorResourceCollection GetDatadogMonitorResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogSingleSignOnResource GetDatadogSingleSignOnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent> GetMarketplaceAgreements(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent> GetMarketplaceAgreementsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource GetMonitoredSubscriptionPropertyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent> GetApiKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent> GetApiKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult> GetBillingInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult>> GetBillingInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> GetDatadogSingleSignOnResource(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> GetDatadogSingleSignOnResourceAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceCollection GetDatadogSingleSignOnResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent> GetDefaultKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent>> GetDefaultKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogHost> GetHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogHost> GetHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.LinkedInfo> GetLinkedResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.LinkedInfo> GetLinkedResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyCollection GetMonitoredSubscriptionProperties() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource> GetMonitoredSubscriptionProperty(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource>> GetMonitoredSubscriptionPropertyAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.MonitoringTagRuleResource> GetMonitoringTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.MonitoringTagRuleResource>> GetMonitoringTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.MonitoringTagRuleCollection GetMonitoringTagRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink> RefreshSetPasswordLink(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink>> RefreshSetPasswordLinkAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetDefaultKey(Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetDefaultKeyAsync(Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class MonitoredSubscriptionPropertyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource>, System.Collections.IEnumerable
    {
        protected MonitoredSubscriptionPropertyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitoredSubscriptionPropertyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>
    {
        public MonitoredSubscriptionPropertyData() { }
        public Azure.ResourceManager.Datadog.Models.SubscriptionList Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoredSubscriptionPropertyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitoredSubscriptionPropertyResource() { }
        public virtual Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string configurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyResource GetMonitoredSubscriptionPropertyResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent> CreateOrUpdateMarketplaceAgreement(Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent>> CreateOrUpdateMarketplaceAgreementAsync(Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult> GetCreationSupported(string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult>> GetCreationSupportedAsync(string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult> GetCreationSupporteds(string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult> GetCreationSupportedsAsync(string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent> GetMarketplaceAgreements(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent> GetMarketplaceAgreementsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Datadog.Models
{
    public static partial class ArmDatadogModelFactory
    {
        public static Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties CreateResourceSupportedProperties(string name = null, bool? isCreationSupported = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent DatadogAgreementResourceContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult DatadogBillingInfoResult(Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo marketplaceSaasInfo = null, Azure.ResourceManager.Datadog.Models.PartnerBillingEntity partnerBillingEntity = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult DatadogCreateResourceSupportedResult(Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogHost DatadogHost(string name = null, System.Collections.Generic.IEnumerable<string> aliases = null, System.Collections.Generic.IEnumerable<string> apps = null, Azure.ResourceManager.Datadog.Models.DatadogHostMetadata meta = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogHostMetadata DatadogHostMetadata(string agentVersion = null, Azure.ResourceManager.Datadog.Models.DatadogInstallMethod installMethod = null, string logsAgentTransport = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogInstallMethod DatadogInstallMethod(string tool = null, string toolVersion = null, string installerVersion = null) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitorResourceData DatadogMonitorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Datadog.Models.MonitorProperties properties = null, string skuName = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink DatadogSetPasswordLink(string setPasswordLink = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties DatadogSingleSignOnProperties(Azure.ResourceManager.Datadog.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Datadog.Models.ProvisioningState?), Azure.ResourceManager.Datadog.Models.SingleSignOnState? singleSignOnState = default(Azure.ResourceManager.Datadog.Models.SingleSignOnState?), string enterpriseAppId = null, System.Uri singleSignOnUri = null) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogSingleSignOnResourceData DatadogSingleSignOnResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.LinkedInfo LinkedInfo(string id = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo MarketplaceSaaSInfo(string marketplaceSubscriptionId = null, string marketplaceName = null, string marketplaceStatus = null, string billedAzureSubscriptionId = null, bool? isSubscribed = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MonitoredResourceContent MonitoredResourceContent(string id = null, bool? isSendingMetrics = default(bool?), string reasonForMetricsStatus = null, bool? isSendingLogs = default(bool?), string reasonForLogsStatus = null) { throw null; }
        public static Azure.ResourceManager.Datadog.MonitoredSubscriptionPropertyData MonitoredSubscriptionPropertyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.SubscriptionList properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.MonitoringTagRuleData MonitoringTagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties MonitoringTagRulesProperties(Azure.ResourceManager.Datadog.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Datadog.Models.ProvisioningState?), Azure.ResourceManager.Datadog.Models.LogRules logRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.FilteringTag> metricRulesFilteringTags = null, bool? isAutomuting = default(bool?), bool? isCustomMetrics = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MonitorProperties MonitorProperties(Azure.ResourceManager.Datadog.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Datadog.Models.ProvisioningState?), Azure.ResourceManager.Datadog.Models.MonitoringStatus? monitoringStatus = default(Azure.ResourceManager.Datadog.Models.MonitoringStatus?), Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus?), Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties datadogOrganizationProperties = null, Azure.ResourceManager.Datadog.Models.UserInfo userInfo = null, Azure.ResourceManager.Datadog.Models.LiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.Datadog.Models.LiftrResourceCategory?), int? liftrResourcePreference = default(int?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.PartnerBillingEntity PartnerBillingEntity(string id = null, string name = null, System.Uri partnerEntityUri = null) { throw null; }
    }
    public partial class CreateResourceSupportedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties>
    {
        internal CreateResourceSupportedProperties() { }
        public bool? IsCreationSupported { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogAgreementProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties>
    {
        public DatadogAgreementProperties() { }
        public bool? IsAccepted { get { throw null; } set { } }
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
    public partial class DatadogAgreementResourceContent : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent>
    {
        public DatadogAgreementResourceContent() { }
        public Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreementResourceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogApiKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent>
    {
        public DatadogApiKeyContent(string key) { }
        public string Created { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogApiKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogBillingInfoResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult>
    {
        internal DatadogBillingInfoResult() { }
        public Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo MarketplaceSaasInfo { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.PartnerBillingEntity PartnerBillingEntity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogCreateResourceSupportedResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult>
    {
        internal DatadogCreateResourceSupportedResult() { }
        public Azure.ResourceManager.Datadog.Models.CreateResourceSupportedProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogCreateResourceSupportedResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Datadog.Models.MonitorUpdateProperties Properties { get { throw null; } set { } }
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
        public string Id { get { throw null; } set { } }
        public bool? IsCspm { get { throw null; } set { } }
        public string LinkingAuthCode { get { throw null; } set { } }
        public string LinkingClientId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
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
    public partial class LinkedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LinkedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LinkedInfo>
    {
        internal LinkedInfo() { }
        public string Id { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.LinkedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LinkedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LinkedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.LinkedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LinkedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LinkedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LinkedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LogRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LogRules>
    {
        public LogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Datadog.Models.FilteringTag> FilteringTags { get { throw null; } }
        public bool? IsSendAadLogs { get { throw null; } set { } }
        public bool? IsSendResourceLogs { get { throw null; } set { } }
        public bool? IsSendSubscriptionLogs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.LogRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LogRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.LogRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.LogRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LogRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LogRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.LogRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceSaaSInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo>
    {
        internal MarketplaceSaaSInfo() { }
        public string BilledAzureSubscriptionId { get { throw null; } }
        public bool? IsSubscribed { get { throw null; } }
        public string MarketplaceName { get { throw null; } }
        public string MarketplaceStatus { get { throw null; } }
        public string MarketplaceSubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public bool? IsSendingLogs { get { throw null; } }
        public bool? IsSendingMetrics { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public string ReasonForMetricsStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitoredResourceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitoredResourceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredResourceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoredStatus : System.IEquatable<Azure.ResourceManager.Datadog.Models.MonitoredStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoredStatus(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MonitoredStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.MonitoredStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.MonitoredStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.MonitoredStatus InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.MonitoredStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.MonitoredStatus left, Azure.ResourceManager.Datadog.Models.MonitoredStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.MonitoredStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.MonitoredStatus left, Azure.ResourceManager.Datadog.Models.MonitoredStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitoredSubscription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoredSubscription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredSubscription>
    {
        public MonitoredSubscription() { }
        public string Error { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.MonitoredStatus? Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.MonitoringTagRulesProperties TagRules { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitoredSubscription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoredSubscription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoredSubscription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitoredSubscription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredSubscription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredSubscription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoredSubscription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public bool? IsAutomuting { get { throw null; } set { } }
        public bool? IsCustomMetrics { get { throw null; } set { } }
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
    public partial class MonitorUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitorUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitorUpdateProperties>
    {
        public MonitorUpdateProperties() { }
        public bool? IsCspm { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.MonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitorUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitorUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitorUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitorUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitorUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitorUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitorUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationData : System.IEquatable<Azure.ResourceManager.Datadog.Models.OperationData>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationData(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.OperationData Active { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.OperationData AddBegin { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.OperationData AddComplete { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.OperationData DeleteBegin { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.OperationData DeleteComplete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.OperationData other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.OperationData left, Azure.ResourceManager.Datadog.Models.OperationData right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.OperationData (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.OperationData left, Azure.ResourceManager.Datadog.Models.OperationData right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerBillingEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.PartnerBillingEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PartnerBillingEntity>
    {
        internal PartnerBillingEntity() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Uri PartnerEntityUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.PartnerBillingEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.PartnerBillingEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.PartnerBillingEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.PartnerBillingEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PartnerBillingEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PartnerBillingEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.PartnerBillingEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SubscriptionList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SubscriptionList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SubscriptionList>
    {
        public SubscriptionList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Datadog.Models.MonitoredSubscription> MonitoredSubscriptionList { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.OperationData? Operation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SubscriptionList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SubscriptionList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.SubscriptionList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.SubscriptionList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SubscriptionList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SubscriptionList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.SubscriptionList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
