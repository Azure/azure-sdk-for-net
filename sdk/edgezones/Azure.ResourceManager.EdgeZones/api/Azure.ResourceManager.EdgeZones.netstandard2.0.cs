namespace Azure.ResourceManager.EdgeZones
{
    public partial class AzureExtendedZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>, System.Collections.IEnumerable
    {
        protected AzureExtendedZoneCollection() { }
        public virtual Azure.Response<bool> Exists(string azureExtendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureExtendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> Get(string azureExtendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>> GetAsync(string azureExtendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> GetIfExists(string azureExtendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>> GetIfExistsAsync(string azureExtendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureExtendedZoneData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeZones.AzureExtendedZoneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeZones.AzureExtendedZoneData>
    {
        internal AzureExtendedZoneData() { }
        public string DisplayName { get { throw null; } }
        public string Geography { get { throw null; } }
        public string GeographyGroup { get { throw null; } }
        public string HomeLocation { get { throw null; } }
        public string Latitude { get { throw null; } }
        public string Longitude { get { throw null; } }
        public Azure.ResourceManager.EdgeZones.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RegionalDisplayName { get { throw null; } }
        public string RegionCategory { get { throw null; } }
        public string RegionType { get { throw null; } }
        public Azure.ResourceManager.EdgeZones.Models.RegistrationState? RegistrationState { get { throw null; } }
        Azure.ResourceManager.EdgeZones.AzureExtendedZoneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeZones.AzureExtendedZoneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeZones.AzureExtendedZoneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeZones.AzureExtendedZoneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeZones.AzureExtendedZoneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeZones.AzureExtendedZoneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeZones.AzureExtendedZoneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureExtendedZoneResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureExtendedZoneResource() { }
        public virtual Azure.ResourceManager.EdgeZones.AzureExtendedZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string azureExtendedZoneName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> Register(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>> RegisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> Unregister(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>> UnregisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class EdgeZonesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> GetAzureExtendedZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string azureExtendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>> GetAzureExtendedZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string azureExtendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource GetAzureExtendedZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeZones.AzureExtendedZoneCollection GetAzureExtendedZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeZones.Mocking
{
    public partial class MockableEdgeZonesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeZonesArmClient() { }
        public virtual Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource GetAzureExtendedZoneResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEdgeZonesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeZonesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource> GetAzureExtendedZone(string azureExtendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.AzureExtendedZoneResource>> GetAzureExtendedZoneAsync(string azureExtendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeZones.AzureExtendedZoneCollection GetAzureExtendedZones() { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeZones.Models
{
    public static partial class ArmEdgeZonesModelFactory
    {
        public static Azure.ResourceManager.EdgeZones.AzureExtendedZoneData AzureExtendedZoneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EdgeZones.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeZones.Models.ProvisioningState?), Azure.ResourceManager.EdgeZones.Models.RegistrationState? registrationState = default(Azure.ResourceManager.EdgeZones.Models.RegistrationState?), string displayName = null, string regionalDisplayName = null, string regionType = null, string regionCategory = null, string geography = null, string geographyGroup = null, string longitude = null, string latitude = null, string homeLocation = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeZones.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeZones.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeZones.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeZones.Models.ProvisioningState left, Azure.ResourceManager.EdgeZones.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeZones.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeZones.Models.ProvisioningState left, Azure.ResourceManager.EdgeZones.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegistrationState : System.IEquatable<Azure.ResourceManager.EdgeZones.Models.RegistrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegistrationState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeZones.Models.RegistrationState NotRegistered { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.RegistrationState PendingRegister { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.RegistrationState PendingUnregister { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.RegistrationState Registered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeZones.Models.RegistrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeZones.Models.RegistrationState left, Azure.ResourceManager.EdgeZones.Models.RegistrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeZones.Models.RegistrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeZones.Models.RegistrationState left, Azure.ResourceManager.EdgeZones.Models.RegistrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
