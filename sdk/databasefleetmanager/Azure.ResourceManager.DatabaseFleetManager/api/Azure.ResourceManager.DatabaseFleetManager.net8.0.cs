namespace Azure.ResourceManager.DatabaseFleetManager
{
    public partial class AzureResourceManagerDatabaseFleetManagerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDatabaseFleetManagerContext() { }
        public static Azure.ResourceManager.DatabaseFleetManager.AzureResourceManagerDatabaseFleetManagerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DatabaseFleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>, System.Collections.IEnumerable
    {
        protected DatabaseFleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetAll(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetAllAsync(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseFleetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>
    {
        public DatabaseFleetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class DatabaseFleetManagerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetDatabaseFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> GetDatabaseFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource GetDatabaseFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetCollection GetDatabaseFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetDatabaseFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetDatabaseFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource GetDatabaseFleetspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource GetFleetDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetTierResource GetFleetTierResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DatabaseFleetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseFleetResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource> GetDatabaseFleetspace(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource>> GetDatabaseFleetspaceAsync(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceCollection GetDatabaseFleetspaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> GetFleetTier(string tierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>> GetFleetTierAsync(string tierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetTierCollection GetFleetTiers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseFleetspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource>, System.Collections.IEnumerable
    {
        protected DatabaseFleetspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetspaceName, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetspaceName, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource> Get(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource> GetAll(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource> GetAllAsync(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource>> GetAsync(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource> GetIfExists(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource>> GetIfExistsAsync(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseFleetspaceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>
    {
        public DatabaseFleetspaceData() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseFleetspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseFleetspaceResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string fleetspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> GetFleetDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>> GetFleetDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseCollection GetFleetDatabases() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RegisterServer(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RegisterServerAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Unregister(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UnregisterAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> GetAll(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> GetAllAsync(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>
    {
        public FirewallRuleData() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRuleResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string fleetspaceName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>, System.Collections.IEnumerable
    {
        protected FleetDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> GetAll(long? skip = default(long?), long? top = default(long?), string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> GetAllAsync(long? skip = default(long?), long? top = default(long?), string filter = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetDatabaseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>
    {
        public FleetDatabaseData() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetDatabaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetDatabaseResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation ChangeTier(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ChangeTierAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string fleetspaceName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Rename(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RenameAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Revert(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevertAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetTierCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>, System.Collections.IEnumerable
    {
        protected FleetTierCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tierName, Azure.ResourceManager.DatabaseFleetManager.FleetTierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tierName, Azure.ResourceManager.DatabaseFleetManager.FleetTierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> Get(string tierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> GetAll(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> GetAllAsync(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>> GetAsync(string tierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> GetIfExists(string tierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>> GetIfExistsAsync(string tierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetTierData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>
    {
        public FleetTierData() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.FleetTierData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FleetTierData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetTierResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetTierResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetTierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string tierName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> Disable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>> DisableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.FleetTierData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FleetTierData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetTierData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.FleetTierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.FleetTierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DatabaseFleetManager.Mocking
{
    public partial class MockableDatabaseFleetManagerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseFleetManagerArmClient() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource GetDatabaseFleetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceResource GetDatabaseFleetspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource GetFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource GetFleetDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetTierResource GetFleetTierResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDatabaseFleetManagerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseFleetManagerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetDatabaseFleet(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource>> GetDatabaseFleetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetCollection GetDatabaseFleets() { throw null; }
    }
    public partial class MockableDatabaseFleetManagerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseFleetManagerSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetDatabaseFleets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetResource> GetDatabaseFleetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DatabaseFleetManager.Models
{
    public static partial class ArmDatabaseFleetManagerModelFactory
    {
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent DatabaseChangeTierContent(string targetTierName = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetData DatabaseFleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption DatabaseFleetManagerTransparentDataEncryption(System.Uri keyUri = null, System.Collections.Generic.IEnumerable<string> keys = null, bool? enableAutoRotation = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch DatabaseFleetPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.DatabaseFleetspaceData DatabaseFleetspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity DatabaseIdentity(Azure.Core.ResourceIdentifier resourceId = null, System.Guid? principalId = default(System.Guid?), System.Guid? clientId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent DatabaseRenameContent(string newName = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride DestinationTierOverride(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind resourceType = default(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind), string tierName = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData FirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties FirewallRuleProperties(string startIPAddress = null, string endIPAddress = null, Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator FleetAdministrator(string login = null, System.Guid? applicationId = default(System.Guid?), System.Guid? objectId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType? principalType = default(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData FleetDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties FleetDatabaseIdentityProperties(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType? identityType = default(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity> userAssignedIdentities = null, System.Guid? federatedClientId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties FleetDatabaseProperties(string originalDatabaseId = null, Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState?), Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode? createMode = default(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode?), string tierName = null, string connectionString = null, bool? isRecoverable = default(bool?), System.DateTimeOffset? restoreFromOn = default(System.DateTimeOffset?), System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?), System.DateTimeOffset? latestRestoreOn = default(System.DateTimeOffset?), int? backupRetentionDays = default(int?), int? databaseSizeGbMax = default(int?), string sourceDatabaseName = null, System.Collections.Generic.IDictionary<string, string> resourceTags = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties identity = null, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption transparentDataEncryption = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties FleetProperties(string description = null, Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties FleetspaceProperties(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState?), int? capacityMax = default(int?), Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator mainPrincipal = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetTierData FleetTierData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties FleetTierProperties(bool? isDisabled = default(bool?), bool? isServerless = default(bool?), bool? isPooled = default(bool?), string serviceTier = null, string family = null, int? capacity = default(int?), int? poolNumOfDatabasesMax = default(int?), int? highAvailabilityReplicaCount = default(int?), Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy? zoneRedundancy = default(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy?), double? databaseCapacityMin = default(double?), double? databaseCapacityMax = default(double?), int? databaseSizeGbMax = default(int?), Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent RegisterServerContent(string tierName = null, string sourceSubscriptionId = null, string sourceResourceGroupName = null, string sourceServerName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride> destinationTierOverrides = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureProvisioningState : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseChangeTierContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent>
    {
        public DatabaseChangeTierContent() { }
        public string TargetTierName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseCreateMode : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode Copy { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode PointInTimeRestore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseFleetManagerIdentityType : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseFleetManagerIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseFleetManagerPrincipalType : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseFleetManagerPrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType Application { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseFleetManagerTransparentDataEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption>
    {
        public DatabaseFleetManagerTransparentDataEncryption() { }
        public bool? EnableAutoRotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public System.Uri KeyUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseFleetManagerZoneRedundancy : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseFleetManagerZoneRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy Disabled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseFleetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch>
    {
        public DatabaseFleetPatch() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseFleetResourceKind : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseFleetResourceKind(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind Database { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind Pool { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>
    {
        public DatabaseIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseRenameContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent>
    {
        public DatabaseRenameContent() { }
        public string NewName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DestinationTierOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride>
    {
        public DestinationTierOverride(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind resourceType, string tierName, string resourceName) { }
        public string ResourceName { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetResourceKind ResourceType { get { throw null; } }
        public string TierName { get { throw null; } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirewallRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>
    {
        public FirewallRuleProperties() { }
        public string EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetAdministrator : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator>
    {
        public FleetAdministrator() { }
        public System.Guid? ApplicationId { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerPrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetDatabaseIdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties>
    {
        public FleetDatabaseIdentityProperties() { }
        public System.Guid? FederatedClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerIdentityType? IdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetDatabaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>
    {
        public FleetDatabaseProperties() { }
        public int? BackupRetentionDays { get { throw null; } }
        public string Collation { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode? CreateMode { get { throw null; } set { } }
        public int? DatabaseSizeGbMax { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseIdentityProperties Identity { get { throw null; } set { } }
        public bool? IsRecoverable { get { throw null; } }
        public System.DateTimeOffset? LatestRestoreOn { get { throw null; } }
        public string OriginalDatabaseId { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ResourceTags { get { throw null; } }
        public System.DateTimeOffset? RestoreFromOn { get { throw null; } set { } }
        public string SourceDatabaseName { get { throw null; } set { } }
        public string TierName { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerTransparentDataEncryption TransparentDataEncryption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties>
    {
        public FleetProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties>
    {
        public FleetspaceProperties() { }
        public int? CapacityMax { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetAdministrator MainPrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetTierProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>
    {
        public FleetTierProperties() { }
        public int? Capacity { get { throw null; } set { } }
        public double? DatabaseCapacityMax { get { throw null; } set { } }
        public double? DatabaseCapacityMin { get { throw null; } set { } }
        public int? DatabaseSizeGbMax { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public int? HighAvailabilityReplicaCount { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } }
        public bool? IsPooled { get { throw null; } set { } }
        public bool? IsServerless { get { throw null; } set { } }
        public int? PoolNumOfDatabasesMax { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? ProvisioningState { get { throw null; } }
        public string ServiceTier { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseFleetManagerZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegisterServerContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent>
    {
        public RegisterServerContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride> DestinationTierOverrides { get { throw null; } }
        public string SourceResourceGroupName { get { throw null; } set { } }
        public string SourceServerName { get { throw null; } set { } }
        public string SourceSubscriptionId { get { throw null; } set { } }
        public string TierName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
