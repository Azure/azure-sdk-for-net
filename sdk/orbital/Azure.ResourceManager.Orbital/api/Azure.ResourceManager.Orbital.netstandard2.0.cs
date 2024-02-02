namespace Azure.ResourceManager.Orbital
{
    public partial class AvailableGroundStationCollection : Azure.ResourceManager.ArmCollection
    {
        protected AvailableGroundStationCollection() { }
        public virtual Azure.Response<bool> Exists(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource> Get(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Orbital.AvailableGroundStationResource> GetAll(Azure.ResourceManager.Orbital.Models.GroundStationCapability capability, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Orbital.AvailableGroundStationResource> GetAllAsync(Azure.ResourceManager.Orbital.Models.GroundStationCapability capability, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource>> GetAsync(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Orbital.AvailableGroundStationResource> GetIfExists(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Orbital.AvailableGroundStationResource>> GetIfExistsAsync(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvailableGroundStationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.AvailableGroundStationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.AvailableGroundStationData>
    {
        internal AvailableGroundStationData() { }
        public float? AltitudeMeters { get { throw null; } }
        public string City { get { throw null; } }
        public float? LatitudeDegrees { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public float? LongitudeDegrees { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode? ReleaseMode { get { throw null; } }
        Azure.ResourceManager.Orbital.AvailableGroundStationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.AvailableGroundStationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.AvailableGroundStationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.AvailableGroundStationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.AvailableGroundStationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.AvailableGroundStationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.AvailableGroundStationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailableGroundStationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvailableGroundStationResource() { }
        public virtual Azure.ResourceManager.Orbital.AvailableGroundStationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string groundStationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrbitalContactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.OrbitalContactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.OrbitalContactResource>, System.Collections.IEnumerable
    {
        protected OrbitalContactCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalContactResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string contactName, Azure.ResourceManager.Orbital.OrbitalContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalContactResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string contactName, Azure.ResourceManager.Orbital.OrbitalContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactResource> Get(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Orbital.OrbitalContactResource> GetAll(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Orbital.OrbitalContactResource> GetAllAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactResource>> GetAsync(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Orbital.OrbitalContactResource> GetIfExists(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Orbital.OrbitalContactResource>> GetIfExistsAsync(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Orbital.OrbitalContactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.OrbitalContactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Orbital.OrbitalContactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.OrbitalContactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OrbitalContactData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.OrbitalContactData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalContactData>
    {
        public OrbitalContactData() { }
        public Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration AntennaConfiguration { get { throw null; } }
        public Azure.Core.ResourceIdentifier ContactProfileId { get { throw null; } set { } }
        public float? EndAzimuthDegrees { get { throw null; } }
        public float? EndElevationDegrees { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string GroundStationName { get { throw null; } set { } }
        public float? MaximumElevationDegrees { get { throw null; } }
        public Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? ReservationEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? ReservationStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? RxEndOn { get { throw null; } }
        public System.DateTimeOffset? RxStartOn { get { throw null; } }
        public float? StartAzimuthDegrees { get { throw null; } }
        public float? StartElevationDegrees { get { throw null; } }
        public Azure.ResourceManager.Orbital.Models.OrbitalContactStatus? Status { get { throw null; } }
        public System.DateTimeOffset? TxEndOn { get { throw null; } }
        public System.DateTimeOffset? TxStartOn { get { throw null; } }
        Azure.ResourceManager.Orbital.OrbitalContactData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.OrbitalContactData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.OrbitalContactData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.OrbitalContactData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalContactData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalContactData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalContactData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrbitalContactProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>, System.Collections.IEnumerable
    {
        protected OrbitalContactProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string contactProfileName, Azure.ResourceManager.Orbital.OrbitalContactProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string contactProfileName, Azure.ResourceManager.Orbital.OrbitalContactProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> Get(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> GetAll(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> GetAllAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>> GetAsync(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> GetIfExists(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>> GetIfExistsAsync(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OrbitalContactProfileData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.OrbitalContactProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalContactProfileData>
    {
        public OrbitalContactProfileData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Orbital.Models.AutoTrackingConfiguration? AutoTrackingConfiguration { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Uri EventHubUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink> Links { get { throw null; } }
        public float? MinimumElevationDegrees { get { throw null; } set { } }
        public System.TimeSpan? MinimumViableContactDuration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.Orbital.OrbitalContactProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.OrbitalContactProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.OrbitalContactProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.OrbitalContactProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalContactProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalContactProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalContactProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrbitalContactProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrbitalContactProfileResource() { }
        public virtual Azure.ResourceManager.Orbital.OrbitalContactProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contactProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags orbitalSpacecraftTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags orbitalSpacecraftTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrbitalContactResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrbitalContactResource() { }
        public virtual Azure.ResourceManager.Orbital.OrbitalContactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string spacecraftName, string contactName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalContactResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.OrbitalContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalContactResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.OrbitalContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class OrbitalExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource> GetAvailableGroundStation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource>> GetAvailableGroundStationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Orbital.AvailableGroundStationResource GetAvailableGroundStationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Orbital.AvailableGroundStationCollection GetAvailableGroundStations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> GetOrbitalContactProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>> GetOrbitalContactProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Orbital.OrbitalContactProfileResource GetOrbitalContactProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Orbital.OrbitalContactProfileCollection GetOrbitalContactProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> GetOrbitalContactProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> GetOrbitalContactProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Orbital.OrbitalContactResource GetOrbitalContactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> GetOrbitalSpacecraft(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>> GetOrbitalSpacecraftAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Orbital.OrbitalSpacecraftResource GetOrbitalSpacecraftResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Orbital.OrbitalSpacecraftCollection GetOrbitalSpacecrafts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> GetOrbitalSpacecrafts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> GetOrbitalSpacecraftsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrbitalSpacecraftCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>, System.Collections.IEnumerable
    {
        protected OrbitalSpacecraftCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string spacecraftName, Azure.ResourceManager.Orbital.OrbitalSpacecraftData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string spacecraftName, Azure.ResourceManager.Orbital.OrbitalSpacecraftData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> Get(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> GetAll(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> GetAllAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>> GetAsync(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> GetIfExists(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>> GetIfExistsAsync(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OrbitalSpacecraftData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.OrbitalSpacecraftData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalSpacecraftData>
    {
        public OrbitalSpacecraftData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink> Links { get { throw null; } }
        public string NoradId { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string TitleLine { get { throw null; } set { } }
        public string TleLine1 { get { throw null; } set { } }
        public string TleLine2 { get { throw null; } set { } }
        Azure.ResourceManager.Orbital.OrbitalSpacecraftData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.OrbitalSpacecraftData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.OrbitalSpacecraftData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.OrbitalSpacecraftData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalSpacecraftData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalSpacecraftData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.OrbitalSpacecraftData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrbitalSpacecraftResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrbitalSpacecraftResource() { }
        public virtual Azure.ResourceManager.Orbital.OrbitalSpacecraftData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string spacecraftName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult> GetAllAvailableContacts(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult>> GetAllAvailableContactsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactResource> GetOrbitalContact(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactResource>> GetOrbitalContactAsync(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Orbital.OrbitalContactCollection GetOrbitalContacts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags orbitalSpacecraftTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags orbitalSpacecraftTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Orbital.Mocking
{
    public partial class MockableOrbitalArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableOrbitalArmClient() { }
        public virtual Azure.ResourceManager.Orbital.AvailableGroundStationResource GetAvailableGroundStationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Orbital.OrbitalContactProfileResource GetOrbitalContactProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Orbital.OrbitalContactResource GetOrbitalContactResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Orbital.OrbitalSpacecraftResource GetOrbitalSpacecraftResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableOrbitalResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOrbitalResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> GetOrbitalContactProfile(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalContactProfileResource>> GetOrbitalContactProfileAsync(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Orbital.OrbitalContactProfileCollection GetOrbitalContactProfiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> GetOrbitalSpacecraft(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource>> GetOrbitalSpacecraftAsync(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Orbital.OrbitalSpacecraftCollection GetOrbitalSpacecrafts() { throw null; }
    }
    public partial class MockableOrbitalSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOrbitalSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource> GetAvailableGroundStation(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource>> GetAvailableGroundStationAsync(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Orbital.AvailableGroundStationCollection GetAvailableGroundStations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> GetOrbitalContactProfiles(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Orbital.OrbitalContactProfileResource> GetOrbitalContactProfilesAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> GetOrbitalSpacecrafts(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Orbital.OrbitalSpacecraftResource> GetOrbitalSpacecraftsAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Orbital.Models
{
    public static partial class ArmOrbitalModelFactory
    {
        public static Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation AuthorizedGroundStation(string groundStationName = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Orbital.AvailableGroundStationData AvailableGroundStationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string city = null, string providerName = null, float? longitudeDegrees = default(float?), float? latitudeDegrees = default(float?), float? altitudeMeters = default(float?), Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode? releaseMode = default(Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode?)) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact OrbitalAvailableContact(Azure.Core.ResourceIdentifier spacecraftId = null, string groundStationName = null, float? maximumElevationDegrees = default(float?), System.DateTimeOffset? txStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? txEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? rxStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? rxEndOn = default(System.DateTimeOffset?), float? startAzimuthDegrees = default(float?), float? endAzimuthDegrees = default(float?), float? startElevationDegrees = default(float?), float? endElevationDegrees = default(float?)) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult OrbitalAvailableContactsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact> values = null) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration OrbitalContactAntennaConfiguration(System.Net.IPAddress destinationIP = null, System.Collections.Generic.IEnumerable<System.Net.IPAddress> sourceIPs = null) { throw null; }
        public static Azure.ResourceManager.Orbital.OrbitalContactData OrbitalContactData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState? provisioningState = default(Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState?), Azure.ResourceManager.Orbital.Models.OrbitalContactStatus? status = default(Azure.ResourceManager.Orbital.Models.OrbitalContactStatus?), System.DateTimeOffset? reservationStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? reservationEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? rxStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? rxEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? txStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? txEndOn = default(System.DateTimeOffset?), string errorMessage = null, float? maximumElevationDegrees = default(float?), float? startAzimuthDegrees = default(float?), float? endAzimuthDegrees = default(float?), string groundStationName = null, float? startElevationDegrees = default(float?), float? endElevationDegrees = default(float?), Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration antennaConfiguration = null, Azure.Core.ResourceIdentifier contactProfileId = null) { throw null; }
        public static Azure.ResourceManager.Orbital.OrbitalContactProfileData OrbitalContactProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState? provisioningState = default(Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState?), System.TimeSpan? minimumViableContactDuration = default(System.TimeSpan?), float? minimumElevationDegrees = default(float?), Azure.ResourceManager.Orbital.Models.AutoTrackingConfiguration? autoTrackingConfiguration = default(Azure.ResourceManager.Orbital.Models.AutoTrackingConfiguration?), System.Uri eventHubUri = null, Azure.Core.ResourceIdentifier networkSubnetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink> links = null) { throw null; }
        public static Azure.ResourceManager.Orbital.OrbitalSpacecraftData OrbitalSpacecraftData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState? provisioningState = default(Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState?), string noradId = null, string titleLine = null, string tleLine1 = null, string tleLine2 = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink> links = null) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink OrbitalSpacecraftLink(string name = null, float centerFrequencyMHz = 0f, float bandwidthMHz = 0f, Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection direction = default(Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection), Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization polarization = default(Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation> authorizations = null) { throw null; }
    }
    public partial class AuthorizedGroundStation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation>
    {
        internal AuthorizedGroundStation() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string GroundStationName { get { throw null; } }
        Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AutoTrackingConfiguration
    {
        Disabled = 0,
        XBand = 1,
        SBand = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroundStationCapability : System.IEquatable<Azure.ResourceManager.Orbital.Models.GroundStationCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroundStationCapability(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.GroundStationCapability Communication { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.GroundStationCapability EarthObservation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.GroundStationCapability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.GroundStationCapability left, Azure.ResourceManager.Orbital.Models.GroundStationCapability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.GroundStationCapability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.GroundStationCapability left, Azure.ResourceManager.Orbital.Models.GroundStationCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroundStationReleaseMode : System.IEquatable<Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroundStationReleaseMode(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode GA { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode Preview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode left, Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode left, Azure.ResourceManager.Orbital.Models.GroundStationReleaseMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OrbitalAvailableContact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact>
    {
        internal OrbitalAvailableContact() { }
        public float? EndAzimuthDegrees { get { throw null; } }
        public float? EndElevationDegrees { get { throw null; } }
        public string GroundStationName { get { throw null; } }
        public float? MaximumElevationDegrees { get { throw null; } }
        public System.DateTimeOffset? RxEndOn { get { throw null; } }
        public System.DateTimeOffset? RxStartOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier SpacecraftId { get { throw null; } }
        public float? StartAzimuthDegrees { get { throw null; } }
        public float? StartElevationDegrees { get { throw null; } }
        public System.DateTimeOffset? TxEndOn { get { throw null; } }
        public System.DateTimeOffset? TxStartOn { get { throw null; } }
        Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrbitalAvailableContactsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent>
    {
        public OrbitalAvailableContactsContent(Azure.ResourceManager.Resources.Models.WritableSubResource contactProfile, string groundStationName, System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public Azure.Core.ResourceIdentifier ContactProfileId { get { throw null; } }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public string GroundStationName { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrbitalAvailableContactsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult>
    {
        internal OrbitalAvailableContactsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContact> Values { get { throw null; } }
        Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalAvailableContactsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrbitalContactAntennaConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration>
    {
        internal OrbitalContactAntennaConfiguration() { }
        public System.Net.IPAddress DestinationIP { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> SourceIPs { get { throw null; } }
        Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactAntennaConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrbitalContactEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint>
    {
        public OrbitalContactEndpoint(System.Net.IPAddress ipAddress, string endPointName, string port, Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol protocol) { }
        public string EndPointName { get { throw null; } set { } }
        public System.Net.IPAddress IPAddress { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol Protocol { get { throw null; } set { } }
        Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrbitalContactProfileLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink>
    {
        public OrbitalContactProfileLink(string name, Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization polarization, Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection direction, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel> channels) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel> Channels { get { throw null; } }
        public Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection Direction { get { throw null; } set { } }
        public float? EirpdBW { get { throw null; } set { } }
        public float? GainOverTemperature { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization Polarization { get { throw null; } set { } }
        Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrbitalContactProfileLinkChannel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel>
    {
        public OrbitalContactProfileLinkChannel(string name, float centerFrequencyMHz, float bandwidthMHz, Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint endPoint) { }
        public float BandwidthMHz { get { throw null; } set { } }
        public float CenterFrequencyMHz { get { throw null; } set { } }
        public string DecodingConfiguration { get { throw null; } set { } }
        public string DemodulationConfiguration { get { throw null; } set { } }
        public string EncodingConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.OrbitalContactEndpoint EndPoint { get { throw null; } set { } }
        public string ModulationConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalContactProfileLinkChannel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrbitalContactProtocol : System.IEquatable<Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrbitalContactProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol left, Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol left, Azure.ResourceManager.Orbital.Models.OrbitalContactProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrbitalContactStatus : System.IEquatable<Azure.ResourceManager.Orbital.Models.OrbitalContactStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrbitalContactStatus(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.OrbitalContactStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalContactStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalContactStatus ProviderCancelled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalContactStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalContactStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.OrbitalContactStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.OrbitalContactStatus left, Azure.ResourceManager.Orbital.Models.OrbitalContactStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.OrbitalContactStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.OrbitalContactStatus left, Azure.ResourceManager.Orbital.Models.OrbitalContactStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrbitalLinkDirection : System.IEquatable<Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrbitalLinkDirection(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection Downlink { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection Uplink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection left, Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection left, Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrbitalLinkPolarization : System.IEquatable<Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrbitalLinkPolarization(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization Lhcp { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization LinearHorizontal { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization LinearVertical { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization Rhcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization left, Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization left, Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrbitalProvisioningState : System.IEquatable<Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrbitalProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState left, Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState left, Azure.ResourceManager.Orbital.Models.OrbitalProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OrbitalSpacecraftLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink>
    {
        public OrbitalSpacecraftLink(string name, float centerFrequencyMHz, float bandwidthMHz, Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection direction, Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization polarization) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Orbital.Models.AuthorizedGroundStation> Authorizations { get { throw null; } }
        public float BandwidthMHz { get { throw null; } set { } }
        public float CenterFrequencyMHz { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.OrbitalLinkDirection Direction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.OrbitalLinkPolarization Polarization { get { throw null; } set { } }
        Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrbitalSpacecraftTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags>
    {
        public OrbitalSpacecraftTags() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Orbital.Models.OrbitalSpacecraftTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
