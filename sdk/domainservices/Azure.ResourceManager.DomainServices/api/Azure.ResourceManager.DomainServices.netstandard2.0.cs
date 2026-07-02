namespace Azure.ResourceManager.DomainServices
{
    public partial class AzureResourceManagerDomainServicesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDomainServicesContext() { }
        public static Azure.ResourceManager.DomainServices.AzureResourceManagerDomainServicesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DomainServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DomainServices.DomainServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.DomainServiceResource>, System.Collections.IEnumerable
    {
        protected DomainServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainServices.DomainServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainServiceName, Azure.ResourceManager.DomainServices.DomainServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainServices.DomainServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainServiceName, Azure.ResourceManager.DomainServices.DomainServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource> Get(string domainServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DomainServices.DomainServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DomainServices.DomainServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource>> GetAsync(string domainServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DomainServices.DomainServiceResource> GetIfExists(string domainServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DomainServices.DomainServiceResource>> GetIfExistsAsync(string domainServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DomainServices.DomainServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DomainServices.DomainServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DomainServices.DomainServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.DomainServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainServiceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.DomainServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.DomainServiceData>
    {
        public DomainServiceData() { }
        public Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics ConfigDiagnostics { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public string DomainConfigurationType { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings DomainSecuritySettings { get { throw null; } set { } }
        public string ETag { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.FilteredSync? FilteredSync { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.LdapsSettings LdapsSettings { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.MigrationProperties MigrationProperties { get { throw null; } }
        public Azure.ResourceManager.DomainServices.Models.NotificationSettings NotificationSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DomainServices.Models.ReplicaSet> ReplicaSets { get { throw null; } }
        public Azure.ResourceManager.DomainServices.Models.ResourceForestSettings ResourceForestSettings { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string SyncApplicationId { get { throw null; } }
        public string SyncOwner { get { throw null; } }
        public Azure.ResourceManager.DomainServices.Models.SyncScope? SyncScope { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TenantId { get { throw null; } }
        public int? Version { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.DomainServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.DomainServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.DomainServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.DomainServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.DomainServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.DomainServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.DomainServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.DomainServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.DomainServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainServiceResource() { }
        public virtual Azure.ResourceManager.DomainServices.DomainServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainServices.OuContainerResource> GetOuContainer(string ouContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.OuContainerResource>> GetOuContainerAsync(string ouContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DomainServices.OuContainerCollection GetOuContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DomainServices.DomainServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.DomainServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.DomainServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.DomainServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.DomainServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.DomainServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.DomainServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult> Unsuspend(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult>> UnsuspendAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainServices.DomainServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DomainServices.DomainServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainServices.DomainServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DomainServices.DomainServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DomainServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource> GetDomainService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource>> GetDomainServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DomainServices.DomainServiceResource GetDomainServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DomainServices.DomainServiceCollection GetDomainServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DomainServices.DomainServiceResource> GetDomainServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DomainServices.DomainServiceResource> GetDomainServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DomainServices.OuContainerResource GetOuContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class OuContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DomainServices.OuContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.OuContainerResource>, System.Collections.IEnumerable
    {
        protected OuContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainServices.OuContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ouContainerName, Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainServices.OuContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ouContainerName, Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ouContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ouContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainServices.OuContainerResource> Get(string ouContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DomainServices.OuContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DomainServices.OuContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.OuContainerResource>> GetAsync(string ouContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DomainServices.OuContainerResource> GetIfExists(string ouContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DomainServices.OuContainerResource>> GetIfExistsAsync(string ouContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DomainServices.OuContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DomainServices.OuContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DomainServices.OuContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.OuContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OuContainerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.OuContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.OuContainerData>
    {
        internal OuContainerData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent> Accounts { get { throw null; } }
        public string ContainerId { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public string DistinguishedName { get { throw null; } }
        public string DomainName { get { throw null; } }
        public string ETag { get { throw null; } }
        public string Location { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ServiceStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.OuContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.OuContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.OuContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.OuContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.OuContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.OuContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.OuContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OuContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.OuContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.OuContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OuContainerResource() { }
        public virtual Azure.ResourceManager.DomainServices.OuContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainServiceName, string ouContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DomainServices.OuContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.OuContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DomainServices.OuContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.OuContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.OuContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.OuContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.OuContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.OuContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.OuContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainServices.OuContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DomainServices.OuContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DomainServices.Mocking
{
    public partial class MockableDomainServicesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDomainServicesArmClient() { }
        public virtual Azure.ResourceManager.DomainServices.DomainServiceResource GetDomainServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DomainServices.OuContainerResource GetOuContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDomainServicesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDomainServicesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource> GetDomainService(string domainServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DomainServices.DomainServiceResource>> GetDomainServiceAsync(string domainServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DomainServices.DomainServiceCollection GetDomainServices() { throw null; }
    }
    public partial class MockableDomainServicesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDomainServicesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DomainServices.DomainServiceResource> GetDomainServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DomainServices.DomainServiceResource> GetDomainServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DomainServices.Models
{
    public static partial class ArmDomainServicesModelFactory
    {
        public static Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics ConfigDiagnostics(System.DateTimeOffset? lastExecuted = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult> validatorResults = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult ConfigDiagnosticsValidatorResult(string validatorId = null, string replicaSetSubnetDisplayName = null, Azure.ResourceManager.DomainServices.Models.Status? status = default(Azure.ResourceManager.DomainServices.Models.Status?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue> issues = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue ConfigDiagnosticsValidatorResultIssue(string id = null, System.Collections.Generic.IEnumerable<string> descriptionParams = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings DomainSecuritySettings(Azure.ResourceManager.DomainServices.Models.NtlmV1? ntlmV1 = default(Azure.ResourceManager.DomainServices.Models.NtlmV1?), Azure.ResourceManager.DomainServices.Models.TlsV1? tlsV1 = default(Azure.ResourceManager.DomainServices.Models.TlsV1?), Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords? syncNtlmPasswords = default(Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords?), Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords? syncKerberosPasswords = default(Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords?), Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords? syncOnPremPasswords = default(Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords?), Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption? kerberosRc4Encryption = default(Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption?), Azure.ResourceManager.DomainServices.Models.KerberosArmoring? kerberosArmoring = default(Azure.ResourceManager.DomainServices.Models.KerberosArmoring?), Azure.ResourceManager.DomainServices.Models.LdapSigning? ldapSigning = default(Azure.ResourceManager.DomainServices.Models.LdapSigning?), Azure.ResourceManager.DomainServices.Models.ChannelBinding? channelBinding = default(Azure.ResourceManager.DomainServices.Models.ChannelBinding?), Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName? syncOnPremSamAccountName = default(Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName?)) { throw null; }
        public static Azure.ResourceManager.DomainServices.DomainServiceData DomainServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? version = default(int?), string tenantId = null, string domainName = null, string deploymentId = null, string syncOwner = null, string syncApplicationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.Models.ReplicaSet> replicaSets = null, Azure.ResourceManager.DomainServices.Models.LdapsSettings ldapsSettings = null, Azure.ResourceManager.DomainServices.Models.ResourceForestSettings resourceForestSettings = null, Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings domainSecuritySettings = null, string domainConfigurationType = null, string sku = null, Azure.ResourceManager.DomainServices.Models.FilteredSync? filteredSync = default(Azure.ResourceManager.DomainServices.Models.FilteredSync?), Azure.ResourceManager.DomainServices.Models.SyncScope? syncScope = default(Azure.ResourceManager.DomainServices.Models.SyncScope?), Azure.ResourceManager.DomainServices.Models.NotificationSettings notificationSettings = null, Azure.ResourceManager.DomainServices.Models.MigrationProperties migrationProperties = null, string provisioningState = null, Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics configDiagnostics = null, System.Collections.Generic.IDictionary<string, string> tags = null, string location = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult DomainServiceUnsuspendResult(string message = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.ForestTrust ForestTrust(string trustedDomainFqdn = null, string trustDirection = null, string friendlyName = null, string remoteDnsIps = null, string trustPassword = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.HealthAlert HealthAlert(string id = null, string name = null, string issue = null, string severity = null, System.DateTimeOffset? raised = default(System.DateTimeOffset?), System.DateTimeOffset? lastDetected = default(System.DateTimeOffset?), string resolutionUri = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.HealthMonitor HealthMonitor(string id = null, string name = null, string details = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.LdapsSettings LdapsSettings(Azure.ResourceManager.DomainServices.Models.Ldaps? ldaps = default(Azure.ResourceManager.DomainServices.Models.Ldaps?), string pfxCertificate = null, string pfxCertificatePassword = null, string publicCertificate = null, string certificateThumbprint = null, System.DateTimeOffset? certificateNotAfter = default(System.DateTimeOffset?), Azure.ResourceManager.DomainServices.Models.ExternalAccess? externalAccess = default(Azure.ResourceManager.DomainServices.Models.ExternalAccess?)) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.MigrationProgress MigrationProgress(double? completionPercentage = default(double?), string progressMessage = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.MigrationProperties MigrationProperties(string oldSubnetId = null, string oldVnetSiteId = null, Azure.ResourceManager.DomainServices.Models.MigrationProgress migrationProgress = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.NotificationSettings NotificationSettings(Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins? notifyGlobalAdmins = default(Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins?), Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins? notifyDcAdmins = default(Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins?), System.Collections.Generic.IEnumerable<string> additionalRecipients = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent OuContainerCreateOrUpdateContent(string accountName = null, string spn = null, string password = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.OuContainerData OuContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string tenantId = null, string domainName = null, string deploymentId = null, string containerId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent> accounts = null, string serviceStatus = null, string distinguishedName = null, string provisioningState = null, System.Collections.Generic.IDictionary<string, string> tags = null, string location = null, string eTag = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.ReplicaSet ReplicaSet(string replicaSetId = null, string location = null, string vnetSiteId = null, string subnetId = null, System.Collections.Generic.IEnumerable<string> domainControllerIpAddress = null, string externalAccessIpAddress = null, string serviceStatus = null, int? selfUnsuspendCounter = default(int?), System.DateTimeOffset? healthLastEvaluated = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.Models.HealthMonitor> healthMonitors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.Models.HealthAlert> healthAlerts = null) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.ResourceForestSettings ResourceForestSettings(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DomainServices.Models.ForestTrust> settings = null, string resourceForest = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChannelBinding : System.IEquatable<Azure.ResourceManager.DomainServices.Models.ChannelBinding>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChannelBinding(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.ChannelBinding Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.ChannelBinding Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.ChannelBinding other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.ChannelBinding left, Azure.ResourceManager.DomainServices.Models.ChannelBinding right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.ChannelBinding (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.ChannelBinding? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.ChannelBinding left, Azure.ResourceManager.DomainServices.Models.ChannelBinding right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics>
    {
        public ConfigDiagnostics() { }
        public System.DateTimeOffset? LastExecuted { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult> ValidatorResults { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigDiagnosticsValidatorResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult>
    {
        public ConfigDiagnosticsValidatorResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue> Issues { get { throw null; } }
        public string ReplicaSetSubnetDisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.Status? Status { get { throw null; } set { } }
        public string ValidatorId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigDiagnosticsValidatorResultIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue>
    {
        public ConfigDiagnosticsValidatorResultIssue() { }
        public System.Collections.Generic.IList<string> DescriptionParams { get { throw null; } }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ConfigDiagnosticsValidatorResultIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainSecuritySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings>
    {
        public DomainSecuritySettings() { }
        public Azure.ResourceManager.DomainServices.Models.ChannelBinding? ChannelBinding { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.KerberosArmoring? KerberosArmoring { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption? KerberosRc4Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.LdapSigning? LdapSigning { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.NtlmV1? NtlmV1 { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords? SyncKerberosPasswords { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords? SyncNtlmPasswords { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords? SyncOnPremPasswords { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName? SyncOnPremSamAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.TlsV1? TlsV1 { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.DomainSecuritySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainServiceUnsuspendResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult>
    {
        internal DomainServiceUnsuspendResult() { }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.DomainServiceUnsuspendResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExternalAccess : System.IEquatable<Azure.ResourceManager.DomainServices.Models.ExternalAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExternalAccess(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.ExternalAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.ExternalAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.ExternalAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.ExternalAccess left, Azure.ResourceManager.DomainServices.Models.ExternalAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.ExternalAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.ExternalAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.ExternalAccess left, Azure.ResourceManager.DomainServices.Models.ExternalAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilteredSync : System.IEquatable<Azure.ResourceManager.DomainServices.Models.FilteredSync>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilteredSync(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.FilteredSync Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.FilteredSync Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.FilteredSync other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.FilteredSync left, Azure.ResourceManager.DomainServices.Models.FilteredSync right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.FilteredSync (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.FilteredSync? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.FilteredSync left, Azure.ResourceManager.DomainServices.Models.FilteredSync right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ForestTrust : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ForestTrust>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ForestTrust>
    {
        public ForestTrust() { }
        public string FriendlyName { get { throw null; } set { } }
        public string RemoteDnsIps { get { throw null; } set { } }
        public string TrustDirection { get { throw null; } set { } }
        public string TrustedDomainFqdn { get { throw null; } set { } }
        public string TrustPassword { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainServices.Models.ForestTrust JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.ForestTrust PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.ForestTrust System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ForestTrust>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ForestTrust>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.ForestTrust System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ForestTrust>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ForestTrust>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ForestTrust>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthAlert : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.HealthAlert>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.HealthAlert>
    {
        internal HealthAlert() { }
        public string Id { get { throw null; } }
        public string Issue { get { throw null; } }
        public System.DateTimeOffset? LastDetected { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? Raised { get { throw null; } }
        public string ResolutionUri { get { throw null; } }
        public string Severity { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainServices.Models.HealthAlert JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.HealthAlert PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.HealthAlert System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.HealthAlert>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.HealthAlert>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.HealthAlert System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.HealthAlert>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.HealthAlert>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.HealthAlert>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthMonitor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.HealthMonitor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.HealthMonitor>
    {
        internal HealthMonitor() { }
        public string Details { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainServices.Models.HealthMonitor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.HealthMonitor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.HealthMonitor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.HealthMonitor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.HealthMonitor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.HealthMonitor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.HealthMonitor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.HealthMonitor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.HealthMonitor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KerberosArmoring : System.IEquatable<Azure.ResourceManager.DomainServices.Models.KerberosArmoring>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KerberosArmoring(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.KerberosArmoring Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.KerberosArmoring Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.KerberosArmoring other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.KerberosArmoring left, Azure.ResourceManager.DomainServices.Models.KerberosArmoring right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.KerberosArmoring (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.KerberosArmoring? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.KerberosArmoring left, Azure.ResourceManager.DomainServices.Models.KerberosArmoring right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KerberosRc4Encryption : System.IEquatable<Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KerberosRc4Encryption(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption left, Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption left, Azure.ResourceManager.DomainServices.Models.KerberosRc4Encryption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Ldaps : System.IEquatable<Azure.ResourceManager.DomainServices.Models.Ldaps>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Ldaps(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.Ldaps Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.Ldaps Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.Ldaps other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.Ldaps left, Azure.ResourceManager.DomainServices.Models.Ldaps right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.Ldaps (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.Ldaps? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.Ldaps left, Azure.ResourceManager.DomainServices.Models.Ldaps right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LdapSigning : System.IEquatable<Azure.ResourceManager.DomainServices.Models.LdapSigning>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LdapSigning(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.LdapSigning Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.LdapSigning Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.LdapSigning other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.LdapSigning left, Azure.ResourceManager.DomainServices.Models.LdapSigning right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.LdapSigning (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.LdapSigning? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.LdapSigning left, Azure.ResourceManager.DomainServices.Models.LdapSigning right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LdapsSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.LdapsSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.LdapsSettings>
    {
        public LdapsSettings() { }
        public System.DateTimeOffset? CertificateNotAfter { get { throw null; } }
        public string CertificateThumbprint { get { throw null; } }
        public Azure.ResourceManager.DomainServices.Models.ExternalAccess? ExternalAccess { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.Ldaps? Ldaps { get { throw null; } set { } }
        public string PfxCertificate { get { throw null; } set { } }
        public string PfxCertificatePassword { get { throw null; } set { } }
        public string PublicCertificate { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainServices.Models.LdapsSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.LdapsSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.LdapsSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.LdapsSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.LdapsSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.LdapsSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.LdapsSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.LdapsSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.LdapsSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationProgress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.MigrationProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.MigrationProgress>
    {
        internal MigrationProgress() { }
        public double? CompletionPercentage { get { throw null; } }
        public string ProgressMessage { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainServices.Models.MigrationProgress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.MigrationProgress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.MigrationProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.MigrationProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.MigrationProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.MigrationProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.MigrationProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.MigrationProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.MigrationProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.MigrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.MigrationProperties>
    {
        internal MigrationProperties() { }
        public Azure.ResourceManager.DomainServices.Models.MigrationProgress MigrationProgress { get { throw null; } }
        public string OldSubnetId { get { throw null; } }
        public string OldVnetSiteId { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainServices.Models.MigrationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.MigrationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.MigrationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.MigrationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.MigrationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.MigrationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.MigrationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.MigrationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.MigrationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.NotificationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.NotificationSettings>
    {
        public NotificationSettings() { }
        public System.Collections.Generic.IList<string> AdditionalRecipients { get { throw null; } }
        public Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins? NotifyDcAdmins { get { throw null; } set { } }
        public Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins? NotifyGlobalAdmins { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainServices.Models.NotificationSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.NotificationSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.NotificationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.NotificationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.NotificationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.NotificationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.NotificationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.NotificationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.NotificationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotifyDcAdmins : System.IEquatable<Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotifyDcAdmins(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins left, Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins left, Azure.ResourceManager.DomainServices.Models.NotifyDcAdmins right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotifyGlobalAdmins : System.IEquatable<Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotifyGlobalAdmins(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins left, Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins left, Azure.ResourceManager.DomainServices.Models.NotifyGlobalAdmins right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NtlmV1 : System.IEquatable<Azure.ResourceManager.DomainServices.Models.NtlmV1>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NtlmV1(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.NtlmV1 Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.NtlmV1 Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.NtlmV1 other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.NtlmV1 left, Azure.ResourceManager.DomainServices.Models.NtlmV1 right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.NtlmV1 (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.NtlmV1? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.NtlmV1 left, Azure.ResourceManager.DomainServices.Models.NtlmV1 right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OuContainerCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent>
    {
        public OuContainerCreateOrUpdateContent() { }
        public string AccountName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Spn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.OuContainerCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReplicaSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ReplicaSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ReplicaSet>
    {
        public ReplicaSet() { }
        public System.Collections.Generic.IReadOnlyList<string> DomainControllerIpAddress { get { throw null; } }
        public string ExternalAccessIpAddress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DomainServices.Models.HealthAlert> HealthAlerts { get { throw null; } }
        public System.DateTimeOffset? HealthLastEvaluated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DomainServices.Models.HealthMonitor> HealthMonitors { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public string ReplicaSetId { get { throw null; } }
        public int? SelfUnsuspendCounter { get { throw null; } }
        public string ServiceStatus { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
        public string VnetSiteId { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainServices.Models.ReplicaSet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.ReplicaSet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.ReplicaSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ReplicaSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ReplicaSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.ReplicaSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ReplicaSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ReplicaSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ReplicaSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceForestSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ResourceForestSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ResourceForestSettings>
    {
        public ResourceForestSettings() { }
        public string ResourceForest { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DomainServices.Models.ForestTrust> Settings { get { throw null; } }
        protected virtual Azure.ResourceManager.DomainServices.Models.ResourceForestSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DomainServices.Models.ResourceForestSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DomainServices.Models.ResourceForestSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ResourceForestSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DomainServices.Models.ResourceForestSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DomainServices.Models.ResourceForestSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ResourceForestSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ResourceForestSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DomainServices.Models.ResourceForestSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.DomainServices.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.Status Failure { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.Status None { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.Status OK { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.Status Running { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.Status Skipped { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.Status Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.Status other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.Status left, Azure.ResourceManager.DomainServices.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.Status (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.Status? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.Status left, Azure.ResourceManager.DomainServices.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncKerberosPasswords : System.IEquatable<Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncKerberosPasswords(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords left, Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords left, Azure.ResourceManager.DomainServices.Models.SyncKerberosPasswords right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncNtlmPasswords : System.IEquatable<Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncNtlmPasswords(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords left, Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords left, Azure.ResourceManager.DomainServices.Models.SyncNtlmPasswords right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncOnPremPasswords : System.IEquatable<Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncOnPremPasswords(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords left, Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords left, Azure.ResourceManager.DomainServices.Models.SyncOnPremPasswords right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncOnPremSamAccountName : System.IEquatable<Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncOnPremSamAccountName(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName left, Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName left, Azure.ResourceManager.DomainServices.Models.SyncOnPremSamAccountName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncScope : System.IEquatable<Azure.ResourceManager.DomainServices.Models.SyncScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncScope(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.SyncScope All { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.SyncScope CloudOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.SyncScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.SyncScope left, Azure.ResourceManager.DomainServices.Models.SyncScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.SyncScope (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.SyncScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.SyncScope left, Azure.ResourceManager.DomainServices.Models.SyncScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TlsV1 : System.IEquatable<Azure.ResourceManager.DomainServices.Models.TlsV1>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TlsV1(string value) { throw null; }
        public static Azure.ResourceManager.DomainServices.Models.TlsV1 Disabled { get { throw null; } }
        public static Azure.ResourceManager.DomainServices.Models.TlsV1 Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DomainServices.Models.TlsV1 other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DomainServices.Models.TlsV1 left, Azure.ResourceManager.DomainServices.Models.TlsV1 right) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.TlsV1 (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DomainServices.Models.TlsV1? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DomainServices.Models.TlsV1 left, Azure.ResourceManager.DomainServices.Models.TlsV1 right) { throw null; }
        public override string ToString() { throw null; }
    }
}
