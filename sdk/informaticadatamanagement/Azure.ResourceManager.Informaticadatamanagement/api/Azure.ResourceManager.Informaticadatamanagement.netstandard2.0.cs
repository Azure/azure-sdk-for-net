namespace Azure.ResourceManager.Informaticadatamanagement
{
    public static partial class InformaticadatamanagementExtensions
    {
        public static Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource GetInformaticaOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> GetInformaticaOrganizationResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>> GetInformaticaOrganizationResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceCollection GetInformaticaOrganizationResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> GetInformaticaOrganizationResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> GetInformaticaOrganizationResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource GetInformaticaServerlessRuntimeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class InformaticaOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InformaticaOrganizationResource() { }
        public virtual Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList> GetAllServerlessRuntimes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList>> GetAllServerlessRuntimesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> GetInformaticaServerlessRuntimeResource(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>> GetInformaticaServerlessRuntimeResourceAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceCollection GetInformaticaServerlessRuntimeResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse> GetServerlessMetadata(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse>> GetServerlessMetadataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> Update(Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>> UpdateAsync(Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InformaticaOrganizationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>, System.Collections.IEnumerable
    {
        protected InformaticaOrganizationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InformaticaOrganizationResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>
    {
        public InformaticaOrganizationResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails CompanyDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties InformaticaProperties { get { throw null; } set { } }
        public string LinkOrganizationToken { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails UserDetails { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InformaticaServerlessRuntimeResource() { }
        public virtual Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse> CheckDependencies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse>> CheckDependenciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string serverlessRuntimeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> ServerlessResourceById(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>> ServerlessResourceByIdAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartFailedServerlessRuntime(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartFailedServerlessRuntimeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> Update(Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>> UpdateAsync(Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>, System.Collections.IEnumerable
    {
        protected InformaticaServerlessRuntimeResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverlessRuntimeName, Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverlessRuntimeName, Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> Get(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>> GetAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> GetIfExists(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>> GetIfExistsAsync(string serverlessRuntimeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>
    {
        public InformaticaServerlessRuntimeResourceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties> AdvancedCustomProperties { get { throw null; } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType? ApplicationType { get { throw null; } set { } }
        public string ComputeUnits { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ExecutionTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration NetworkInterfaceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType? Platform { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ServerlessAccountLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties ServerlessRuntimeConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag> ServerlessRuntimeTags { get { throw null; } }
        public string SupplementaryFileLocation { get { throw null; } set { } }
        public string UserContextToken { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Informaticadatamanagement.Mocking
{
    public partial class MockableInformaticadatamanagementArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableInformaticadatamanagementArmClient() { }
        public virtual Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource GetInformaticaOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResource GetInformaticaServerlessRuntimeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableInformaticadatamanagementResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableInformaticadatamanagementResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> GetInformaticaOrganizationResource(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource>> GetInformaticaOrganizationResourceAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceCollection GetInformaticaOrganizationResources() { throw null; }
    }
    public partial class MockableInformaticadatamanagementSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableInformaticadatamanagementSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> GetInformaticaOrganizationResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResource> GetInformaticaOrganizationResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Informaticadatamanagement.Models
{
    public partial class AdvancedCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties>
    {
        public AdvancedCustomProperties() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationConfigs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs>
    {
        public ApplicationConfigs(string applicationConfigsType, string name, string value, string platform, string customized, string defaultValue) { }
        public string ApplicationConfigsType { get { throw null; } set { } }
        public string Customized { get { throw null; } set { } }
        public string DefaultValue { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Platform { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationType : System.IEquatable<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType CDI { get { throw null; } }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType Cdie { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType left, Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType left, Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationTypeMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata>
    {
        internal ApplicationTypeMetadata() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmInformaticadatamanagementModelFactory
    {
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata ApplicationTypeMetadata(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse CheckDependenciesResponse(int count = 0, string id = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency> references = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata ComputeUnitsMetadata(string name = null, System.Collections.Generic.IEnumerable<string> value = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData InfaRuntimeResourceFetchMetaData(string name = null, string createdTime = null, string updatedTime = null, string createdBy = null, string updatedBy = null, string id = null, Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType runtimeType = default(Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType), string status = null, string statusLocalized = null, string statusMessage = null, Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties serverlessConfigProperties = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties InfaServerlessFetchConfigProperties(string subnet = null, string applicationType = null, string resourceGroupName = null, string advancedCustomProperties = null, string supplementaryFileLocation = null, string platform = null, string tags = null, string vnet = null, string executionTimeout = null, string computeUnits = null, System.Guid? tenantId = default(System.Guid?), string subscriptionId = null, string region = null, string serverlessArmResourceId = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.InformaticaOrganizationResourceData InformaticaOrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState?), Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties informaticaProperties = null, Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails marketplaceDetails = null, Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails userDetails = null, Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails companyDetails = null, string linkOrganizationToken = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.InformaticaServerlessRuntimeResourceData InformaticaServerlessRuntimeResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState?), string description = null, Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType? platform = default(Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType?), Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType? applicationType = default(Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType?), string computeUnits = null, string executionTimeout = null, string serverlessAccountLocation = null, Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration networkInterfaceConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties> advancedCustomProperties = null, string supplementaryFileLocation = null, Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties serverlessRuntimeConfig = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag> serverlessRuntimeTags = null, string userContextToken = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList InformaticaServerlessRuntimeResourceList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData> informaticaRuntimeResources = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata RegionsMetadata(string id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties ServerlessConfigProperties(Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType? platform = default(Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata> applicationTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata> computeUnits = null, string executionTimeout = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata> regions = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse ServerlessMetadataResponse(Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType? runtimeType = default(Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType?), Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties serverlessConfigProperties = null, Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties serverlessRuntimeConfigProperties = null) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency ServerlessRuntimeDependency(string id = null, string appContextId = null, string path = null, string documentType = null, string description = null, string lastUpdatedTime = null) { throw null; }
    }
    public partial class CdiConfigProps : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps>
    {
        public CdiConfigProps(string engineName, string engineVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs> applicationConfigs) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationConfigs> ApplicationConfigs { get { throw null; } }
        public string EngineName { get { throw null; } set { } }
        public string EngineVersion { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckDependenciesResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse>
    {
        internal CheckDependenciesResponse() { }
        public int Count { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency> References { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CheckDependenciesResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails>
    {
        public CompanyDetails() { }
        public string Business { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public int? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompanyDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetailsUpdate>
    {
        public CompanyDetailsUpdate() { }
        public string Business { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public int? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeUnitsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata>
    {
        internal ComputeUnitsMetadata() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Value { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InfaRuntimeResourceFetchMetaData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData>
    {
        internal InfaRuntimeResourceFetchMetaData() { }
        public string CreatedBy { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType RuntimeType { get { throw null; } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties ServerlessConfigProperties { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusLocalized { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public string UpdatedTime { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InfaServerlessFetchConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties>
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
        Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InfaServerlessFetchConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaOrganizationResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch>
    {
        public InformaticaOrganizationResourcePatch() { }
        public Azure.ResourceManager.Informaticadatamanagement.Models.OrganizationPropertiesCustomUpdate Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties>
    {
        public InformaticaProperties() { }
        public string InformaticaRegion { get { throw null; } set { } }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResourceList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList>
    {
        internal InformaticaServerlessRuntimeResourceList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Informaticadatamanagement.Models.InfaRuntimeResourceFetchMetaData> InformaticaRuntimeResources { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourceList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InformaticaServerlessRuntimeResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch>
    {
        public InformaticaServerlessRuntimeResourcePatch() { }
        public Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimePropertiesCustomUpdate Properties { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaServerlessRuntimeResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(string marketplaceSubscriptionId, Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails offerDetails) { }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails OfferDetails { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetailsUpdate>
    {
        public MarketplaceDetailsUpdate() { }
        public string MarketplaceSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetailsUpdate OfferDetails { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration>
    {
        public NetworkInterfaceConfiguration(string vnetId, string subnetId) { }
        public string SubnetId { get { throw null; } set { } }
        public string VnetId { get { throw null; } set { } }
        public string VnetResourceGuid { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkInterfaceConfigurationUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfigurationUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfigurationUpdate>
    {
        public NetworkInterfaceConfigurationUpdate() { }
        public string SubnetId { get { throw null; } set { } }
        public string VnetId { get { throw null; } set { } }
        public string VnetResourceGuid { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfigurationUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfigurationUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfigurationUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfigurationUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfigurationUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfigurationUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfigurationUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails>
    {
        public OfferDetails(string publisherId, string offerId, string planId, string planName, string termId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfferDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetailsUpdate>
    {
        public OfferDetailsUpdate() { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OfferDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrganizationPropertiesCustomUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.OrganizationPropertiesCustomUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OrganizationPropertiesCustomUpdate>
    {
        public OrganizationPropertiesCustomUpdate() { }
        public Azure.ResourceManager.Informaticadatamanagement.Models.CompanyDetailsUpdate CompanyDetails { get { throw null; } set { } }
        public string ExistingResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.InformaticaOrganizationResourcePatch InformaticaOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.MarketplaceDetailsUpdate MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.UserDetailsUpdate UserDetails { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.OrganizationPropertiesCustomUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.OrganizationPropertiesCustomUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.OrganizationPropertiesCustomUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.OrganizationPropertiesCustomUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OrganizationPropertiesCustomUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OrganizationPropertiesCustomUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.OrganizationPropertiesCustomUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlatformType : System.IEquatable<Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlatformType(string value) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType Azure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType left, Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType left, Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState left, Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState left, Azure.ResourceManager.Informaticadatamanagement.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegionsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata>
    {
        internal RegionsMetadata() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuntimeType : System.IEquatable<Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuntimeType(string value) { throw null; }
        public static Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType Serverless { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType left, Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType left, Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerlessConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties>
    {
        internal ServerlessConfigProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationTypeMetadata> ApplicationTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Informaticadatamanagement.Models.ComputeUnitsMetadata> ComputeUnits { get { throw null; } }
        public string ExecutionTimeout { get { throw null; } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType? Platform { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Informaticadatamanagement.Models.RegionsMetadata> Regions { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessMetadataResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse>
    {
        internal ServerlessMetadataResponse() { }
        public Azure.ResourceManager.Informaticadatamanagement.Models.RuntimeType? RuntimeType { get { throw null; } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessConfigProperties ServerlessConfigProperties { get { throw null; } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties ServerlessRuntimeConfigProperties { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessMetadataResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties>
    {
        public ServerlessRuntimeConfigProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps> CdiConfigProps { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps> CdieConfigProps { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeConfigPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigPropertiesUpdate>
    {
        public ServerlessRuntimeConfigPropertiesUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps> CdiConfigProps { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Informaticadatamanagement.Models.CdiConfigProps> CdieConfigProps { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency>
    {
        internal ServerlessRuntimeDependency() { }
        public string AppContextId { get { throw null; } }
        public string Description { get { throw null; } }
        public string DocumentType { get { throw null; } }
        public string Id { get { throw null; } }
        public string LastUpdatedTime { get { throw null; } }
        public string Path { get { throw null; } }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimePropertiesCustomUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimePropertiesCustomUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimePropertiesCustomUpdate>
    {
        public ServerlessRuntimePropertiesCustomUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Informaticadatamanagement.Models.AdvancedCustomProperties> AdvancedCustomProperties { get { throw null; } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.ApplicationType? ApplicationType { get { throw null; } set { } }
        public string ComputeUnits { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string ExecutionTimeout { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.NetworkInterfaceConfigurationUpdate NetworkInterfaceConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.PlatformType? Platform { get { throw null; } set { } }
        public string ServerlessAccountLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeConfigPropertiesUpdate ServerlessRuntimeConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag> ServerlessRuntimeTags { get { throw null; } }
        public string SupplementaryFileLocation { get { throw null; } set { } }
        public string UserContextToken { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimePropertiesCustomUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimePropertiesCustomUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimePropertiesCustomUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimePropertiesCustomUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimePropertiesCustomUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimePropertiesCustomUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimePropertiesCustomUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerlessRuntimeTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag>
    {
        public ServerlessRuntimeTag() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.ServerlessRuntimeTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails>
    {
        public UserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetailsUpdate>
    {
        public UserDetailsUpdate() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        Azure.ResourceManager.Informaticadatamanagement.Models.UserDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Informaticadatamanagement.Models.UserDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Informaticadatamanagement.Models.UserDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
