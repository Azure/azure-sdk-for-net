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
        public static Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreement> CreateOrUpdateMarketplaceAgreement(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Datadog.Models.DatadogAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreement>> CreateOrUpdateMarketplaceAgreementAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Datadog.Models.DatadogAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> GetDatadogMonitorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource GetDatadogMonitoredSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitorResource GetDatadogMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitorCollection GetDatadogMonitors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogSingleSignOnResource GetDatadogSingleSignOnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource GetDataMonitoringTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogAgreement> GetMarketplaceAgreements(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogAgreement> GetMarketplaceAgreementsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult> GetSubscriptionStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult>> GetSubscriptionStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult> GetSubscriptionStatuses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult> GetSubscriptionStatusesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatadogMonitorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DatadogMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DatadogMonitorResource>, System.Collections.IEnumerable
    {
        protected DatadogMonitorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Datadog.DatadogMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Datadog.DatadogMonitorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DatadogMonitorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorData>
    {
        public DatadogMonitorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogMonitoredSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource>, System.Collections.IEnumerable
    {
        protected DatadogMonitoredSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatadogMonitoredSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>
    {
        public DatadogMonitoredSubscriptionData() { }
        public Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogMonitoredSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatadogMonitoredSubscriptionResource() { }
        public virtual Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string configurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatadogMonitorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatadogMonitorResource() { }
        public virtual Azure.ResourceManager.Datadog.DatadogMonitorData Data { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult> GetBillingInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult>> GetBillingInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource> GetDatadogMonitoredSubscription(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource>> GetDatadogMonitoredSubscriptionAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionCollection GetDatadogMonitoredSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> GetDatadogSingleSignOn(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> GetDatadogSingleSignOnAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DatadogSingleSignOnCollection GetDatadogSingleSignOns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource> GetDataMonitoringTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource>> GetDataMonitoringTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DataMonitoringTagRuleCollection GetDataMonitoringTagRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogApiKey> GetDefaultKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogApiKey>> GetDefaultKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogHost> GetHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogHost> GetHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult> GetLinkedResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult> GetLinkedResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink> RefreshSetPasswordLink(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink>> RefreshSetPasswordLinkAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitorResource> ResubscribeOrganization(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitorResource>> ResubscribeOrganizationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetDefaultKey(Azure.ResourceManager.Datadog.Models.DatadogApiKey body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetDefaultKeyAsync(Azure.ResourceManager.Datadog.Models.DatadogApiKey body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.DatadogMonitorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogMonitorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogMonitorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogMonitorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogMonitorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatadogSingleSignOnCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>, System.Collections.IEnumerable
    {
        protected DatadogSingleSignOnCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Datadog.DatadogSingleSignOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Datadog.DatadogSingleSignOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DatadogSingleSignOnData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>
    {
        public DatadogSingleSignOnData() { }
        public Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogSingleSignOnData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogSingleSignOnData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogSingleSignOnResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatadogSingleSignOnResource() { }
        public virtual Azure.ResourceManager.Datadog.DatadogSingleSignOnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.DatadogSingleSignOnData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DatadogSingleSignOnData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DatadogSingleSignOnData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.DatadogSingleSignOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DatadogSingleSignOnResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.DatadogSingleSignOnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataMonitoringTagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource>, System.Collections.IEnumerable
    {
        protected DataMonitoringTagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Datadog.DataMonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Datadog.DataMonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource> GetIfExists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource>> GetIfExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataMonitoringTagRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>
    {
        public DataMonitoringTagRuleData() { }
        public Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DataMonitoringTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DataMonitoringTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataMonitoringTagRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataMonitoringTagRuleResource() { }
        public virtual Azure.ResourceManager.Datadog.DataMonitoringTagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Datadog.DataMonitoringTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.DataMonitoringTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.DataMonitoringTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.DataMonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Datadog.DataMonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Datadog.Mocking
{
    public partial class MockableDatadogArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDatadogArmClient() { }
        public virtual Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionResource GetDatadogMonitoredSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DatadogMonitorResource GetDatadogMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DatadogSingleSignOnResource GetDatadogSingleSignOnResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DataMonitoringTagRuleResource GetDataMonitoringTagRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDatadogResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatadogResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitor(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.DatadogMonitorResource>> GetDatadogMonitorAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Datadog.DatadogMonitorCollection GetDatadogMonitors() { throw null; }
    }
    public partial class MockableDatadogSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatadogSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreement> CreateOrUpdateMarketplaceAgreement(Azure.ResourceManager.Datadog.Models.DatadogAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogAgreement>> CreateOrUpdateMarketplaceAgreementAsync(Azure.ResourceManager.Datadog.Models.DatadogAgreement body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.DatadogMonitorResource> GetDatadogMonitorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogAgreement> GetMarketplaceAgreements(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogAgreement> GetMarketplaceAgreementsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult> GetSubscriptionStatus(string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult>> GetSubscriptionStatusAsync(string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult> GetSubscriptionStatuses(string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult> GetSubscriptionStatusesAsync(string datadogOrganizationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Datadog.Models
{
    public static partial class ArmDatadogModelFactory
    {
        public static Azure.ResourceManager.Datadog.Models.DatadogAgreement DatadogAgreement(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogBillingInfoResult DatadogBillingInfoResult(Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo marketplaceSaasInfo = null, Azure.ResourceManager.Datadog.Models.PartnerBillingEntity partnerBillingEntity = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogHost DatadogHost(string name = null, System.Collections.Generic.IEnumerable<string> aliases = null, System.Collections.Generic.IEnumerable<string> apps = null, Azure.ResourceManager.Datadog.Models.DatadogHostMetadata meta = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogHostMetadata DatadogHostMetadata(string agentVersion = null, Azure.ResourceManager.Datadog.Models.DatadogInstallMethod installMethod = null, string logsAgentTransport = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogInstallMethod DatadogInstallMethod(string tool = null, string toolVersion = null, string installerVersion = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult DatadogLinkedResourceResult(Azure.Core.ResourceIdentifier id = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitorData DatadogMonitorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties properties = null, string skuName = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult DatadogMonitoredResourceResult(Azure.Core.ResourceIdentifier id = null, bool? isSendingMetricsEnabled = default(bool?), string reasonForMetricsStatus = null, bool? isSendingLogsEnabled = default(bool?), string reasonForLogsStatus = null) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogMonitoredSubscriptionData DatadogMonitoredSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties DatadogMonitorProperties(Azure.ResourceManager.Datadog.Models.DatadogProvisioningState? provisioningState = default(Azure.ResourceManager.Datadog.Models.DatadogProvisioningState?), Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus? monitoringStatus = default(Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus?), Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus? marketplaceSubscriptionStatus = default(Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus?), Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties datadogOrganizationProperties = null, Azure.ResourceManager.Datadog.Models.DatadogUserInfo userInfo = null, Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory?), int? liftrResourcePreference = default(int?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogSetPasswordLink DatadogSetPasswordLink(string setPasswordLink = null) { throw null; }
        public static Azure.ResourceManager.Datadog.DatadogSingleSignOnData DatadogSingleSignOnData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties DatadogSingleSignOnProperties(Azure.ResourceManager.Datadog.Models.DatadogProvisioningState? provisioningState = default(Azure.ResourceManager.Datadog.Models.DatadogProvisioningState?), Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState? singleSignOnState = default(Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState?), string enterpriseAppId = null, System.Uri singleSignOnUri = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties DatadogSubscriptionStatusProperties(string name = null, bool? isCreationSupported = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult DatadogSubscriptionStatusResult(Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.DataMonitoringTagRuleData DataMonitoringTagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MarketplaceSaaSInfo MarketplaceSaaSInfo(string marketplaceSubscriptionId = null, string marketplaceName = null, string marketplaceStatus = null, string billedAzureSubscriptionId = null, bool? isSubscribed = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties MonitoringTagRuleProperties(Azure.ResourceManager.Datadog.Models.DatadogProvisioningState? provisioningState = default(Azure.ResourceManager.Datadog.Models.DatadogProvisioningState?), Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules logRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag> metricRulesFilteringTags = null, Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules agentRules = null, bool? isAutomutingEnabled = default(bool?), bool? isCustomMetricsEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.PartnerBillingEntity PartnerBillingEntity(string id = null, string name = null, System.Uri partnerEntityUri = null) { throw null; }
    }
    public partial class DatadogAgreement : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreement>
    {
        public DatadogAgreement() { }
        public Azure.ResourceManager.Datadog.Models.DatadogAgreementProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogAgreement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogAgreement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogAgreement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogAgreement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatadogLiftrResourceCategory : System.IEquatable<Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatadogLiftrResourceCategory(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory left, Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory left, Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatadogLinkedResourceResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult>
    {
        internal DatadogLinkedResourceResult() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogLinkedResourceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogMonitorAgentRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules>
    {
        public DatadogMonitorAgentRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag> FilteringTags { get { throw null; } }
        public bool? IsAgentMonitoringEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogMonitoredResourceResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult>
    {
        internal DatadogMonitoredResourceResult() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public bool? IsSendingLogsEnabled { get { throw null; } }
        public bool? IsSendingMetricsEnabled { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public string ReasonForMetricsStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredResourceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogMonitoredSubscriptionItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredSubscriptionItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredSubscriptionItem>
    {
        public DatadogMonitoredSubscriptionItem() { }
        public string Error { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus? Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties TagRules { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitoredSubscriptionItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredSubscriptionItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredSubscriptionItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitoredSubscriptionItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredSubscriptionItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredSubscriptionItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitoredSubscriptionItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogMonitorFilteringTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag>
    {
        public DatadogMonitorFilteringTag() { }
        public Azure.ResourceManager.Datadog.Models.DatadogMonitorTagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatadogMonitoringStatus : System.IEquatable<Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatadogMonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus left, Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus left, Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatadogMonitorLogRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules>
    {
        public DatadogMonitorLogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag> FilteringTags { get { throw null; } }
        public bool? IsAadLogsSent { get { throw null; } set { } }
        public bool? IsResourceLogsSent { get { throw null; } set { } }
        public bool? IsSubscriptionLogsSent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogMonitorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch>
    {
        public DatadogMonitorPatch() { }
        public Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatchProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogMonitorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties>
    {
        public DatadogMonitorProperties() { }
        public Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties DatadogOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DatadogLiftrResourceCategory? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DatadogProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DatadogUserInfo UserInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogMonitorResourcePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatchProperties>
    {
        public DatadogMonitorResourcePatchProperties() { }
        public bool? IsCspm { get { throw null; } set { } }
        public bool? IsResourceCollection { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DatadogMonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogMonitorResourcePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatadogMonitorStatus : System.IEquatable<Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatadogMonitorStatus(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus left, Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus left, Azure.ResourceManager.Datadog.Models.DatadogMonitorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatadogMonitorTagAction : System.IEquatable<Azure.ResourceManager.Datadog.Models.DatadogMonitorTagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatadogMonitorTagAction(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogMonitorTagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogMonitorTagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DatadogMonitorTagAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DatadogMonitorTagAction left, Azure.ResourceManager.Datadog.Models.DatadogMonitorTagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DatadogMonitorTagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DatadogMonitorTagAction left, Azure.ResourceManager.Datadog.Models.DatadogMonitorTagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatadogOperation : System.IEquatable<Azure.ResourceManager.Datadog.Models.DatadogOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatadogOperation(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogOperation Active { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogOperation AddBegin { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogOperation AddComplete { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogOperation DeleteBegin { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogOperation DeleteComplete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DatadogOperation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DatadogOperation left, Azure.ResourceManager.Datadog.Models.DatadogOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DatadogOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DatadogOperation left, Azure.ResourceManager.Datadog.Models.DatadogOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatadogOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogOrganizationProperties>
    {
        public DatadogOrganizationProperties() { }
        public string ApiKey { get { throw null; } set { } }
        public string ApplicationKey { get { throw null; } set { } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public bool? IsCspm { get { throw null; } set { } }
        public bool? IsResourceCollection { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatadogProvisioningState : System.IEquatable<Azure.ResourceManager.Datadog.Models.DatadogProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatadogProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DatadogProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DatadogProvisioningState left, Azure.ResourceManager.Datadog.Models.DatadogProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DatadogProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DatadogProvisioningState left, Azure.ResourceManager.Datadog.Models.DatadogProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.Datadog.Models.DatadogProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatadogSingleSignOnState : System.IEquatable<Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatadogSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState Existing { get { throw null; } }
        public static Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState left, Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState left, Azure.ResourceManager.Datadog.Models.DatadogSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatadogSubscriptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties>
    {
        public DatadogSubscriptionProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Datadog.Models.DatadogMonitoredSubscriptionItem> MonitoredSubscriptionList { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DatadogOperation? Operation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogSubscriptionStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties>
    {
        internal DatadogSubscriptionStatusProperties() { }
        public bool? IsCreationSupported { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogSubscriptionStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult>
    {
        internal DatadogSubscriptionStatusResult() { }
        public Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogSubscriptionStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatadogUserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogUserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogUserInfo>
    {
        public DatadogUserInfo() { }
        public string EmailAddress { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogUserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogUserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.DatadogUserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.DatadogUserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogUserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogUserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.DatadogUserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Datadog.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitoringTagRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties>
    {
        public MonitoringTagRuleProperties() { }
        public Azure.ResourceManager.Datadog.Models.DatadogMonitorAgentRules AgentRules { get { throw null; } set { } }
        public bool? IsAutomutingEnabled { get { throw null; } set { } }
        public bool? IsCustomMetricsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Datadog.Models.DatadogMonitorLogRules LogRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Datadog.Models.DatadogMonitorFilteringTag> MetricRulesFilteringTags { get { throw null; } }
        public Azure.ResourceManager.Datadog.Models.DatadogProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.MonitoringTagRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResubscribeOrganizationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent>
    {
        public ResubscribeOrganizationContent() { }
        public string AzureSubscriptionId { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Datadog.Models.ResubscribeOrganizationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
