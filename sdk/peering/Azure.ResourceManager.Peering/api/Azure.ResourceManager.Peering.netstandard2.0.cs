namespace Azure.ResourceManager.Peering
{
    public partial class ConnectionMonitorTestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>, System.Collections.IEnumerable
    {
        protected ConnectionMonitorTestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionMonitorTestName, Azure.ResourceManager.Peering.ConnectionMonitorTestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionMonitorTestName, Azure.ResourceManager.Peering.ConnectionMonitorTestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionMonitorTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionMonitorTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> Get(string connectionMonitorTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>> GetAsync(string connectionMonitorTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectionMonitorTestData : Azure.ResourceManager.Models.ResourceData
    {
        public ConnectionMonitorTestData() { }
        public string Destination { get { throw null; } set { } }
        public int? DestinationPort { get { throw null; } set { } }
        public bool? IsTestSuccessful { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Path { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceAgent { get { throw null; } set { } }
        public int? TestFrequencyInSec { get { throw null; } set { } }
    }
    public partial class ConnectionMonitorTestResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectionMonitorTestResource() { }
        public virtual Azure.ResourceManager.Peering.ConnectionMonitorTestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string peeringServiceName, string connectionMonitorTestName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.ConnectionMonitorTestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.ConnectionMonitorTestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PeerAsnCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeerAsnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeerAsnResource>, System.Collections.IEnumerable
    {
        protected PeerAsnCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeerAsnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string peerAsnName, Azure.ResourceManager.Peering.PeerAsnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeerAsnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string peerAsnName, Azure.ResourceManager.Peering.PeerAsnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string peerAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string peerAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeerAsnResource> Get(string peerAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.PeerAsnResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.PeerAsnResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeerAsnResource>> GetAsync(string peerAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeerAsnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeerAsnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeerAsnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeerAsnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeerAsnData : Azure.ResourceManager.Models.ResourceData
    {
        public PeerAsnData() { }
        public string ErrorMessage { get { throw null; } }
        public int? PeerAsn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.ContactDetail> PeerContactDetail { get { throw null; } }
        public string PeerName { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.ValidationState? ValidationState { get { throw null; } }
    }
    public partial class PeerAsnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PeerAsnResource() { }
        public virtual Azure.ResourceManager.Peering.PeerAsnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string peerAsnName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeerAsnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeerAsnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeerAsnResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeerAsnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeerAsnResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeerAsnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PeeringCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringResource>, System.Collections.IEnumerable
    {
        protected PeeringCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string peeringName, Azure.ResourceManager.Peering.PeeringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string peeringName, Azure.ResourceManager.Peering.PeeringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringResource> Get(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.PeeringResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> GetAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeeringResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeeringResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeeringData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PeeringData(Azure.Core.AzureLocation location, Azure.ResourceManager.Peering.Models.PeeringSku sku, Azure.ResourceManager.Peering.Models.PeeringKind kind) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Peering.Models.PeeringPropertiesDirect Direct { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringPropertiesExchange Exchange { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringKind Kind { get { throw null; } set { } }
        public string PeeringLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringSku Sku { get { throw null; } set { } }
    }
    public static partial class PeeringExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Peering.Models.Enum0> CheckServiceProviderAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Peering.Models.CheckServiceProviderAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.Models.Enum0>> CheckServiceProviderAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Peering.Models.CheckServiceProviderAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix> GetCdnPeeringPrefixes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string peeringLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix> GetCdnPeeringPrefixesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string peeringLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Peering.ConnectionMonitorTestResource GetConnectionMonitorTestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Peering.PeerAsnResource> GetPeerAsn(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string peerAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeerAsnResource>> GetPeerAsnAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string peerAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Peering.PeerAsnResource GetPeerAsnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Peering.PeerAsnCollection GetPeerAsns(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Peering.PeeringResource> GetPeering(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> GetPeeringAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Peering.Models.PeeringLocation> GetPeeringLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Peering.Models.PeeringLocationsKind kind, Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType? directPeeringType = default(Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.PeeringLocation> GetPeeringLocationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Peering.Models.PeeringLocationsKind kind, Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType? directPeeringType = default(Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringRegisteredAsnResource GetPeeringRegisteredAsnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource GetPeeringRegisteredPrefixResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringResource GetPeeringResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringCollection GetPeerings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Peering.PeeringResource> GetPeerings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringResource> GetPeeringsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Peering.PeeringResource> GetPeeringsByLegacyPeering(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string peeringLocation, Azure.ResourceManager.Peering.Models.LegacyPeeringsKind kind, int? asn = default(int?), Azure.ResourceManager.Peering.Models.DirectPeeringType? directPeeringType = default(Azure.ResourceManager.Peering.Models.DirectPeeringType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringResource> GetPeeringsByLegacyPeeringAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string peeringLocation, Azure.ResourceManager.Peering.Models.LegacyPeeringsKind kind, int? asn = default(int?), Azure.ResourceManager.Peering.Models.DirectPeeringType? directPeeringType = default(Azure.ResourceManager.Peering.Models.DirectPeeringType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource> GetPeeringService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string peeringServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource>> GetPeeringServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string peeringServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Peering.Models.PeeringServiceCountry> GetPeeringServiceCountries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.PeeringServiceCountry> GetPeeringServiceCountriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Peering.Models.PeeringServiceLocation> GetPeeringServiceLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.PeeringServiceLocation> GetPeeringServiceLocationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringServicePrefixResource GetPeeringServicePrefixResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Peering.Models.PeeringServiceProvider> GetPeeringServiceProviders(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.PeeringServiceProvider> GetPeeringServiceProvidersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringServiceResource GetPeeringServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringServiceCollection GetPeeringServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Peering.PeeringServiceResource> GetPeeringServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringServiceResource> GetPeeringServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response InitializeConnectionMonitorPeeringService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> InitializeConnectionMonitorPeeringServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Peering.Models.LookingGlassOutput> InvokeLookingGlas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Peering.Models.LookingGlassCommand command, Azure.ResourceManager.Peering.Models.LookingGlassSourceType sourceType, string sourceLocation, string destinationIP, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.Models.LookingGlassOutput>> InvokeLookingGlasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Peering.Models.LookingGlassCommand command, Azure.ResourceManager.Peering.Models.LookingGlassSourceType sourceType, string sourceLocation, string destinationIP, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PeeringRegisteredAsnCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>, System.Collections.IEnumerable
    {
        protected PeeringRegisteredAsnCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string registeredAsnName, Azure.ResourceManager.Peering.PeeringRegisteredAsnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string registeredAsnName, Azure.ResourceManager.Peering.PeeringRegisteredAsnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string registeredAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string registeredAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> Get(string registeredAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>> GetAsync(string registeredAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeeringRegisteredAsnData : Azure.ResourceManager.Models.ResourceData
    {
        public PeeringRegisteredAsnData() { }
        public int? Asn { get { throw null; } set { } }
        public string PeeringServicePrefixKey { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PeeringRegisteredAsnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PeeringRegisteredAsnResource() { }
        public virtual Azure.ResourceManager.Peering.PeeringRegisteredAsnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string peeringName, string registeredAsnName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeeringRegisteredAsnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeeringRegisteredAsnData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PeeringRegisteredPrefixCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>, System.Collections.IEnumerable
    {
        protected PeeringRegisteredPrefixCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string registeredPrefixName, Azure.ResourceManager.Peering.PeeringRegisteredPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string registeredPrefixName, Azure.ResourceManager.Peering.PeeringRegisteredPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string registeredPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string registeredPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> Get(string registeredPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>> GetAsync(string registeredPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeeringRegisteredPrefixData : Azure.ResourceManager.Models.ResourceData
    {
        public PeeringRegisteredPrefixData() { }
        public string ErrorMessage { get { throw null; } }
        public string PeeringServicePrefixKey { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PrefixValidationState? PrefixValidationState { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PeeringRegisteredPrefixResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PeeringRegisteredPrefixResource() { }
        public virtual Azure.ResourceManager.Peering.PeeringRegisteredPrefixData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string peeringName, string registeredPrefixName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeeringRegisteredPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeeringRegisteredPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> Validate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>> ValidateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PeeringResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PeeringResource() { }
        public virtual Azure.ResourceManager.Peering.PeeringData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string peeringName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> GetPeeringRegisteredAsn(string registeredAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>> GetPeeringRegisteredAsnAsync(string registeredAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeeringRegisteredAsnCollection GetPeeringRegisteredAsns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> GetPeeringRegisteredPrefix(string registeredPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>> GetPeeringRegisteredPrefixAsync(string registeredPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeeringRegisteredPrefixCollection GetPeeringRegisteredPrefixes() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.Models.PeeringReceivedRoute> GetReceivedRoutes(string prefix = null, string asPath = null, string originAsValidationState = null, string rpkiValidationState = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.PeeringReceivedRoute> GetReceivedRoutesAsync(string prefix = null, string asPath = null, string originAsValidationState = null, string rpkiValidationState = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringResource> Update(Azure.ResourceManager.Peering.Models.ResourceTags tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> UpdateAsync(Azure.ResourceManager.Peering.Models.ResourceTags tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PeeringServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringServiceResource>, System.Collections.IEnumerable
    {
        protected PeeringServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string peeringServiceName, Azure.ResourceManager.Peering.PeeringServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string peeringServiceName, Azure.ResourceManager.Peering.PeeringServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string peeringServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string peeringServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource> Get(string peeringServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.PeeringServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource>> GetAsync(string peeringServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeeringServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeeringServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeeringServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PeeringServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Peering.Models.LogAnalyticsWorkspaceProperties LogAnalyticsWorkspaceProperties { get { throw null; } set { } }
        public string PeeringServiceLocation { get { throw null; } set { } }
        public string PeeringServiceProvider { get { throw null; } set { } }
        public string ProviderBackupPeeringLocation { get { throw null; } set { } }
        public string ProviderPrimaryPeeringLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
    }
    public partial class PeeringServicePrefixCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringServicePrefixResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringServicePrefixResource>, System.Collections.IEnumerable
    {
        protected PeeringServicePrefixCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringServicePrefixResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string prefixName, Azure.ResourceManager.Peering.PeeringServicePrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringServicePrefixResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string prefixName, Azure.ResourceManager.Peering.PeeringServicePrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string prefixName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string prefixName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServicePrefixResource> Get(string prefixName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.PeeringServicePrefixResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringServicePrefixResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServicePrefixResource>> GetAsync(string prefixName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeeringServicePrefixResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringServicePrefixResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeeringServicePrefixResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringServicePrefixResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeeringServicePrefixData : Azure.ResourceManager.Models.ResourceData
    {
        public PeeringServicePrefixData() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent> Events { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.LearnedType? LearnedType { get { throw null; } }
        public string PeeringServicePrefixKey { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PrefixValidationState? PrefixValidationState { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PeeringServicePrefixResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PeeringServicePrefixResource() { }
        public virtual Azure.ResourceManager.Peering.PeeringServicePrefixData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string peeringServiceName, string prefixName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServicePrefixResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServicePrefixResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringServicePrefixResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeeringServicePrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringServicePrefixResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeeringServicePrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PeeringServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PeeringServiceResource() { }
        public virtual Azure.ResourceManager.Peering.PeeringServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string peeringServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> GetConnectionMonitorTest(string connectionMonitorTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>> GetConnectionMonitorTestAsync(string connectionMonitorTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Peering.ConnectionMonitorTestCollection GetConnectionMonitorTests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServicePrefixResource> GetPeeringServicePrefix(string prefixName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServicePrefixResource>> GetPeeringServicePrefixAsync(string prefixName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeeringServicePrefixCollection GetPeeringServicePrefixes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource> Update(Azure.ResourceManager.Peering.Models.ResourceTags tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource>> UpdateAsync(Azure.ResourceManager.Peering.Models.ResourceTags tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Peering.Models
{
    public partial class BgpSession
    {
        public BgpSession() { }
        public int? MaxPrefixesAdvertisedV4 { get { throw null; } set { } }
        public int? MaxPrefixesAdvertisedV6 { get { throw null; } set { } }
        public string Md5AuthenticationKey { get { throw null; } set { } }
        public string MicrosoftSessionIPv4Address { get { throw null; } set { } }
        public string MicrosoftSessionIPv6Address { get { throw null; } set { } }
        public string PeerSessionIPv4Address { get { throw null; } set { } }
        public string PeerSessionIPv6Address { get { throw null; } set { } }
        public string SessionPrefixV4 { get { throw null; } set { } }
        public string SessionPrefixV6 { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.SessionStateV4? SessionStateV4 { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.SessionStateV6? SessionStateV6 { get { throw null; } }
    }
    public partial class CdnPeeringPrefix : Azure.ResourceManager.Models.ResourceData
    {
        public CdnPeeringPrefix() { }
        public string AzureRegion { get { throw null; } }
        public string AzureService { get { throw null; } }
        public string BgpCommunity { get { throw null; } }
        public bool? IsPrimaryRegion { get { throw null; } }
        public string Prefix { get { throw null; } }
    }
    public partial class CheckServiceProviderAvailabilityContent
    {
        public CheckServiceProviderAvailabilityContent() { }
        public string PeeringServiceLocation { get { throw null; } set { } }
        public string PeeringServiceProvider { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Command : System.IEquatable<Azure.ResourceManager.Peering.Models.Command>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Command(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.Command BgpRoute { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Command Ping { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Command Traceroute { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.Command other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.Command left, Azure.ResourceManager.Peering.Models.Command right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.Command (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.Command left, Azure.ResourceManager.Peering.Models.Command right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionState : System.IEquatable<Azure.ResourceManager.Peering.Models.ConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.ConnectionState Active { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ConnectionState Approved { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ConnectionState None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ConnectionState PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ConnectionState ProvisioningCompleted { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ConnectionState ProvisioningFailed { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ConnectionState ProvisioningStarted { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ConnectionState TypeChangeInProgress { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ConnectionState TypeChangeRequested { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ConnectionState Validating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.ConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.ConnectionState left, Azure.ResourceManager.Peering.Models.ConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.ConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.ConnectionState left, Azure.ResourceManager.Peering.Models.ConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContactDetail
    {
        public ContactDetail() { }
        public string Email { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.Role? Role { get { throw null; } set { } }
    }
    public partial class DirectConnection
    {
        public DirectConnection() { }
        public int? BandwidthInMbps { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.BgpSession BgpSession { get { throw null; } set { } }
        public string ConnectionIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.ConnectionState? ConnectionState { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string MicrosoftTrackingId { get { throw null; } }
        public int? PeeringDBFacilityId { get { throw null; } set { } }
        public int? ProvisionedBandwidthInMbps { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.SessionAddressProvider? SessionAddressProvider { get { throw null; } set { } }
        public bool? UseForPeeringService { get { throw null; } set { } }
    }
    public partial class DirectPeeringFacility
    {
        public DirectPeeringFacility() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.DirectPeeringType? DirectPeeringType { get { throw null; } set { } }
        public int? PeeringDBFacilityId { get { throw null; } set { } }
        public string PeeringDBFacilityLink { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DirectPeeringType : System.IEquatable<Azure.ResourceManager.Peering.Models.DirectPeeringType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DirectPeeringType(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.DirectPeeringType Cdn { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.DirectPeeringType Edge { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.DirectPeeringType EdgeZoneForOperators { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.DirectPeeringType Internal { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.DirectPeeringType Ix { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.DirectPeeringType IxRs { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.DirectPeeringType Transit { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.DirectPeeringType Voice { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.DirectPeeringType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.DirectPeeringType left, Azure.ResourceManager.Peering.Models.DirectPeeringType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.DirectPeeringType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.DirectPeeringType left, Azure.ResourceManager.Peering.Models.DirectPeeringType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Enum0 : System.IEquatable<Azure.ResourceManager.Peering.Models.Enum0>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Enum0(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.Enum0 Available { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Enum0 Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.Enum0 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.Enum0 left, Azure.ResourceManager.Peering.Models.Enum0 right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.Enum0 (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.Enum0 left, Azure.ResourceManager.Peering.Models.Enum0 right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExchangeConnection
    {
        public ExchangeConnection() { }
        public Azure.ResourceManager.Peering.Models.BgpSession BgpSession { get { throw null; } set { } }
        public string ConnectionIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.ConnectionState? ConnectionState { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int? PeeringDBFacilityId { get { throw null; } set { } }
    }
    public partial class ExchangePeeringFacility
    {
        public ExchangePeeringFacility() { }
        public int? BandwidthInMbps { get { throw null; } set { } }
        public string ExchangeName { get { throw null; } set { } }
        public string FacilityIPv4Prefix { get { throw null; } set { } }
        public string FacilityIPv6Prefix { get { throw null; } set { } }
        public string MicrosoftIPv4Address { get { throw null; } set { } }
        public string MicrosoftIPv6Address { get { throw null; } set { } }
        public int? PeeringDBFacilityId { get { throw null; } set { } }
        public string PeeringDBFacilityLink { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Family : System.IEquatable<Azure.ResourceManager.Peering.Models.Family>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Family(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.Family Direct { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Family Exchange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.Family other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.Family left, Azure.ResourceManager.Peering.Models.Family right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.Family (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.Family left, Azure.ResourceManager.Peering.Models.Family right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LearnedType : System.IEquatable<Azure.ResourceManager.Peering.Models.LearnedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LearnedType(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.LearnedType None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.LearnedType ViaServiceProvider { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.LearnedType ViaSession { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.LearnedType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.LearnedType left, Azure.ResourceManager.Peering.Models.LearnedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.LearnedType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.LearnedType left, Azure.ResourceManager.Peering.Models.LearnedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LegacyPeeringsKind : System.IEquatable<Azure.ResourceManager.Peering.Models.LegacyPeeringsKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LegacyPeeringsKind(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.LegacyPeeringsKind Direct { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.LegacyPeeringsKind Exchange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.LegacyPeeringsKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.LegacyPeeringsKind left, Azure.ResourceManager.Peering.Models.LegacyPeeringsKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.LegacyPeeringsKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.LegacyPeeringsKind left, Azure.ResourceManager.Peering.Models.LegacyPeeringsKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogAnalyticsWorkspaceProperties
    {
        public LogAnalyticsWorkspaceProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> ConnectedAgents { get { throw null; } }
        public string Key { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LookingGlassCommand : System.IEquatable<Azure.ResourceManager.Peering.Models.LookingGlassCommand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LookingGlassCommand(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.LookingGlassCommand BgpRoute { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.LookingGlassCommand Ping { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.LookingGlassCommand Traceroute { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.LookingGlassCommand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.LookingGlassCommand left, Azure.ResourceManager.Peering.Models.LookingGlassCommand right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.LookingGlassCommand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.LookingGlassCommand left, Azure.ResourceManager.Peering.Models.LookingGlassCommand right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LookingGlassOutput
    {
        internal LookingGlassOutput() { }
        public Azure.ResourceManager.Peering.Models.Command? Command { get { throw null; } }
        public string Output { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LookingGlassSourceType : System.IEquatable<Azure.ResourceManager.Peering.Models.LookingGlassSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LookingGlassSourceType(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.LookingGlassSourceType AzureRegion { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.LookingGlassSourceType EdgeSite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.LookingGlassSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.LookingGlassSourceType left, Azure.ResourceManager.Peering.Models.LookingGlassSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.LookingGlassSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.LookingGlassSourceType left, Azure.ResourceManager.Peering.Models.LookingGlassSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PeeringBandwidthOffer
    {
        public PeeringBandwidthOffer() { }
        public string OfferName { get { throw null; } set { } }
        public int? ValueInMbps { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringKind : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringKind(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringKind Direct { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringKind Exchange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringKind left, Azure.ResourceManager.Peering.Models.PeeringKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringKind left, Azure.ResourceManager.Peering.Models.PeeringKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PeeringLocation : Azure.ResourceManager.Models.ResourceData
    {
        public PeeringLocation() { }
        public string AzureRegion { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringLocationPropertiesDirect Direct { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.ExchangePeeringFacility> ExchangePeeringFacilities { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringKind? Kind { get { throw null; } set { } }
        public string PeeringLocationValue { get { throw null; } set { } }
    }
    public partial class PeeringLocationPropertiesDirect
    {
        public PeeringLocationPropertiesDirect() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer> BandwidthOffers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.DirectPeeringFacility> PeeringFacilities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringLocationsDirectPeeringType : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringLocationsDirectPeeringType(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType Cdn { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType Edge { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType EdgeZoneForOperators { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType Internal { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType Ix { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType IxRs { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType Transit { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType Voice { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType left, Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType left, Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringLocationsKind : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringLocationsKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringLocationsKind(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringLocationsKind Direct { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringLocationsKind Exchange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringLocationsKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringLocationsKind left, Azure.ResourceManager.Peering.Models.PeeringLocationsKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringLocationsKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringLocationsKind left, Azure.ResourceManager.Peering.Models.PeeringLocationsKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PeeringPropertiesDirect
    {
        public PeeringPropertiesDirect() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.DirectConnection> Connections { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.DirectPeeringType? DirectPeeringType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PeerAsnId { get { throw null; } set { } }
        public bool? UseForPeeringService { get { throw null; } }
    }
    public partial class PeeringPropertiesExchange
    {
        public PeeringPropertiesExchange() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.ExchangeConnection> Connections { get { throw null; } }
        public Azure.Core.ResourceIdentifier PeerAsnId { get { throw null; } set { } }
    }
    public partial class PeeringReceivedRoute
    {
        internal PeeringReceivedRoute() { }
        public string AsPath { get { throw null; } }
        public string NextHop { get { throw null; } }
        public string OriginAsValidationState { get { throw null; } }
        public string Prefix { get { throw null; } }
        public string ReceivedTimestamp { get { throw null; } }
        public string RpkiValidationState { get { throw null; } }
        public string TrustAnchor { get { throw null; } }
    }
    public partial class PeeringServiceCountry : Azure.ResourceManager.Models.ResourceData
    {
        public PeeringServiceCountry() { }
    }
    public partial class PeeringServiceLocation : Azure.ResourceManager.Models.ResourceData
    {
        public PeeringServiceLocation() { }
        public string AzureRegion { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
    public partial class PeeringServicePrefixEvent
    {
        internal PeeringServicePrefixEvent() { }
        public string EventDescription { get { throw null; } }
        public string EventLevel { get { throw null; } }
        public string EventSummary { get { throw null; } }
        public System.DateTimeOffset? EventTimestamp { get { throw null; } }
        public string EventType { get { throw null; } }
    }
    public partial class PeeringServiceProvider : Azure.ResourceManager.Models.ResourceData
    {
        public PeeringServiceProvider() { }
        public System.Collections.Generic.IList<string> PeeringLocations { get { throw null; } }
        public string ServiceProviderName { get { throw null; } set { } }
    }
    public partial class PeeringSku
    {
        public PeeringSku() { }
        public Azure.ResourceManager.Peering.Models.Family? Family { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.Size? Size { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.Tier? Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrefixValidationState : System.IEquatable<Azure.ResourceManager.Peering.Models.PrefixValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrefixValidationState(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PrefixValidationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PrefixValidationState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PrefixValidationState None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PrefixValidationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PrefixValidationState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PrefixValidationState Verified { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PrefixValidationState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PrefixValidationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PrefixValidationState left, Azure.ResourceManager.Peering.Models.PrefixValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PrefixValidationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PrefixValidationState left, Azure.ResourceManager.Peering.Models.PrefixValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Peering.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.ProvisioningState left, Azure.ResourceManager.Peering.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.ProvisioningState left, Azure.ResourceManager.Peering.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTags
    {
        public ResourceTags() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Role : System.IEquatable<Azure.ResourceManager.Peering.Models.Role>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Role(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.Role Escalation { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Role Noc { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Role Other { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Role Policy { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Role Service { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Role Technical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.Role other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.Role left, Azure.ResourceManager.Peering.Models.Role right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.Role (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.Role left, Azure.ResourceManager.Peering.Models.Role right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionAddressProvider : System.IEquatable<Azure.ResourceManager.Peering.Models.SessionAddressProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionAddressProvider(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.SessionAddressProvider Microsoft { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionAddressProvider Peer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.SessionAddressProvider other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.SessionAddressProvider left, Azure.ResourceManager.Peering.Models.SessionAddressProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.SessionAddressProvider (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.SessionAddressProvider left, Azure.ResourceManager.Peering.Models.SessionAddressProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionStateV4 : System.IEquatable<Azure.ResourceManager.Peering.Models.SessionStateV4>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionStateV4(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 Active { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 Connect { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 Established { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 Idle { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 OpenConfirm { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 OpenReceived { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 OpenSent { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 PendingAdd { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 PendingRemove { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV4 PendingUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.SessionStateV4 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.SessionStateV4 left, Azure.ResourceManager.Peering.Models.SessionStateV4 right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.SessionStateV4 (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.SessionStateV4 left, Azure.ResourceManager.Peering.Models.SessionStateV4 right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionStateV6 : System.IEquatable<Azure.ResourceManager.Peering.Models.SessionStateV6>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionStateV6(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 Active { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 Connect { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 Established { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 Idle { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 OpenConfirm { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 OpenReceived { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 OpenSent { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 PendingAdd { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 PendingRemove { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.SessionStateV6 PendingUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.SessionStateV6 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.SessionStateV6 left, Azure.ResourceManager.Peering.Models.SessionStateV6 right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.SessionStateV6 (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.SessionStateV6 left, Azure.ResourceManager.Peering.Models.SessionStateV6 right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Size : System.IEquatable<Azure.ResourceManager.Peering.Models.Size>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Size(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.Size Free { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Size Metered { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Size Unlimited { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.Size other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.Size left, Azure.ResourceManager.Peering.Models.Size right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.Size (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.Size left, Azure.ResourceManager.Peering.Models.Size right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Tier : System.IEquatable<Azure.ResourceManager.Peering.Models.Tier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Tier(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.Tier Basic { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.Tier Premium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.Tier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.Tier left, Azure.ResourceManager.Peering.Models.Tier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.Tier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.Tier left, Azure.ResourceManager.Peering.Models.Tier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationState : System.IEquatable<Azure.ResourceManager.Peering.Models.ValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationState(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.ValidationState Approved { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ValidationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ValidationState None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.ValidationState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.ValidationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.ValidationState left, Azure.ResourceManager.Peering.Models.ValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.ValidationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.ValidationState left, Azure.ResourceManager.Peering.Models.ValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
