namespace Azure.ResourceManager.InformaticaDataManagement
{
    public static partial class InformaticaDataManagementExtensions
    {
        public static Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource GetInformaticaOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganizationResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> GetInformaticaOrganizationResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceCollection GetInformaticaOrganizationResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganizationResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganizationResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource GetInformaticaServerlessRuntimeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class InformaticaOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InformaticaOrganizationResource() { }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList> GetAllServerlessRuntimes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>> GetAllServerlessRuntimesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> GetInformaticaServerlessRuntimeResource(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> GetInformaticaServerlessRuntimeResourceAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceCollection GetInformaticaServerlessRuntimeResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse> GetServerlessMetadata(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>> GetServerlessMetadataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> Update(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> UpdateAsync(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InformaticaOrganizationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>, System.Collections.IEnumerable
    {
        protected InformaticaOrganizationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InformaticaOrganizationResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>
    {
        public InformaticaOrganizationResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails CompanyDetails { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties InformaticaProperties { get { throw null; } set { } }
        public string LinkOrganizationToken { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails UserDetails { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InformaticaServerlessRuntimeResource() { }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse> CheckDependencies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse>> CheckDependenciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string serverlessRuntimeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> ServerlessResourceById(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> ServerlessResourceByIdAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartFailedServerlessRuntime(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartFailedServerlessRuntimeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> Update(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> UpdateAsync(Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>, System.Collections.IEnumerable
    {
        protected InformaticaServerlessRuntimeResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverlessRuntimeName, Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverlessRuntimeName, Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> Get(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> GetAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> GetIfExists(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>> GetIfExistsAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>
    {
        public InformaticaServerlessRuntimeResourceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties> AdvancedCustomProperties { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType? ApplicationType { get { throw null; } set { } }
        public string ComputeUnits { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ExecutionTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration NetworkInterfaceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType? Platform { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ServerlessAccountLocation { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties ServerlessRuntimeConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag> ServerlessRuntimeTags { get { throw null; } }
        public string SupplementaryFileLocation { get { throw null; } set { } }
        public string UserContextToken { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.InformaticaDataManagement.Mocking
{
    public partial class MockableInformaticaDataManagementArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableInformaticaDataManagementArmClient() { }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource GetInformaticaOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResource GetInformaticaServerlessRuntimeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableInformaticaDataManagementResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableInformaticaDataManagementResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganizationResource(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource>> GetInformaticaOrganizationResourceAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceCollection GetInformaticaOrganizationResources() { throw null; }
    }
    public partial class MockableInformaticaDataManagementSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableInformaticaDataManagementSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganizationResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResource> GetInformaticaOrganizationResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.InformaticaDataManagement.Models
{
    public partial class AdvancedCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>
    {
        public AdvancedCustomProperties() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationConfigs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs>
    {
        public ApplicationConfigs(string applicationConfigsType, string name, string value, string platform, string customized, string defaultValue) { }
        public string ApplicationConfigsType { get { throw null; } set { } }
        public string Customized { get { throw null; } set { } }
        public string DefaultValue { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Platform { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationType : System.IEquatable<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType CDI { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType Cdie { get { throw null; } }
        public bool Equals(Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType left, Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType left, Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationTypeMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata>
    {
        internal ApplicationTypeMetadata() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmInformaticaDataManagementModelFactory
    {
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata ApplicationTypeMetadata(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse CheckDependenciesResponse(int count = 0, string id = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency> references = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata ComputeUnitsMetadata(string name = null, System.Collections.Generic.IEnumerable<string> value = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData InfaRuntimeResourceFetchMetaData(string name = null, string createdTime = null, string updatedTime = null, string createdBy = null, string updatedBy = null, string id = null, Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType runtimeType = default(Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType), string status = null, string statusLocalized = null, string statusMessage = null, Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties serverlessConfigProperties = null, string description = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties InfaServerlessFetchConfigProperties(string subnet = null, string applicationType = null, string resourceGroupName = null, string advancedCustomProperties = null, string supplementaryFileLocation = null, string platform = null, string tags = null, string vnet = null, string executionTimeout = null, string computeUnits = null, System.Guid? tenantId = default(System.Guid?), string subscriptionId = null, string region = null, string serverlessArmResourceId = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.InformaticaOrganizationResourceData InformaticaOrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState?), Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties informaticaProperties = null, Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails marketplaceDetails = null, Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails userDetails = null, Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails companyDetails = null, string linkOrganizationToken = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.InformaticaServerlessRuntimeResourceData InformaticaServerlessRuntimeResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState?), string description = null, Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType? platform = default(Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType?), Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType? applicationType = default(Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType?), string computeUnits = null, string executionTimeout = null, string serverlessAccountLocation = null, Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration networkInterfaceConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties> advancedCustomProperties = null, string supplementaryFileLocation = null, Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties serverlessRuntimeConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag> serverlessRuntimeTags = null, string userContextToken = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList InformaticaServerlessRuntimeResourceList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData> informaticaRuntimeResources = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata RegionsMetadata(string id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties ServerlessConfigProperties(Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType? platform = default(Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata> applicationTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata> computeUnits = null, string executionTimeout = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata> regions = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse ServerlessMetadataResponse(Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType? runtimeType = default(Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType?), Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties serverlessConfigProperties = null, Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties serverlessRuntimeConfigProperties = null) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency ServerlessRuntimeDependency(string id = null, string appContextId = null, string path = null, string documentType = null, string description = null, string lastUpdatedTime = null) { throw null; }
    }
    public partial class CdiConfigProps : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps>
    {
        public CdiConfigProps(string engineName, string engineVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs> applicationConfigs) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationConfigs> ApplicationConfigs { get { throw null; } }
        public string EngineName { get { throw null; } set { } }
        public string EngineVersion { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckDependenciesResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse>
    {
        internal CheckDependenciesResponse() { }
        public int Count { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency> References { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CheckDependenciesResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails>
    {
        public CompanyDetails() { }
        public string Business { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public int? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompanyDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetailsUpdate>
    {
        public CompanyDetailsUpdate() { }
        public string Business { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public int? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeUnitsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>
    {
        internal ComputeUnitsMetadata() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Value { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InfaRuntimeResourceFetchMetaData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData>
    {
        internal InfaRuntimeResourceFetchMetaData() { }
        public string CreatedBy { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType RuntimeType { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties ServerlessConfigProperties { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusLocalized { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public string UpdatedTime { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InfaServerlessFetchConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties>
    {
        internal InfaServerlessFetchConfigProperties() { }
        public string AdvancedCustomProperties { get { throw null; } }
        public string ApplicationType { get { throw null; } }
        public string ComputeUnits { get { throw null; } }
        public string ExecutionTimeout { get { throw null; } }
        public string Platform { get { throw null; } }
        public string Region { get { throw null; } }
        public string ResourceGroupName { get { throw null; } }
        public string ServerlessArmResourceId { get { throw null; } }
        public string Subnet { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SupplementaryFileLocation { get { throw null; } }
        public string Tags { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string Vnet { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InfaServerlessFetchConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaOrganizationResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch>
    {
        public InformaticaOrganizationResourcePatch() { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.OrganizationPropertiesCustomUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>
    {
        public InformaticaProperties() { }
        public string InformaticaRegion { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResourceList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>
    {
        internal InformaticaServerlessRuntimeResourceList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.InformaticaDataManagement.Models.InfaRuntimeResourceFetchMetaData> InformaticaRuntimeResources { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourceList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch>
    {
        public InformaticaServerlessRuntimeResourcePatch() { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesCustomUpdate Properties { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaServerlessRuntimeResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(string marketplaceSubscriptionId, Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails offerDetails) { }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails OfferDetails { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetailsUpdate>
    {
        public MarketplaceDetailsUpdate() { }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetailsUpdate OfferDetails { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration>
    {
        public NetworkInterfaceConfiguration(string vnetId, string subnetId) { }
        public string SubnetId { get { throw null; } set { } }
        public string VnetId { get { throw null; } set { } }
        public string VnetResourceGuid { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceConfigurationUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfigurationUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfigurationUpdate>
    {
        public NetworkInterfaceConfigurationUpdate() { }
        public string SubnetId { get { throw null; } set { } }
        public string VnetId { get { throw null; } set { } }
        public string VnetResourceGuid { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfigurationUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfigurationUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfigurationUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfigurationUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfigurationUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfigurationUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfigurationUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails>
    {
        public OfferDetails(string publisherId, string offerId, string planId, string planName, string termId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfferDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetailsUpdate>
    {
        public OfferDetailsUpdate() { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OfferDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrganizationPropertiesCustomUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.OrganizationPropertiesCustomUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OrganizationPropertiesCustomUpdate>
    {
        public OrganizationPropertiesCustomUpdate() { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.CompanyDetailsUpdate CompanyDetails { get { throw null; } set { } }
        public string ExistingResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.InformaticaOrganizationResourcePatch InformaticaOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.MarketplaceDetailsUpdate MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.UserDetailsUpdate UserDetails { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.OrganizationPropertiesCustomUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.OrganizationPropertiesCustomUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.OrganizationPropertiesCustomUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.OrganizationPropertiesCustomUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OrganizationPropertiesCustomUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OrganizationPropertiesCustomUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.OrganizationPropertiesCustomUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlatformType : System.IEquatable<Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlatformType(string value) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType Azure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType left, Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType left, Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState left, Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState left, Azure.ResourceManager.InformaticaDataManagement.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegionsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata>
    {
        internal RegionsMetadata() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuntimeType : System.IEquatable<Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuntimeType(string value) { throw null; }
        public static Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType Serverless { get { throw null; } }
        public bool Equals(Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType left, Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType left, Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerlessConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>
    {
        internal ServerlessConfigProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationTypeMetadata> ApplicationTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.InformaticaDataManagement.Models.ComputeUnitsMetadata> ComputeUnits { get { throw null; } }
        public string ExecutionTimeout { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType? Platform { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.InformaticaDataManagement.Models.RegionsMetadata> Regions { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessMetadataResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>
    {
        internal ServerlessMetadataResponse() { }
        public Azure.ResourceManager.InformaticaDataManagement.Models.RuntimeType? RuntimeType { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessConfigProperties ServerlessConfigProperties { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties ServerlessRuntimeConfigProperties { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessMetadataResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>
    {
        public ServerlessRuntimeConfigProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps> CdiConfigProps { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps> CdieConfigProps { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeConfigPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>
    {
        public ServerlessRuntimeConfigPropertiesUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps> CdiConfigProps { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.CdiConfigProps> CdieConfigProps { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>
    {
        internal ServerlessRuntimeDependency() { }
        public string AppContextId { get { throw null; } }
        public string Description { get { throw null; } }
        public string DocumentType { get { throw null; } }
        public string Id { get { throw null; } }
        public string LastUpdatedTime { get { throw null; } }
        public string Path { get { throw null; } }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimePropertiesCustomUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesCustomUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesCustomUpdate>
    {
        public ServerlessRuntimePropertiesCustomUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.AdvancedCustomProperties> AdvancedCustomProperties { get { throw null; } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ApplicationType? ApplicationType { get { throw null; } set { } }
        public string ComputeUnits { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ExecutionTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.NetworkInterfaceConfigurationUpdate NetworkInterfaceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.PlatformType? Platform { get { throw null; } set { } }
        public string ServerlessAccountLocation { get { throw null; } set { } }
        public Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeConfigPropertiesUpdate ServerlessRuntimeConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag> ServerlessRuntimeTags { get { throw null; } }
        public string SupplementaryFileLocation { get { throw null; } set { } }
        public string UserContextToken { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesCustomUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesCustomUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesCustomUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesCustomUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesCustomUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesCustomUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimePropertiesCustomUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>
    {
        public ServerlessRuntimeTag() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.ServerlessRuntimeTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails>
    {
        public UserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetailsUpdate>
    {
        public UserDetailsUpdate() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        Azure.ResourceManager.InformaticaDataManagement.Models.UserDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.InformaticaDataManagement.Models.UserDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.InformaticaDataManagement.Models.UserDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
