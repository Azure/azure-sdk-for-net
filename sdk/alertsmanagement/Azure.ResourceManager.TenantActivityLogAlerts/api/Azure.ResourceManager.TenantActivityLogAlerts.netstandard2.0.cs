namespace Azure.ResourceManager.TenantActivityLogAlerts
{
    public partial class AzureResourceManagerTenantActivityLogAlertsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerTenantActivityLogAlertsContext() { }
        public static Azure.ResourceManager.TenantActivityLogAlerts.AzureResourceManagerTenantActivityLogAlertsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class TenantActivityLogAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>, System.Collections.IEnumerable
    {
        protected TenantActivityLogAlertCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertRuleName, Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertRuleName, Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class TenantActivityLogAlertData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>
    {
        public TenantActivityLogAlertData(System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition> conditionAllOf) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup> ActionsActionGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition> ConditionAllOf { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TenantScope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TenantActivityLogAlertResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantActivityLogAlertResource() { }
        public virtual Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData Data { get { throw null; } }
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
        Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> Update(Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> UpdateAsync(Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class TenantActivityLogAlertsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlert(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> GetTenantActivityLogAlertAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource GetTenantActivityLogAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertCollection GetTenantActivityLogAlerts(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlerts(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlertsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlert(string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource>> GetTenantActivityLogAlertAsync(string alertRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertCollection GetTenantActivityLogAlerts() { throw null; }
    }
    public partial class MockableTenantActivityLogAlertsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTenantActivityLogAlertsTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlerts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertResource> GetTenantActivityLogAlertsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.TenantActivityLogAlerts.Models
{
    public static partial class ArmTenantActivityLogAlertsModelFactory
    {
        public static Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup TenantActivityLogAlertActionGroup(Azure.Core.ResourceIdentifier actionGroupId = null, System.Collections.Generic.IDictionary<string, string> webhookProperties = null, System.Collections.Generic.IDictionary<string, string> actionProperties = null) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition TenantActivityLogAlertAnyOfOrLeafCondition(string field = null, string equalTo = null, System.Collections.Generic.IEnumerable<string> containsAny = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition> anyOf = null) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.TenantActivityLogAlertData TenantActivityLogAlertData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string tenantScope = null, System.Collections.Generic.IEnumerable<string> scopes = null, bool? isEnabled = default(bool?), string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition> conditionAllOf = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup> actionsActionGroups = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition TenantActivityLogAlertLeafCondition(string field = null, string equalTo = null, System.Collections.Generic.IEnumerable<string> containsAny = null) { throw null; }
        public static Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch TenantActivityLogAlertPatch(System.Collections.Generic.IDictionary<string, string> tags = null, bool? isEnabled = default(bool?)) { throw null; }
    }
    public partial class TenantActivityLogAlertActionGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup>
    {
        public TenantActivityLogAlertActionGroup(Azure.Core.ResourceIdentifier actionGroupId) { }
        public Azure.Core.ResourceIdentifier ActionGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ActionProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> WebhookProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertActionGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TenantActivityLogAlertAnyOfOrLeafCondition : Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition>
    {
        public TenantActivityLogAlertAnyOfOrLeafCondition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition> AnyOf { get { throw null; } }
        protected override Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertAnyOfOrLeafCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TenantActivityLogAlertLeafCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition>
    {
        public TenantActivityLogAlertLeafCondition() { }
        public System.Collections.Generic.IList<string> ContainsAny { get { throw null; } }
        public string EqualTo { get { throw null; } set { } }
        public string Field { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertLeafCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TenantActivityLogAlertPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch>
    {
        public TenantActivityLogAlertPatch() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.TenantActivityLogAlerts.Models.TenantActivityLogAlertPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
