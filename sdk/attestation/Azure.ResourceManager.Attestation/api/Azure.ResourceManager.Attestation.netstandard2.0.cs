namespace Azure.ResourceManager.Attestation
{
    public static partial class AttestationExtensions
    {
        public static Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource GetAttestationPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvider(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> GetAttestationProviderAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Attestation.AttestationProviderResource GetAttestationProviderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Attestation.AttestationProviderCollection GetAttestationProviders(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProviders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvidersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvidersByDefaultProvider(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvidersByDefaultProviderAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> GetDefaultByLocationAttestationProvider(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> GetDefaultByLocationAttestationProviderAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AttestationPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected AttestationPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttestationPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData>
    {
        public AttestationPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public string PrivateEndpointStringId { get { throw null; } }
        public Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttestationPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AttestationPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AttestationProviderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Attestation.AttestationProviderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Attestation.AttestationProviderResource>, System.Collections.IEnumerable
    {
        protected AttestationProviderCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Attestation.AttestationProviderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string providerName, Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Attestation.AttestationProviderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string providerName, Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> Get(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> GetAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Attestation.AttestationProviderResource> GetIfExists(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Attestation.AttestationProviderResource>> GetIfExistsAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Attestation.AttestationProviderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Attestation.AttestationProviderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Attestation.AttestationProviderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Attestation.AttestationProviderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttestationProviderData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.AttestationProviderData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.AttestationProviderData>
    {
        public AttestationProviderData(Azure.Core.AzureLocation location) { }
        public System.Uri AttestUri { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Attestation.Models.AttestationServiceStatus? Status { get { throw null; } set { } }
        public string TrustModel { get { throw null; } set { } }
        Azure.ResourceManager.Attestation.AttestationProviderData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.AttestationProviderData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.AttestationProviderData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Attestation.AttestationProviderData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.AttestationProviderData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.AttestationProviderData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.AttestationProviderData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttestationProviderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AttestationProviderResource() { }
        public virtual Azure.ResourceManager.Attestation.AttestationProviderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> GetAttestationPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>> GetAttestationPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionCollection GetAttestationPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource> GetPrivateLinkResourcesByProvider(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource> GetPrivateLinkResourcesByProviderAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> Update(Azure.ResourceManager.Attestation.Models.AttestationProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> UpdateAsync(Azure.ResourceManager.Attestation.Models.AttestationProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Attestation.Mocking
{
    public partial class MockableAttestationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAttestationArmClient() { }
        public virtual Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource GetAttestationPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Attestation.AttestationProviderResource GetAttestationProviderResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAttestationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAttestationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvider(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> GetAttestationProviderAsync(string providerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Attestation.AttestationProviderCollection GetAttestationProviders() { throw null; }
    }
    public partial class MockableAttestationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAttestationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProviders(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvidersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvidersByDefaultProvider(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvidersByDefaultProviderAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> GetDefaultByLocationAttestationProvider(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> GetDefaultByLocationAttestationProviderAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Attestation.Models
{
    public static partial class ArmAttestationModelFactory
    {
        public static Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData AttestationPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string privateEndpointStringId = null, Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource AttestationPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent AttestationProviderCreateOrUpdateContent(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams properties = null) { throw null; }
        public static Azure.ResourceManager.Attestation.AttestationProviderData AttestationProviderData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string trustModel = null, Azure.ResourceManager.Attestation.Models.AttestationServiceStatus? status = default(Azure.ResourceManager.Attestation.Models.AttestationServiceStatus?), System.Uri attestUri = null, Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType? publicNetworkAccess = default(Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.Attestation.Models.JsonWebKey JsonWebKey(string alg = null, string crv = null, string d = null, string dp = null, string dq = null, string e = null, string k = null, string kid = null, string kty = null, string n = null, string p = null, string q = null, string qi = null, string use = null, string x = null, System.Collections.Generic.IEnumerable<string> x5C = null, string y = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestationPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestationPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestationPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestationPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AttestationPrivateLinkResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource>
    {
        public AttestationPrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttestationPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState>
    {
        public AttestationPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttestationProviderCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent>
    {
        public AttestationProviderCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams properties) { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationProviderCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttestationProviderPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationProviderPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationProviderPatch>
    {
        public AttestationProviderPatch() { }
        public Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType? AttestationServicePatchSpecificParamsPublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Attestation.Models.AttestationProviderPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationProviderPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationProviderPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Attestation.Models.AttestationProviderPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationProviderPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationProviderPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationProviderPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttestationServiceCreationSpecificParams : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams>
    {
        public AttestationServiceCreationSpecificParams() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Attestation.Models.JsonWebKey> PolicySigningCertificatesKeys { get { throw null; } }
        public Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttestationServiceStatus : System.IEquatable<Azure.ResourceManager.Attestation.Models.AttestationServiceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttestationServiceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Attestation.Models.AttestationServiceStatus Error { get { throw null; } }
        public static Azure.ResourceManager.Attestation.Models.AttestationServiceStatus NotReady { get { throw null; } }
        public static Azure.ResourceManager.Attestation.Models.AttestationServiceStatus Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Attestation.Models.AttestationServiceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Attestation.Models.AttestationServiceStatus left, Azure.ResourceManager.Attestation.Models.AttestationServiceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Attestation.Models.AttestationServiceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Attestation.Models.AttestationServiceStatus left, Azure.ResourceManager.Attestation.Models.AttestationServiceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JsonWebKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.JsonWebKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.JsonWebKey>
    {
        public JsonWebKey(string kty) { }
        public string Alg { get { throw null; } set { } }
        public string Crv { get { throw null; } set { } }
        public string D { get { throw null; } set { } }
        public string Dp { get { throw null; } set { } }
        public string Dq { get { throw null; } set { } }
        public string E { get { throw null; } set { } }
        public string K { get { throw null; } set { } }
        public string Kid { get { throw null; } set { } }
        public string Kty { get { throw null; } }
        public string N { get { throw null; } set { } }
        public string P { get { throw null; } set { } }
        public string Q { get { throw null; } set { } }
        public string Qi { get { throw null; } set { } }
        public string Use { get { throw null; } set { } }
        public string X { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> X5C { get { throw null; } }
        public string Y { get { throw null; } set { } }
        Azure.ResourceManager.Attestation.Models.JsonWebKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.JsonWebKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Attestation.Models.JsonWebKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Attestation.Models.JsonWebKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.JsonWebKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.JsonWebKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Attestation.Models.JsonWebKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType left, Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType left, Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
