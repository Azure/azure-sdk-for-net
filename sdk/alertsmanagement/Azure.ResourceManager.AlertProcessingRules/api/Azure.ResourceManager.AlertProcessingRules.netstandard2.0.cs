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
    public abstract partial class Action : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Action>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Action>
    {
        internal Action() { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.Action JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.Action PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.Action System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Action>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Action>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.Action System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Action>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Action>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Action>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddActionGroups : Azure.ResourceManager.AlertProcessingRules.Models.Action, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AddActionGroups>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AddActionGroups>
    {
        public AddActionGroups(System.Collections.Generic.IEnumerable<string> actionGroupIds) { }
        public System.Collections.Generic.IList<string> ActionGroupIds { get { throw null; } }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.Action JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.Action PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.AddActionGroups System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AddActionGroups>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AddActionGroups>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.AddActionGroups System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AddActionGroups>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AddActionGroups>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AddActionGroups>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertProcessingRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch>
    {
        public AlertProcessingRulePatch() { }
        public bool? Enabled { get { throw null; } set { } }
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
        public AlertProcessingRuleProperties(System.Collections.Generic.IEnumerable<string> scopes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.Action> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertProcessingRules.Models.Action> Actions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertProcessingRules.Models.Condition> Conditions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.AlertProcessingRules.Models.Schedule Schedule { get { throw null; } set { } }
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
    public static partial class ArmAlertProcessingRulesModelFactory
    {
        public static Azure.ResourceManager.AlertProcessingRules.Models.AddActionGroups AddActionGroups(System.Collections.Generic.IEnumerable<string> actionGroupIds = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.AlertProcessingRuleData AlertProcessingRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRulePatch AlertProcessingRulePatch(bool? enabled = default(bool?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.AlertProcessingRuleProperties AlertProcessingRuleProperties(System.Collections.Generic.IEnumerable<string> scopes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.Condition> conditions = null, Azure.ResourceManager.AlertProcessingRules.Models.Schedule schedule = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.Action> actions = null, string description = null, bool? enabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Condition Condition(Azure.ResourceManager.AlertProcessingRules.Models.Field? field = default(Azure.ResourceManager.AlertProcessingRules.Models.Field?), Azure.ResourceManager.AlertProcessingRules.Models.Operator? @operator = default(Azure.ResourceManager.AlertProcessingRules.Models.Operator?), System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.MonthlyRecurrence MonthlyRecurrence(string startTime = null, string endTime = null, System.Collections.Generic.IEnumerable<int> daysOfMonth = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Schedule Schedule(string effectiveFrom = null, string effectiveUntil = null, string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.Recurrence> recurrences = null) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.WeeklyRecurrence WeeklyRecurrence(string startTime = null, string endTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek> daysOfWeek = null) { throw null; }
    }
    public partial class Condition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Condition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Condition>
    {
        public Condition() { }
        public Azure.ResourceManager.AlertProcessingRules.Models.Field? Field { get { throw null; } set { } }
        public Azure.ResourceManager.AlertProcessingRules.Models.Operator? Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.Condition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.Condition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.Condition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Condition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Condition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.Condition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Condition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Condition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Condition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DailyRecurrence : Azure.ResourceManager.AlertProcessingRules.Models.Recurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>
    {
        public DailyRecurrence() { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.Recurrence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.Recurrence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.DailyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DaysOfWeek : System.IEquatable<Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DaysOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek left, Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek left, Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Field : System.IEquatable<Azure.ResourceManager.AlertProcessingRules.Models.Field>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Field(string value) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field AlertContext { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field AlertRuleId { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field AlertRuleName { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field Description { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field MonitorCondition { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field MonitorService { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field Severity { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field SignalType { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field TargetResource { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field TargetResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Field TargetResourceType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertProcessingRules.Models.Field other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertProcessingRules.Models.Field left, Azure.ResourceManager.AlertProcessingRules.Models.Field right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.Field (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.Field? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertProcessingRules.Models.Field left, Azure.ResourceManager.AlertProcessingRules.Models.Field right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonthlyRecurrence : Azure.ResourceManager.AlertProcessingRules.Models.Recurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.MonthlyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.MonthlyRecurrence>
    {
        public MonthlyRecurrence(System.Collections.Generic.IEnumerable<int> daysOfMonth) { }
        public System.Collections.Generic.IList<int> DaysOfMonth { get { throw null; } }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.Recurrence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.Recurrence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.MonthlyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.MonthlyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.MonthlyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.MonthlyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.MonthlyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.MonthlyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.MonthlyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Operator : System.IEquatable<Azure.ResourceManager.AlertProcessingRules.Models.Operator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Operator(string value) { throw null; }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Operator Contains { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Operator DoesNotContain { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Operator EqualTo { get { throw null; } }
        public static Azure.ResourceManager.AlertProcessingRules.Models.Operator NotEqualTo { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AlertProcessingRules.Models.Operator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AlertProcessingRules.Models.Operator left, Azure.ResourceManager.AlertProcessingRules.Models.Operator right) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.Operator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AlertProcessingRules.Models.Operator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AlertProcessingRules.Models.Operator left, Azure.ResourceManager.AlertProcessingRules.Models.Operator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class Recurrence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Recurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Recurrence>
    {
        internal Recurrence() { }
        public string EndTime { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.Recurrence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.Recurrence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.Recurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Recurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Recurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.Recurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Recurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Recurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Recurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoveAllActionGroups : Azure.ResourceManager.AlertProcessingRules.Models.Action, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.RemoveAllActionGroups>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.RemoveAllActionGroups>
    {
        public RemoveAllActionGroups() { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.Action JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.Action PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.RemoveAllActionGroups System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.RemoveAllActionGroups>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.RemoveAllActionGroups>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.RemoveAllActionGroups System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.RemoveAllActionGroups>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.RemoveAllActionGroups>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.RemoveAllActionGroups>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Schedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Schedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Schedule>
    {
        public Schedule() { }
        public string EffectiveFrom { get { throw null; } set { } }
        public string EffectiveUntil { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertProcessingRules.Models.Recurrence> Recurrences { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.Schedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertProcessingRules.Models.Schedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.Schedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Schedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.Schedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.Schedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Schedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Schedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.Schedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeeklyRecurrence : Azure.ResourceManager.AlertProcessingRules.Models.Recurrence, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.WeeklyRecurrence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.WeeklyRecurrence>
    {
        public WeeklyRecurrence(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek> daysOfWeek) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AlertProcessingRules.Models.DaysOfWeek> DaysOfWeek { get { throw null; } }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.Recurrence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.AlertProcessingRules.Models.Recurrence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertProcessingRules.Models.WeeklyRecurrence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.WeeklyRecurrence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertProcessingRules.Models.WeeklyRecurrence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertProcessingRules.Models.WeeklyRecurrence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.WeeklyRecurrence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.WeeklyRecurrence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertProcessingRules.Models.WeeklyRecurrence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
