namespace Azure.ResourceManager.TenantActivityLogAlerts
{
    public partial class AzureResourceManagerTenantActivityLogAlertsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerTenantActivityLogAlertsContext() { }
        public static Azure.ResourceManager.TenantActivityLogAlerts.AzureResourceManagerTenantActivityLogAlertsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class TenantActivityLogAlertResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantActivityLogAlertResource() { }
        public virtual Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string managementGroupName, string alertRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> Update(Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> UpdateAsync(Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantActivityLogAlertResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>, System.Collections.IEnumerable
    {
        protected TenantActivityLogAlertResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertRuleName, Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertRuleName, Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> Get(string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> GetAsync(string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetIfExists(string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> GetIfExistsAsync(string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantActivityLogAlertResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>
    {
        public TenantActivityLogAlertResourceData(System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition> conditionAllOf) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup> ActionsActionGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition> ConditionAllOf { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TenantScope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class TenantActivityLogAlertsExtensions
    {
        public static Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource GetTenantActivityLogAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlertResource(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> GetTenantActivityLogAlertResourceAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceCollection GetTenantActivityLogAlertResources(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlertResources(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlertResourcesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.TenantActivityLogAlerts.Mocking
{
    public partial class MockableTenantActivityLogAlertsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableTenantActivityLogAlertsArmClient() { }
        public virtual Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource GetTenantActivityLogAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableTenantActivityLogAlertsManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTenantActivityLogAlertsManagementGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlertResource(string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> GetTenantActivityLogAlertResourceAsync(string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceCollection GetTenantActivityLogAlertResources() { throw null; }
    }
    public partial class MockableTenantActivityLogAlertsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTenantActivityLogAlertsTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlertResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlertResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.TenantActivityLogAlerts.Models
{
    public partial class ActionGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup>
    {
        public ActionGroup(string actionGroupId) { }
        public string ActionGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ActionProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> WebhookProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertRuleAnyOfOrLeafCondition : Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition>
    {
        public AlertRuleAnyOfOrLeafCondition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition> AnyOf { get { throw null; } }
        protected override Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertRuleLeafCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition>
    {
        public AlertRuleLeafCondition() { }
        public System.Collections.Generic.IList<string> ContainsAny { get { throw null; } }
        public string EqualTo { get { throw null; } set { } }
        public string Field { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmTenantActivityLogAlertsModelFactory
    {
        public static Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup ActionGroup(string actionGroupId = null, System.Collections.Generic.IDictionary<string, string> webhookProperties = null, System.Collections.Generic.IDictionary<string, string> actionProperties = null) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition AlertRuleAnyOfOrLeafCondition(string field = null, string equalTo = null, System.Collections.Generic.IEnumerable<string> containsAny = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition> anyOf = null) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleLeafCondition AlertRuleLeafCondition(string field = null, string equalTo = null, System.Collections.Generic.IEnumerable<string> containsAny = null) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResourceData TenantActivityLogAlertResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string tenantScope = null, System.Collections.Generic.IEnumerable<string> scopes = null, bool? enabled = default(bool?), string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.Models.AlertRuleAnyOfOrLeafCondition> conditionAllOf = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.Models.ActionGroup> actionsActionGroups = null, System.Collections.Generic.IDictionary<string, string> tags = null, string location = null) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch TenantActivityLogAlertResourcePatch(System.Collections.Generic.IDictionary<string, string> tags = null, bool? enabled = default(bool?)) { throw null; }
    }
    public partial class TenantActivityLogAlertResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch>
    {
        public TenantActivityLogAlertResourcePatch() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
