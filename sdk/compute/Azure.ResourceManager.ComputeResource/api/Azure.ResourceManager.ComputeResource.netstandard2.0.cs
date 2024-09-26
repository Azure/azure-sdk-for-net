namespace Azure.ResourceManager.ComputeResource
{
    public partial class AvailabilitySetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>, System.Collections.IEnumerable
    {
        protected AvailabilitySetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string availabilitySetName, Azure.ResourceManager.ComputeResource.AvailabilitySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string availabilitySetName, Azure.ResourceManager.ComputeResource.AvailabilitySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> Get(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>> GetAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> GetIfExists(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>> GetIfExistsAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvailabilitySetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>
    {
        public AvailabilitySetData(Azure.Core.AzureLocation location) { }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public int? PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.ComputeResource.AvailabilitySetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.AvailabilitySetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilitySetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvailabilitySetResource() { }
        public virtual Azure.ResourceManager.ComputeResource.AvailabilitySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string availabilitySetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize> GetAvailableSizes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize> GetAvailableSizesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.AvailabilitySetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.AvailabilitySetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.AvailabilitySetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> Update(Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>> UpdateAsync(Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.CapacityReservationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.CapacityReservationResource>, System.Collections.IEnumerable
    {
        protected CapacityReservationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.CapacityReservationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capacityReservationName, Azure.ResourceManager.ComputeResource.CapacityReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.CapacityReservationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capacityReservationName, Azure.ResourceManager.ComputeResource.CapacityReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capacityReservationName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capacityReservationName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource> Get(string capacityReservationName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.CapacityReservationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.CapacityReservationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource>> GetAsync(string capacityReservationName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.CapacityReservationResource> GetIfExists(string capacityReservationName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.CapacityReservationResource>> GetIfExistsAsync(string capacityReservationName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.CapacityReservationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.CapacityReservationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.CapacityReservationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.CapacityReservationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapacityReservationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>
    {
        public CapacityReservationData(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku) { }
        public Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView InstanceView { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeResource.CapacityReservationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.CapacityReservationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityReservationGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>, System.Collections.IEnumerable
    {
        protected CapacityReservationGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.CapacityReservationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.CapacityReservationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> Get(string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> GetAll(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> GetAllAsync(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>> GetAsync(string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> GetIfExists(string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>> GetIfExistsAsync(string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapacityReservationGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>
    {
        public CapacityReservationGroupData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> CapacityReservations { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView InstanceView { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> SharingSubscriptionIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeResource.CapacityReservationGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.CapacityReservationGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityReservationGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapacityReservationGroupResource() { }
        public virtual Azure.ResourceManager.ComputeResource.CapacityReservationGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string capacityReservationGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> Get(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>> GetAsync(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource> GetCapacityReservation(string capacityReservationName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource>> GetCapacityReservationAsync(string capacityReservationName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.CapacityReservationCollection GetCapacityReservations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.CapacityReservationGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.CapacityReservationGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> Update(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>> UpdateAsync(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapacityReservationResource() { }
        public virtual Azure.ResourceManager.ComputeResource.CapacityReservationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string capacityReservationGroupName, string capacityReservationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource> Get(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource>> GetAsync(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.CapacityReservationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.CapacityReservationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.CapacityReservationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.CapacityReservationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.CapacityReservationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ComputeResourceExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.LogAnalytics> ExportLogAnalyticsRequestRateByInterval(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>> ExportLogAnalyticsRequestRateByIntervalAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.LogAnalytics> ExportLogAnalyticsThrottledRequests(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>> ExportLogAnalyticsThrottledRequestsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> GetAvailabilitySet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>> GetAvailabilitySetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.AvailabilitySetResource GetAvailabilitySetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.AvailabilitySetCollection GetAvailabilitySets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> GetAvailabilitySets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> GetAvailabilitySetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> GetCapacityReservationGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>> GetCapacityReservationGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource GetCapacityReservationGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.CapacityReservationGroupCollection GetCapacityReservationGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> GetCapacityReservationGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand?), Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup? resourceIdsOnly = default(Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> GetCapacityReservationGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand?), Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup? resourceIdsOnly = default(Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.CapacityReservationResource GetCapacityReservationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> GetDedicatedHostGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hostGroupName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>> GetDedicatedHostGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hostGroupName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource GetDedicatedHostGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.DedicatedHostGroupCollection GetDedicatedHostGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> GetDedicatedHostGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> GetDedicatedHostGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.DedicatedHostResource GetDedicatedHostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource> GetDiskImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource>> GetDiskImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.DiskImageResource GetDiskImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.DiskImageCollection GetDiskImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.DiskImageResource> GetDiskImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.DiskImageResource> GetDiskImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetOffersVirtualMachineImagesEdgeZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetOffersVirtualMachineImagesEdgeZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> GetProximityPlacementGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>> GetProximityPlacementGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource GetProximityPlacementGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.ProximityPlacementGroupCollection GetProximityPlacementGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> GetProximityPlacementGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> GetProximityPlacementGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetPublishersVirtualMachineImagesEdgeZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetPublishersVirtualMachineImagesEdgeZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> GetRestorePointGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string restorePointGroupName, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>> GetRestorePointGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string restorePointGroupName, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.RestorePointGroupResource GetRestorePointGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.RestorePointGroupCollection GetRestorePointGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> GetRestorePointGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> GetRestorePointGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.RestorePointResource GetRestorePointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> GetSshPublicKey(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>> GetSshPublicKeyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.SshPublicKeyResource GetSshPublicKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.SshPublicKeyCollection GetSshPublicKeys(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> GetSshPublicKeys(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> GetSshPublicKeysAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetVirtualMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource>> GetVirtualMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> GetVirtualMachineExtensionImage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource>> GetVirtualMachineExtensionImageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource GetVirtualMachineExtensionImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource GetVirtualMachineExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage> GetVirtualMachineImage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>> GetVirtualMachineImageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageEdgeZoneSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageEdgeZoneSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageOffers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageOffersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagePublishers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagePublishersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagesByEdgeZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagesByEdgeZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage> GetVirtualMachineImagesEdgeZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>> GetVirtualMachineImagesEdgeZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagesEdgeZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagesEdgeZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineResource GetVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument> GetVirtualMachineRunCommand(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument>> GetVirtualMachineRunCommandAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource GetVirtualMachineRunCommandResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase> GetVirtualMachineRunCommands(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase> GetVirtualMachineRunCommandsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineCollection GetVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetVirtualMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string statusOnly = null, string filter = null, Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm? expand = default(Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetVirtualMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string statusOnly = null, string filter = null, Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm? expand = default(Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetVirtualMachinesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetVirtualMachinesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetVirtualMachineScaleSet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>> GetVirtualMachineScaleSetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource GetVirtualMachineScaleSetExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource GetVirtualMachineScaleSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeResource GetVirtualMachineScaleSetRollingUpgradeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetCollection GetVirtualMachineScaleSets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetVirtualMachineScaleSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource GetVirtualMachineScaleSetVmExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource GetVirtualMachineScaleSetVmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource GetVirtualMachineScaleSetVmRunCommandResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize> GetVirtualMachineSizes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize> GetVirtualMachineSizesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.DedicatedHostResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.DedicatedHostResource>, System.Collections.IEnumerable
    {
        protected DedicatedHostCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.DedicatedHostResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hostName, Azure.ResourceManager.ComputeResource.DedicatedHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.DedicatedHostResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hostName, Azure.ResourceManager.ComputeResource.DedicatedHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource> Get(string hostName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.DedicatedHostResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.DedicatedHostResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource>> GetAsync(string hostName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.DedicatedHostResource> GetIfExists(string hostName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.DedicatedHostResource>> GetIfExistsAsync(string hostName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.DedicatedHostResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.DedicatedHostResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.DedicatedHostResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.DedicatedHostResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHostData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>
    {
        public DedicatedHostData(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku) { }
        public bool? AutoReplaceOnFailure { get { throw null; } set { } }
        public string HostId { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.DedicatedHostLicenseType? LicenseType { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.ComputeResource.DedicatedHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.DedicatedHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>, System.Collections.IEnumerable
    {
        protected DedicatedHostGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hostGroupName, Azure.ResourceManager.ComputeResource.DedicatedHostGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hostGroupName, Azure.ResourceManager.ComputeResource.DedicatedHostGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostGroupName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostGroupName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> Get(string hostGroupName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>> GetAsync(string hostGroupName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> GetIfExists(string hostGroupName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>> GetIfExistsAsync(string hostGroupName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHostGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>
    {
        public DedicatedHostGroupData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> DedicatedHosts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName> InstanceViewHosts { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public bool? SupportAutomaticPlacement { get { throw null; } set { } }
        public bool? UltraSsdEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeResource.DedicatedHostGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.DedicatedHostGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedHostGroupResource() { }
        public virtual Azure.ResourceManager.ComputeResource.DedicatedHostGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> Get(Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>> GetAsync(Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource> GetDedicatedHost(string hostName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource>> GetDedicatedHostAsync(string hostName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.DedicatedHostCollection GetDedicatedHosts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.DedicatedHostGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.DedicatedHostGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> Update(Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>> UpdateAsync(Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedHostResource() { }
        public virtual Azure.ResourceManager.ComputeResource.DedicatedHostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostGroupName, string hostName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource> Get(Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource>> GetAsync(Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetAvailableSizes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetAvailableSizesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.DedicatedHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.DedicatedHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DedicatedHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.DedicatedHostResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.DedicatedHostResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.DiskImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.DiskImageResource>, System.Collections.IEnumerable
    {
        protected DiskImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.DiskImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.ComputeResource.DiskImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.DiskImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.ComputeResource.DiskImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource> Get(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.DiskImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.DiskImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource>> GetAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.DiskImageResource> GetIfExists(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.DiskImageResource>> GetIfExistsAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.DiskImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.DiskImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.DiskImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.DiskImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DiskImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DiskImageData>
    {
        public DiskImageData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceVirtualMachineId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile StorageProfile { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.DiskImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DiskImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DiskImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.DiskImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DiskImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DiskImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DiskImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DiskImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DiskImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskImageResource() { }
        public virtual Azure.ResourceManager.ComputeResource.DiskImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string imageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.DiskImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DiskImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.DiskImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.DiskImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DiskImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DiskImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.DiskImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.DiskImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.DiskImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.DiskImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.DiskImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProximityPlacementGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>, System.Collections.IEnumerable
    {
        protected ProximityPlacementGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string proximityPlacementGroupName, Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string proximityPlacementGroupName, Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> Get(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>> GetAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> GetIfExists(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>> GetIfExistsAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProximityPlacementGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>
    {
        public ProximityPlacementGroupData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus> AvailabilitySets { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IntentVmSizes { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType? ProximityPlacementGroupType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus> VirtualMachines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus> VirtualMachineScaleSets { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProximityPlacementGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProximityPlacementGroupResource() { }
        public virtual Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string proximityPlacementGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> Get(string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>> GetAsync(string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> Update(Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>> UpdateAsync(Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointCollection : Azure.ResourceManager.ArmCollection
    {
        protected RestorePointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.RestorePointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string restorePointName, Azure.ResourceManager.ComputeResource.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.RestorePointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string restorePointName, Azure.ResourceManager.ComputeResource.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string restorePointName, Azure.ResourceManager.ComputeResource.Models.RestorePointExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointName, Azure.ResourceManager.ComputeResource.Models.RestorePointExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointResource> Get(string restorePointName, Azure.ResourceManager.ComputeResource.Models.RestorePointExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointResource>> GetAsync(string restorePointName, Azure.ResourceManager.ComputeResource.Models.RestorePointExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.RestorePointResource> GetIfExists(string restorePointName, Azure.ResourceManager.ComputeResource.Models.RestorePointExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.RestorePointResource>> GetIfExistsAsync(string restorePointName, Azure.ResourceManager.ComputeResource.Models.RestorePointExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointData>
    {
        public RestorePointData() { }
        public Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType? ConsistencyMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ExcludeDisks { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView InstanceView { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata SourceMetadata { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceRestorePointId { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.RestorePointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.RestorePointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>, System.Collections.IEnumerable
    {
        protected RestorePointGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string restorePointGroupName, Azure.ResourceManager.ComputeResource.RestorePointGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string restorePointGroupName, Azure.ResourceManager.ComputeResource.RestorePointGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string restorePointGroupName, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointGroupName, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> Get(string restorePointGroupName, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>> GetAsync(string restorePointGroupName, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> GetIfExists(string restorePointGroupName, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>> GetIfExistsAsync(string restorePointGroupName, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorePointGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>
    {
        public RestorePointGroupData(Azure.Core.AzureLocation location) { }
        public string ProvisioningState { get { throw null; } }
        public string RestorePointGroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.RestorePointData> RestorePoints { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource Source { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.RestorePointGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.RestorePointGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePointGroupResource() { }
        public virtual Azure.ResourceManager.ComputeResource.RestorePointGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> Get(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>> GetAsync(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointResource> GetRestorePoint(string restorePointName, Azure.ResourceManager.ComputeResource.Models.RestorePointExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointResource>> GetRestorePointAsync(string restorePointName, Azure.ResourceManager.ComputeResource.Models.RestorePointExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.RestorePointCollection GetRestorePoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.RestorePointGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.RestorePointGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> Update(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>> UpdateAsync(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePointResource() { }
        public virtual Azure.ResourceManager.ComputeResource.RestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointGroupName, string restorePointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointResource> Get(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointResource>> GetAsync(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.RestorePointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.RestorePointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.RestorePointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.RestorePointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.RestorePointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.RestorePointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SshPublicKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>, System.Collections.IEnumerable
    {
        protected SshPublicKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sshPublicKeyName, Azure.ResourceManager.ComputeResource.SshPublicKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sshPublicKeyName, Azure.ResourceManager.ComputeResource.SshPublicKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> Get(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>> GetAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> GetIfExists(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>> GetIfExistsAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SshPublicKeyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>
    {
        public SshPublicKeyData(Azure.Core.AzureLocation location) { }
        public string PublicKey { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.SshPublicKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.SshPublicKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPublicKeyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SshPublicKeyResource() { }
        public virtual Azure.ResourceManager.ComputeResource.SshPublicKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sshPublicKeyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult> GenerateKeyPair(Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult>> GenerateKeyPairAsync(Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.SshPublicKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.SshPublicKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.SshPublicKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> Update(Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>> UpdateAsync(Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmName, Azure.ResourceManager.ComputeResource.VirtualMachineData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmName, Azure.ResourceManager.ComputeResource.VirtualMachineData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource> Get(string vmName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetAll(string filter = null, Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType? expand = default(Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetAllAsync(string filter = null, Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType? expand = default(Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource>> GetAsync(string vmName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetIfExists(string vmName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineResource>> GetIfExistsAsync(string vmName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>
    {
        public VirtualMachineData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AvailabilitySetId { get { throw null; } set { } }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData> Resources { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile StorageProfile { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UserData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineScaleSetId { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeResource.VirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmExtensionName, Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmExtensionName, Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> Get(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>> GetAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> GetIfExists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>> GetIfExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineExtensionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>
    {
        public VirtualMachineExtensionData(Azure.Core.AzureLocation location) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineExtensionImageCollection() { }
        public virtual Azure.Response<bool> Exists(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> Get(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> GetAll(string type, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> GetAllAsync(string type, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource>> GetAsync(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> GetIfExists(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource>> GetIfExistsAsync(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineExtensionImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>
    {
        public VirtualMachineExtensionImageData(Azure.Core.AzureLocation location) { }
        public string ComputeRole { get { throw null; } set { } }
        public string HandlerSchema { get { throw null; } set { } }
        public string OperatingSystem { get { throw null; } set { } }
        public bool? SupportsMultipleExtensions { get { throw null; } set { } }
        public bool? VirtualMachineScaleSetEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineExtensionImageResource() { }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string publisherName, string type, string version) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineExtensionResource() { }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string vmExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineResource() { }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult> AssessPatches(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult>> AssessPatchesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile> AttachDetachDataDisks(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest attachDetachDataDisksRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile>> AttachDetachDataDisksAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest attachDetachDataDisksRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult> Capture(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult>> CaptureAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ConvertToManagedDisks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ConvertToManagedDisksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, bool? hibernate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, bool? hibernate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Generalize(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GeneralizeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource> Get(Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource>> GetAsync(Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize> GetAvailableSizes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize> GetAvailableSizesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource> GetVirtualMachineExtension(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource>> GetVirtualMachineExtensionAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineExtensionCollection GetVirtualMachineExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> GetVirtualMachineRunCommand(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>> GetVirtualMachineRunCommandAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandCollection GetVirtualMachineRunCommands() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult> InstallPatches(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult>> InstallPatchesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView> InstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView>> InstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult> RetrieveBootDiagnosticsData(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult>> RetrieveBootDiagnosticsDataAsync(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult> RunCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult>> RunCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SimulateEviction(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SimulateEvictionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.VirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineRunCommandCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineRunCommandCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string runCommandName, Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string runCommandName, Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> Get(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>> GetAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> GetIfExists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>> GetIfExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineRunCommandData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>
    {
        public VirtualMachineRunCommandData(Azure.Core.AzureLocation location) { }
        public bool? AsyncExecution { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity ErrorBlobManagedIdentity { get { throw null; } set { } }
        public System.Uri ErrorBlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity OutputBlobManagedIdentity { get { throw null; } set { } }
        public System.Uri OutputBlobUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter> ProtectedParameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string RunAsPassword { get { throw null; } set { } }
        public string RunAsUser { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource Source { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public bool? TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRunCommandResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineRunCommandResource() { }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string runCommandName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> Get(string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>> GetAsync(string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetIfExists(string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>> GetIfExistsAsync(string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>
    {
        public VirtualMachineScaleSetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public bool? DoNotRunExtensionsOnOverprovisionedVms { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsMaximumCapacityConstrained { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.OrchestrationMode? OrchestrationMode { get { throw null; } set { } }
        public bool? Overprovision { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy PriorityMixPolicy { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy ResiliencyPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public bool? SinglePlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile SkuProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy SpotRestorePolicy { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile VirtualMachineProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode? ZonalPlatformFaultDomainAlignMode { get { throw null; } set { } }
        public bool? ZoneBalance { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmssExtensionName, Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmssExtensionName, Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource> Get(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource>> GetAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource> GetIfExists(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource>> GetIfExistsAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>
    {
        public VirtualMachineScaleSetExtensionData() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetExtensionResource() { }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string vmssExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetResource() { }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ApproveRollingUpgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ApproveRollingUpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CancelVirtualMachineScaleSetRollingUpgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelVirtualMachineScaleSetRollingUpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ConvertToSinglePlacementGroup(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ConvertToSinglePlacementGroupAsync(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? hibernate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? hibernate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteInstances(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteInstancesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse> ForceRecoveryServiceFabricPlatformUpdateDomainWalk(int platformUpdateDomain, string zone = null, string placementGroupId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse>> ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(int platformUpdateDomain, string zone = null, string placementGroupId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> Get(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>> GetAsync(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo> GetOSUpgradeHistory(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo> GetOSUpgradeHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource> GetVirtualMachineScaleSetExtension(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource>> GetVirtualMachineScaleSetExtensionAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionCollection GetVirtualMachineScaleSetExtensions() { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeResource GetVirtualMachineScaleSetRollingUpgrade() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> GetVirtualMachineScaleSetVm(string instanceId, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>> GetVirtualMachineScaleSetVmAsync(string instanceId, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmCollection GetVirtualMachineScaleSetVms() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PerformMaintenance(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PerformMaintenanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOff(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOffAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOn(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOnAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reapply(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReapplyAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReimageAll(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAllAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SetOrchestrationServiceState(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SetOrchestrationServiceStateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartExtensionUpgradeVirtualMachineScaleSetRollingUpgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartExtensionUpgradeVirtualMachineScaleSetRollingUpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartOSUpgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartOSUpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateInstances(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateInstancesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetRollingUpgradeData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>
    {
        public VirtualMachineScaleSetRollingUpgradeData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError Error { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy Policy { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo Progress { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus RunningStatus { get { throw null; } }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetRollingUpgradeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetRollingUpgradeResource() { }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetVmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instanceId, Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instanceId, Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceId, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceId, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> Get(string instanceId, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> GetAll(string filter = null, string select = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> GetAllAsync(string filter = null, string select = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>> GetAsync(string instanceId, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> GetIfExists(string instanceId, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>> GetIfExistsAsync(string instanceId, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>
    {
        public VirtualMachineScaleSetVmData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AvailabilitySetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string InstanceId { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView InstanceView { get { throw null; } }
        public bool? LatestModelApplied { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public string ModelDefinitionApplied { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy ProtectionPolicy { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData> Resources { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku Sku { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile StorageProfile { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UserData { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetVmExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmExtensionName, Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmExtensionName, Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource> Get(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource>> GetAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource> GetIfExists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource>> GetIfExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>
    {
        public VirtualMachineScaleSetVmExtensionData() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVmExtensionResource() { }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string instanceId, string vmExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVmResource() { }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ApproveRollingUpgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ApproveRollingUpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile> AttachDetachDataDisks(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest attachDetachDataDisksRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile>> AttachDetachDataDisksAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest attachDetachDataDisksRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string instanceId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> Get(Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>> GetAsync(Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView> GetInstanceView(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView>> GetInstanceViewAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource> GetVirtualMachineScaleSetVmExtension(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource>> GetVirtualMachineScaleSetVmExtensionAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionCollection GetVirtualMachineScaleSetVmExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> GetVirtualMachineScaleSetVmRunCommand(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>> GetVirtualMachineScaleSetVmRunCommandAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandCollection GetVirtualMachineScaleSetVmRunCommands() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PerformMaintenance(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PerformMaintenanceAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOff(Azure.WaitUntil waitUntil, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOffAsync(Azure.WaitUntil waitUntil, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOn(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOnAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReimageAll(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAllAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult> RetrieveBootDiagnosticsData(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult>> RetrieveBootDiagnosticsDataAsync(int? sasUriExpirationTimeInMinutes = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult> RunCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult>> RunCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SimulateEviction(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SimulateEvictionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmRunCommandCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetVmRunCommandCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string runCommandName, Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string runCommandName, Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> Get(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>> GetAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> GetIfExists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>> GetIfExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmRunCommandResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVmRunCommandResource() { }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string instanceId, string runCommandName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeResource.Mocking
{
    public partial class MockableComputeResourceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeResourceArmClient() { }
        public virtual Azure.ResourceManager.ComputeResource.AvailabilitySetResource GetAvailabilitySetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource GetCapacityReservationGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.CapacityReservationResource GetCapacityReservationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource GetDedicatedHostGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.DedicatedHostResource GetDedicatedHostResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.DiskImageResource GetDiskImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource GetProximityPlacementGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.RestorePointGroupResource GetRestorePointGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.RestorePointResource GetRestorePointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.SshPublicKeyResource GetSshPublicKeyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource GetVirtualMachineExtensionImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineExtensionResource GetVirtualMachineExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineResource GetVirtualMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandResource GetVirtualMachineRunCommandResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionResource GetVirtualMachineScaleSetExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource GetVirtualMachineScaleSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeResource GetVirtualMachineScaleSetRollingUpgradeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionResource GetVirtualMachineScaleSetVmExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmResource GetVirtualMachineScaleSetVmResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmRunCommandResource GetVirtualMachineScaleSetVmRunCommandResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeResourceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeResourceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> GetAvailabilitySet(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.AvailabilitySetResource>> GetAvailabilitySetAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.AvailabilitySetCollection GetAvailabilitySets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> GetCapacityReservationGroup(string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource>> GetCapacityReservationGroupAsync(string capacityReservationGroupName, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.CapacityReservationGroupCollection GetCapacityReservationGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> GetDedicatedHostGroup(string hostGroupName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource>> GetDedicatedHostGroupAsync(string hostGroupName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.DedicatedHostGroupCollection GetDedicatedHostGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource> GetDiskImage(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.DiskImageResource>> GetDiskImageAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.DiskImageCollection GetDiskImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> GetProximityPlacementGroup(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource>> GetProximityPlacementGroupAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.ProximityPlacementGroupCollection GetProximityPlacementGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> GetRestorePointGroup(string restorePointGroupName, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.RestorePointGroupResource>> GetRestorePointGroupAsync(string restorePointGroupName, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.RestorePointGroupCollection GetRestorePointGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> GetSshPublicKey(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.SshPublicKeyResource>> GetSshPublicKeyAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.SshPublicKeyCollection GetSshPublicKeys() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetVirtualMachine(string vmName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineResource>> GetVirtualMachineAsync(string vmName, Azure.ResourceManager.ComputeResource.Models.InstanceViewType? expand = default(Azure.ResourceManager.ComputeResource.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineCollection GetVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetVirtualMachineScaleSet(string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource>> GetVirtualMachineScaleSetAsync(string virtualMachineScaleSetName, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetCollection GetVirtualMachineScaleSets() { throw null; }
    }
    public partial class MockableComputeResourceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeResourceSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.LogAnalytics> ExportLogAnalyticsRequestRateByInterval(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>> ExportLogAnalyticsRequestRateByIntervalAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.LogAnalytics> ExportLogAnalyticsThrottledRequests(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>> ExportLogAnalyticsThrottledRequestsAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> GetAvailabilitySets(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.AvailabilitySetResource> GetAvailabilitySetsAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> GetCapacityReservationGroups(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand?), Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup? resourceIdsOnly = default(Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.CapacityReservationGroupResource> GetCapacityReservationGroupsAsync(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand?), Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup? resourceIdsOnly = default(Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> GetDedicatedHostGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.DedicatedHostGroupResource> GetDedicatedHostGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.DiskImageResource> GetDiskImages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.DiskImageResource> GetDiskImagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetOffersVirtualMachineImagesEdgeZones(Azure.Core.AzureLocation location, string edgeZone, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetOffersVirtualMachineImagesEdgeZonesAsync(Azure.Core.AzureLocation location, string edgeZone, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> GetProximityPlacementGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.ProximityPlacementGroupResource> GetProximityPlacementGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetPublishersVirtualMachineImagesEdgeZones(Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetPublishersVirtualMachineImagesEdgeZonesAsync(Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> GetRestorePointGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.RestorePointGroupResource> GetRestorePointGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> GetSshPublicKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.SshPublicKeyResource> GetSshPublicKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage> GetUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage> GetUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource> GetVirtualMachineExtensionImage(Azure.Core.AzureLocation location, string publisherName, string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageResource>> GetVirtualMachineExtensionImageAsync(Azure.Core.AzureLocation location, string publisherName, string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(Azure.Core.AzureLocation location, string publisherName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage> GetVirtualMachineImage(Azure.Core.AzureLocation location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>> GetVirtualMachineImageAsync(Azure.Core.AzureLocation location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageEdgeZoneSkus(Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageEdgeZoneSkusAsync(Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageOffers(Azure.Core.AzureLocation location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageOffersAsync(Azure.Core.AzureLocation location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagePublishers(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagePublishersAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImages(Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagesAsync(Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagesByEdgeZone(Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagesByEdgeZoneAsync(Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage> GetVirtualMachineImagesEdgeZone(Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>> GetVirtualMachineImagesEdgeZoneAsync(Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagesEdgeZones(Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImagesEdgeZonesAsync(Azure.ResourceManager.ComputeResource.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageSkus(Azure.Core.AzureLocation location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase> GetVirtualMachineImageSkusAsync(Azure.Core.AzureLocation location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument> GetVirtualMachineRunCommand(Azure.Core.AzureLocation location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument>> GetVirtualMachineRunCommandAsync(Azure.Core.AzureLocation location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase> GetVirtualMachineRunCommands(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase> GetVirtualMachineRunCommandsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetVirtualMachines(string statusOnly = null, string filter = null, Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm? expand = default(Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetVirtualMachinesAsync(string statusOnly = null, string filter = null, Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm? expand = default(Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetVirtualMachinesByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineResource> GetVirtualMachinesByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetVirtualMachineScaleSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize> GetVirtualMachineSizes(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize> GetVirtualMachineSizesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeResource.Models
{
    public partial class AdditionalCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities>
    {
        public AdditionalCapabilities() { }
        public bool? HibernationEnabled { get { throw null; } set { } }
        public bool? UltraSsdEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdditionalUnattendContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent>
    {
        public AdditionalUnattendContent() { }
        public Azure.ResourceManager.ComputeResource.Models.ComponentName? ComponentName { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.PassName? PassName { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SettingName? SettingName { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArchitectureType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ArchitectureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArchitectureType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ArchitectureType Arm64 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ArchitectureType X64 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ArchitectureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ArchitectureType left, Azure.ResourceManager.ComputeResource.Models.ArchitectureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ArchitectureType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ArchitectureType left, Azure.ResourceManager.ComputeResource.Models.ArchitectureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmComputeResourceModelFactory
    {
        public static Azure.ResourceManager.ComputeResource.AvailabilitySetData AvailabilitySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku = null, int? platformUpdateDomainCount = default(int?), int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> virtualMachines = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null, Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy scheduledEventsPolicy = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch AvailabilitySetPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku = null, int? platformUpdateDomainCount = default(int?), int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> virtualMachines = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null, Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy scheduledEventsPolicy = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary AvailablePatchSummary(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus? status = default(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus?), string assessmentActivityId = null, bool? rebootPending = default(bool?), int? criticalAndSecurityPatchCount = default(int?), int? otherPatchCount = default(int?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError error = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView BootDiagnosticsInstanceView(System.Uri consoleScreenshotBlobUri = null, System.Uri serialConsoleLogBlobUri = null, Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.CapacityReservationData CapacityReservationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku = null, System.Collections.Generic.IEnumerable<string> zones = null, string reservationId = null, int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachinesAssociated = null, System.DateTimeOffset? provisioningOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView instanceView = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.CapacityReservationGroupData CapacityReservationGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> capacityReservations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachinesAssociated = null, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView instanceView = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> sharingSubscriptionIds = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView CapacityReservationGroupInstanceView(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName> capacityReservations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> sharedSubscriptionIds = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch CapacityReservationGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> capacityReservations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachinesAssociated = null, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView instanceView = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> sharingSubscriptionIds = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView CapacityReservationInstanceView(Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization utilizationInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName CapacityReservationInstanceViewWithName(Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization utilizationInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null, string name = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch CapacityReservationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku = null, string reservationId = null, int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachinesAssociated = null, System.DateTimeOffset? provisioningOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView instanceView = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization CapacityReservationUtilization(int? currentCapacity = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachinesAllocated = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError ComputeResourceApiError(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase> details = null, Azure.ResourceManager.ComputeResource.Models.InnerError innererror = null, string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase ComputeResourceApiErrorBase(string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage ComputeResourceUsage(Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit unit = default(Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit), int currentValue = 0, long limit = (long)0, Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName name = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName ComputeResourceUsageName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData ComputeSubResourceData(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DataDiskImage DataDiskImage(int? lun = default(int?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach DataDisksToAttach(string diskId = null, int? lun = default(int?), Azure.ResourceManager.ComputeResource.Models.CachingType? caching = default(Azure.ResourceManager.ComputeResource.Models.CachingType?), Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType? deleteOption = default(Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType?), Azure.Core.ResourceIdentifier diskEncryptionSetId = null, bool? writeAcceleratorEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach DataDisksToDetach(string diskId = null, Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType? detachOption = default(Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm DedicatedHostAllocatableVm(string vmSize = null, double? count = default(double?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.DedicatedHostData DedicatedHostData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku = null, int? platformFaultDomain = default(int?), bool? autoReplaceOnFailure = default(bool?), string hostId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachines = null, Azure.ResourceManager.ComputeResource.Models.DedicatedHostLicenseType? licenseType = default(Azure.ResourceManager.ComputeResource.Models.DedicatedHostLicenseType?), System.DateTimeOffset? provisioningOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView instanceView = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.DedicatedHostGroupData DedicatedHostGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> dedicatedHosts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName> instanceViewHosts = null, bool? supportAutomaticPlacement = default(bool?), bool? ultraSsdEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch DedicatedHostGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<string> zones = null, int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> hosts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName> instanceViewHosts = null, bool? supportAutomaticPlacement = default(bool?), bool? ultraSsdEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView DedicatedHostInstanceView(string assetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm> availableCapacityAllocatableVms = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName DedicatedHostInstanceViewWithName(string assetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm> availableCapacityAllocatableVms = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null, string name = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch DedicatedHostPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku = null, int? platformFaultDomain = default(int?), bool? autoReplaceOnFailure = default(bool?), string hostId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachines = null, Azure.ResourceManager.ComputeResource.Models.DedicatedHostLicenseType? licenseType = default(Azure.ResourceManager.ComputeResource.Models.DedicatedHostLicenseType?), System.DateTimeOffset? provisioningOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView instanceView = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.DiskImageData DiskImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.Core.ResourceIdentifier sourceVirtualMachineId = null, Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile storageProfile = null, string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.ComputeResource.Models.HyperVGeneration?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiskImagePatch DiskImagePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.ResourceIdentifier sourceVirtualMachineId = null, Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile storageProfile = null, string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.ComputeResource.Models.HyperVGeneration?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiskInstanceView DiskInstanceView(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings> encryptionSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes DiskRestorePointAttributes(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption encryption = null, Azure.Core.ResourceIdentifier sourceDiskRestorePointId = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView DiskRestorePointInstanceView(string id = null, Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus replicationStatus = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus DiskRestorePointReplicationStatus(Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus status = null, int? completionPercent = default(int?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ImageReference ImageReference(Azure.Core.ResourceIdentifier id = null, string publisher = null, string offer = null, string sku = null, string version = null, string exactVersion = null, string sharedGalleryImageUniqueId = null, string communityGalleryImageId = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.InnerError InnerError(string exceptiontype = null, string errordetail = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary LastPatchInstallationSummary(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus? status = default(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus?), string installationActivityId = null, bool? maintenanceWindowExceeded = default(bool?), int? notSelectedPatchCount = default(int?), int? excludedPatchCount = default(int?), int? pendingPatchCount = default(int?), int? installedPatchCount = default(int?), int? failedPatchCount = default(int?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError error = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.LogAnalytics LogAnalytics(string logAnalyticsOutput = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase LogAnalyticsInputBase(System.Uri blobContainerSasUri = null, System.DateTimeOffset fromTime = default(System.DateTimeOffset), System.DateTimeOffset toTime = default(System.DateTimeOffset), bool? groupByThrottlePolicy = default(bool?), bool? groupByOperationName = default(bool?), bool? groupByResourceName = default(bool?), bool? groupByClientApplicationId = default(bool?), bool? groupByUserAgent = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus MaintenanceRedeployStatus(bool? isCustomerInitiatedMaintenanceAllowed = default(bool?), System.DateTimeOffset? preMaintenanceWindowStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? preMaintenanceWindowEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceWindowStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceWindowEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeResource.Models.MaintenanceOperationResultCodeType? lastOperationResultCode = default(Azure.ResourceManager.ComputeResource.Models.MaintenanceOperationResultCodeType?), string lastOperationMessage = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary OrchestrationServiceSummary(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName? serviceName = default(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName?), Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState? serviceState = default(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail PatchInstallationDetail(string patchId = null, string name = null, string version = null, string kbId = null, System.Collections.Generic.IEnumerable<string> classifications = null, Azure.ResourceManager.ComputeResource.Models.PatchInstallationState? installationState = default(Azure.ResourceManager.ComputeResource.Models.PatchInstallationState?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.ProximityPlacementGroupData ProximityPlacementGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType? proximityPlacementGroupType = default(Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus> virtualMachines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus> virtualMachineScaleSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus> availabilitySets = null, Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus colocationStatus = null, System.Collections.Generic.IEnumerable<string> intentVmSizes = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse RecoveryWalkResponse(bool? walkPerformed = default(bool?), int? nextPlatformUpdateDomain = default(int?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent RequestRateByIntervalContent(System.Uri blobContainerSasUri = null, System.DateTimeOffset fromTime = default(System.DateTimeOffset), System.DateTimeOffset toTime = default(System.DateTimeOffset), bool? groupByThrottlePolicy = default(bool?), bool? groupByOperationName = default(bool?), bool? groupByResourceName = default(bool?), bool? groupByClientApplicationId = default(bool?), bool? groupByUserAgent = default(bool?), Azure.ResourceManager.ComputeResource.Models.IntervalInMins intervalLength = Azure.ResourceManager.ComputeResource.Models.IntervalInMins.ThreeMins) { throw null; }
        public static Azure.ResourceManager.ComputeResource.RestorePointData RestorePointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> excludeDisks = null, Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata sourceMetadata = null, string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType? consistencyMode = default(Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType?), System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier sourceRestorePointId = null, Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.RestorePointGroupData RestorePointGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource source = null, string provisioningState = null, string restorePointGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.RestorePointData> restorePoints = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch RestorePointGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource source = null, string provisioningState = null, string restorePointGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.RestorePointData> restorePoints = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource RestorePointGroupSource(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView RestorePointInstanceView(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView> diskRestorePoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata RestorePointSourceMetadata(Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile hardwareProfile = null, Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile storageProfile = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile osProfile = null, Azure.ResourceManager.ComputeResource.Models.BootDiagnostics bootDiagnostics = null, string licenseType = null, string vmId = null, Azure.ResourceManager.ComputeResource.Models.SecurityProfile securityProfile = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string userData = null, Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.ComputeResource.Models.HyperVGeneration?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk RestorePointSourceVmDataDisk(int? lun = default(int?), string name = null, Azure.ResourceManager.ComputeResource.Models.CachingType? caching = default(Azure.ResourceManager.ComputeResource.Models.CachingType?), int? diskSizeGB = default(int?), Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk managedDisk = null, Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes diskRestorePoint = null, bool? writeAcceleratorEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk RestorePointSourceVmOSDisk(Azure.ResourceManager.ComputeResource.Models.OperatingSystemType? osType = default(Azure.ResourceManager.ComputeResource.Models.OperatingSystemType?), Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings encryptionSettings = null, string name = null, Azure.ResourceManager.ComputeResource.Models.CachingType? caching = default(Azure.ResourceManager.ComputeResource.Models.CachingType?), int? diskSizeGB = default(int?), Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk managedDisk = null, Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes diskRestorePoint = null, bool? writeAcceleratorEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile RestorePointSourceVmStorageProfile(Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk osDisk = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk> dataDiskList = null, Azure.ResourceManager.ComputeResource.Models.DiskControllerType? diskControllerType = default(Azure.ResourceManager.ComputeResource.Models.DiskControllerType?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult RetrieveBootDiagnosticsDataResult(System.Uri consoleScreenshotBlobUri = null, System.Uri serialConsoleLogBlobUri = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo RollbackStatusInfo(int? successfullyRolledbackInstanceCount = default(int?), int? failedRolledbackInstanceCount = default(int?), Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError rollbackError = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo RollingUpgradeProgressInfo(int? successfulInstanceCount = default(int?), int? failedInstanceCount = default(int?), int? inProgressInstanceCount = default(int?), int? pendingInstanceCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus RollingUpgradeRunningStatus(Azure.ResourceManager.ComputeResource.Models.RollingUpgradeStatusCode? code = default(Azure.ResourceManager.ComputeResource.Models.RollingUpgradeStatusCode?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeResource.Models.RollingUpgradeActionType? lastAction = default(Azure.ResourceManager.ComputeResource.Models.RollingUpgradeActionType?), System.DateTimeOffset? lastActionOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RunCommandDocument RunCommandDocument(string schema = null, string id = null, Azure.ResourceManager.ComputeResource.Models.SupportedOperatingSystemType osType = Azure.ResourceManager.ComputeResource.Models.SupportedOperatingSystemType.Windows, string label = null, string description = null, System.Collections.Generic.IEnumerable<string> script = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition> parameters = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase RunCommandDocumentBase(string schema = null, string id = null, Azure.ResourceManager.ComputeResource.Models.SupportedOperatingSystemType osType = Azure.ResourceManager.ComputeResource.Models.SupportedOperatingSystemType.Windows, string label = null, string description = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RunCommandInput RunCommandInput(string commandId = null, System.Collections.Generic.IEnumerable<string> script = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter> parameters = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition RunCommandParameterDefinition(string name = null, string runCommandParameterDefinitionType = null, string defaultValue = null, bool? required = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.SshPublicKeyData SshPublicKeyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string publicKey = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult SshPublicKeyGenerateKeyPairResult(string privateKey = null, string publicKey = null, Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent ThrottledRequestsContent(System.Uri blobContainerSasUri = null, System.DateTimeOffset fromTime = default(System.DateTimeOffset), System.DateTimeOffset toTime = default(System.DateTimeOffset), bool? groupByThrottlePolicy = default(bool?), bool? groupByOperationName = default(bool?), bool? groupByResourceName = default(bool?), bool? groupByClientApplicationId = default(bool?), bool? groupByUserAgent = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo UpgradeOperationHistoricalStatusInfo(Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties properties = null, string upgradeOperationHistoricalStatusInfoType = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties UpgradeOperationHistoricalStatusInfoProperties(Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus runningStatus = null, Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo progress = null, Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError error = null, Azure.ResourceManager.ComputeResource.Models.UpgradeOperationInvoker? startedBy = default(Azure.ResourceManager.ComputeResource.Models.UpgradeOperationInvoker?), Azure.ResourceManager.ComputeResource.Models.ImageReference targetImageReference = null, Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo rollbackInfo = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus UpgradeOperationHistoryStatus(Azure.ResourceManager.ComputeResource.Models.UpgradeState? code = default(Azure.ResourceManager.ComputeResource.Models.UpgradeState?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView VirtualMachineAgentInstanceView(string vmAgentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView> extensionHandlers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult VirtualMachineAssessPatchesResult(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus? status = default(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus?), string assessmentActivityId = null, bool? rebootPending = default(bool?), int? criticalAndSecurityPatchCount = default(int?), int? otherPatchCount = default(int?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties> availablePatches = null, Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError error = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult VirtualMachineCaptureResult(Azure.Core.ResourceIdentifier id = null, string schema = null, string contentVersion = null, System.BinaryData parameters = null, System.Collections.Generic.IEnumerable<System.BinaryData> resources = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineData VirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan plan = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData> resources = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string managedBy = null, string etag = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile hardwareProfile = null, Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy scheduledEventsPolicy = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile storageProfile = null, Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile osProfile = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile networkProfile = null, Azure.ResourceManager.ComputeResource.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.ComputeResource.Models.BootDiagnostics bootDiagnostics = null, Azure.Core.ResourceIdentifier availabilitySetId = null, Azure.Core.ResourceIdentifier virtualMachineScaleSetId = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType? priority = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType?), Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType? evictionPolicy = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType?), double? billingMaxPrice = default(double?), Azure.Core.ResourceIdentifier hostId = null, Azure.Core.ResourceIdentifier hostGroupId = null, string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView instanceView = null, string licenseType = null, string vmId = null, string extensionsTimeBudget = null, int? platformFaultDomain = default(int?), Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication> galleryApplications = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk VirtualMachineDataDisk(int lun = 0, string name = null, System.Uri vhdUri = null, System.Uri imageUri = null, Azure.ResourceManager.ComputeResource.Models.CachingType? caching = default(Azure.ResourceManager.ComputeResource.Models.CachingType?), bool? writeAcceleratorEnabled = default(bool?), Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType createOption = default(Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType), int? diskSizeGB = default(int?), Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk managedDisk = null, Azure.Core.ResourceIdentifier sourceResourceId = null, bool? toBeDetached = default(bool?), long? diskIopsReadWrite = default(long?), long? diskMBpsReadWrite = default(long?), Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType? detachOption = default(Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType?), Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType? deleteOption = default(Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData VirtualMachineExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView instanceView = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference keyVaultProtectedSettings = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView VirtualMachineExtensionHandlerInstanceView(string virtualMachineExtensionHandlerInstanceViewType = null, string typeHandlerVersion = null, Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineExtensionImageData VirtualMachineExtensionImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string operatingSystem = null, string computeRole = null, string handlerSchema = null, bool? virtualMachineScaleSetEnabled = default(bool?), bool? supportsMultipleExtensions = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent VirtualMachineInstallPatchesContent(System.TimeSpan? maximumDuration = default(System.TimeSpan?), Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting rebootSetting = default(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting), Azure.ResourceManager.ComputeResource.Models.WindowsParameters windowsParameters = null, Azure.ResourceManager.ComputeResource.Models.LinuxParameters linuxParameters = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult VirtualMachineInstallPatchesResult(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus? status = default(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus?), string installationActivityId = null, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus? rebootStatus = default(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus?), bool? maintenanceWindowExceeded = default(bool?), int? excludedPatchCount = default(int?), int? notSelectedPatchCount = default(int?), int? pendingPatchCount = default(int?), int? installedPatchCount = default(int?), int? failedPatchCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail> patches = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError error = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView VirtualMachineInstanceView(int? platformUpdateDomain = default(int?), int? platformFaultDomain = default(int?), string computerName = null, string osName = null, string osVersion = null, Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.ComputeResource.Models.HyperVGeneration?), string rdpThumbPrint = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView vmAgent = null, Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus maintenanceRedeployStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView> disks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView> extensions = null, Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus vmHealthStatus = null, Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView bootDiagnostics = null, string assignedHost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus patchStatus = null, bool? isVmInStandbyPool = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch VirtualMachinePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan plan = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile hardwareProfile = null, Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy scheduledEventsPolicy = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile storageProfile = null, Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile osProfile = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile networkProfile = null, Azure.ResourceManager.ComputeResource.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.ComputeResource.Models.BootDiagnostics bootDiagnostics = null, Azure.Core.ResourceIdentifier availabilitySetId = null, Azure.Core.ResourceIdentifier virtualMachineScaleSetId = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType? priority = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType?), Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType? evictionPolicy = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType?), double? billingMaxPrice = default(double?), Azure.Core.ResourceIdentifier hostId = null, Azure.Core.ResourceIdentifier hostGroupId = null, string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView instanceView = null, string licenseType = null, string vmId = null, string extensionsTimeBudget = null, int? platformFaultDomain = default(int?), Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication> galleryApplications = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus VirtualMachinePatchStatus(Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary availablePatchSummary = null, Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary lastPatchInstallationSummary = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> configurationStatuses = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineRunCommandData VirtualMachineRunCommandData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource source = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter> protectedParameters = null, bool? asyncExecution = default(bool?), string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = default(int?), System.Uri outputBlobUri = null, System.Uri errorBlobUri = null, Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity outputBlobManagedIdentity = null, Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity errorBlobManagedIdentity = null, string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView instanceView = null, bool? treatFailureAsDeploymentFailure = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView VirtualMachineRunCommandInstanceView(Azure.ResourceManager.ComputeResource.Models.ExecutionState? executionState = default(Azure.ResourceManager.ComputeResource.Models.ExecutionState?), string executionMessage = null, int? exitCode = default(int?), string output = null, string error = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult VirtualMachineRunCommandResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> value = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate VirtualMachineRunCommandUpdate(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource source = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter> protectedParameters = null, bool? asyncExecution = default(bool?), string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = default(int?), System.Uri outputBlobUri = null, System.Uri errorBlobUri = null, Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity outputBlobManagedIdentity = null, Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity errorBlobManagedIdentity = null, string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView instanceView = null, bool? treatFailureAsDeploymentFailure = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetData VirtualMachineScaleSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku = null, Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan plan = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string etag = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy upgradePolicy = null, Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy scheduledEventsPolicy = null, Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy automaticRepairsPolicy = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile virtualMachineProfile = null, string provisioningState = null, bool? overprovision = default(bool?), bool? doNotRunExtensionsOnOverprovisionedVms = default(bool?), string uniqueId = null, bool? singlePlacementGroup = default(bool?), bool? zoneBalance = default(bool?), int? platformFaultDomainCount = default(int?), Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, Azure.Core.ResourceIdentifier hostGroupId = null, Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy scaleInPolicy = null, Azure.ResourceManager.ComputeResource.Models.OrchestrationMode? orchestrationMode = default(Azure.ResourceManager.ComputeResource.Models.OrchestrationMode?), Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy spotRestorePolicy = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy priorityMixPolicy = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), bool? isMaximumCapacityConstrained = default(bool?), Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy resiliencyPolicy = null, Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode? zonalPlatformFaultDomainAlignMode = default(Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode?), Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile skuProfile = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData VirtualMachineScaleSetExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference keyVaultProtectedSettings = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch VirtualMachineScaleSetExtensionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference keyVaultProtectedSettings = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView VirtualMachineScaleSetInstanceView(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount> virtualMachineStatusesSummary = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary> extensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary> orchestrationServices = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetRollingUpgradeData VirtualMachineScaleSetRollingUpgradeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy policy = null, Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus runningStatus = null, Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo progress = null, Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError error = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku VirtualMachineScaleSetSku(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity VirtualMachineScaleSetSkuCapacity(long? minimum = default(long?), long? maximum = default(long?), long? defaultCapacity = default(long?), Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuScaleType? scaleType = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuScaleType?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmData VirtualMachineScaleSetVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string instanceId = null, Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku sku = null, Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan plan = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.VirtualMachineExtensionData> resources = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string etag = null, bool? latestModelApplied = default(bool?), string vmId = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView instanceView = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile hardwareProfile = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile storageProfile = null, Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile osProfile = null, Azure.ResourceManager.ComputeResource.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile networkProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations = null, Azure.ResourceManager.ComputeResource.Models.BootDiagnostics bootDiagnostics = null, Azure.Core.ResourceIdentifier availabilitySetId = null, string provisioningState = null, string licenseType = null, string modelDefinitionApplied = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy protectionPolicy = null, string userData = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetVmExtensionData VirtualMachineScaleSetVmExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView instanceView = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference keyVaultProtectedSettings = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch VirtualMachineScaleSetVmExtensionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference keyVaultProtectedSettings = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary VirtualMachineScaleSetVmExtensionsSummary(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount> statusesSummary = null) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView VirtualMachineScaleSetVmInstanceView(int? platformUpdateDomain = default(int?), int? platformFaultDomain = default(int?), string rdpThumbPrint = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView vmAgent = null, Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus maintenanceRedeployStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView> disks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView> extensions = null, Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus vmHealthStatus = null, Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView bootDiagnostics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> statuses = null, Azure.Core.ResourceIdentifier assignedHost = null, string placementGroupId = null, string computerName = null, string osName = null, string osVersion = null, Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.ComputeResource.Models.HyperVGeneration?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile VirtualMachineScaleSetVmProfile(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile osProfile = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile storageProfile = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile networkProfile = null, Azure.ResourceManager.ComputeResource.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.ComputeResource.Models.BootDiagnostics bootDiagnostics = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile extensionProfile = null, string licenseType = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType? priority = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType?), Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType? evictionPolicy = default(Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType?), double? billingMaxPrice = default(double?), Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication> galleryApplications = null, Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties hardwareVmSizeProperties = null, Azure.Core.ResourceIdentifier serviceArtifactReferenceId = null, Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference securityPostureReference = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize VirtualMachineSize(string name = null, int? numberOfCores = default(int?), int? osDiskSizeInMB = default(int?), int? resourceDiskSizeInMB = default(int?), int? memoryInMB = default(int?), int? maxDataDiskCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties VirtualMachineSoftwarePatchProperties(string patchId = null, string name = null, string version = null, string kbId = null, System.Collections.Generic.IEnumerable<string> classifications = null, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior? rebootBehavior = default(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior?), string activityId = null, System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState? assessmentState = default(Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount VirtualMachineStatusCodeCount(string code = null, int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration WindowsConfiguration(bool? provisionVmAgent = default(bool?), bool? isAutomaticUpdatesEnabled = default(bool?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent> additionalUnattendContent = null, Azure.ResourceManager.ComputeResource.Models.PatchSettings patchSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeResource.Models.WinRMListener> winRMListeners = null, bool? isVmAgentPlatformUpdatesEnabled = default(bool?)) { throw null; }
    }
    public partial class AttachDetachDataDisksRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest>
    {
        public AttachDetachDataDisksRequest() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach> DataDisksToAttach { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach> DataDisksToDetach { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AttachDetachDataDisksRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutomaticOSUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AutomaticOSUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AutomaticOSUpgradePolicy>
    {
        public AutomaticOSUpgradePolicy() { }
        public bool? DisableAutomaticRollback { get { throw null; } set { } }
        public bool? EnableAutomaticOSUpgrade { get { throw null; } set { } }
        public bool? OSRollingUpgradeDeferral { get { throw null; } set { } }
        public bool? UseRollingUpgradePolicy { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.AutomaticOSUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AutomaticOSUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AutomaticOSUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.AutomaticOSUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AutomaticOSUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AutomaticOSUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AutomaticOSUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutomaticRepairsPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy>
    {
        public AutomaticRepairsPolicy() { }
        public bool? Enabled { get { throw null; } set { } }
        public string GracePeriod { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.RepairAction? RepairAction { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilitySetPatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch>
    {
        public AvailabilitySetPatch() { }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public int? PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AvailabilitySetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailablePatchSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary>
    {
        internal AvailablePatchSummary() { }
        public string AssessmentActivityId { get { throw null; } }
        public int? CriticalAndSecurityPatchCount { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError Error { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public int? OtherPatchCount { get { throw null; } }
        public bool? RebootPending { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus? Status { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BootDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnostics>
    {
        public BootDiagnostics() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.BootDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.BootDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BootDiagnosticsInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView>
    {
        internal BootDiagnosticsInstanceView() { }
        public System.Uri ConsoleScreenshotBlobUri { get { throw null; } }
        public System.Uri SerialConsoleLogBlobUri { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus Status { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityReservationGroupGetExpand : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityReservationGroupGetExpand(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand VirtualMachineScaleSetVmsRef { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand VirtualMachinesRef { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand left, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand left, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupGetExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityReservationGroupInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView>
    {
        internal CapacityReservationGroupInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName> CapacityReservations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> SharedSubscriptionIds { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityReservationGroupInstanceViewType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityReservationGroupInstanceViewType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType left, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType left, Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityReservationGroupPatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch>
    {
        public CapacityReservationGroupPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> CapacityReservations { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupInstanceView InstanceView { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> SharingSubscriptionIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityReservationInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView>
    {
        internal CapacityReservationInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization UtilizationInfo { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityReservationInstanceViewType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityReservationInstanceViewType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType left, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType left, Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityReservationInstanceViewWithName : Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName>
    {
        internal CapacityReservationInstanceViewWithName() { }
        public string Name { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceViewWithName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityReservationPatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch>
    {
        public CapacityReservationPatch() { }
        public Azure.ResourceManager.ComputeResource.Models.CapacityReservationInstanceView InstanceView { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityReservationUtilization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization>
    {
        internal CapacityReservationUtilization() { }
        public int? CurrentCapacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAllocated { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.CapacityReservationUtilization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentName : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComponentName MicrosoftWindowsShellSetup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ComponentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ComponentName left, Azure.ResourceManager.ComputeResource.Models.ComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ComponentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ComponentName left, Azure.ResourceManager.ComputeResource.Models.ComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeAllocationStrategy : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ComputeAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeAllocationStrategy CapacityOptimized { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeAllocationStrategy LowestPrice { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ComputeAllocationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ComputeAllocationStrategy left, Azure.ResourceManager.ComputeResource.Models.ComputeAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ComputeAllocationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ComputeAllocationStrategy left, Azure.ResourceManager.ComputeResource.Models.ComputeAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeNetworkInterfaceAuxiliaryMode : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeNetworkInterfaceAuxiliaryMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode AcceleratedConnections { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode Floating { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeNetworkInterfaceAuxiliarySku : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeNetworkInterfaceAuxiliarySku(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku A1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku A2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku A4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku A8 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku left, Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku left, Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeResourceApiError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError>
    {
        internal ComputeResourceApiError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase> Details { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResourceApiErrorBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase>
    {
        internal ComputeResourceApiErrorBase() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiErrorBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeResourceDeleteOption : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeResourceDeleteOption(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption left, Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption left, Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch>
    {
        public ComputeResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResourcePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan>
    {
        public ComputeResourcePlan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResourcePublicIPAddressSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku>
    {
        public ComputeResourcePublicIPAddressSku() { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeResourcePublicIPAddressSkuName : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeResourcePublicIPAddressSkuName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuName left, Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuName left, Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeResourcePublicIPAddressSkuTier : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeResourcePublicIPAddressSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuTier Global { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuTier Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuTier left, Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuTier left, Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeResourceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku>
    {
        public ComputeResourceSku() { }
        public long? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ComputeResourceStatusLevelType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }
    public partial class ComputeResourceUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage>
    {
        internal ComputeResourceUsage() { }
        public int CurrentValue { get { throw null; } }
        public long Limit { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName Name { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit Unit { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResourceUsageName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName>
    {
        internal ComputeResourceUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeResourceUsageUnit : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeResourceUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit left, Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit left, Azure.ResourceManager.ComputeResource.Models.ComputeResourceUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeScheduledEventsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile>
    {
        public ComputeScheduledEventsProfile() { }
        public Azure.ResourceManager.ComputeResource.Models.OSImageNotificationProfile OSImageNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.TerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSecurityPostureReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference>
    {
        public ComputeSecurityPostureReference(Azure.Core.ResourceIdentifier id) { }
        public System.Collections.Generic.IList<string> ExcludeExtensionNames { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public bool? IsOverridable { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSkuProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile>
    {
        public ComputeSkuProfile() { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfileVmSize> VmSizes { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSkuProfileVmSize : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfileVmSize>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfileVmSize>
    {
        public ComputeSkuProfileVmSize() { }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfileVmSize System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfileVmSize>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfileVmSize>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfileVmSize System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfileVmSize>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfileVmSize>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfileVmSize>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSubResourceData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData>
    {
        public ComputeSubResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSubResourceDataWithColocationStatus : Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus>
    {
        public ComputeSubResourceDataWithColocationStatus() { }
        public Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceDataWithColocationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeWriteableSubResourceData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData>
    {
        public ComputeWriteableSubResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsistencyModeType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsistencyModeType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType ApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType CrashConsistent { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType FileSystemConsistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType left, Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType left, Azure.ResourceManager.ComputeResource.Models.ConsistencyModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DataDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDiskImage>
    {
        public DataDiskImage() { }
        public int? Lun { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.DataDiskImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DataDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DataDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DataDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDisksToAttach : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach>
    {
        public DataDisksToAttach(string diskId) { }
        public Azure.ResourceManager.ComputeResource.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public string DiskId { get { throw null; } }
        public int? Lun { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToAttach>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDisksToDetach : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach>
    {
        public DataDisksToDetach(string diskId) { }
        public Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType? DetachOption { get { throw null; } set { } }
        public string DiskId { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DataDisksToDetach>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostAllocatableVm : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm>
    {
        internal DedicatedHostAllocatableVm() { }
        public double? Count { get { throw null; } }
        public string VmSize { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostGroupPatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch>
    {
        public DedicatedHostGroupPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Hosts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName> InstanceViewHosts { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public bool? SupportAutomaticPlacement { get { throw null; } set { } }
        public bool? UltraSsdEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView>
    {
        internal DedicatedHostInstanceView() { }
        public string AssetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.DedicatedHostAllocatableVm> AvailableCapacityAllocatableVms { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostInstanceViewWithName : Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName>
    {
        internal DedicatedHostInstanceViewWithName() { }
        public string Name { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceViewWithName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DedicatedHostLicenseType
    {
        None = 0,
        WindowsServerHybrid = 1,
        WindowsServerPerpetual = 2,
    }
    public partial class DedicatedHostPatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch>
    {
        public DedicatedHostPatch() { }
        public bool? AutoReplaceOnFailure { get { throw null; } set { } }
        public string HostId { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.DedicatedHostLicenseType? LicenseType { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DedicatedHostPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskOption : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.DiffDiskOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskOption(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiffDiskOption Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.DiffDiskOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.DiffDiskOption left, Azure.ResourceManager.ComputeResource.Models.DiffDiskOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.DiffDiskOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.DiffDiskOption left, Azure.ResourceManager.ComputeResource.Models.DiffDiskOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement NvmeDisk { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement left, Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement left, Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiffDiskSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings>
    {
        public DiffDiskSettings() { }
        public Azure.ResourceManager.ComputeResource.Models.DiffDiskOption? Option { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiffDiskPlacement? Placement { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskControllerType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.DiskControllerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskControllerType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiskControllerType NVMe { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DiskControllerType Scsi { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.DiskControllerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.DiskControllerType left, Azure.ResourceManager.ComputeResource.Models.DiskControllerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.DiskControllerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.DiskControllerType left, Azure.ResourceManager.ComputeResource.Models.DiskControllerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOptionType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType Attach { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType Copy { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType Empty { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType FromImage { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType left, Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType left, Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDeleteOptionType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDeleteOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType Delete { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType left, Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType left, Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDetachOptionType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDetachOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType ForceDetach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType left, Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType left, Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskEncryptionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings>
    {
        public DiskEncryptionSettings() { }
        public Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.KeyVaultKeyReference KeyEncryptionKey { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImagePatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskImagePatch>
    {
        public DiskImagePatch() { }
        public Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceVirtualMachineId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile StorageProfile { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.DiskImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DiskImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView>
    {
        internal DiskInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings> EncryptionSettings { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.DiskInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DiskInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskRestorePointAttributes : Azure.ResourceManager.ComputeResource.Models.ComputeSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes>
    {
        public DiskRestorePointAttributes() { }
        public Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption Encryption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceDiskRestorePointId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskRestorePointInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView>
    {
        internal DiskRestorePointInstanceView() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus ReplicationStatus { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskRestorePointReplicationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus>
    {
        internal DiskRestorePointReplicationStatus() { }
        public int? CompletionPercent { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus Status { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointReplicationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNameLabelScopeType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNameLabelScopeType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType left, Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType left, Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionState : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ExecutionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ExecutionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ExecutionState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ExecutionState Pending { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ExecutionState Running { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ExecutionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ExecutionState TimedOut { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ExecutionState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ExecutionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ExecutionState left, Azure.ResourceManager.ComputeResource.Models.ExecutionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ExecutionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ExecutionState left, Azure.ResourceManager.ComputeResource.Models.ExecutionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpandTypesForListVm : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpandTypesForListVm(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm left, Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm left, Azure.ResourceManager.ComputeResource.Models.ExpandTypesForListVm right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GetVirtualMachineExpandType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GetVirtualMachineExpandType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType left, Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType left, Azure.ResourceManager.ComputeResource.Models.GetVirtualMachineExpandType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGeneration : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.HyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.HyperVGeneration V1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.HyperVGeneration V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.HyperVGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.HyperVGeneration left, Azure.ResourceManager.ComputeResource.Models.HyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.HyperVGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.HyperVGeneration left, Azure.ResourceManager.ComputeResource.Models.HyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageAlternativeOption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageAlternativeOption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageAlternativeOption>
    {
        public ImageAlternativeOption() { }
        public Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType? AlternativeType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ImageAlternativeOption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageAlternativeOption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageAlternativeOption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ImageAlternativeOption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageAlternativeOption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageAlternativeOption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageAlternativeOption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageAlternativeType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageAlternativeType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType None { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType Offer { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType Plan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType left, Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType left, Azure.ResourceManager.ComputeResource.Models.ImageAlternativeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageDataDisk : Azure.ResourceManager.ComputeResource.Models.ImageDisk, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDataDisk>
    {
        public ImageDataDisk(int lun) { }
        public int Lun { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ImageDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ImageDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDeprecationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageDeprecationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDeprecationStatus>
    {
        public ImageDeprecationStatus() { }
        public Azure.ResourceManager.ComputeResource.Models.ImageAlternativeOption AlternativeOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ImageState? ImageState { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduledDeprecationOn { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ImageDeprecationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageDeprecationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageDeprecationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ImageDeprecationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDeprecationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDeprecationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDeprecationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDisk>
    {
        public ImageDisk() { }
        public System.Uri BlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedDiskId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SnapshotId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ImageDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ImageDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageOSDisk : Azure.ResourceManager.ComputeResource.Models.ImageDisk, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageOSDisk>
    {
        public ImageOSDisk(Azure.ResourceManager.ComputeResource.Models.SupportedOperatingSystemType osType, Azure.ResourceManager.ComputeResource.Models.OperatingSystemStateType osState) { }
        public Azure.ResourceManager.ComputeResource.Models.OperatingSystemStateType OSState { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SupportedOperatingSystemType OSType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ImageOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ImageOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageReference : Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageReference>
    {
        public ImageReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageUniqueId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageState : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ImageState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ImageState Active { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ImageState Deprecated { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ImageState ScheduledForDeprecation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ImageState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ImageState left, Azure.ResourceManager.ComputeResource.Models.ImageState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ImageState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ImageState left, Azure.ResourceManager.ComputeResource.Models.ImageState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile>
    {
        public ImageStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.ImageDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ImageOSDisk OSDisk { get { throw null; } set { } }
        public bool? ZoneResilient { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ImageStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InnerError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.InnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.InnerError>
    {
        internal InnerError() { }
        public string Errordetail { get { throw null; } }
        public string Exceptiontype { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.InnerError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.InnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.InnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.InnerError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.InnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.InnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.InnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus>
    {
        public InstanceViewStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceStatusLevelType? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum InstanceViewType
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
    public readonly partial struct IPVersion : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.IPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPVersion(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.IPVersion IPv4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.IPVersion IPv6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.IPVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.IPVersion left, Azure.ResourceManager.ComputeResource.Models.IPVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.IPVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.IPVersion left, Azure.ResourceManager.ComputeResource.Models.IPVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultKeyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultKeyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultKeyReference>
    {
        public KeyVaultKeyReference(System.Uri keyUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.KeyVaultKeyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultKeyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultKeyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.KeyVaultKeyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultKeyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultKeyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultKeyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference>
    {
        public KeyVaultSecretReference(System.Uri secretUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LastPatchInstallationSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary>
    {
        internal LastPatchInstallationSummary() { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError Error { get { throw null; } }
        public int? ExcludedPatchCount { get { throw null; } }
        public int? FailedPatchCount { get { throw null; } }
        public string InstallationActivityId { get { throw null; } }
        public int? InstalledPatchCount { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public bool? MaintenanceWindowExceeded { get { throw null; } }
        public int? NotSelectedPatchCount { get { throw null; } }
        public int? PendingPatchCount { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus? Status { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration>
    {
        public LinuxConfiguration() { }
        public bool? IsPasswordAuthenticationDisabled { get { throw null; } set { } }
        public bool? IsVmAgentPlatformUpdatesEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.LinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyConfiguration> SshPublicKeys { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxParameters>
    {
        public LinuxParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux> ClassificationsToInclude { get { throw null; } }
        public string MaintenanceRunId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PackageNameMasksToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToInclude { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.LinuxParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.LinuxParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.LinuxPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.LinuxPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.LinuxPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.LinuxPatchAssessmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.ComputeResource.Models.LinuxPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.LinuxPatchAssessmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.LinuxPatchAssessmentMode left, Azure.ResourceManager.ComputeResource.Models.LinuxPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxPatchSettings>
    {
        public LinuxPatchSettings() { }
        public Azure.ResourceManager.ComputeResource.Models.LinuxPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchMode? PatchMode { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.LinuxPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.LinuxPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVmGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxVmGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>
    {
        public LinuxVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVmGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchMode left, Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchMode left, Azure.ResourceManager.ComputeResource.Models.LinuxVmGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogAnalytics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>
    {
        internal LogAnalytics() { }
        public string LogAnalyticsOutput { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.LogAnalytics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.LogAnalytics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LogAnalytics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsInputBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase>
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
        Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MaintenanceOperationResultCodeType
    {
        None = 0,
        RetryLater = 1,
        MaintenanceAborted = 2,
        MaintenanceCompleted = 3,
    }
    public partial class MaintenanceRedeployStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus>
    {
        internal MaintenanceRedeployStatus() { }
        public bool? IsCustomerInitiatedMaintenanceAllowed { get { throw null; } }
        public string LastOperationMessage { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.MaintenanceOperationResultCodeType? LastOperationResultCode { get { throw null; } }
        public System.DateTimeOffset? MaintenanceWindowEndOn { get { throw null; } }
        public System.DateTimeOffset? MaintenanceWindowStartOn { get { throw null; } }
        public System.DateTimeOffset? PreMaintenanceWindowEndOn { get { throw null; } }
        public System.DateTimeOffset? PreMaintenanceWindowStartOn { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mode : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.Mode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.Mode Audit { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.Mode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.Mode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.Mode left, Azure.ResourceManager.ComputeResource.Models.Mode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.Mode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.Mode left, Azure.ResourceManager.ComputeResource.Models.Mode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkApiVersion : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkApiVersion(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion TwoThousandTwenty1101 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion left, Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion left, Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum OperatingSystemStateType
    {
        Generalized = 0,
        Specialized = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystemType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.OperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.OperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.OperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.OperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.OperatingSystemType left, Azure.ResourceManager.ComputeResource.Models.OperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.OperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.OperatingSystemType left, Azure.ResourceManager.ComputeResource.Models.OperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestrationMode : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.OrchestrationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.OrchestrationMode Flexible { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.OrchestrationMode Uniform { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.OrchestrationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.OrchestrationMode left, Azure.ResourceManager.ComputeResource.Models.OrchestrationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.OrchestrationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.OrchestrationMode left, Azure.ResourceManager.ComputeResource.Models.OrchestrationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestrationServiceName : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationServiceName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName AutomaticRepairs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName left, Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName left, Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestrationServiceState : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationServiceState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState NotRunning { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState Running { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState left, Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState left, Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestrationServiceStateAction : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationServiceStateAction(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction Resume { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction Suspend { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction left, Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction left, Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OrchestrationServiceStateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent>
    {
        public OrchestrationServiceStateContent(Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName serviceName, Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction action) { }
        public Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateAction Action { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName ServiceName { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceStateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationServiceSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary>
    {
        internal OrchestrationServiceSummary() { }
        public Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceName? ServiceName { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceState? ServiceState { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSImageNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OSImageNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OSImageNotificationProfile>
    {
        public OSImageNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.OSImageNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OSImageNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OSImageNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.OSImageNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OSImageNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OSImageNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OSImageNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSProfileProvisioningData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OSProfileProvisioningData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OSProfileProvisioningData>
    {
        public OSProfileProvisioningData() { }
        public string AdminPassword { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.OSProfileProvisioningData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OSProfileProvisioningData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.OSProfileProvisioningData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.OSProfileProvisioningData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OSProfileProvisioningData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OSProfileProvisioningData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.OSProfileProvisioningData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PassName : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.PassName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PassName(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.PassName OobeSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.PassName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.PassName left, Azure.ResourceManager.ComputeResource.Models.PassName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.PassName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.PassName left, Azure.ResourceManager.ComputeResource.Models.PassName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchAssessmentState : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchAssessmentState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState Available { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState left, Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState left, Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatchInstallationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail>
    {
        internal PatchInstallationDetail() { }
        public System.Collections.Generic.IReadOnlyList<string> Classifications { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.PatchInstallationState? InstallationState { get { throw null; } }
        public string KbId { get { throw null; } }
        public string Name { get { throw null; } }
        public string PatchId { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchInstallationState : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.PatchInstallationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchInstallationState(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.PatchInstallationState Excluded { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PatchInstallationState Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PatchInstallationState Installed { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PatchInstallationState NotSelected { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PatchInstallationState Pending { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PatchInstallationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.PatchInstallationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.PatchInstallationState left, Azure.ResourceManager.ComputeResource.Models.PatchInstallationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.PatchInstallationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.PatchInstallationState left, Azure.ResourceManager.ComputeResource.Models.PatchInstallationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchOperationStatus : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus left, Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus left, Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.PatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PatchSettings>
    {
        public PatchSettings() { }
        public Azure.ResourceManager.ComputeResource.Models.WindowsPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public bool? EnableHotpatching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode? PatchMode { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.PatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.PatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.PatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.PatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProximityPlacementGroupPatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch>
    {
        public ProximityPlacementGroupPatch() { }
        Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProximityPlacementGroupType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProximityPlacementGroupType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType Standard { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType Ultra { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType left, Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType left, Azure.ResourceManager.ComputeResource.Models.ProximityPlacementGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProxyAgentSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ProxyAgentSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ProxyAgentSettings>
    {
        public ProxyAgentSettings() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? KeyIncarnationId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.Mode? Mode { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ProxyAgentSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ProxyAgentSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ProxyAgentSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ProxyAgentSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ProxyAgentSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ProxyAgentSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ProxyAgentSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPAllocationMethod : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.PublicIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.PublicIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.PublicIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.PublicIPAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.PublicIPAllocationMethod left, Azure.ResourceManager.ComputeResource.Models.PublicIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.PublicIPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.PublicIPAllocationMethod left, Azure.ResourceManager.ComputeResource.Models.PublicIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurchasePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.PurchasePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PurchasePlan>
    {
        public PurchasePlan(string publisher, string name, string product) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.PurchasePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.PurchasePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.PurchasePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.PurchasePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PurchasePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PurchasePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.PurchasePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryWalkResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse>
    {
        internal RecoveryWalkResponse() { }
        public int? NextPlatformUpdateDomain { get { throw null; } }
        public bool? WalkPerformed { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RecoveryWalkResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RepairAction : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.RepairAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RepairAction(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RepairAction Reimage { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.RepairAction Replace { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.RepairAction Restart { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.RepairAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.RepairAction left, Azure.ResourceManager.ComputeResource.Models.RepairAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.RepairAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.RepairAction left, Azure.ResourceManager.ComputeResource.Models.RepairAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestRateByIntervalContent : Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent>
    {
        public RequestRateByIntervalContent(System.Uri blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, Azure.ResourceManager.ComputeResource.Models.IntervalInMins intervalLength) : base (default(System.Uri), default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
        public Azure.ResourceManager.ComputeResource.Models.IntervalInMins IntervalLength { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RequestRateByIntervalContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResiliencyPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy>
    {
        public ResiliencyPolicy() { }
        public bool? ResilientVmCreationPolicyEnabled { get { throw null; } set { } }
        public bool? ResilientVmDeletionPolicyEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceIdOptionsForGetCapacityReservationGroup : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceIdOptionsForGetCapacityReservationGroup(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup All { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup CreatedInSubscription { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup SharedWithSubscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup left, Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup left, Azure.ResourceManager.ComputeResource.Models.ResourceIdOptionsForGetCapacityReservationGroup right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestorePointEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption>
    {
        public RestorePointEncryption() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType? EncryptionType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestorePointEncryptionType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestorePointEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType EncryptionAtRestWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType EncryptionAtRestWithPlatformAndCustomerKeys { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType EncryptionAtRestWithPlatformKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType left, Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType left, Azure.ResourceManager.ComputeResource.Models.RestorePointEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestorePointExpand : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.RestorePointExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestorePointExpand(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointExpand InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand left, Azure.ResourceManager.ComputeResource.Models.RestorePointExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.RestorePointExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.RestorePointExpand left, Azure.ResourceManager.ComputeResource.Models.RestorePointExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestorePointGroupExpand : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestorePointGroupExpand(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand RestorePoints { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand left, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand left, Azure.ResourceManager.ComputeResource.Models.RestorePointGroupExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestorePointGroupPatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch>
    {
        public RestorePointGroupPatch() { }
        public string ProvisioningState { get { throw null; } }
        public string RestorePointGroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.RestorePointData> RestorePoints { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource Source { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointGroupSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource>
    {
        public RestorePointGroupSource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointGroupSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView>
    {
        internal RestorePointInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.DiskRestorePointInstanceView> DiskRestorePoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointSourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata>
    {
        public RestorePointSourceMetadata() { }
        public Azure.ResourceManager.ComputeResource.Models.BootDiagnostics BootDiagnostics { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile OSProfile { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.SecurityProfile SecurityProfile { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } }
        public string VmId { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointSourceVmDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk>
    {
        public RestorePointSourceVmDataDisk() { }
        public Azure.ResourceManager.ComputeResource.Models.CachingType? Caching { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes DiskRestorePoint { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } }
        public int? Lun { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointSourceVmOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk>
    {
        public RestorePointSourceVmOSDisk() { }
        public Azure.ResourceManager.ComputeResource.Models.CachingType? Caching { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.DiskRestorePointAttributes DiskRestorePoint { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings EncryptionSettings { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.OperatingSystemType? OSType { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointSourceVmStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile>
    {
        public RestorePointSourceVmStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmDataDisk> DataDiskList { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.DiskControllerType? DiskControllerType { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmOSDisk OSDisk { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RestorePointSourceVmStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RetrieveBootDiagnosticsDataResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult>
    {
        internal RetrieveBootDiagnosticsDataResult() { }
        public System.Uri ConsoleScreenshotBlobUri { get { throw null; } }
        public System.Uri SerialConsoleLogBlobUri { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RetrieveBootDiagnosticsDataResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RollbackStatusInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo>
    {
        internal RollbackStatusInfo() { }
        public int? FailedRolledbackInstanceCount { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError RollbackError { get { throw null; } }
        public int? SuccessfullyRolledbackInstanceCount { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum RollingUpgradeActionType
    {
        Start = 0,
        Cancel = 1,
    }
    public partial class RollingUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy>
    {
        public RollingUpgradePolicy() { }
        public bool? EnableCrossZoneUpgrade { get { throw null; } set { } }
        public bool? IsMaxSurgeEnabled { get { throw null; } set { } }
        public int? MaxBatchInstancePercent { get { throw null; } set { } }
        public int? MaxUnhealthyInstancePercent { get { throw null; } set { } }
        public int? MaxUnhealthyUpgradedInstancePercent { get { throw null; } set { } }
        public string PauseTimeBetweenBatches { get { throw null; } set { } }
        public bool? PrioritizeUnhealthyInstances { get { throw null; } set { } }
        public bool? RollbackFailedInstancesOnPolicyBreach { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RollingUpgradeProgressInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo>
    {
        internal RollingUpgradeProgressInfo() { }
        public int? FailedInstanceCount { get { throw null; } }
        public int? InProgressInstanceCount { get { throw null; } }
        public int? PendingInstanceCount { get { throw null; } }
        public int? SuccessfulInstanceCount { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RollingUpgradeRunningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus>
    {
        internal RollingUpgradeRunningStatus() { }
        public Azure.ResourceManager.ComputeResource.Models.RollingUpgradeStatusCode? Code { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RollingUpgradeActionType? LastAction { get { throw null; } }
        public System.DateTimeOffset? LastActionOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RollingUpgradeRunningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum RollingUpgradeStatusCode
    {
        RollingForward = 0,
        Cancelled = 1,
        Completed = 2,
        Faulted = 3,
    }
    public partial class RunCommandDocument : Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument>
    {
        internal RunCommandDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition> Parameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Script { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RunCommandDocument System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RunCommandDocument System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandDocumentBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase>
    {
        internal RunCommandDocumentBase() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Label { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.SupportedOperatingSystemType OSType { get { throw null; } }
        public string Schema { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandDocumentBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInput>
    {
        public RunCommandInput(string commandId) { }
        public string CommandId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<string> Script { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RunCommandInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RunCommandInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandInputParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter>
    {
        public RunCommandInputParameter(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity>
    {
        public RunCommandManagedIdentity() { }
        public string ClientId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandParameterDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition>
    {
        internal RunCommandParameterDefinition() { }
        public string DefaultValue { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? Required { get { throw null; } }
        public string RunCommandParameterDefinitionType { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.RunCommandParameterDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScaleInPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy>
    {
        public ScaleInPolicy() { }
        public bool? ForceDeletion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule> Rules { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledEventsPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy>
    {
        public ScheduledEventsPolicy() { }
        public bool? AutomaticallyApprove { get { throw null; } set { } }
        public bool? Enable { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.UserInitiatedRedeploy UserInitiatedRedeploy { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityEncryptionType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType DiskWithVmGuestState { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType NonPersistedTPM { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType VmGuestStateOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType left, Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType left, Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityPostureReferenceUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SecurityPostureReferenceUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SecurityPostureReferenceUpdate>
    {
        public SecurityPostureReferenceUpdate() { }
        public System.Collections.Generic.IList<string> ExcludeExtensions { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public bool? IsOverridable { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.SecurityPostureReferenceUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SecurityPostureReferenceUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SecurityPostureReferenceUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.SecurityPostureReferenceUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SecurityPostureReferenceUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SecurityPostureReferenceUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SecurityPostureReferenceUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SecurityProfile>
    {
        public SecurityProfile() { }
        public bool? EncryptionAtHost { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ProxyAgentSettings ProxyAgentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SecurityType? SecurityType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.UefiSettings UefiSettings { get { throw null; } set { } }
        public string UserAssignedIdentityResourceId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.SecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.SecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.SecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.SecurityType ConfidentialVm { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.SecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.SecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.SecurityType left, Azure.ResourceManager.ComputeResource.Models.SecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.SecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.SecurityType left, Azure.ResourceManager.ComputeResource.Models.SecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SettingName
    {
        AutoLogon = 0,
        FirstLogonCommands = 1,
    }
    public partial class SpotRestorePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy>
    {
        public SpotRestorePolicy() { }
        public bool? Enabled { get { throw null; } set { } }
        public string RestoreTimeout { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SshEncryptionType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.SshEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SshEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.SshEncryptionType Ed25519 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.SshEncryptionType RSA { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.SshEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.SshEncryptionType left, Azure.ResourceManager.ComputeResource.Models.SshEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.SshEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.SshEncryptionType left, Azure.ResourceManager.ComputeResource.Models.SshEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SshGenerateKeyPairInputContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent>
    {
        public SshGenerateKeyPairInputContent() { }
        public Azure.ResourceManager.ComputeResource.Models.SshEncryptionType? EncryptionType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshGenerateKeyPairInputContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPublicKeyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyConfiguration>
    {
        public SshPublicKeyConfiguration() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.SshPublicKeyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.SshPublicKeyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPublicKeyGenerateKeyPairResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult>
    {
        internal SshPublicKeyGenerateKeyPairResult() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyGenerateKeyPairResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPublicKeyPatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch>
    {
        public SshPublicKeyPatch() { }
        public string PublicKey { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.SshPublicKeyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.StorageAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.StorageAccountType PremiumV2Lrs { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.StorageAccountType PremiumZrs { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.StorageAccountType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.StorageAccountType StandardSsdLrs { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.StorageAccountType StandardSsdZrs { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.StorageAccountType UltraSsdLrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.StorageAccountType left, Azure.ResourceManager.ComputeResource.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.StorageAccountType left, Azure.ResourceManager.ComputeResource.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions
    {
        public SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions(Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, string skus, string version) { }
        public string EdgeZone { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string Offer { get { throw null; } }
        public string PublisherName { get { throw null; } }
        public string Skus { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions
    {
        public SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions(Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, string skus) { }
        public string EdgeZone { get { throw null; } }
        public string Expand { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string Offer { get { throw null; } }
        public string Orderby { get { throw null; } set { } }
        public string PublisherName { get { throw null; } }
        public string Skus { get { throw null; } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class SubscriptionResourceGetVirtualMachineImagesOptions
    {
        public SubscriptionResourceGetVirtualMachineImagesOptions(Azure.Core.AzureLocation location, string publisherName, string offer, string skus) { }
        public string Expand { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string Offer { get { throw null; } }
        public string Orderby { get { throw null; } set { } }
        public string PublisherName { get { throw null; } }
        public string Skus { get { throw null; } }
        public int? Top { get { throw null; } set { } }
    }
    public enum SupportedOperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class TerminateNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.TerminateNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.TerminateNotificationProfile>
    {
        public TerminateNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.TerminateNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.TerminateNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.TerminateNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.TerminateNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.TerminateNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.TerminateNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.TerminateNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThrottledRequestsContent : Azure.ResourceManager.ComputeResource.Models.LogAnalyticsInputBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent>
    {
        public ThrottledRequestsContent(System.Uri blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime) : base (default(System.Uri), default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
        Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.ThrottledRequestsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UefiSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UefiSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UefiSettings>
    {
        public UefiSettings() { }
        public bool? IsSecureBootEnabled { get { throw null; } set { } }
        public bool? IsVirtualTpmEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.UefiSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UefiSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UefiSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.UefiSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UefiSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UefiSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UefiSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradeOperationHistoricalStatusInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo>
    {
        internal UpgradeOperationHistoricalStatusInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties Properties { get { throw null; } }
        public string UpgradeOperationHistoricalStatusInfoType { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradeOperationHistoricalStatusInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties>
    {
        internal UpgradeOperationHistoricalStatusInfoProperties() { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError Error { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RollingUpgradeProgressInfo Progress { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RollbackStatusInfo RollbackInfo { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus RunningStatus { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.UpgradeOperationInvoker? StartedBy { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ImageReference TargetImageReference { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoricalStatusInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradeOperationHistoryStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus>
    {
        internal UpgradeOperationHistoryStatus() { }
        public Azure.ResourceManager.ComputeResource.Models.UpgradeState? Code { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UpgradeOperationHistoryStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum UpgradeOperationInvoker
    {
        Unknown = 0,
        User = 1,
        Platform = 2,
    }
    public enum UpgradeState
    {
        RollingForward = 0,
        Cancelled = 1,
        Completed = 2,
        Faulted = 3,
    }
    public partial class UserInitiatedRedeploy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UserInitiatedRedeploy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UserInitiatedRedeploy>
    {
        public UserInitiatedRedeploy() { }
        public bool? AutomaticallyApprove { get { throw null; } set { } }
        public string DummyProperty { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.UserInitiatedRedeploy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UserInitiatedRedeploy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.UserInitiatedRedeploy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.UserInitiatedRedeploy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UserInitiatedRedeploy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UserInitiatedRedeploy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.UserInitiatedRedeploy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VaultCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VaultCertificate>
    {
        public VaultCertificate() { }
        public string CertificateStore { get { throw null; } set { } }
        public System.Uri CertificateUri { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VaultCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VaultCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VaultCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VaultCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VaultCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VaultCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VaultCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultSecretGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup>
    {
        public VaultSecretGroup() { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VaultCertificate> VaultCertificates { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineAgentInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView>
    {
        internal VirtualMachineAgentInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView> ExtensionHandlers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public string VmAgentVersion { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineAssessPatchesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult>
    {
        internal VirtualMachineAssessPatchesResult() { }
        public string AssessmentActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties> AvailablePatches { get { throw null; } }
        public int? CriticalAndSecurityPatchCount { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError Error { get { throw null; } }
        public int? OtherPatchCount { get { throw null; } }
        public bool? RebootPending { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus? Status { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineAssessPatchesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineCaptureContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent>
    {
        public VirtualMachineCaptureContent(string vhdPrefix, string destinationContainerName, bool overwriteVhds) { }
        public string DestinationContainerName { get { throw null; } }
        public bool OverwriteVhds { get { throw null; } }
        public string VhdPrefix { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineCaptureResult : Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult>
    {
        public VirtualMachineCaptureResult() { }
        public string ContentVersion { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> Resources { get { throw null; } }
        public string Schema { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineCaptureResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk>
    {
        public VirtualMachineDataDisk(int lun, Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeResource.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskDetachOptionType? DetachOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } }
        public long? DiskMBpsReadWrite { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public bool? ToBeDetached { get { throw null; } set { } }
        public System.Uri VhdUri { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineDiskSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile>
    {
        public VirtualMachineDiskSecurityProfile() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SecurityEncryptionType? SecurityEncryptionType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineDiskType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineDiskType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskType None { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskType Unmanaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskType left, Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskType left, Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineEvictionPolicyType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineEvictionPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType left, Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType left, Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineExtensionHandlerInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView>
    {
        internal VirtualMachineExtensionHandlerInstanceView() { }
        public Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus Status { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        public string VirtualMachineExtensionHandlerInstanceViewType { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionHandlerInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView>
    {
        public VirtualMachineExtensionInstanceView() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Substatuses { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string VirtualMachineExtensionInstanceViewType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionPatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch>
    {
        public VirtualMachineExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineGalleryApplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication>
    {
        public VirtualMachineGalleryApplication(string packageReferenceId) { }
        public string ConfigurationReference { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public string PackageReferenceId { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
        public bool? TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile>
    {
        public VirtualMachineHardwareProfile() { }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType? VmSize { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties VmSizeProperties { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineImage : Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>
    {
        public VirtualMachineImage(string name, Azure.Core.AzureLocation location) : base (default(string), default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ComputeResource.Models.ArchitectureType? Architecture { get { throw null; } set { } }
        public bool? AutomaticOSUpgradeSupported { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.DataDiskImage> DataDiskImages { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskType? DisallowedVmDiskType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ImageDeprecationStatus ImageDeprecationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SupportedOperatingSystemType? OSDiskImageOperatingSystem { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.PurchasePlan Plan { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineImageBase : Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase>
    {
        public VirtualMachineImageBase(string name, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineImageFeature : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageFeature>
    {
        public VirtualMachineImageFeature() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageFeature System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageFeature System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineImageFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstallPatchesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent>
    {
        public VirtualMachineInstallPatchesContent(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting rebootSetting) { }
        public Azure.ResourceManager.ComputeResource.Models.LinuxParameters LinuxParameters { get { throw null; } set { } }
        public System.TimeSpan? MaximumDuration { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting RebootSetting { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.WindowsParameters WindowsParameters { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstallPatchesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult>
    {
        internal VirtualMachineInstallPatchesResult() { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceApiError Error { get { throw null; } }
        public int? ExcludedPatchCount { get { throw null; } }
        public int? FailedPatchCount { get { throw null; } }
        public string InstallationActivityId { get { throw null; } }
        public int? InstalledPatchCount { get { throw null; } }
        public bool? MaintenanceWindowExceeded { get { throw null; } }
        public int? NotSelectedPatchCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.PatchInstallationDetail> Patches { get { throw null; } }
        public int? PendingPatchCount { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus? RebootStatus { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.PatchOperationStatus? Status { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstallPatchesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView>
    {
        internal VirtualMachineInstanceView() { }
        public string AssignedHost { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView BootDiagnostics { get { throw null; } }
        public string ComputerName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView> Disks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView> Extensions { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public bool? IsVmInStandbyPool { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus MaintenanceRedeployStatus { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus PatchStatus { get { throw null; } }
        public int? PlatformFaultDomain { get { throw null; } }
        public int? PlatformUpdateDomain { get { throw null; } }
        public string RdpThumbPrint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView VmAgent { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus VmHealthStatus { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineIPTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineIPTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineIPTag>
    {
        public VirtualMachineIPTag() { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineIPTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineIPTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineIPTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineIPTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineIPTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineIPTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineIPTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineManagedDisk : Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk>
    {
        public VirtualMachineManagedDisk() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceConfiguration>
    {
        public VirtualMachineNetworkInterfaceConfiguration(string name) { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.Core.ResourceIdentifier DscpConfigurationId { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceIPConfiguration> IPConfigurations { get { throw null; } }
        public bool? IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceIPConfiguration>
    {
        public VirtualMachineNetworkInterfaceIPConfiguration(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.IPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceReference : Azure.ResourceManager.ComputeResource.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceReference>
    {
        public VirtualMachineNetworkInterfaceReference() { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption? DeleteOption { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile>
    {
        public VirtualMachineNetworkProfile() { }
        public Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkInterfaceReference> NetworkInterfaces { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSDisk>
    {
        public VirtualMachineOSDisk(Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeResource.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskEncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SupportedOperatingSystemType? OSType { get { throw null; } set { } }
        public System.Uri VhdUri { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile>
    {
        public VirtualMachineOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public bool? AllowExtensionOperations { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public bool? RequireGuestProvisionSignal { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch>
    {
        public VirtualMachinePatch() { }
        public Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AvailabilitySetId { get { throw null; } set { } }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType? EvictionPolicy { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile StorageProfile { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UserData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineScaleSetId { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePatchStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus>
    {
        internal VirtualMachinePatchStatus() { }
        public Azure.ResourceManager.ComputeResource.Models.AvailablePatchSummary AvailablePatchSummary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> ConfigurationStatuses { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.LastPatchInstallationSummary LastPatchInstallationSummary { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePatchStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePriorityType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePriorityType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType Low { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType Regular { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType left, Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType left, Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressConfiguration>
    {
        public VirtualMachinePublicIPAddressConfiguration(string name) { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineIPTag> IPTags { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.IPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.PublicIPAllocationMethod? PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku Sku { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressDnsSettingsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>
    {
        public VirtualMachinePublicIPAddressDnsSettingsConfiguration(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType? DomainNameLabelScope { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineReimageContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent>
    {
        public VirtualMachineReimageContent() { }
        public string ExactVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.OSProfileProvisioningData OSProfile { get { throw null; } set { } }
        public bool? TempDisk { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRunCommandInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView>
    {
        internal VirtualMachineRunCommandInstanceView() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Error { get { throw null; } }
        public string ExecutionMessage { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ExecutionState? ExecutionState { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public string Output { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRunCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult>
    {
        internal VirtualMachineRunCommandResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Value { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRunCommandScriptSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource>
    {
        public VirtualMachineRunCommandScriptSource() { }
        public string CommandId { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Uri ScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity ScriptUriManagedIdentity { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRunCommandUpdate : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate>
    {
        public VirtualMachineRunCommandUpdate() { }
        public bool? AsyncExecution { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity ErrorBlobManagedIdentity { get { throw null; } set { } }
        public System.Uri ErrorBlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.RunCommandManagedIdentity OutputBlobManagedIdentity { get { throw null; } set { } }
        public System.Uri OutputBlobUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.RunCommandInputParameter> ProtectedParameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string RunAsPassword { get { throw null; } set { } }
        public string RunAsUser { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandScriptSource Source { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public bool? TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineRunCommandUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetConvertToSinglePlacementGroupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>
    {
        public VirtualMachineScaleSetConvertToSinglePlacementGroupContent() { }
        public string ActivePlacementGroupId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk>
    {
        public VirtualMachineScaleSetDataDisk(int lun, Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeResource.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch>
    {
        public VirtualMachineScaleSetExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile>
    {
        public VirtualMachineScaleSetExtensionProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.VirtualMachineScaleSetExtensionData> Extensions { get { throw null; } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineScaleSetGetExpand : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineScaleSetGetExpand(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand UserData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand left, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand left, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetGetExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineScaleSetInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView>
    {
        internal VirtualMachineScaleSetInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary> Extensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.OrchestrationServiceSummary> OrchestrationServices { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount> VirtualMachineStatusesSummary { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPConfiguration>
    {
        public VirtualMachineScaleSetIPConfiguration(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerInboundNatPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.IPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetIPTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPTag>
    {
        public VirtualMachineScaleSetIPTag() { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetManagedDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk>
    {
        public VirtualMachineScaleSetManagedDisk() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration>
    {
        public VirtualMachineScaleSetNetworkConfiguration(string name) { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPConfiguration> IPConfigurations { get { throw null; } }
        public bool? IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile>
    {
        public VirtualMachineScaleSetNetworkProfile() { }
        public Azure.Core.ResourceIdentifier HealthProbeId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSDisk>
    {
        public VirtualMachineScaleSetOSDisk(Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.ComputeResource.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SupportedOperatingSystemType? OSType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile>
    {
        public VirtualMachineScaleSetOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public bool? AllowExtensionOperations { get { throw null; } set { } }
        public string ComputerNamePrefix { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public bool? RequireGuestProvisionSignal { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPatch : Azure.ResourceManager.ComputeResource.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch>
    {
        public VirtualMachineScaleSetPatch() { }
        public Azure.ResourceManager.ComputeResource.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public bool? DoNotRunExtensionsOnOverprovisionedVms { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? Overprovision { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourcePlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy PriorityMixPolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ResiliencyPolicy ResiliencyPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public bool? SinglePlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeSkuProfile SkuProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SpotRestorePolicy SpotRestorePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateVmProfile VirtualMachineProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode? ZonalPlatformFaultDomainAlignMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPriorityMixPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy>
    {
        public VirtualMachineScaleSetPriorityMixPolicy() { }
        public int? BaseRegularPriorityCount { get { throw null; } set { } }
        public int? RegularPriorityPercentageAboveBase { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPriorityMixPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>
    {
        public VirtualMachineScaleSetPublicIPAddressConfiguration(string name) { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetIPTag> IPTags { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.IPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourcePublicIPAddressSku Sku { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>
    {
        public VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DomainNameLabelScopeType? DomainNameLabelScope { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetReimageContent : Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent>
    {
        public VirtualMachineScaleSetReimageContent() { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetReimageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineScaleSetScaleInRule : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineScaleSetScaleInRule(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule Default { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule NewestVm { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule OldestVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule left, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule left, Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetScaleInRule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineScaleSetSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku>
    {
        internal VirtualMachineScaleSetSku() { }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceSku Sku { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity>
    {
        internal VirtualMachineScaleSetSkuCapacity() { }
        public long? DefaultCapacity { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuScaleType? ScaleType { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum VirtualMachineScaleSetSkuScaleType
    {
        None = 0,
        Automatic = 1,
    }
    public partial class VirtualMachineScaleSetStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile>
    {
        public VirtualMachineScaleSetStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } }
        public string DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSDisk OSDisk { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateIPConfiguration>
    {
        public VirtualMachineScaleSetUpdateIPConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationGatewayBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ApplicationSecurityGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerBackendAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> LoadBalancerInboundNatPools { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.IPVersion? PrivateIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>
    {
        public VirtualMachineScaleSetUpdateNetworkConfiguration() { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeNetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateIPConfiguration> IPConfigurations { get { throw null; } }
        public bool? IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkProfile>
    {
        public VirtualMachineScaleSetUpdateNetworkProfile() { }
        public Azure.Core.ResourceIdentifier HealthProbeId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSDisk>
    {
        public VirtualMachineScaleSetUpdateOSDisk() { }
        public Azure.ResourceManager.ComputeResource.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetManagedDisk ManagedDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSProfile>
    {
        public VirtualMachineScaleSetUpdateOSProfile() { }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdatePublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>
    {
        public VirtualMachineScaleSetUpdatePublicIPAddressConfiguration() { }
        public Azure.ResourceManager.ComputeResource.Models.ComputeResourceDeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateStorageProfile>
    {
        public VirtualMachineScaleSetUpdateStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } }
        public string DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSDisk OSDisk { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateVmProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateVmProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateVmProfile>
    {
        public VirtualMachineScaleSetUpdateVmProfile() { }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties HardwareVmSizeProperties { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SecurityPostureReferenceUpdate SecurityPostureReference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateVmProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateVmProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateVmProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateVmProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateVmProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateVmProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpdateVmProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum VirtualMachineScaleSetUpgradeMode
    {
        Automatic = 0,
        Manual = 1,
        Rolling = 2,
    }
    public partial class VirtualMachineScaleSetUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy>
    {
        public VirtualMachineScaleSetUpgradePolicy() { }
        public Azure.ResourceManager.ComputeResource.Models.AutomaticOSUpgradePolicy AutomaticOSUpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradeMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.RollingUpgradePolicy RollingUpgradePolicy { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch>
    {
        public VirtualMachineScaleSetVmExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionsSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary>
    {
        internal VirtualMachineScaleSetVmExtensionsSummary() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount> StatusesSummary { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmExtensionsSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmInstanceIds : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds>
    {
        public VirtualMachineScaleSetVmInstanceIds() { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceIds>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmInstanceRequiredIds : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds>
    {
        public VirtualMachineScaleSetVmInstanceRequiredIds(System.Collections.Generic.IEnumerable<string> instanceIds) { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceRequiredIds>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView>
    {
        internal VirtualMachineScaleSetVmInstanceView() { }
        public Azure.Core.ResourceIdentifier AssignedHost { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.BootDiagnosticsInstanceView BootDiagnostics { get { throw null; } }
        public string ComputerName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.DiskInstanceView> Disks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineExtensionInstanceView> Extensions { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.MaintenanceRedeployStatus MaintenanceRedeployStatus { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string PlacementGroupId { get { throw null; } }
        public int? PlatformFaultDomain { get { throw null; } }
        public int? PlatformUpdateDomain { get { throw null; } }
        public string RdpThumbPrint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineAgentInstanceView VmAgent { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.InstanceViewStatus VmHealthStatus { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile>
    {
        public VirtualMachineScaleSetVmProfile() { }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineEvictionPolicyType? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties HardwareVmSizeProperties { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachinePriorityType? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ComputeSecurityPostureReference SecurityPostureReference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceArtifactReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetStorageProfile StorageProfile { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UserData { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmProtectionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy>
    {
        public VirtualMachineScaleSetVmProtectionPolicy() { }
        public bool? ProtectFromScaleIn { get { throw null; } set { } }
        public bool? ProtectFromScaleSetActions { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmReimageContent : Azure.ResourceManager.ComputeResource.Models.VirtualMachineReimageContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent>
    {
        public VirtualMachineScaleSetVmReimageContent() { }
        public bool? ForceUpdateOSDiskForEphemeral { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineScaleSetVmReimageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineSize : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize>
    {
        internal VirtualMachineSize() { }
        public int? MaxDataDiskCount { get { throw null; } }
        public int? MemoryInMB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public int? OSDiskSizeInMB { get { throw null; } }
        public int? ResourceDiskSizeInMB { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSize>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineSizeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties>
    {
        public VirtualMachineSizeProperties() { }
        public int? VCpusAvailable { get { throw null; } set { } }
        public int? VCpusPerCore { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineSizeType : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineSizeType(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType BasicA0 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType BasicA1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType BasicA2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType BasicA3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType BasicA4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA0 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA10 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA11 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA1V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA2MV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA4MV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA5 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA6 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA7 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA8 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA8MV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA8V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardA9 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardB1Ms { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardB1S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardB2Ms { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardB2S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardB4Ms { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardB8Ms { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD11 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD12 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD13 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD14 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD15V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD16V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD1V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD2V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD2V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD32V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD3V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD4V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD4V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD5V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD64SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD64V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardD8V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS11 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS11V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS12 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS12V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS13 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS132V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS134V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS14 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS144V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS148V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS14V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS15V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS1V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE16SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE16V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE2SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE2V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE3216V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE328SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE32SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE32V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE4SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE4V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE6416SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE6432SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE64SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE64V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE8SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardE8V3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF16 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF16S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF16SV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF1S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF2S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF2SV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF32SV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF4S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF4SV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF64SV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF72SV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF8 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF8S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardF8SV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardG1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardG2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardG3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardG4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardG5 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardGS1 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardGS2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardGS3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardGS4 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardGS44 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardGS48 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardGS5 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardGS516 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardGS58 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardH16 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardH16M { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardH16Mr { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardH16R { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardH8 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardH8M { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardL16S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardL32S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardL4S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardL8S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardM12832Ms { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardM12864Ms { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardM128Ms { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardM128S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardM6416Ms { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardM6432Ms { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardM64Ms { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardM64S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC12 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC12SV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC12SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC24 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC24R { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC24RsV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC24RsV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC24SV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC24SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC6 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC6SV2 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNC6SV3 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardND12S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardND24Rs { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardND24S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardND6S { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNV12 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNV24 { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType StandardNV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType left, Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType left, Azure.ResourceManager.ComputeResource.Models.VirtualMachineSizeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineSoftwarePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties>
    {
        internal VirtualMachineSoftwarePatchProperties() { }
        public string ActivityId { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.PatchAssessmentState? AssessmentState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Classifications { get { throw null; } }
        public string KbId { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string PatchId { get { throw null; } }
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior? RebootBehavior { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineSoftwarePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineStatusCodeCount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount>
    {
        internal VirtualMachineStatusCodeCount() { }
        public string Code { get { throw null; } }
        public int? Count { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStatusCodeCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile>
    {
        public VirtualMachineStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VirtualMachineDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.DiskControllerType? DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.VirtualMachineOSDisk OSDisk { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.VirtualMachineStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchClassificationForLinux : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchClassificationForLinux(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux Critical { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux Other { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux Security { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux left, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux left, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForLinux right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchClassificationForWindows : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchClassificationForWindows(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows Critical { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows Definition { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows FeaturePack { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows Security { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows ServicePack { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows Tools { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows UpdateRollUp { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows Updates { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows left, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows left, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchRebootBehavior : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchRebootBehavior(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior AlwaysRequiresReboot { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior CanRequestReboot { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior NeverReboots { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior left, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior left, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting left, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting left, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchRebootStatus : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchRebootStatus(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus NotNeeded { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus Required { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus Started { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus left, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus left, Azure.ResourceManager.ComputeResource.Models.VmGuestPatchRebootStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration>
    {
        public WindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.AdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } }
        public bool? IsAutomaticUpdatesEnabled { get { throw null; } set { } }
        public bool? IsVmAgentPlatformUpdatesEnabled { get { throw null; } }
        public Azure.ResourceManager.ComputeResource.Models.PatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.WinRMListener> WinRMListeners { get { throw null; } }
        Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WindowsParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WindowsParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsParameters>
    {
        public WindowsParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeResource.Models.VmGuestPatchClassificationForWindows> ClassificationsToInclude { get { throw null; } }
        public bool? ExcludeKbsRequiringReboot { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KbNumbersToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> KbNumbersToInclude { get { throw null; } }
        public System.DateTimeOffset? MaxPatchPublishOn { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.WindowsParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WindowsParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WindowsParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.WindowsParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsPatchAssessmentMode : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.WindowsPatchAssessmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsPatchAssessmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.WindowsPatchAssessmentMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.WindowsPatchAssessmentMode ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.WindowsPatchAssessmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.ComputeResource.Models.WindowsPatchAssessmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.WindowsPatchAssessmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.WindowsPatchAssessmentMode left, Azure.ResourceManager.ComputeResource.Models.WindowsPatchAssessmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsVmGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>
    {
        public WindowsVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsVmGuestPatchMode : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmGuestPatchMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode AutomaticByOS { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode left, Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode left, Azure.ResourceManager.ComputeResource.Models.WindowsVmGuestPatchMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WinRMListener : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WinRMListener>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WinRMListener>
    {
        public WinRMListener() { }
        public System.Uri CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.ComputeResource.Models.WinRMListenerProtocolType? Protocol { get { throw null; } set { } }
        Azure.ResourceManager.ComputeResource.Models.WinRMListener System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WinRMListener>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeResource.Models.WinRMListener>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeResource.Models.WinRMListener System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WinRMListener>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WinRMListener>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeResource.Models.WinRMListener>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WinRMListenerProtocolType
    {
        Http = 0,
        Https = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZonalPlatformFaultDomainAlignMode : System.IEquatable<Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZonalPlatformFaultDomainAlignMode(string value) { throw null; }
        public static Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode Aligned { get { throw null; } }
        public static Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode Unaligned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode left, Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode left, Azure.ResourceManager.ComputeResource.Models.ZonalPlatformFaultDomainAlignMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
