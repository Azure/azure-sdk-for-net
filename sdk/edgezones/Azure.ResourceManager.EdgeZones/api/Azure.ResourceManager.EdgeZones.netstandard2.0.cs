namespace Azure.ResourceManager.EdgeZones
{
    public static partial class EdgeZonesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> GetExtendedZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string extendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>> GetExtendedZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string extendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeZones.ExtendedZoneResource GetExtendedZoneResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeZones.ExtendedZoneCollection GetExtendedZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class ExtendedZoneCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>, System.Collections.IEnumerable
    {
        protected ExtendedZoneCollection() { }
        public virtual Azure.Response<bool> Exists(string extendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> Get(string extendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>> GetAsync(string extendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> GetIfExists(string extendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>> GetIfExistsAsync(string extendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExtendedZoneData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeZones.ExtendedZoneData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeZones.ExtendedZoneData>
    {
        internal ExtendedZoneData() { }
        public string DisplayName { get { throw null; } }
        public string Geography { get { throw null; } }
        public string GeographyGroup { get { throw null; } }
        public string HomeLocation { get { throw null; } }
        public string Latitude { get { throw null; } }
        public string Longitude { get { throw null; } }
        public Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState? ProvisioningState { get { throw null; } }
        public string RegionalDisplayName { get { throw null; } }
        public string RegionCategory { get { throw null; } }
        public string RegionType { get { throw null; } }
        public Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState? RegistrationState { get { throw null; } }
        Azure.ResourceManager.EdgeZones.ExtendedZoneData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeZones.ExtendedZoneData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeZones.ExtendedZoneData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeZones.ExtendedZoneData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeZones.ExtendedZoneData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeZones.ExtendedZoneData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeZones.ExtendedZoneData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtendedZoneResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtendedZoneResource() { }
        public virtual Azure.ResourceManager.EdgeZones.ExtendedZoneData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string extendedZoneName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> Register(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>> RegisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> Unregister(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>> UnregisterAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeZones.Mocking
{
    public partial class MockableEdgeZonesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeZonesArmClient() { }
        public virtual Azure.ResourceManager.EdgeZones.ExtendedZoneResource GetExtendedZoneResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEdgeZonesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeZonesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource> GetExtendedZone(string extendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeZones.ExtendedZoneResource>> GetExtendedZoneAsync(string extendedZoneName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeZones.ExtendedZoneCollection GetExtendedZones() { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeZones.Models
{
    public static partial class ArmEdgeZonesModelFactory
    {
        public static Azure.ResourceManager.EdgeZones.ExtendedZoneData ExtendedZoneData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState?), Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState? registrationState = default(Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState?), string displayName = null, string regionalDisplayName = null, string regionType = null, string regionCategory = null, string geography = null, string geographyGroup = null, string longitude = null, string latitude = null, string homeLocation = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeZonesProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeZonesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState left, Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState left, Azure.ResourceManager.EdgeZones.Models.EdgeZonesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeZonesRegistrationState : System.IEquatable<Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeZonesRegistrationState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState NotRegistered { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState PendingRegister { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState PendingUnregister { get { throw null; } }
        public static Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState Registered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState left, Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState left, Azure.ResourceManager.EdgeZones.Models.EdgeZonesRegistrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
