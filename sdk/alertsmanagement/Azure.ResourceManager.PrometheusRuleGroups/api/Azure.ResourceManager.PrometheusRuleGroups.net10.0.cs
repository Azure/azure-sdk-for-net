namespace Azure.ResourceManager.PrometheusRuleGroups
{
    public partial class AzureResourceManagerPrometheusRuleGroupsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPrometheusRuleGroupsContext() { }
        public static Azure.ResourceManager.PrometheusRuleGroups.AzureResourceManagerPrometheusRuleGroupsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class PrometheusRuleGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>, System.Collections.IEnumerable
    {
        protected PrometheusRuleGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleGroupName, Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleGroupName, Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> Get(string ruleGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>> GetAsync(string ruleGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> GetIfExists(string ruleGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>> GetIfExistsAsync(string ruleGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrometheusRuleGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>
    {
        public PrometheusRuleGroupData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> scopes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule> rules) { }
        public string ClusterName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.TimeSpan? Interval { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule> Rules { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusRuleGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrometheusRuleGroupResource() { }
        public virtual Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ruleGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> Update(Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>> UpdateAsync(Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PrometheusRuleGroupsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> GetPrometheusRuleGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>> GetPrometheusRuleGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ruleGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource GetPrometheusRuleGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupCollection GetPrometheusRuleGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> GetPrometheusRuleGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> GetPrometheusRuleGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PrometheusRuleGroups.Mocking
{
    public partial class MockablePrometheusRuleGroupsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePrometheusRuleGroupsArmClient() { }
        public virtual Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource GetPrometheusRuleGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePrometheusRuleGroupsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePrometheusRuleGroupsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> GetPrometheusRuleGroup(string ruleGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource>> GetPrometheusRuleGroupAsync(string ruleGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupCollection GetPrometheusRuleGroups() { throw null; }
    }
    public partial class MockablePrometheusRuleGroupsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePrometheusRuleGroupsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> GetPrometheusRuleGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupResource> GetPrometheusRuleGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PrometheusRuleGroups.Models
{
    public static partial class ArmPrometheusRuleGroupsModelFactory
    {
        public static Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule PrometheusRule(string record = null, string alert = null, bool? enabled = default(bool?), string expression = null, System.Collections.Generic.IDictionary<string, string> labels = null, int? severity = default(int?), System.TimeSpan? @for = default(System.TimeSpan?), System.Collections.Generic.IDictionary<string, string> annotations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction> actions = null, Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration resolveConfiguration = null) { throw null; }
        public static Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction PrometheusRuleGroupAction(string actionGroupId = null, System.Collections.Generic.IDictionary<string, string> actionProperties = null) { throw null; }
        public static Azure.ResourceManager.PrometheusRuleGroups.PrometheusRuleGroupData PrometheusRuleGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, bool? enabled = default(bool?), string clusterName = null, System.Collections.Generic.IEnumerable<string> scopes = null, System.TimeSpan? interval = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule> rules = null) { throw null; }
        public static Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch PrometheusRuleGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, bool? enabled = default(bool?)) { throw null; }
    }
    public partial class PrometheusRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule>
    {
        public PrometheusRule(string expression) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction> Actions { get { throw null; } }
        public string Alert { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Annotations { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.TimeSpan? For { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Record { get { throw null; } set { } }
        public Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration ResolveConfiguration { get { throw null; } set { } }
        public int? Severity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusRuleGroupAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction>
    {
        public PrometheusRuleGroupAction() { }
        public string ActionGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ActionProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusRuleGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch>
    {
        public PrometheusRuleGroupPatch() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrometheusRuleResolveConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration>
    {
        public PrometheusRuleResolveConfiguration() { }
        public bool? AutoResolved { get { throw null; } set { } }
        public System.TimeSpan? TimeToResolve { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrometheusRuleGroups.Models.PrometheusRuleResolveConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
