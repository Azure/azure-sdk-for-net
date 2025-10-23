namespace Azure.ResourceManager.MigrationDiscoverySap
{
    public partial class AzureResourceManagerMigrationDiscoverySapContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMigrationDiscoverySapContext() { }
        public static Azure.ResourceManager.MigrationDiscoverySap.AzureResourceManagerMigrationDiscoverySapContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class MigrationDiscoverySapExtensions
    {
        public static Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource GetSapDiscoveryServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> GetSapDiscoverySite(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>> GetSapDiscoverySiteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource GetSapDiscoverySiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteCollection GetSapDiscoverySites(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> GetSapDiscoverySites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> GetSapDiscoverySitesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource GetSapInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SapDiscoveryServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource>, System.Collections.IEnumerable
    {
        protected SapDiscoveryServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverInstanceName, Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverInstanceName, Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource> Get(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource>> GetAsync(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource> GetIfExists(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource>> GetIfExistsAsync(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapDiscoveryServerInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>
    {
        public SapDiscoveryServerInstanceData() { }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail ConfigurationData { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError Errors { get { throw null; } }
        public string InstanceSid { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem? OperatingSystem { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail PerformanceData { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType? SapInstanceType { get { throw null; } }
        public string SapProduct { get { throw null; } }
        public string SapProductVersion { get { throw null; } }
        public string ServerName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDiscoveryServerInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapDiscoveryServerInstanceResource() { }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapDiscoverySiteName, string sapInstanceName, string serverInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource> Update(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource>> UpdateAsync(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapDiscoverySiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>, System.Collections.IEnumerable
    {
        protected SapDiscoverySiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sapDiscoverySiteName, Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sapDiscoverySiteName, Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> Get(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>> GetAsync(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> GetIfExists(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>> GetIfExistsAsync(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapDiscoverySiteData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>
    {
        public SapDiscoverySiteData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError Errors { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string MasterSiteId { get { throw null; } set { } }
        public string MigrateProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDiscoverySiteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapDiscoverySiteResource() { }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapDiscoverySiteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> GetSapInstance(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>> GetSapInstanceAsync(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SapInstanceCollection GetSapInstances() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> ImportEntities(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> ImportEntitiesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> Update(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>> UpdateAsync(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SapInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>, System.Collections.IEnumerable
    {
        protected SapInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sapInstanceName, Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sapInstanceName, Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> Get(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>> GetAsync(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> GetIfExists(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>> GetIfExistsAsync(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SapInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>
    {
        public SapInstanceData(Azure.Core.AzureLocation location) { }
        public string Application { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment? Environment { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError Errors { get { throw null; } }
        public string LandscapeSid { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public string SystemSid { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SapInstanceResource() { }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapDiscoverySiteName, string sapInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource> GetSapDiscoveryServerInstance(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource>> GetSapDiscoveryServerInstanceAsync(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceCollection GetSapDiscoveryServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource> Update(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource>> UpdateAsync(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MigrationDiscoverySap.Mocking
{
    public partial class MockableMigrationDiscoverySapArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationDiscoverySapArmClient() { }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceResource GetSapDiscoveryServerInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource GetSapDiscoverySiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SapInstanceResource GetSapInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMigrationDiscoverySapResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationDiscoverySapResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> GetSapDiscoverySite(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource>> GetSapDiscoverySiteAsync(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteCollection GetSapDiscoverySites() { throw null; }
    }
    public partial class MockableMigrationDiscoverySapSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationDiscoverySapSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> GetSapDiscoverySites(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteResource> GetSapDiscoverySitesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MigrationDiscoverySap.Models
{
    public static partial class ArmMigrationDiscoverySapModelFactory
    {
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail ConfigurationDetail(int? saps = default(int?), int? cpu = default(int?), string cpuType = null, int? cpuInMhz = default(int?), int? ram = default(int?), string hardwareManufacturer = null, string model = null, int? totalDiskSizeGB = default(int?), int? totalDiskIops = default(int?), Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType? databaseType = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType?), int? targetHanaRamSizeGB = default(int?)) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail ExcelPerformanceDetail(int? maxCpuLoad = default(int?), int? totalSourceDbSizeGB = default(int?)) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail SapDiscoveryErrorDetail(string code = null, string message = null, string recommendation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail> details = null) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SapDiscoveryServerInstanceData SapDiscoveryServerInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string serverName = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType? sapInstanceType = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType?), string instanceSid = null, string sapProduct = null, string sapProductVersion = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem? operatingSystem = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem?), Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail configurationData = null, Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail performanceData = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState?), Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError errors = null) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SapDiscoverySiteData SapDiscoverySiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation extendedLocation = null, string masterSiteId = null, string migrateProjectId = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState?), Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError errors = null) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SapInstanceData SapInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string systemSid = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment? environment = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment?), string landscapeSid = null, string application = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState?), Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError errors = null) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError SapMigrateError(string code = null, string message = null, string recommendation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail> details = null) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties ServerInstanceProperties(string serverName = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType? sapInstanceType = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType?), string instanceSid = null, string sapProduct = null, string sapProductVersion = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem? operatingSystem = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem?), Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail configurationData = null, Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail performanceData = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState?), Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError errors = null) { throw null; }
    }
    public partial class ConfigurationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>
    {
        internal ConfigurationDetail() { }
        public int? Cpu { get { throw null; } }
        public int? CpuInMhz { get { throw null; } }
        public string CpuType { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType? DatabaseType { get { throw null; } }
        public string HardwareManufacturer { get { throw null; } }
        public string Model { get { throw null; } }
        public int? Ram { get { throw null; } }
        public int? Saps { get { throw null; } }
        public int? TargetHanaRamSizeGB { get { throw null; } }
        public int? TotalDiskIops { get { throw null; } }
        public int? TotalDiskSizeGB { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExcelPerformanceDetail : Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>
    {
        internal ExcelPerformanceDetail() { }
        public int? MaxCpuLoad { get { throw null; } }
        public int? TotalSourceDbSizeGB { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NativePerformanceDetail : Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>
    {
        internal NativePerformanceDetail() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PerformanceDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>
    {
        protected PerformanceDetail() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDiscoveryDatabaseType : System.IEquatable<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDiscoveryDatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType Adabas { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType DB2 { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType Hana { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType Informix { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType Oracle { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType SapAse { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType SapDB { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType SapMaxDB { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType SQLServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType left, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType left, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryDatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapDiscoveryErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>
    {
        internal SapDiscoveryErrorDetail() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDiscoveryExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation>
    {
        public SapDiscoveryExtendedLocation(string extendedLocationType, string name) { }
        public string ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDiscoveryOperatingSystem : System.IEquatable<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDiscoveryOperatingSystem(string value) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem IbmAix { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem RedHat { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem Solaris { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem Suse { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem Unix { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem WindowsServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem left, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem right) { throw null; }
        public static implicit operator Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem left, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapDiscoveryProvisioningState : System.IEquatable<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapDiscoveryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState left, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState left, Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapDiscoveryServerInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch>
    {
        public SapDiscoveryServerInstancePatch() { }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryServerInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SapDiscoverySitePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch>
    {
        public SapDiscoverySitePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoverySitePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapInstanceEnvironment : System.IEquatable<Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapInstanceEnvironment(string value) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment Development { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment PreProduction { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment Production { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment QualityAssurance { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment Sandbox { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment Test { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment Training { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment left, Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment right) { throw null; }
        public static implicit operator Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment left, Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch>
    {
        public SapInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapInstanceType : System.IEquatable<Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapInstanceType(string value) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType App { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType Ascs { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType DB { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType Scs { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType Webdisp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType left, Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType left, Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapMigrateError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError>
    {
        internal SapMigrateError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>
    {
        public ServerInstanceProperties() { }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail ConfigurationData { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapMigrateError Errors { get { throw null; } }
        public string InstanceSid { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryOperatingSystem? OperatingSystem { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail PerformanceData { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType? SapInstanceType { get { throw null; } }
        public string SapProduct { get { throw null; } }
        public string SapProductVersion { get { throw null; } }
        public string ServerName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
