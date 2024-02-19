namespace Azure.ResourceManager.MigrationDiscoverySap
{
    public static partial class MigrationDiscoverySapExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> GetSAPDiscoverySite(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>> GetSAPDiscoverySiteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource GetSAPDiscoverySiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteCollection GetSAPDiscoverySites(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> GetSAPDiscoverySites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> GetSAPDiscoverySitesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource GetSAPInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource GetServerInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SAPDiscoverySiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>, System.Collections.IEnumerable
    {
        protected SAPDiscoverySiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sapDiscoverySiteName, Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sapDiscoverySiteName, Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> Get(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>> GetAsync(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> GetIfExists(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>> GetIfExistsAsync(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SAPDiscoverySiteData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData>
    {
        public SAPDiscoverySiteData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError Errors { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string MasterSiteId { get { throw null; } set { } }
        public string MigrateProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SAPDiscoverySiteResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SAPDiscoverySiteResource() { }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapDiscoverySiteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> GetSAPInstance(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>> GetSAPInstanceAsync(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceCollection GetSAPInstances() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult> ImportEntities(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Models.OperationStatusResult>> ImportEntitiesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> Update(Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>> UpdateAsync(Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SAPInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>, System.Collections.IEnumerable
    {
        protected SAPInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sapInstanceName, Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sapInstanceName, Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> Get(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>> GetAsync(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> GetIfExists(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>> GetIfExistsAsync(string sapInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SAPInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData>
    {
        public SAPInstanceData(Azure.Core.AzureLocation location) { }
        public string Application { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment? Environment { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError Errors { get { throw null; } }
        public string LandscapeSid { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SystemSid { get { throw null; } }
        Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SAPInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SAPInstanceResource() { }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapDiscoverySiteName, string sapInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource> GetServerInstance(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource>> GetServerInstanceAsync(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceCollection GetServerInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource> Update(Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource>> UpdateAsync(Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource>, System.Collections.IEnumerable
    {
        protected ServerInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverInstanceName, Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverInstanceName, Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource> Get(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource>> GetAsync(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource> GetIfExists(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource>> GetIfExistsAsync(string serverInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData>
    {
        public ServerInstanceData() { }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail ConfigurationData { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError Errors { get { throw null; } }
        public string InstanceSid { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem? OperatingSystem { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail PerformanceData { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType? SapInstanceType { get { throw null; } }
        public string SapProduct { get { throw null; } }
        public string SapProductVersion { get { throw null; } }
        public string ServerName { get { throw null; } }
        Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerInstanceResource() { }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sapDiscoverySiteName, string sapInstanceName, string serverInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource> Update(Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource>> UpdateAsync(Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MigrationDiscoverySap.Mocking
{
    public partial class MockableMigrationDiscoverySapArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationDiscoverySapArmClient() { }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource GetSAPDiscoverySiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceResource GetSAPInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceResource GetServerInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMigrationDiscoverySapResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationDiscoverySapResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> GetSAPDiscoverySite(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource>> GetSAPDiscoverySiteAsync(string sapDiscoverySiteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteCollection GetSAPDiscoverySites() { throw null; }
    }
    public partial class MockableMigrationDiscoverySapSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMigrationDiscoverySapSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> GetSAPDiscoverySites(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteResource> GetSAPDiscoverySitesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MigrationDiscoverySap.Models
{
    public static partial class ArmMigrationDiscoverySapModelFactory
    {
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail ConfigurationDetail(int? saps = default(int?), int? cpu = default(int?), string cpuType = null, int? cpuInMhz = default(int?), int? ram = default(int?), string hardwareManufacturer = null, string model = null, int? totalDiskSizeGB = default(int?), int? totalDiskIops = default(int?), Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType? databaseType = default(Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType?), int? targetHanaRamSizeGB = default(int?)) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail ExcelPerformanceDetail(int? maxCpuLoad = default(int?), int? totalSourceDbSizeGB = default(int?)) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail SapDiscoveryErrorDetail(string code = null, string message = null, string recommendation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail> details = null) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SAPDiscoverySiteData SAPDiscoverySiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation extendedLocation = null, string masterSiteId = null, string migrateProjectId = null, Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState?), Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError errors = null) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.SAPInstanceData SAPInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string systemSid = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment? environment = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceEnvironment?), string landscapeSid = null, string application = null, Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState?), Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError errors = null) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError SAPMigrateError(string code = null, string message = null, string recommendation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail> details = null) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.ServerInstanceData ServerInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string serverName = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType? sapInstanceType = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType?), string instanceSid = null, string sapProduct = null, string sapProductVersion = null, Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem? operatingSystem = default(Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem?), Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail configurationData = null, Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail performanceData = null, Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState?), Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError errors = null) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties ServerInstanceProperties(string serverName = null, Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType? sapInstanceType = default(Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType?), string instanceSid = null, string sapProduct = null, string sapProductVersion = null, Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem? operatingSystem = default(Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem?), Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail configurationData = null, Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail performanceData = null, Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState?), Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError errors = null) { throw null; }
    }
    public partial class ConfigurationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>
    {
        internal ConfigurationDetail() { }
        public int? Cpu { get { throw null; } }
        public int? CpuInMhz { get { throw null; } }
        public string CpuType { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType? DatabaseType { get { throw null; } }
        public string HardwareManufacturer { get { throw null; } }
        public string Model { get { throw null; } }
        public int? Ram { get { throw null; } }
        public int? Saps { get { throw null; } }
        public int? TargetHanaRamSizeGB { get { throw null; } }
        public int? TotalDiskIops { get { throw null; } }
        public int? TotalDiskSizeGB { get { throw null; } }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseType : System.IEquatable<Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType Adabas { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType Db2 { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType Hana { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType Informix { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType Oracle { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType Sapase { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType Sapdb { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType SAPMaxDB { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType SQLServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType left, Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType left, Azure.ResourceManager.MigrationDiscoverySap.Models.DatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExcelPerformanceDetail : Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>
    {
        internal ExcelPerformanceDetail() { }
        public int? MaxCpuLoad { get { throw null; } }
        public int? TotalSourceDbSizeGB { get { throw null; } }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExcelPerformanceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation>
    {
        public ExtendedLocation(string extendedLocationType, string name) { }
        public string ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NativePerformanceDetail : Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>
    {
        internal NativePerformanceDetail() { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.NativePerformanceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystem : System.IEquatable<Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystem(string value) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem Ibmaix { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem RedHat { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem Solaris { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem Suse { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem Unix { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem WindowsServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem left, Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem right) { throw null; }
        public static implicit operator Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem left, Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class PerformanceDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>
    {
        protected PerformanceDetail() { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState left, Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState left, Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SapDiscoveryErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>
    {
        internal SapDiscoveryErrorDetail() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SAPDiscoverySitePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch>
    {
        public SAPDiscoverySitePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPDiscoverySitePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SAPInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch>
    {
        public SAPInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SapInstanceType : System.IEquatable<Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SapInstanceType(string value) { throw null; }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType APP { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType Ascs { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType DB { get { throw null; } }
        public static Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType SCS { get { throw null; } }
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
    public partial class SAPMigrateError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError>
    {
        internal SAPMigrateError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MigrationDiscoverySap.Models.SapDiscoveryErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch>
    {
        public ServerInstancePatch() { }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>
    {
        public ServerInstanceProperties() { }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ConfigurationDetail ConfigurationData { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SAPMigrateError Errors { get { throw null; } }
        public string InstanceSid { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.OperatingSystem? OperatingSystem { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.PerformanceDetail PerformanceData { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MigrationDiscoverySap.Models.SapInstanceType? SapInstanceType { get { throw null; } }
        public string SapProduct { get { throw null; } }
        public string SapProductVersion { get { throw null; } }
        public string ServerName { get { throw null; } }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MigrationDiscoverySap.Models.ServerInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
