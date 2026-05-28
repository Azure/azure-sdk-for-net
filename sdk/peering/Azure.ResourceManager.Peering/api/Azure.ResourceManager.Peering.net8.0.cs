namespace Azure.ResourceManager.Peering
{
    public partial class AzureResourceManagerPeeringContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPeeringContext() { }
        public static Azure.ResourceManager.Peering.AzureResourceManagerPeeringContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> GetIfExists(string connectionMonitorTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>> GetIfExistsAsync(string connectionMonitorTestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.ConnectionMonitorTestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.ConnectionMonitorTestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectionMonitorTestData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>
    {
        public ConnectionMonitorTestData() { }
        public string Destination { get { throw null; } set { } }
        public int? DestinationPort { get { throw null; } set { } }
        public bool? IsTestSuccessful { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Path { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceAgent { get { throw null; } set { } }
        public int? TestFrequencyInSec { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.ConnectionMonitorTestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.ConnectionMonitorTestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionMonitorTestResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>
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
        Azure.ResourceManager.Peering.ConnectionMonitorTestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.ConnectionMonitorTestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.ConnectionMonitorTestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Peering.PeerAsnResource> GetIfExists(string peerAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Peering.PeerAsnResource>> GetIfExistsAsync(string peerAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeerAsnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeerAsnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeerAsnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeerAsnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeerAsnData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeerAsnData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeerAsnData>
    {
        public PeerAsnData() { }
        public string ErrorMessage { get { throw null; } }
        public int? PeerAsn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.PeerAsnContactDetail> PeerContactDetail { get { throw null; } }
        public string PeerName { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeerAsnValidationState? ValidationState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeerAsnData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeerAsnData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeerAsnData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeerAsnData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeerAsnData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeerAsnData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeerAsnData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeerAsnResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeerAsnData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeerAsnData>
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
        Azure.ResourceManager.Peering.PeerAsnData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeerAsnData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeerAsnData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeerAsnData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeerAsnData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeerAsnData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeerAsnData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Peering.PeeringResource> GetIfExists(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Peering.PeeringResource>> GetIfExistsAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeeringResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeeringResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeeringData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringData>
    {
        public PeeringData(Azure.Core.AzureLocation location, Azure.ResourceManager.Peering.Models.PeeringSku sku, Azure.ResourceManager.Peering.Models.PeeringKind kind) { }
        public Azure.ResourceManager.Peering.Models.DirectPeeringProperties Direct { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.ExchangePeeringProperties Exchange { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringKind Kind { get { throw null; } set { } }
        public string PeeringLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class PeeringExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability> CheckPeeringServiceProviderAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability>> CheckPeeringServiceProviderAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response InitializePeeringServiceConnectionMonitor(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> InitializePeeringServiceConnectionMonitorAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Peering.Models.LookingGlassOutput> InvokeLookingGlass(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Peering.Models.LookingGlassCommand command, Azure.ResourceManager.Peering.Models.LookingGlassSourceType sourceType, string sourceLocation, string destinationIP, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.Models.LookingGlassOutput>> InvokeLookingGlassAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Peering.Models.LookingGlassCommand command, Azure.ResourceManager.Peering.Models.LookingGlassSourceType sourceType, string sourceLocation, string destinationIP, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> GetIfExists(string registeredAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>> GetIfExistsAsync(string registeredAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredAsnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeeringRegisteredAsnData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>
    {
        public PeeringRegisteredAsnData() { }
        public int? Asn { get { throw null; } set { } }
        public string PeeringServicePrefixKey { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringRegisteredAsnData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringRegisteredAsnData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringRegisteredAsnResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>
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
        Azure.ResourceManager.Peering.PeeringRegisteredAsnData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringRegisteredAsnData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredAsnData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> GetIfExists(string registeredPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>> GetIfExistsAsync(string registeredPrefixName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeeringRegisteredPrefixData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>
    {
        public PeeringRegisteredPrefixData() { }
        public string ErrorMessage { get { throw null; } }
        public string PeeringServicePrefixKey { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState? PrefixValidationState { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringRegisteredPrefixData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringRegisteredPrefixData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringRegisteredPrefixResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>
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
        Azure.ResourceManager.Peering.PeeringRegisteredPrefixData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringRegisteredPrefixData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringRegisteredPrefixData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeeringRegisteredPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeeringRegisteredPrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource> Validate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource>> ValidateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PeeringResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringData>
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
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix> GetRpUnbilledPrefixes(bool? consolidate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix> GetRpUnbilledPrefixesAsync(bool? consolidate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Peering.PeeringData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringResource> Update(Azure.ResourceManager.Peering.Models.PeeringPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> UpdateAsync(Azure.ResourceManager.Peering.Models.PeeringPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Peering.PeeringServiceResource> GetIfExists(string peeringServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Peering.PeeringServiceResource>> GetIfExistsAsync(string peeringServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeeringServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeeringServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeeringServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServiceData>
    {
        public PeeringServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties LogAnalyticsWorkspaceProperties { get { throw null; } set { } }
        public string PeeringServiceLocation { get { throw null; } set { } }
        public string PeeringServiceProvider { get { throw null; } set { } }
        public string ProviderBackupPeeringLocation { get { throw null; } set { } }
        public string ProviderPrimaryPeeringLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringProvisioningState? ProvisioningState { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Peering.PeeringServicePrefixResource> GetIfExists(string prefixName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Peering.PeeringServicePrefixResource>> GetIfExistsAsync(string prefixName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Peering.PeeringServicePrefixResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Peering.PeeringServicePrefixResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Peering.PeeringServicePrefixResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.PeeringServicePrefixResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PeeringServicePrefixData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>
    {
        public PeeringServicePrefixData() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent> Events { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringLearnedType? LearnedType { get { throw null; } }
        public string PeeringServicePrefixKey { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState? PrefixValidationState { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringServicePrefixData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringServicePrefixData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringServicePrefixResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>
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
        Azure.ResourceManager.Peering.PeeringServicePrefixData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringServicePrefixData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServicePrefixData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringServicePrefixResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeeringServicePrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Peering.PeeringServicePrefixResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Peering.PeeringServicePrefixData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PeeringServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServiceData>
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
        Azure.ResourceManager.Peering.PeeringServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.PeeringServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.PeeringServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.PeeringServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource> Update(Azure.ResourceManager.Peering.Models.PeeringServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource>> UpdateAsync(Azure.ResourceManager.Peering.Models.PeeringServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Peering.Mocking
{
    public partial class MockablePeeringArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePeeringArmClient() { }
        public virtual Azure.ResourceManager.Peering.ConnectionMonitorTestResource GetConnectionMonitorTestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeerAsnResource GetPeerAsnResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeeringRegisteredAsnResource GetPeeringRegisteredAsnResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeeringRegisteredPrefixResource GetPeeringRegisteredPrefixResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeeringResource GetPeeringResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeeringServicePrefixResource GetPeeringServicePrefixResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeeringServiceResource GetPeeringServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePeeringResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePeeringResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringResource> GetPeering(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringResource>> GetPeeringAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeeringCollection GetPeerings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource> GetPeeringService(string peeringServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeeringServiceResource>> GetPeeringServiceAsync(string peeringServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeeringServiceCollection GetPeeringServices() { throw null; }
    }
    public partial class MockablePeeringSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePeeringSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability> CheckPeeringServiceProviderAvailability(Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability>> CheckPeeringServiceProviderAvailabilityAsync(Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix> GetCdnPeeringPrefixes(string peeringLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix> GetCdnPeeringPrefixesAsync(string peeringLocation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.PeerAsnResource> GetPeerAsn(string peerAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.PeerAsnResource>> GetPeerAsnAsync(string peerAsnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Peering.PeerAsnCollection GetPeerAsns() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.Models.PeeringLocation> GetPeeringLocations(Azure.ResourceManager.Peering.Models.PeeringLocationsKind kind, Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType? directPeeringType = default(Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.PeeringLocation> GetPeeringLocationsAsync(Azure.ResourceManager.Peering.Models.PeeringLocationsKind kind, Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType? directPeeringType = default(Azure.ResourceManager.Peering.Models.PeeringLocationsDirectPeeringType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.PeeringResource> GetPeerings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringResource> GetPeeringsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.PeeringResource> GetPeeringsByLegacyPeering(string peeringLocation, Azure.ResourceManager.Peering.Models.LegacyPeeringsKind kind, int? asn = default(int?), Azure.ResourceManager.Peering.Models.DirectPeeringType? directPeeringType = default(Azure.ResourceManager.Peering.Models.DirectPeeringType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringResource> GetPeeringsByLegacyPeeringAsync(string peeringLocation, Azure.ResourceManager.Peering.Models.LegacyPeeringsKind kind, int? asn = default(int?), Azure.ResourceManager.Peering.Models.DirectPeeringType? directPeeringType = default(Azure.ResourceManager.Peering.Models.DirectPeeringType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.Models.PeeringServiceCountry> GetPeeringServiceCountries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.PeeringServiceCountry> GetPeeringServiceCountriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.Models.PeeringServiceLocation> GetPeeringServiceLocations(string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.PeeringServiceLocation> GetPeeringServiceLocationsAsync(string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.Models.PeeringServiceProvider> GetPeeringServiceProviders(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.Models.PeeringServiceProvider> GetPeeringServiceProvidersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Peering.PeeringServiceResource> GetPeeringServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Peering.PeeringServiceResource> GetPeeringServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response InitializePeeringServiceConnectionMonitor(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> InitializePeeringServiceConnectionMonitorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Peering.Models.LookingGlassOutput> InvokeLookingGlass(Azure.ResourceManager.Peering.Models.LookingGlassCommand command, Azure.ResourceManager.Peering.Models.LookingGlassSourceType sourceType, string sourceLocation, string destinationIP, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Peering.Models.LookingGlassOutput>> InvokeLookingGlassAsync(Azure.ResourceManager.Peering.Models.LookingGlassCommand command, Azure.ResourceManager.Peering.Models.LookingGlassSourceType sourceType, string sourceLocation, string destinationIP, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Peering.Models
{
    public static partial class ArmPeeringModelFactory
    {
        public static Azure.ResourceManager.Peering.Models.CdnPeeringPrefix CdnPeeringPrefix(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string prefix = null, Azure.Core.AzureLocation? azureRegion = default(Azure.Core.AzureLocation?), string azureService = null, bool? isPrimaryRegion = default(bool?), string bgpCommunity = null) { throw null; }
        public static Azure.ResourceManager.Peering.ConnectionMonitorTestData ConnectionMonitorTestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string sourceAgent = null, string destination = null, int? destinationPort = default(int?), int? testFrequencyInSec = default(int?), bool? isTestSuccessful = default(bool?), System.Collections.Generic.IEnumerable<string> path = null, Azure.ResourceManager.Peering.Models.PeeringProvisioningState? provisioningState = default(Azure.ResourceManager.Peering.Models.PeeringProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Peering.Models.DirectPeeringProperties DirectPeeringProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.Models.PeeringDirectConnection> connections = null, bool? useForPeeringService = default(bool?), Azure.Core.ResourceIdentifier peerAsnId = null, Azure.ResourceManager.Peering.Models.DirectPeeringType? directPeeringType = default(Azure.ResourceManager.Peering.Models.DirectPeeringType?)) { throw null; }
        public static Azure.ResourceManager.Peering.Models.LookingGlassOutput LookingGlassOutput(Azure.ResourceManager.Peering.Models.LookingGlassCommand? command = default(Azure.ResourceManager.Peering.Models.LookingGlassCommand?), string output = null) { throw null; }
        public static Azure.ResourceManager.Peering.PeerAsnData PeerAsnData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? peerAsn = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.Models.PeerAsnContactDetail> peerContactDetail = null, string peerName = null, Azure.ResourceManager.Peering.Models.PeerAsnValidationState? validationState = default(Azure.ResourceManager.Peering.Models.PeerAsnValidationState?), string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringBgpSession PeeringBgpSession(string sessionPrefixV4 = null, string sessionPrefixV6 = null, System.Net.IPAddress microsoftSessionIPv4Address = null, System.Net.IPAddress microsoftSessionIPv6Address = null, System.Net.IPAddress peerSessionIPv4Address = null, System.Net.IPAddress peerSessionIPv6Address = null, Azure.ResourceManager.Peering.Models.PeeringSessionStateV4? sessionStateV4 = default(Azure.ResourceManager.Peering.Models.PeeringSessionStateV4?), Azure.ResourceManager.Peering.Models.PeeringSessionStateV6? sessionStateV6 = default(Azure.ResourceManager.Peering.Models.PeeringSessionStateV6?), int? maxPrefixesAdvertisedV4 = default(int?), int? maxPrefixesAdvertisedV6 = default(int?), string md5AuthenticationKey = null) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringData PeeringData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Peering.Models.PeeringSku sku = null, Azure.ResourceManager.Peering.Models.PeeringKind kind = default(Azure.ResourceManager.Peering.Models.PeeringKind), Azure.ResourceManager.Peering.Models.DirectPeeringProperties direct = null, Azure.ResourceManager.Peering.Models.ExchangePeeringProperties exchange = null, string peeringLocation = null, Azure.ResourceManager.Peering.Models.PeeringProvisioningState? provisioningState = default(Azure.ResourceManager.Peering.Models.PeeringProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringDirectConnection PeeringDirectConnection(int? bandwidthInMbps = default(int?), int? provisionedBandwidthInMbps = default(int?), Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider? sessionAddressProvider = default(Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider?), bool? useForPeeringService = default(bool?), string microsoftTrackingId = null, int? peeringDBFacilityId = default(int?), Azure.ResourceManager.Peering.Models.PeeringConnectionState? connectionState = default(Azure.ResourceManager.Peering.Models.PeeringConnectionState?), Azure.ResourceManager.Peering.Models.PeeringBgpSession bgpSession = null, string connectionIdentifier = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringExchangeConnection PeeringExchangeConnection(int? peeringDBFacilityId = default(int?), Azure.ResourceManager.Peering.Models.PeeringConnectionState? connectionState = default(Azure.ResourceManager.Peering.Models.PeeringConnectionState?), Azure.ResourceManager.Peering.Models.PeeringBgpSession bgpSession = null, System.Guid? connectionIdentifier = default(System.Guid?), string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringLocation PeeringLocation(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Peering.Models.PeeringKind? kind = default(Azure.ResourceManager.Peering.Models.PeeringKind?), Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties direct = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.Models.ExchangePeeringFacility> exchangePeeringFacilities = null, string peeringLocationValue = null, string country = null, Azure.Core.AzureLocation? azureRegion = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties PeeringLogAnalyticsWorkspaceProperties(string workspaceId = null, string key = null, System.Collections.Generic.IEnumerable<string> connectedAgents = null) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringReceivedRoute PeeringReceivedRoute(string prefix = null, string nextHop = null, string asPath = null, string originAsValidationState = null, string rpkiValidationState = null, string trustAnchor = null, string receivedTimestamp = null) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringRegisteredAsnData PeeringRegisteredAsnData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? asn = default(int?), string peeringServicePrefixKey = null, Azure.ResourceManager.Peering.Models.PeeringProvisioningState? provisioningState = default(Azure.ResourceManager.Peering.Models.PeeringProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringRegisteredPrefixData PeeringRegisteredPrefixData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string prefix = null, Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState? prefixValidationState = default(Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState?), string peeringServicePrefixKey = null, string errorMessage = null, Azure.ResourceManager.Peering.Models.PeeringProvisioningState? provisioningState = default(Azure.ResourceManager.Peering.Models.PeeringProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringServiceCountry PeeringServiceCountry(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringServiceData PeeringServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string skuName = null, string peeringServiceLocation = null, string peeringServiceProvider = null, Azure.ResourceManager.Peering.Models.PeeringProvisioningState? provisioningState = default(Azure.ResourceManager.Peering.Models.PeeringProvisioningState?), string providerPrimaryPeeringLocation = null, string providerBackupPeeringLocation = null, Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties logAnalyticsWorkspaceProperties = null) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringServiceLocation PeeringServiceLocation(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string country = null, string state = null, Azure.Core.AzureLocation? azureRegion = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Peering.PeeringServicePrefixData PeeringServicePrefixData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string prefix = null, Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState? prefixValidationState = default(Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState?), Azure.ResourceManager.Peering.Models.PeeringLearnedType? learnedType = default(Azure.ResourceManager.Peering.Models.PeeringLearnedType?), string errorMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent> events = null, string peeringServicePrefixKey = null, Azure.ResourceManager.Peering.Models.PeeringProvisioningState? provisioningState = default(Azure.ResourceManager.Peering.Models.PeeringProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent PeeringServicePrefixEvent(System.DateTimeOffset? eventTimestamp = default(System.DateTimeOffset?), string eventType = null, string eventSummary = null, string eventLevel = null, string eventDescription = null) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringServiceProvider PeeringServiceProvider(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string serviceProviderName = null, System.Collections.Generic.IEnumerable<string> peeringLocations = null) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringSku PeeringSku(string name = null, Azure.ResourceManager.Peering.Models.PeeringTier? tier = default(Azure.ResourceManager.Peering.Models.PeeringTier?), Azure.ResourceManager.Peering.Models.PeeringFamily? family = default(Azure.ResourceManager.Peering.Models.PeeringFamily?), Azure.ResourceManager.Peering.Models.PeeringSize? size = default(Azure.ResourceManager.Peering.Models.PeeringSize?)) { throw null; }
        public static Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix RoutingPreferenceUnbilledPrefix(string prefix = null, Azure.Core.AzureLocation? azureRegion = default(Azure.Core.AzureLocation?), int? peerAsn = default(int?)) { throw null; }
    }
    public partial class CdnPeeringPrefix : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix>
    {
        public CdnPeeringPrefix() { }
        public Azure.Core.AzureLocation? AzureRegion { get { throw null; } }
        public string AzureService { get { throw null; } }
        public string BgpCommunity { get { throw null; } }
        public bool? IsPrimaryRegion { get { throw null; } }
        public string Prefix { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.CdnPeeringPrefix System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.CdnPeeringPrefix System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.CdnPeeringPrefix>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckPeeringServiceProviderAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent>
    {
        public CheckPeeringServiceProviderAvailabilityContent() { }
        public string PeeringServiceLocation { get { throw null; } set { } }
        public string PeeringServiceProvider { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.CheckPeeringServiceProviderAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DirectPeeringFacility : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.DirectPeeringFacility>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringFacility>
    {
        public DirectPeeringFacility() { }
        public string Address { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.DirectPeeringType? DirectPeeringType { get { throw null; } set { } }
        public int? PeeringDBFacilityId { get { throw null; } set { } }
        public string PeeringDBFacilityLink { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.DirectPeeringFacility System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.DirectPeeringFacility>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.DirectPeeringFacility>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.DirectPeeringFacility System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringFacility>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringFacility>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringFacility>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DirectPeeringLocationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties>
    {
        public DirectPeeringLocationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer> BandwidthOffers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.DirectPeeringFacility> PeeringFacilities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DirectPeeringProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.DirectPeeringProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringProperties>
    {
        public DirectPeeringProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.PeeringDirectConnection> Connections { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.DirectPeeringType? DirectPeeringType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PeerAsnId { get { throw null; } set { } }
        public bool? UseForPeeringService { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.DirectPeeringProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.DirectPeeringProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.DirectPeeringProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.DirectPeeringProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.DirectPeeringProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ExchangePeeringFacility : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.ExchangePeeringFacility>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.ExchangePeeringFacility>
    {
        public ExchangePeeringFacility() { }
        public int? BandwidthInMbps { get { throw null; } set { } }
        public string ExchangeName { get { throw null; } set { } }
        public string FacilityIPv4Prefix { get { throw null; } set { } }
        public string FacilityIPv6Prefix { get { throw null; } set { } }
        public System.Net.IPAddress MicrosoftIPv4Address { get { throw null; } set { } }
        public System.Net.IPAddress MicrosoftIPv6Address { get { throw null; } set { } }
        public int? PeeringDBFacilityId { get { throw null; } set { } }
        public string PeeringDBFacilityLink { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.ExchangePeeringFacility System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.ExchangePeeringFacility>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.ExchangePeeringFacility>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.ExchangePeeringFacility System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.ExchangePeeringFacility>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.ExchangePeeringFacility>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.ExchangePeeringFacility>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExchangePeeringProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.ExchangePeeringProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.ExchangePeeringProperties>
    {
        public ExchangePeeringProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.PeeringExchangeConnection> Connections { get { throw null; } }
        public Azure.Core.ResourceIdentifier PeerAsnId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.ExchangePeeringProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.ExchangePeeringProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.ExchangePeeringProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.ExchangePeeringProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.ExchangePeeringProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.ExchangePeeringProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.ExchangePeeringProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LookingGlassOutput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.LookingGlassOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.LookingGlassOutput>
    {
        internal LookingGlassOutput() { }
        public Azure.ResourceManager.Peering.Models.LookingGlassCommand? Command { get { throw null; } }
        public string Output { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.LookingGlassOutput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.LookingGlassOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.LookingGlassOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.LookingGlassOutput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.LookingGlassOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.LookingGlassOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.LookingGlassOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PeerAsnContactDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeerAsnContactDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeerAsnContactDetail>
    {
        public PeerAsnContactDetail() { }
        public string Email { get { throw null; } set { } }
        public string Phone { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringRole? Role { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeerAsnContactDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeerAsnContactDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeerAsnContactDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeerAsnContactDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeerAsnContactDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeerAsnContactDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeerAsnContactDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeerAsnValidationState : System.IEquatable<Azure.ResourceManager.Peering.Models.PeerAsnValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeerAsnValidationState(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeerAsnValidationState Approved { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeerAsnValidationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeerAsnValidationState None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeerAsnValidationState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeerAsnValidationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeerAsnValidationState left, Azure.ResourceManager.Peering.Models.PeerAsnValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeerAsnValidationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeerAsnValidationState left, Azure.ResourceManager.Peering.Models.PeerAsnValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PeeringBandwidthOffer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer>
    {
        public PeeringBandwidthOffer() { }
        public string OfferName { get { throw null; } set { } }
        public int? ValueInMbps { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringBandwidthOffer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringBgpSession : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringBgpSession>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringBgpSession>
    {
        public PeeringBgpSession() { }
        public int? MaxPrefixesAdvertisedV4 { get { throw null; } set { } }
        public int? MaxPrefixesAdvertisedV6 { get { throw null; } set { } }
        public string Md5AuthenticationKey { get { throw null; } set { } }
        public System.Net.IPAddress MicrosoftSessionIPv4Address { get { throw null; } set { } }
        public System.Net.IPAddress MicrosoftSessionIPv6Address { get { throw null; } set { } }
        public System.Net.IPAddress PeerSessionIPv4Address { get { throw null; } set { } }
        public System.Net.IPAddress PeerSessionIPv6Address { get { throw null; } set { } }
        public string SessionPrefixV4 { get { throw null; } set { } }
        public string SessionPrefixV6 { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringSessionStateV4? SessionStateV4 { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringSessionStateV6? SessionStateV6 { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringBgpSession System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringBgpSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringBgpSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringBgpSession System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringBgpSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringBgpSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringBgpSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringConnectionState : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringConnectionState Active { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringConnectionState Approved { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringConnectionState None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringConnectionState PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringConnectionState ProvisioningCompleted { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringConnectionState ProvisioningFailed { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringConnectionState ProvisioningStarted { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringConnectionState TypeChangeInProgress { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringConnectionState TypeChangeRequested { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringConnectionState Validating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringConnectionState left, Azure.ResourceManager.Peering.Models.PeeringConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringConnectionState left, Azure.ResourceManager.Peering.Models.PeeringConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PeeringDirectConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringDirectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringDirectConnection>
    {
        public PeeringDirectConnection() { }
        public int? BandwidthInMbps { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringBgpSession BgpSession { get { throw null; } set { } }
        public string ConnectionIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringConnectionState? ConnectionState { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string MicrosoftTrackingId { get { throw null; } }
        public int? PeeringDBFacilityId { get { throw null; } set { } }
        public int? ProvisionedBandwidthInMbps { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider? SessionAddressProvider { get { throw null; } set { } }
        public bool? UseForPeeringService { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringDirectConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringDirectConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringDirectConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringDirectConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringDirectConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringDirectConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringDirectConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringExchangeConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringExchangeConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringExchangeConnection>
    {
        public PeeringExchangeConnection() { }
        public Azure.ResourceManager.Peering.Models.PeeringBgpSession BgpSession { get { throw null; } set { } }
        public System.Guid? ConnectionIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringConnectionState? ConnectionState { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int? PeeringDBFacilityId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringExchangeConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringExchangeConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringExchangeConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringExchangeConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringExchangeConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringExchangeConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringExchangeConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringFamily : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringFamily(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringFamily Direct { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringFamily Exchange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringFamily left, Azure.ResourceManager.Peering.Models.PeeringFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringFamily left, Azure.ResourceManager.Peering.Models.PeeringFamily right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringLearnedType : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringLearnedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringLearnedType(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringLearnedType None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringLearnedType ViaServiceProvider { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringLearnedType ViaSession { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringLearnedType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringLearnedType left, Azure.ResourceManager.Peering.Models.PeeringLearnedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringLearnedType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringLearnedType left, Azure.ResourceManager.Peering.Models.PeeringLearnedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PeeringLocation : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringLocation>
    {
        public PeeringLocation() { }
        public Azure.Core.AzureLocation? AzureRegion { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.DirectPeeringLocationProperties Direct { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Peering.Models.ExchangePeeringFacility> ExchangePeeringFacilities { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringKind? Kind { get { throw null; } set { } }
        public string PeeringLocationValue { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PeeringLogAnalyticsWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties>
    {
        public PeeringLogAnalyticsWorkspaceProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> ConnectedAgents { get { throw null; } }
        public string Key { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringLogAnalyticsWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringPatch : Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringPatch>
    {
        public PeeringPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringPrefixValidationState : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringPrefixValidationState(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState Invalid { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState Verified { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState left, Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState left, Azure.ResourceManager.Peering.Models.PeeringPrefixValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringProvisioningState : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringProvisioningState left, Azure.ResourceManager.Peering.Models.PeeringProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringProvisioningState left, Azure.ResourceManager.Peering.Models.PeeringProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PeeringReceivedRoute : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringReceivedRoute>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringReceivedRoute>
    {
        internal PeeringReceivedRoute() { }
        public string AsPath { get { throw null; } }
        public string NextHop { get { throw null; } }
        public string OriginAsValidationState { get { throw null; } }
        public string Prefix { get { throw null; } }
        public string ReceivedTimestamp { get { throw null; } }
        public string RpkiValidationState { get { throw null; } }
        public string TrustAnchor { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringReceivedRoute System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringReceivedRoute>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringReceivedRoute>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringReceivedRoute System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringReceivedRoute>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringReceivedRoute>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringReceivedRoute>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringResourceTagsPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch>
    {
        public PeeringResourceTagsPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringRole : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringRole(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringRole Escalation { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringRole Noc { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringRole Other { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringRole Policy { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringRole Service { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringRole Technical { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringRole left, Azure.ResourceManager.Peering.Models.PeeringRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringRole left, Azure.ResourceManager.Peering.Models.PeeringRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PeeringServiceCountry : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServiceCountry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceCountry>
    {
        public PeeringServiceCountry() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringServiceCountry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServiceCountry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServiceCountry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringServiceCountry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceCountry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceCountry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceCountry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringServiceLocation : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServiceLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceLocation>
    {
        public PeeringServiceLocation() { }
        public Azure.Core.AzureLocation? AzureRegion { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringServiceLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServiceLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServiceLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringServiceLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringServicePatch : Azure.ResourceManager.Peering.Models.PeeringResourceTagsPatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServicePatch>
    {
        public PeeringServicePatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringServicePrefixEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent>
    {
        internal PeeringServicePrefixEvent() { }
        public string EventDescription { get { throw null; } }
        public string EventLevel { get { throw null; } }
        public string EventSummary { get { throw null; } }
        public System.DateTimeOffset? EventTimestamp { get { throw null; } }
        public string EventType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServicePrefixEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeeringServiceProvider : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServiceProvider>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceProvider>
    {
        public PeeringServiceProvider() { }
        public System.Collections.Generic.IList<string> PeeringLocations { get { throw null; } }
        public string ServiceProviderName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringServiceProvider System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServiceProvider>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringServiceProvider>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringServiceProvider System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceProvider>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceProvider>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringServiceProvider>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringServiceProviderAvailability : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringServiceProviderAvailability(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability Available { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability left, Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability left, Azure.ResourceManager.Peering.Models.PeeringServiceProviderAvailability right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringSessionAddressProvider : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringSessionAddressProvider(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider Microsoft { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider Peer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider left, Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider left, Azure.ResourceManager.Peering.Models.PeeringSessionAddressProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringSessionStateV4 : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringSessionStateV4>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringSessionStateV4(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 Active { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 Connect { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 Established { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 Idle { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 OpenConfirm { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 OpenReceived { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 OpenSent { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 PendingAdd { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 PendingRemove { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 PendingUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 left, Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 left, Azure.ResourceManager.Peering.Models.PeeringSessionStateV4 right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringSessionStateV6 : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringSessionStateV6>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringSessionStateV6(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 Active { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 Connect { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 Established { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 Idle { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 None { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 OpenConfirm { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 OpenReceived { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 OpenSent { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 PendingAdd { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 PendingRemove { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 PendingUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 left, Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 left, Azure.ResourceManager.Peering.Models.PeeringSessionStateV6 right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringSize : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringSize(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringSize Free { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSize Metered { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringSize Unlimited { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringSize left, Azure.ResourceManager.Peering.Models.PeeringSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringSize left, Azure.ResourceManager.Peering.Models.PeeringSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PeeringSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringSku>
    {
        public PeeringSku() { }
        public Azure.ResourceManager.Peering.Models.PeeringFamily? Family { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Peering.Models.PeeringSize? Size { get { throw null; } }
        public Azure.ResourceManager.Peering.Models.PeeringTier? Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.PeeringSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.PeeringSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.PeeringSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringTier : System.IEquatable<Azure.ResourceManager.Peering.Models.PeeringTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringTier(string value) { throw null; }
        public static Azure.ResourceManager.Peering.Models.PeeringTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Peering.Models.PeeringTier Premium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Peering.Models.PeeringTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Peering.Models.PeeringTier left, Azure.ResourceManager.Peering.Models.PeeringTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Peering.Models.PeeringTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Peering.Models.PeeringTier left, Azure.ResourceManager.Peering.Models.PeeringTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutingPreferenceUnbilledPrefix : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix>
    {
        internal RoutingPreferenceUnbilledPrefix() { }
        public Azure.Core.AzureLocation? AzureRegion { get { throw null; } }
        public int? PeerAsn { get { throw null; } }
        public string Prefix { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Peering.Models.RoutingPreferenceUnbilledPrefix>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
