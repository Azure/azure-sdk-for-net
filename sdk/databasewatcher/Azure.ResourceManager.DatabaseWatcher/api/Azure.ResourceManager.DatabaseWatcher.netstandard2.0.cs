namespace Azure.ResourceManager.DatabaseWatcher
{
    public partial class AzureResourceManagerDatabaseWatcherContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDatabaseWatcherContext() { }
        public static Azure.ResourceManager.DatabaseWatcher.AzureResourceManagerDatabaseWatcherContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DatabaseWatcherAlertRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource>, System.Collections.IEnumerable
    {
        protected DatabaseWatcherAlertRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertRuleResourceName, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertRuleResourceName, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource> Get(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource>> GetAsync(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource> GetIfExists(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource>> GetIfExistsAsync(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseWatcherAlertRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>
    {
        public DatabaseWatcherAlertRuleData() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseWatcherAlertRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseWatcherAlertRuleResource() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string watcherName, string alertRuleResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseWatcherCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>, System.Collections.IEnumerable
    {
        protected DatabaseWatcherCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string watcherName, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string watcherName, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> Get(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>> GetAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> GetIfExists(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>> GetIfExistsAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseWatcherData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>
    {
        public DatabaseWatcherData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class DatabaseWatcherExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> GetDatabaseWatcher(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource GetDatabaseWatcherAlertRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>> GetDatabaseWatcherAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource GetDatabaseWatcherHealthValidationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource GetDatabaseWatcherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherCollection GetDatabaseWatchers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> GetDatabaseWatchers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> GetDatabaseWatchersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource GetDatabaseWatcherSharedPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource GetDatabaseWatcherTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DatabaseWatcherHealthValidationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource>, System.Collections.IEnumerable
    {
        protected DatabaseWatcherHealthValidationCollection() { }
        public virtual Azure.Response<bool> Exists(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource> Get(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource>> GetAsync(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource> GetIfExists(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource>> GetIfExistsAsync(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseWatcherHealthValidationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>
    {
        internal DatabaseWatcherHealthValidationData() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseWatcherHealthValidationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseWatcherHealthValidationResource() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string watcherName, string healthValidationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource> StartValidation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource>> StartValidationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseWatcherResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseWatcherResource() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string watcherName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource> GetDatabaseWatcherAlertRule(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource>> GetDatabaseWatcherAlertRuleAsync(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleCollection GetDatabaseWatcherAlertRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource> GetDatabaseWatcherHealthValidation(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource>> GetDatabaseWatcherHealthValidationAsync(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationCollection GetDatabaseWatcherHealthValidations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource> GetDatabaseWatcherSharedPrivateLinkResource(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource>> GetDatabaseWatcherSharedPrivateLinkResourceAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceCollection GetDatabaseWatcherSharedPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource> GetDatabaseWatcherTarget(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource>> GetDatabaseWatcherTargetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetCollection GetDatabaseWatcherTargets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseWatcherSharedPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseWatcherSharedPrivateLinkResource() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string watcherName, string sharedPrivateLinkResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseWatcherSharedPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected DatabaseWatcherSharedPrivateLinkResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource> Get(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource> GetIfExists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource>> GetIfExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseWatcherSharedPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>
    {
        public DatabaseWatcherSharedPrivateLinkResourceData() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseWatcherTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource>, System.Collections.IEnumerable
    {
        protected DatabaseWatcherTargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource> Get(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource>> GetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource> GetIfExists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource>> GetIfExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseWatcherTargetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>
    {
        public DatabaseWatcherTargetData() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseWatcherTargetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseWatcherTargetResource() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string watcherName, string targetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DatabaseWatcher.Mocking
{
    public partial class MockableDatabaseWatcherArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseWatcherArmClient() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleResource GetDatabaseWatcherAlertRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationResource GetDatabaseWatcherHealthValidationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource GetDatabaseWatcherResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResource GetDatabaseWatcherSharedPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetResource GetDatabaseWatcherTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDatabaseWatcherResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseWatcherResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> GetDatabaseWatcher(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource>> GetDatabaseWatcherAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherCollection GetDatabaseWatchers() { throw null; }
    }
    public partial class MockableDatabaseWatcherSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseWatcherSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> GetDatabaseWatchers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherResource> GetDatabaseWatchersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DatabaseWatcher.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertRuleCreationProperty : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertRuleCreationProperty(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty CreatedWithActionGroup { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty left, Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty left, Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmDatabaseWatcherModelFactory
    {
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherAlertRuleData DatabaseWatcherAlertRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties DatabaseWatcherAlertRuleProperties(Azure.Core.ResourceIdentifier alertRuleResourceId = null, Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty createdWithProperties = default(Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty), System.DateTimeOffset createdOn = default(System.DateTimeOffset), Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState?), string alertRuleTemplateId = null, string alertRuleTemplateVersion = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherData DatabaseWatcherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherHealthValidationData DatabaseWatcherHealthValidationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue DatabaseWatcherHealthValidationIssue(string errorCode = null, string errorMessage = null, string additionalDetails = null, string recommendationMessage = null, System.Uri recommendationUri = null, Azure.Core.ResourceIdentifier relatedResourceId = null, Azure.Core.ResourceType? relatedResourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties DatabaseWatcherHealthValidationProperties(System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset endOn = default(System.DateTimeOffset), Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus status = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue> issues = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties DatabaseWatcherProperties(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore datastore = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus? status = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus?), Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState?), Azure.Core.ResourceIdentifier defaultAlertRuleIdentityResourceId = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherSharedPrivateLinkResourceData DatabaseWatcherSharedPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties DatabaseWatcherSharedPrivateLinkResourceProperties(Azure.Core.ResourceIdentifier privateLinkResourceId = null, string groupId = null, string requestMessage = null, string dnsZone = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus? status = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus?), Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.DatabaseWatcherTargetData DatabaseWatcherTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties DatabaseWatcherTargetProperties(string targetType = null, Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType = default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret targetVault = null, string connectionServerName = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SqlDBElasticPoolTargetProperties SqlDBElasticPoolTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType = default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret targetVault = null, string connectionServerName = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState?), Azure.Core.ResourceIdentifier sqlEpResourceId = null, Azure.Core.ResourceIdentifier anchorDatabaseResourceId = null, bool? readIntent = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SqlDBSingleDatabaseTargetProperties SqlDBSingleDatabaseTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType = default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret targetVault = null, string connectionServerName = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState?), Azure.Core.ResourceIdentifier sqlDbResourceId = null, bool? readIntent = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SqlMITargetProperties SqlMITargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType = default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret targetVault = null, string connectionServerName = null, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState?), Azure.Core.ResourceIdentifier sqlMiResourceId = null, int? connectionTcpPort = default(int?), bool? readIntent = default(bool?)) { throw null; }
    }
    public partial class DatabaseWatcherAlertRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties>
    {
        public DatabaseWatcherAlertRuleProperties(Azure.Core.ResourceIdentifier alertRuleResourceId, Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty createdWithProperties, System.DateTimeOffset createdOn, string alertRuleTemplateId, string alertRuleTemplateVersion) { }
        public Azure.Core.ResourceIdentifier AlertRuleResourceId { get { throw null; } set { } }
        public string AlertRuleTemplateId { get { throw null; } set { } }
        public string AlertRuleTemplateVersion { get { throw null; } set { } }
        public System.DateTimeOffset CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty CreatedWithProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherAlertRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseWatcherDatastore : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore>
    {
        public DatabaseWatcherDatastore(System.Uri kustoClusterUri, System.Uri kustoDataIngestionUri, string kustoDatabaseName, System.Uri kustoManagementUri, Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType kustoOfferingType) { }
        public Azure.Core.ResourceIdentifier AdxClusterResourceId { get { throw null; } set { } }
        public string KustoClusterDisplayName { get { throw null; } set { } }
        public System.Uri KustoClusterUri { get { throw null; } set { } }
        public string KustoDatabaseName { get { throw null; } set { } }
        public System.Uri KustoDataIngestionUri { get { throw null; } set { } }
        public System.Uri KustoManagementUri { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType KustoOfferingType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseWatcherHealthValidationIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue>
    {
        internal DatabaseWatcherHealthValidationIssue() { }
        public string AdditionalDetails { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string RecommendationMessage { get { throw null; } }
        public System.Uri RecommendationUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier RelatedResourceId { get { throw null; } }
        public Azure.Core.ResourceType? RelatedResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseWatcherHealthValidationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties>
    {
        internal DatabaseWatcherHealthValidationProperties() { }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationIssue> Issues { get { throw null; } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseWatcherHealthValidationStatus : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseWatcherHealthValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherHealthValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseWatcherPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch>
    {
        public DatabaseWatcherPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseWatcherProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties>
    {
        public DatabaseWatcherProperties() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore Datastore { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DefaultAlertRuleIdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseWatcherProvisioningState : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseWatcherProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseWatcherResourceProvisioningState : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseWatcherResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseWatcherSharedPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties>
    {
        public DatabaseWatcherSharedPrivateLinkResourceProperties(Azure.Core.ResourceIdentifier privateLinkResourceId, string groupId, string requestMessage) { }
        public string DnsZone { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseWatcherSharedPrivateLinkResourceStatus : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseWatcherSharedPrivateLinkResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherSharedPrivateLinkResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseWatcherStatus : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseWatcherStatus(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DatabaseWatcherTargetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties>
    {
        protected DatabaseWatcherTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType, string connectionServerName) { }
        public string ConnectionServerName { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType TargetAuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret TargetVault { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseWatcherUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherUpdateProperties>
    {
        public DatabaseWatcherUpdateProperties() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherDatastore Datastore { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DefaultAlertRuleIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoOfferingType : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoOfferingType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType Adx { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType Fabric { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType Free { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType left, Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType left, Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlDBElasticPoolTargetProperties : Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBElasticPoolTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBElasticPoolTargetProperties>
    {
        public SqlDBElasticPoolTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType, string connectionServerName, Azure.Core.ResourceIdentifier sqlEpResourceId, Azure.Core.ResourceIdentifier anchorDatabaseResourceId) : base (default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), default(string)) { }
        public Azure.Core.ResourceIdentifier AnchorDatabaseResourceId { get { throw null; } set { } }
        public bool? ReadIntent { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlEpResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlDBElasticPoolTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBElasticPoolTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBElasticPoolTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlDBElasticPoolTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBElasticPoolTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBElasticPoolTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBElasticPoolTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDBSingleDatabaseTargetProperties : Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBSingleDatabaseTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBSingleDatabaseTargetProperties>
    {
        public SqlDBSingleDatabaseTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType, string connectionServerName, Azure.Core.ResourceIdentifier sqlDbResourceId) : base (default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), default(string)) { }
        public bool? ReadIntent { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlDbResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlDBSingleDatabaseTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBSingleDatabaseTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBSingleDatabaseTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlDBSingleDatabaseTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBSingleDatabaseTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBSingleDatabaseTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDBSingleDatabaseTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlMITargetProperties : Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherTargetProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMITargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMITargetProperties>
    {
        public SqlMITargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType, string connectionServerName, Azure.Core.ResourceIdentifier sqlMiResourceId) : base (default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), default(string)) { }
        public int? ConnectionTcpPort { get { throw null; } set { } }
        public bool? ReadIntent { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlMiResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlMITargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMITargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMITargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlMITargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMITargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMITargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMITargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetAuthenticationType : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType Aad { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType Sql { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType left, Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType left, Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetAuthenticationVaultSecret : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret>
    {
        public TargetAuthenticationVaultSecret() { }
        public Azure.Core.ResourceIdentifier AkvResourceId { get { throw null; } set { } }
        public string AkvTargetPassword { get { throw null; } set { } }
        public string AkvTargetUser { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationVaultSecret>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
