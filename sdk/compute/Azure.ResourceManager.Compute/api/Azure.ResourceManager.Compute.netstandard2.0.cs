namespace Azure.ResourceManager.Compute
{
    public partial class AvailabilitySetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.AvailabilitySetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.AvailabilitySetResource>, System.Collections.IEnumerable
    {
        protected AvailabilitySetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.AvailabilitySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string availabilitySetName, Azure.ResourceManager.Compute.AvailabilitySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.AvailabilitySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string availabilitySetName, Azure.ResourceManager.Compute.AvailabilitySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource> Get(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.AvailabilitySetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.AvailabilitySetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource>> GetAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.AvailabilitySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.AvailabilitySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.AvailabilitySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.AvailabilitySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvailabilitySetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AvailabilitySetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public int? PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualMachines { get { throw null; } }
    }
    public partial class AvailabilitySetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvailabilitySetResource() { }
        public virtual Azure.ResourceManager.Compute.AvailabilitySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string availabilitySetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetAvailableSizes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetAvailableSizesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource> Update(Azure.ResourceManager.Compute.Models.AvailabilitySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.AvailabilitySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservationResource>, System.Collections.IEnumerable
    {
        protected CapacityReservationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capacityReservationName, Azure.ResourceManager.Compute.CapacityReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capacityReservationName, Azure.ResourceManager.Compute.CapacityReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> Get(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CapacityReservationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CapacityReservationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> GetAsync(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CapacityReservationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CapacityReservationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapacityReservationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CapacityReservationData(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.ComputeSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView InstanceView { get { throw null; } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class CapacityReservationGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroupResource>, System.Collections.IEnumerable
    {
        protected CapacityReservationGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capacityReservationGroupName, Azure.ResourceManager.Compute.CapacityReservationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capacityReservationGroupName, Azure.ResourceManager.Compute.CapacityReservationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> Get(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetAll(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetAllAsync(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> GetAsync(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CapacityReservationGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CapacityReservationGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapacityReservationGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CapacityReservationGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> CapacityReservations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName> InstanceViewCapacityReservations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class CapacityReservationGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapacityReservationGroupResource() { }
        public virtual Azure.ResourceManager.Compute.CapacityReservationGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string capacityReservationGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> Get(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> GetAsync(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> GetCapacityReservation(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> GetCapacityReservationAsync(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.CapacityReservationCollection GetCapacityReservations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> Update(Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapacityReservationResource() { }
        public virtual Azure.ResourceManager.Compute.CapacityReservationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string capacityReservationGroupName, string capacityReservationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> Get(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> GetAsync(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.CapacityReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.CapacityReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceResource>, System.Collections.IEnumerable
    {
        protected CloudServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CloudServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudServiceName, Azure.ResourceManager.Compute.CloudServiceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CloudServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudServiceName, Azure.ResourceManager.Compute.CloudServiceData data = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource> Get(string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CloudServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CloudServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource>> GetAsync(string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CloudServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CloudServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CloudServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AllowModelOverride { get { throw null; } set { } }
        public string Configuration { get { throw null; } set { } }
        public System.Uri ConfigurationUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.CloudServiceExtension> Extensions { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CloudServiceNetworkProfile NetworkProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.CloudServiceVaultSecretGroup> OSSecrets { get { throw null; } }
        public System.Uri PackageUri { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.CloudServiceRoleProfileProperties> Roles { get { throw null; } }
        public bool? StartCloudService { get { throw null; } set { } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode? UpgradeMode { get { throw null; } set { } }
    }
    public partial class CloudServiceOSFamilyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource>, System.Collections.IEnumerable
    {
        protected CloudServiceOSFamilyCollection() { }
        public virtual Azure.Response<bool> Exists(string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource> Get(string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource>> GetAsync(string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudServiceOSFamilyData : Azure.ResourceManager.Models.ResourceData
    {
        internal CloudServiceOSFamilyData() { }
        public string Label { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.OSVersionPropertiesBase> Versions { get { throw null; } }
    }
    public partial class CloudServiceOSFamilyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudServiceOSFamilyResource() { }
        public virtual Azure.ResourceManager.Compute.CloudServiceOSFamilyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string osFamilyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceOSVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceOSVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceOSVersionResource>, System.Collections.IEnumerable
    {
        protected CloudServiceOSVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSVersionResource> Get(string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CloudServiceOSVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CloudServiceOSVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSVersionResource>> GetAsync(string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CloudServiceOSVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceOSVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CloudServiceOSVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceOSVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudServiceOSVersionData : Azure.ResourceManager.Models.ResourceData
    {
        internal CloudServiceOSVersionData() { }
        public string Family { get { throw null; } }
        public string FamilyLabel { get { throw null; } }
        public bool? IsActive { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        public string Label { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class CloudServiceOSVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudServiceOSVersionResource() { }
        public virtual Azure.ResourceManager.Compute.CloudServiceOSVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string osVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudServiceResource() { }
        public virtual Azure.ResourceManager.Compute.CloudServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteInstances(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RoleInstances roleInstances = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteInstancesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RoleInstances roleInstances = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleResource> GetCloudServiceRole(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleResource>> GetCloudServiceRoleAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource> GetCloudServiceRoleInstance(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource>> GetCloudServiceRoleInstanceAsync(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.CloudServiceRoleInstanceCollection GetCloudServiceRoleInstances() { throw null; }
        public virtual Azure.ResourceManager.Compute.CloudServiceRoleCollection GetCloudServiceRoles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.CloudServiceInstanceView> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.CloudServiceInstanceView>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.UpdateDomainIdentifier> GetUpdateDomain(int updateDomain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.UpdateDomainIdentifier>> GetUpdateDomainAsync(int updateDomain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.UpdateDomainIdentifier> GetUpdateDomains(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.UpdateDomainIdentifier> GetUpdateDomainsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOff(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOffAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOn(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOnAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Rebuild(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RoleInstances roleInstances = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RebuildAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RoleInstances roleInstances = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RoleInstances roleInstances = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RoleInstances roleInstances = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RoleInstances roleInstances = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RoleInstances roleInstances = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CloudServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.CloudServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CloudServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.CloudServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation WalkUpdateDomain(Azure.WaitUntil waitUntil, int updateDomain, Azure.ResourceManager.Compute.Models.UpdateDomainIdentifier updateDomainIdentifier = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> WalkUpdateDomainAsync(Azure.WaitUntil waitUntil, int updateDomain, Azure.ResourceManager.Compute.Models.UpdateDomainIdentifier updateDomainIdentifier = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceRoleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceRoleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceRoleResource>, System.Collections.IEnumerable
    {
        protected CloudServiceRoleCollection() { }
        public virtual Azure.Response<bool> Exists(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleResource> Get(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CloudServiceRoleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CloudServiceRoleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleResource>> GetAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CloudServiceRoleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceRoleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CloudServiceRoleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceRoleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudServiceRoleData : Azure.ResourceManager.Models.ResourceData
    {
        internal CloudServiceRoleData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CloudServiceRoleSku Sku { get { throw null; } }
        public string UniqueId { get { throw null; } }
    }
    public partial class CloudServiceRoleInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource>, System.Collections.IEnumerable
    {
        protected CloudServiceRoleInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource> Get(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource> GetAll(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource> GetAllAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource>> GetAsync(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudServiceRoleInstanceData : Azure.ResourceManager.Models.ResourceData
    {
        internal CloudServiceRoleInstanceData() { }
        public Azure.ResourceManager.Compute.Models.RoleInstanceView InstanceView { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceSku Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CloudServiceRoleInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudServiceRoleInstanceResource() { }
        public virtual Azure.ResourceManager.Compute.CloudServiceRoleInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServiceName, string roleInstanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource> Get(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RoleInstanceView> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RoleInstanceView>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetRemoteDesktopFile(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetRemoteDesktopFileAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Rebuild(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RebuildAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceRoleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudServiceRoleResource() { }
        public virtual Azure.ResourceManager.Compute.CloudServiceRoleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServiceName, string roleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRoleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ComputeExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.LogAnalytics> ExportLogAnalyticsRequestRateByInterval(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.LogAnalytics>> ExportLogAnalyticsRequestRateByIntervalAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.LogAnalytics> ExportLogAnalyticsThrottledRequests(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.ThrottledRequestsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.LogAnalytics>> ExportLogAnalyticsThrottledRequestsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.ThrottledRequestsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource> GetAvailabilitySet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource>> GetAvailabilitySetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.AvailabilitySetResource GetAvailabilitySetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.AvailabilitySetCollection GetAvailabilitySets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.AvailabilitySetResource> GetAvailabilitySets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.AvailabilitySetResource> GetAvailabilitySetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetCapacityReservationGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> GetCapacityReservationGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservationGroupResource GetCapacityReservationGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservationGroupCollection GetCapacityReservationGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetCapacityReservationGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetCapacityReservationGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservationResource GetCapacityReservationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource> GetCloudService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceResource>> GetCloudServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.CloudServiceOSFamilyCollection GetCloudServiceOSFamilies(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource> GetCloudServiceOSFamily(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSFamilyResource>> GetCloudServiceOSFamilyAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.CloudServiceOSFamilyResource GetCloudServiceOSFamilyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSVersionResource> GetCloudServiceOSVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceOSVersionResource>> GetCloudServiceOSVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.CloudServiceOSVersionResource GetCloudServiceOSVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.CloudServiceOSVersionCollection GetCloudServiceOSVersions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.Compute.CloudServiceResource GetCloudServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.CloudServiceRoleInstanceResource GetCloudServiceRoleInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.CloudServiceRoleResource GetCloudServiceRoleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.CloudServiceCollection GetCloudServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.CloudServiceResource> GetCloudServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.CloudServiceResource> GetCloudServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGallery> GetCommunityGallery(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGallery>> GetCommunityGalleryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGalleryImage> GetCommunityGalleryImage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publicGalleryName, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGalleryImage>> GetCommunityGalleryImageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publicGalleryName, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGalleryImageVersion> GetCommunityGalleryImageVersion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publicGalleryName, string galleryImageName, string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGalleryImageVersion>> GetCommunityGalleryImageVersionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publicGalleryName, string galleryImageName, string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource GetComputePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetDedicatedHostGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> GetDedicatedHostGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHostGroupResource GetDedicatedHostGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHostGroupCollection GetDedicatedHostGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetDedicatedHostGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetDedicatedHostGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHostResource GetDedicatedHostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource> GetDiskAccess(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource>> GetDiskAccessAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.DiskAccessCollection GetDiskAccesses(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.DiskAccessResource> GetDiskAccesses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskAccessResource> GetDiskAccessesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.DiskAccessResource GetDiskAccessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource> GetDiskEncryptionSet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource>> GetDiskEncryptionSetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.DiskEncryptionSetResource GetDiskEncryptionSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.DiskEncryptionSetCollection GetDiskEncryptionSets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.DiskEncryptionSetResource> GetDiskEncryptionSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskEncryptionSetResource> GetDiskEncryptionSetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.DiskRestorePointResource GetDiskRestorePointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryCollection GetGalleries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.GalleryResource> GetGalleries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.GalleryResource> GetGalleriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.GalleryResource> GetGallery(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryApplicationResource GetGalleryApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryApplicationVersionResource GetGalleryApplicationVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryResource>> GetGalleryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryImageResource GetGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryImageVersionResource GetGalleryImageVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryResource GetGalleryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.ImageResource> GetImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ImageResource>> GetImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.ImageResource GetImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.ImageCollection GetImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.ImageResource> GetImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.ImageResource> GetImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource> GetManagedDisk(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource>> GetManagedDiskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.ManagedDiskResource GetManagedDiskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.ManagedDiskCollection GetManagedDisks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.ManagedDiskResource> GetManagedDisks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.ManagedDiskResource> GetManagedDisksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetOffersVirtualMachineImagesEdgeZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetOffersVirtualMachineImagesEdgeZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> GetProximityPlacementGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> GetProximityPlacementGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.ProximityPlacementGroupResource GetProximityPlacementGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.ProximityPlacementGroupCollection GetProximityPlacementGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> GetProximityPlacementGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> GetProximityPlacementGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetPublishersVirtualMachineImagesEdgeZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetPublishersVirtualMachineImagesEdgeZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.ComputeResourceSku> GetResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ComputeResourceSku> GetResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> GetRestorePointGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> GetRestorePointGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePointGroupResource GetRestorePointGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePointGroupCollection GetRestorePointGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.RestorePointGroupResource> GetRestorePointGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.RestorePointGroupResource> GetRestorePointGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePointResource GetRestorePointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.SharedGalleryCollection GetSharedGalleries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.SharedGalleryResource> GetSharedGallery(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryResource>> GetSharedGalleryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.SharedGalleryImageResource GetSharedGalleryImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.SharedGalleryImageVersionResource GetSharedGalleryImageVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.SharedGalleryResource GetSharedGalleryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.SnapshotResource> GetSnapshot(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SnapshotResource>> GetSnapshotAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.SnapshotResource GetSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.SnapshotCollection GetSnapshots(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.SnapshotResource> GetSnapshots(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.SnapshotResource> GetSnapshotsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> GetSshPublicKey(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> GetSshPublicKeyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.SshPublicKeyResource GetSshPublicKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.SshPublicKeyCollection GetSshPublicKeys(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.SshPublicKeyResource> GetSshPublicKeys(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.SshPublicKeyResource> GetSshPublicKeysAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.ComputeUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ComputeUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> GetVirtualMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> GetVirtualMachineExtensionImage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>> GetVirtualMachineExtensionImageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource GetVirtualMachineExtensionImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineExtensionResource GetVirtualMachineExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage> GetVirtualMachineImage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage>> GetVirtualMachineImageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageEdgeZoneSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageEdgeZoneSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageOffers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageOffersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagePublishers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagePublishersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, string skus, string expand = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, string skus, string expand = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage> GetVirtualMachineImagesEdgeZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage>> GetVirtualMachineImagesEdgeZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesEdgeZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string expand = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesEdgeZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string expand = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineResource GetVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandDocument> GetVirtualMachineRunCommand(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandDocument>> GetVirtualMachineRunCommandAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineRunCommandResource GetVirtualMachineRunCommandResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> GetVirtualMachineRunCommands(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> GetVirtualMachineRunCommandsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineCollection GetVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string statusOnly = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string statusOnly = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachinesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachinesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> GetVirtualMachineScaleSetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource GetVirtualMachineScaleSetExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetResource GetVirtualMachineScaleSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource GetVirtualMachineScaleSetRollingUpgradeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetCollection GetVirtualMachineScaleSets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource GetVirtualMachineScaleSetVmExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource GetVirtualMachineScaleSetVmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource GetVirtualMachineScaleSetVmRunCommandResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetVirtualMachineSizes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetVirtualMachineSizesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ComputePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ComputePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComputePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public ComputePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Compute.Models.ComputePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ComputePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComputePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskAccessName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHostResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHostResource>, System.Collections.IEnumerable
    {
        protected DedicatedHostCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hostName, Azure.ResourceManager.Compute.DedicatedHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hostName, Azure.ResourceManager.Compute.DedicatedHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> Get(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DedicatedHostResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DedicatedHostResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> GetAsync(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DedicatedHostResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHostResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DedicatedHostResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHostResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHostData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DedicatedHostData(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.ComputeSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AutoReplaceOnFailure { get { throw null; } set { } }
        public string HostId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostLicenseTypes? LicenseType { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachines { get { throw null; } }
    }
    public partial class DedicatedHostGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroupResource>, System.Collections.IEnumerable
    {
        protected DedicatedHostGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hostGroupName, Azure.ResourceManager.Compute.DedicatedHostGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hostGroupName, Azure.ResourceManager.Compute.DedicatedHostGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> Get(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> GetAsync(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DedicatedHostGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DedicatedHostGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHostGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DedicatedHostGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Hosts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName> InstanceViewHosts { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public bool? SupportAutomaticPlacement { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class DedicatedHostGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedHostGroupResource() { }
        public virtual Azure.ResourceManager.Compute.DedicatedHostGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> Get(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> GetDedicatedHost(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> GetDedicatedHostAsync(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostCollection GetDedicatedHosts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> Update(Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedHostResource() { }
        public virtual Azure.ResourceManager.Compute.DedicatedHostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostGroupName, string hostName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> Get(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.DedicatedHostPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.DedicatedHostPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskAccessCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskAccessResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskAccessResource>, System.Collections.IEnumerable
    {
        protected DiskAccessCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskAccessResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diskAccessName, Azure.ResourceManager.Compute.DiskAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskAccessResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diskAccessName, Azure.ResourceManager.Compute.DiskAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource> Get(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DiskAccessResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskAccessResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource>> GetAsync(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DiskAccessResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskAccessResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DiskAccessResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskAccessResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskAccessData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DiskAccessData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
    }
    public partial class DiskAccessResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskAccessResource() { }
        public virtual Azure.ResourceManager.Compute.DiskAccessData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskAccessName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource> GetComputePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionResource>> GetComputePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.ComputePrivateEndpointConnectionCollection GetComputePrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.PrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.PrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccessResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskAccessResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.DiskAccessPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskAccessResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.DiskAccessPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskEncryptionSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskEncryptionSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskEncryptionSetResource>, System.Collections.IEnumerable
    {
        protected DiskEncryptionSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskEncryptionSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diskEncryptionSetName, Azure.ResourceManager.Compute.DiskEncryptionSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskEncryptionSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diskEncryptionSetName, Azure.ResourceManager.Compute.DiskEncryptionSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource> Get(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DiskEncryptionSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskEncryptionSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource>> GetAsync(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DiskEncryptionSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskEncryptionSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DiskEncryptionSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskEncryptionSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskEncryptionSetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DiskEncryptionSetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.KeyForDiskEncryptionSet ActiveKey { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ApiError AutoKeyRotationError { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskEncryptionSetType? EncryptionType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.KeyForDiskEncryptionSet> PreviousKeys { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public bool? RotationToLatestKeyVersionEnabled { get { throw null; } set { } }
    }
    public partial class DiskEncryptionSetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskEncryptionSetResource() { }
        public virtual Azure.ResourceManager.Compute.DiskEncryptionSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskEncryptionSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetAssociatedResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetAssociatedResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskEncryptionSetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.DiskEncryptionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskEncryptionSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.DiskEncryptionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskRestorePointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskRestorePointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskRestorePointResource>, System.Collections.IEnumerable
    {
        protected DiskRestorePointCollection() { }
        public virtual Azure.Response<bool> Exists(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskRestorePointResource> Get(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DiskRestorePointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskRestorePointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskRestorePointResource>> GetAsync(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DiskRestorePointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskRestorePointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DiskRestorePointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskRestorePointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskRestorePointData : Azure.ResourceManager.Models.ResourceData
    {
        internal DiskRestorePointData() { }
        public bool? AcceleratedNetwork { get { throw null; } }
        public float? CompletionPercent { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiskAccessId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskEncryption Encryption { get { throw null; } }
        public string FamilyId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskPurchasePlan PurchasePlan { get { throw null; } }
        public string ReplicationState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } }
        public Azure.Core.AzureLocation? SourceResourceLocation { get { throw null; } }
        public string SourceUniqueId { get { throw null; } }
        public bool? SupportsHibernation { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
    }
    public partial class DiskRestorePointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskRestorePointResource() { }
        public virtual Azure.ResourceManager.Compute.DiskRestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskRestorePointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskRestorePointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.AccessUri> GrantAccess(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.AccessUri>> GrantAccessAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RevokeAccess(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevokeAccessAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryApplicationResource>, System.Collections.IEnumerable
    {
        protected GalleryApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryApplicationName, Azure.ResourceManager.Compute.GalleryApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryApplicationName, Azure.ResourceManager.Compute.GalleryApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource> Get(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.GalleryApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.GalleryApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource>> GetAsync(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.GalleryApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.GalleryApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryApplicationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GalleryApplicationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public System.Uri PrivacyStatementUri { get { throw null; } set { } }
        public System.Uri ReleaseNoteUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? SupportedOSType { get { throw null; } set { } }
    }
    public partial class GalleryApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryApplicationResource() { }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryApplicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> GetGalleryApplicationVersion(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>> GetGalleryApplicationVersionAsync(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationVersionCollection GetGalleryApplicationVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GalleryApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GalleryApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>, System.Collections.IEnumerable
    {
        protected GalleryApplicationVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryApplicationVersionName, Azure.ResourceManager.Compute.GalleryApplicationVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryApplicationVersionName, Azure.ResourceManager.Compute.GalleryApplicationVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> Get(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>> GetAsync(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryApplicationVersionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GalleryApplicationVersionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
    }
    public partial class GalleryApplicationVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryApplicationVersionResource() { }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> Get(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>> GetAsync(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryApplicationVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryApplicationVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryResource>, System.Collections.IEnumerable
    {
        protected GalleryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryName, Azure.ResourceManager.Compute.GalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryName, Azure.ResourceManager.Compute.GalleryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryResource> Get(string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.GalleryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.GalleryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryResource>> GetAsync(string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.GalleryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.GalleryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GalleryData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public string IdentifierUniqueName { get { throw null; } }
        public bool? IsSoftDeleteEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SharingProfile SharingProfile { get { throw null; } set { } }
    }
    public partial class GalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryImageResource>, System.Collections.IEnumerable
    {
        protected GalleryImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Compute.GalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryImageName, Azure.ResourceManager.Compute.GalleryImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.GalleryImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.GalleryImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.GalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.GalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryImageData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GalleryImageData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisallowedDiskTypes { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.GalleryImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes? OSState { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public System.Uri PrivacyStatementUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImagePurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RecommendedMachineConfiguration Recommended { get { throw null; } set { } }
        public System.Uri ReleaseNoteUri { get { throw null; } set { } }
    }
    public partial class GalleryImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryImageResource() { }
        public virtual Azure.ResourceManager.Compute.GalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource> GetGalleryImageVersion(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource>> GetGalleryImageVersionAsync(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImageVersionCollection GetGalleryImageVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GalleryImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryImageVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryImageVersionResource>, System.Collections.IEnumerable
    {
        protected GalleryImageVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryImageVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string galleryImageVersionName, Azure.ResourceManager.Compute.GalleryImageVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryImageVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string galleryImageVersionName, Azure.ResourceManager.Compute.GalleryImageVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource> Get(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.GalleryImageVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.GalleryImageVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource>> GetAsync(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.GalleryImageVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryImageVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.GalleryImageVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryImageVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryImageVersionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GalleryImageVersionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class GalleryImageVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryImageVersionResource() { }
        public virtual Azure.ResourceManager.Compute.GalleryImageVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource> Get(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource>> GetAsync(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryImageVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GalleryImageVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryImageVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GalleryImageVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryResource() { }
        public virtual Azure.ResourceManager.Compute.GalleryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryResource> Get(Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryResource>> GetAsync(Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource> GetGalleryApplication(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationResource>> GetGalleryApplicationAsync(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationCollection GetGalleryApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource> GetGalleryImage(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageResource>> GetGalleryImageAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImageCollection GetGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GalleryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.GalleryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GalleryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.SharingUpdate> UpdateSharingProfile(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.SharingUpdate sharingUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.SharingUpdate>> UpdateSharingProfileAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.SharingUpdate sharingUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ImageResource>, System.Collections.IEnumerable
    {
        protected ImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.Compute.ImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.Compute.ImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ImageResource> Get(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.ImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.ImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ImageResource>> GetAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.ImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.ImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ImageData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationTypes? HyperVGeneration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceVirtualMachineId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class ImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImageResource() { }
        public virtual Azure.ResourceManager.Compute.ImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string imageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ImageResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ImageResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.ImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.ImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedDiskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ManagedDiskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ManagedDiskResource>, System.Collections.IEnumerable
    {
        protected ManagedDiskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ManagedDiskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diskName, Azure.ResourceManager.Compute.ManagedDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ManagedDiskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diskName, Azure.ResourceManager.Compute.ManagedDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource> Get(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.ManagedDiskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.ManagedDiskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource>> GetAsync(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.ManagedDiskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ManagedDiskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.ManagedDiskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ManagedDiskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedDiskData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedDiskData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AcceleratedNetwork { get { throw null; } set { } }
        public bool? BurstingEnabled { get { throw null; } set { } }
        public float? CompletionPercent { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreationData CreationData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskAccessId { get { throw null; } set { } }
        public long? DiskIopsReadOnly { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadOnly { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public long? DiskSizeBytes { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskState? DiskState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingGroup EncryptionSettingGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagedByExtended { get { throw null; } }
        public int? MaxShares { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public string PropertyUpdatesInProgressTargetTier { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskPurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ShareInfoElement> ShareInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskSku Sku { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ManagedDiskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedDiskResource() { }
        public virtual Azure.ResourceManager.Compute.ManagedDiskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.AccessUri> GrantAccess(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.AccessUri>> GrantAccessAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RevokeAccess(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevokeAccessAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ManagedDiskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ManagedDiskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.ManagedDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ManagedDiskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.ManagedDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProximityPlacementGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>, System.Collections.IEnumerable
    {
        protected ProximityPlacementGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string proximityPlacementGroupName, Azure.ResourceManager.Compute.ProximityPlacementGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string proximityPlacementGroupName, Azure.ResourceManager.Compute.ProximityPlacementGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> Get(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> GetAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProximityPlacementGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProximityPlacementGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus> AvailabilitySets { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType? ProximityPlacementGroupType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus> VirtualMachines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus> VirtualMachineScaleSets { get { throw null; } }
    }
    public partial class ProximityPlacementGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProximityPlacementGroupResource() { }
        public virtual Azure.ResourceManager.Compute.ProximityPlacementGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string proximityPlacementGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> Get(string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> GetAsync(string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> Update(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointCollection : Azure.ResourceManager.ArmCollection
    {
        protected RestorePointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string restorePointName, Azure.ResourceManager.Compute.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string restorePointName, Azure.ResourceManager.Compute.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointResource> Get(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointResource>> GetAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointData : Azure.ResourceManager.Models.ResourceData
    {
        public RestorePointData() { }
        public Azure.ResourceManager.Compute.Models.ConsistencyModeTypes? ConsistencyMode { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ExcludeDisks { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata SourceMetadata { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } set { } }
    }
    public partial class RestorePointGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.RestorePointGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.RestorePointGroupResource>, System.Collections.IEnumerable
    {
        protected RestorePointGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string restorePointCollectionName, Azure.ResourceManager.Compute.RestorePointGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string restorePointCollectionName, Azure.ResourceManager.Compute.RestorePointGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> Get(string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.RestorePointGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.RestorePointGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> GetAsync(string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.RestorePointGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.RestorePointGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.RestorePointGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.RestorePointGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorePointGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RestorePointGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ProvisioningState { get { throw null; } }
        public string RestorePointGroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.RestorePointData> RestorePoints { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointCollectionSource Source { get { throw null; } set { } }
    }
    public partial class RestorePointGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePointGroupResource() { }
        public virtual Azure.ResourceManager.Compute.RestorePointGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointCollectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> Get(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> GetAsync(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointResource> GetRestorePoint(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointResource>> GetRestorePointAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.RestorePointCollection GetRestorePoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> Update(Azure.ResourceManager.Compute.Models.RestorePointGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.RestorePointGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePointResource() { }
        public virtual Azure.ResourceManager.Compute.RestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string restorePointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskRestorePointResource> GetDiskRestorePoint(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskRestorePointResource>> GetDiskRestorePointAsync(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DiskRestorePointCollection GetDiskRestorePoints() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedGalleryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGalleryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGalleryResource>, System.Collections.IEnumerable
    {
        protected SharedGalleryCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryResource> Get(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.SharedGalleryResource> GetAll(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.SharedGalleryResource> GetAllAsync(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryResource>> GetAsync(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.SharedGalleryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGalleryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.SharedGalleryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGalleryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedGalleryData : Azure.ResourceManager.Compute.Models.PirSharedGalleryResourceData
    {
        internal SharedGalleryData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
    }
    public partial class SharedGalleryImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageResource>, System.Collections.IEnumerable
    {
        protected SharedGalleryImageCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageResource> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.SharedGalleryImageResource> GetAll(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.SharedGalleryImageResource> GetAllAsync(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageResource>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.SharedGalleryImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.SharedGalleryImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedGalleryImageData : Azure.ResourceManager.Compute.Models.PirSharedGalleryResourceData
    {
        internal SharedGalleryImageData() { }
        public System.Collections.Generic.IList<string> DisallowedDiskTypes { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.GalleryImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageIdentifier Identifier { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes? OSState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImagePurchasePlan PurchasePlan { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RecommendedMachineConfiguration Recommended { get { throw null; } }
    }
    public partial class SharedGalleryImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedGalleryImageResource() { }
        public virtual Azure.ResourceManager.Compute.SharedGalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string galleryUniqueName, string galleryImageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource> GetSharedGalleryImageVersion(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource>> GetSharedGalleryImageVersionAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.SharedGalleryImageVersionCollection GetSharedGalleryImageVersions() { throw null; }
    }
    public partial class SharedGalleryImageVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource>, System.Collections.IEnumerable
    {
        protected SharedGalleryImageVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource> Get(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource> GetAll(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource> GetAllAsync(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource>> GetAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedGalleryImageVersionData : Azure.ResourceManager.Compute.Models.PirSharedGalleryResourceData
    {
        internal SharedGalleryImageVersionData() { }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
    }
    public partial class SharedGalleryImageVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedGalleryImageVersionResource() { }
        public virtual Azure.ResourceManager.Compute.SharedGalleryImageVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string galleryUniqueName, string galleryImageName, string galleryImageVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedGalleryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedGalleryResource() { }
        public virtual Azure.ResourceManager.Compute.SharedGalleryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string galleryUniqueName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageResource> GetSharedGalleryImage(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageResource>> GetSharedGalleryImageAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.SharedGalleryImageCollection GetSharedGalleryImages() { throw null; }
    }
    public partial class SnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SnapshotResource>, System.Collections.IEnumerable
    {
        protected SnapshotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.SnapshotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.Compute.SnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.SnapshotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.Compute.SnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.SnapshotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.SnapshotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.SnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.SnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SnapshotData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SnapshotData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AcceleratedNetwork { get { throw null; } set { } }
        public float? CompletionPercent { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreationData CreationData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskAccessId { get { throw null; } set { } }
        public long? DiskSizeBytes { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskState? DiskState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingGroup EncryptionSettingGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public bool? Incremental { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskPurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SnapshotSku Sku { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UniqueId { get { throw null; } }
    }
    public partial class SnapshotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SnapshotResource() { }
        public virtual Azure.ResourceManager.Compute.SnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SnapshotResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SnapshotResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string snapshotName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.AccessUri> GrantAccess(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.AccessUri>> GrantAccessAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SnapshotResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SnapshotResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RevokeAccess(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevokeAccessAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SnapshotResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SnapshotResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.SnapshotResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.SnapshotPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.SnapshotResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.SnapshotPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SshPublicKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SshPublicKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SshPublicKeyResource>, System.Collections.IEnumerable
    {
        protected SshPublicKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.SshPublicKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sshPublicKeyName, Azure.ResourceManager.Compute.SshPublicKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.SshPublicKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sshPublicKeyName, Azure.ResourceManager.Compute.SshPublicKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> Get(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.SshPublicKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.SshPublicKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> GetAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.SshPublicKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SshPublicKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.SshPublicKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SshPublicKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SshPublicKeyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SshPublicKeyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string PublicKey { get { throw null; } set { } }
    }
    public partial class SshPublicKeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SshPublicKeyResource() { }
        public virtual Azure.ResourceManager.Compute.SshPublicKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sshPublicKeyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult> GenerateKeyPair(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>> GenerateKeyPairAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> Update(Azure.ResourceManager.Compute.Models.SshPublicKeyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.SshPublicKeyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmName, Azure.ResourceManager.Compute.VirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmName, Azure.ResourceManager.Compute.VirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> Get(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> GetAsync(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AvailabilitySetId { get { throw null; } set { } }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VmGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePlan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.VirtualMachineExtensionData> Resources { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.TerminateNotificationProfile ScheduledEventsTerminateNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineScaleSetId { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class VirtualMachineExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmExtensionName, Azure.ResourceManager.Compute.VirtualMachineExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmExtensionName, Azure.ResourceManager.Compute.VirtualMachineExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> Get(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>> GetAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineExtensionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineExtensionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineExtensionImageCollection() { }
        public virtual Azure.Response<bool> Exists(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> Get(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> GetAll(string type, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> GetAllAsync(string type, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>> GetAsync(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineExtensionImageData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineExtensionImageData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ComputeRole { get { throw null; } set { } }
        public string HandlerSchema { get { throw null; } set { } }
        public string OperatingSystem { get { throw null; } set { } }
        public bool? SupportsMultipleExtensions { get { throw null; } set { } }
        public bool? VmScaleSetEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineExtensionImageResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string publisherName, string type, string version) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineExtensionResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string vmExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult> AssessPatches(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>> AssessPatchesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult> Capture(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>> CaptureAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ConvertToManagedDisks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ConvertToManagedDisksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, bool? hibernate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, bool? hibernate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Generalize(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GeneralizeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> Get(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetAvailableSizes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetAvailableSizesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> GetVirtualMachineExtension(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>> GetVirtualMachineExtensionAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionCollection GetVirtualMachineExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> GetVirtualMachineRunCommand(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>> GetVirtualMachineRunCommandAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineRunCommandCollection GetVirtualMachineRunCommands() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult> InstallPatches(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>> InstallPatchesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView> InstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView>> InstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PerformMaintenance(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PerformMaintenanceAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOff(Azure.WaitUntil waitUntil, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOffAsync(Azure.WaitUntil waitUntil, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOn(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOnAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reapply(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReapplyAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult> RetrieveBootDiagnosticsData(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>> RetrieveBootDiagnosticsDataAsync(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.RunCommandResult> RunCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.RunCommandResult>> RunCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SimulateEviction(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SimulateEvictionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineRunCommandCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineRunCommandCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string runCommandName, Azure.ResourceManager.Compute.VirtualMachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string runCommandName, Azure.ResourceManager.Compute.VirtualMachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> Get(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>> GetAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineRunCommandData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineRunCommandData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AsyncExecution { get { throw null; } set { } }
        public System.Uri ErrorBlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView InstanceView { get { throw null; } }
        public System.Uri OutputBlobUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> ProtectedParameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string RunAsPassword { get { throw null; } set { } }
        public string RunAsUser { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource Source { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
    }
    public partial class VirtualMachineRunCommandResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineRunCommandResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineRunCommandData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string runCommandName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmScaleSetName, Azure.ResourceManager.Compute.VirtualMachineScaleSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmScaleSetName, Azure.ResourceManager.Compute.VirtualMachineScaleSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> Get(string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> GetAsync(string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineScaleSetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public bool? DoNotRunExtensionsOnOverprovisionedVms { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OrchestrationMode? OrchestrationMode { get { throw null; } set { } }
        public bool? Overprovision { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePlan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public bool? SinglePlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SpotRestorePolicy SpotRestorePolicy { get { throw null; } set { } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile VirtualMachineProfile { get { throw null; } set { } }
        public bool? ZoneBalance { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmssExtensionName, Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmssExtensionName, Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> Get(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>> GetAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionData : Azure.ResourceManager.Compute.Models.ComputeSubResourceData
    {
        public VirtualMachineScaleSetExtensionData() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetExtensionResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CancelVirtualMachineScaleSetRollingUpgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelVirtualMachineScaleSetRollingUpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ConvertToSinglePlacementGroup(Azure.ResourceManager.Compute.Models.VmScaleSetConvertToSinglePlacementGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ConvertToSinglePlacementGroupAsync(Azure.ResourceManager.Compute.Models.VmScaleSetConvertToSinglePlacementGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteInstances(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteInstancesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse> ForceRecoveryServiceFabricPlatformUpdateDomainWalk(int platformUpdateDomain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>> ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(int platformUpdateDomain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> Get(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> GetAsync(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo> GetOSUpgradeHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo> GetOSUpgradeHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> GetVirtualMachineScaleSetExtension(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>> GetVirtualMachineScaleSetExtensionAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionCollection GetVirtualMachineScaleSetExtensions() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource GetVirtualMachineScaleSetRollingUpgrade() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> GetVirtualMachineScaleSetVm(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> GetVirtualMachineScaleSetVmAsync(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmCollection GetVirtualMachineScaleSetVms() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PerformMaintenance(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PerformMaintenanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOff(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOffAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOn(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOnAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReimageAll(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAllAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SetOrchestrationServiceState(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SetOrchestrationServiceStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartExtensionUpgradeVirtualMachineScaleSetRollingUpgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartExtensionUpgradeVirtualMachineScaleSetRollingUpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartOSUpgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartOSUpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateInstances(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateInstancesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetRollingUpgradeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineScaleSetRollingUpgradeData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradePolicy Policy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo Progress { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus RunningStatus { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetRollingUpgradeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetRollingUpgradeResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetVmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instanceId, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instanceId, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> Get(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> GetAll(string filter = null, string select = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> GetAllAsync(string filter = null, string select = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> GetAsync(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineScaleSetVmData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AvailabilitySetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public string InstanceId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView InstanceView { get { throw null; } }
        public bool? LatestModelApplied { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public string ModelDefinitionApplied { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy ProtectionPolicy { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.VirtualMachineExtensionData> Resources { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVmExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetVmExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmExtensionName, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmExtensionName, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> Get(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>> GetAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionData : Azure.ResourceManager.Compute.Models.ComputeSubResourceData
    {
        public VirtualMachineScaleSetVmExtensionData() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVmExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVmExtensionResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName, string instanceId, string vmExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVmResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName, string instanceId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> Get(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> GetVirtualMachineScaleSetVmExtension(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>> GetVirtualMachineScaleSetVmExtensionAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionCollection GetVirtualMachineScaleSetVmExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> GetVirtualMachineScaleSetVmRunCommand(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> GetVirtualMachineScaleSetVmRunCommandAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandCollection GetVirtualMachineScaleSetVmRunCommands() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PerformMaintenance(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PerformMaintenanceAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOff(Azure.WaitUntil waitUntil, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOffAsync(Azure.WaitUntil waitUntil, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOn(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOnAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReimageAll(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAllAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult> RetrieveBootDiagnosticsData(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>> RetrieveBootDiagnosticsDataAsync(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.RunCommandResult> RunCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.RunCommandResult>> RunCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SimulateEviction(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SimulateEvictionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmRunCommandCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetVmRunCommandCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string runCommandName, Azure.ResourceManager.Compute.VirtualMachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string runCommandName, Azure.ResourceManager.Compute.VirtualMachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> Get(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> GetAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmRunCommandResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVmRunCommandResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineRunCommandData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName, string instanceId, string runCommandName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessLevel : System.IEquatable<Azure.ResourceManager.Compute.Models.AccessLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessLevel(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.AccessLevel None { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AccessLevel Read { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AccessLevel Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.AccessLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.AccessLevel left, Azure.ResourceManager.Compute.Models.AccessLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.AccessLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.AccessLevel left, Azure.ResourceManager.Compute.Models.AccessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessUri
    {
        internal AccessUri() { }
        public string AccessSas { get { throw null; } }
        public string SecurityDataAccessSas { get { throw null; } }
    }
    public partial class AdditionalCapabilities
    {
        public AdditionalCapabilities() { }
        public bool? HibernationEnabled { get { throw null; } set { } }
        public bool? UltraSsdEnabled { get { throw null; } set { } }
    }
    public partial class AdditionalUnattendContent
    {
        public AdditionalUnattendContent() { }
        public string ComponentName { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public string PassName { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SettingNames? SettingName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AggregatedReplicationState : System.IEquatable<Azure.ResourceManager.Compute.Models.AggregatedReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AggregatedReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.AggregatedReplicationState Completed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AggregatedReplicationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AggregatedReplicationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.AggregatedReplicationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.AggregatedReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.AggregatedReplicationState left, Azure.ResourceManager.Compute.Models.AggregatedReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.AggregatedReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.AggregatedReplicationState left, Azure.ResourceManager.Compute.Models.AggregatedReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiError
    {
        internal ApiError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ApiErrorBase> Details { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class ApiErrorBase
    {
        internal ApiErrorBase() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class AutomaticOSUpgradePolicy
    {
        public AutomaticOSUpgradePolicy() { }
        public bool? DisableAutomaticRollback { get { throw null; } set { } }
        public bool? EnableAutomaticOSUpgrade { get { throw null; } set { } }
    }
    public partial class AutomaticRepairsPolicy
    {
        public AutomaticRepairsPolicy() { }
        public bool? Enabled { get { throw null; } set { } }
        public string GracePeriod { get { throw null; } set { } }
    }
    public partial class AvailabilitySetPatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public AvailabilitySetPatch() { }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public int? PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualMachines { get { throw null; } }
    }
    public partial class AvailablePatchSummary
    {
        internal AvailablePatchSummary() { }
        public string AssessmentActivityId { get { throw null; } }
        public int? CriticalAndSecurityPatchCount { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public int? OtherPatchCount { get { throw null; } }
        public bool? RebootPending { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchOperationStatus? Status { get { throw null; } }
    }
    public partial class BootDiagnostics
    {
        public BootDiagnostics() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
    }
    public partial class BootDiagnosticsInstanceView
    {
        internal BootDiagnosticsInstanceView() { }
        public System.Uri ConsoleScreenshotBlobUri { get { throw null; } }
        public System.Uri SerialConsoleLogBlobUri { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus Status { get { throw null; } }
    }
    public enum CachingTypes
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityReservationGroupInstanceViewTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityReservationGroupInstanceViewTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes left, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes left, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityReservationGroupPatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public CapacityReservationGroupPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> CapacityReservations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName> InstanceViewCapacityReservations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
    }
    public partial class CapacityReservationInstanceView
    {
        internal CapacityReservationInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> UtilizationInfoVirtualMachinesAllocated { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityReservationInstanceViewTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityReservationInstanceViewTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes left, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes left, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityReservationInstanceViewWithName : Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView
    {
        internal CapacityReservationInstanceViewWithName() { }
        public string Name { get { throw null; } }
    }
    public partial class CapacityReservationPatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public CapacityReservationPatch() { }
        public Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView InstanceView { get { throw null; } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
    }
    public partial class CloudServiceExtension
    {
        public CloudServiceExtension() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string CloudServiceExtensionPropertiesType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CloudServiceVaultAndSecretReference ProtectedSettingsFromKeyVault { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RolesAppliedTo { get { throw null; } }
        public string Settings { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class CloudServiceInstanceView
    {
        internal CloudServiceInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<string> PrivateIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.StatusCodeCount> RoleInstanceStatusesSummary { get { throw null; } }
        public string SdkVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceInstanceViewStatus> Statuses { get { throw null; } }
    }
    public partial class CloudServiceNetworkProfile
    {
        public CloudServiceNetworkProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.LoadBalancerConfiguration> LoadBalancerConfigurations { get { throw null; } }
        public Azure.Core.ResourceIdentifier SwappableCloudServiceId { get { throw null; } set { } }
    }
    public partial class CloudServicePatch
    {
        public CloudServicePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CloudServiceRoleProfileProperties
    {
        public CloudServiceRoleProfileProperties() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CloudServiceRoleSku Sku { get { throw null; } set { } }
    }
    public partial class CloudServiceRoleSku
    {
        public CloudServiceRoleSku() { }
        public long? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudServiceUpgradeMode : System.IEquatable<Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudServiceUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode Auto { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode Manual { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode Simultaneous { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode left, Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode left, Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudServiceVaultAndSecretReference
    {
        public CloudServiceVaultAndSecretReference() { }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
    }
    public partial class CloudServiceVaultCertificate
    {
        public CloudServiceVaultCertificate() { }
        public System.Uri CertificateUri { get { throw null; } set { } }
    }
    public partial class CloudServiceVaultSecretGroup
    {
        public CloudServiceVaultSecretGroup() { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.CloudServiceVaultCertificate> VaultCertificates { get { throw null; } }
    }
    public partial class CommunityGallery : Azure.ResourceManager.Compute.Models.PirCommunityGalleryResourceData
    {
        internal CommunityGallery() { }
    }
    public partial class CommunityGalleryImage : Azure.ResourceManager.Compute.Models.PirCommunityGalleryResourceData
    {
        internal CommunityGalleryImage() { }
        public System.Collections.Generic.IList<string> DisallowedDiskTypes { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.GalleryImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageIdentifier Identifier { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes? OSState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImagePurchasePlan PurchasePlan { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RecommendedMachineConfiguration Recommended { get { throw null; } }
    }
    public partial class CommunityGalleryImageVersion : Azure.ResourceManager.Compute.Models.PirCommunityGalleryResourceData
    {
        internal CommunityGalleryImageVersion() { }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
    }
    public partial class ComputePlan
    {
        public ComputePlan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Compute.Models.ComputePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputePrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputePrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputePrivateLinkServiceConnectionState
    {
        public ComputePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class ComputeResourceSku
    {
        internal ComputeResourceSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuCosts> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class ComputeResourceSkuCapacity
    {
        internal ComputeResourceSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
    }
    public partial class ComputeResourceSkuLocationInfo
    {
        internal ComputeResourceSkuLocationInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> ExtendedLocations { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ExtendedLocationType? ExtendedLocationType { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ComputeSku
    {
        public ComputeSku() { }
        public long? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class ComputeSubResourceData
    {
        public ComputeSubResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
    }
    public partial class ComputeSubResourceDataWithColocationStatus : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData
    {
        public ComputeSubResourceDataWithColocationStatus() { }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
    }
    public partial class ComputeUpdateResourceData
    {
        public ComputeUpdateResourceData() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ComputeUsage
    {
        internal ComputeUsage() { }
        public int CurrentValue { get { throw null; } }
        public long Limit { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class ComputeWriteableSubResourceData
    {
        public ComputeWriteableSubResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsistencyModeTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.ConsistencyModeTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsistencyModeTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ConsistencyModeTypes ApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ConsistencyModeTypes CrashConsistent { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ConsistencyModeTypes FileSystemConsistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ConsistencyModeTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ConsistencyModeTypes left, Azure.ResourceManager.Compute.Models.ConsistencyModeTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ConsistencyModeTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ConsistencyModeTypes left, Azure.ResourceManager.Compute.Models.ConsistencyModeTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataDisk
    {
        public DataDisk(int lun, Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskDetachOptionTypes? DetachOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } }
        public long? DiskMBpsReadWrite { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ToBeDetached { get { throw null; } set { } }
        public System.Uri VhdUri { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class DataDiskImage
    {
        public DataDiskImage() { }
        public int? Lun { get { throw null; } }
    }
    public partial class DataDiskImageEncryption : Azure.ResourceManager.Compute.Models.DiskImageEncryption
    {
        public DataDiskImageEncryption(int lun) { }
        public int Lun { get { throw null; } set { } }
    }
    public partial class DedicatedHostAllocatableVm
    {
        internal DedicatedHostAllocatableVm() { }
        public double? Count { get { throw null; } }
        public string VmSize { get { throw null; } }
    }
    public partial class DedicatedHostGroupPatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public DedicatedHostGroupPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Hosts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName> InstanceViewHosts { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public bool? SupportAutomaticPlacement { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class DedicatedHostInstanceView
    {
        internal DedicatedHostInstanceView() { }
        public string AssetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm> AvailableCapacityAllocatableVms { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
    }
    public partial class DedicatedHostInstanceViewWithName : Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView
    {
        internal DedicatedHostInstanceViewWithName() { }
        public string Name { get { throw null; } }
    }
    public enum DedicatedHostLicenseTypes
    {
        None = 0,
        WindowsServerHybrid = 1,
        WindowsServerPerpetual = 2,
    }
    public partial class DedicatedHostPatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public DedicatedHostPatch() { }
        public bool? AutoReplaceOnFailure { get { throw null; } set { } }
        public string HostId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostLicenseTypes? LicenseType { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachines { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeleteOptions : System.IEquatable<Azure.ResourceManager.Compute.Models.DeleteOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeleteOptions(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DeleteOptions Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DeleteOptions Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DeleteOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DeleteOptions left, Azure.ResourceManager.Compute.Models.DeleteOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DeleteOptions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DeleteOptions left, Azure.ResourceManager.Compute.Models.DeleteOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskOptions : System.IEquatable<Azure.ResourceManager.Compute.Models.DiffDiskOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskOptions(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiffDiskOptions Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiffDiskOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiffDiskOptions left, Azure.ResourceManager.Compute.Models.DiffDiskOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiffDiskOptions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiffDiskOptions left, Azure.ResourceManager.Compute.Models.DiffDiskOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.ResourceManager.Compute.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiffDiskPlacement ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiffDiskPlacement left, Azure.ResourceManager.Compute.Models.DiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiffDiskPlacement left, Azure.ResourceManager.Compute.Models.DiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiffDiskSettings
    {
        public DiffDiskSettings() { }
        public Azure.ResourceManager.Compute.Models.DiffDiskOptions? Option { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiffDiskPlacement? Placement { get { throw null; } set { } }
    }
    public partial class DiskAccessPatch
    {
        public DiskAccessPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOption : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskCreateOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOption(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Attach { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Copy { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption CopyStart { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Empty { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption FromImage { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Import { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption ImportSecure { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Restore { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption Upload { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOption UploadPreparedSecure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskCreateOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskCreateOption left, Azure.ResourceManager.Compute.Models.DiskCreateOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskCreateOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskCreateOption left, Azure.ResourceManager.Compute.Models.DiskCreateOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOptionTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOptionTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes Attach { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes Empty { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes FromImage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes left, Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes left, Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskCreationData
    {
        public DiskCreationData(Azure.ResourceManager.Compute.Models.DiskCreateOption createOption) { }
        public Azure.ResourceManager.Compute.Models.DiskCreateOption CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageDiskReference GalleryImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageDiskReference ImageReference { get { throw null; } set { } }
        public int? LogicalSectorSize { get { throw null; } set { } }
        public System.Uri SecurityDataUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public string SourceUniqueId { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public long? UploadSizeBytes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDeleteOptionTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDeleteOptionTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes left, Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes left, Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDetachOptionTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskDetachOptionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDetachOptionTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskDetachOptionTypes ForceDetach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskDetachOptionTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskDetachOptionTypes left, Azure.ResourceManager.Compute.Models.DiskDetachOptionTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskDetachOptionTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskDetachOptionTypes left, Azure.ResourceManager.Compute.Models.DiskDetachOptionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskEncryption
    {
        public DiskEncryption() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionType? EncryptionType { get { throw null; } set { } }
    }
    public partial class DiskEncryptionSetPatch
    {
        public DiskEncryptionSetPatch() { }
        public Azure.ResourceManager.Compute.Models.KeyForDiskEncryptionSet ActiveKey { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskEncryptionSetType? EncryptionType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public bool? RotationToLatestKeyVersionEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DiskEncryptionSettings
    {
        public DiskEncryptionSettings() { }
        public Azure.ResourceManager.Compute.Models.KeyVaultSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultKeyReference KeyEncryptionKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskEncryptionSetType : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskEncryptionSetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskEncryptionSetType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskEncryptionSetType ConfidentialVmEncryptedWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskEncryptionSetType EncryptionAtRestWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskEncryptionSetType EncryptionAtRestWithPlatformAndCustomerKeys { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskEncryptionSetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskEncryptionSetType left, Azure.ResourceManager.Compute.Models.DiskEncryptionSetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskEncryptionSetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskEncryptionSetType left, Azure.ResourceManager.Compute.Models.DiskEncryptionSetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskImageEncryption
    {
        public DiskImageEncryption() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
    }
    public partial class DiskInstanceView
    {
        internal DiskInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings> EncryptionSettings { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
    }
    public partial class DiskPurchasePlan
    {
        public DiskPurchasePlan(string name, string publisher, string product) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    public partial class DiskSecurityProfile
    {
        public DiskSecurityProfile() { }
        public Azure.Core.ResourceIdentifier SecureVmDiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskSecurityTypes? SecurityType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskSecurityTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskSecurityTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskSecurityTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskSecurityTypes ConfidentialVmDiskEncryptedWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskSecurityTypes ConfidentialVmDiskEncryptedWithPlatformKey { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskSecurityTypes ConfidentialVmGuestStateOnlyEncryptedWithPlatformKey { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskSecurityTypes TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskSecurityTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskSecurityTypes left, Azure.ResourceManager.Compute.Models.DiskSecurityTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskSecurityTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskSecurityTypes left, Azure.ResourceManager.Compute.Models.DiskSecurityTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskSku
    {
        public DiskSku() { }
        public Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes? Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskState : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskState ActiveSas { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState ActiveSasFrozen { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState ActiveUpload { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState Attached { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState Frozen { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState ReadyToUpload { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState Reserved { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState Unattached { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskState left, Azure.ResourceManager.Compute.Models.DiskState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskState left, Azure.ResourceManager.Compute.Models.DiskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskStorageAccountTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskStorageAccountTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes PremiumZRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes StandardSsdLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes StandardSsdZRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes UltraSsdLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes left, Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes left, Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionImages
    {
        public EncryptionImages() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDiskImageEncryption> DataDiskImages { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
    }
    public partial class EncryptionSettingGroup
    {
        public EncryptionSettingGroup(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.EncryptionSettingsElement> EncryptionSettings { get { throw null; } }
        public string EncryptionSettingsVersion { get { throw null; } set { } }
    }
    public partial class EncryptionSettingsElement
    {
        public EncryptionSettingsElement() { }
        public Azure.ResourceManager.Compute.Models.KeyVaultAndSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultAndKeyReference KeyEncryptionKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionType : System.IEquatable<Azure.ResourceManager.Compute.Models.EncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.EncryptionType EncryptionAtRestWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.EncryptionType EncryptionAtRestWithPlatformAndCustomerKeys { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.EncryptionType EncryptionAtRestWithPlatformKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.EncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.EncryptionType left, Azure.ResourceManager.Compute.Models.EncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.EncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.EncryptionType left, Azure.ResourceManager.Compute.Models.EncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionState : System.IEquatable<Azure.ResourceManager.Compute.Models.ExecutionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ExecutionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ExecutionState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ExecutionState Pending { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ExecutionState Running { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ExecutionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ExecutionState TimedOut { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ExecutionState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ExecutionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ExecutionState left, Azure.ResourceManager.Compute.Models.ExecutionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ExecutionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ExecutionState left, Azure.ResourceManager.Compute.Models.ExecutionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpandTypesForGetCapacityReservationGroups : System.IEquatable<Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpandTypesForGetCapacityReservationGroups(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups VirtualMachineScaleSetVmsRef { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups VirtualMachinesRef { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups left, Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups left, Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpandTypesForGetVmScaleSets : System.IEquatable<Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpandTypesForGetVmScaleSets(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets UserData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets left, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets left, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVmScaleSets right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtendedLocation
    {
        public ExtendedLocation() { }
        public Azure.ResourceManager.Compute.Models.ExtendedLocationTypes? ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationType : System.IEquatable<Azure.ResourceManager.Compute.Models.ExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ExtendedLocationType EdgeZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ExtendedLocationType left, Azure.ResourceManager.Compute.Models.ExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ExtendedLocationType left, Azure.ResourceManager.Compute.Models.ExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.ExtendedLocationTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ExtendedLocationTypes EdgeZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ExtendedLocationTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ExtendedLocationTypes left, Azure.ResourceManager.Compute.Models.ExtendedLocationTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ExtendedLocationTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ExtendedLocationTypes left, Azure.ResourceManager.Compute.Models.ExtendedLocationTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryApplicationPatch : Azure.ResourceManager.Compute.Models.GalleryUpdateResourceDefinition
    {
        public GalleryApplicationPatch() { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public System.Uri PrivacyStatementUri { get { throw null; } set { } }
        public System.Uri ReleaseNoteUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? SupportedOSType { get { throw null; } set { } }
    }
    public partial class GalleryApplicationVersionPatch : Azure.ResourceManager.Compute.Models.GalleryUpdateResourceDefinition
    {
        public GalleryApplicationVersionPatch() { }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryApplicationVersionPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryApplicationVersionPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryApplicationVersionPublishingProfile : Azure.ResourceManager.Compute.Models.GalleryArtifactPublishingProfileBase
    {
        public GalleryApplicationVersionPublishingProfile(Azure.ResourceManager.Compute.Models.UserArtifactSource source) { }
        public bool? EnableHealthCheck { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UserArtifactManage ManageActions { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UserArtifactSource Source { get { throw null; } set { } }
    }
    public partial class GalleryArtifactPublishingProfileBase
    {
        public GalleryArtifactPublishingProfileBase() { }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } set { } }
        public bool? ExcludeFromLatest { get { throw null; } set { } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationMode? ReplicationMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.TargetRegion> TargetRegions { get { throw null; } }
    }
    public partial class GalleryArtifactVersionSource
    {
        public GalleryArtifactVersionSource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class GalleryDataDiskImage : Azure.ResourceManager.Compute.Models.GalleryDiskImage
    {
        public GalleryDataDiskImage(int lun) { }
        public int Lun { get { throw null; } set { } }
    }
    public partial class GalleryDiskImage
    {
        public GalleryDiskImage() { }
        public Azure.ResourceManager.Compute.Models.HostCaching? HostCaching { get { throw null; } set { } }
        public int? SizeInGB { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryArtifactVersionSource Source { get { throw null; } set { } }
    }
    public partial class GalleryImageFeature
    {
        public GalleryImageFeature() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class GalleryImageIdentifier
    {
        public GalleryImageIdentifier(string publisher, string offer, string sku) { }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
    }
    public partial class GalleryImagePatch : Azure.ResourceManager.Compute.Models.GalleryUpdateResourceDefinition
    {
        public GalleryImagePatch() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisallowedDiskTypes { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeOn { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.GalleryImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryImageIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes? OSState { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public System.Uri PrivacyStatementUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImagePurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RecommendedMachineConfiguration Recommended { get { throw null; } set { } }
        public System.Uri ReleaseNoteUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryImagePropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryImagePropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryImagePropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryImageVersionPatch : Azure.ResourceManager.Compute.Models.GalleryUpdateResourceDefinition
    {
        public GalleryImageVersionPatch() { }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionStorageProfile StorageProfile { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryImageVersionPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryImageVersionPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryImageVersionPublishingProfile : Azure.ResourceManager.Compute.Models.GalleryArtifactPublishingProfileBase
    {
        public GalleryImageVersionPublishingProfile() { }
    }
    public partial class GalleryImageVersionStorageProfile
    {
        public GalleryImageVersionStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.GalleryDataDiskImage> DataDiskImages { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryOSDiskImage OSDiskImage { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryArtifactVersionSource Source { get { throw null; } set { } }
    }
    public partial class GalleryOSDiskImage : Azure.ResourceManager.Compute.Models.GalleryDiskImage
    {
        public GalleryOSDiskImage() { }
    }
    public partial class GalleryPatch : Azure.ResourceManager.Compute.Models.GalleryUpdateResourceDefinition
    {
        public GalleryPatch() { }
        public string Description { get { throw null; } set { } }
        public string IdentifierUniqueName { get { throw null; } }
        public bool? IsSoftDeleteEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SharingProfile SharingProfile { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GalleryPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GalleryPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState left, Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GallerySharingPermissionTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.GallerySharingPermissionTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GallerySharingPermissionTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.GallerySharingPermissionTypes Groups { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.GallerySharingPermissionTypes Private { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.GallerySharingPermissionTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.GallerySharingPermissionTypes left, Azure.ResourceManager.Compute.Models.GallerySharingPermissionTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.GallerySharingPermissionTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.GallerySharingPermissionTypes left, Azure.ResourceManager.Compute.Models.GallerySharingPermissionTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GalleryUpdateResourceDefinition : Azure.ResourceManager.Models.ResourceData
    {
        public GalleryUpdateResourceDefinition() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class GrantAccessData
    {
        public GrantAccessData(Azure.ResourceManager.Compute.Models.AccessLevel access, int durationInSeconds) { }
        public Azure.ResourceManager.Compute.Models.AccessLevel Access { get { throw null; } }
        public int DurationInSeconds { get { throw null; } }
        public bool? GetSecureVmGuestStateSas { get { throw null; } set { } }
    }
    public partial class HardwareProfile
    {
        public HardwareProfile() { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes? VmSize { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VmSizeProperties VmSizeProperties { get { throw null; } set { } }
    }
    public enum HostCaching
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGeneration : System.IEquatable<Azure.ResourceManager.Compute.Models.HyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.HyperVGeneration V1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.HyperVGeneration V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.HyperVGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.HyperVGeneration left, Azure.ResourceManager.Compute.Models.HyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.HyperVGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.HyperVGeneration left, Azure.ResourceManager.Compute.Models.HyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGenerationType : System.IEquatable<Azure.ResourceManager.Compute.Models.HyperVGenerationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGenerationType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.HyperVGenerationType V1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.HyperVGenerationType V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.HyperVGenerationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.HyperVGenerationType left, Azure.ResourceManager.Compute.Models.HyperVGenerationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.HyperVGenerationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.HyperVGenerationType left, Azure.ResourceManager.Compute.Models.HyperVGenerationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGenerationTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.HyperVGenerationTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGenerationTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.HyperVGenerationTypes V1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.HyperVGenerationTypes V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.HyperVGenerationTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.HyperVGenerationTypes left, Azure.ResourceManager.Compute.Models.HyperVGenerationTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.HyperVGenerationTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.HyperVGenerationTypes left, Azure.ResourceManager.Compute.Models.HyperVGenerationTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageDataDisk : Azure.ResourceManager.Compute.Models.ImageDisk
    {
        public ImageDataDisk(int lun) { }
        public int Lun { get { throw null; } set { } }
    }
    public partial class ImageDisk
    {
        public ImageDisk() { }
        public System.Uri BlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedDiskId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SnapshotId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
    }
    public partial class ImageDiskReference
    {
        public ImageDiskReference(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public int? Lun { get { throw null; } set { } }
    }
    public partial class ImageOSDisk : Azure.ResourceManager.Compute.Models.ImageDisk
    {
        public ImageOSDisk(Azure.ResourceManager.Compute.Models.OperatingSystemTypes osType, Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes osState) { }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes OSState { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes OSType { get { throw null; } set { } }
    }
    public partial class ImagePatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public ImagePatch() { }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationTypes? HyperVGeneration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceVirtualMachineId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class ImagePurchasePlan
    {
        public ImagePurchasePlan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    public partial class ImageReference : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData
    {
        public ImageReference() { }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageUniqueId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ImageStorageProfile
    {
        public ImageStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.ImageDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImageOSDisk OSDisk { get { throw null; } set { } }
        public bool? ZoneResilient { get { throw null; } set { } }
    }
    public partial class InnerError
    {
        internal InnerError() { }
        public string Errordetail { get { throw null; } }
        public string Exceptiontype { get { throw null; } }
    }
    public partial class InstanceSku
    {
        internal InstanceSku() { }
        public string Name { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class InstanceViewStatus
    {
        public InstanceViewStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StatusLevelTypes? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
    }
    public enum InstanceViewTypes
    {
        InstanceView = 0,
        UserData = 1,
    }
    public enum IntervalInMins
    {
        ThreeMins = 0,
        FiveMins = 1,
        ThirtyMins = 2,
        SixtyMins = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPVersion : System.IEquatable<Azure.ResourceManager.Compute.Models.IPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPVersion(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.IPVersion IPv4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.IPVersion IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.IPVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.IPVersion left, Azure.ResourceManager.Compute.Models.IPVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.IPVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.IPVersion left, Azure.ResourceManager.Compute.Models.IPVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyForDiskEncryptionSet
    {
        public KeyForDiskEncryptionSet(System.Uri keyUri) { }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
    }
    public partial class KeyVaultAndKeyReference
    {
        public KeyVaultAndKeyReference(Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault, System.Uri keyUri) { }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
    }
    public partial class KeyVaultAndSecretReference
    {
        public KeyVaultAndSecretReference(Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault, System.Uri secretUri) { }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
    }
    public partial class KeyVaultKeyReference
    {
        public KeyVaultKeyReference(System.Uri keyUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
    }
    public partial class KeyVaultSecretReference
    {
        public KeyVaultSecretReference(System.Uri secretUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
    }
    public partial class LastPatchInstallationSummary
    {
        internal LastPatchInstallationSummary() { }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public int? ExcludedPatchCount { get { throw null; } }
        public int? FailedPatchCount { get { throw null; } }
        public string InstallationActivityId { get { throw null; } }
        public int? InstalledPatchCount { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public bool? MaintenanceWindowExceeded { get { throw null; } }
        public int? NotSelectedPatchCount { get { throw null; } }
        public int? PendingPatchCount { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchOperationStatus? Status { get { throw null; } }
    }
    public partial class LinuxConfiguration
    {
        public LinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SshPublicKeyInfo> SshPublicKeys { get { throw null; } }
    }
    public partial class LinuxParameters
    {
        public LinuxParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux> ClassificationsToInclude { get { throw null; } }
        public string MaintenanceRunId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PackageNameMasksToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToInclude { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxPatchSettings
    {
        public LinuxPatchSettings() { }
        public Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode? PatchMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVmGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode left, Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode left, Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadBalancerConfiguration
    {
        public LoadBalancerConfiguration(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.LoadBalancerFrontendIPConfiguration> frontendIPConfigurations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.LoadBalancerFrontendIPConfiguration> FrontendIPConfigurations { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class LoadBalancerFrontendIPConfiguration
    {
        public LoadBalancerFrontendIPConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPAddressId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class LogAnalytics
    {
        internal LogAnalytics() { }
        public string LogAnalyticsOutput { get { throw null; } }
    }
    public partial class LogAnalyticsInputBase
    {
        public LogAnalyticsInputBase(System.Uri blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime) { }
        public System.Uri BlobContainerSasUri { get { throw null; } }
        public System.DateTimeOffset FromTime { get { throw null; } }
        public bool? GroupByClientApplicationId { get { throw null; } set { } }
        public bool? GroupByOperationName { get { throw null; } set { } }
        public bool? GroupByResourceName { get { throw null; } set { } }
        public bool? GroupByThrottlePolicy { get { throw null; } set { } }
        public bool? GroupByUserAgent { get { throw null; } set { } }
        public System.DateTimeOffset ToTime { get { throw null; } }
    }
    public enum MaintenanceOperationResultCodeTypes
    {
        None = 0,
        RetryLater = 1,
        MaintenanceAborted = 2,
        MaintenanceCompleted = 3,
    }
    public partial class MaintenanceRedeployStatus
    {
        internal MaintenanceRedeployStatus() { }
        public bool? IsCustomerInitiatedMaintenanceAllowed { get { throw null; } }
        public string LastOperationMessage { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.MaintenanceOperationResultCodeTypes? LastOperationResultCode { get { throw null; } }
        public System.DateTimeOffset? MaintenanceWindowEndOn { get { throw null; } }
        public System.DateTimeOffset? MaintenanceWindowStartOn { get { throw null; } }
        public System.DateTimeOffset? PreMaintenanceWindowEndOn { get { throw null; } }
        public System.DateTimeOffset? PreMaintenanceWindowStartOn { get { throw null; } }
    }
    public partial class ManagedDiskParameters : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData
    {
        public ManagedDiskParameters() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
    }
    public partial class ManagedDiskPatch
    {
        public ManagedDiskPatch() { }
        public bool? AcceleratedNetwork { get { throw null; } set { } }
        public bool? BurstingEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskAccessId { get { throw null; } set { } }
        public long? DiskIopsReadOnly { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadOnly { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingGroup EncryptionSettingGroup { get { throw null; } set { } }
        public int? MaxShares { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public string PropertyUpdatesInProgressTargetTier { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskPurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskSku Sku { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkAccessPolicy : System.IEquatable<Azure.ResourceManager.Compute.Models.NetworkAccessPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkAccessPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.NetworkAccessPolicy AllowAll { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.NetworkAccessPolicy AllowPrivate { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.NetworkAccessPolicy DenyAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.NetworkAccessPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.NetworkAccessPolicy left, Azure.ResourceManager.Compute.Models.NetworkAccessPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.NetworkAccessPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.NetworkAccessPolicy left, Azure.ResourceManager.Compute.Models.NetworkAccessPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkApiVersion : System.IEquatable<Azure.ResourceManager.Compute.Models.NetworkApiVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkApiVersion(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.NetworkApiVersion TwoThousandTwenty1101 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.NetworkApiVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.NetworkApiVersion left, Azure.ResourceManager.Compute.Models.NetworkApiVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.NetworkApiVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.NetworkApiVersion left, Azure.ResourceManager.Compute.Models.NetworkApiVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkInterfaceReference : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData
    {
        public NetworkInterfaceReference() { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class NetworkProfile
    {
        public NetworkProfile() { }
        public Azure.ResourceManager.Compute.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.NetworkInterfaceReference> NetworkInterfaces { get { throw null; } }
    }
    public enum OperatingSystemStateTypes
    {
        Generalized = 0,
        Specialized = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystemType : System.IEquatable<Azure.ResourceManager.Compute.Models.OperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.OperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.OperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.OperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.OperatingSystemType left, Azure.ResourceManager.Compute.Models.OperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.OperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.OperatingSystemType left, Azure.ResourceManager.Compute.Models.OperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum OperatingSystemTypes
    {
        Windows = 0,
        Linux = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestrationMode : System.IEquatable<Azure.ResourceManager.Compute.Models.OrchestrationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.OrchestrationMode Flexible { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.OrchestrationMode Uniform { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.OrchestrationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.OrchestrationMode left, Azure.ResourceManager.Compute.Models.OrchestrationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.OrchestrationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.OrchestrationMode left, Azure.ResourceManager.Compute.Models.OrchestrationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestrationServiceNames : System.IEquatable<Azure.ResourceManager.Compute.Models.OrchestrationServiceNames>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationServiceNames(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceNames AutomaticRepairs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.OrchestrationServiceNames other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.OrchestrationServiceNames left, Azure.ResourceManager.Compute.Models.OrchestrationServiceNames right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.OrchestrationServiceNames (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.OrchestrationServiceNames left, Azure.ResourceManager.Compute.Models.OrchestrationServiceNames right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestrationServiceState : System.IEquatable<Azure.ResourceManager.Compute.Models.OrchestrationServiceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationServiceState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceState NotRunning { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceState Running { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.OrchestrationServiceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.OrchestrationServiceState left, Azure.ResourceManager.Compute.Models.OrchestrationServiceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.OrchestrationServiceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.OrchestrationServiceState left, Azure.ResourceManager.Compute.Models.OrchestrationServiceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestrationServiceStateAction : System.IEquatable<Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationServiceStateAction(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction Resume { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction Suspend { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction left, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction left, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OrchestrationServiceStateContent
    {
        public OrchestrationServiceStateContent(Azure.ResourceManager.Compute.Models.OrchestrationServiceNames serviceName, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction action) { }
        public Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction Action { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OrchestrationServiceNames ServiceName { get { throw null; } }
    }
    public partial class OrchestrationServiceSummary
    {
        internal OrchestrationServiceSummary() { }
        public Azure.ResourceManager.Compute.Models.OrchestrationServiceNames? ServiceName { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OrchestrationServiceState? ServiceState { get { throw null; } }
    }
    public partial class OSDisk
    {
        public OSDisk(Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskDeleteOptionTypes? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskEncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public System.Uri VhdUri { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class OSProfile
    {
        public OSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public bool? AllowExtensionOperations { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public bool? RequireGuestProvisionSignal { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    public partial class OSVersionPropertiesBase
    {
        internal OSVersionPropertiesBase() { }
        public bool? IsActive { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        public string Label { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchAssessmentState : System.IEquatable<Azure.ResourceManager.Compute.Models.PatchAssessmentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchAssessmentState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PatchAssessmentState Available { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PatchAssessmentState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.PatchAssessmentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.PatchAssessmentState left, Azure.ResourceManager.Compute.Models.PatchAssessmentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.PatchAssessmentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.PatchAssessmentState left, Azure.ResourceManager.Compute.Models.PatchAssessmentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatchInstallationDetail
    {
        internal PatchInstallationDetail() { }
        public System.Collections.Generic.IReadOnlyList<string> Classifications { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchInstallationState? InstallationState { get { throw null; } }
        public string KbId { get { throw null; } }
        public string Name { get { throw null; } }
        public string PatchId { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchInstallationState : System.IEquatable<Azure.ResourceManager.Compute.Models.PatchInstallationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchInstallationState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PatchInstallationState Excluded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PatchInstallationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PatchInstallationState Installed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PatchInstallationState NotSelected { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PatchInstallationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PatchInstallationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.PatchInstallationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.PatchInstallationState left, Azure.ResourceManager.Compute.Models.PatchInstallationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.PatchInstallationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.PatchInstallationState left, Azure.ResourceManager.Compute.Models.PatchInstallationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchOperationStatus : System.IEquatable<Azure.ResourceManager.Compute.Models.PatchOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PatchOperationStatus CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PatchOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PatchOperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PatchOperationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PatchOperationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.PatchOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.PatchOperationStatus left, Azure.ResourceManager.Compute.Models.PatchOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.PatchOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.PatchOperationStatus left, Azure.ResourceManager.Compute.Models.PatchOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatchSettings
    {
        public PatchSettings() { }
        public Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public bool? EnableHotpatching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode? PatchMode { get { throw null; } set { } }
    }
    public partial class PirCommunityGalleryResourceData
    {
        internal PirCommunityGalleryResourceData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string UniqueId { get { throw null; } }
    }
    public partial class PirResourceData
    {
        internal PirResourceData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class PirSharedGalleryResourceData : Azure.ResourceManager.Compute.Models.PirResourceData
    {
        internal PirSharedGalleryResourceData() { }
        public string UniqueId { get { throw null; } }
    }
    public partial class PrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal PrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public enum ProtocolTypes
    {
        Http = 0,
        Https = 1,
    }
    public partial class ProximityPlacementGroupPatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public ProximityPlacementGroupPatch() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProximityPlacementGroupType : System.IEquatable<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProximityPlacementGroupType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType Standard { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType Ultra { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType left, Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType left, Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PublicIPAddressSku
    {
        public PublicIPAddressSku() { }
        public Azure.ResourceManager.Compute.Models.PublicIPAddressSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PublicIPAddressSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuName : System.IEquatable<Azure.ResourceManager.Compute.Models.PublicIPAddressSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PublicIPAddressSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PublicIPAddressSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.PublicIPAddressSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.PublicIPAddressSkuName left, Azure.ResourceManager.Compute.Models.PublicIPAddressSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.PublicIPAddressSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.PublicIPAddressSkuName left, Azure.ResourceManager.Compute.Models.PublicIPAddressSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAddressSkuTier : System.IEquatable<Azure.ResourceManager.Compute.Models.PublicIPAddressSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAddressSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PublicIPAddressSkuTier Global { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PublicIPAddressSkuTier Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.PublicIPAddressSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.Compute.Models.PublicIPAddressSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.PublicIPAddressSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.PublicIPAddressSkuTier left, Azure.ResourceManager.Compute.Models.PublicIPAddressSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAllocationMethod : System.IEquatable<Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod left, Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod left, Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Compute.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.PublicNetworkAccess left, Azure.ResourceManager.Compute.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.PublicNetworkAccess left, Azure.ResourceManager.Compute.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurchasePlan
    {
        public PurchasePlan(string publisher, string name, string product) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    public partial class RecommendedMachineConfiguration
    {
        public RecommendedMachineConfiguration() { }
        public Azure.ResourceManager.Compute.Models.ResourceRange Memory { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ResourceRange VCPUs { get { throw null; } set { } }
    }
    public partial class RecoveryWalkResponse
    {
        internal RecoveryWalkResponse() { }
        public int? NextPlatformUpdateDomain { get { throw null; } }
        public bool? WalkPerformed { get { throw null; } }
    }
    public partial class RegionalReplicationStatus
    {
        internal RegionalReplicationStatus() { }
        public string Details { get { throw null; } }
        public int? Progress { get { throw null; } }
        public string Region { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ReplicationState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationMode : System.IEquatable<Azure.ResourceManager.Compute.Models.ReplicationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ReplicationMode Full { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ReplicationMode Shallow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ReplicationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ReplicationMode left, Azure.ResourceManager.Compute.Models.ReplicationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ReplicationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ReplicationMode left, Azure.ResourceManager.Compute.Models.ReplicationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationState : System.IEquatable<Azure.ResourceManager.Compute.Models.ReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ReplicationState Completed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ReplicationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ReplicationState Replicating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ReplicationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ReplicationState left, Azure.ResourceManager.Compute.Models.ReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ReplicationState left, Azure.ResourceManager.Compute.Models.ReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReplicationStatus
    {
        internal ReplicationStatus() { }
        public Azure.ResourceManager.Compute.Models.AggregatedReplicationState? AggregatedState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.RegionalReplicationStatus> Summary { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationStatusTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.ReplicationStatusTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationStatusTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ReplicationStatusTypes ReplicationStatus { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes left, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ReplicationStatusTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes left, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestRateByIntervalContent : Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase
    {
        public RequestRateByIntervalContent(System.Uri blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, Azure.ResourceManager.Compute.Models.IntervalInMins intervalLength) : base (default(System.Uri), default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
        public Azure.ResourceManager.Compute.Models.IntervalInMins IntervalLength { get { throw null; } }
    }
    public partial class ResourceInstanceViewStatus
    {
        internal ResourceInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.StatusLevelTypes? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class ResourceRange
    {
        public ResourceRange() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
    }
    public partial class ResourceSkuCapabilities
    {
        internal ResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public enum ResourceSkuCapacityScaleType
    {
        None = 0,
        Automatic = 1,
        Manual = 2,
    }
    public partial class ResourceSkuCosts
    {
        internal ResourceSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public long? Quantity { get { throw null; } }
    }
    public partial class ResourceSkuRestrictionInfo
    {
        internal ResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuRestrictions
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.Compute.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public enum ResourceSkuRestrictionsReasonCode
    {
        QuotaId = 0,
        NotAvailableForSubscription = 1,
    }
    public enum ResourceSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    public partial class ResourceSkuZoneDetails
    {
        internal ResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestorePointCollectionExpandOptions : System.IEquatable<Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestorePointCollectionExpandOptions(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions RestorePoints { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions left, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions left, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestorePointCollectionSource
    {
        public RestorePointCollectionSource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    public partial class RestorePointGroupPatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public RestorePointGroupPatch() { }
        public string ProvisioningState { get { throw null; } }
        public string RestorePointGroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.RestorePointData> RestorePoints { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointCollectionSource Source { get { throw null; } set { } }
    }
    public partial class RestorePointSourceMetadata
    {
        internal RestorePointSourceMetadata() { }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OSProfile OSProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile StorageProfile { get { throw null; } }
        public string VmId { get { throw null; } }
    }
    public partial class RestorePointSourceVmDataDisk
    {
        internal RestorePointSourceVmDataDisk() { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiskRestorePointId { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } }
        public int? Lun { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ManagedDiskParameters ManagedDisk { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class RestorePointSourceVmOSDisk
    {
        internal RestorePointSourceVmOSDisk() { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiskRestorePointId { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskEncryptionSettings EncryptionSettings { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ManagedDiskParameters ManagedDisk { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemType? OSType { get { throw null; } }
    }
    public partial class RestorePointSourceVmStorageProfile
    {
        internal RestorePointSourceVmStorageProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk OSDisk { get { throw null; } }
    }
    public partial class RetrieveBootDiagnosticsDataResult
    {
        internal RetrieveBootDiagnosticsDataResult() { }
        public System.Uri ConsoleScreenshotBlobUri { get { throw null; } }
        public System.Uri SerialConsoleLogBlobUri { get { throw null; } }
    }
    public partial class RoleInstances
    {
        public RoleInstances(System.Collections.Generic.IEnumerable<string> roleInstancesValue) { }
        public System.Collections.Generic.IList<string> RoleInstancesValue { get { throw null; } }
    }
    public partial class RoleInstanceView
    {
        internal RoleInstanceView() { }
        public int? PlatformFaultDomain { get { throw null; } }
        public int? PlatformUpdateDomain { get { throw null; } }
        public string PrivateId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceInstanceViewStatus> Statuses { get { throw null; } }
    }
    public partial class RollbackStatusInfo
    {
        internal RollbackStatusInfo() { }
        public int? FailedRolledbackInstanceCount { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ApiError RollbackError { get { throw null; } }
        public int? SuccessfullyRolledbackInstanceCount { get { throw null; } }
    }
    public enum RollingUpgradeActionType
    {
        Start = 0,
        Cancel = 1,
    }
    public partial class RollingUpgradePolicy
    {
        public RollingUpgradePolicy() { }
        public bool? EnableCrossZoneUpgrade { get { throw null; } set { } }
        public int? MaxBatchInstancePercent { get { throw null; } set { } }
        public int? MaxUnhealthyInstancePercent { get { throw null; } set { } }
        public int? MaxUnhealthyUpgradedInstancePercent { get { throw null; } set { } }
        public string PauseTimeBetweenBatches { get { throw null; } set { } }
        public bool? PrioritizeUnhealthyInstances { get { throw null; } set { } }
    }
    public partial class RollingUpgradeProgressInfo
    {
        internal RollingUpgradeProgressInfo() { }
        public int? FailedInstanceCount { get { throw null; } }
        public int? InProgressInstanceCount { get { throw null; } }
        public int? PendingInstanceCount { get { throw null; } }
        public int? SuccessfulInstanceCount { get { throw null; } }
    }
    public partial class RollingUpgradeRunningStatus
    {
        internal RollingUpgradeRunningStatus() { }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeStatusCode? Code { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeActionType? LastAction { get { throw null; } }
        public System.DateTimeOffset? LastActionOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public enum RollingUpgradeStatusCode
    {
        RollingForward = 0,
        Cancelled = 1,
        Completed = 2,
        Faulted = 3,
    }
    public partial class RunCommandDocument : Azure.ResourceManager.Compute.Models.RunCommandDocumentBase
    {
        internal RunCommandDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition> Parameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Script { get { throw null; } }
    }
    public partial class RunCommandDocumentBase
    {
        internal RunCommandDocumentBase() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Label { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes OSType { get { throw null; } }
        public string Schema { get { throw null; } }
    }
    public partial class RunCommandInput
    {
        public RunCommandInput(string commandId) { }
        public string CommandId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<string> Script { get { throw null; } }
    }
    public partial class RunCommandInputParameter
    {
        public RunCommandInputParameter(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class RunCommandParameterDefinition
    {
        internal RunCommandParameterDefinition() { }
        public string DefaultValue { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? Required { get { throw null; } }
        public string RunCommandParameterDefinitionType { get { throw null; } }
    }
    public partial class RunCommandResult
    {
        internal RunCommandResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Value { get { throw null; } }
    }
    public partial class ScaleInPolicy
    {
        public ScaleInPolicy() { }
        public bool? ForceDeletion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules> Rules { get { throw null; } }
    }
    public partial class SecurityProfile
    {
        public SecurityProfile() { }
        public bool? EncryptionAtHost { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityTypes? SecurityType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UefiSettings UefiSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.SecurityTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SecurityTypes TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.SecurityTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.SecurityTypes left, Azure.ResourceManager.Compute.Models.SecurityTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.SecurityTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.SecurityTypes left, Azure.ResourceManager.Compute.Models.SecurityTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelectPermissions : System.IEquatable<Azure.ResourceManager.Compute.Models.SelectPermissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelectPermissions(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SelectPermissions Permissions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.SelectPermissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.SelectPermissions left, Azure.ResourceManager.Compute.Models.SelectPermissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.SelectPermissions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.SelectPermissions left, Azure.ResourceManager.Compute.Models.SelectPermissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SettingNames
    {
        AutoLogon = 0,
        FirstLogonCommands = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharedToValues : System.IEquatable<Azure.ResourceManager.Compute.Models.SharedToValues>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharedToValues(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SharedToValues Tenant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.SharedToValues other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.SharedToValues left, Azure.ResourceManager.Compute.Models.SharedToValues right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.SharedToValues (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.SharedToValues left, Azure.ResourceManager.Compute.Models.SharedToValues right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareInfoElement
    {
        internal ShareInfoElement() { }
        public System.Uri VmUri { get { throw null; } }
    }
    public partial class SharingProfile
    {
        public SharingProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.SharingProfileGroup> Groups { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GallerySharingPermissionTypes? Permissions { get { throw null; } set { } }
    }
    public partial class SharingProfileGroup
    {
        public SharingProfileGroup() { }
        public Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes? GroupType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharingProfileGroupTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharingProfileGroupTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes AADTenants { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes Subscriptions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes left, Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes left, Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharingUpdate
    {
        public SharingUpdate(Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes operationType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SharingProfileGroup> Groups { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes OperationType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharingUpdateOperationTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharingUpdateOperationTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes Add { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes Remove { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes Reset { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes left, Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes left, Azure.ResourceManager.Compute.Models.SharingUpdateOperationTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SnapshotPatch
    {
        public SnapshotPatch() { }
        public bool? AcceleratedNetwork { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskAccessId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingGroup EncryptionSettingGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SnapshotSku Sku { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SnapshotSku
    {
        public SnapshotSku() { }
        public Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes? Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SnapshotStorageAccountTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SnapshotStorageAccountTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes StandardZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes left, Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes left, Azure.ResourceManager.Compute.Models.SnapshotStorageAccountTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpotRestorePolicy
    {
        public SpotRestorePolicy() { }
        public bool? Enabled { get { throw null; } set { } }
        public string RestoreTimeout { get { throw null; } set { } }
    }
    public partial class SshPublicKeyGenerateKeyPairResult
    {
        internal SshPublicKeyGenerateKeyPairResult() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
    }
    public partial class SshPublicKeyInfo
    {
        public SshPublicKeyInfo() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class SshPublicKeyPatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public SshPublicKeyPatch() { }
        public string PublicKey { get { throw null; } set { } }
    }
    public partial class StatusCodeCount
    {
        internal StatusCodeCount() { }
        public string Code { get { throw null; } }
        public int? Count { get { throw null; } }
    }
    public enum StatusLevelTypes
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.Compute.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType StandardZRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.StorageAccountType left, Azure.ResourceManager.Compute.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.StorageAccountType left, Azure.ResourceManager.Compute.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.StorageAccountTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes PremiumZRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes StandardSsdLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes StandardSsdZRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes UltraSsdLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.StorageAccountTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.StorageAccountTypes left, Azure.ResourceManager.Compute.Models.StorageAccountTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.StorageAccountTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.StorageAccountTypes left, Azure.ResourceManager.Compute.Models.StorageAccountTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageProfile
    {
        public StorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSDisk OSDisk { get { throw null; } set { } }
    }
    public partial class TargetRegion
    {
        public TargetRegion(string name) { }
        public Azure.ResourceManager.Compute.Models.EncryptionImages Encryption { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? RegionalReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
    }
    public partial class TerminateNotificationProfile
    {
        public TerminateNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
    }
    public partial class ThrottledRequestsContent : Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase
    {
        public ThrottledRequestsContent(System.Uri blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime) : base (default(System.Uri), default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
    }
    public partial class UefiSettings
    {
        public UefiSettings() { }
        public bool? SecureBootEnabled { get { throw null; } set { } }
        public bool? VTpmEnabled { get { throw null; } set { } }
    }
    public partial class UpdateDomainIdentifier
    {
        public UpdateDomainIdentifier() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public enum UpgradeMode
    {
        Automatic = 0,
        Manual = 1,
        Rolling = 2,
    }
    public partial class UpgradeOperationHistoricalStatusInfo
    {
        internal UpgradeOperationHistoricalStatusInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties Properties { get { throw null; } }
        public string UpgradeOperationHistoricalStatusInfoType { get { throw null; } }
    }
    public partial class UpgradeOperationHistoricalStatusInfoProperties
    {
        internal UpgradeOperationHistoricalStatusInfoProperties() { }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo Progress { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollbackStatusInfo RollbackInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus RunningStatus { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradeOperationInvoker? StartedBy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImageReference TargetImageReference { get { throw null; } }
    }
    public partial class UpgradeOperationHistoryStatus
    {
        internal UpgradeOperationHistoryStatus() { }
        public Azure.ResourceManager.Compute.Models.UpgradeState? Code { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public enum UpgradeOperationInvoker
    {
        Unknown = 0,
        User = 1,
        Platform = 2,
    }
    public partial class UpgradePolicy
    {
        public UpgradePolicy() { }
        public Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy AutomaticOSUpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UpgradeMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradePolicy RollingUpgradePolicy { get { throw null; } set { } }
    }
    public enum UpgradeState
    {
        RollingForward = 0,
        Cancelled = 1,
        Completed = 2,
        Faulted = 3,
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class UserArtifactManage
    {
        public UserArtifactManage(string install, string remove) { }
        public string Install { get { throw null; } set { } }
        public string Remove { get { throw null; } set { } }
        public string Update { get { throw null; } set { } }
    }
    public partial class UserArtifactSource
    {
        public UserArtifactSource(string mediaLink) { }
        public string DefaultConfigurationLink { get { throw null; } set { } }
        public string MediaLink { get { throw null; } set { } }
    }
    public partial class VaultCertificate
    {
        public VaultCertificate() { }
        public string CertificateStore { get { throw null; } set { } }
        public System.Uri CertificateUri { get { throw null; } set { } }
    }
    public partial class VaultSecretGroup
    {
        public VaultSecretGroup() { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultCertificate> VaultCertificates { get { throw null; } }
    }
    public partial class VirtualMachineAgentInstanceView
    {
        internal VirtualMachineAgentInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView> ExtensionHandlers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public string VmAgentVersion { get { throw null; } }
    }
    public partial class VirtualMachineAssessPatchesResult
    {
        internal VirtualMachineAssessPatchesResult() { }
        public string AssessmentActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties> AvailablePatches { get { throw null; } }
        public int? CriticalAndSecurityPatchCount { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public int? OtherPatchCount { get { throw null; } }
        public bool? RebootPending { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchOperationStatus? Status { get { throw null; } }
    }
    public partial class VirtualMachineCaptureContent
    {
        public VirtualMachineCaptureContent(string vhdPrefix, string destinationContainerName, bool overwriteVhds) { }
        public string DestinationContainerName { get { throw null; } }
        public bool OverwriteVhds { get { throw null; } }
        public string VhdPrefix { get { throw null; } }
    }
    public partial class VirtualMachineCaptureResult : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData
    {
        public VirtualMachineCaptureResult() { }
        public string ContentVersion { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> Resources { get { throw null; } }
        public string Schema { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineEvictionPolicyTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineEvictionPolicyTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes left, Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes left, Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineExtensionHandlerInstanceView
    {
        internal VirtualMachineExtensionHandlerInstanceView() { }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus Status { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        public string VirtualMachineExtensionHandlerInstanceViewType { get { throw null; } }
    }
    public partial class VirtualMachineExtensionInstanceView
    {
        public VirtualMachineExtensionInstanceView() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Substatuses { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string VirtualMachineExtensionInstanceViewType { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionPatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public VirtualMachineExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineImage : Azure.ResourceManager.Compute.Models.VirtualMachineImageBase
    {
        public VirtualMachineImage(string name, Azure.Core.AzureLocation location) : base (default(string), default(Azure.Core.AzureLocation)) { }
        public bool? AutomaticOSUpgradeSupported { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDiskImage> DataDiskImages { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VmDiskTypes? DisallowedVmDiskType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationTypes? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSDiskImageOperatingSystem { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PurchasePlan Plan { get { throw null; } set { } }
    }
    public partial class VirtualMachineImageBase : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData
    {
        public VirtualMachineImageBase(string name, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VirtualMachineImageFeature
    {
        public VirtualMachineImageFeature() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class VirtualMachineInstallPatchesContent
    {
        public VirtualMachineInstallPatchesContent(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting rebootSetting) { }
        public Azure.ResourceManager.Compute.Models.LinuxParameters LinuxParameters { get { throw null; } set { } }
        public System.TimeSpan? MaximumDuration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting RebootSetting { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.WindowsParameters WindowsParameters { get { throw null; } set { } }
    }
    public partial class VirtualMachineInstallPatchesResult
    {
        internal VirtualMachineInstallPatchesResult() { }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public int? ExcludedPatchCount { get { throw null; } }
        public int? FailedPatchCount { get { throw null; } }
        public string InstallationActivityId { get { throw null; } }
        public int? InstalledPatchCount { get { throw null; } }
        public bool? MaintenanceWindowExceeded { get { throw null; } }
        public int? NotSelectedPatchCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.PatchInstallationDetail> Patches { get { throw null; } }
        public int? PendingPatchCount { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus? RebootStatus { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchOperationStatus? Status { get { throw null; } }
    }
    public partial class VirtualMachineInstanceView
    {
        internal VirtualMachineInstanceView() { }
        public string AssignedHost { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView BootDiagnostics { get { throw null; } }
        public string ComputerName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DiskInstanceView> Disks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView> Extensions { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationType? HyperVGeneration { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus MaintenanceRedeployStatus { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus PatchStatus { get { throw null; } }
        public int? PlatformFaultDomain { get { throw null; } }
        public int? PlatformUpdateDomain { get { throw null; } }
        public string RdpThumbPrint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView VmAgent { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus VmHealthStatus { get { throw null; } }
    }
    public partial class VirtualMachineIPTag
    {
        public VirtualMachineIPTag() { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class VirtualMachineNetworkInterfaceConfiguration
    {
        public VirtualMachineNetworkInterfaceConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.Core.ResourceIdentifier DscpConfigurationId { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration> IPConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class VirtualMachineNetworkInterfaceIPConfiguration
    {
        public VirtualMachineNetworkInterfaceIPConfiguration(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class VirtualMachinePatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public VirtualMachinePatch() { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AvailabilitySetId { get { throw null; } set { } }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes? EvictionPolicy { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VmGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePlan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.TerminateNotificationProfile ScheduledEventsTerminateNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineScaleSetId { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class VirtualMachinePatchStatus
    {
        internal VirtualMachinePatchStatus() { }
        public Azure.ResourceManager.Compute.Models.AvailablePatchSummary AvailablePatchSummary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> ConfigurationStatuses { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary LastPatchInstallationSummary { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePriorityTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePriorityTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes Low { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes Regular { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes left, Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes left, Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressConfiguration
    {
        public VirtualMachinePublicIPAddressConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public string DnsDomainNameLabel { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineIPTag> IPTags { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod? PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PublicIPAddressSku Sku { get { throw null; } set { } }
    }
    public partial class VirtualMachineReimageContent
    {
        public VirtualMachineReimageContent() { }
        public bool? TempDisk { get { throw null; } set { } }
    }
    public partial class VirtualMachineRunCommandInstanceView
    {
        internal VirtualMachineRunCommandInstanceView() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Error { get { throw null; } }
        public string ExecutionMessage { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ExecutionState? ExecutionState { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public string Output { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
    }
    public partial class VirtualMachineRunCommandScriptSource
    {
        public VirtualMachineRunCommandScriptSource() { }
        public string CommandId { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Uri ScriptUri { get { throw null; } set { } }
    }
    public partial class VirtualMachineRunCommandUpdate : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public VirtualMachineRunCommandUpdate() { }
        public bool? AsyncExecution { get { throw null; } set { } }
        public System.Uri ErrorBlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView InstanceView { get { throw null; } }
        public System.Uri OutputBlobUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> ProtectedParameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string RunAsPassword { get { throw null; } set { } }
        public string RunAsUser { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource Source { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetDataDisk
    {
        public VirtualMachineScaleSetDataDisk(int lun, Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes CreateOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetExtensionPatch : Azure.ResourceManager.Compute.Models.ComputeSubResourceData
    {
        public VirtualMachineScaleSetExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetExtensionProfile
    {
        public VirtualMachineScaleSetExtensionProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData> Extensions { get { throw null; } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetInstanceView
    {
        internal VirtualMachineScaleSetInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary> Extensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary> OrchestrationServices { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount> VirtualMachineStatusesSummary { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetIPConfiguration : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData
    {
        public VirtualMachineScaleSetIPConfiguration(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerInboundNatPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetIPTag
    {
        public VirtualMachineScaleSetIPTag() { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetManagedDiskParameters
    {
        public VirtualMachineScaleSetManagedDiskParameters() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkConfiguration : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData
    {
        public VirtualMachineScaleSetNetworkConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration> IPConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkProfile
    {
        public VirtualMachineScaleSetNetworkProfile() { }
        public Azure.Core.ResourceIdentifier HealthProbeId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetOSDisk
    {
        public VirtualMachineScaleSetOSDisk(Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionTypes CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetOSProfile
    {
        public VirtualMachineScaleSetOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public string ComputerNamePrefix { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetPatch : Azure.ResourceManager.Compute.Models.ComputeUpdateResourceData
    {
        public VirtualMachineScaleSetPatch() { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public bool? DoNotRunExtensionsOnOverprovisionedVms { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? Overprovision { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePlan Plan { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public bool? SinglePlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile VirtualMachineProfile { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration
    {
        public VirtualMachineScaleSetPublicIPAddressConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public string DnsDomainNameLabel { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag> IPTags { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PublicIPAddressSku Sku { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetReimageContent : Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent
    {
        public VirtualMachineScaleSetReimageContent() { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineScaleSetScaleInRules : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineScaleSetScaleInRules(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules Default { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules NewestVm { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules OldestVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules left, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules left, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRules right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineScaleSetSku
    {
        internal VirtualMachineScaleSetSku() { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetSkuCapacity
    {
        internal VirtualMachineScaleSetSkuCapacity() { }
        public long? DefaultCapacity { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuScaleType? ScaleType { get { throw null; } }
    }
    public enum VirtualMachineScaleSetSkuScaleType
    {
        None = 0,
        Automatic = 1,
    }
    public partial class VirtualMachineScaleSetStorageProfile
    {
        public VirtualMachineScaleSetStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk OSDisk { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateIPConfiguration : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData
    {
        public VirtualMachineScaleSetUpdateIPConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerInboundNatPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateNetworkConfiguration : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData
    {
        public VirtualMachineScaleSetUpdateNetworkConfiguration() { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration> IPConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateNetworkProfile
    {
        public VirtualMachineScaleSetUpdateNetworkProfile() { }
        public Azure.Core.ResourceIdentifier HealthProbeId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetUpdateOSDisk
    {
        public VirtualMachineScaleSetUpdateOSDisk() { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateOSProfile
    {
        public VirtualMachineScaleSetUpdateOSProfile() { }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdatePublicIPAddressConfiguration
    {
        public VirtualMachineScaleSetUpdatePublicIPAddressConfiguration() { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public string DnsDomainNameLabel { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateStorageProfile
    {
        public VirtualMachineScaleSetUpdateStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk OSDisk { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateVmProfile
    {
        public VirtualMachineScaleSetUpdateVmProfile() { }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.TerminateNotificationProfile ScheduledEventsTerminateNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVmExtensionPatch : Azure.ResourceManager.Compute.Models.ComputeSubResourceData
    {
        public VirtualMachineScaleSetVmExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVmExtensionsSummary
    {
        internal VirtualMachineScaleSetVmExtensionsSummary() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount> StatusesSummary { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVmInstanceIds
    {
        public VirtualMachineScaleSetVmInstanceIds() { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVmInstanceRequiredIds
    {
        public VirtualMachineScaleSetVmInstanceRequiredIds(System.Collections.Generic.IEnumerable<string> instanceIds) { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVmInstanceView
    {
        internal VirtualMachineScaleSetVmInstanceView() { }
        public string AssignedHost { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView BootDiagnostics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DiskInstanceView> Disks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView> Extensions { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus MaintenanceRedeployStatus { get { throw null; } }
        public string PlacementGroupId { get { throw null; } }
        public int? PlatformFaultDomain { get { throw null; } }
        public int? PlatformUpdateDomain { get { throw null; } }
        public string RdpThumbPrint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView VmAgent { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus VmHealthStatus { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVmProfile
    {
        public VirtualMachineScaleSetVmProfile() { }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VmGalleryApplication> GalleryApplications { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.TerminateNotificationProfile ScheduledEventsTerminateNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVmProtectionPolicy
    {
        public VirtualMachineScaleSetVmProtectionPolicy() { }
        public bool? ProtectFromScaleIn { get { throw null; } set { } }
        public bool? ProtectFromScaleSetActions { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVmReimageContent : Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent
    {
        public VirtualMachineScaleSetVmReimageContent() { }
    }
    public partial class VirtualMachineSize
    {
        internal VirtualMachineSize() { }
        public int? MaxDataDiskCount { get { throw null; } }
        public int? MemoryInMB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public int? OSDiskSizeInMB { get { throw null; } }
        public int? ResourceDiskSizeInMB { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineSizeTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineSizeTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes BasicA0 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes BasicA1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes BasicA2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes BasicA3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes BasicA4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA0 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA10 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA1V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA2MV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA4MV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA6 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA7 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA8MV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA8V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardA9 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB1Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB1S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB2Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB2S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB4Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardB8Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD13 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD14 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD15V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD16V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD1V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD2V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD2V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD32V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD3V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD4V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD4V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD5V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD64V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardD8V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS11V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS12V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS13 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS132V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS134V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS14 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS144V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS148V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS14V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS15V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS1V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE16V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE2V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE3216V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE328SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE32V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE4V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE6416SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE6432SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE64V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardE8V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF16 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF16S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF1S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF2S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF2SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF32SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF4S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF4SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF72SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF8S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardF8SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardG1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardG2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardG3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardG4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardG5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS44 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS48 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS516 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardGS58 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH16 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH16M { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH16Mr { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH16R { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardH8M { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardL16S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardL32S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardL4S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardL8S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM12832Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM12864Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM128Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM128S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM6416Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM6432Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM64Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardM64S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC12SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC12SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24R { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24RsV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24RsV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC24SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC6 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC6SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNC6SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardND12S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardND24Rs { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardND24S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardND6S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNV12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNV24 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes StandardNV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes left, Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes left, Azure.ResourceManager.Compute.Models.VirtualMachineSizeTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineSoftwarePatchProperties
    {
        internal VirtualMachineSoftwarePatchProperties() { }
        public string ActivityId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchAssessmentState? AssessmentState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Classifications { get { throw null; } }
        public string KbId { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string PatchId { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior? RebootBehavior { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class VirtualMachineStatusCodeCount
    {
        internal VirtualMachineStatusCodeCount() { }
        public string Code { get { throw null; } }
        public int? Count { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmDiskTypes : System.IEquatable<Azure.ResourceManager.Compute.Models.VmDiskTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmDiskTypes(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VmDiskTypes None { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmDiskTypes Unmanaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VmDiskTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VmDiskTypes left, Azure.ResourceManager.Compute.Models.VmDiskTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VmDiskTypes (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VmDiskTypes left, Azure.ResourceManager.Compute.Models.VmDiskTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmGalleryApplication
    {
        public VmGalleryApplication(string packageReferenceId) { }
        public string ConfigurationReference { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public string PackageReferenceId { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchClassificationLinux : System.IEquatable<Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchClassificationLinux(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux Critical { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux Other { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux Security { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux left, Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux left, Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationLinux right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchClassificationWindows : System.IEquatable<Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchClassificationWindows(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows Critical { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows Definition { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows FeaturePack { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows Security { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows ServicePack { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows Tools { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows UpdateRollUp { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows Updates { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows left, Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows left, Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchRebootBehavior : System.IEquatable<Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchRebootBehavior(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior AlwaysRequiresReboot { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior CanRequestReboot { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior NeverReboots { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior left, Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior left, Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchRebootSetting : System.IEquatable<Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting left, Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting left, Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchRebootStatus : System.IEquatable<Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchRebootStatus(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus NotNeeded { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus Required { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus Started { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus left, Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus left, Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmScaleSetConvertToSinglePlacementGroupContent
    {
        public VmScaleSetConvertToSinglePlacementGroupContent() { }
        public string ActivePlacementGroupId { get { throw null; } set { } }
    }
    public partial class VmSizeProperties
    {
        public VmSizeProperties() { }
        public int? VCPUsAvailable { get { throw null; } set { } }
        public int? VCPUsPerCore { get { throw null; } set { } }
    }
    public partial class WindowsConfiguration
    {
        public WindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.WinRMListener> WinRMListeners { get { throw null; } }
    }
    public partial class WindowsParameters
    {
        public WindowsParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows> ClassificationsToInclude { get { throw null; } }
        public bool? ExcludeKbsRequiringReboot { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KbNumbersToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> KbNumbersToInclude { get { throw null; } }
        public System.DateTimeOffset? MaxPatchPublishOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode AutomaticByOS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode left, Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode left, Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WinRMListener
    {
        public WinRMListener() { }
        public System.Uri CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ProtocolTypes? Protocol { get { throw null; } set { } }
    }
}
