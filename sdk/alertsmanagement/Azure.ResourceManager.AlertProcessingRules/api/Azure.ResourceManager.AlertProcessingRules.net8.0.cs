namespace Azure.ResourceManager.AlertProcessingRules
{
    public partial class AlertProcessingRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>, System.Collections.IEnumerable
    {
        protected AlertProcessingRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertProcessingRuleName, Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertProcessingRuleName, Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> Get(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>> GetAsync(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> GetIfExists(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>> GetIfExistsAsync(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertProcessingRuleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>
    {
        public AlertProcessingRuleData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertProcessingRuleResource() { }
        public virtual Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string alertProcessingRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> Update(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>> UpdateAsync(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AlertProcessingRulesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> GetAlertProcessingRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource GetAlertProcessingRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleCollection GetAlertProcessingRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> GetAlertProcessingRules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> GetAlertProcessingRulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAlertProcessingRulesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAlertProcessingRulesContext() { }
        public static Azure.ResourceManager.AlertProcessingRules.AzureResourceManagerAlertProcessingRulesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.AlertProcessingRules.Mocking
{
    public partial class MockableAlertProcessingRulesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertProcessingRulesArmClient() { }
        public virtual Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource GetAlertProcessingRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAlertProcessingRulesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertProcessingRulesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> GetAlertProcessingRule(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource>> GetAlertProcessingRuleAsync(string alertProcessingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleCollection GetAlertProcessingRules() { throw null; }
    }
    public partial class MockableAlertProcessingRulesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertProcessingRulesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> GetAlertProcessingRules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleResource> GetAlertProcessingRulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AlertProcessingRules.Models
{
    public abstract partial class AlertProcessingRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction>
    {
        protected AlertProcessingRuleAction() { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleAddGroupsAction : Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAddGroupsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAddGroupsAction>
    {
        public AlertProcessingRuleAddGroupsAction(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> actionGroupIds) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ActionGroupIds { get { throw null; } }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAddGroupsAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAddGroupsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAddGroupsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAddGroupsAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAddGroupsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAddGroupsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAddGroupsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition>
    {
        public AlertProcessingRuleCondition() { }
        public Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField? Field { get { throw null; } set { } }
        public Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator? Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertProcessingRuleField : System.IEquatable<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertProcessingRuleField(string value) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField AlertContext { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField AlertRuleId { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField AlertRuleName { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField Description { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField MonitorCondition { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField MonitorService { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField Severity { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField SignalType { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField TargetResource { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField TargetResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField TargetResourceType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField left, Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField left, Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertProcessingRuleMonthlyRecurrence : Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleMonthlyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleMonthlyRecurrence>
    {
        public AlertProcessingRuleMonthlyRecurrence(System.Collections.Generic.IEnumerable<int> daysOfMonth) { }
        public System.Collections.Generic.IList<int> DaysOfMonth { get { throw null; } }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleMonthlyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleMonthlyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleMonthlyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleMonthlyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleMonthlyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleMonthlyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleMonthlyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertProcessingRuleOperator : System.IEquatable<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertProcessingRuleOperator(string value) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator DoesNotContain { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator EqualTo { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator NotEquals { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator left, Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator left, Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertProcessingRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch>
    {
        public AlertProcessingRulePatch() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties>
    {
        public AlertProcessingRuleProperties(System.Collections.Generic.IEnumerable<string> scopes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition> Conditions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AlertProcessingRuleRecurrence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence>
    {
        protected AlertProcessingRuleRecurrence() { }
        public System.TimeSpan? EndOn { get { throw null; } set { } }
        public System.TimeSpan? StartOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleRemoveAllGroupsAction : Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRemoveAllGroupsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRemoveAllGroupsAction>
    {
        public AlertProcessingRuleRemoveAllGroupsAction() { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRemoveAllGroupsAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRemoveAllGroupsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRemoveAllGroupsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRemoveAllGroupsAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRemoveAllGroupsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRemoveAllGroupsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRemoveAllGroupsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule>
    {
        public AlertProcessingRuleSchedule() { }
        public System.DateTimeOffset? EffectiveFrom { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveUntil { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence> Recurrences { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRuleWeeklyRecurrence : Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleWeeklyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleWeeklyRecurrence>
    {
        public AlertProcessingRuleWeeklyRecurrence(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek> daysOfWeek) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek> DaysOfWeek { get { throw null; } }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleWeeklyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleWeeklyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleWeeklyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleWeeklyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleWeeklyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleWeeklyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleWeeklyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertsManagementDayOfWeek : System.IEquatable<Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertsManagementDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek left, Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek left, Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmAlertProcessingRulesModelFactory
    {
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAddGroupsAction AlertProcessingRuleAddGroupsAction(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> actionGroupIds = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition AlertProcessingRuleCondition(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField? field = default(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleField?), Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator? @operator = default(Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleOperator?), System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData AlertProcessingRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleMonthlyRecurrence AlertProcessingRuleMonthlyRecurrence(System.TimeSpan? startOn = default(System.TimeSpan?), System.TimeSpan? endOn = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<int> daysOfMonth = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch AlertProcessingRulePatch(bool? isEnabled = default(bool?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties AlertProcessingRuleProperties(System.Collections.Generic.IEnumerable<string> scopes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleCondition> conditions = null, Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule schedule = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleAction> actions = null, string description = null, bool? isEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleSchedule AlertProcessingRuleSchedule(System.DateTimeOffset? effectiveFrom = default(System.DateTimeOffset?), System.DateTimeOffset? effectiveUntil = default(System.DateTimeOffset?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence> recurrences = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleWeeklyRecurrence AlertProcessingRuleWeeklyRecurrence(System.TimeSpan? startOn = default(System.TimeSpan?), System.TimeSpan? endOn = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.AlertsManagementDayOfWeek> daysOfWeek = null) { throw null; }
    }
    public partial class DailyRecurrence : Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>
    {
        public DailyRecurrence() { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleRecurrence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
