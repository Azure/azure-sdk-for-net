namespace Azure.ResourceManager.Orbital
{
    public partial class AvailableGroundStationCollection : Azure.ResourceManager.ArmCollection
    {
        protected AvailableGroundStationCollection() { }
        public virtual Azure.Response<bool> Exists(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource> Get(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Orbital.AvailableGroundStationResource> GetAll(Azure.ResourceManager.Orbital.Models.CapabilityParameter capability, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Orbital.AvailableGroundStationResource> GetAllAsync(Azure.ResourceManager.Orbital.Models.CapabilityParameter capability, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource>> GetAsync(string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvailableGroundStationData : Azure.ResourceManager.Models.ResourceData
    {
        internal AvailableGroundStationData() { }
        public float? AltitudeMeters { get { throw null; } }
        public string City { get { throw null; } }
        public float? LatitudeDegrees { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public float? LongitudeDegrees { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public Azure.ResourceManager.Orbital.Models.ReleaseMode? ReleaseMode { get { throw null; } }
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
    public partial class ContactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.ContactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.ContactResource>, System.Collections.IEnumerable
    {
        protected ContactCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.ContactResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string contactName, Azure.ResourceManager.Orbital.ContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.ContactResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string contactName, Azure.ResourceManager.Orbital.ContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.ContactResource> Get(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Orbital.ContactResource> GetAll(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Orbital.ContactResource> GetAllAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.ContactResource>> GetAsync(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Orbital.ContactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.ContactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Orbital.ContactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.ContactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContactData : Azure.ResourceManager.Models.ResourceData
    {
        public ContactData() { }
        public Azure.ResourceManager.Orbital.Models.ContactsPropertiesAntennaConfiguration AntennaConfiguration { get { throw null; } }
        public Azure.Core.ResourceIdentifier ContactProfileId { get { throw null; } set { } }
        public float? EndAzimuthDegrees { get { throw null; } }
        public float? EndElevationDegrees { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string GroundStationName { get { throw null; } set { } }
        public float? MaximumElevationDegrees { get { throw null; } }
        public Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.DateTimeOffset? ReservationEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? ReservationStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? RxEndOn { get { throw null; } }
        public System.DateTimeOffset? RxStartOn { get { throw null; } }
        public float? StartAzimuthDegrees { get { throw null; } }
        public float? StartElevationDegrees { get { throw null; } }
        public Azure.ResourceManager.Orbital.Models.ContactsStatus? Status { get { throw null; } }
        public System.DateTimeOffset? TxEndOn { get { throw null; } }
        public System.DateTimeOffset? TxStartOn { get { throw null; } }
    }
    public partial class ContactProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.ContactProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.ContactProfileResource>, System.Collections.IEnumerable
    {
        protected ContactProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.ContactProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string contactProfileName, Azure.ResourceManager.Orbital.ContactProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.ContactProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string contactProfileName, Azure.ResourceManager.Orbital.ContactProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource> Get(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Orbital.ContactProfileResource> GetAll(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Orbital.ContactProfileResource> GetAllAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource>> GetAsync(string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Orbital.ContactProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.ContactProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Orbital.ContactProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.ContactProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContactProfileData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ContactProfileData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Orbital.Models.AutoTrackingConfiguration? AutoTrackingConfiguration { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Uri EventHubUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Orbital.Models.ContactProfileLink> Links { get { throw null; } }
        public float? MinimumElevationDegrees { get { throw null; } set { } }
        public System.TimeSpan? MinimumViableContactDuration { get { throw null; } set { } }
        public string NetworkSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class ContactProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContactProfileResource() { }
        public virtual Azure.ResourceManager.Orbital.ContactProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contactProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.ContactProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.ContactProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContactResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContactResource() { }
        public virtual Azure.ResourceManager.Orbital.ContactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string spacecraftName, string contactName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.ContactResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.ContactResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.ContactResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.ContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.ContactResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.ContactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class OrbitalExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource> GetAvailableGroundStation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.AvailableGroundStationResource>> GetAvailableGroundStationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string groundStationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Orbital.AvailableGroundStationResource GetAvailableGroundStationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Orbital.AvailableGroundStationCollection GetAvailableGroundStations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource> GetContactProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.ContactProfileResource>> GetContactProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string contactProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Orbital.ContactProfileResource GetContactProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Orbital.ContactProfileCollection GetContactProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Orbital.ContactProfileResource> GetContactProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Orbital.ContactProfileResource> GetContactProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Orbital.ContactResource GetContactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.Models.OperationResult> GetOperationsResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.Models.OperationResult>> GetOperationsResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource> GetSpacecraft(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource>> GetSpacecraftAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Orbital.SpacecraftResource GetSpacecraftResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Orbital.SpacecraftCollection GetSpacecrafts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Orbital.SpacecraftResource> GetSpacecrafts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Orbital.SpacecraftResource> GetSpacecraftsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SpacecraftCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.SpacecraftResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.SpacecraftResource>, System.Collections.IEnumerable
    {
        protected SpacecraftCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.SpacecraftResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string spacecraftName, Azure.ResourceManager.Orbital.SpacecraftData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.SpacecraftResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string spacecraftName, Azure.ResourceManager.Orbital.SpacecraftData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource> Get(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Orbital.SpacecraftResource> GetAll(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Orbital.SpacecraftResource> GetAllAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource>> GetAsync(string spacecraftName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Orbital.SpacecraftResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Orbital.SpacecraftResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Orbital.SpacecraftResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.SpacecraftResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SpacecraftData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SpacecraftData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Orbital.Models.SpacecraftLink> Links { get { throw null; } }
        public string NoradId { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string TitleLine { get { throw null; } set { } }
        public string TleLine1 { get { throw null; } set { } }
        public string TleLine2 { get { throw null; } set { } }
    }
    public partial class SpacecraftResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SpacecraftResource() { }
        public virtual Azure.ResourceManager.Orbital.SpacecraftData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string spacecraftName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.ContactResource> GetContact(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.ContactResource>> GetContactAsync(string contactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Orbital.ContactCollection GetContacts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Orbital.SpacecraftResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.SpacecraftResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Orbital.SpacecraftResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Orbital.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Orbital.Models
{
    public partial class AuthorizedGroundstation
    {
        internal AuthorizedGroundstation() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string GroundStation { get { throw null; } }
    }
    public enum AutoTrackingConfiguration
    {
        Disabled = 0,
        XBand = 1,
        SBand = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapabilityParameter : System.IEquatable<Azure.ResourceManager.Orbital.Models.CapabilityParameter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapabilityParameter(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.CapabilityParameter Communication { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.CapabilityParameter EarthObservation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.CapabilityParameter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.CapabilityParameter left, Azure.ResourceManager.Orbital.Models.CapabilityParameter right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.CapabilityParameter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.CapabilityParameter left, Azure.ResourceManager.Orbital.Models.CapabilityParameter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContactProfileLink
    {
        public ContactProfileLink(string name, Azure.ResourceManager.Orbital.Models.Polarization polarization, Azure.ResourceManager.Orbital.Models.Direction direction, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Orbital.Models.ContactProfileLinkChannel> channels) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Orbital.Models.ContactProfileLinkChannel> Channels { get { throw null; } }
        public Azure.ResourceManager.Orbital.Models.Direction Direction { get { throw null; } set { } }
        public float? EirpdBW { get { throw null; } set { } }
        public float? GainOverTemperature { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.Polarization Polarization { get { throw null; } set { } }
    }
    public partial class ContactProfileLinkChannel
    {
        public ContactProfileLinkChannel(string name, float centerFrequencyMHz, float bandwidthMHz, Azure.ResourceManager.Orbital.Models.EndPoint endPoint) { }
        public float BandwidthMHz { get { throw null; } set { } }
        public float CenterFrequencyMHz { get { throw null; } set { } }
        public string DecodingConfiguration { get { throw null; } set { } }
        public string DemodulationConfiguration { get { throw null; } set { } }
        public string EncodingConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.EndPoint EndPoint { get { throw null; } set { } }
        public string ModulationConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContactProfilesPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContactProfilesPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState left, Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState left, Azure.ResourceManager.Orbital.Models.ContactProfilesPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContactsPropertiesAntennaConfiguration
    {
        internal ContactsPropertiesAntennaConfiguration() { }
        public string DestinationIP { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SourceIPs { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContactsPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContactsPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState left, Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState left, Azure.ResourceManager.Orbital.Models.ContactsPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContactsStatus : System.IEquatable<Azure.ResourceManager.Orbital.Models.ContactsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContactsStatus(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.ContactsStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactsStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactsStatus ProviderCancelled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactsStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ContactsStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.ContactsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.ContactsStatus left, Azure.ResourceManager.Orbital.Models.ContactsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.ContactsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.ContactsStatus left, Azure.ResourceManager.Orbital.Models.ContactsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Direction : System.IEquatable<Azure.ResourceManager.Orbital.Models.Direction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Direction(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.Direction Downlink { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.Direction Uplink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.Direction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.Direction left, Azure.ResourceManager.Orbital.Models.Direction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.Direction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.Direction left, Azure.ResourceManager.Orbital.Models.Direction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndPoint
    {
        public EndPoint(string ipAddress, string endPointName, string port, Azure.ResourceManager.Orbital.Models.Protocol protocol) { }
        public string EndPointName { get { throw null; } set { } }
        public string IPAddress { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.Protocol Protocol { get { throw null; } set { } }
    }
    public partial class OperationResult
    {
        internal OperationResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Orbital.Models.OperationResultErrorProperties Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Orbital.Models.Status? Status { get { throw null; } }
    }
    public partial class OperationResultErrorProperties
    {
        internal OperationResultErrorProperties() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Polarization : System.IEquatable<Azure.ResourceManager.Orbital.Models.Polarization>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Polarization(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.Polarization Lhcp { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.Polarization LinearHorizontal { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.Polarization LinearVertical { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.Polarization Rhcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.Polarization other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.Polarization left, Azure.ResourceManager.Orbital.Models.Polarization right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.Polarization (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.Polarization left, Azure.ResourceManager.Orbital.Models.Polarization right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Protocol : System.IEquatable<Azure.ResourceManager.Orbital.Models.Protocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Protocol(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.Protocol TCP { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.Protocol UDP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.Protocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.Protocol left, Azure.ResourceManager.Orbital.Models.Protocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.Protocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.Protocol left, Azure.ResourceManager.Orbital.Models.Protocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReleaseMode : System.IEquatable<Azure.ResourceManager.Orbital.Models.ReleaseMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReleaseMode(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.ReleaseMode GA { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.ReleaseMode Preview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.ReleaseMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.ReleaseMode left, Azure.ResourceManager.Orbital.Models.ReleaseMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.ReleaseMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.ReleaseMode left, Azure.ResourceManager.Orbital.Models.ReleaseMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpacecraftLink
    {
        public SpacecraftLink(string name, float centerFrequencyMHz, float bandwidthMHz, Azure.ResourceManager.Orbital.Models.Direction direction, Azure.ResourceManager.Orbital.Models.Polarization polarization) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Orbital.Models.AuthorizedGroundstation> Authorizations { get { throw null; } }
        public float BandwidthMHz { get { throw null; } set { } }
        public float CenterFrequencyMHz { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.Direction Direction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Orbital.Models.Polarization Polarization { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpacecraftsPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpacecraftsPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState left, Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState left, Azure.ResourceManager.Orbital.Models.SpacecraftsPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Orbital.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Orbital.Models.Status Canceled { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.Status Failed { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.Status Running { get { throw null; } }
        public static Azure.ResourceManager.Orbital.Models.Status Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Orbital.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Orbital.Models.Status left, Azure.ResourceManager.Orbital.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Orbital.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Orbital.Models.Status left, Azure.ResourceManager.Orbital.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TagsObject
    {
        public TagsObject() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
