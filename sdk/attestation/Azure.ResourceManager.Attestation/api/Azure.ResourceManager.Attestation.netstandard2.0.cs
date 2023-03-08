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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttestationPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public AttestationPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Attestation.Models.AttestationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Attestation.AttestationProviderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Attestation.AttestationProviderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Attestation.AttestationProviderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Attestation.AttestationProviderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttestationProviderData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AttestationProviderData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Uri AttestUri { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Attestation.AttestationPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Attestation.Models.AttestationServiceStatus? Status { get { throw null; } set { } }
        public string TrustModel { get { throw null; } set { } }
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
namespace Azure.ResourceManager.Attestation.Mock
{
    public partial class AttestationProviderResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected AttestationProviderResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProviders(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvidersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvidersByDefaultProvider(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Attestation.AttestationProviderResource> GetAttestationProvidersByDefaultProviderAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource> GetDefaultByLocationAttestationProvider(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Attestation.AttestationProviderResource>> GetDefaultByLocationAttestationProviderAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.Attestation.AttestationProviderCollection GetAttestationProviders() { throw null; }
    }
}
namespace Azure.ResourceManager.Attestation.Models
{
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
    public partial class AttestationPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public AttestationPrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class AttestationPrivateLinkServiceConnectionState
    {
        public AttestationPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Attestation.Models.AttestationPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class AttestationProviderCreateOrUpdateContent
    {
        public AttestationProviderCreateOrUpdateContent(Azure.Core.AzureLocation location, Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams properties) { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.Attestation.Models.AttestationServiceCreationSpecificParams Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AttestationProviderPatch
    {
        public AttestationProviderPatch() { }
        public Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType? AttestationServicePatchSpecificParamsPublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AttestationServiceCreationSpecificParams
    {
        public AttestationServiceCreationSpecificParams() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Attestation.Models.JsonWebKey> PolicySigningCertificatesKeys { get { throw null; } }
        public Azure.ResourceManager.Attestation.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
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
    public partial class JsonWebKey
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
