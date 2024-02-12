namespace Azure.ResourceManager.ServiceNetworking
{
    public partial class AssociationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.AssociationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.AssociationResource>, System.Collections.IEnumerable
    {
        protected AssociationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.AssociationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.ServiceNetworking.AssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.AssociationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.ServiceNetworking.AssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> Get(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.AssociationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.AssociationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> GetAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.AssociationResource> GetIfExists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.AssociationResource>> GetIfExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.AssociationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.AssociationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.AssociationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.AssociationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssociationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.AssociationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>
    {
        public AssociationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ServiceNetworking.Models.AssociationType? AssociationType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        Azure.ResourceManager.ServiceNetworking.AssociationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.AssociationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssociationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssociationResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.AssociationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName, string associationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> Update(Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontendCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.FrontendResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.FrontendResource>, System.Collections.IEnumerable
    {
        protected FrontendCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.FrontendResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string frontendName, Azure.ResourceManager.ServiceNetworking.FrontendData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.FrontendResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string frontendName, Azure.ResourceManager.ServiceNetworking.FrontendData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> Get(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.FrontendResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.FrontendResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> GetAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.FrontendResource> GetIfExists(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.FrontendResource>> GetIfExistsAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.FrontendResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.FrontendResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.FrontendResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.FrontendResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontendData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.FrontendData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>
    {
        public FrontendData(Azure.Core.AzureLocation location) { }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.ServiceNetworking.FrontendData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.FrontendData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontendResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontendResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.FrontendData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName, string frontendName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> Update(Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ServiceNetworkingExtensions
    {
        public static Azure.ResourceManager.ServiceNetworking.AssociationResource GetAssociationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.FrontendResource GetFrontendResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficController(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> GetTrafficControllerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerResource GetTrafficControllerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerCollection GetTrafficControllers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficControllers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficControllersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficControllerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>, System.Collections.IEnumerable
    {
        protected TrafficControllerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trafficControllerName, Azure.ResourceManager.ServiceNetworking.TrafficControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trafficControllerName, Azure.ResourceManager.ServiceNetworking.TrafficControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> Get(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> GetAsync(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetIfExists(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> GetIfExistsAsync(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrafficControllerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>
    {
        public TrafficControllerData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Associations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ConfigurationEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Frontends { get { throw null; } }
        public Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficControllerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficControllerResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> GetAssociation(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> GetAssociationAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.AssociationCollection GetAssociations() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> GetFrontend(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> GetFrontendAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.FrontendCollection GetFrontends() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> Update(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceNetworking.Mocking
{
    public partial class MockableServiceNetworkingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceNetworkingArmClient() { }
        public virtual Azure.ResourceManager.ServiceNetworking.AssociationResource GetAssociationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.FrontendResource GetFrontendResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerResource GetTrafficControllerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableServiceNetworkingResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceNetworkingResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficController(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> GetTrafficControllerAsync(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerCollection GetTrafficControllers() { throw null; }
    }
    public partial class MockableServiceNetworkingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceNetworkingSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficControllers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficControllersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceNetworking.Models
{
    public static partial class ArmServiceNetworkingModelFactory
    {
        public static Azure.ResourceManager.ServiceNetworking.AssociationData AssociationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ServiceNetworking.Models.AssociationType? associationType = default(Azure.ResourceManager.ServiceNetworking.Models.AssociationType?), Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.FrontendData FrontendData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string fqdn = null, Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerData TrafficControllerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> configurationEndpoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> frontends = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> associations = null, Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState?)) { throw null; }
    }
    public partial class AssociationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>
    {
        public AssociationPatch() { }
        public Azure.ResourceManager.ServiceNetworking.Models.AssociationType? AssociationType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssociationType : System.IEquatable<Azure.ResourceManager.ServiceNetworking.Models.AssociationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssociationType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.Models.AssociationType Subnets { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.Models.AssociationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.Models.AssociationType left, Azure.ResourceManager.ServiceNetworking.Models.AssociationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.Models.AssociationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.Models.AssociationType left, Azure.ResourceManager.ServiceNetworking.Models.AssociationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontendPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>
    {
        public FrontendPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState left, Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState left, Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficControllerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>
    {
        public TrafficControllerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
