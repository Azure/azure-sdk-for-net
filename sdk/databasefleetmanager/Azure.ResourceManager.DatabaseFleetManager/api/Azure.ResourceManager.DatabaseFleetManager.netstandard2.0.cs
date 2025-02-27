namespace Azure.ResourceManager.DatabaseFleetManager
{
    public static partial class DatabaseFleetManagerExtensions
    {
        public static Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> GetFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource GetFleetDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetResource GetFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetCollection GetFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource GetFleetspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetTierResource GetFleetTierResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class FleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetResource>, System.Collections.IEnumerable
    {
        protected FleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.DatabaseFleetManager.FleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.DatabaseFleetManager.FleetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetAll(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetAllAsync(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>
    {
        public FleetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.ResourceManager.ArmOperation ChangeTier(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ChangeTierAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string fleetspaceName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Rename(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RenameAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class FleetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource> GetFleetspace(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource>> GetFleetspaceAsync(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetspaceCollection GetFleetspaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource> GetFleetTier(string tierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetTierResource>> GetFleetTierAsync(string tierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetTierCollection GetFleetTiers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.FleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource>, System.Collections.IEnumerable
    {
        protected FleetspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetspaceName, Azure.ResourceManager.DatabaseFleetManager.FleetspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetspaceName, Azure.ResourceManager.DatabaseFleetManager.FleetspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource> Get(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource> GetAll(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource> GetAllAsync(long? skip = default(long?), long? top = default(long?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource>> GetAsync(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource> GetIfExists(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource>> GetIfExistsAsync(string fleetspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetspaceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>
    {
        public FleetspaceData() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FleetspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FleetspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetspaceResource() { }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string fleetspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource> GetFleetDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource>> GetFleetDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseCollection GetFleetDatabases() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RegisterServer(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RegisterServerAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseFleetManager.FleetspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.FleetspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.FleetspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Unregister(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UnregisterAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.FleetspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseFleetManager.FleetspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.ResourceManager.DatabaseFleetManager.FirewallRuleResource GetFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseResource GetFleetDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetResource GetFleetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetspaceResource GetFleetspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetTierResource GetFleetTierResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDatabaseFleetManagerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseFleetManagerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetFleet(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseFleetManager.FleetResource>> GetFleetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseFleetManager.FleetCollection GetFleets() { throw null; }
    }
    public partial class MockableDatabaseFleetManagerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseFleetManagerSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetFleets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseFleetManager.FleetResource> GetFleetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DatabaseFleetManager.Models
{
    public static partial class ArmDatabaseFleetManagerModelFactory
    {
        public static Azure.ResourceManager.DatabaseFleetManager.FirewallRuleData FirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties FirewallRuleProperties(string startIPAddress = null, string endIPAddress = null, Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetData FleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetDatabaseData FleetDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties FleetDatabaseProperties(string originalDatabaseId = null, Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState?), Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode? createMode = default(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode?), string tierName = null, string connectionString = null, bool? recoverable = default(bool?), System.DateTimeOffset? restoreFromOn = default(System.DateTimeOffset?), System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?), System.DateTimeOffset? latestRestoreOn = default(System.DateTimeOffset?), int? backupRetentionDays = default(int?), int? databaseSizeGbMax = default(int?), string sourceDatabaseName = null, System.Collections.Generic.IDictionary<string, string> resourceTags = null, Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties identity = null, Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption transparentDataEncryption = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties FleetProperties(string description = null, Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetspaceData FleetspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetspaceProperties FleetspaceProperties(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState?), int? capacityMax = default(int?), Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal mainPrincipal = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.FleetTierData FleetTierData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties FleetTierProperties(bool? disabled = default(bool?), bool? serverless = default(bool?), bool? pooled = default(bool?), string serviceTier = null, string family = null, int? capacity = default(int?), int? poolNumOfDatabasesMax = default(int?), int? highAvailabilityReplicaCount = default(int?), Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy? zoneRedundancy = default(Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy?), double? databaseCapacityMin = default(double?), double? databaseCapacityMax = default(double?), int? databaseSizeGbMax = default(int?), Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState?)) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState left, Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseChangeTierProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties>
    {
        public DatabaseChangeTierProperties() { }
        public string TargetTierName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseChangeTierProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode left, Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>
    {
        public DatabaseIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabaseRenameProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties>
    {
        public DatabaseRenameProperties() { }
        public string NewName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseRenameProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DestinationTierOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride>
    {
        public DestinationTierOverride(Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType resourceType, string tierName, string resourceName) { }
        public string ResourceName { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType ResourceType { get { throw null; } }
        public string TierName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FirewallRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties Identity { get { throw null; } set { } }
        public System.DateTimeOffset? LatestRestoreOn { get { throw null; } }
        public string OriginalDatabaseId { get { throw null; } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? ProvisioningState { get { throw null; } }
        public bool? Recoverable { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ResourceTags { get { throw null; } }
        public System.DateTimeOffset? RestoreFromOn { get { throw null; } set { } }
        public string SourceDatabaseName { get { throw null; } set { } }
        public string TierName { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption TransparentDataEncryption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetDatabaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch>
    {
        public FleetPatch() { }
        public Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetProperties>
    {
        public FleetProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal MainPrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public bool? Disabled { get { throw null; } }
        public string Family { get { throw null; } set { } }
        public int? HighAvailabilityReplicaCount { get { throw null; } set { } }
        public bool? Pooled { get { throw null; } set { } }
        public int? PoolNumOfDatabasesMax { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.AzureProvisioningState? ProvisioningState { get { throw null; } }
        public bool? Serverless { get { throw null; } set { } }
        public string ServiceTier { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.FleetTierProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IdentityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties>
    {
        public IdentityProperties() { }
        public System.Guid? FederatedClientId { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.IdentityType? IdentityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DatabaseFleetManager.Models.DatabaseIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.IdentityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.IdentityType None { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.IdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.IdentityType left, Azure.ResourceManager.DatabaseFleetManager.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.IdentityType left, Azure.ResourceManager.DatabaseFleetManager.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MainPrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal>
    {
        public MainPrincipal() { }
        public System.Guid? ApplicationId { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseFleetManager.Models.PrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.MainPrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrincipalType : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.PrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.PrincipalType Application { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.PrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.PrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.PrincipalType left, Azure.ResourceManager.DatabaseFleetManager.Models.PrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.PrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.PrincipalType left, Azure.ResourceManager.DatabaseFleetManager.Models.PrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegisterServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties>
    {
        public RegisterServerProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DatabaseFleetManager.Models.DestinationTierOverride> DestinationTierOverrides { get { throw null; } }
        public string SourceResourceGroupName { get { throw null; } set { } }
        public string SourceServerName { get { throw null; } set { } }
        public string SourceSubscriptionId { get { throw null; } set { } }
        public string TierName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.RegisterServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceType : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType Database { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType Pool { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType left, Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType left, Azure.ResourceManager.DatabaseFleetManager.Models.ResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransparentDataEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption>
    {
        public TransparentDataEncryption() { }
        public bool? EnableAutoRotation { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public System.Uri KeyUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseFleetManager.Models.TransparentDataEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneRedundancy : System.IEquatable<Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy Disabled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy left, Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy left, Azure.ResourceManager.DatabaseFleetManager.Models.ZoneRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
}
