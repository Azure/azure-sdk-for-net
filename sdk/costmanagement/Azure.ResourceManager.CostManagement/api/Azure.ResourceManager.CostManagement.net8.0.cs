namespace Azure.ResourceManager.CostManagement
{
    public partial class AzureResourceManagerCostManagementContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCostManagementContext() { }
        public static Azure.ResourceManager.CostManagement.AzureResourceManagerCostManagementContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BudgetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.BudgetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.BudgetResource>, System.Collections.IEnumerable
    {
        protected BudgetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.BudgetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string budgetName, Azure.ResourceManager.CostManagement.BudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.BudgetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string budgetName, Azure.ResourceManager.CostManagement.BudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.BudgetResource> Get(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.BudgetResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.BudgetResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.BudgetResource>> GetAsync(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.BudgetResource> GetIfExists(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.BudgetResource>> GetIfExistsAsync(string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.BudgetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.BudgetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.BudgetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.BudgetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BudgetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.BudgetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.BudgetData>
    {
        public BudgetData() { }
        public float? Amount { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CategoryType? BudgetCategory { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.TimeGrainType? BudgetTimeGrain { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Use BudgetCategory instead.")]
        public Azure.ResourceManager.CostManagement.Models.CategoryType Category { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CurrentSpend CurrentSpend { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.BudgetFilter Filter { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ForecastSpend ForecastSpend { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CostManagement.Models.BudgetNotification> Notifications { get { throw null; } }
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Use BudgetTimeGrain instead.")]
        public Azure.ResourceManager.CostManagement.Models.TimeGrainType TimeGrain { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod TimePeriod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.BudgetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.BudgetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.BudgetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.BudgetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.BudgetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.BudgetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.BudgetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BudgetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.BudgetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.BudgetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BudgetResource() { }
        public virtual Azure.ResourceManager.CostManagement.BudgetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string budgetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.BudgetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.BudgetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.BudgetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.BudgetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.BudgetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.BudgetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.BudgetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.BudgetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.BudgetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.BudgetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.BudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.BudgetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.BudgetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CostAllocationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>, System.Collections.IEnumerable
    {
        protected CostAllocationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.CostManagement.CostAllocationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.CostManagement.CostAllocationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CostAllocationRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>
    {
        public CostAllocationRuleData() { }
        public Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.CostAllocationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostAllocationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CostAllocationRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CostAllocationRuleResource() { }
        public virtual Azure.ResourceManager.CostManagement.CostAllocationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountId, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.CostAllocationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostAllocationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostAllocationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostAllocationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostAllocationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CostManagementAlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementAlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementAlertResource>, System.Collections.IEnumerable
    {
        protected CostManagementAlertCollection() { }
        public virtual Azure.Response<bool> Exists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource> Get(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource>> GetAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetIfExists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.CostManagementAlertResource>> GetIfExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.CostManagementAlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementAlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.CostManagementAlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementAlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CostManagementAlertData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>
    {
        public CostManagementAlertData() { }
        public System.DateTimeOffset? CloseOn { get { throw null; } set { } }
        public string CostEntityId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition Definition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails Details { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource? Source { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus? Status { get { throw null; } set { } }
        public string StatusModificationUserName { get { throw null; } set { } }
        public System.DateTimeOffset? StatusModifiedOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.CostManagementAlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostManagementAlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CostManagementAlertResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CostManagementAlertResource() { }
        public virtual Azure.ResourceManager.CostManagement.CostManagementAlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string alertId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.CostManagementAlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostManagementAlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementAlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource> Update(Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource>> UpdateAsync(Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CostManagementExportCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementExportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementExportResource>, System.Collections.IEnumerable
    {
        protected CostManagementExportCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementExportResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string exportName, Azure.ResourceManager.CostManagement.CostManagementExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementExportResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string exportName, Azure.ResourceManager.CostManagement.CostManagementExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource> Get(string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.CostManagementExportResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.CostManagementExportResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource>> GetAsync(string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.CostManagementExportResource> GetIfExists(string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.CostManagementExportResource>> GetIfExistsAsync(string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.CostManagementExportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementExportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.CostManagementExportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementExportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CostManagementExportData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementExportData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementExportData>
    {
        public CostManagementExportData() { }
        public Azure.ResourceManager.CostManagement.Models.CompressionModeType? CompressionMode { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType? DataOverwriteBehavior { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportDefinition Definition { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination DeliveryInfoDestination { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string ExportDescription { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportFormatType? Format { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.DateTimeOffset? NextRunTimeEstimate { get { throw null; } }
        public bool? PartitionData { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement.Models.ExportRun> RunHistoryValue { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ExportSchedule Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext SystemSuspensionContext { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.CostManagementExportData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementExportData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementExportData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostManagementExportData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementExportData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementExportData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementExportData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CostManagementExportResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementExportData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementExportData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CostManagementExportResource() { }
        public virtual Azure.ResourceManager.CostManagement.CostManagementExportData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string exportName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Execute(Azure.ResourceManager.CostManagement.Models.ExportRunContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Execute(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteAsync(Azure.ResourceManager.CostManagement.Models.ExportRunContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.ExportRun> GetExecutionHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.ExportRun> GetExecutionHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.CostManagementExportData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementExportData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementExportData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostManagementExportData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementExportData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementExportData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementExportData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementExportResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementExportResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementExportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CostManagementExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> ByBillingAccountIdGenerateReservationDetailsReport(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> ByBillingAccountIdGenerateReservationDetailsReport(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> ByBillingAccountIdGenerateReservationDetailsReportAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> ByBillingAccountIdGenerateReservationDetailsReportAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> ByBillingProfileIdGenerateReservationDetailsReport(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> ByBillingProfileIdGenerateReservationDetailsReport(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> ByBillingProfileIdGenerateReservationDetailsReportAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> ByBillingProfileIdGenerateReservationDetailsReportAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> ByExternalCloudProviderTypeDimensions(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, string filter = null, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> ByExternalCloudProviderTypeDimensions(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.TenantResourceByExternalCloudProviderTypeDimensionsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> ByExternalCloudProviderTypeDimensionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, string filter = null, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> ByExternalCloudProviderTypeDimensionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.TenantResourceByExternalCloudProviderTypeDimensionsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult> CheckCostManagementNameAvailabilityByScheduledAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>> CheckCostManagementNameAvailabilityByScheduledActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult> CheckCostManagementNameAvailabilityByScopeScheduledAction(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>> CheckCostManagementNameAvailabilityByScopeScheduledActionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults> CreateOperation(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource> CreateOperation(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>> CreateOperationAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource>> CreateOperationAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> DownloadByBillingAccount(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> DownloadByBillingAccountAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties> DownloadByBillingProfilePriceSheet(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("The underlying operation now returns PriceSheetDownloadProperties instead of DownloadURL and the DownloadURL.ValidTill field is no longer available from the service. This overload will throw NotSupportedException at runtime. Use the ArmClient.DownloadByBillingProfilePriceSheet extension method instead.")]
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL> DownloadByBillingProfilePriceSheet(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties>> DownloadByBillingProfilePriceSheetAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("The underlying operation now returns PriceSheetDownloadProperties instead of DownloadURL and the DownloadURL.ValidTill field is no longer available from the service. This overload will throw NotSupportedException at runtime. Use the ArmClient.DownloadByBillingProfilePriceSheetAsync extension method instead.")]
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL>> DownloadByBillingProfilePriceSheetAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL> DownloadPriceSheet(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL> DownloadPriceSheet(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileName, string invoiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL>> DownloadPriceSheetAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL>> DownloadPriceSheetAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileName, string invoiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.Models.ForecastResult> ExternalCloudProviderUsageForecast(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, Azure.ResourceManager.CostManagement.Models.ForecastDefinition forecastDefinition, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.ForecastResult>> ExternalCloudProviderUsageForecastAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, Azure.ResourceManager.CostManagement.Models.ForecastDefinition forecastDefinition, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScope(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScope(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string savingsPlanOrderId, string savingsPlanId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScopeAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScopeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string savingsPlanOrderId, string savingsPlanId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingAccountScope(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingAccountScope(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingAccountScopeAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingAccountScopeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingProfileScope(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingProfileScope(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingProfileScopeAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingProfileScopeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationOrderScope(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationOrderScope(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string reservationOrderId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationOrderScopeAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationOrderScopeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string reservationOrderId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationScope(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationScope(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string reservationOrderId, string reservationId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationScopeAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationScopeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string reservationOrderId, string reservationId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScope(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScope(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string savingsPlanOrderId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScopeAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScopeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string savingsPlanOrderId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementViewsCollection GetAllCostManagementViews(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesCollection GetAllGenerateDetailedCostReportOperationStatuses(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.CostManagement.TenantsCostManagementViewsCollection GetAllTenantsCostManagementViews(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel> GetBenefitRecommendations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string orderby = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel> GetBenefitRecommendationsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string orderby = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountId(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountId(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountIdAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileId(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileId(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileIdAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, string billingProfileId, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanId(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanId(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string savingsPlanId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanIdAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string savingsPlanId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrder(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrder(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrderAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrderAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string savingsPlanOrderId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.BudgetResource> GetBudget(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.BudgetResource>> GetBudgetAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.BudgetResource GetBudgetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.BudgetCollection GetBudgets(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> GetCostAllocationRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>> GetCostAllocationRuleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostAllocationRuleResource GetCostAllocationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostAllocationRuleCollection GetCostAllocationRules(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetCostManagementAlert(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource>> GetCostManagementAlertAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementAlertResource GetCostManagementAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementAlertCollection GetCostManagementAlerts(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetCostManagementAlerts(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetCostManagementAlertsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource> GetCostManagementExport(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource>> GetCostManagementExportAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementExportResource GetCostManagementExportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementExportCollection GetCostManagementExports(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.CostManagementSettingResource> GetCostManagementSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementSettingResource>> GetCostManagementSettingAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementSettingResource GetCostManagementSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementSettingCollection GetCostManagementSettings(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource> GetCostManagementViews(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> GetCostManagementViewsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementViewsResource GetCostManagementViewsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> GetDimensions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> GetDimensionsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource> GetGenerateDetailedCostReportOperationResult(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource>> GetGenerateDetailedCostReportOperationResultAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource GetGenerateDetailedCostReportOperationResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultCollection GetGenerateDetailedCostReportOperationResults(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource> GetGenerateDetailedCostReportOperationStatuses(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource>> GetGenerateDetailedCostReportOperationStatusesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource GetGenerateDetailedCostReportOperationStatusesResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults> GetOperationResults(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>> GetOperationResultsAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource> GetScheduledAction(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource>> GetScheduledActionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.ScheduledActionResource GetScheduledActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.ScheduledActionCollection GetScheduledActions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> GetTenantScheduledAction(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> GetTenantScheduledActionAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.TenantScheduledActionResource GetTenantScheduledActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CostManagement.TenantScheduledActionCollection GetTenantScheduledActions(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> GetTenantsCostManagementViews(this Azure.ResourceManager.Resources.TenantResource tenantResource, string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> GetTenantsCostManagementViewsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource GetTenantsCostManagementViewsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.Models.QueryResult> UsageByExternalCloudProviderTypeQuery(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, Azure.ResourceManager.CostManagement.Models.QueryDefinition queryDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.QueryResult>> UsageByExternalCloudProviderTypeQueryAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, Azure.ResourceManager.CostManagement.Models.QueryDefinition queryDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.Models.ForecastResult> UsageForecast(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.ForecastDefinition forecastDefinition, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.ForecastResult>> UsageForecastAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.ForecastDefinition forecastDefinition, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CostManagement.Models.QueryResult> UsageQuery(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.QueryDefinition queryDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.QueryResult>> UsageQueryAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.QueryDefinition queryDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CostManagementSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementSettingResource>, System.Collections.IEnumerable
    {
        protected CostManagementSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, Azure.ResourceManager.CostManagement.CostManagementSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, Azure.ResourceManager.CostManagement.CostManagementSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementSettingResource> Get(Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.CostManagementSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.CostManagementSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementSettingResource>> GetAsync(Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.CostManagementSettingResource> GetIfExists(Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.CostManagementSettingResource>> GetIfExistsAsync(Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.CostManagementSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.CostManagementSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class CostManagementSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>
    {
        internal CostManagementSettingData() { }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.CostManagementSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostManagementSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CostManagementSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CostManagementSettingResource() { }
        public virtual Azure.ResourceManager.CostManagement.CostManagementSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.CostManagementSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostManagementSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CostManagementViewData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>
    {
        public CostManagementViewData() { }
        public Azure.ResourceManager.CostManagement.Models.AccumulatedType? Accumulated { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ViewChartType? Chart { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Currency { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigDataset DataSet { get { throw null; } set { } }
        public string DateRange { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IncludeMonetaryCommitment { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ViewKpiProperties> Kpis { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ViewMetricType? Metric { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ViewPivotProperties> Pivots { get { throw null; } }
        public Azure.Core.ResourceIdentifier Scope { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ReportTimeframeType? Timeframe { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod TimePeriod { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ViewReportType? TypePropertiesQueryType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.CostManagementViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostManagementViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CostManagementViewsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementViewsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementViewsResource>, System.Collections.IEnumerable
    {
        protected CostManagementViewsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementViewsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource> Get(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.CostManagementViewsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.CostManagementViewsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> GetAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.CostManagementViewsResource> GetIfExists(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> GetIfExistsAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.CostManagementViewsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.CostManagementViewsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.CostManagementViewsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.CostManagementViewsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CostManagementViewsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CostManagementViewsResource() { }
        public virtual Azure.ResourceManager.CostManagement.CostManagementViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string viewName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.CostManagementViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostManagementViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementViewsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GenerateDetailedCostReportOperationResultCollection : Azure.ResourceManager.ArmCollection
    {
        protected GenerateDetailedCostReportOperationResultCollection() { }
        public virtual Azure.Response<bool> Exists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource> Get(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource>> GetAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource> GetIfExists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource>> GetIfExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GenerateDetailedCostReportOperationResultData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>
    {
        internal GenerateDetailedCostReportOperationResultData() { }
        public System.Uri DownloadUri { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public System.DateTimeOffset? ValidTill { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateDetailedCostReportOperationResultResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GenerateDetailedCostReportOperationResultResource() { }
        public virtual Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string operationId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource> Get(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource>> GetAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateDetailedCostReportOperationStatusesCollection : Azure.ResourceManager.ArmCollection
    {
        protected GenerateDetailedCostReportOperationStatusesCollection() { }
        public virtual Azure.Response<bool> Exists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource> Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource>> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource> GetIfExists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource>> GetIfExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GenerateDetailedCostReportOperationStatusesData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>
    {
        internal GenerateDetailedCostReportOperationStatusesData() { }
        public System.Uri DownloadUri { get { throw null; } }
        public string EndTime { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails Error { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public string StartTime { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType? StatusValue { get { throw null; } }
        public System.DateTimeOffset? ValidTill { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateDetailedCostReportOperationStatusesResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GenerateDetailedCostReportOperationStatusesResource() { }
        public virtual Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string operationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.ScheduledActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.ScheduledActionResource>, System.Collections.IEnumerable
    {
        protected ScheduledActionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.ScheduledActionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.ScheduledActionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.ScheduledActionResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.ScheduledActionResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.ScheduledActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.ScheduledActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.ScheduledActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.ScheduledActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScheduledActionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.ScheduledActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>
    {
        public ScheduledActionData() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat> FileFormats { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ScheduledActionKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.NotificationProperties Notification { get { throw null; } set { } }
        public string NotificationEmail { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ScheduleProperties Schedule { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Scope { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus? Status { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ViewId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.ScheduledActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.ScheduledActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.ScheduledActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScheduledActionResource() { }
        public virtual Azure.ResourceManager.CostManagement.ScheduledActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RunByScope(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunByScopeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.ScheduledActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.ScheduledActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.ScheduledActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantScheduledActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>, System.Collections.IEnumerable
    {
        protected TenantScheduledActionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.CostManagement.ScheduledActionData data, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantScheduledActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.ScheduledActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantScheduledActionResource() { }
        public virtual Azure.ResourceManager.CostManagement.ScheduledActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Run(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.ScheduledActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.ScheduledActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.ScheduledActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.ScheduledActionData data, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantsCostManagementViewsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>, System.Collections.IEnumerable
    {
        protected TenantsCostManagementViewsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> Get(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> GetAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> GetIfExists(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> GetIfExistsAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantsCostManagementViewsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantsCostManagementViewsResource() { }
        public virtual Azure.ResourceManager.CostManagement.CostManagementViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string viewName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CostManagement.CostManagementViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.CostManagementViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.CostManagementViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement.CostManagementViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CostManagement.Mocking
{
    public partial class MockableCostManagementArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCostManagementArmClient() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> ByBillingAccountIdGenerateReservationDetailsReport(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> ByBillingAccountIdGenerateReservationDetailsReportAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> ByBillingProfileIdGenerateReservationDetailsReport(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> ByBillingProfileIdGenerateReservationDetailsReportAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult> CheckCostManagementNameAvailabilityByScopeScheduledAction(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>> CheckCostManagementNameAvailabilityByScopeScheduledActionAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults> CreateOperation(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource> CreateOperation(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>> CreateOperationAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource>> CreateOperationAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> DownloadByBillingAccount(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> DownloadByBillingAccountAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties> DownloadByBillingProfilePriceSheet(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties>> DownloadByBillingProfilePriceSheetAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL> DownloadPriceSheet(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL>> DownloadPriceSheetAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScope(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScopeAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingAccountScope(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingAccountScopeAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingProfileScope(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingProfileScopeAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationOrderScope(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationOrderScopeAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationScope(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationScopeAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScope(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScopeAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.CostManagementViewsCollection GetAllCostManagementViews(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesCollection GetAllGenerateDetailedCostReportOperationStatuses(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel> GetBenefitRecommendations(Azure.Core.ResourceIdentifier scope, string filter = null, string orderby = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel> GetBenefitRecommendationsAsync(Azure.Core.ResourceIdentifier scope, string filter = null, string orderby = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountId(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountIdAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileId(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileIdAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanId(Azure.Core.ResourceIdentifier scope, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanIdAsync(Azure.Core.ResourceIdentifier scope, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrder(Azure.Core.ResourceIdentifier scope, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrderAsync(Azure.Core.ResourceIdentifier scope, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.BudgetResource> GetBudget(Azure.Core.ResourceIdentifier scope, string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.BudgetResource>> GetBudgetAsync(Azure.Core.ResourceIdentifier scope, string budgetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.BudgetResource GetBudgetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.BudgetCollection GetBudgets(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostAllocationRuleResource> GetCostAllocationRule(Azure.Core.ResourceIdentifier scope, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostAllocationRuleResource>> GetCostAllocationRuleAsync(Azure.Core.ResourceIdentifier scope, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.CostAllocationRuleResource GetCostAllocationRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.CostAllocationRuleCollection GetCostAllocationRules(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetCostManagementAlert(Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementAlertResource>> GetCostManagementAlertAsync(Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.CostManagementAlertResource GetCostManagementAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.CostManagementAlertCollection GetCostManagementAlerts(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource> GetCostManagementExport(Azure.Core.ResourceIdentifier scope, string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementExportResource>> GetCostManagementExportAsync(Azure.Core.ResourceIdentifier scope, string exportName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.CostManagementExportResource GetCostManagementExportResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.CostManagementExportCollection GetCostManagementExports(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementSettingResource> GetCostManagementSetting(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementSettingResource>> GetCostManagementSettingAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.CostManagementSettingType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.CostManagementSettingResource GetCostManagementSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.CostManagementSettingCollection GetCostManagementSettings(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource> GetCostManagementViews(Azure.Core.ResourceIdentifier scope, string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.CostManagementViewsResource>> GetCostManagementViewsAsync(Azure.Core.ResourceIdentifier scope, string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.CostManagementViewsResource GetCostManagementViewsResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> GetDimensions(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> GetDimensionsAsync(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource> GetGenerateDetailedCostReportOperationResult(Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource>> GetGenerateDetailedCostReportOperationResultAsync(Azure.Core.ResourceIdentifier scope, Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultResource GetGenerateDetailedCostReportOperationResultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultCollection GetGenerateDetailedCostReportOperationResults(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource> GetGenerateDetailedCostReportOperationStatuses(Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource>> GetGenerateDetailedCostReportOperationStatusesAsync(Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesResource GetGenerateDetailedCostReportOperationStatusesResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults> GetOperationResults(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>> GetOperationResultsAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource> GetScheduledAction(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.ScheduledActionResource>> GetScheduledActionAsync(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.ScheduledActionResource GetScheduledActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.ScheduledActionCollection GetScheduledActions(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.TenantScheduledActionResource GetTenantScheduledActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource GetTenantsCostManagementViewsResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.Models.ForecastResult> UsageForecast(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.ForecastDefinition forecastDefinition, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.ForecastResult>> UsageForecastAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.ForecastDefinition forecastDefinition, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.Models.QueryResult> UsageQuery(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.QueryDefinition queryDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.QueryResult>> UsageQueryAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.QueryDefinition queryDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableCostManagementTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCostManagementTenantResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> ByBillingAccountIdGenerateReservationDetailsReport(Azure.WaitUntil waitUntil, string billingAccountId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> ByBillingAccountIdGenerateReservationDetailsReportAsync(Azure.WaitUntil waitUntil, string billingAccountId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus> ByBillingProfileIdGenerateReservationDetailsReport(Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.OperationStatus>> ByBillingProfileIdGenerateReservationDetailsReportAsync(Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileId, string startDate, string endDate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> ByExternalCloudProviderTypeDimensions(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, string filter = null, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> ByExternalCloudProviderTypeDimensions(Azure.ResourceManager.CostManagement.Models.TenantResourceByExternalCloudProviderTypeDimensionsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> ByExternalCloudProviderTypeDimensionsAsync(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, string filter = null, string expand = null, string skiptoken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.CostManagementDimension> ByExternalCloudProviderTypeDimensionsAsync(Azure.ResourceManager.CostManagement.Models.TenantResourceByExternalCloudProviderTypeDimensionsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult> CheckCostManagementNameAvailabilityByScheduledAction(Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>> CheckCostManagementNameAvailabilityByScheduledActionAsync(Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("The underlying operation now returns PriceSheetDownloadProperties instead of DownloadURL and the DownloadURL.ValidTill field is no longer available from the service. This overload will throw NotSupportedException at runtime. Use the ArmClient.DownloadByBillingProfilePriceSheet extension method instead.")]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL> DownloadByBillingProfilePriceSheet(Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("The underlying operation now returns PriceSheetDownloadProperties instead of DownloadURL and the DownloadURL.ValidTill field is no longer available from the service. This overload will throw NotSupportedException at runtime. Use the ArmClient.DownloadByBillingProfilePriceSheetAsync extension method instead.")]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL>> DownloadByBillingProfilePriceSheetAsync(Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL> DownloadPriceSheet(Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileName, string invoiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.DownloadURL>> DownloadPriceSheetAsync(Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileName, string invoiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.Models.ForecastResult> ExternalCloudProviderUsageForecast(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, Azure.ResourceManager.CostManagement.Models.ForecastDefinition forecastDefinition, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.ForecastResult>> ExternalCloudProviderUsageForecastAsync(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, Azure.ResourceManager.CostManagement.Models.ForecastDefinition forecastDefinition, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScope(Azure.WaitUntil waitUntil, string savingsPlanOrderId, string savingsPlanId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportAsyncSavingsPlanScopeAsync(Azure.WaitUntil waitUntil, string savingsPlanOrderId, string savingsPlanId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingAccountScope(Azure.WaitUntil waitUntil, string billingAccountId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingAccountScopeAsync(Azure.WaitUntil waitUntil, string billingAccountId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportBillingProfileScope(Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportBillingProfileScopeAsync(Azure.WaitUntil waitUntil, string billingAccountId, string billingProfileId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationOrderScope(Azure.WaitUntil waitUntil, string reservationOrderId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationOrderScopeAsync(Azure.WaitUntil waitUntil, string reservationOrderId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportReservationScope(Azure.WaitUntil waitUntil, string reservationOrderId, string reservationId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportReservationScopeAsync(Azure.WaitUntil waitUntil, string reservationOrderId, string reservationId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScope(Azure.WaitUntil waitUntil, string savingsPlanOrderId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>> GenerateBenefitUtilizationSummariesReportSavingsPlanOrderScopeAsync(Azure.WaitUntil waitUntil, string savingsPlanOrderId, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.TenantsCostManagementViewsCollection GetAllTenantsCostManagementViews() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountId(string billingAccountId, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingAccountIdAsync(string billingAccountId, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileId(string billingAccountId, string billingProfileId, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesByBillingProfileIdAsync(string billingAccountId, string billingProfileId, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanId(string savingsPlanOrderId, string savingsPlanId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanIdAsync(string savingsPlanOrderId, string savingsPlanId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrder(string savingsPlanOrderId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary> GetBenefitUtilizationSummariesBySavingsPlanOrderAsync(string savingsPlanOrderId, string filter = null, Azure.ResourceManager.CostManagement.Models.GrainContent? grainParameter = default(Azure.ResourceManager.CostManagement.Models.GrainContent?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetCostManagementAlerts(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CostManagement.CostManagementAlertResource> GetCostManagementAlertsAsync(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource> GetTenantScheduledAction(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantScheduledActionResource>> GetTenantScheduledActionAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CostManagement.TenantScheduledActionCollection GetTenantScheduledActions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource> GetTenantsCostManagementViews(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.TenantsCostManagementViewsResource>> GetTenantsCostManagementViewsAsync(string viewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CostManagement.Models.QueryResult> UsageByExternalCloudProviderTypeQuery(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, Azure.ResourceManager.CostManagement.Models.QueryDefinition queryDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CostManagement.Models.QueryResult>> UsageByExternalCloudProviderTypeQueryAsync(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId, Azure.ResourceManager.CostManagement.Models.QueryDefinition queryDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CostManagement.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccumulatedType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AccumulatedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccumulatedType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AccumulatedType False { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AccumulatedType True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AccumulatedType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AccumulatedType left, Azure.ResourceManager.CostManagement.Models.AccumulatedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AccumulatedType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AccumulatedType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AccumulatedType left, Azure.ResourceManager.CostManagement.Models.AccumulatedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertCriterion : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AlertCriterion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertCriterion(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion CostThresholdExceeded { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion CreditThresholdApproaching { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion CreditThresholdReached { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion CrossCloudCollectionError { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion CrossCloudNewDataAvailable { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion ForecastCostThresholdExceeded { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion ForecastUsageThresholdExceeded { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion GeneralThresholdError { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion InvoiceDueDateApproaching { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion InvoiceDueDateReached { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion MultiCurrency { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion QuotaThresholdApproaching { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion QuotaThresholdReached { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertCriterion UsageThresholdExceeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AlertCriterion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AlertCriterion left, Azure.ResourceManager.CostManagement.Models.AlertCriterion right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertCriterion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertCriterion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AlertCriterion left, Azure.ResourceManager.CostManagement.Models.AlertCriterion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertPropertiesDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition>
    {
        public AlertPropertiesDefinition() { }
        public Azure.ResourceManager.CostManagement.Models.CostManagementAlertType? AlertType { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory? Category { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertCriterion? Criteria { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertPropertiesDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails>
    {
        public AlertPropertiesDetails() { }
        public decimal? Amount { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ContactEmails { get { throw null; } }
        public System.Collections.Generic.IList<string> ContactGroups { get { throw null; } }
        public System.Collections.Generic.IList<string> ContactRoles { get { throw null; } }
        public decimal? CurrentSpend { get { throw null; } set { } }
        public string DepartmentName { get { throw null; } set { } }
        public string EnrollmentEndDate { get { throw null; } set { } }
        public string EnrollmentNumber { get { throw null; } set { } }
        public string EnrollmentStartDate { get { throw null; } set { } }
        public decimal? InvoicingThreshold { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> MeterFilter { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator? Operator { get { throw null; } set { } }
        public string OverridingAlert { get { throw null; } set { } }
        public string PeriodStartDate { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> ResourceFilter { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> ResourceGroupFilter { get { throw null; } }
        public System.BinaryData TagFilter { get { throw null; } set { } }
        public decimal? Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType? TimeGrainType { get { throw null; } set { } }
        public string TriggeredBy { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertTimeGrainType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertTimeGrainType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType Annually { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType BillingAnnual { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType BillingMonth { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType BillingQuarter { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType Monthly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType None { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType Quarterly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType left, Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType left, Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AllSavingsBenefitDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails>
    {
        public AllSavingsBenefitDetails() { }
        public decimal? AverageUtilizationPercentage { get { throw null; } }
        public decimal? BenefitCost { get { throw null; } }
        public decimal? CommitmentAmount { get { throw null; } }
        public decimal? CoveragePercentage { get { throw null; } }
        public decimal? OverageCost { get { throw null; } }
        public decimal? SavingsAmount { get { throw null; } }
        public decimal? SavingsPercentage { get { throw null; } }
        public decimal? TotalCost { get { throw null; } }
        public decimal? WastageCost { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AllSavingsList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AllSavingsList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AllSavingsList>
    {
        internal AllSavingsList() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.AllSavingsList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.AllSavingsList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.AllSavingsList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AllSavingsList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AllSavingsList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.AllSavingsList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AllSavingsList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AllSavingsList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AllSavingsList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmCostManagementModelFactory
    {
        public static Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails AlertPropertiesDetails(Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType? timeGrainType = default(Azure.ResourceManager.CostManagement.Models.AlertTimeGrainType?), string periodStartDate = null, string triggeredBy = null, System.Collections.Generic.IEnumerable<System.BinaryData> resourceGroupFilter = null, System.Collections.Generic.IEnumerable<System.BinaryData> resourceFilter = null, System.Collections.Generic.IEnumerable<System.BinaryData> meterFilter = null, System.BinaryData tagFilter = null, decimal? threshold = default(decimal?), Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator? @operator = default(Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator?), decimal? amount = default(decimal?), string unit = null, decimal? currentSpend = default(decimal?), System.Collections.Generic.IEnumerable<string> contactEmails = null, System.Collections.Generic.IEnumerable<string> contactGroups = null, System.Collections.Generic.IEnumerable<string> contactRoles = null, string overridingAlert = null, string departmentName = null, string companyName = null, string enrollmentNumber = null, string enrollmentStartDate = null, string enrollmentEndDate = null, decimal? invoicingThreshold = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails AllSavingsBenefitDetails(decimal? overageCost = default(decimal?), decimal? benefitCost = default(decimal?), decimal? totalCost = default(decimal?), decimal? savingsAmount = default(decimal?), decimal? savingsPercentage = default(decimal?), decimal? coveragePercentage = default(decimal?), decimal? commitmentAmount = default(decimal?), decimal? averageUtilizationPercentage = default(decimal?), decimal? wastageCost = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AllSavingsList AllSavingsList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties AsyncOperationStatusProperties(Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema? reportUri = default(Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema?), Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema? secondaryReportUri = default(Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BenefitDetails BenefitDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind? kind = default(Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel BenefitRecommendationModel(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties properties = null, Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind? kind = default(Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties BenefitRecommendationProperties(System.DateTimeOffset? firstConsumptionOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastConsumptionOn = default(System.DateTimeOffset?), Azure.ResourceManager.CostManagement.Models.LookBackPeriod? lookBackPeriod = default(Azure.ResourceManager.CostManagement.Models.LookBackPeriod?), int? totalHours = default(int?), Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails usage = null, string armSkuName = null, Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm? term = default(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm?), Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain? commitmentGranularity = default(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain?), string currencyCode = null, decimal? costWithoutBenefit = default(decimal?), Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails recommendationDetails = null, Azure.ResourceManager.CostManagement.Models.AllSavingsList allRecommendationDetails = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus BenefitUtilizationSummariesOperationStatus(Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent input = null, Azure.ResourceManager.CostManagement.Models.OperationStatusType? status = default(Azure.ResourceManager.CostManagement.Models.OperationStatusType?), Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary BenefitUtilizationSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression BudgetComparisonExpression(string name = null, Azure.ResourceManager.CostManagement.Models.BudgetOperatorType @operator = default(Azure.ResourceManager.CostManagement.Models.BudgetOperatorType), System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.BudgetData BudgetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CostManagement.Models.CategoryType? budgetCategory = default(Azure.ResourceManager.CostManagement.Models.CategoryType?), float? amount = default(float?), Azure.ResourceManager.CostManagement.Models.TimeGrainType? budgetTimeGrain = default(Azure.ResourceManager.CostManagement.Models.TimeGrainType?), Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod timePeriod = null, Azure.ResourceManager.CostManagement.Models.BudgetFilter filter = null, Azure.ResourceManager.CostManagement.Models.CurrentSpend currentSpend = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CostManagement.Models.BudgetNotification> notifications = null, Azure.ResourceManager.CostManagement.Models.ForecastSpend forecastSpend = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BudgetFilter BudgetFilter(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties> and = null, Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression dimensions = null, Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression tags = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BudgetNotification BudgetNotification(bool enabled = false, Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType @operator = default(Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType), float threshold = 0f, Azure.ResourceManager.CostManagement.Models.Frequency? frequency = default(Azure.ResourceManager.CostManagement.Models.Frequency?), System.Collections.Generic.IEnumerable<string> contactEmails = null, System.Collections.Generic.IEnumerable<string> contactRoles = null, System.Collections.Generic.IEnumerable<string> contactGroups = null, Azure.ResourceManager.CostManagement.Models.ThresholdType? thresholdType = default(Azure.ResourceManager.CostManagement.Models.ThresholdType?), Azure.ResourceManager.CostManagement.Models.CultureCode? locale = default(Azure.ResourceManager.CostManagement.Models.CultureCode?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CommonExportProperties CommonExportProperties(Azure.ResourceManager.CostManagement.Models.ExportFormatType? format = default(Azure.ResourceManager.CostManagement.Models.ExportFormatType?), Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination deliveryInfoDestination = null, Azure.ResourceManager.CostManagement.Models.ExportDefinition definition = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ExportRun> runHistoryValue = null, bool? partitionData = default(bool?), Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType? dataOverwriteBehavior = default(Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType?), Azure.ResourceManager.CostManagement.Models.CompressionModeType? compressionMode = default(Azure.ResourceManager.CostManagement.Models.CompressionModeType?), string exportDescription = null, System.DateTimeOffset? nextRunTimeEstimate = default(System.DateTimeOffset?), Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext systemSuspensionContext = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CommonExportProperties CommonExportProperties(Azure.ResourceManager.CostManagement.Models.ExportFormatType? format, Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination deliveryInfoDestination, Azure.ResourceManager.CostManagement.Models.ExportDefinition definition, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ExportRun> runHistoryValue, bool? partitionData, System.DateTimeOffset? nextRunTimeEstimate) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostAllocationRuleData CostAllocationRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails CostAllocationRuleDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity> sourceResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity> targetResources = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties CostAllocationRuleProperties(string description = null, Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails details = null, Azure.ResourceManager.CostManagement.Models.RuleStatus status = default(Azure.ResourceManager.CostManagement.Models.RuleStatus), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults CostDetailsOperationResults(string id = null, string name = null, string type = null, Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType? status = default(Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType?), string manifestVersion = null, Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat? dataFormat = default(Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat?), long? byteCount = default(long?), int? blobCount = default(int?), bool? compressData = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ExportBlobInfo> blobs = null, string requestScope = null, Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent requestBody = null, System.DateTimeOffset? validTill = default(System.DateTimeOffset?), Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails error = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementAlertData CostManagementAlertData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition definition = null, string description = null, Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource? source = default(Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource?), Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails details = null, string costEntityId = null, Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus? status = default(Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? closeOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string statusModificationUserName = null, System.DateTimeOffset? statusModifiedOn = default(System.DateTimeOffset?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementDimension CostManagementDimension(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, bool? isFilterEnabled = default(bool?), bool? isGroupingEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> data = null, int? total = default(int?), string category = null, System.DateTimeOffset? usageStart = default(System.DateTimeOffset?), System.DateTimeOffset? usageEnd = default(System.DateTimeOffset?), string nextLink = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string sku = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementExportData CostManagementExportData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CostManagement.Models.ExportFormatType? format = default(Azure.ResourceManager.CostManagement.Models.ExportFormatType?), Azure.ResourceManager.CostManagement.Models.ExportDefinition definition = null, bool? partitionData = default(bool?), Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType? dataOverwriteBehavior = default(Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType?), Azure.ResourceManager.CostManagement.Models.CompressionModeType? compressionMode = default(Azure.ResourceManager.CostManagement.Models.CompressionModeType?), string exportDescription = null, System.DateTimeOffset? nextRunTimeEstimate = default(System.DateTimeOffset?), Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext systemSuspensionContext = null, Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination deliveryInfoDestination = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ExportRun> runHistoryValue = null, Azure.ResourceManager.CostManagement.Models.ExportSchedule schedule = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string location = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementExportData CostManagementExportData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.CostManagement.Models.ExportFormatType? format, Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination deliveryInfoDestination, Azure.ResourceManager.CostManagement.Models.ExportDefinition definition, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ExportRun> runHistoryValue, bool? partitionData, System.DateTimeOffset? nextRunTimeEstimate, Azure.ResourceManager.CostManagement.Models.ExportSchedule schedule, Azure.ETag? eTag) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult CostManagementNameAvailabilityResult(bool? nameAvailable = default(bool?), Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason? reason = default(Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementSettingData CostManagementSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.CostManagementViewData CostManagementViewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.Core.ResourceIdentifier scope = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string dateRange = null, string currency = null, Azure.ResourceManager.CostManagement.Models.ViewChartType? chart = default(Azure.ResourceManager.CostManagement.Models.ViewChartType?), Azure.ResourceManager.CostManagement.Models.AccumulatedType? accumulated = default(Azure.ResourceManager.CostManagement.Models.AccumulatedType?), Azure.ResourceManager.CostManagement.Models.ViewMetricType? metric = default(Azure.ResourceManager.CostManagement.Models.ViewMetricType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ViewKpiProperties> kpis = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ViewPivotProperties> pivots = null, Azure.ResourceManager.CostManagement.Models.ViewReportType? typePropertiesQueryType = default(Azure.ResourceManager.CostManagement.Models.ViewReportType?), Azure.ResourceManager.CostManagement.Models.ReportTimeframeType? timeframe = default(Azure.ResourceManager.CostManagement.Models.ReportTimeframeType?), Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod timePeriod = null, Azure.ResourceManager.CostManagement.Models.ReportConfigDataset dataSet = null, bool? includeMonetaryCommitment = default(bool?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CurrentSpend CurrentSpend(float? amount = default(float?), string unit = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.DownloadURL DownloadURL(System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), System.DateTimeOffset? validTill = default(System.DateTimeOffset?), System.Uri downloadUri = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ErrorDetailsWithNestedDetails ErrorDetailsWithNestedDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportBlobInfo ExportBlobInfo(string blobLink = null, long? byteCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportProperties ExportProperties(Azure.ResourceManager.CostManagement.Models.ExportFormatType? format = default(Azure.ResourceManager.CostManagement.Models.ExportFormatType?), Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination deliveryInfoDestination = null, Azure.ResourceManager.CostManagement.Models.ExportDefinition definition = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ExportRun> runHistoryValue = null, bool? partitionData = default(bool?), Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType? dataOverwriteBehavior = default(Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType?), Azure.ResourceManager.CostManagement.Models.CompressionModeType? compressionMode = default(Azure.ResourceManager.CostManagement.Models.CompressionModeType?), string exportDescription = null, System.DateTimeOffset? nextRunTimeEstimate = default(System.DateTimeOffset?), Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext systemSuspensionContext = null, Azure.ResourceManager.CostManagement.Models.ExportSchedule schedule = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportRun ExportRun(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType? executionType = default(Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType?), Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus? status = default(Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus?), string submittedBy = null, System.DateTimeOffset? submittedOn = default(System.DateTimeOffset?), System.DateTimeOffset? processingStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? processingEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string fileName = null, string manifestFile = null, Azure.ResourceManager.CostManagement.Models.CommonExportProperties runSettings = null, Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails error = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportRun ExportRun(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType? executionType, Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus? status, string submittedBy, System.DateTimeOffset? submittedOn, System.DateTimeOffset? processingStartOn, System.DateTimeOffset? processingEndOn, string fileName, Azure.ResourceManager.CostManagement.Models.CommonExportProperties runSettings, Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails error, Azure.ETag? eTag) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails ExportRunErrorDetails(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext ExportSuspensionContext(string suspensionCode = null, string suspensionReason = null, System.DateTimeOffset? suspensionOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastAggregation ForecastAggregation(Azure.ResourceManager.CostManagement.Models.FunctionName name = default(Azure.ResourceManager.CostManagement.Models.FunctionName), Azure.ResourceManager.CostManagement.Models.FunctionType function = default(Azure.ResourceManager.CostManagement.Models.FunctionType)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastColumn ForecastColumn(string name = null, string forecastColumnType = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression ForecastComparisonExpression(string name = null, Azure.ResourceManager.CostManagement.Models.ForecastOperatorType @operator = default(Azure.ResourceManager.CostManagement.Models.ForecastOperatorType), System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastDataset ForecastDataset(Azure.ResourceManager.CostManagement.Models.GranularityType? granularity = default(Azure.ResourceManager.CostManagement.Models.GranularityType?), System.Collections.Generic.IEnumerable<string> columns = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CostManagement.Models.ForecastAggregation> aggregation = null, Azure.ResourceManager.CostManagement.Models.ForecastFilter filter = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastDefinition ForecastDefinition(Azure.ResourceManager.CostManagement.Models.ForecastType forecastType = default(Azure.ResourceManager.CostManagement.Models.ForecastType), Azure.ResourceManager.CostManagement.Models.ForecastTimeframe timeframe = default(Azure.ResourceManager.CostManagement.Models.ForecastTimeframe), Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod timePeriod = null, Azure.ResourceManager.CostManagement.Models.ForecastDataset dataset = null, bool? includeActualCost = default(bool?), bool? includeFreshPartialCost = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastFilter ForecastFilter(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ForecastFilter> and = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ForecastFilter> or = null, Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression dimensions = null, Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression tags = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastResult ForecastResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string nextLink = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ForecastColumn> columns = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.BinaryData>> rows = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string sku = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastSpend ForecastSpend(float? amount = default(float?), string unit = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod ForecastTimePeriod(System.DateTimeOffset from = default(System.DateTimeOffset), System.DateTimeOffset to = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationResultData GenerateDetailedCostReportOperationResultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), System.DateTimeOffset? validTill = default(System.DateTimeOffset?), System.Uri downloadUri = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.GenerateDetailedCostReportOperationStatusesData GenerateDetailedCostReportOperationStatusesData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), System.DateTimeOffset? validTill = default(System.DateTimeOffset?), System.Uri downloadUri = null, Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType? statusValue = default(Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType?), string startTime = null, string endTime = null, Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails error = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod GenerateDetailedCostReportTimePeriod(string start = null, string end = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.IncludedQuantityUtilizationSummary IncludedQuantityUtilizationSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string armSkuName = null, string benefitId = null, string benefitOrderId = null, Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind? benefitType = default(Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind?), System.DateTimeOffset? usageOn = default(System.DateTimeOffset?), decimal? utilizationPercentage = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties McaPriceSheetProperties(string billingAccountID = null, string billingAccountName = null, string billingProfileId = null, string billingProfileName = null, string productOrderName = null, float? serviceFamily = default(float?), string product = null, string productId = null, string skuId = null, string unitOfMeasure = null, string meterId = null, string meterName = null, string meterType = null, string meterCategory = null, string meterSubCategory = null, string meterRegion = null, string tierMinimumUnits = null, System.DateTimeOffset? effectiveStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? effectiveEndOn = default(System.DateTimeOffset?), string unitPrice = null, string basePrice = null, string marketPrice = null, string currency = null, string billingCurrency = null, string term = null, string priceType = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.NotificationProperties NotificationProperties(System.Collections.Generic.IEnumerable<string> to = null, string language = null, string message = null, string regionalFormat = null, string subject = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.OperationStatus OperationStatus(Azure.ResourceManager.CostManagement.Models.OperationStatusType? status = default(Azure.ResourceManager.CostManagement.Models.OperationStatusType?), Azure.ResourceManager.CostManagement.Models.ReservationReportSchema? reportUri = default(Azure.ResourceManager.CostManagement.Models.ReservationReportSchema?), System.DateTimeOffset? validUntil = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties PriceSheetDownloadProperties(System.DateTimeOffset? expiryOn = default(System.DateTimeOffset?), string downloadUri = null, Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties downloadFileProperties = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryAggregation QueryAggregation(string name = null, Azure.ResourceManager.CostManagement.Models.FunctionType function = default(Azure.ResourceManager.CostManagement.Models.FunctionType)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryColumn QueryColumn(string name = null, string queryColumnType = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression QueryComparisonExpression(string name = null, Azure.ResourceManager.CostManagement.Models.QueryOperatorType @operator = default(Azure.ResourceManager.CostManagement.Models.QueryOperatorType), System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryDataset QueryDataset(Azure.ResourceManager.CostManagement.Models.GranularityType? granularity = default(Azure.ResourceManager.CostManagement.Models.GranularityType?), System.Collections.Generic.IEnumerable<string> columns = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CostManagement.Models.QueryAggregation> aggregation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.QueryGrouping> grouping = null, Azure.ResourceManager.CostManagement.Models.QueryFilter filter = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryDefinition QueryDefinition(Azure.ResourceManager.CostManagement.Models.ExportType exportType = default(Azure.ResourceManager.CostManagement.Models.ExportType), Azure.ResourceManager.CostManagement.Models.TimeframeType timeframe = default(Azure.ResourceManager.CostManagement.Models.TimeframeType), Azure.ResourceManager.CostManagement.Models.QueryTimePeriod timePeriod = null, Azure.ResourceManager.CostManagement.Models.QueryDataset dataset = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryFilter QueryFilter(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.QueryFilter> and = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.QueryFilter> or = null, Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression dimensions = null, Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression tags = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryGrouping QueryGrouping(Azure.ResourceManager.CostManagement.Models.QueryColumnType columnType = default(Azure.ResourceManager.CostManagement.Models.QueryColumnType), string name = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryResult QueryResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string nextLink = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.QueryColumn> columns = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<System.BinaryData>> rows = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string sku = null, Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryTimePeriod QueryTimePeriod(System.DateTimeOffset from = default(System.DateTimeOffset), System.DateTimeOffset to = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails RecommendationUsageDetails(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain? usageGrain = default(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain?), System.Collections.Generic.IEnumerable<decimal> charges = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression ReportConfigComparisonExpression(string name = null, Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType @operator = default(Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType), System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportConfigDataset ReportConfigDataset(Azure.ResourceManager.CostManagement.Models.ReportGranularityType? granularity = default(Azure.ResourceManager.CostManagement.Models.ReportGranularityType?), System.Collections.Generic.IEnumerable<string> columns = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation> aggregation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping> grouping = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ReportConfigSorting> sorting = null, Azure.ResourceManager.CostManagement.Models.ReportConfigFilter filter = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportConfigFilter ReportConfigFilter(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter> and = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter> or = null, Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression dimensions = null, Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression tags = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.SavingsPlanUtilizationSummary SavingsPlanUtilizationSummary(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string armSkuName = null, string benefitId = null, string benefitOrderId = null, Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind? benefitType = default(Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind?), System.DateTimeOffset? usageOn = default(System.DateTimeOffset?), decimal? avgUtilizationPercentage = default(decimal?), decimal? minUtilizationPercentage = default(decimal?), decimal? maxUtilizationPercentage = default(decimal?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.ScheduledActionData ScheduledActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.ResourceManager.CostManagement.Models.NotificationProperties notification = null, string notificationEmail = null, Azure.ResourceManager.CostManagement.Models.ScheduleProperties schedule = null, Azure.Core.ResourceIdentifier scope = null, Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus? status = default(Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus?), Azure.Core.ResourceIdentifier viewId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat> fileFormats = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.CostManagement.Models.ScheduledActionKind? kind = default(Azure.ResourceManager.CostManagement.Models.ScheduledActionKind?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.ScheduledActionData ScheduledActionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string displayName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat> fileFormats, Azure.ResourceManager.CostManagement.Models.NotificationProperties notification, string notificationEmail, Azure.ResourceManager.CostManagement.Models.ScheduleProperties schedule, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus? status, Azure.Core.ResourceIdentifier viewId, Azure.ETag? eTag, Azure.ResourceManager.CostManagement.Models.ScheduledActionKind? kind) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ScheduleProperties ScheduleProperties(Azure.ResourceManager.CostManagement.Models.ScheduleFrequency frequency = default(Azure.ResourceManager.CostManagement.Models.ScheduleFrequency), int? hourOfDay = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek> daysOfWeek = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth> weeksOfMonth = null, int? dayOfMonth = default(int?), System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset endOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.SharedScopeBenefitRecommendationProperties SharedScopeBenefitRecommendationProperties(System.DateTimeOffset? firstConsumptionOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastConsumptionOn = default(System.DateTimeOffset?), Azure.ResourceManager.CostManagement.Models.LookBackPeriod? lookBackPeriod = default(Azure.ResourceManager.CostManagement.Models.LookBackPeriod?), int? totalHours = default(int?), Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails usage = null, string armSkuName = null, Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm? term = default(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm?), Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain? commitmentGranularity = default(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain?), string currencyCode = null, decimal? costWithoutBenefit = default(decimal?), Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails recommendationDetails = null, Azure.ResourceManager.CostManagement.Models.AllSavingsList allRecommendationDetails = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.SingleScopeBenefitRecommendationProperties SingleScopeBenefitRecommendationProperties(System.DateTimeOffset? firstConsumptionOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastConsumptionOn = default(System.DateTimeOffset?), Azure.ResourceManager.CostManagement.Models.LookBackPeriod? lookBackPeriod = default(Azure.ResourceManager.CostManagement.Models.LookBackPeriod?), int? totalHours = default(int?), Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails usage = null, string armSkuName = null, Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm? term = default(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm?), Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain? commitmentGranularity = default(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain?), string currencyCode = null, decimal? costWithoutBenefit = default(decimal?), Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails recommendationDetails = null, Azure.ResourceManager.CostManagement.Models.AllSavingsList allRecommendationDetails = null, string subscriptionId = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity SourceCostAllocationEntity(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType resourceType = default(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType), string name = null, System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.TagInheritanceSetting TagInheritanceSetting(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? preferContainerTags = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity TargetCostAllocationEntity(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType resourceType = default(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType), string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.CostAllocationProportion> values = null, Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType policyType = default(Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType)) { throw null; }
    }
    public partial class AsyncOperationStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties>
    {
        internal AsyncOperationStatusProperties() { }
        public Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema? ReportUri { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema? SecondaryReportUri { get { throw null; } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BenefitDetails : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitDetails>
    {
        public BenefitDetails() { }
        public Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind? Kind { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BenefitDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BenefitDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BenefitRecommendationModel : Azure.ResourceManager.CostManagement.Models.BenefitDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel>
    {
        public BenefitRecommendationModel() { }
        public Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties Properties { get { throw null; } set { } }
        protected override Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BenefitRecommendationPeriodTerm : System.IEquatable<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BenefitRecommendationPeriodTerm(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm P1Y { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm P3Y { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm left, Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm left, Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class BenefitRecommendationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties>
    {
        protected BenefitRecommendationProperties() { }
        public Azure.ResourceManager.CostManagement.Models.AllSavingsList AllRecommendationDetails { get { throw null; } }
        public string ArmSkuName { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain? CommitmentGranularity { get { throw null; } set { } }
        public decimal? CostWithoutBenefit { get { throw null; } }
        public string CurrencyCode { get { throw null; } }
        public System.DateTimeOffset? FirstConsumptionOn { get { throw null; } }
        public System.DateTimeOffset? LastConsumptionOn { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.LookBackPeriod? LookBackPeriod { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AllSavingsBenefitDetails RecommendationDetails { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.BenefitRecommendationPeriodTerm? Term { get { throw null; } set { } }
        public int? TotalHours { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails Usage { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BenefitRecommendationUsageGrain : System.IEquatable<Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BenefitRecommendationUsageGrain(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain Hourly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain Monthly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain left, Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain left, Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BenefitUtilizationSummariesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent>
    {
        public BenefitUtilizationSummariesContent(Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain grain, System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public string BenefitId { get { throw null; } set { } }
        public string BenefitOrderId { get { throw null; } set { } }
        public string BillingAccountId { get { throw null; } set { } }
        public string BillingProfileId { get { throw null; } set { } }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain Grain { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind? Kind { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BenefitUtilizationSummariesOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>
    {
        internal BenefitUtilizationSummariesOperationStatus() { }
        public Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesContent Input { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.AsyncOperationStatusProperties Properties { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.OperationStatusType? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummariesOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BenefitUtilizationSummary : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary>
    {
        public BenefitUtilizationSummary() { }
        public BenefitUtilizationSummary(Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind kind) { }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BenefitUtilizationSummaryReportSchema : System.IEquatable<Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BenefitUtilizationSummaryReportSchema(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema AvgUtilizationPercentage { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema BenefitId { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema BenefitOrderId { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema BenefitType { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema Kind { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema MaxUtilizationPercentage { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema MinUtilizationPercentage { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema UsageDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema UtilizedPercentage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema left, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema left, Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummaryReportSchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingAccountBenefitKind : System.IEquatable<Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingAccountBenefitKind(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind IncludedQuantity { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind Reservation { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind SavingsPlan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind left, Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind left, Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BudgetComparisonExpression : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression>
    {
        public BudgetComparisonExpression(string name, Azure.ResourceManager.CostManagement.Models.BudgetOperatorType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.BudgetOperatorType Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BudgetFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetFilter>
    {
        public BudgetFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties> And { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.BudgetFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.BudgetFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BudgetFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BudgetFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BudgetFilterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties>
    {
        public BudgetFilterProperties() { }
        public Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression Dimensions { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.BudgetComparisonExpression Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetFilterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BudgetNotification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetNotification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetNotification>
    {
        public BudgetNotification(bool enabled, Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType @operator, float threshold, System.Collections.Generic.IEnumerable<string> contactEmails) { }
        public System.Collections.Generic.IList<string> ContactEmails { get { throw null; } }
        public System.Collections.Generic.IList<string> ContactGroups { get { throw null; } }
        public System.Collections.Generic.IList<string> ContactRoles { get { throw null; } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.Frequency? Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CultureCode? Locale { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType Operator { get { throw null; } set { } }
        public float Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ThresholdType? ThresholdType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.BudgetNotification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.BudgetNotification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BudgetNotification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetNotification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetNotification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BudgetNotification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetNotification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetNotification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetNotification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BudgetNotificationOperatorType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BudgetNotificationOperatorType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType EqualTo { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType GreaterThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType LessThan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType left, Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType left, Azure.ResourceManager.CostManagement.Models.BudgetNotificationOperatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BudgetOperatorType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.BudgetOperatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BudgetOperatorType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.BudgetOperatorType In { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.BudgetOperatorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.BudgetOperatorType left, Azure.ResourceManager.CostManagement.Models.BudgetOperatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BudgetOperatorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.BudgetOperatorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.BudgetOperatorType left, Azure.ResourceManager.CostManagement.Models.BudgetOperatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BudgetTimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod>
    {
        public BudgetTimePeriod(System.DateTimeOffset startOn) { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.BudgetTimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CategoryType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CategoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CategoryType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CategoryType Cost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CategoryType ReservationUtilization { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CategoryType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CategoryType left, Azure.ResourceManager.CostManagement.Models.CategoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CategoryType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CategoryType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CategoryType left, Azure.ResourceManager.CostManagement.Models.CategoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommonExportProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CommonExportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CommonExportProperties>
    {
        public CommonExportProperties(Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination deliveryInfoDestination, Azure.ResourceManager.CostManagement.Models.ExportDefinition definition) { }
        public CommonExportProperties(Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo deliveryInfo, Azure.ResourceManager.CostManagement.Models.ExportDefinition definition) { }
        public Azure.ResourceManager.CostManagement.Models.CompressionModeType? CompressionMode { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType? DataOverwriteBehavior { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportDefinition Definition { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination DeliveryInfoDestination { get { throw null; } set { } }
        public string ExportDescription { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportFormatType? Format { get { throw null; } set { } }
        public System.DateTimeOffset? NextRunTimeEstimate { get { throw null; } }
        public bool? PartitionData { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement.Models.ExportRun> RunHistoryValue { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext SystemSuspensionContext { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CommonExportProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CommonExportProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CommonExportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CommonExportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CommonExportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CommonExportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CommonExportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CommonExportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CommonExportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComparisonOperatorType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComparisonOperatorType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType Contains { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType In { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType left, Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType left, Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompressionModeType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CompressionModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompressionModeType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CompressionModeType Gzip { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CompressionModeType None { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CompressionModeType Snappy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CompressionModeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CompressionModeType left, Azure.ResourceManager.CostManagement.Models.CompressionModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CompressionModeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CompressionModeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CompressionModeType left, Azure.ResourceManager.CostManagement.Models.CompressionModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CostAllocationEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationEntity>
    {
        public CostAllocationEntity(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType resourceType, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostAllocationEntity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostAllocationEntity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CostAllocationEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CostAllocationEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostAllocationPolicyType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostAllocationPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType FixedProportion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType left, Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType left, Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CostAllocationProportion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationProportion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationProportion>
    {
        public CostAllocationProportion(string name, float percentage) { }
        public string Name { get { throw null; } set { } }
        public float Percentage { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostAllocationProportion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostAllocationProportion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CostAllocationProportion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationProportion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationProportion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CostAllocationProportion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationProportion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationProportion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationProportion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostAllocationResourceType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostAllocationResourceType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType Dimension { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType Tag { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType left, Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType left, Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CostAllocationRuleDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails>
    {
        public CostAllocationRuleDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity> SourceResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity> TargetResources { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CostAllocationRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties>
    {
        public CostAllocationRuleProperties(Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails details, Azure.ResourceManager.CostManagement.Models.RuleStatus status) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CostAllocationRuleDetails Details { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.RuleStatus Status { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostAllocationRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostDetailsDataFormat : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostDetailsDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat CsvCostDetailsDataFormat { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat left, Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat left, Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostDetailsMetricType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostDetailsMetricType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType ActualCostCostDetailsMetricType { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType AmortizedCostCostDetailsMetricType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType left, Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType left, Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CostDetailsOperationResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>
    {
        internal CostDetailsOperationResults() { }
        public int? BlobCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ExportBlobInfo> Blobs { get { throw null; } }
        public long? ByteCount { get { throw null; } }
        public bool? CompressData { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.CostDetailsDataFormat? DataFormat { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string ManifestVersion { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent RequestBody { get { throw null; } }
        public string RequestScope { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType? Status { get { throw null; } }
        public string Type { get { throw null; } }
        public System.DateTimeOffset? ValidTill { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostDetailsOperationResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostDetailsStatusType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostDetailsStatusType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType CompletedCostDetailsStatusType { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType FailedCostDetailsStatusType { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType NoDataFoundCostDetailsStatusType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType left, Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType left, Azure.ResourceManager.CostManagement.Models.CostDetailsStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CostDetailsTimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod>
    {
        public CostDetailsTimePeriod(string start, string end) { }
        public string End { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostManagementAlertCategory : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostManagementAlertCategory(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory Billing { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory Cost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory System { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory Usage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory left, Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory left, Azure.ResourceManager.CostManagement.Models.CostManagementAlertCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostManagementAlertOperator : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostManagementAlertOperator(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator EqualTo { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator GreaterThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator LessThanOrEqualTo { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator left, Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator left, Azure.ResourceManager.CostManagement.Models.CostManagementAlertOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CostManagementAlertPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch>
    {
        public CostManagementAlertPatch() { }
        public System.DateTimeOffset? CloseOn { get { throw null; } set { } }
        public string CostEntityId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertPropertiesDefinition Definition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.AlertPropertiesDetails Details { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource? Source { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus? Status { get { throw null; } set { } }
        public string StatusModificationUserName { get { throw null; } set { } }
        public System.DateTimeOffset? StatusModifiedOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementAlertPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostManagementAlertSource : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostManagementAlertSource(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource Preset { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource left, Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource left, Azure.ResourceManager.CostManagement.Models.CostManagementAlertSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostManagementAlertStatus : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostManagementAlertStatus(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus Active { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus Dismissed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus None { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus Overridden { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus Resolved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus left, Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus left, Azure.ResourceManager.CostManagement.Models.CostManagementAlertStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostManagementAlertType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostManagementAlertType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostManagementAlertType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertType Budget { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertType BudgetForecast { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertType Credit { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertType General { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertType Invoice { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertType Quota { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementAlertType XCloud { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostManagementAlertType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostManagementAlertType left, Azure.ResourceManager.CostManagement.Models.CostManagementAlertType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementAlertType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementAlertType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostManagementAlertType left, Azure.ResourceManager.CostManagement.Models.CostManagementAlertType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CostManagementDimension : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementDimension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementDimension>
    {
        internal CostManagementDimension() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Data { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? IsFilterEnabled { get { throw null; } }
        public bool? IsGroupingEnabled { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string NextLink { get { throw null; } }
        public string Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public int? Total { get { throw null; } }
        public System.DateTimeOffset? UsageEnd { get { throw null; } }
        public System.DateTimeOffset? UsageStart { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CostManagementDimension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementDimension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementDimension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CostManagementDimension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementDimension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementDimension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementDimension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CostManagementNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent>
    {
        public CostManagementNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CostManagementNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>
    {
        internal CostManagementNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CostManagementNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostManagementSettingType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostManagementSettingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostManagementSettingType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementSettingType Taginheritance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostManagementSettingType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostManagementSettingType left, Azure.ResourceManager.CostManagement.Models.CostManagementSettingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementSettingType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementSettingType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostManagementSettingType left, Azure.ResourceManager.CostManagement.Models.CostManagementSettingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostManagementUnavailabilityReason : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostManagementUnavailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason left, Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason left, Azure.ResourceManager.CostManagement.Models.CostManagementUnavailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CultureCode : System.IEquatable<Azure.ResourceManager.CostManagement.Models.CultureCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CultureCode(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode CsCz { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode DaDk { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode DeDe { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode EnGb { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode EnUs { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode EsEs { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode FrFr { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode HuHu { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode ItIt { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode JaJp { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode KoKr { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode NbNo { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode NlNl { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode PlPl { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode PtBr { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode PtPt { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode RuRu { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode SvSe { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode TrTr { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode ZhCn { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.CultureCode ZhTw { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.CultureCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.CultureCode left, Azure.ResourceManager.CostManagement.Models.CultureCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CultureCode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.CultureCode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.CultureCode left, Azure.ResourceManager.CostManagement.Models.CultureCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CurrentSpend : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CurrentSpend>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CurrentSpend>
    {
        internal CurrentSpend() { }
        public float? Amount { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.CurrentSpend JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.CurrentSpend PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.CurrentSpend System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CurrentSpend>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.CurrentSpend>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.CurrentSpend System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CurrentSpend>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CurrentSpend>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.CurrentSpend>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataOverwriteBehaviorType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataOverwriteBehaviorType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType CreateNewReport { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType OverwritePreviousReport { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType left, Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType left, Azure.ResourceManager.CostManagement.Models.DataOverwriteBehaviorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DestinationType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.DestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DestinationType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.DestinationType AzureBlob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.DestinationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.DestinationType left, Azure.ResourceManager.CostManagement.Models.DestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.DestinationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.DestinationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.DestinationType left, Azure.ResourceManager.CostManagement.Models.DestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DownloadURL : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.DownloadURL>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.DownloadURL>
    {
        internal DownloadURL() { }
        public System.Uri DownloadUri { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public System.DateTimeOffset? ValidTill { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.DownloadURL JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.DownloadURL PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.DownloadURL System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.DownloadURL>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.DownloadURL>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.DownloadURL System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.DownloadURL>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.DownloadURL>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.DownloadURL>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDetailsWithNestedDetails : Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ErrorDetailsWithNestedDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ErrorDetailsWithNestedDetails>
    {
        internal ErrorDetailsWithNestedDetails() { }
        protected override Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ErrorDetailsWithNestedDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ErrorDetailsWithNestedDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ErrorDetailsWithNestedDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ErrorDetailsWithNestedDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ErrorDetailsWithNestedDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ErrorDetailsWithNestedDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ErrorDetailsWithNestedDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportBlobInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportBlobInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportBlobInfo>
    {
        internal ExportBlobInfo() { }
        public string BlobLink { get { throw null; } }
        public long? ByteCount { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportBlobInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportBlobInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportBlobInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportBlobInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportBlobInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportBlobInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportBlobInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportBlobInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportBlobInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDataset>
    {
        public ExportDataset() { }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public string DataVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.FilterItems> Filters { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.GranularityType? Granularity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDefinition>
    {
        public ExportDefinition(Azure.ResourceManager.CostManagement.Models.ExportType exportType, Azure.ResourceManager.CostManagement.Models.TimeframeType timeframe) { }
        public Azure.ResourceManager.CostManagement.Models.ExportDataset DataSet { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportType ExportType { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.TimeframeType Timeframe { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportTimePeriod TimePeriod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportDeliveryDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination>
    {
        public ExportDeliveryDestination(string container) { }
        public string Container { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string RootFolderPath { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public string StorageAccount { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.DestinationType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportDeliveryInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo>
    {
        public ExportDeliveryInfo(Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination destination) { }
        public Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination Destination { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportDeliveryInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportFormatType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ExportFormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportFormatType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportFormatType Csv { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportFormatType Parquet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ExportFormatType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ExportFormatType left, Azure.ResourceManager.CostManagement.Models.ExportFormatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportFormatType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportFormatType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ExportFormatType left, Azure.ResourceManager.CostManagement.Models.ExportFormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportProperties : Azure.ResourceManager.CostManagement.Models.CommonExportProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportProperties>
    {
        public ExportProperties(Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination deliveryInfoDestination, Azure.ResourceManager.CostManagement.Models.ExportDefinition definition) : base (default(Azure.ResourceManager.CostManagement.Models.ExportDeliveryDestination), default(Azure.ResourceManager.CostManagement.Models.ExportDefinition)) { }
        public Azure.ResourceManager.CostManagement.Models.ExportSchedule Schedule { get { throw null; } set { } }
        protected override Azure.ResourceManager.CostManagement.Models.CommonExportProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement.Models.CommonExportProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportRecurrencePeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod>
    {
        public ExportRecurrencePeriod(System.DateTimeOffset from) { }
        public System.DateTimeOffset From { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportRun : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRun>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRun>
    {
        public ExportRun() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails Error { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType? ExecutionType { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public string ManifestFile { get { throw null; } set { } }
        public System.DateTimeOffset? ProcessingEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? ProcessingStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CommonExportProperties RunSettings { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus? Status { get { throw null; } set { } }
        public string SubmittedBy { get { throw null; } set { } }
        public System.DateTimeOffset? SubmittedOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportRun System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportRun System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportRunContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRunContent>
    {
        public ExportRunContent() { }
        public Azure.ResourceManager.CostManagement.Models.ExportTimePeriod TimePeriod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportRunContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportRunContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportRunErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails>
    {
        public ExportRunErrorDetails() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportRunErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportRunExecutionStatus : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportRunExecutionStatus(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus DataNotAvailable { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus NewDataNotAvailable { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus left, Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus left, Azure.ResourceManager.CostManagement.Models.ExportRunExecutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportRunExecutionType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportRunExecutionType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType OnDemand { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType left, Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType left, Azure.ResourceManager.CostManagement.Models.ExportRunExecutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportSchedule>
    {
        public ExportSchedule() { }
        public Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType? Recurrence { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportRecurrencePeriod RecurrencePeriod { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportScheduleRecurrenceType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportScheduleRecurrenceType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType Annually { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType Monthly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType left, Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType left, Azure.ResourceManager.CostManagement.Models.ExportScheduleRecurrenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportScheduleStatusType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportScheduleStatusType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType Active { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType left, Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType left, Azure.ResourceManager.CostManagement.Models.ExportScheduleStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportSuspensionContext : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext>
    {
        internal ExportSuspensionContext() { }
        public string SuspensionCode { get { throw null; } }
        public System.DateTimeOffset? SuspensionOn { get { throw null; } }
        public string SuspensionReason { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportSuspensionContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExportTimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportTimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportTimePeriod>
    {
        public ExportTimePeriod(System.DateTimeOffset from, System.DateTimeOffset to) { }
        public System.DateTimeOffset From { get { throw null; } set { } }
        public System.DateTimeOffset To { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportTimePeriod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ExportTimePeriod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ExportTimePeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportTimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ExportTimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ExportTimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportTimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportTimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ExportTimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ExportType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExportType ActualCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportType AmortizedCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportType FocusCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportType PriceSheet { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportType ReservationDetails { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportType ReservationRecommendations { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportType ReservationTransactions { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExportType Usage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ExportType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ExportType left, Azure.ResourceManager.CostManagement.Models.ExportType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExportType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ExportType left, Azure.ResourceManager.CostManagement.Models.ExportType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExternalCloudProviderType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExternalCloudProviderType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType ExternalBillingAccounts { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType ExternalSubscriptions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType left, Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType left, Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilterItemNames : System.IEquatable<Azure.ResourceManager.CostManagement.Models.FilterItemNames>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilterItemNames(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.FilterItemNames LookBackPeriod { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.FilterItemNames ReservationScope { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.FilterItemNames ResourceType { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.FilterItemNames other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.FilterItemNames left, Azure.ResourceManager.CostManagement.Models.FilterItemNames right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.FilterItemNames (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.FilterItemNames? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.FilterItemNames left, Azure.ResourceManager.CostManagement.Models.FilterItemNames right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FilterItems : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.FilterItems>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.FilterItems>
    {
        public FilterItems() { }
        public Azure.ResourceManager.CostManagement.Models.FilterItemNames? Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.FilterItems JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.FilterItems PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.FilterItems System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.FilterItems>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.FilterItems>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.FilterItems System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.FilterItems>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.FilterItems>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.FilterItems>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForecastAggregation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastAggregation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastAggregation>
    {
        public ForecastAggregation(Azure.ResourceManager.CostManagement.Models.FunctionName name, Azure.ResourceManager.CostManagement.Models.FunctionType function) { }
        public Azure.ResourceManager.CostManagement.Models.FunctionType Function { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.FunctionName Name { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastAggregation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastAggregation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ForecastAggregation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastAggregation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastAggregation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ForecastAggregation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastAggregation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastAggregation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastAggregation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForecastColumn : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastColumn>
    {
        internal ForecastColumn() { }
        public string ForecastColumnType { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastColumn JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastColumn PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ForecastColumn System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ForecastColumn System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForecastComparisonExpression : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression>
    {
        public ForecastComparisonExpression(string name, Azure.ResourceManager.CostManagement.Models.ForecastOperatorType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ForecastOperatorType Operator { get { throw null; } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForecastDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastDataset>
    {
        public ForecastDataset(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CostManagement.Models.ForecastAggregation> aggregation) { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CostManagement.Models.ForecastAggregation> Aggregation { get { throw null; } }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ForecastFilter Filter { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.GranularityType? Granularity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ForecastDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ForecastDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForecastDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastDefinition>
    {
        public ForecastDefinition(Azure.ResourceManager.CostManagement.Models.ForecastType forecastType, Azure.ResourceManager.CostManagement.Models.ForecastTimeframe timeframe, Azure.ResourceManager.CostManagement.Models.ForecastDataset dataset) { }
        public Azure.ResourceManager.CostManagement.Models.ForecastDataset Dataset { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ForecastType ForecastType { get { throw null; } }
        public bool? IncludeActualCost { get { throw null; } set { } }
        public bool? IncludeFreshPartialCost { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ForecastTimeframe Timeframe { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod TimePeriod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ForecastDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ForecastDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForecastFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastFilter>
    {
        public ForecastFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ForecastFilter> And { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression Dimensions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ForecastFilter> Or { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ForecastComparisonExpression Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ForecastFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ForecastFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForecastOperatorType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ForecastOperatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForecastOperatorType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastOperatorType In { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ForecastOperatorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ForecastOperatorType left, Azure.ResourceManager.CostManagement.Models.ForecastOperatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ForecastOperatorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ForecastOperatorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ForecastOperatorType left, Azure.ResourceManager.CostManagement.Models.ForecastOperatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ForecastResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastResult>
    {
        internal ForecastResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement.Models.ForecastColumn> Columns { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<System.BinaryData>> Rows { get { throw null; } }
        public string Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ForecastResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ForecastResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForecastSpend : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastSpend>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastSpend>
    {
        internal ForecastSpend() { }
        public float? Amount { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastSpend JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastSpend PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ForecastSpend System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastSpend>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastSpend>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ForecastSpend System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastSpend>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastSpend>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastSpend>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForecastTimeframe : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ForecastTimeframe>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForecastTimeframe(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastTimeframe Custom { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ForecastTimeframe other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ForecastTimeframe left, Azure.ResourceManager.CostManagement.Models.ForecastTimeframe right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ForecastTimeframe (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ForecastTimeframe? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ForecastTimeframe left, Azure.ResourceManager.CostManagement.Models.ForecastTimeframe right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ForecastTimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod>
    {
        public ForecastTimePeriod(System.DateTimeOffset from, System.DateTimeOffset to) { }
        public System.DateTimeOffset From { get { throw null; } }
        public System.DateTimeOffset To { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ForecastTimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ForecastType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ForecastType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ForecastType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ForecastType ActualCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ForecastType AmortizedCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ForecastType Usage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ForecastType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ForecastType left, Azure.ResourceManager.CostManagement.Models.ForecastType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ForecastType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ForecastType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ForecastType left, Azure.ResourceManager.CostManagement.Models.ForecastType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Frequency : System.IEquatable<Azure.ResourceManager.CostManagement.Models.Frequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Frequency(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.Frequency Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.Frequency Monthly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.Frequency Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.Frequency other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.Frequency left, Azure.ResourceManager.CostManagement.Models.Frequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.Frequency (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.Frequency? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.Frequency left, Azure.ResourceManager.CostManagement.Models.Frequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FunctionName : System.IEquatable<Azure.ResourceManager.CostManagement.Models.FunctionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FunctionName(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.FunctionName Cost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.FunctionName CostUSD { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.FunctionName PreTaxCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.FunctionName PreTaxCostUSD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.FunctionName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.FunctionName left, Azure.ResourceManager.CostManagement.Models.FunctionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.FunctionName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.FunctionName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.FunctionName left, Azure.ResourceManager.CostManagement.Models.FunctionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FunctionType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.FunctionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FunctionType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.FunctionType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.FunctionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.FunctionType left, Azure.ResourceManager.CostManagement.Models.FunctionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.FunctionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.FunctionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.FunctionType left, Azure.ResourceManager.CostManagement.Models.FunctionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenerateCostDetailsReportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent>
    {
        public GenerateCostDetailsReportContent() { }
        public string BillingPeriod { get { throw null; } set { } }
        public string InvoiceId { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CostDetailsMetricType? Metric { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.CostDetailsTimePeriod TimePeriod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateCostDetailsReportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateDetailedCostReportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent>
    {
        public GenerateDetailedCostReportContent() { }
        public string BillingPeriod { get { throw null; } set { } }
        public string CustomerId { get { throw null; } set { } }
        public string InvoiceId { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType? Metric { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod TimePeriod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GenerateDetailedCostReportMetricType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GenerateDetailedCostReportMetricType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType ActualCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType AmortizedCost { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType left, Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType left, Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportMetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenerateDetailedCostReportTimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod>
    {
        public GenerateDetailedCostReportTimePeriod(string start, string end) { }
        public string End { get { throw null; } }
        public string Start { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.GenerateDetailedCostReportTimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrainContent : System.IEquatable<Azure.ResourceManager.CostManagement.Models.GrainContent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrainContent(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.GrainContent Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.GrainContent Hourly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.GrainContent Monthly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.GrainContent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.GrainContent left, Azure.ResourceManager.CostManagement.Models.GrainContent right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.GrainContent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.GrainContent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.GrainContent left, Azure.ResourceManager.CostManagement.Models.GrainContent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GranularityType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.GranularityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GranularityType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.GranularityType Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.GranularityType Monthly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.GranularityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.GranularityType left, Azure.ResourceManager.CostManagement.Models.GranularityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.GranularityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.GranularityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.GranularityType left, Azure.ResourceManager.CostManagement.Models.GranularityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IncludedQuantityUtilizationSummary : Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.IncludedQuantityUtilizationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.IncludedQuantityUtilizationSummary>
    {
        public IncludedQuantityUtilizationSummary() { }
        public string ArmSkuName { get { throw null; } }
        public string BenefitId { get { throw null; } }
        public string BenefitOrderId { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind? BenefitType { get { throw null; } set { } }
        public System.DateTimeOffset? UsageOn { get { throw null; } }
        public decimal? UtilizationPercentage { get { throw null; } }
        protected override Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.IncludedQuantityUtilizationSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.IncludedQuantityUtilizationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.IncludedQuantityUtilizationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.IncludedQuantityUtilizationSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.IncludedQuantityUtilizationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.IncludedQuantityUtilizationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.IncludedQuantityUtilizationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LookBackPeriod : System.IEquatable<Azure.ResourceManager.CostManagement.Models.LookBackPeriod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LookBackPeriod(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.LookBackPeriod Last30Days { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.LookBackPeriod Last60Days { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.LookBackPeriod Last7Days { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.LookBackPeriod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.LookBackPeriod left, Azure.ResourceManager.CostManagement.Models.LookBackPeriod right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.LookBackPeriod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.LookBackPeriod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.LookBackPeriod left, Azure.ResourceManager.CostManagement.Models.LookBackPeriod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class McaPriceSheetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties>
    {
        internal McaPriceSheetProperties() { }
        public string BasePrice { get { throw null; } }
        public string BillingAccountID { get { throw null; } }
        public string BillingAccountName { get { throw null; } }
        public string BillingCurrency { get { throw null; } }
        public string BillingProfileId { get { throw null; } }
        public string BillingProfileName { get { throw null; } }
        public string Currency { get { throw null; } }
        public System.DateTimeOffset? EffectiveEndOn { get { throw null; } }
        public System.DateTimeOffset? EffectiveStartOn { get { throw null; } }
        public string MarketPrice { get { throw null; } }
        public string MeterCategory { get { throw null; } }
        public string MeterId { get { throw null; } }
        public string MeterName { get { throw null; } }
        public string MeterRegion { get { throw null; } }
        public string MeterSubCategory { get { throw null; } }
        public string MeterType { get { throw null; } }
        public string PriceType { get { throw null; } }
        public string Product { get { throw null; } }
        public string ProductId { get { throw null; } }
        public string ProductOrderName { get { throw null; } }
        public float? ServiceFamily { get { throw null; } }
        public string SkuId { get { throw null; } }
        public string Term { get { throw null; } }
        public string TierMinimumUnits { get { throw null; } }
        public string UnitOfMeasure { get { throw null; } }
        public string UnitPrice { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.NotificationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.NotificationProperties>
    {
        public NotificationProperties(System.Collections.Generic.IEnumerable<string> to, string subject) { }
        public string Language { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string RegionalFormat { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> To { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.NotificationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.NotificationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.NotificationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.NotificationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.NotificationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.NotificationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.NotificationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.NotificationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.NotificationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.OperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.OperationStatus>
    {
        internal OperationStatus() { }
        public Azure.ResourceManager.CostManagement.Models.ReservationReportSchema? ReportUri { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.OperationStatusType? Status { get { throw null; } }
        public System.DateTimeOffset? ValidUntil { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.OperationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.OperationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.OperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.OperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.OperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.OperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.OperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.OperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.OperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatusType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.OperationStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatusType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.OperationStatusType Complete { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.OperationStatusType Completed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.OperationStatusType Failed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.OperationStatusType Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.OperationStatusType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.OperationStatusType left, Azure.ResourceManager.CostManagement.Models.OperationStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.OperationStatusType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.OperationStatusType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.OperationStatusType left, Azure.ResourceManager.CostManagement.Models.OperationStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PriceSheetDownloadProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties>
    {
        internal PriceSheetDownloadProperties() { }
        public Azure.ResourceManager.CostManagement.Models.McaPriceSheetProperties DownloadFileProperties { get { throw null; } }
        public string DownloadUri { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.PriceSheetDownloadProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryAggregation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryAggregation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryAggregation>
    {
        public QueryAggregation(string name, Azure.ResourceManager.CostManagement.Models.FunctionType function) { }
        public Azure.ResourceManager.CostManagement.Models.FunctionType Function { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryAggregation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryAggregation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.QueryAggregation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryAggregation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryAggregation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.QueryAggregation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryAggregation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryAggregation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryAggregation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryColumn : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryColumn>
    {
        internal QueryColumn() { }
        public string Name { get { throw null; } }
        public string QueryColumnType { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryColumn JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryColumn PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.QueryColumn System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.QueryColumn System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryColumnType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.QueryColumnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryColumnType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryColumnType Dimension { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.QueryColumnType TagKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.QueryColumnType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.QueryColumnType left, Azure.ResourceManager.CostManagement.Models.QueryColumnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.QueryColumnType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.QueryColumnType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.QueryColumnType left, Azure.ResourceManager.CostManagement.Models.QueryColumnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryComparisonExpression : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression>
    {
        public QueryComparisonExpression(string name, Azure.ResourceManager.CostManagement.Models.QueryOperatorType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.QueryOperatorType Operator { get { throw null; } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryDataset>
    {
        public QueryDataset() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CostManagement.Models.QueryAggregation> Aggregation { get { throw null; } }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.QueryFilter Filter { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.GranularityType? Granularity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.QueryGrouping> Grouping { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.QueryDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.QueryDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryDefinition>
    {
        public QueryDefinition(Azure.ResourceManager.CostManagement.Models.ExportType exportType, Azure.ResourceManager.CostManagement.Models.TimeframeType timeframe, Azure.ResourceManager.CostManagement.Models.QueryDataset dataset) { }
        public Azure.ResourceManager.CostManagement.Models.QueryDataset Dataset { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ExportType ExportType { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.TimeframeType Timeframe { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.QueryTimePeriod TimePeriod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.QueryDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.QueryDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryFilter>
    {
        public QueryFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.QueryFilter> And { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression Dimensions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.QueryFilter> Or { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.QueryComparisonExpression Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.QueryFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.QueryFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryGrouping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryGrouping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryGrouping>
    {
        public QueryGrouping(Azure.ResourceManager.CostManagement.Models.QueryColumnType columnType, string name) { }
        public Azure.ResourceManager.CostManagement.Models.QueryColumnType ColumnType { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryGrouping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryGrouping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.QueryGrouping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryGrouping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryGrouping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.QueryGrouping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryGrouping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryGrouping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryGrouping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryOperatorType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.QueryOperatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryOperatorType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.QueryOperatorType In { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.QueryOperatorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.QueryOperatorType left, Azure.ResourceManager.CostManagement.Models.QueryOperatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.QueryOperatorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.QueryOperatorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.QueryOperatorType left, Azure.ResourceManager.CostManagement.Models.QueryOperatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryResult>
    {
        internal QueryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement.Models.QueryColumn> Columns { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<System.BinaryData>> Rows { get { throw null; } }
        public string Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.QueryResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.QueryResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryTimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryTimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryTimePeriod>
    {
        public QueryTimePeriod(System.DateTimeOffset from, System.DateTimeOffset to) { }
        public System.DateTimeOffset From { get { throw null; } }
        public System.DateTimeOffset To { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryTimePeriod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.QueryTimePeriod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.QueryTimePeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryTimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.QueryTimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.QueryTimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryTimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryTimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.QueryTimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationUsageDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails>
    {
        public RecommendationUsageDetails() { }
        public System.Collections.Generic.IReadOnlyList<decimal> Charges { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.BenefitRecommendationUsageGrain? UsageGrain { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.RecommendationUsageDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportConfigAggregation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation>
    {
        public ReportConfigAggregation(string name, Azure.ResourceManager.CostManagement.Models.FunctionType function) { }
        public Azure.ResourceManager.CostManagement.Models.FunctionType Function { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportConfigComparisonExpression : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression>
    {
        public ReportConfigComparisonExpression(string name, Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ComparisonOperatorType Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportConfigDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigDataset>
    {
        public ReportConfigDataset() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.CostManagement.Models.ReportConfigAggregation> Aggregation { get { throw null; } }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigFilter Filter { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ReportGranularityType? Granularity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping> Grouping { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ReportConfigSorting> Sorting { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ReportConfigDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ReportConfigDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportConfigFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter>
    {
        public ReportConfigFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter> And { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression Dimensions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter> Or { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigComparisonExpression Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ReportConfigFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ReportConfigFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportConfigGrouping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping>
    {
        public ReportConfigGrouping(Azure.ResourceManager.CostManagement.Models.QueryColumnType queryColumnType, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.QueryColumnType QueryColumnType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigGrouping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportConfigSorting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigSorting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigSorting>
    {
        public ReportConfigSorting(string name) { }
        public Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType? Direction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigSorting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigSorting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ReportConfigSorting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigSorting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigSorting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ReportConfigSorting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigSorting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigSorting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigSorting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportConfigSortingType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportConfigSortingType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType Ascending { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType Descending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType left, Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType left, Azure.ResourceManager.CostManagement.Models.ReportConfigSortingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReportConfigTimePeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod>
    {
        public ReportConfigTimePeriod(System.DateTimeOffset from, System.DateTimeOffset to) { }
        public System.DateTimeOffset From { get { throw null; } set { } }
        public System.DateTimeOffset To { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ReportConfigTimePeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportGranularityType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ReportGranularityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportGranularityType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportGranularityType Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportGranularityType Monthly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ReportGranularityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ReportGranularityType left, Azure.ResourceManager.CostManagement.Models.ReportGranularityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportGranularityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportGranularityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ReportGranularityType left, Azure.ResourceManager.CostManagement.Models.ReportGranularityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportOperationStatusType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportOperationStatusType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType Completed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType Failed { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType InProgress { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType NoDataFound { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType Queued { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType ReadyToDownload { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType left, Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType left, Azure.ResourceManager.CostManagement.Models.ReportOperationStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportTimeframeType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ReportTimeframeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportTimeframeType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReportTimeframeType Custom { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportTimeframeType MonthToDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportTimeframeType WeekToDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReportTimeframeType YearToDate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ReportTimeframeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ReportTimeframeType left, Azure.ResourceManager.CostManagement.Models.ReportTimeframeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportTimeframeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReportTimeframeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ReportTimeframeType left, Azure.ResourceManager.CostManagement.Models.ReportTimeframeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservationReportSchema : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ReservationReportSchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservationReportSchema(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema InstanceFlexibilityGroup { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema InstanceFlexibilityRatio { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema InstanceId { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema Kind { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema ReservationId { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema ReservationOrderId { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema ReservedHours { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema SkuName { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema TotalReservedQuantity { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema UsageDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ReservationReportSchema UsedHours { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ReservationReportSchema other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ReservationReportSchema left, Azure.ResourceManager.CostManagement.Models.ReservationReportSchema right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReservationReportSchema (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ReservationReportSchema? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ReservationReportSchema left, Azure.ResourceManager.CostManagement.Models.ReservationReportSchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleStatus : System.IEquatable<Azure.ResourceManager.CostManagement.Models.RuleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleStatus(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.RuleStatus Active { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.RuleStatus NotActive { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.RuleStatus Processing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.RuleStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.RuleStatus left, Azure.ResourceManager.CostManagement.Models.RuleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.RuleStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.RuleStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.RuleStatus left, Azure.ResourceManager.CostManagement.Models.RuleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SavingsPlanUtilizationSummary : Azure.ResourceManager.CostManagement.Models.BenefitUtilizationSummary, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SavingsPlanUtilizationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SavingsPlanUtilizationSummary>
    {
        public SavingsPlanUtilizationSummary() { }
        public string ArmSkuName { get { throw null; } }
        public decimal? AvgUtilizationPercentage { get { throw null; } }
        public string BenefitId { get { throw null; } }
        public string BenefitOrderId { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.BillingAccountBenefitKind? BenefitType { get { throw null; } set { } }
        public decimal? MaxUtilizationPercentage { get { throw null; } }
        public decimal? MinUtilizationPercentage { get { throw null; } }
        public System.DateTimeOffset? UsageOn { get { throw null; } }
        protected override Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.SavingsPlanUtilizationSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SavingsPlanUtilizationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SavingsPlanUtilizationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.SavingsPlanUtilizationSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SavingsPlanUtilizationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SavingsPlanUtilizationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SavingsPlanUtilizationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionDaysOfWeek : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionDaysOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek left, Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek left, Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionFileFormat : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionFileFormat(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat Csv { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat left, Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat left, Azure.ResourceManager.CostManagement.Models.ScheduledActionFileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionKind : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ScheduledActionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionKind(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionKind Email { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionKind InsightAlert { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ScheduledActionKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ScheduledActionKind left, Azure.ResourceManager.CostManagement.Models.ScheduledActionKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ScheduledActionKind left, Azure.ResourceManager.CostManagement.Models.ScheduledActionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionStatus : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionStatus(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus Expired { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus left, Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus left, Azure.ResourceManager.CostManagement.Models.ScheduledActionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduledActionWeeksOfMonth : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduledActionWeeksOfMonth(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth First { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth Fourth { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth Last { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth Second { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth Third { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth left, Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth left, Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleFrequency : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ScheduleFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleFrequency(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ScheduleFrequency Daily { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduleFrequency Monthly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ScheduleFrequency Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ScheduleFrequency other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ScheduleFrequency left, Azure.ResourceManager.CostManagement.Models.ScheduleFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduleFrequency (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ScheduleFrequency? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ScheduleFrequency left, Azure.ResourceManager.CostManagement.Models.ScheduleFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ScheduleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ScheduleProperties>
    {
        public ScheduleProperties(Azure.ResourceManager.CostManagement.Models.ScheduleFrequency frequency, System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public int? DayOfMonth { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ScheduledActionDaysOfWeek> DaysOfWeek { get { throw null; } }
        public System.DateTimeOffset EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ScheduleFrequency Frequency { get { throw null; } set { } }
        public int? HourOfDay { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.ScheduledActionWeeksOfMonth> WeeksOfMonth { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ScheduleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ScheduleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ScheduleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ScheduleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ScheduleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ScheduleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ScheduleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ScheduleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ScheduleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedScopeBenefitRecommendationProperties : Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SharedScopeBenefitRecommendationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SharedScopeBenefitRecommendationProperties>
    {
        public SharedScopeBenefitRecommendationProperties() { }
        protected override Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.SharedScopeBenefitRecommendationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SharedScopeBenefitRecommendationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SharedScopeBenefitRecommendationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.SharedScopeBenefitRecommendationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SharedScopeBenefitRecommendationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SharedScopeBenefitRecommendationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SharedScopeBenefitRecommendationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SingleScopeBenefitRecommendationProperties : Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SingleScopeBenefitRecommendationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SingleScopeBenefitRecommendationProperties>
    {
        public SingleScopeBenefitRecommendationProperties() { }
        public string ResourceGroup { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected override Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement.Models.BenefitRecommendationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.SingleScopeBenefitRecommendationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SingleScopeBenefitRecommendationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SingleScopeBenefitRecommendationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.SingleScopeBenefitRecommendationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SingleScopeBenefitRecommendationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SingleScopeBenefitRecommendationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SingleScopeBenefitRecommendationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceCostAllocationEntity : Azure.ResourceManager.CostManagement.Models.CostAllocationEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity>
    {
        public SourceCostAllocationEntity(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType resourceType, string name, System.Collections.Generic.IEnumerable<string> values) : base (default(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType), default(string)) { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override Azure.ResourceManager.CostManagement.Models.CostAllocationEntity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement.Models.CostAllocationEntity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.SourceCostAllocationEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TagInheritanceSetting : Azure.ResourceManager.CostManagement.CostManagementSettingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.TagInheritanceSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.TagInheritanceSetting>
    {
        public TagInheritanceSetting() { }
        public bool? PreferContainerTags { get { throw null; } set { } }
        protected override Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.TagInheritanceSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.TagInheritanceSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.TagInheritanceSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.TagInheritanceSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.TagInheritanceSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.TagInheritanceSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.TagInheritanceSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetCostAllocationEntity : Azure.ResourceManager.CostManagement.Models.CostAllocationEntity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity>
    {
        public TargetCostAllocationEntity(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType resourceType, string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement.Models.CostAllocationProportion> values, Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType policyType) : base (default(Azure.ResourceManager.CostManagement.Models.CostAllocationResourceType), default(string)) { }
        public Azure.ResourceManager.CostManagement.Models.CostAllocationPolicyType PolicyType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement.Models.CostAllocationProportion> Values { get { throw null; } }
        protected override Azure.ResourceManager.CostManagement.Models.CostAllocationEntity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement.Models.CostAllocationEntity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.TargetCostAllocationEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TenantResourceByExternalCloudProviderTypeDimensionsOptions
    {
        public TenantResourceByExternalCloudProviderTypeDimensionsOptions(Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType externalCloudProviderType, string externalCloudProviderId) { }
        public string Expand { get { throw null; } set { } }
        public string ExternalCloudProviderId { get { throw null; } }
        public Azure.ResourceManager.CostManagement.Models.ExternalCloudProviderType ExternalCloudProviderType { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public string Skiptoken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThresholdType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ThresholdType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThresholdType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ThresholdType Actual { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ThresholdType Forecasted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ThresholdType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ThresholdType left, Azure.ResourceManager.CostManagement.Models.ThresholdType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ThresholdType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ThresholdType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ThresholdType left, Azure.ResourceManager.CostManagement.Models.ThresholdType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeframeType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.TimeframeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeframeType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType BillingMonthToDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType Custom { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType MonthToDate { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType TheCurrentMonth { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType TheLastBillingMonth { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType TheLastMonth { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeframeType WeekToDate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.TimeframeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.TimeframeType left, Azure.ResourceManager.CostManagement.Models.TimeframeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.TimeframeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.TimeframeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.TimeframeType left, Azure.ResourceManager.CostManagement.Models.TimeframeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeGrainType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.TimeGrainType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeGrainType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.TimeGrainType Annually { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeGrainType BillingAnnual { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeGrainType BillingMonth { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeGrainType BillingQuarter { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeGrainType Last30Days { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeGrainType Last7Days { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeGrainType Monthly { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.TimeGrainType Quarterly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.TimeGrainType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.TimeGrainType left, Azure.ResourceManager.CostManagement.Models.TimeGrainType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.TimeGrainType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.TimeGrainType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.TimeGrainType left, Azure.ResourceManager.CostManagement.Models.TimeGrainType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ViewChartType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ViewChartType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ViewChartType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ViewChartType Area { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ViewChartType GroupedColumn { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ViewChartType Line { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ViewChartType StackedColumn { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ViewChartType Table { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ViewChartType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ViewChartType left, Azure.ResourceManager.CostManagement.Models.ViewChartType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ViewChartType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ViewChartType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ViewChartType left, Azure.ResourceManager.CostManagement.Models.ViewChartType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ViewKpiProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ViewKpiProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ViewKpiProperties>
    {
        public ViewKpiProperties() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ViewKpiType? KpiType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ViewKpiProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ViewKpiProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ViewKpiProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ViewKpiProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ViewKpiProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ViewKpiProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ViewKpiProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ViewKpiProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ViewKpiProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ViewKpiType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ViewKpiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ViewKpiType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ViewKpiType Budget { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ViewKpiType Forecast { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ViewKpiType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ViewKpiType left, Azure.ResourceManager.CostManagement.Models.ViewKpiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ViewKpiType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ViewKpiType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ViewKpiType left, Azure.ResourceManager.CostManagement.Models.ViewKpiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ViewMetricType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ViewMetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ViewMetricType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ViewMetricType ActualCost { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ViewMetricType Ahub { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ViewMetricType AmortizedCost { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ViewMetricType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ViewMetricType left, Azure.ResourceManager.CostManagement.Models.ViewMetricType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ViewMetricType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ViewMetricType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ViewMetricType left, Azure.ResourceManager.CostManagement.Models.ViewMetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ViewPivotProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ViewPivotProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ViewPivotProperties>
    {
        public ViewPivotProperties() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement.Models.ViewPivotType? PivotType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement.Models.ViewPivotProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement.Models.ViewPivotProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement.Models.ViewPivotProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ViewPivotProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement.Models.ViewPivotProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement.Models.ViewPivotProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ViewPivotProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ViewPivotProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement.Models.ViewPivotProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ViewPivotType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ViewPivotType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ViewPivotType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ViewPivotType Dimension { get { throw null; } }
        public static Azure.ResourceManager.CostManagement.Models.ViewPivotType TagKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ViewPivotType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ViewPivotType left, Azure.ResourceManager.CostManagement.Models.ViewPivotType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ViewPivotType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ViewPivotType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ViewPivotType left, Azure.ResourceManager.CostManagement.Models.ViewPivotType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ViewReportType : System.IEquatable<Azure.ResourceManager.CostManagement.Models.ViewReportType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ViewReportType(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement.Models.ViewReportType Usage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement.Models.ViewReportType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement.Models.ViewReportType left, Azure.ResourceManager.CostManagement.Models.ViewReportType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ViewReportType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement.Models.ViewReportType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement.Models.ViewReportType left, Azure.ResourceManager.CostManagement.Models.ViewReportType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
