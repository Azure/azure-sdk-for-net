namespace Azure.ResourceManager.Compute
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.Compute.AvailabilitySet GetAvailabilitySet(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservation GetCapacityReservation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservationGroup GetCapacityReservationGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.CloudService GetCloudService(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.CloudServiceRole GetCloudServiceRole(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHost GetDedicatedHost(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHostGroup GetDedicatedHostGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Disk GetDisk(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.DiskAccess GetDiskAccess(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.DiskEncryptionSet GetDiskEncryptionSet(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.DiskRestorePoint GetDiskRestorePoint(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Gallery GetGallery(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryApplication GetGalleryApplication(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryApplicationVersion GetGalleryApplicationVersion(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryImage GetGalleryImage(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryImageVersion GetGalleryImageVersion(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Image GetImage(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.OSFamily GetOSFamily(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.OSVersion GetOSVersion(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.ProximityPlacementGroup GetProximityPlacementGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePoint GetRestorePoint(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePointGroup GetRestorePointGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.RoleInstance GetRoleInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.SharedGallery GetSharedGallery(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.SharedGalleryImage GetSharedGalleryImage(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.SharedGalleryImageVersion GetSharedGalleryImageVersion(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.Snapshot GetSnapshot(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.SshPublicKey GetSshPublicKey(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachine GetVirtualMachine(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineExtension GetVirtualMachineExtension(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineExtensionImage GetVirtualMachineExtensionImage(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineRunCommand GetVirtualMachineRunCommand(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSet GetVirtualMachineScaleSet(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension GetVirtualMachineScaleSetExtension(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgrade GetVirtualMachineScaleSetRollingUpgrade(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand GetVirtualMachineScaleSetVirtualMachineRunCommand(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetVm GetVirtualMachineScaleSetVm(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension GetVirtualMachineScaleSetVmExtension(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class AvailabilitySet : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvailabilitySet() { }
        public virtual Azure.ResourceManager.Compute.AvailabilitySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string availabilitySetName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.AvailabilitySetDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.AvailabilitySetDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetAvailableSizes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetAvailableSizesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet> Update(Azure.ResourceManager.Compute.Models.AvailabilitySetUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet>> UpdateAsync(Azure.ResourceManager.Compute.Models.AvailabilitySetUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvailabilitySetCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.AvailabilitySet>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.AvailabilitySet>, System.Collections.IEnumerable
    {
        protected AvailabilitySetCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.AvailabilitySetCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string availabilitySetName, Azure.ResourceManager.Compute.AvailabilitySetData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.AvailabilitySetCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string availabilitySetName, Azure.ResourceManager.Compute.AvailabilitySetData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet> Get(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.AvailabilitySet> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.AvailabilitySet> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet>> GetAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet> GetIfExists(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet>> GetIfExistsAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.AvailabilitySet> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.AvailabilitySet>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.AvailabilitySet> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.AvailabilitySet>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvailabilitySetData : Azure.ResourceManager.Models.TrackedResource
    {
        public AvailabilitySetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public int? PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualMachines { get { throw null; } }
    }
    public partial class CapacityReservation : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapacityReservation() { }
        public virtual Azure.ResourceManager.Compute.CapacityReservationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservation> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservation>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string capacityReservationGroupName, string capacityReservationName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CapacityReservationDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CapacityReservationDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservation> Get(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservation>> GetAsync(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservation> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservation>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservation> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservation>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CapacityReservationUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.CapacityReservationUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CapacityReservationUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.CapacityReservationUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservation>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservation>, System.Collections.IEnumerable
    {
        protected CapacityReservationCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.CapacityReservationCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string capacityReservationName, Azure.ResourceManager.Compute.CapacityReservationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CapacityReservationCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string capacityReservationName, Azure.ResourceManager.Compute.CapacityReservationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservation> Get(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CapacityReservation> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CapacityReservation> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservation>> GetAsync(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservation> GetIfExists(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservation>> GetIfExistsAsync(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CapacityReservation> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservation>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CapacityReservation> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservation>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapacityReservationData : Azure.ResourceManager.Models.TrackedResource
    {
        public CapacityReservationData(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.Sku sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView InstanceView { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningTime { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class CapacityReservationGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapacityReservationGroup() { }
        public virtual Azure.ResourceManager.Compute.CapacityReservationGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string capacityReservationGroupName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CapacityReservationGroupDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CapacityReservationGroupDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup> Get(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup>> GetAsync(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.CapacityReservationCollection GetCapacityReservations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup> Update(Azure.ResourceManager.Compute.Models.CapacityReservationGroupUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup>> UpdateAsync(Azure.ResourceManager.Compute.Models.CapacityReservationGroupUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroup>, System.Collections.IEnumerable
    {
        protected CapacityReservationGroupCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.CapacityReservationGroupCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string capacityReservationGroupName, Azure.ResourceManager.Compute.CapacityReservationGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CapacityReservationGroupCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string capacityReservationGroupName, Azure.ResourceManager.Compute.CapacityReservationGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup> Get(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CapacityReservationGroup> GetAll(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CapacityReservationGroup> GetAllAsync(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup>> GetAsync(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup> GetIfExists(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup>> GetIfExistsAsync(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CapacityReservationGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CapacityReservationGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapacityReservationGroupData : Azure.ResourceManager.Models.TrackedResource
    {
        public CapacityReservationGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> CapacityReservations { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView InstanceView { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class CloudService : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudService() { }
        public virtual Azure.ResourceManager.Compute.CloudServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudService> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudService>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServiceName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CloudServiceDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CloudServiceDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CloudServiceDeleteInstancesOperation DeleteInstances(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RoleInstances parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CloudServiceDeleteInstancesOperation> DeleteInstancesAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RoleInstances parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudService> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudService>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.CloudServiceRoleCollection GetCloudServiceRoles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.CloudServiceInstanceView> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.CloudServiceInstanceView>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.RoleInstanceCollection GetRoleInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.UpdateDomain> GetUpdateDomain(int updateDomain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.UpdateDomain>> GetUpdateDomainAsync(int updateDomain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.UpdateDomain> GetUpdateDomains(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.UpdateDomain> GetUpdateDomainsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CloudServicePowerOffOperation PowerOff(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CloudServicePowerOffOperation> PowerOffAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CloudServicePowerOnOperation PowerOn(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CloudServicePowerOnOperation> PowerOnAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CloudServiceRebuildOperation Rebuild(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RoleInstances parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CloudServiceRebuildOperation> RebuildAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RoleInstances parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CloudServiceReimageOperation Reimage(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RoleInstances parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CloudServiceReimageOperation> ReimageAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RoleInstances parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudService> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudService>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CloudServiceRestartOperation Restart(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RoleInstances parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CloudServiceRestartOperation> RestartAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RoleInstances parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudService> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudService>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CloudServiceUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.CloudServiceUpdate parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CloudServiceUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.CloudServiceUpdate parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.CloudServiceWalkUpdateDomainOperation WalkUpdateDomain(bool waitForCompletion, int updateDomain, Azure.ResourceManager.Compute.Models.UpdateDomain parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CloudServiceWalkUpdateDomainOperation> WalkUpdateDomainAsync(bool waitForCompletion, int updateDomain, Azure.ResourceManager.Compute.Models.UpdateDomain parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudService>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudService>, System.Collections.IEnumerable
    {
        protected CloudServiceCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.CloudServiceCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string cloudServiceName, Azure.ResourceManager.Compute.CloudServiceData parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.CloudServiceCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string cloudServiceName, Azure.ResourceManager.Compute.CloudServiceData parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudService> Get(string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CloudService> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CloudService> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudService>> GetAsync(string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudService> GetIfExists(string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudService>> GetIfExistsAsync(string cloudServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CloudService> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudService>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CloudService> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudService>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudServiceData : Azure.ResourceManager.Models.TrackedResource
    {
        public CloudServiceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.CloudServiceProperties Properties { get { throw null; } set { } }
    }
    public partial class CloudServiceRole : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudServiceRole() { }
        public virtual Azure.ResourceManager.Compute.CloudServiceRoleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServiceName, string roleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRole> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRole>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceRoleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceRole>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceRole>, System.Collections.IEnumerable
    {
        protected CloudServiceRoleCollection() { }
        public virtual Azure.Response<bool> Exists(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRole> Get(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CloudServiceRole> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CloudServiceRole> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRole>> GetAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CloudServiceRole> GetIfExists(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CloudServiceRole>> GetIfExistsAsync(string roleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CloudServiceRole> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CloudServiceRole>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CloudServiceRole> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CloudServiceRole>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudServiceRoleData : Azure.ResourceManager.Models.Resource
    {
        internal CloudServiceRoleData() { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CloudServiceRoleProperties Properties { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CloudServiceRoleSku Sku { get { throw null; } }
    }
    public partial class DedicatedHost : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedHost() { }
        public virtual Azure.ResourceManager.Compute.DedicatedHostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHost> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHost>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostGroupName, string hostName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DedicatedHostDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DedicatedHostDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHost> Get(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHost>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHost> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHost>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHost> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHost>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DedicatedHostUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.DedicatedHostUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DedicatedHostUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.DedicatedHostUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHost>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHost>, System.Collections.IEnumerable
    {
        protected DedicatedHostCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.DedicatedHostCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string hostName, Azure.ResourceManager.Compute.DedicatedHostData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DedicatedHostCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string hostName, Azure.ResourceManager.Compute.DedicatedHostData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHost> Get(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DedicatedHost> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DedicatedHost> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHost>> GetAsync(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHost> GetIfExists(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHost>> GetIfExistsAsync(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DedicatedHost> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHost>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DedicatedHost> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHost>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHostData : Azure.ResourceManager.Models.TrackedResource
    {
        public DedicatedHostData(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.Sku sku) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AutoReplaceOnFailure { get { throw null; } set { } }
        public string HostId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostLicenseTypes? LicenseType { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningTime { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachines { get { throw null; } }
    }
    public partial class DedicatedHostGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedHostGroup() { }
        public virtual Azure.ResourceManager.Compute.DedicatedHostGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostGroupName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DedicatedHostGroupDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DedicatedHostGroupDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup> Get(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostCollection GetDedicatedHosts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup> Update(Azure.ResourceManager.Compute.Models.DedicatedHostGroupUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup>> UpdateAsync(Azure.ResourceManager.Compute.Models.DedicatedHostGroupUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroup>, System.Collections.IEnumerable
    {
        protected DedicatedHostGroupCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.DedicatedHostGroupCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string hostGroupName, Azure.ResourceManager.Compute.DedicatedHostGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DedicatedHostGroupCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string hostGroupName, Azure.ResourceManager.Compute.DedicatedHostGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup> Get(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DedicatedHostGroup> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DedicatedHostGroup> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup>> GetAsync(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup> GetIfExists(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup>> GetIfExistsAsync(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DedicatedHostGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DedicatedHostGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHostGroupData : Azure.ResourceManager.Models.TrackedResource
    {
        public DedicatedHostGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Hosts { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostGroupInstanceView InstanceView { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public bool? SupportAutomaticPlacement { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class Disk : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected Disk() { }
        public virtual Azure.ResourceManager.Compute.DiskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Disk> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Disk>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DiskDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Disk> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Disk>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DiskGrantAccessOperation GrantAccess(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GrantAccessData grantAccessData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskGrantAccessOperation> GrantAccessAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GrantAccessData grantAccessData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Disk> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Disk>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DiskRevokeAccessOperation RevokeAccess(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskRevokeAccessOperation> RevokeAccessAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Disk> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Disk>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DiskUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.DiskUpdate disk, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.DiskUpdate disk, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskAccess : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskAccess() { }
        public virtual Azure.ResourceManager.Compute.DiskAccessData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccess> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccess>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskAccessName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DiskAccessDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskAccessDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccess> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccess>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.PrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.PrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccess> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccess>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccess> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccess>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DiskAccessUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.DiskAccessUpdate diskAccess, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskAccessUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.DiskAccessUpdate diskAccess, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskAccessCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskAccess>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskAccess>, System.Collections.IEnumerable
    {
        protected DiskAccessCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.DiskAccessCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string diskAccessName, Azure.ResourceManager.Compute.DiskAccessData diskAccess, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskAccessCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string diskAccessName, Azure.ResourceManager.Compute.DiskAccessData diskAccess, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccess> Get(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DiskAccess> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskAccess> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccess>> GetAsync(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskAccess> GetIfExists(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskAccess>> GetIfExistsAsync(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DiskAccess> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskAccess>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DiskAccess> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskAccess>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskAccessData : Azure.ResourceManager.Models.TrackedResource
    {
        public DiskAccessData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
    }
    public partial class DiskCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Disk>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Disk>, System.Collections.IEnumerable
    {
        protected DiskCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.DiskCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string diskName, Azure.ResourceManager.Compute.DiskData disk, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string diskName, Azure.ResourceManager.Compute.DiskData disk, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Disk> Get(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Disk> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Disk> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Disk>> GetAsync(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Disk> GetIfExists(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Disk>> GetIfExistsAsync(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Disk> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Disk>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Disk> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Disk>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskData : Azure.ResourceManager.Models.TrackedResource
    {
        public DiskData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? BurstingEnabled { get { throw null; } set { } }
        public float? CompletionPercent { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CreationData CreationData { get { throw null; } set { } }
        public string DiskAccessId { get { throw null; } set { } }
        public long? DiskIopsReadOnly { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadOnly { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public long? DiskSizeBytes { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskState? DiskState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingsCollection EncryptionSettingsCollection { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ManagedByExtended { get { throw null; } }
        public int? MaxShares { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PropertyUpdatesInProgress PropertyUpdatesInProgress { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskPurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ShareInfoElement> ShareInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SupportedCapabilities SupportedCapabilities { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class DiskEncryptionSet : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskEncryptionSet() { }
        public virtual Azure.ResourceManager.Compute.DiskEncryptionSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskEncryptionSetName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DiskEncryptionSetDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskEncryptionSetDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetAssociatedResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetAssociatedResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DiskEncryptionSetUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.DiskEncryptionSetUpdate diskEncryptionSet, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskEncryptionSetUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.DiskEncryptionSetUpdate diskEncryptionSet, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskEncryptionSetCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskEncryptionSet>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskEncryptionSet>, System.Collections.IEnumerable
    {
        protected DiskEncryptionSetCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.DiskEncryptionSetCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string diskEncryptionSetName, Azure.ResourceManager.Compute.DiskEncryptionSetData diskEncryptionSet, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskEncryptionSetCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string diskEncryptionSetName, Azure.ResourceManager.Compute.DiskEncryptionSetData diskEncryptionSet, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet> Get(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DiskEncryptionSet> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskEncryptionSet> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet>> GetAsync(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet> GetIfExists(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet>> GetIfExistsAsync(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DiskEncryptionSet> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskEncryptionSet>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DiskEncryptionSet> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskEncryptionSet>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskEncryptionSetData : Azure.ResourceManager.Models.TrackedResource
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
    public partial class DiskRestorePoint : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskRestorePoint() { }
        public virtual Azure.ResourceManager.Compute.DiskRestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskRestorePoint> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskRestorePoint>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DiskRestorePointGrantAccessOperation GrantAccess(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GrantAccessData grantAccessData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskRestorePointGrantAccessOperation> GrantAccessAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GrantAccessData grantAccessData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.DiskRestorePointRevokeAccessOperation RevokeAccess(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.DiskRestorePointRevokeAccessOperation> RevokeAccessAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskRestorePointCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskRestorePoint>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskRestorePoint>, System.Collections.IEnumerable
    {
        protected DiskRestorePointCollection() { }
        public virtual Azure.Response<bool> Exists(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskRestorePoint> Get(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DiskRestorePoint> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskRestorePoint> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskRestorePoint>> GetAsync(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskRestorePoint> GetIfExists(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskRestorePoint>> GetIfExistsAsync(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DiskRestorePoint> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskRestorePoint>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DiskRestorePoint> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskRestorePoint>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskRestorePointData : Azure.ResourceManager.Models.Resource
    {
        internal DiskRestorePointData() { }
        public float? CompletionPercent { get { throw null; } }
        public string DiskAccessId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Encryption Encryption { get { throw null; } }
        public string FamilyId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskPurchasePlan PurchasePlan { get { throw null; } }
        public string ReplicationState { get { throw null; } }
        public string SourceResourceId { get { throw null; } }
        public string SourceResourceLocation { get { throw null; } }
        public string SourceUniqueId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SupportedCapabilities SupportedCapabilities { get { throw null; } }
        public bool? SupportsHibernation { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
    }
    public partial class Gallery : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected Gallery() { }
        public virtual Azure.ResourceManager.Compute.GalleryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Gallery> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Gallery>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Gallery> Get(Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Gallery>> GetAsync(Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationCollection GetGalleryApplications() { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImageCollection GetGalleryImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Gallery> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Gallery>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Gallery> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Gallery>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GalleryUpdate gallery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GalleryUpdate gallery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryUpdateSharingProfileOperation UpdateSharingProfile(bool waitForCompletion, Azure.ResourceManager.Compute.Models.SharingUpdate sharingUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryUpdateSharingProfileOperation> UpdateSharingProfileAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.SharingUpdate sharingUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplication : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryApplication() { }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplication> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplication>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryApplicationName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryApplicationDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryApplicationDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplication> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplication>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationVersionCollection GetGalleryApplicationVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplication> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplication>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplication> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplication>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryApplicationUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GalleryApplicationUpdate galleryApplication, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryApplicationUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GalleryApplicationUpdate galleryApplication, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryApplication>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryApplication>, System.Collections.IEnumerable
    {
        protected GalleryApplicationCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.GalleryApplicationCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string galleryApplicationName, Azure.ResourceManager.Compute.GalleryApplicationData galleryApplication, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryApplicationCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string galleryApplicationName, Azure.ResourceManager.Compute.GalleryApplicationData galleryApplication, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplication> Get(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.GalleryApplication> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.GalleryApplication> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplication>> GetAsync(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplication> GetIfExists(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplication>> GetIfExistsAsync(string galleryApplicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.GalleryApplication> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryApplication>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.GalleryApplication> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryApplication>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryApplicationData : Azure.ResourceManager.Models.TrackedResource
    {
        public GalleryApplicationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public System.Uri PrivacyStatementUri { get { throw null; } set { } }
        public System.Uri ReleaseNoteUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? SupportedOSType { get { throw null; } set { } }
    }
    public partial class GalleryApplicationVersion : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryApplicationVersion() { }
        public virtual Azure.ResourceManager.Compute.GalleryApplicationVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryApplicationName, string galleryApplicationVersionName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryApplicationVersionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryApplicationVersionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion> Get(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion>> GetAsync(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryApplicationVersionUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GalleryApplicationVersionUpdate galleryApplicationVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryApplicationVersionUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GalleryApplicationVersionUpdate galleryApplicationVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationVersionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryApplicationVersion>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryApplicationVersion>, System.Collections.IEnumerable
    {
        protected GalleryApplicationVersionCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.GalleryApplicationVersionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string galleryApplicationVersionName, Azure.ResourceManager.Compute.GalleryApplicationVersionData galleryApplicationVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryApplicationVersionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string galleryApplicationVersionName, Azure.ResourceManager.Compute.GalleryApplicationVersionData galleryApplicationVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion> Get(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.GalleryApplicationVersion> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.GalleryApplicationVersion> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion>> GetAsync(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion> GetIfExists(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion>> GetIfExistsAsync(string galleryApplicationVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.GalleryApplicationVersion> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryApplicationVersion>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.GalleryApplicationVersion> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryApplicationVersion>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryApplicationVersionData : Azure.ResourceManager.Models.TrackedResource
    {
        public GalleryApplicationVersionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
    }
    public partial class GalleryCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Gallery>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Gallery>, System.Collections.IEnumerable
    {
        protected GalleryCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.GalleryCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string galleryName, Azure.ResourceManager.Compute.GalleryData gallery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string galleryName, Azure.ResourceManager.Compute.GalleryData gallery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Gallery> Get(string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Gallery> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Gallery> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Gallery>> GetAsync(string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Gallery> GetIfExists(string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Gallery>> GetIfExistsAsync(string galleryName, Azure.ResourceManager.Compute.Models.SelectPermissions? select = default(Azure.ResourceManager.Compute.Models.SelectPermissions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Gallery> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Gallery>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Gallery> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Gallery>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryData : Azure.ResourceManager.Models.TrackedResource
    {
        public GalleryData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SharingProfile SharingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SoftDeletePolicy SoftDeletePolicy { get { throw null; } set { } }
    }
    public partial class GalleryImage : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryImage() { }
        public virtual Azure.ResourceManager.Compute.GalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImage> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImage>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryImageName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryImageDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryImageDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImage> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImage>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.GalleryImageVersionCollection GetGalleryImageVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImage> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImage>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImage> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImage>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryImageUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GalleryImageUpdate galleryImage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryImageUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GalleryImageUpdate galleryImage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryImage>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryImage>, System.Collections.IEnumerable
    {
        protected GalleryImageCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.GalleryImageCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string galleryImageName, Azure.ResourceManager.Compute.GalleryImageData galleryImage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryImageCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string galleryImageName, Azure.ResourceManager.Compute.GalleryImageData galleryImage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImage> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.GalleryImage> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.GalleryImage> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImage>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImage> GetIfExists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImage>> GetIfExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.GalleryImage> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryImage>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.GalleryImage> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryImage>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryImageData : Azure.ResourceManager.Models.TrackedResource
    {
        public GalleryImageData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Disallowed Disallowed { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } set { } }
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
    public partial class GalleryImageVersion : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GalleryImageVersion() { }
        public virtual Azure.ResourceManager.Compute.GalleryImageVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string galleryName, string galleryImageName, string galleryImageVersionName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryImageVersionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryImageVersionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion> Get(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion>> GetAsync(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.GalleryImageVersionUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GalleryImageVersionUpdate galleryImageVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryImageVersionUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GalleryImageVersionUpdate galleryImageVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageVersionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryImageVersion>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryImageVersion>, System.Collections.IEnumerable
    {
        protected GalleryImageVersionCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.GalleryImageVersionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string galleryImageVersionName, Azure.ResourceManager.Compute.GalleryImageVersionData galleryImageVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.GalleryImageVersionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string galleryImageVersionName, Azure.ResourceManager.Compute.GalleryImageVersionData galleryImageVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion> Get(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.GalleryImageVersion> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.GalleryImageVersion> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion>> GetAsync(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion> GetIfExists(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion>> GetIfExistsAsync(string galleryImageVersionName, Azure.ResourceManager.Compute.Models.ReplicationStatusTypes? expand = default(Azure.ResourceManager.Compute.Models.ReplicationStatusTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.GalleryImageVersion> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.GalleryImageVersion>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.GalleryImageVersion> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.GalleryImageVersion>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GalleryImageVersionData : Azure.ResourceManager.Models.TrackedResource
    {
        public GalleryImageVersionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class Image : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected Image() { }
        public virtual Azure.ResourceManager.Compute.ImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Image> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Image>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string imageName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.ImageDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.ImageDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Image> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Image>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Image> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Image>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Image> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Image>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.ImageUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.ImageUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.ImageUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.ImageUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImageCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Image>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Image>, System.Collections.IEnumerable
    {
        protected ImageCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.ImageCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string imageName, Azure.ResourceManager.Compute.ImageData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.ImageCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string imageName, Azure.ResourceManager.Compute.ImageData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Image> Get(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Image> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Image> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Image>> GetAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Image> GetIfExists(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Image>> GetIfExistsAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Image> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Image>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Image> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Image>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImageData : Azure.ResourceManager.Models.TrackedResource
    {
        public ImageData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationTypes? HyperVGeneration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVirtualMachine { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class OSFamily : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OSFamily() { }
        public virtual Azure.ResourceManager.Compute.OSFamilyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string osFamilyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.OSFamily> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.OSFamily>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OSFamilyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.OSFamily>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.OSFamily>, System.Collections.IEnumerable
    {
        protected OSFamilyCollection() { }
        public virtual Azure.Response<bool> Exists(string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.OSFamily> Get(string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.OSFamily> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.OSFamily> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.OSFamily>> GetAsync(string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.OSFamily> GetIfExists(string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.OSFamily>> GetIfExistsAsync(string osFamilyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.OSFamily> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.OSFamily>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.OSFamily> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.OSFamily>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OSFamilyData : Azure.ResourceManager.Models.Resource
    {
        internal OSFamilyData() { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OSFamilyProperties Properties { get { throw null; } }
    }
    public partial class OSVersion : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OSVersion() { }
        public virtual Azure.ResourceManager.Compute.OSVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string osVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.OSVersion> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.OSVersion>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OSVersionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.OSVersion>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.OSVersion>, System.Collections.IEnumerable
    {
        protected OSVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.OSVersion> Get(string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.OSVersion> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.OSVersion> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.OSVersion>> GetAsync(string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.OSVersion> GetIfExists(string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.OSVersion>> GetIfExistsAsync(string osVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.OSVersion> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.OSVersion>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.OSVersion> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.OSVersion>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OSVersionData : Azure.ResourceManager.Models.Resource
    {
        internal OSVersionData() { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OSVersionProperties Properties { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.Compute.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskAccessName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.Compute.PrivateEndpointConnectionData privateEndpointConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.Compute.PrivateEndpointConnectionData privateEndpointConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.Resource
    {
        public PrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ProximityPlacementGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProximityPlacementGroup() { }
        public virtual Azure.ResourceManager.Compute.ProximityPlacementGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string proximityPlacementGroupName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.ProximityPlacementGroupDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup> Get(string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup>> GetAsync(string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup> Update(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup>> UpdateAsync(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProximityPlacementGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ProximityPlacementGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ProximityPlacementGroup>, System.Collections.IEnumerable
    {
        protected ProximityPlacementGroupCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.ProximityPlacementGroupCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string proximityPlacementGroupName, Azure.ResourceManager.Compute.ProximityPlacementGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string proximityPlacementGroupName, Azure.ResourceManager.Compute.ProximityPlacementGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup> Get(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.ProximityPlacementGroup> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.ProximityPlacementGroup> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup>> GetAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup> GetIfExists(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup>> GetIfExistsAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.ProximityPlacementGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ProximityPlacementGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.ProximityPlacementGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ProximityPlacementGroup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProximityPlacementGroupData : Azure.ResourceManager.Models.TrackedResource
    {
        public ProximityPlacementGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.SubResourceWithColocationStatus> AvailabilitySets { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType? ProximityPlacementGroupType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.SubResourceWithColocationStatus> VirtualMachines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.SubResourceWithColocationStatus> VirtualMachineScaleSets { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.Compute.AvailabilitySetCollection GetAvailabilitySets(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservationGroupCollection GetCapacityReservationGroups(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.CloudServiceCollection GetCloudServices(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHostGroupCollection GetDedicatedHostGroups(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.DiskAccessCollection GetDiskAccesses(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.DiskEncryptionSetCollection GetDiskEncryptionSets(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.DiskCollection GetDisks(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.GalleryCollection GetGalleries(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.ImageCollection GetImages(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.ProximityPlacementGroupCollection GetProximityPlacementGroups(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePointGroupCollection GetRestorePointGroups(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.SnapshotCollection GetSnapshots(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.SshPublicKeyCollection GetSshPublicKeys(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineCollection GetVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetCollection GetVirtualMachineScaleSets(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class RestorePoint : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePoint() { }
        public virtual Azure.ResourceManager.Compute.RestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string restorePointName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.RestorePointDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.RestorePointDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePoint> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePoint>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DiskRestorePointCollection GetDiskRestorePoints() { throw null; }
    }
    public partial class RestorePointCollection : Azure.ResourceManager.Core.ArmCollection
    {
        protected RestorePointCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.RestorePointCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string restorePointName, Azure.ResourceManager.Compute.RestorePointData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.RestorePointCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string restorePointName, Azure.ResourceManager.Compute.RestorePointData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePoint> Get(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePoint>> GetAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePoint> GetIfExists(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePoint>> GetIfExistsAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointData : Azure.ResourceManager.Models.Resource
    {
        public RestorePointData() { }
        public Azure.ResourceManager.Compute.Models.ConsistencyModeTypes? ConsistencyMode { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ExcludeDisks { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata SourceMetadata { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } set { } }
    }
    public partial class RestorePointGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePointGroup() { }
        public virtual Azure.ResourceManager.Compute.RestorePointGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointCollectionName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.RestorePointGroupDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.RestorePointGroupDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup> Get(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup>> GetAsync(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.RestorePointCollection GetRestorePoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup> Update(Azure.ResourceManager.Compute.Models.RestorePointCollectionUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup>> UpdateAsync(Azure.ResourceManager.Compute.Models.RestorePointCollectionUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.RestorePointGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.RestorePointGroup>, System.Collections.IEnumerable
    {
        protected RestorePointGroupCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.RestorePointGroupCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string restorePointCollectionName, Azure.ResourceManager.Compute.RestorePointGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.RestorePointGroupCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string restorePointCollectionName, Azure.ResourceManager.Compute.RestorePointGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup> Get(string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.RestorePointGroup> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.RestorePointGroup> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup>> GetAsync(string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup> GetIfExists(string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup>> GetIfExistsAsync(string restorePointCollectionName, Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions? expand = default(Azure.ResourceManager.Compute.Models.RestorePointCollectionExpandOptions?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.RestorePointGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.RestorePointGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.RestorePointGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.RestorePointGroup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorePointGroupData : Azure.ResourceManager.Models.TrackedResource
    {
        public RestorePointGroupData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ProvisioningState { get { throw null; } }
        public string RestorePointCollectionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.RestorePointData> RestorePoints { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointCollectionSourceProperties Source { get { throw null; } set { } }
    }
    public partial class RoleInstance : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleInstance() { }
        public virtual Azure.ResourceManager.Compute.RoleInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServiceName, string roleInstanceName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.RoleInstanceDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.RoleInstanceDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RoleInstance> Get(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RoleInstance>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RoleInstanceView> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RoleInstanceView>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetRemoteDesktopFile(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetRemoteDesktopFileAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.RoleInstanceRebuildOperation Rebuild(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.RoleInstanceRebuildOperation> RebuildAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.RoleInstanceReimageOperation Reimage(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.RoleInstanceReimageOperation> ReimageAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.RoleInstanceRestartOperation Restart(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.RoleInstanceRestartOperation> RestartAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleInstanceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.RoleInstance>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.RoleInstance>, System.Collections.IEnumerable
    {
        protected RoleInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RoleInstance> Get(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.RoleInstance> GetAll(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.RoleInstance> GetAllAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RoleInstance>> GetAsync(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RoleInstance> GetIfExists(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RoleInstance>> GetIfExistsAsync(string roleInstanceName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.RoleInstance> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.RoleInstance>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.RoleInstance> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.RoleInstance>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleInstanceData : Azure.ResourceManager.Models.Resource
    {
        internal RoleInstanceData() { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RoleInstanceProperties Properties { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceSku Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SharedGallery : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedGallery() { }
        public virtual Azure.ResourceManager.Compute.SharedGalleryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string galleryUniqueName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGallery> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGallery>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.SharedGalleryImageCollection GetSharedGalleryImages() { throw null; }
    }
    public partial class SharedGalleryCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGallery>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGallery>, System.Collections.IEnumerable
    {
        protected SharedGalleryCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGallery> Get(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.SharedGallery> GetAll(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.SharedGallery> GetAllAsync(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGallery>> GetAsync(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGallery> GetIfExists(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGallery>> GetIfExistsAsync(string galleryUniqueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.SharedGallery> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGallery>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.SharedGallery> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGallery>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedGalleryData : Azure.ResourceManager.Compute.Models.PirSharedGalleryResource
    {
        internal SharedGalleryData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
    }
    public partial class SharedGalleryImage : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedGalleryImage() { }
        public virtual Azure.ResourceManager.Compute.SharedGalleryImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string galleryUniqueName, string galleryImageName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImage> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImage>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.SharedGalleryImageVersionCollection GetSharedGalleryImageVersions() { throw null; }
    }
    public partial class SharedGalleryImageCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGalleryImage>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGalleryImage>, System.Collections.IEnumerable
    {
        protected SharedGalleryImageCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImage> Get(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.SharedGalleryImage> GetAll(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.SharedGalleryImage> GetAllAsync(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImage>> GetAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImage> GetIfExists(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImage>> GetIfExistsAsync(string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.SharedGalleryImage> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGalleryImage>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.SharedGalleryImage> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGalleryImage>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedGalleryImageData : Azure.ResourceManager.Compute.Models.PirSharedGalleryResource
    {
        internal SharedGalleryImageData() { }
        public Azure.ResourceManager.Compute.Models.Disallowed Disallowed { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.GalleryImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageIdentifier Identifier { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes? OSState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImagePurchasePlan PurchasePlan { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RecommendedMachineConfiguration Recommended { get { throw null; } }
    }
    public partial class SharedGalleryImageVersion : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedGalleryImageVersion() { }
        public virtual Azure.ResourceManager.Compute.SharedGalleryImageVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string galleryUniqueName, string galleryImageName, string galleryImageVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersion> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersion>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedGalleryImageVersionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageVersion>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageVersion>, System.Collections.IEnumerable
    {
        protected SharedGalleryImageVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersion> Get(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.SharedGalleryImageVersion> GetAll(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.SharedGalleryImageVersion> GetAllAsync(Azure.ResourceManager.Compute.Models.SharedToValues? sharedTo = default(Azure.ResourceManager.Compute.Models.SharedToValues?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersion>> GetAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersion> GetIfExists(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SharedGalleryImageVersion>> GetIfExistsAsync(string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.SharedGalleryImageVersion> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageVersion>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.SharedGalleryImageVersion> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SharedGalleryImageVersion>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedGalleryImageVersionData : Azure.ResourceManager.Compute.Models.PirSharedGalleryResource
    {
        internal SharedGalleryImageVersionData() { }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.DateTimeOffset? PublishedDate { get { throw null; } }
    }
    public partial class Snapshot : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected Snapshot() { }
        public virtual Azure.ResourceManager.Compute.SnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Snapshot> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Snapshot>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string snapshotName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.SnapshotDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.SnapshotDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Snapshot> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Snapshot>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.SnapshotGrantAccessOperation GrantAccess(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GrantAccessData grantAccessData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.SnapshotGrantAccessOperation> GrantAccessAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.GrantAccessData grantAccessData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Snapshot> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Snapshot>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.SnapshotRevokeAccessOperation RevokeAccess(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.SnapshotRevokeAccessOperation> RevokeAccessAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Snapshot> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Snapshot>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.SnapshotUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.SnapshotUpdate snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.SnapshotUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.SnapshotUpdate snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Snapshot>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Snapshot>, System.Collections.IEnumerable
    {
        protected SnapshotCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.SnapshotCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string snapshotName, Azure.ResourceManager.Compute.SnapshotData snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.SnapshotCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string snapshotName, Azure.ResourceManager.Compute.SnapshotData snapshot, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Snapshot> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Snapshot> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Snapshot> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Snapshot>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Snapshot> GetIfExists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Snapshot>> GetIfExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.Snapshot> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.Snapshot>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.Snapshot> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Snapshot>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SnapshotData : Azure.ResourceManager.Models.TrackedResource
    {
        public SnapshotData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public float? CompletionPercent { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CreationData CreationData { get { throw null; } set { } }
        public string DiskAccessId { get { throw null; } set { } }
        public long? DiskSizeBytes { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskState? DiskState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingsCollection EncryptionSettingsCollection { get { throw null; } set { } }
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
        public Azure.ResourceManager.Compute.Models.SupportedCapabilities SupportedCapabilities { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UniqueId { get { throw null; } }
    }
    public partial class SshPublicKey : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SshPublicKey() { }
        public virtual Azure.ResourceManager.Compute.SshPublicKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKey> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKey>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sshPublicKeyName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.SshPublicKeyDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.SshPublicKeyDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult> GenerateKeyPair(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>> GenerateKeyPairAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKey> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKey>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKey> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKey>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKey> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKey>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKey> Update(Azure.ResourceManager.Compute.Models.SshPublicKeyUpdateResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKey>> UpdateAsync(Azure.ResourceManager.Compute.Models.SshPublicKeyUpdateResource parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SshPublicKeyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SshPublicKey>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SshPublicKey>, System.Collections.IEnumerable
    {
        protected SshPublicKeyCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.SshPublicKeyCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string sshPublicKeyName, Azure.ResourceManager.Compute.SshPublicKeyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.SshPublicKeyCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string sshPublicKeyName, Azure.ResourceManager.Compute.SshPublicKeyData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKey> Get(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.SshPublicKey> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.SshPublicKey> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKey>> GetAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKey> GetIfExists(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKey>> GetIfExistsAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.SshPublicKey> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SshPublicKey>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.SshPublicKey> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SshPublicKey>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SshPublicKeyData : Azure.ResourceManager.Models.TrackedResource
    {
        public SshPublicKeyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string PublicKey { get { throw null; } set { } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.ResourceManager.Compute.Models.ExportRequestRateByIntervalLogAnalyticOperation ExportRequestRateByIntervalLogAnalytic(this Azure.ResourceManager.Resources.Subscription subscription, bool waitForCompletion, string location, Azure.ResourceManager.Compute.Models.RequestRateByIntervalInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.ExportRequestRateByIntervalLogAnalyticOperation> ExportRequestRateByIntervalLogAnalyticAsync(this Azure.ResourceManager.Resources.Subscription subscription, bool waitForCompletion, string location, Azure.ResourceManager.Compute.Models.RequestRateByIntervalInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ExportThrottledRequestsLogAnalyticOperation ExportThrottledRequestsLogAnalytic(this Azure.ResourceManager.Resources.Subscription subscription, bool waitForCompletion, string location, Azure.ResourceManager.Compute.Models.ThrottledRequestsInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.ExportThrottledRequestsLogAnalyticOperation> ExportThrottledRequestsLogAnalyticAsync(this Azure.ResourceManager.Resources.Subscription subscription, bool waitForCompletion, string location, Azure.ResourceManager.Compute.Models.ThrottledRequestsInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.AvailabilitySet> GetAvailabilitySets(this Azure.ResourceManager.Resources.Subscription subscription, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.AvailabilitySet> GetAvailabilitySetsAsync(this Azure.ResourceManager.Resources.Subscription subscription, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.CapacityReservationGroup> GetCapacityReservationGroups(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.CapacityReservationGroup> GetCapacityReservationGroupsAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetCapacityReservationGroups?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.CloudService> GetCloudServices(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.CloudService> GetCloudServicesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGallery> GetCommunityGallery(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGallery>> GetCommunityGalleryAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publicGalleryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGalleryImage> GetCommunityGalleryImage(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publicGalleryName, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGalleryImage>> GetCommunityGalleryImageAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publicGalleryName, string galleryImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGalleryImageVersion> GetCommunityGalleryImageVersion(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publicGalleryName, string galleryImageName, string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.CommunityGalleryImageVersion>> GetCommunityGalleryImageVersionAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publicGalleryName, string galleryImageName, string galleryImageVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.DedicatedHostGroup> GetDedicatedHostGroups(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.DedicatedHostGroup> GetDedicatedHostGroupsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.DiskAccess> GetDiskAccesses(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskAccess> GetDiskAccessesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.DiskEncryptionSet> GetDiskEncryptionSets(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskEncryptionSet> GetDiskEncryptionSetsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Disk> GetDisks(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Disk> GetDisksAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Gallery> GetGalleries(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Gallery> GetGalleriesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Image> GetImages(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Image> GetImagesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetOffersVirtualMachineImages(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetOffersVirtualMachineImagesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetOffersVirtualMachineImagesEdgeZones(this Azure.ResourceManager.Resources.Subscription subscription, string location, string edgeZone, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetOffersVirtualMachineImagesEdgeZonesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string edgeZone, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.OSFamilyCollection GetOSFamilies(this Azure.ResourceManager.Resources.Subscription subscription, string location) { throw null; }
        public static Azure.ResourceManager.Compute.OSVersionCollection GetOSVersions(this Azure.ResourceManager.Resources.Subscription subscription, string location) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.ProximityPlacementGroup> GetProximityPlacementGroups(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.ProximityPlacementGroup> GetProximityPlacementGroupsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetPublishersVirtualMachineImages(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetPublishersVirtualMachineImagesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetPublishersVirtualMachineImagesEdgeZones(this Azure.ResourceManager.Resources.Subscription subscription, string location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetPublishersVirtualMachineImagesEdgeZonesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.ResourceSku> GetResourceSkus(this Azure.ResourceManager.Resources.Subscription subscription, string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ResourceSku> GetResourceSkusAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.RestorePointGroup> GetRestorePointGroups(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.RestorePointGroup> GetRestorePointGroupsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.SharedGalleryCollection GetSharedGalleries(this Azure.ResourceManager.Resources.Subscription subscription, string location) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Snapshot> GetSnapshots(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Snapshot> GetSnapshotsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.SshPublicKey> GetSshPublicKeys(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.SshPublicKey> GetSshPublicKeysAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.Usage> GetUsages(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.Usage> GetUsagesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publisherName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage> GetVirtualMachineImage(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage>> GetVirtualMachineImageAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetVirtualMachineImageEdgeZoneSkus(this Azure.ResourceManager.Resources.Subscription subscription, string location, string edgeZone, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetVirtualMachineImageEdgeZoneSkusAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string edgeZone, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetVirtualMachineImages(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publisherName, string offer, string skus, string expand = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetVirtualMachineImagesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publisherName, string offer, string skus, string expand = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage> GetVirtualMachineImagesEdgeZone(this Azure.ResourceManager.Resources.Subscription subscription, string location, string edgeZone, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage>> GetVirtualMachineImagesEdgeZoneAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string edgeZone, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetVirtualMachineImagesEdgeZones(this Azure.ResourceManager.Resources.Subscription subscription, string location, string edgeZone, string publisherName, string offer, string skus, string expand = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetVirtualMachineImagesEdgeZonesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string edgeZone, string publisherName, string offer, string skus, string expand = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetVirtualMachineImageSkus(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageResource> GetVirtualMachineImageSkusAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandDocument> GetVirtualMachineRunCommand(this Azure.ResourceManager.Resources.Subscription subscription, string location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandDocument>> GetVirtualMachineRunCommandAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> GetVirtualMachineRunCommands(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> GetVirtualMachineRunCommandsAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachine> GetVirtualMachines(this Azure.ResourceManager.Resources.Subscription subscription, string statusOnly = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachine> GetVirtualMachinesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string statusOnly = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachine> GetVirtualMachinesByLocation(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachine> GetVirtualMachinesByLocationAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSet> GetVirtualMachineScaleSets(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSet> GetVirtualMachineScaleSetsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSet> GetVirtualMachineScaleSetsByLocation(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSet> GetVirtualMachineScaleSetsByLocationAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetVirtualMachineSizes(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetVirtualMachineSizesAsync(this Azure.ResourceManager.Resources.Subscription subscription, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachine : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachine() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachine> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachine>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesOperation AssessPatches(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesOperation> AssessPatchesAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineCaptureOperation Capture(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineCaptureParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureOperation> CaptureAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineCaptureParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineConvertToManagedDisksOperation ConvertToManagedDisks(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineConvertToManagedDisksOperation> ConvertToManagedDisksAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineDeallocateOperation Deallocate(bool waitForCompletion, bool? hibernate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineDeallocateOperation> DeallocateAsync(bool waitForCompletion, bool? hibernate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineDeleteOperation Delete(bool waitForCompletion, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineDeleteOperation> DeleteAsync(bool waitForCompletion, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Generalize(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GeneralizeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachine> Get(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachine>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetAvailableSizes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetAvailableSizesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionCollection GetVirtualMachineExtensions() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineRunCommandCollection GetVirtualMachineRunCommands() { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesOperation InstallPatches(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesParameters installPatchesInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesOperation> InstallPatchesAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesParameters installPatchesInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView> InstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView>> InstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachinePerformMaintenanceOperation PerformMaintenance(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachinePerformMaintenanceOperation> PerformMaintenanceAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachinePowerOffOperation PowerOff(bool waitForCompletion, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachinePowerOffOperation> PowerOffAsync(bool waitForCompletion, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachinePowerOnOperation PowerOn(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachinePowerOnOperation> PowerOnAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineReapplyOperation Reapply(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineReapplyOperation> ReapplyAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineRedeployOperation Redeploy(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineRedeployOperation> RedeployAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineReimageOperation Reimage(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineReimageParameters parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineReimageOperation> ReimageAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineReimageParameters parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachine> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachine>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineRestartOperation Restart(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineRestartOperation> RestartAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult> RetrieveBootDiagnosticsData(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>> RetrieveBootDiagnosticsDataAsync(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandOperation RunCommand(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RunCommandInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandOperation> RunCommandAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RunCommandInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachine> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachine>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SimulateEviction(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SimulateEvictionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachine>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachine>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string vmName, Azure.ResourceManager.Compute.VirtualMachineData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string vmName, Azure.ResourceManager.Compute.VirtualMachineData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachine> Get(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachine> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachine> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachine>> GetAsync(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachine> GetIfExists(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachine>> GetIfExistsAsync(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachine> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachine>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachine> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachine>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualMachineData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ApplicationProfile ApplicationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource AvailabilitySet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BillingProfile BillingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CapacityReservationProfile CapacityReservation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource Host { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource HostGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Plan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource ProximityPlacementGroup { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.VirtualMachineExtensionData> Resources { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource VirtualMachineScaleSet { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class VirtualMachineExtension : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineExtension() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string vmExtensionName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineExtensionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineExtensionUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionUpdate extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionUpdate extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineExtensionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtension>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtension>, System.Collections.IEnumerable
    {
        protected VirtualMachineExtensionCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineExtensionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string vmExtensionName, Azure.ResourceManager.Compute.VirtualMachineExtensionData extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string vmExtensionName, Azure.ResourceManager.Compute.VirtualMachineExtensionData extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension> Get(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineExtension> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineExtension> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension>> GetAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension> GetIfExists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension>> GetIfExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtension> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtension>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtension> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtension>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineExtensionData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualMachineExtensionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public object ProtectedSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionImage : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineExtensionImage() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string publisherName, string type, string version) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineExtensionImageCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionImage>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionImage>, System.Collections.IEnumerable
    {
        protected VirtualMachineExtensionImageCollection() { }
        public virtual Azure.Response<bool> Exists(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> Get(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> GetAll(string type, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> GetAllAsync(string type, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage>> GetAsync(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> GetIfExists(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImage>> GetIfExistsAsync(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionImage>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtensionImage> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionImage>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineExtensionImageData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualMachineExtensionImageData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ComputeRole { get { throw null; } set { } }
        public string HandlerSchema { get { throw null; } set { } }
        public string OperatingSystem { get { throw null; } set { } }
        public bool? SupportsMultipleExtensions { get { throw null; } set { } }
        public bool? VmScaleSetEnabled { get { throw null; } set { } }
    }
    public partial class VirtualMachineRunCommand : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineRunCommand() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineRunCommandData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string runCommandName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineRunCommandCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineRunCommand>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineRunCommand>, System.Collections.IEnumerable
    {
        protected VirtualMachineRunCommandCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string runCommandName, Azure.ResourceManager.Compute.VirtualMachineRunCommandData runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string runCommandName, Azure.ResourceManager.Compute.VirtualMachineRunCommandData runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand> Get(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineRunCommand> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineRunCommand> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand>> GetAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand> GetIfExists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand>> GetIfExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineRunCommand> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineRunCommand>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineRunCommand> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineRunCommand>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineRunCommandData : Azure.ResourceManager.Models.TrackedResource
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
    public partial class VirtualMachineScaleSet : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSet() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetCancelVirtualMachineScaleSetRollingUpgradeOperation CancelVirtualMachineScaleSetRollingUpgrade(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetCancelVirtualMachineScaleSetRollingUpgradeOperation> CancelVirtualMachineScaleSetRollingUpgradeAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ConvertToSinglePlacementGroup(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ConvertToSinglePlacementGroupAsync(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDeallocateOperation Deallocate(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDeallocateOperation> DeallocateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDeleteOperation Delete(bool waitForCompletion, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDeleteOperation> DeleteAsync(bool waitForCompletion, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDeleteInstancesOperation DeleteInstances(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIDs, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDeleteInstancesOperation> DeleteInstancesAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIDs, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse> ForceRecoveryServiceFabricPlatformUpdateDomainWalk(int platformUpdateDomain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>> ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(int platformUpdateDomain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet> Get(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet>> GetAsync(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo> GetOSUpgradeHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo> GetOSUpgradeHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionCollection GetVirtualMachineScaleSetExtensions() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgrade GetVirtualMachineScaleSetRollingUpgrade() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmCollection GetVirtualMachineScaleSetVms() { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPerformMaintenanceOperation PerformMaintenance(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPerformMaintenanceOperation> PerformMaintenanceAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPowerOffOperation PowerOff(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPowerOffOperation> PowerOffAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPowerOnOperation PowerOn(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPowerOnOperation> PowerOnAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetRedeployOperation Redeploy(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetRedeployOperation> RedeployAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageOperation Reimage(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageParameters vmScaleSetReimageInput = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageAllOperation ReimageAll(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageAllOperation> ReimageAllAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageOperation> ReimageAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageParameters vmScaleSetReimageInput = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetRestartOperation Restart(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetRestartOperation> RestartAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIDs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSetOrchestrationServiceStateOperation SetOrchestrationServiceState(bool waitForCompletion, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSetOrchestrationServiceStateOperation> SetOrchestrationServiceStateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStartExtensionUpgradeVirtualMachineScaleSetRollingUpgradeOperation StartExtensionUpgradeVirtualMachineScaleSetRollingUpgrade(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStartExtensionUpgradeVirtualMachineScaleSetRollingUpgradeOperation> StartExtensionUpgradeVirtualMachineScaleSetRollingUpgradeAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStartOSUpgradeOperation StartOSUpgrade(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStartOSUpgradeOperation> StartOSUpgradeAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdate parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateInstancesOperation UpdateInstances(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIDs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateInstancesOperation> UpdateInstancesAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIDs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSet>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSet>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string vmScaleSetName, Azure.ResourceManager.Compute.VirtualMachineScaleSetData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string vmScaleSetName, Azure.ResourceManager.Compute.VirtualMachineScaleSetData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet> Get(string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSet> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSet> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet>> GetAsync(string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet> GetIfExists(string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet>> GetIfExistsAsync(string vmScaleSetName, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSet> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSet>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSet> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSet>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualMachineScaleSetData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public bool? DoNotRunExtensionsOnOverprovisionedVms { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource HostGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OrchestrationMode? OrchestrationMode { get { throw null; } set { } }
        public bool? Overprovision { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Plan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public bool? SinglePlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SpotRestorePolicy SpotRestorePolicy { get { throw null; } set { } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile VirtualMachineProfile { get { throw null; } set { } }
        public bool? ZoneBalance { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetExtension : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetExtension() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName, string vmssExtensionName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionUpdate extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionUpdate extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetExtensionCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string vmssExtensionName, Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string vmssExtensionName, Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension> Get(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>> GetAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension> GetIfExists(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>> GetIfExistsAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionData : Azure.ResourceManager.Compute.Models.SubResourceReadOnly
    {
        public VirtualMachineScaleSetExtensionData() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public object ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetRollingUpgrade : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetRollingUpgrade() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgrade> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgrade>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgrade> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgrade>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgrade> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgrade>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgrade> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgrade>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetRollingUpgradeData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualMachineScaleSetRollingUpgradeData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradePolicy Policy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo Progress { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus RunningStatus { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVirtualMachineRunCommand : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVirtualMachineRunCommand() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineRunCommandData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName, string instanceId, string runCommandName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVirtualMachineRunCommandDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVirtualMachineRunCommandDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVirtualMachineRunCommandUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVirtualMachineRunCommandUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVirtualMachineRunCommandCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetVirtualMachineRunCommandCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVirtualMachineRunCommandCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string runCommandName, Azure.ResourceManager.Compute.VirtualMachineRunCommandData runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVirtualMachineRunCommandCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string runCommandName, Azure.ResourceManager.Compute.VirtualMachineRunCommandData runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand> Get(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>> GetAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand> GetIfExists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>> GetIfExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVm : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVm() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName, string instanceId) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmDeallocateOperation Deallocate(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmDeallocateOperation> DeallocateAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmDeleteOperation Delete(bool waitForCompletion, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmDeleteOperation> DeleteAsync(bool waitForCompletion, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm> Get(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommandCollection GetVirtualMachineScaleSetVirtualMachineRunCommands() { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionCollection GetVirtualMachineScaleSetVmExtensions() { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmPerformMaintenanceOperation PerformMaintenance(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmPerformMaintenanceOperation> PerformMaintenanceAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmPowerOffOperation PowerOff(bool waitForCompletion, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmPowerOffOperation> PowerOffAsync(bool waitForCompletion, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmPowerOnOperation PowerOn(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmPowerOnOperation> PowerOnAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmRedeployOperation Redeploy(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmRedeployOperation> RedeployAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageOperation Reimage(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageOptions vmScaleSetVMReimageInput = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageAllOperation ReimageAll(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageAllOperation> ReimageAllAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageOperation> ReimageAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageOptions vmScaleSetVMReimageInput = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmRestartOperation Restart(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmRestartOperation> RestartAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult> RetrieveBootDiagnosticsData(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>> RetrieveBootDiagnosticsDataAsync(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmRunCommandOperation RunCommand(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RunCommandInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmRunCommandOperation> RunCommandAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.RunCommandInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SimulateEviction(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SimulateEvictionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetVmCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string instanceId, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string instanceId, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm> Get(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm> GetAll(string filter = null, string select = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm> GetAllAsync(string filter = null, string select = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>> GetAsync(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm> GetIfExists(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>> GetIfExistsAsync(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewTypes? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewTypes?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmData : Azure.ResourceManager.Models.TrackedResource
    {
        public VirtualMachineScaleSetVmData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource AvailabilitySet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public string InstanceId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView InstanceView { get { throw null; } }
        public bool? LatestModelApplied { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public string ModelDefinitionApplied { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmNetworkProfileConfiguration NetworkProfileConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Plan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy ProtectionPolicy { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.VirtualMachineExtensionData> Resources { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVmExtension : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVmExtension() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmScaleSetName, string instanceId, string vmExtensionName) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionUpdateOptions extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionUpdateOptions extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetVmExtensionCollection() { }
        public virtual Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string vmExtensionName, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string vmExtensionName, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData extensionParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension> Get(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>> GetAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension> GetIfExists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>> GetIfExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionData : Azure.ResourceManager.Compute.Models.SubResourceReadOnly
    {
        public VirtualMachineScaleSetVmExtensionData() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public object ProtectedSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
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
        public string AccessSAS { get { throw null; } }
        public string SecurityDataAccessSAS { get { throw null; } }
    }
    public partial class AdditionalCapabilities
    {
        public AdditionalCapabilities() { }
        public bool? HibernationEnabled { get { throw null; } set { } }
        public bool? UltraSSDEnabled { get { throw null; } set { } }
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
    public partial class ApplicationProfile
    {
        public ApplicationProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VmGalleryApplication> GalleryApplications { get { throw null; } }
    }
    public partial class AutomaticOSUpgradePolicy
    {
        public AutomaticOSUpgradePolicy() { }
        public bool? DisableAutomaticRollback { get { throw null; } set { } }
        public bool? EnableAutomaticOSUpgrade { get { throw null; } set { } }
    }
    public partial class AutomaticOSUpgradeProperties
    {
        public AutomaticOSUpgradeProperties(bool automaticOSUpgradeSupported) { }
        public bool AutomaticOSUpgradeSupported { get { throw null; } set { } }
    }
    public partial class AutomaticRepairsPolicy
    {
        public AutomaticRepairsPolicy() { }
        public bool? Enabled { get { throw null; } set { } }
        public string GracePeriod { get { throw null; } set { } }
    }
    public partial class AvailabilitySetCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.AvailabilitySet>
    {
        protected AvailabilitySetCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.AvailabilitySet Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySet>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvailabilitySetDeleteOperation : Azure.Operation
    {
        protected AvailabilitySetDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AvailabilitySetUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public AvailabilitySetUpdate() { }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public int? PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualMachines { get { throw null; } }
    }
    public partial class AvailablePatchSummary
    {
        internal AvailablePatchSummary() { }
        public string AssessmentActivityId { get { throw null; } }
        public int? CriticalAndSecurityPatchCount { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public int? OtherPatchCount { get { throw null; } }
        public bool? RebootPending { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchOperationStatus? Status { get { throw null; } }
    }
    public partial class BillingProfile
    {
        public BillingProfile() { }
        public double? MaxPrice { get { throw null; } set { } }
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
    public partial class CapacityReservationCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.CapacityReservation>
    {
        protected CapacityReservationCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.CapacityReservation Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.CapacityReservation>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.CapacityReservation>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationDeleteOperation : Azure.Operation
    {
        protected CapacityReservationDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationGroupCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.CapacityReservationGroup>
    {
        protected CapacityReservationGroupCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.CapacityReservationGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationGroupDeleteOperation : Azure.Operation
    {
        protected CapacityReservationGroupDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationGroupInstanceView
    {
        internal CapacityReservationGroupInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName> CapacityReservations { get { throw null; } }
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
    public partial class CapacityReservationGroupUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public CapacityReservationGroupUpdate() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> CapacityReservations { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView InstanceView { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
    }
    public partial class CapacityReservationInstanceView
    {
        internal CapacityReservationInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CapacityReservationUtilization UtilizationInfo { get { throw null; } }
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
    public partial class CapacityReservationProfile
    {
        public CapacityReservationProfile() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource CapacityReservationGroup { get { throw null; } set { } }
    }
    public partial class CapacityReservationUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public CapacityReservationUpdate() { }
        public Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView InstanceView { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningTime { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
    }
    public partial class CapacityReservationUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.CapacityReservation>
    {
        protected CapacityReservationUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.CapacityReservation Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.CapacityReservation>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.CapacityReservation>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationUtilization
    {
        internal CapacityReservationUtilization() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAllocated { get { throw null; } }
    }
    public partial class CloudServiceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.CloudService>
    {
        protected CloudServiceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.CloudService Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.CloudService>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.CloudService>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceDeleteInstancesOperation : Azure.Operation
    {
        protected CloudServiceDeleteInstancesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceDeleteOperation : Azure.Operation
    {
        protected CloudServiceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceExtensionProfile
    {
        public CloudServiceExtensionProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.Extension> Extensions { get { throw null; } }
    }
    public partial class CloudServiceExtensionProperties
    {
        public CloudServiceExtensionProperties() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string ProtectedSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CloudServiceVaultAndSecretReference ProtectedSettingsFromKeyVault { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RolesAppliedTo { get { throw null; } }
        public string Settings { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class CloudServiceInstanceView
    {
        internal CloudServiceInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<string> PrivateIds { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatusesSummary RoleInstance { get { throw null; } }
        public string SdkVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceInstanceViewStatus> Statuses { get { throw null; } }
    }
    public partial class CloudServiceNetworkProfile
    {
        public CloudServiceNetworkProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.LoadBalancerConfiguration> LoadBalancerConfigurations { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SwappableCloudService { get { throw null; } set { } }
    }
    public partial class CloudServiceOSProfile
    {
        public CloudServiceOSProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.CloudServiceVaultSecretGroup> Secrets { get { throw null; } }
    }
    public partial class CloudServicePowerOffOperation : Azure.Operation
    {
        protected CloudServicePowerOffOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServicePowerOnOperation : Azure.Operation
    {
        protected CloudServicePowerOnOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceProperties
    {
        public CloudServiceProperties() { }
        public bool? AllowModelOverride { get { throw null; } set { } }
        public string Configuration { get { throw null; } set { } }
        public string ConfigurationUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CloudServiceExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CloudServiceNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CloudServiceOSProfile OSProfile { get { throw null; } set { } }
        public string PackageUrl { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CloudServiceRoleProfile RoleProfile { get { throw null; } set { } }
        public bool? StartCloudService { get { throw null; } set { } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CloudServiceUpgradeMode? UpgradeMode { get { throw null; } set { } }
    }
    public partial class CloudServiceRebuildOperation : Azure.Operation
    {
        protected CloudServiceRebuildOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceReimageOperation : Azure.Operation
    {
        protected CloudServiceReimageOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceRestartOperation : Azure.Operation
    {
        protected CloudServiceRestartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServiceRoleProfile
    {
        public CloudServiceRoleProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.CloudServiceRoleProfileProperties> Roles { get { throw null; } }
    }
    public partial class CloudServiceRoleProfileProperties
    {
        public CloudServiceRoleProfileProperties() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CloudServiceRoleSku Sku { get { throw null; } set { } }
    }
    public partial class CloudServiceRoleProperties
    {
        internal CloudServiceRoleProperties() { }
        public string UniqueId { get { throw null; } }
    }
    public partial class CloudServiceRoleSku
    {
        public CloudServiceRoleSku() { }
        public long? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class CloudServiceUpdate
    {
        public CloudServiceUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CloudServiceUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.CloudService>
    {
        protected CloudServiceUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.CloudService Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.CloudService>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.CloudService>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string SecretUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
    }
    public partial class CloudServiceVaultCertificate
    {
        public CloudServiceVaultCertificate() { }
        public string CertificateUrl { get { throw null; } set { } }
    }
    public partial class CloudServiceVaultSecretGroup
    {
        public CloudServiceVaultSecretGroup() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.CloudServiceVaultCertificate> VaultCertificates { get { throw null; } }
    }
    public partial class CloudServiceWalkUpdateDomainOperation : Azure.Operation
    {
        protected CloudServiceWalkUpdateDomainOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunityGallery : Azure.ResourceManager.Compute.Models.PirCommunityGalleryResource
    {
        internal CommunityGallery() { }
    }
    public partial class CommunityGalleryImage : Azure.ResourceManager.Compute.Models.PirCommunityGalleryResource
    {
        internal CommunityGalleryImage() { }
        public Azure.ResourceManager.Compute.Models.Disallowed Disallowed { get { throw null; } }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.GalleryImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageIdentifier Identifier { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes? OSState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImagePurchasePlan PurchasePlan { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RecommendedMachineConfiguration Recommended { get { throw null; } }
    }
    public partial class CommunityGalleryImageVersion : Azure.ResourceManager.Compute.Models.PirCommunityGalleryResource
    {
        internal CommunityGalleryImageVersion() { }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } }
        public System.DateTimeOffset? PublishedDate { get { throw null; } }
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
    public partial class CreationData
    {
        public CreationData(Azure.ResourceManager.Compute.Models.DiskCreateOption createOption) { }
        public Azure.ResourceManager.Compute.Models.DiskCreateOption CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageDiskReference GalleryImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageDiskReference ImageReference { get { throw null; } set { } }
        public int? LogicalSectorSize { get { throw null; } set { } }
        public System.Uri SecurityDataUri { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public string SourceUniqueId { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public long? UploadSizeBytes { get { throw null; } set { } }
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
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Image { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ToBeDetached { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Vhd { get { throw null; } set { } }
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
    public partial class DedicatedHostAvailableCapacity
    {
        internal DedicatedHostAvailableCapacity() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm> AllocatableVms { get { throw null; } }
    }
    public partial class DedicatedHostCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.DedicatedHost>
    {
        protected DedicatedHostCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.DedicatedHost Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DedicatedHost>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DedicatedHost>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostDeleteOperation : Azure.Operation
    {
        protected DedicatedHostDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostGroupCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.DedicatedHostGroup>
    {
        protected DedicatedHostGroupCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.DedicatedHostGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostGroupDeleteOperation : Azure.Operation
    {
        protected DedicatedHostGroupDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostGroupInstanceView
    {
        internal DedicatedHostGroupInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName> Hosts { get { throw null; } }
    }
    public partial class DedicatedHostGroupUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public DedicatedHostGroupUpdate() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Hosts { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostGroupInstanceView InstanceView { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public bool? SupportAutomaticPlacement { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class DedicatedHostInstanceView
    {
        internal DedicatedHostInstanceView() { }
        public string AssetId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostAvailableCapacity AvailableCapacity { get { throw null; } }
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
    public partial class DedicatedHostUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public DedicatedHostUpdate() { }
        public bool? AutoReplaceOnFailure { get { throw null; } set { } }
        public string HostId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostLicenseTypes? LicenseType { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ProvisioningTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachines { get { throw null; } }
    }
    public partial class DedicatedHostUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.DedicatedHost>
    {
        protected DedicatedHostUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.DedicatedHost Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DedicatedHost>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DedicatedHost>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DiagnosticsProfile
    {
        public DiagnosticsProfile() { }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
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
    public partial class Disallowed
    {
        public Disallowed() { }
        public System.Collections.Generic.IList<string> DiskTypes { get { throw null; } }
    }
    public partial class DisallowedConfiguration
    {
        public DisallowedConfiguration() { }
        public Azure.ResourceManager.Compute.Models.VmDiskTypes? VmDiskType { get { throw null; } set { } }
    }
    public partial class DiskAccessCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.DiskAccess>
    {
        protected DiskAccessCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.DiskAccess Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DiskAccess>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DiskAccess>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskAccessDeleteOperation : Azure.Operation
    {
        protected DiskAccessDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskAccessUpdate
    {
        public DiskAccessUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DiskAccessUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.DiskAccess>
    {
        protected DiskAccessUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.DiskAccess Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DiskAccess>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DiskAccess>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DiskCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Disk>
    {
        protected DiskCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Disk Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Disk>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Disk>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskDeleteOperation : Azure.Operation
    {
        protected DiskDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DiskEncryptionSetCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.DiskEncryptionSet>
    {
        protected DiskEncryptionSetCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.DiskEncryptionSet Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskEncryptionSetDeleteOperation : Azure.Operation
    {
        protected DiskEncryptionSetDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskEncryptionSetIdentityType : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskEncryptionSetIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskEncryptionSetIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskEncryptionSetIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskEncryptionSetIdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskEncryptionSetIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskEncryptionSetIdentityType left, Azure.ResourceManager.Compute.Models.DiskEncryptionSetIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskEncryptionSetIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskEncryptionSetIdentityType left, Azure.ResourceManager.Compute.Models.DiskEncryptionSetIdentityType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class DiskEncryptionSetUpdate
    {
        public DiskEncryptionSetUpdate() { }
        public Azure.ResourceManager.Compute.Models.KeyForDiskEncryptionSet ActiveKey { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskEncryptionSetType? EncryptionType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public bool? RotationToLatestKeyVersionEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DiskEncryptionSetUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.DiskEncryptionSet>
    {
        protected DiskEncryptionSetUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.DiskEncryptionSet Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.DiskEncryptionSet>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskGrantAccessOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.AccessUri>
    {
        protected DiskGrantAccessOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.AccessUri Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.AccessUri>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.AccessUri>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskImageEncryption
    {
        public DiskImageEncryption() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
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
    public partial class DiskRestorePointGrantAccessOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.AccessUri>
    {
        protected DiskRestorePointGrantAccessOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.AccessUri Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.AccessUri>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.AccessUri>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskRestorePointRevokeAccessOperation : Azure.Operation
    {
        protected DiskRestorePointRevokeAccessOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskRevokeAccessOperation : Azure.Operation
    {
        protected DiskRevokeAccessOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskSecurityProfile
    {
        public DiskSecurityProfile() { }
        public string SecureVmDiskEncryptionSetId { get { throw null; } set { } }
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
        public static Azure.ResourceManager.Compute.Models.DiskState ActiveSAS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskState ActiveSASFrozen { get { throw null; } }
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
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes StandardSSDLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes StandardSSDZRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskStorageAccountTypes UltraSSDLRS { get { throw null; } }
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
    public partial class DiskUpdate
    {
        public DiskUpdate() { }
        public bool? BurstingEnabled { get { throw null; } set { } }
        public string DiskAccessId { get { throw null; } set { } }
        public long? DiskIopsReadOnly { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadOnly { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingsCollection EncryptionSettingsCollection { get { throw null; } set { } }
        public int? MaxShares { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PropertyUpdatesInProgress PropertyUpdatesInProgress { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskPurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SupportedCapabilities SupportedCapabilities { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class DiskUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Disk>
    {
        protected DiskUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Disk Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Disk>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Disk>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Encryption
    {
        public Encryption() { }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionType? Type { get { throw null; } set { } }
    }
    public partial class EncryptionImages
    {
        public EncryptionImages() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDiskImageEncryption> DataDiskImages { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OSDiskImageEncryption OSDiskImage { get { throw null; } set { } }
    }
    public partial class EncryptionSettingsCollection
    {
        public EncryptionSettingsCollection(bool enabled) { }
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
    public readonly partial struct ExpandTypesForGetVirtualMachineScaleSets : System.IEquatable<Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpandTypesForGetVirtualMachineScaleSets(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets UserData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets left, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets left, Azure.ResourceManager.Compute.Models.ExpandTypesForGetVirtualMachineScaleSets right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportRequestRateByIntervalLogAnalyticOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.LogAnalytics>
    {
        protected ExportRequestRateByIntervalLogAnalyticOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.LogAnalytics Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.LogAnalytics>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.LogAnalytics>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExportThrottledRequestsLogAnalyticOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.LogAnalytics>
    {
        protected ExportThrottledRequestsLogAnalyticOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.LogAnalytics Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.LogAnalytics>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.LogAnalytics>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedLocation
    {
        public ExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ExtendedLocationTypes? Type { get { throw null; } set { } }
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
    public partial class Extension
    {
        public Extension() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CloudServiceExtensionProperties Properties { get { throw null; } set { } }
    }
    public partial class GalleryApplicationCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.GalleryApplication>
    {
        protected GalleryApplicationCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.GalleryApplication Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryApplication>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryApplication>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationDeleteOperation : Azure.Operation
    {
        protected GalleryApplicationDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationUpdate : Azure.ResourceManager.Compute.Models.UpdateResourceDefinition
    {
        public GalleryApplicationUpdate() { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } set { } }
        public string Eula { get { throw null; } set { } }
        public System.Uri PrivacyStatementUri { get { throw null; } set { } }
        public System.Uri ReleaseNoteUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? SupportedOSType { get { throw null; } set { } }
    }
    public partial class GalleryApplicationUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.GalleryApplication>
    {
        protected GalleryApplicationUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.GalleryApplication Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryApplication>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryApplication>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationVersionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.GalleryApplicationVersion>
    {
        protected GalleryApplicationVersionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.GalleryApplicationVersion Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryApplicationVersionDeleteOperation : Azure.Operation
    {
        protected GalleryApplicationVersionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class GalleryApplicationVersionUpdate : Azure.ResourceManager.Compute.Models.UpdateResourceDefinition
    {
        public GalleryApplicationVersionUpdate() { }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryApplicationVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
    }
    public partial class GalleryApplicationVersionUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.GalleryApplicationVersion>
    {
        protected GalleryApplicationVersionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.GalleryApplicationVersion Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryApplicationVersion>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryArtifactPublishingProfileBase
    {
        public GalleryArtifactPublishingProfileBase() { }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } set { } }
        public bool? ExcludeFromLatest { get { throw null; } set { } }
        public System.DateTimeOffset? PublishedDate { get { throw null; } }
        public int? ReplicaCount { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationMode? ReplicationMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.TargetRegion> TargetRegions { get { throw null; } }
    }
    public partial class GalleryArtifactVersionSource
    {
        public GalleryArtifactVersionSource() { }
        public string Id { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
    }
    public partial class GalleryCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Gallery>
    {
        protected GalleryCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Gallery Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Gallery>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Gallery>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryDataDiskImage : Azure.ResourceManager.Compute.Models.GalleryDiskImage
    {
        public GalleryDataDiskImage(int lun) { }
        public int Lun { get { throw null; } set { } }
    }
    public partial class GalleryDeleteOperation : Azure.Operation
    {
        protected GalleryDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryDiskImage
    {
        public GalleryDiskImage() { }
        public Azure.ResourceManager.Compute.Models.HostCaching? HostCaching { get { throw null; } set { } }
        public int? SizeInGB { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryArtifactVersionSource Source { get { throw null; } set { } }
    }
    public partial class GalleryIdentifier
    {
        public GalleryIdentifier() { }
        public string UniqueName { get { throw null; } }
    }
    public partial class GalleryImageCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.GalleryImage>
    {
        protected GalleryImageCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.GalleryImage Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryImage>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryImage>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageDeleteOperation : Azure.Operation
    {
        protected GalleryImageDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class GalleryImageUpdate : Azure.ResourceManager.Compute.Models.UpdateResourceDefinition
    {
        public GalleryImageUpdate() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Disallowed Disallowed { get { throw null; } set { } }
        public System.DateTimeOffset? EndOfLifeDate { get { throw null; } set { } }
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
    public partial class GalleryImageUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.GalleryImage>
    {
        protected GalleryImageUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.GalleryImage Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryImage>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryImage>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageVersionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.GalleryImageVersion>
    {
        protected GalleryImageVersionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.GalleryImageVersion Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryImageVersionDeleteOperation : Azure.Operation
    {
        protected GalleryImageVersionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class GalleryImageVersionUpdate : Azure.ResourceManager.Compute.Models.UpdateResourceDefinition
    {
        public GalleryImageVersionUpdate() { }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionPublishingProfile PublishingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ReplicationStatus ReplicationStatus { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.GalleryImageVersionStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class GalleryImageVersionUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.GalleryImageVersion>
    {
        protected GalleryImageVersionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.GalleryImageVersion Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.GalleryImageVersion>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryOSDiskImage : Azure.ResourceManager.Compute.Models.GalleryDiskImage
    {
        public GalleryOSDiskImage() { }
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
    public partial class GalleryUpdate : Azure.ResourceManager.Compute.Models.UpdateResourceDefinition
    {
        public GalleryUpdate() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryIdentifier Identifier { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.GalleryPropertiesProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SharingProfile SharingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SoftDeletePolicy SoftDeletePolicy { get { throw null; } set { } }
    }
    public partial class GalleryUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Gallery>
    {
        protected GalleryUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Gallery Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Gallery>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Gallery>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GalleryUpdateSharingProfileOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.SharingUpdate>
    {
        protected GalleryUpdateSharingProfileOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.SharingUpdate Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.SharingUpdate>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.SharingUpdate>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GrantAccessData
    {
        public GrantAccessData(Azure.ResourceManager.Compute.Models.AccessLevel access, int durationInSeconds) { }
        public Azure.ResourceManager.Compute.Models.AccessLevel Access { get { throw null; } }
        public int DurationInSeconds { get { throw null; } }
        public bool? GetSecureVmGuestStateSAS { get { throw null; } set { } }
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
    public partial class ImageCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Image>
    {
        protected ImageCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Image Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Image>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Image>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImageDataDisk : Azure.ResourceManager.Compute.Models.ImageDisk
    {
        public ImageDataDisk(int lun) { }
        public int Lun { get { throw null; } set { } }
    }
    public partial class ImageDeleteOperation : Azure.Operation
    {
        protected ImageDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImageDisk
    {
        public ImageDisk() { }
        public System.Uri BlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource DiskEncryptionSet { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource ManagedDisk { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource Snapshot { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
    }
    public partial class ImageDiskReference
    {
        public ImageDiskReference(string id) { }
        public string Id { get { throw null; } set { } }
        public int? Lun { get { throw null; } set { } }
    }
    public partial class ImageOSDisk : Azure.ResourceManager.Compute.Models.ImageDisk
    {
        public ImageOSDisk(Azure.ResourceManager.Compute.Models.OperatingSystemTypes oSType, Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes oSState) { }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateTypes OSState { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes OSType { get { throw null; } set { } }
    }
    public partial class ImagePurchasePlan
    {
        public ImagePurchasePlan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    public partial class ImageReference : Azure.ResourceManager.Compute.Models.SubResource
    {
        public ImageReference() { }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
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
    public partial class ImageUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public ImageUpdate() { }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationTypes? HyperVGeneration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVirtualMachine { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageStorageProfile StorageProfile { get { throw null; } set { } }
    }
    public partial class ImageUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Image>
    {
        protected ImageUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Image Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Image>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Image>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class InstanceViewStatusesSummary
    {
        internal InstanceViewStatusesSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.StatusCodeCount> StatusesSummary { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPVersions : System.IEquatable<Azure.ResourceManager.Compute.Models.IPVersions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPVersions(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.IPVersions IPv4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.IPVersions IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.IPVersions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.IPVersions left, Azure.ResourceManager.Compute.Models.IPVersions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.IPVersions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.IPVersions left, Azure.ResourceManager.Compute.Models.IPVersions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyForDiskEncryptionSet
    {
        public KeyForDiskEncryptionSet(string keyUrl) { }
        public string KeyUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
    }
    public partial class KeyVaultAndKeyReference
    {
        public KeyVaultAndKeyReference(Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault, string keyUrl) { }
        public string KeyUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
    }
    public partial class KeyVaultAndSecretReference
    {
        public KeyVaultAndSecretReference(Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault, string secretUrl) { }
        public string SecretUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
    }
    public partial class KeyVaultKeyReference
    {
        public KeyVaultKeyReference(string keyUrl, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public string KeyUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
    }
    public partial class KeyVaultSecretReference
    {
        public KeyVaultSecretReference(string secretUrl, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public string SecretUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
    }
    public partial class LastPatchInstallationSummary
    {
        internal LastPatchInstallationSummary() { }
        public Azure.ResourceManager.Compute.Models.ApiError Error { get { throw null; } }
        public int? ExcludedPatchCount { get { throw null; } }
        public int? FailedPatchCount { get { throw null; } }
        public string InstallationActivityId { get { throw null; } }
        public int? InstalledPatchCount { get { throw null; } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public bool? MaintenanceWindowExceeded { get { throw null; } }
        public int? NotSelectedPatchCount { get { throw null; } }
        public int? PendingPatchCount { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchOperationStatus? Status { get { throw null; } }
    }
    public partial class LinuxConfiguration
    {
        public LinuxConfiguration() { }
        public bool? DisablePasswordAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SshConfiguration Ssh { get { throw null; } set { } }
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
        public LoadBalancerConfiguration(string name, Azure.ResourceManager.Compute.Models.LoadBalancerConfigurationProperties properties) { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LoadBalancerConfigurationProperties Properties { get { throw null; } set { } }
    }
    public partial class LoadBalancerConfigurationProperties
    {
        public LoadBalancerConfigurationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.LoadBalancerFrontendIPConfiguration> frontendIPConfigurations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.LoadBalancerFrontendIPConfiguration> FrontendIPConfigurations { get { throw null; } }
    }
    public partial class LoadBalancerFrontendIPConfiguration
    {
        public LoadBalancerFrontendIPConfiguration(string name, Azure.ResourceManager.Compute.Models.LoadBalancerFrontendIPConfigurationProperties properties) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LoadBalancerFrontendIPConfigurationProperties Properties { get { throw null; } set { } }
    }
    public partial class LoadBalancerFrontendIPConfigurationProperties
    {
        public LoadBalancerFrontendIPConfigurationProperties() { }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource PublicIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource Subnet { get { throw null; } set { } }
    }
    public partial class LogAnalytics
    {
        internal LogAnalytics() { }
        public Azure.ResourceManager.Compute.Models.LogAnalyticsOutput Properties { get { throw null; } }
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
    public partial class LogAnalyticsOutput
    {
        internal LogAnalyticsOutput() { }
        public string Output { get { throw null; } }
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
        public System.DateTimeOffset? MaintenanceWindowEndTime { get { throw null; } }
        public System.DateTimeOffset? MaintenanceWindowStartTime { get { throw null; } }
        public System.DateTimeOffset? PreMaintenanceWindowEndTime { get { throw null; } }
        public System.DateTimeOffset? PreMaintenanceWindowStartTime { get { throw null; } }
    }
    public partial class ManagedDiskParameters : Azure.ResourceManager.Compute.Models.SubResource
    {
        public ManagedDiskParameters() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource DiskEncryptionSet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
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
    public partial class NetworkInterfaceReference : Azure.ResourceManager.Compute.Models.SubResource
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
    public partial class OrchestrationServiceStateInput
    {
        public OrchestrationServiceStateInput(Azure.ResourceManager.Compute.Models.OrchestrationServiceNames serviceName, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction action) { }
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
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Image { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ManagedDiskParameters ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Vhd { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
    }
    public partial class OSDiskImage
    {
        public OSDiskImage(Azure.ResourceManager.Compute.Models.OperatingSystemTypes operatingSystem) { }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes OperatingSystem { get { throw null; } set { } }
    }
    public partial class OSDiskImageEncryption : Azure.ResourceManager.Compute.Models.DiskImageEncryption
    {
        public OSDiskImageEncryption() { }
    }
    public partial class OSFamilyProperties
    {
        internal OSFamilyProperties() { }
        public string Label { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.OSVersionPropertiesBase> Versions { get { throw null; } }
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
    public partial class OSVersionProperties
    {
        internal OSVersionProperties() { }
        public string Family { get { throw null; } }
        public string FamilyLabel { get { throw null; } }
        public bool? IsActive { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        public string Label { get { throw null; } }
        public string Version { get { throw null; } }
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
    public partial class PirCommunityGalleryResource
    {
        internal PirCommunityGalleryResource() { }
        public string Location { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        public string UniqueId { get { throw null; } }
    }
    public partial class PirResource
    {
        internal PirResource() { }
        public string Location { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class PirSharedGalleryResource : Azure.ResourceManager.Compute.Models.PirResource
    {
        internal PirSharedGalleryResource() { }
        public string UniqueId { get { throw null; } }
    }
    public partial class Plan
    {
        public Plan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionDeleteOperation : Azure.Operation
    {
        protected PrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Compute.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Models.Resource
    {
        internal PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class PrivateLinkResourceListResult
    {
        internal PrivateLinkResourceListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.PrivateLinkResource> Value { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class PropertyUpdatesInProgress
    {
        internal PropertyUpdatesInProgress() { }
        public string TargetTier { get { throw null; } }
    }
    public enum ProtocolTypes
    {
        Http = 0,
        Https = 1,
    }
    public partial class ProximityPlacementGroupCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.ProximityPlacementGroup>
    {
        protected ProximityPlacementGroupCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.ProximityPlacementGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProximityPlacementGroupDeleteOperation : Azure.Operation
    {
        protected ProximityPlacementGroupDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ProximityPlacementGroupUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public ProximityPlacementGroupUpdate() { }
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
    public partial class RequestRateByIntervalInput : Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase
    {
        public RequestRateByIntervalInput(System.Uri blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, Azure.ResourceManager.Compute.Models.IntervalInMins intervalLength) : base (default(System.Uri), default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
        public Azure.ResourceManager.Compute.Models.IntervalInMins IntervalLength { get { throw null; } }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        SystemAssignedUserAssigned = 2,
        None = 3,
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
    public partial class ResourceSku
    {
        internal ResourceSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuCosts> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class ResourceSkuCapabilities
    {
        internal ResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ResourceSkuCapacity
    {
        internal ResourceSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
    }
    public enum ResourceSkuCapacityScaleType
    {
        Automatic = 0,
        Manual = 1,
        None = 2,
    }
    public partial class ResourceSkuCosts
    {
        internal ResourceSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterID { get { throw null; } }
        public long? Quantity { get { throw null; } }
    }
    public partial class ResourceSkuLocationInfo
    {
        internal ResourceSkuLocationInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> ExtendedLocations { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ExtendedLocationType? Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuRestrictionInfo
    {
        internal ResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuRestrictions
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.Compute.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ResourceSkuRestrictionsType? Type { get { throw null; } }
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
    public partial class RestorePointCollectionSourceProperties
    {
        public RestorePointCollectionSourceProperties() { }
        public string Id { get { throw null; } set { } }
        public string Location { get { throw null; } }
    }
    public partial class RestorePointCollectionUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public RestorePointCollectionUpdate() { }
        public string ProvisioningState { get { throw null; } }
        public string RestorePointCollectionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.RestorePointData> RestorePoints { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointCollectionSourceProperties Source { get { throw null; } set { } }
    }
    public partial class RestorePointCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.RestorePoint>
    {
        protected RestorePointCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.RestorePoint Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.RestorePoint>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.RestorePoint>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointDeleteOperation : Azure.Operation
    {
        protected RestorePointDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointGroupCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.RestorePointGroup>
    {
        protected RestorePointGroupCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.RestorePointGroup Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroup>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointGroupDeleteOperation : Azure.Operation
    {
        protected RestorePointGroupDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointSourceMetadata
    {
        internal RestorePointSourceMetadata() { }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OSProfile OSProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile StorageProfile { get { throw null; } }
        public string VmId { get { throw null; } }
    }
    public partial class RestorePointSourceVmDataDisk
    {
        internal RestorePointSourceVmDataDisk() { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource DiskRestorePoint { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } }
        public int? Lun { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ManagedDiskParameters ManagedDisk { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class RestorePointSourceVmOSDisk
    {
        internal RestorePointSourceVmOSDisk() { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource DiskRestorePoint { get { throw null; } }
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
    public partial class RoleInstanceDeleteOperation : Azure.Operation
    {
        protected RoleInstanceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleInstanceNetworkProfile
    {
        internal RoleInstanceNetworkProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WritableSubResource> NetworkInterfaces { get { throw null; } }
    }
    public partial class RoleInstanceProperties
    {
        internal RoleInstanceProperties() { }
        public Azure.ResourceManager.Compute.Models.RoleInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RoleInstanceNetworkProfile NetworkProfile { get { throw null; } }
    }
    public partial class RoleInstanceRebuildOperation : Azure.Operation
    {
        protected RoleInstanceRebuildOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleInstanceReimageOperation : Azure.Operation
    {
        protected RoleInstanceReimageOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleInstanceRestartOperation : Azure.Operation
    {
        protected RoleInstanceRestartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? LastActionTime { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
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
        public string Type { get { throw null; } }
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
    public partial class ScheduledEventsProfile
    {
        public ScheduledEventsProfile() { }
        public Azure.ResourceManager.Compute.Models.TerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
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
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SharingProfileGroupTypes? Type { get { throw null; } set { } }
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
    public partial class Sku
    {
        public Sku() { }
        public long? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class SnapshotCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Snapshot>
    {
        protected SnapshotCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Snapshot Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Snapshot>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Snapshot>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotDeleteOperation : Azure.Operation
    {
        protected SnapshotDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotGrantAccessOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.AccessUri>
    {
        protected SnapshotGrantAccessOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.AccessUri Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.AccessUri>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.AccessUri>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotRevokeAccessOperation : Azure.Operation
    {
        protected SnapshotRevokeAccessOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SnapshotUpdate
    {
        public SnapshotUpdate() { }
        public string DiskAccessId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.EncryptionSettingsCollection EncryptionSettingsCollection { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemTypes? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SnapshotSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SupportedCapabilities SupportedCapabilities { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SnapshotUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.Snapshot>
    {
        protected SnapshotUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Snapshot Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Snapshot>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Snapshot>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SoftDeletePolicy
    {
        public SoftDeletePolicy() { }
        public bool? IsSoftDeleteEnabled { get { throw null; } set { } }
    }
    public partial class SpotRestorePolicy
    {
        public SpotRestorePolicy() { }
        public bool? Enabled { get { throw null; } set { } }
        public string RestoreTimeout { get { throw null; } set { } }
    }
    public partial class SshConfiguration
    {
        public SshConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SshPublicKeyInfo> PublicKeys { get { throw null; } }
    }
    public partial class SshPublicKeyCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.SshPublicKey>
    {
        protected SshPublicKeyCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.SshPublicKey Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.SshPublicKey>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.SshPublicKey>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SshPublicKeyDeleteOperation : Azure.Operation
    {
        protected SshPublicKeyDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SshPublicKeyGenerateKeyPairResult
    {
        internal SshPublicKeyGenerateKeyPairResult() { }
        public string Id { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
    }
    public partial class SshPublicKeyInfo
    {
        public SshPublicKeyInfo() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    public partial class SshPublicKeyUpdateResource : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public SshPublicKeyUpdateResource() { }
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
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes StandardSSDLRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes StandardSSDZRS { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountTypes UltraSSDLRS { get { throw null; } }
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
    public partial class SubResource
    {
        public SubResource() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class SubResourceReadOnly
    {
        public SubResourceReadOnly() { }
        public string Id { get { throw null; } }
    }
    public partial class SubResourceWithColocationStatus : Azure.ResourceManager.Compute.Models.SubResource
    {
        public SubResourceWithColocationStatus() { }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
    }
    public partial class SupportedCapabilities
    {
        public SupportedCapabilities() { }
        public bool? AcceleratedNetwork { get { throw null; } set { } }
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
    public partial class ThrottledRequestsInput : Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase
    {
        public ThrottledRequestsInput(System.Uri blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime) : base (default(System.Uri), default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
    }
    public partial class UefiSettings
    {
        public UefiSettings() { }
        public bool? SecureBootEnabled { get { throw null; } set { } }
        public bool? VTpmEnabled { get { throw null; } set { } }
    }
    public partial class UpdateDomain
    {
        public UpdateDomain() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class UpdateResource
    {
        public UpdateResource() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class UpdateResourceDefinition : Azure.ResourceManager.Models.Resource
    {
        public UpdateResourceDefinition() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties Properties { get { throw null; } }
        public string Type { get { throw null; } }
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
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
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
    public partial class Usage
    {
        internal Usage() { }
        public int CurrentValue { get { throw null; } }
        public long Limit { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
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
        public string CertificateUrl { get { throw null; } set { } }
    }
    public partial class VaultSecretGroup
    {
        public VaultSecretGroup() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource SourceVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultCertificate> VaultCertificates { get { throw null; } }
    }
    public partial class VirtualHardDisk
    {
        public VirtualHardDisk() { }
        public string Uri { get { throw null; } set { } }
    }
    public partial class VirtualMachineAgentInstanceView
    {
        internal VirtualMachineAgentInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView> ExtensionHandlers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public string VmAgentVersion { get { throw null; } }
    }
    public partial class VirtualMachineAssessPatchesOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>
    {
        protected VirtualMachineAssessPatchesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? StartDateTime { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchOperationStatus? Status { get { throw null; } }
    }
    public partial class VirtualMachineCaptureOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>
    {
        protected VirtualMachineCaptureOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCaptureParameters
    {
        public VirtualMachineCaptureParameters(string vhdPrefix, string destinationContainerName, bool overwriteVhds) { }
        public string DestinationContainerName { get { throw null; } }
        public bool OverwriteVhds { get { throw null; } }
        public string VhdPrefix { get { throw null; } }
    }
    public partial class VirtualMachineCaptureResult : Azure.ResourceManager.Compute.Models.SubResource
    {
        public VirtualMachineCaptureResult() { }
        public string ContentVersion { get { throw null; } }
        public object Parameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<object> Resources { get { throw null; } }
        public string Schema { get { throw null; } }
    }
    public partial class VirtualMachineConvertToManagedDisksOperation : Azure.Operation
    {
        protected VirtualMachineConvertToManagedDisksOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachine>
    {
        protected VirtualMachineCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachine Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachine>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachine>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineDeallocateOperation : Azure.Operation
    {
        protected VirtualMachineDeallocateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineDeleteOperation : Azure.Operation
    {
        protected VirtualMachineDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class VirtualMachineExtensionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineExtension>
    {
        protected VirtualMachineExtensionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineExtensionDeleteOperation : Azure.Operation
    {
        protected VirtualMachineExtensionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineExtensionHandlerInstanceView
    {
        internal VirtualMachineExtensionHandlerInstanceView() { }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus Status { get { throw null; } }
        public string Type { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
    }
    public partial class VirtualMachineExtensionInstanceView
    {
        public VirtualMachineExtensionInstanceView() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Substatuses { get { throw null; } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionsListResult
    {
        internal VirtualMachineExtensionsListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.VirtualMachineExtensionData> Value { get { throw null; } }
    }
    public partial class VirtualMachineExtensionUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public VirtualMachineExtensionUpdate() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public object ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VirtualMachineExtensionUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineExtension>
    {
        protected VirtualMachineExtensionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineHealthStatus
    {
        internal VirtualMachineHealthStatus() { }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus Status { get { throw null; } }
    }
    public partial class VirtualMachineImage : Azure.ResourceManager.Compute.Models.VirtualMachineImageResource
    {
        public VirtualMachineImage(string name, string location) : base (default(string), default(string)) { }
        public Azure.ResourceManager.Compute.Models.AutomaticOSUpgradeProperties AutomaticOSUpgradeProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDiskImage> DataDiskImages { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DisallowedConfiguration Disallowed { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGenerationTypes? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSDiskImage OSDiskImage { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PurchasePlan Plan { get { throw null; } set { } }
    }
    public partial class VirtualMachineImageFeature
    {
        public VirtualMachineImageFeature() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class VirtualMachineImageResource : Azure.ResourceManager.Compute.Models.SubResource
    {
        public VirtualMachineImageResource(string name, string location) { }
        public Azure.ResourceManager.Compute.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VirtualMachineInstallPatchesOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>
    {
        protected VirtualMachineInstallPatchesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineInstallPatchesParameters
    {
        public VirtualMachineInstallPatchesParameters(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting rebootSetting) { }
        public Azure.ResourceManager.Compute.Models.LinuxParameters LinuxParameters { get { throw null; } set { } }
        public string MaximumDuration { get { throw null; } set { } }
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
        public System.DateTimeOffset? StartDateTime { get { throw null; } }
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
        public Azure.ResourceManager.Compute.Models.VirtualMachineHealthStatus VmHealth { get { throw null; } }
    }
    public partial class VirtualMachineIpTag
    {
        public VirtualMachineIpTag() { }
        public string IpTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class VirtualMachineNetworkInterfaceConfiguration
    {
        public VirtualMachineNetworkInterfaceConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceDnsSettingsConfiguration DnsSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource DscpConfiguration { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration> IpConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource NetworkSecurityGroup { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class VirtualMachineNetworkInterfaceDnsSettingsConfiguration
    {
        public VirtualMachineNetworkInterfaceDnsSettingsConfiguration() { }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
    }
    public partial class VirtualMachineNetworkInterfaceIPConfiguration
    {
        public VirtualMachineNetworkInterfaceIPConfiguration(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersions? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource Subnet { get { throw null; } set { } }
    }
    public partial class VirtualMachinePatchStatus
    {
        internal VirtualMachinePatchStatus() { }
        public Azure.ResourceManager.Compute.Models.AvailablePatchSummary AvailablePatchSummary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> ConfigurationStatuses { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary LastPatchInstallationSummary { get { throw null; } }
    }
    public partial class VirtualMachinePerformMaintenanceOperation : Azure.Operation
    {
        protected VirtualMachinePerformMaintenanceOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachinePowerOffOperation : Azure.Operation
    {
        protected VirtualMachinePowerOffOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachinePowerOnOperation : Azure.Operation
    {
        protected VirtualMachinePowerOnOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineIpTag> IpTags { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersions? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod? PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource PublicIPPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PublicIPAddressSku Sku { get { throw null; } set { } }
    }
    public partial class VirtualMachinePublicIPAddressDnsSettingsConfiguration
    {
        public VirtualMachinePublicIPAddressDnsSettingsConfiguration(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
    }
    public partial class VirtualMachineReapplyOperation : Azure.Operation
    {
        protected VirtualMachineReapplyOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineRedeployOperation : Azure.Operation
    {
        protected VirtualMachineRedeployOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineReimageOperation : Azure.Operation
    {
        protected VirtualMachineReimageOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineReimageParameters
    {
        public VirtualMachineReimageParameters() { }
        public bool? TempDisk { get { throw null; } set { } }
    }
    public partial class VirtualMachineRestartOperation : Azure.Operation
    {
        protected VirtualMachineRestartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineRunCommandCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineRunCommand>
    {
        protected VirtualMachineRunCommandCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineRunCommand Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineRunCommandDeleteOperation : Azure.Operation
    {
        protected VirtualMachineRunCommandDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineRunCommandInstanceView
    {
        internal VirtualMachineRunCommandInstanceView() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string Error { get { throw null; } }
        public string ExecutionMessage { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ExecutionState? ExecutionState { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public string Output { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
    }
    public partial class VirtualMachineRunCommandOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.RunCommandResult>
    {
        protected VirtualMachineRunCommandOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.RunCommandResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineRunCommandScriptSource
    {
        public VirtualMachineRunCommandScriptSource() { }
        public string CommandId { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Uri ScriptUri { get { throw null; } set { } }
    }
    public partial class VirtualMachineRunCommandUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
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
    public partial class VirtualMachineRunCommandUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineRunCommand>
    {
        protected VirtualMachineRunCommandUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineRunCommand Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineRunCommand>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetCancelVirtualMachineScaleSetRollingUpgradeOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetCancelVirtualMachineScaleSetRollingUpgradeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetConvertToSinglePlacementGroupOptions
    {
        public VirtualMachineScaleSetConvertToSinglePlacementGroupOptions() { }
        public string ActivePlacementGroupId { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineScaleSet>
    {
        protected VirtualMachineScaleSetCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineScaleSet Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class VirtualMachineScaleSetDeallocateOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetDeallocateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetDeleteInstancesOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetDeleteInstancesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetDeleteOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>
    {
        protected VirtualMachineScaleSetExtensionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionDeleteOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetExtensionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionProfile
    {
        public VirtualMachineScaleSetExtensionProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData> Extensions { get { throw null; } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetExtensionUpdate : Azure.ResourceManager.Compute.Models.SubResourceReadOnly
    {
        public VirtualMachineScaleSetExtensionUpdate() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public object ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetExtensionUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>
    {
        protected VirtualMachineScaleSetExtensionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetInstanceView
    {
        internal VirtualMachineScaleSetInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary> Extensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary> OrchestrationServices { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceViewStatusesSummary VirtualMachine { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetInstanceViewStatusesSummary
    {
        internal VirtualMachineScaleSetInstanceViewStatusesSummary() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount> StatusesSummary { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetIPConfiguration : Azure.ResourceManager.Compute.Models.SubResource
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
        public Azure.ResourceManager.Resources.Models.WritableSubResource Subnet { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetIpTag
    {
        public VirtualMachineScaleSetIpTag() { }
        public string IpTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetManagedDiskParameters
    {
        public VirtualMachineScaleSetManagedDiskParameters() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource DiskEncryptionSet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountTypes? StorageAccountType { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkConfiguration : Azure.ResourceManager.Compute.Models.SubResource
    {
        public VirtualMachineScaleSetNetworkConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration> IpConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource NetworkSecurityGroup { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetNetworkConfigurationDnsSettings
    {
        public VirtualMachineScaleSetNetworkConfigurationDnsSettings() { }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetNetworkProfile
    {
        public VirtualMachineScaleSetNetworkProfile() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource HealthProbe { get { throw null; } set { } }
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
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Image { get { throw null; } set { } }
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
    public partial class VirtualMachineScaleSetPerformMaintenanceOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetPerformMaintenanceOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetPowerOffOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetPowerOffOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetPowerOnOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetPowerOnOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration
    {
        public VirtualMachineScaleSetPublicIPAddressConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIpTag> IpTags { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource PublicIPPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PublicIPAddressSku Sku { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings
    {
        public VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetRedeployOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetRedeployOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetReimageAllOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetReimageAllOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetReimageOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetReimageOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetReimageParameters : Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageOptions
    {
        public VirtualMachineScaleSetReimageParameters() { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetRestartOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetRestartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class VirtualMachineScaleSetSetOrchestrationServiceStateOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetSetOrchestrationServiceStateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetSku
    {
        internal VirtualMachineScaleSetSku() { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } }
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
        Automatic = 0,
        None = 1,
    }
    public partial class VirtualMachineScaleSetStartExtensionUpgradeVirtualMachineScaleSetRollingUpgradeOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetStartExtensionUpgradeVirtualMachineScaleSetRollingUpgradeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetStartOSUpgradeOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetStartOSUpgradeOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetStorageProfile
    {
        public VirtualMachineScaleSetStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk OSDisk { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public VirtualMachineScaleSetUpdate() { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public bool? DoNotRunExtensionsOnOverprovisionedVms { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? Overprovision { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Plan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public bool? SinglePlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Sku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile VirtualMachineProfile { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateInstancesOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetUpdateInstancesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateIPConfiguration : Azure.ResourceManager.Compute.Models.SubResource
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
        public Azure.ResourceManager.Resources.Models.WritableSubResource Subnet { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateNetworkConfiguration : Azure.ResourceManager.Compute.Models.SubResource
    {
        public VirtualMachineScaleSetUpdateNetworkConfiguration() { }
        public Azure.ResourceManager.Compute.Models.DeleteOptions? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration> IpConfigurations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource NetworkSecurityGroup { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetUpdateNetworkProfile
    {
        public VirtualMachineScaleSetUpdateNetworkProfile() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource HealthProbe { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineScaleSet>
    {
        protected VirtualMachineScaleSetUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineScaleSet Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSet>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateOSDisk
    {
        public VirtualMachineScaleSetUpdateOSDisk() { }
        public Azure.ResourceManager.Compute.Models.CachingTypes? Caching { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualHardDisk Image { get { throw null; } set { } }
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
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
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
        public Azure.ResourceManager.Compute.Models.BillingProfile BillingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
    }
    public partial class VirtualMachineScaleSetVirtualMachineRunCommandCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>
    {
        protected VirtualMachineScaleSetVirtualMachineRunCommandCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVirtualMachineRunCommandDeleteOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVirtualMachineRunCommandDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVirtualMachineRunCommandUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>
    {
        protected VirtualMachineScaleSetVirtualMachineRunCommandUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVirtualMachineRunCommand>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>
    {
        protected VirtualMachineScaleSetVmCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineScaleSetVm Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVm>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmDeallocateOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVmDeallocateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmDeleteOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVmDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>
    {
        protected VirtualMachineScaleSetVmExtensionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionDeleteOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVmExtensionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionsListResult
    {
        internal VirtualMachineScaleSetVmExtensionsListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData> Value { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVmExtensionsSummary
    {
        internal VirtualMachineScaleSetVmExtensionsSummary() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount> StatusesSummary { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVmExtensionUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>
    {
        protected VirtualMachineScaleSetVmExtensionUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtension>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionUpdateOptions : Azure.ResourceManager.Compute.Models.SubResourceReadOnly
    {
        public VirtualMachineScaleSetVmExtensionUpdateOptions() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public object ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
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
        public Azure.ResourceManager.Compute.Models.VirtualMachineHealthStatus VmHealth { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVmNetworkProfileConfiguration
    {
        public VirtualMachineScaleSetVmNetworkProfileConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
    }
    public partial class VirtualMachineScaleSetVmPerformMaintenanceOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVmPerformMaintenanceOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmPowerOffOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVmPowerOffOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmPowerOnOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVmPowerOnOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmProfile
    {
        public VirtualMachineScaleSetVmProfile() { }
        public Azure.ResourceManager.Compute.Models.ApplicationProfile ApplicationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BillingProfile BillingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CapacityReservationProfile CapacityReservation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile OsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
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
    public partial class VirtualMachineScaleSetVmRedeployOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVmRedeployOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmReimageAllOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVmReimageAllOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmReimageOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVmReimageOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmReimageOptions : Azure.ResourceManager.Compute.Models.VirtualMachineReimageParameters
    {
        public VirtualMachineScaleSetVmReimageOptions() { }
    }
    public partial class VirtualMachineScaleSetVmRestartOperation : Azure.Operation
    {
        protected VirtualMachineScaleSetVmRestartOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmRunCommandOperation : Azure.Operation<Azure.ResourceManager.Compute.Models.RunCommandResult>
    {
        protected VirtualMachineScaleSetVmRunCommandOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.Models.RunCommandResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? LastModifiedDateTime { get { throw null; } }
        public string Name { get { throw null; } }
        public string PatchId { get { throw null; } }
        public System.DateTimeOffset? PublishedDate { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior? RebootBehavior { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class VirtualMachineStatusCodeCount
    {
        internal VirtualMachineStatusCodeCount() { }
        public string Code { get { throw null; } }
        public int? Count { get { throw null; } }
    }
    public partial class VirtualMachineUpdate : Azure.ResourceManager.Compute.Models.UpdateResource
    {
        public VirtualMachineUpdate() { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ApplicationProfile ApplicationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource AvailabilitySet { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BillingProfile BillingProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CapacityReservationProfile CapacityReservation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiagnosticsProfile DiagnosticsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyTypes? EvictionPolicy { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource Host { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource HostGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Plan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityTypes? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource ProximityPlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource VirtualMachineScaleSet { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class VirtualMachineUpdateOperation : Azure.Operation<Azure.ResourceManager.Compute.VirtualMachine>
    {
        protected VirtualMachineUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Compute.VirtualMachine Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachine>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Compute.VirtualMachine>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Compute.Models.WinRMConfiguration WinRM { get { throw null; } set { } }
    }
    public partial class WindowsParameters
    {
        public WindowsParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationWindows> ClassificationsToInclude { get { throw null; } }
        public bool? ExcludeKbsRequiringReboot { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KbNumbersToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> KbNumbersToInclude { get { throw null; } }
        public System.DateTimeOffset? MaxPatchPublishDate { get { throw null; } set { } }
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
    public partial class WinRMConfiguration
    {
        public WinRMConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.WinRMListener> Listeners { get { throw null; } }
    }
    public partial class WinRMListener
    {
        public WinRMListener() { }
        public string CertificateUrl { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ProtocolTypes? Protocol { get { throw null; } set { } }
    }
}
