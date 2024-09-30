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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.AvailabilitySetResource> GetIfExists(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.AvailabilitySetResource>> GetIfExistsAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.AvailabilitySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.AvailabilitySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.AvailabilitySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.AvailabilitySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvailabilitySetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.AvailabilitySetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.AvailabilitySetData>
    {
        public AvailabilitySetData(Azure.Core.AzureLocation location) { }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public int? PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.Compute.AvailabilitySetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.AvailabilitySetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.AvailabilitySetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.AvailabilitySetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.AvailabilitySetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.AvailabilitySetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.AvailabilitySetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilitySetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.AvailabilitySetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.AvailabilitySetData>
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
        Azure.ResourceManager.Compute.AvailabilitySetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.AvailabilitySetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.AvailabilitySetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.AvailabilitySetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.AvailabilitySetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.AvailabilitySetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.AvailabilitySetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource> Update(Azure.ResourceManager.Compute.Models.AvailabilitySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.AvailabilitySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservationResource>, System.Collections.IEnumerable
    {
        protected CapacityReservationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capacityReservationName, Azure.ResourceManager.Compute.CapacityReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capacityReservationName, Azure.ResourceManager.Compute.CapacityReservationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> Get(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CapacityReservationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CapacityReservationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> GetAsync(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.CapacityReservationResource> GetIfExists(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.CapacityReservationResource>> GetIfExistsAsync(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CapacityReservationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CapacityReservationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapacityReservationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationData>
    {
        public CapacityReservationData(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.ComputeSku sku) { }
        public Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView InstanceView { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Compute.CapacityReservationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.CapacityReservationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityReservationGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroupResource>, System.Collections.IEnumerable
    {
        protected CapacityReservationGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capacityReservationGroupName, Azure.ResourceManager.Compute.CapacityReservationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capacityReservationGroupName, Azure.ResourceManager.Compute.CapacityReservationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> Get(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetAll(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetAllAsync(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> GetAsync(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetIfExists(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> GetIfExistsAsync(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.CapacityReservationGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.CapacityReservationGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.CapacityReservationGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapacityReservationGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>
    {
        public CapacityReservationGroupData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> CapacityReservations { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView InstanceView { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> SharingSubscriptionIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Compute.CapacityReservationGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.CapacityReservationGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityReservationGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>
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
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> Get(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> GetAsync(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> GetCapacityReservation(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> GetCapacityReservationAsync(string capacityReservationName, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.CapacityReservationCollection GetCapacityReservations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.CapacityReservationGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.CapacityReservationGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> Update(Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityReservationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationData>
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
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> Get(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> GetAsync(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.CapacityReservationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.CapacityReservationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.CapacityReservationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.CapacityReservationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.CapacityReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.CapacityReservationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.CapacityReservationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetCapacityReservationGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> GetCapacityReservationGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservationGroupResource GetCapacityReservationGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservationGroupCollection GetCapacityReservationGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetCapacityReservationGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand?), Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup? resourceIdsOnly = default(Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetCapacityReservationGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand?), Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup? resourceIdsOnly = default(Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservationResource GetCapacityReservationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetDedicatedHostGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> GetDedicatedHostGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHostGroupResource GetDedicatedHostGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHostGroupCollection GetDedicatedHostGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetDedicatedHostGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetDedicatedHostGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHostResource GetDedicatedHostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.DiskImageResource> GetDiskImage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskImageResource>> GetDiskImageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.DiskImageResource GetDiskImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.DiskImageCollection GetDiskImages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.DiskImageResource> GetDiskImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskImageResource> GetDiskImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> GetRestorePointGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string restorePointGroupName, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> GetRestorePointGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string restorePointGroupName, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePointGroupResource GetRestorePointGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePointGroupCollection GetRestorePointGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.RestorePointGroupResource> GetRestorePointGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.RestorePointGroupResource> GetRestorePointGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePointResource GetRestorePointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> GetSshPublicKey(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> GetSshPublicKeyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.SshPublicKeyResource GetSshPublicKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Compute.SshPublicKeyCollection GetSshPublicKeys(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.SshPublicKeyResource> GetSshPublicKeys(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.SshPublicKeyResource> GetSshPublicKeysAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.ComputeUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ComputeUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> GetVirtualMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesByEdgeZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesByEdgeZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage> GetVirtualMachineImagesEdgeZone(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage>> GetVirtualMachineImagesEdgeZoneAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesEdgeZones(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesEdgeZonesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineResource GetVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandDocument> GetVirtualMachineRunCommand(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandDocument>> GetVirtualMachineRunCommandAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineRunCommandResource GetVirtualMachineRunCommandResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> GetVirtualMachineRunCommands(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> GetVirtualMachineRunCommandsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineCollection GetVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string statusOnly = null, string filter = null, Azure.ResourceManager.Compute.Models.ExpandTypesForListVm? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForListVm?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string statusOnly = null, string filter = null, Azure.ResourceManager.Compute.Models.ExpandTypesForListVm? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForListVm?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachinesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachinesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> GetVirtualMachineScaleSetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DedicatedHostCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHostResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHostResource>, System.Collections.IEnumerable
    {
        protected DedicatedHostCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hostName, Azure.ResourceManager.Compute.DedicatedHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hostName, Azure.ResourceManager.Compute.DedicatedHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> Get(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DedicatedHostResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DedicatedHostResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> GetAsync(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.DedicatedHostResource> GetIfExists(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.DedicatedHostResource>> GetIfExistsAsync(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DedicatedHostResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHostResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DedicatedHostResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHostResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHostData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostData>
    {
        public DedicatedHostData(Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.ComputeSku sku) { }
        public bool? AutoReplaceOnFailure { get { throw null; } set { } }
        public string HostId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostLicenseType? LicenseType { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.Compute.DedicatedHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.DedicatedHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroupResource>, System.Collections.IEnumerable
    {
        protected DedicatedHostGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hostGroupName, Azure.ResourceManager.Compute.DedicatedHostGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hostGroupName, Azure.ResourceManager.Compute.DedicatedHostGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> Get(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> GetAsync(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetIfExists(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> GetIfExistsAsync(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DedicatedHostGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DedicatedHostGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DedicatedHostGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHostGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>
    {
        public DedicatedHostGroupData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> DedicatedHosts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName> InstanceViewHosts { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public bool? SupportAutomaticPlacement { get { throw null; } set { } }
        public bool? UltraSsdEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Compute.DedicatedHostGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.DedicatedHostGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>
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
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> Get(Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> GetDedicatedHost(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> GetDedicatedHostAsync(string hostName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostCollection GetDedicatedHosts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.DedicatedHostGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.DedicatedHostGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> Update(Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHostResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostData>
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
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> Get(Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetAvailableSizes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetAvailableSizesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.DedicatedHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DedicatedHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.DedicatedHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DedicatedHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.DedicatedHostPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DedicatedHostResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.DedicatedHostPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskImageResource>, System.Collections.IEnumerable
    {
        protected DiskImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.Compute.DiskImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string imageName, Azure.ResourceManager.Compute.DiskImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskImageResource> Get(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DiskImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskImageResource>> GetAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.DiskImageResource> GetIfExists(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.DiskImageResource>> GetIfExistsAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.DiskImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.DiskImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.DiskImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.DiskImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DiskImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DiskImageData>
    {
        public DiskImageData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceVirtualMachineId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageStorageProfile StorageProfile { get { throw null; } set { } }
        Azure.ResourceManager.Compute.DiskImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DiskImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DiskImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.DiskImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DiskImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DiskImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DiskImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DiskImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DiskImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskImageResource() { }
        public virtual Azure.ResourceManager.Compute.DiskImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string imageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskImageResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskImageResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.DiskImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DiskImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.DiskImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.DiskImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DiskImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DiskImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.DiskImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.DiskImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.DiskImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.DiskImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> GetIfExists(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> GetIfExistsAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProximityPlacementGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>
    {
        public ProximityPlacementGroupData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus> AvailabilitySets { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IntentVmSizes { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType? ProximityPlacementGroupType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus> VirtualMachines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus> VirtualMachineScaleSets { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Compute.ProximityPlacementGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.ProximityPlacementGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProximityPlacementGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>
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
        Azure.ResourceManager.Compute.ProximityPlacementGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.ProximityPlacementGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.ProximityPlacementGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> Update(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointCollection : Azure.ResourceManager.ArmCollection
    {
        protected RestorePointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string restorePointName, Azure.ResourceManager.Compute.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string restorePointName, Azure.ResourceManager.Compute.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string restorePointName, Azure.ResourceManager.Compute.Models.RestorePointExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointName, Azure.ResourceManager.Compute.Models.RestorePointExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointResource> Get(string restorePointName, Azure.ResourceManager.Compute.Models.RestorePointExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointResource>> GetAsync(string restorePointName, Azure.ResourceManager.Compute.Models.RestorePointExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.RestorePointResource> GetIfExists(string restorePointName, Azure.ResourceManager.Compute.Models.RestorePointExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.RestorePointResource>> GetIfExistsAsync(string restorePointName, Azure.ResourceManager.Compute.Models.RestorePointExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointData>
    {
        public RestorePointData() { }
        public Azure.ResourceManager.Compute.Models.ConsistencyModeType? ConsistencyMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ExcludeDisks { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointInstanceView InstanceView { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata SourceMetadata { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceRestorePointId { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } set { } }
        Azure.ResourceManager.Compute.RestorePointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.RestorePointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.RestorePointGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.RestorePointGroupResource>, System.Collections.IEnumerable
    {
        protected RestorePointGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string restorePointGroupName, Azure.ResourceManager.Compute.RestorePointGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string restorePointGroupName, Azure.ResourceManager.Compute.RestorePointGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string restorePointGroupName, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointGroupName, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> Get(string restorePointGroupName, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.RestorePointGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.RestorePointGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> GetAsync(string restorePointGroupName, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.RestorePointGroupResource> GetIfExists(string restorePointGroupName, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.RestorePointGroupResource>> GetIfExistsAsync(string restorePointGroupName, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.RestorePointGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.RestorePointGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.RestorePointGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.RestorePointGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorePointGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointGroupData>
    {
        public RestorePointGroupData(Azure.Core.AzureLocation location) { }
        public string ProvisioningState { get { throw null; } }
        public string RestorePointGroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.RestorePointData> RestorePoints { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointGroupSource Source { get { throw null; } set { } }
        Azure.ResourceManager.Compute.RestorePointGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.RestorePointGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePointGroupResource() { }
        public virtual Azure.ResourceManager.Compute.RestorePointGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> Get(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> GetAsync(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointResource> GetRestorePoint(string restorePointName, Azure.ResourceManager.Compute.Models.RestorePointExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointResource>> GetRestorePointAsync(string restorePointName, Azure.ResourceManager.Compute.Models.RestorePointExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.RestorePointCollection GetRestorePoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.RestorePointGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.RestorePointGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> Update(Azure.ResourceManager.Compute.Models.RestorePointGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.RestorePointGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePointResource() { }
        public virtual Azure.ResourceManager.Compute.RestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointGroupName, string restorePointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointResource> Get(Azure.ResourceManager.Compute.Models.RestorePointExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointResource>> GetAsync(Azure.ResourceManager.Compute.Models.RestorePointExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.RestorePointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.RestorePointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.RestorePointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.RestorePointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.RestorePointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.RestorePointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.SshPublicKeyResource> GetIfExists(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.SshPublicKeyResource>> GetIfExistsAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.SshPublicKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.SshPublicKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.SshPublicKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.SshPublicKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SshPublicKeyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.SshPublicKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.SshPublicKeyData>
    {
        public SshPublicKeyData(Azure.Core.AzureLocation location) { }
        public string PublicKey { get { throw null; } set { } }
        Azure.ResourceManager.Compute.SshPublicKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.SshPublicKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.SshPublicKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.SshPublicKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.SshPublicKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.SshPublicKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.SshPublicKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPublicKeyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.SshPublicKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.SshPublicKeyData>
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
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult> GenerateKeyPair(Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>> GenerateKeyPairAsync(Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.SshPublicKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.SshPublicKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.SshPublicKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.SshPublicKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.SshPublicKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.SshPublicKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.SshPublicKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> Update(Azure.ResourceManager.Compute.Models.SshPublicKeyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> UpdateAsync(Azure.ResourceManager.Compute.Models.SshPublicKeyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmName, Azure.ResourceManager.Compute.VirtualMachineData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmName, Azure.ResourceManager.Compute.VirtualMachineData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> Get(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetAll(string filter = null, Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType? expand = default(Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetAllAsync(string filter = null, Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType? expand = default(Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> GetAsync(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineResource> GetIfExists(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineResource>> GetIfExistsAsync(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineData>
    {
        public VirtualMachineData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AvailabilitySetId { get { throw null; } set { } }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePlan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.VirtualMachineExtensionData> Resources { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile StorageProfile { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UserData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineScaleSetId { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Compute.VirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> GetIfExists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>> GetIfExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineExtensionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>
    {
        public VirtualMachineExtensionData(Azure.Core.AzureLocation location) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.Compute.VirtualMachineExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> GetIfExists(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>> GetIfExistsAsync(string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineExtensionImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>
    {
        public VirtualMachineExtensionImageData(Azure.Core.AzureLocation location) { }
        public string ComputeRole { get { throw null; } set { } }
        public string HandlerSchema { get { throw null; } set { } }
        public string OperatingSystem { get { throw null; } set { } }
        public bool? SupportsMultipleExtensions { get { throw null; } set { } }
        public bool? VirtualMachineScaleSetEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Compute.VirtualMachineExtensionImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineExtensionImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineExtensionImageResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string publisherName, string type, string version) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.VirtualMachineExtensionImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineExtensionImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>
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
        Azure.ResourceManager.Compute.VirtualMachineExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult> AssessPatches(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>> AssessPatchesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile> AttachDetachDataDisks(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest attachDetachDataDisksRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile>> AttachDetachDataDisksAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest attachDetachDataDisksRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> Get(Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult> RunCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult>> RunCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SimulateEviction(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SimulateEvictionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.VirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachinePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachinePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> GetIfExists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>> GetIfExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineRunCommandData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>
    {
        public VirtualMachineRunCommandData(Azure.Core.AzureLocation location) { }
        public bool? AsyncExecution { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity ErrorBlobManagedIdentity { get { throw null; } set { } }
        public System.Uri ErrorBlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity OutputBlobManagedIdentity { get { throw null; } set { } }
        public System.Uri OutputBlobUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> ProtectedParameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string RunAsPassword { get { throw null; } set { } }
        public string RunAsUser { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource Source { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public bool? TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        Azure.ResourceManager.Compute.VirtualMachineRunCommandData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineRunCommandData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRunCommandResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>
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
        Azure.ResourceManager.Compute.VirtualMachineRunCommandData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineRunCommandData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineRunCommandResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualMachineScaleSetName, Azure.ResourceManager.Compute.VirtualMachineScaleSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualMachineScaleSetName, Azure.ResourceManager.Compute.VirtualMachineScaleSetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> Get(string virtualMachineScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> GetAsync(string virtualMachineScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetIfExists(string virtualMachineScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> GetIfExistsAsync(string virtualMachineScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>
    {
        public VirtualMachineScaleSetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public bool? DoNotRunExtensionsOnOverprovisionedVms { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsMaximumCapacityConstrained { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OrchestrationMode? OrchestrationMode { get { throw null; } set { } }
        public bool? Overprovision { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePlan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy PriorityMixPolicy { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ResiliencyPolicy ResiliencyPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public bool? SinglePlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSkuProfile SkuProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SpotRestorePolicy SpotRestorePolicy { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile VirtualMachineProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode? ZonalPlatformFaultDomainAlignMode { get { throw null; } set { } }
        public bool? ZoneBalance { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> GetIfExists(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>> GetIfExistsAsync(string vmssExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>
    {
        public VirtualMachineScaleSetExtensionData() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetExtensionResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string vmssExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ApproveRollingUpgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ApproveRollingUpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CancelVirtualMachineScaleSetRollingUpgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelVirtualMachineScaleSetRollingUpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ConvertToSinglePlacementGroup(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ConvertToSinglePlacementGroupAsync(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? hibernate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? hibernate = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteInstances(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteInstancesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse> ForceRecoveryServiceFabricPlatformUpdateDomainWalk(int platformUpdateDomain, string zone = null, string placementGroupId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>> ForceRecoveryServiceFabricPlatformUpdateDomainWalkAsync(int platformUpdateDomain, string zone = null, string placementGroupId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> Get(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> GetAsync(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> GetVirtualMachineScaleSetVm(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> GetVirtualMachineScaleSetVmAsync(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmCollection GetVirtualMachineScaleSetVms() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PerformMaintenance(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PerformMaintenanceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOff(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOffAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, bool? skipShutdown = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOn(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOnAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds vmInstanceIds = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reapply(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReapplyAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        Azure.ResourceManager.Compute.VirtualMachineScaleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateInstances(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateInstancesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds vmInstanceIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetRollingUpgradeData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>
    {
        public VirtualMachineScaleSetRollingUpgradeData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Compute.Models.ComputeApiError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradePolicy Policy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo Progress { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus RunningStatus { get { throw null; } }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetRollingUpgradeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetRollingUpgradeResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineScaleSetVmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instanceId, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instanceId, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> Get(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> GetAll(string filter = null, string select = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> GetAllAsync(string filter = null, string select = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> GetAsync(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> GetIfExists(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> GetIfExistsAsync(string instanceId, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>
    {
        public VirtualMachineScaleSetVmData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AvailabilitySetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string InstanceId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView InstanceView { get { throw null; } }
        public bool? LatestModelApplied { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public string ModelDefinitionApplied { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy ProtectionPolicy { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.VirtualMachineExtensionData> Resources { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile StorageProfile { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UserData { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> GetIfExists(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>> GetIfExistsAsync(string vmExtensionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>
    {
        public VirtualMachineScaleSetVmExtensionData() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVmExtensionResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string instanceId, string vmExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVmResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ApproveRollingUpgrade(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ApproveRollingUpgradeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile> AttachDetachDataDisks(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest attachDetachDataDisksRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile>> AttachDetachDataDisksAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest attachDetachDataDisksRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string instanceId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deallocate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeallocateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> Get(Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> GetAsync(Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult> RunCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult>> RunCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.RunCommandInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SimulateEviction(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SimulateEvictionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> GetIfExists(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> GetIfExistsAsync(string runCommandName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineScaleSetVmRunCommandResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineScaleSetVmRunCommandResource() { }
        public virtual Azure.ResourceManager.Compute.VirtualMachineRunCommandData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string instanceId, string runCommandName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.VirtualMachineRunCommandData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.VirtualMachineRunCommandData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.VirtualMachineRunCommandData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate runCommand, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Mocking
{
    public partial class MockableComputeArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeArmClient() { }
        public virtual Azure.ResourceManager.Compute.AvailabilitySetResource GetAvailabilitySetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.CapacityReservationGroupResource GetCapacityReservationGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.CapacityReservationResource GetCapacityReservationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostGroupResource GetDedicatedHostGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostResource GetDedicatedHostResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.DiskImageResource GetDiskImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.ProximityPlacementGroupResource GetProximityPlacementGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.RestorePointGroupResource GetRestorePointGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.RestorePointResource GetRestorePointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.SshPublicKeyResource GetSshPublicKeyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource GetVirtualMachineExtensionImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionResource GetVirtualMachineExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineResource GetVirtualMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineRunCommandResource GetVirtualMachineRunCommandResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionResource GetVirtualMachineScaleSetExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetResource GetVirtualMachineScaleSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeResource GetVirtualMachineScaleSetRollingUpgradeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionResource GetVirtualMachineScaleSetVmExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmResource GetVirtualMachineScaleSetVmResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetVmRunCommandResource GetVirtualMachineScaleSetVmRunCommandResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource> GetAvailabilitySet(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.AvailabilitySetResource>> GetAvailabilitySetAsync(string availabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.AvailabilitySetCollection GetAvailabilitySets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetCapacityReservationGroup(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.CapacityReservationGroupResource>> GetCapacityReservationGroupAsync(string capacityReservationGroupName, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.CapacityReservationGroupCollection GetCapacityReservationGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetDedicatedHostGroup(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DedicatedHostGroupResource>> GetDedicatedHostGroupAsync(string hostGroupName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DedicatedHostGroupCollection GetDedicatedHostGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.DiskImageResource> GetDiskImage(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.DiskImageResource>> GetDiskImageAsync(string imageName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.DiskImageCollection GetDiskImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> GetProximityPlacementGroup(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.ProximityPlacementGroupResource>> GetProximityPlacementGroupAsync(string proximityPlacementGroupName, string includeColocationStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.ProximityPlacementGroupCollection GetProximityPlacementGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource> GetRestorePointGroup(string restorePointGroupName, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.RestorePointGroupResource>> GetRestorePointGroupAsync(string restorePointGroupName, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand? expand = default(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.RestorePointGroupCollection GetRestorePointGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource> GetSshPublicKey(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.SshPublicKeyResource>> GetSshPublicKeyAsync(string sshPublicKeyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.SshPublicKeyCollection GetSshPublicKeys() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachine(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineResource>> GetVirtualMachineAsync(string vmName, Azure.ResourceManager.Compute.Models.InstanceViewType? expand = default(Azure.ResourceManager.Compute.Models.InstanceViewType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineCollection GetVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSet(string virtualMachineScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource>> GetVirtualMachineScaleSetAsync(string virtualMachineScaleSetName, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand? expand = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineScaleSetCollection GetVirtualMachineScaleSets() { throw null; }
    }
    public partial class MockableComputeSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.LogAnalytics> ExportLogAnalyticsRequestRateByInterval(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.LogAnalytics>> ExportLogAnalyticsRequestRateByIntervalAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.LogAnalytics> ExportLogAnalyticsThrottledRequests(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.ThrottledRequestsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Compute.Models.LogAnalytics>> ExportLogAnalyticsThrottledRequestsAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.Compute.Models.ThrottledRequestsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.AvailabilitySetResource> GetAvailabilitySets(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.AvailabilitySetResource> GetAvailabilitySetsAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetCapacityReservationGroups(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand?), Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup? resourceIdsOnly = default(Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.CapacityReservationGroupResource> GetCapacityReservationGroupsAsync(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand? expand = default(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand?), Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup? resourceIdsOnly = default(Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetDedicatedHostGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DedicatedHostGroupResource> GetDedicatedHostGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.DiskImageResource> GetDiskImages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.DiskImageResource> GetDiskImagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetOffersVirtualMachineImagesEdgeZones(Azure.Core.AzureLocation location, string edgeZone, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetOffersVirtualMachineImagesEdgeZonesAsync(Azure.Core.AzureLocation location, string edgeZone, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> GetProximityPlacementGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.ProximityPlacementGroupResource> GetProximityPlacementGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetPublishersVirtualMachineImagesEdgeZones(Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetPublishersVirtualMachineImagesEdgeZonesAsync(Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.RestorePointGroupResource> GetRestorePointGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.RestorePointGroupResource> GetRestorePointGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.SshPublicKeyResource> GetSshPublicKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.SshPublicKeyResource> GetSshPublicKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.ComputeUsage> GetUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ComputeUsage> GetUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource> GetVirtualMachineExtensionImage(Azure.Core.AzureLocation location, string publisherName, string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.VirtualMachineExtensionImageResource>> GetVirtualMachineExtensionImageAsync(Azure.Core.AzureLocation location, string publisherName, string type, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Compute.VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(Azure.Core.AzureLocation location, string publisherName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage> GetVirtualMachineImage(Azure.Core.AzureLocation location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage>> GetVirtualMachineImageAsync(Azure.Core.AzureLocation location, string publisherName, string offer, string skus, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageEdgeZoneSkus(Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageEdgeZoneSkusAsync(Azure.Core.AzureLocation location, string edgeZone, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageOffers(Azure.Core.AzureLocation location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageOffersAsync(Azure.Core.AzureLocation location, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagePublishers(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagePublishersAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImages(Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesAsync(Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesByEdgeZone(Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesByEdgeZoneAsync(Azure.Core.AzureLocation location, string edgeZone, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage> GetVirtualMachineImagesEdgeZone(Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.VirtualMachineImage>> GetVirtualMachineImagesEdgeZoneAsync(Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZoneOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesEdgeZones(Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImagesEdgeZonesAsync(Azure.ResourceManager.Compute.Models.SubscriptionResourceGetVirtualMachineImagesEdgeZonesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageSkus(Azure.Core.AzureLocation location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase> GetVirtualMachineImageSkusAsync(Azure.Core.AzureLocation location, string publisherName, string offer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandDocument> GetVirtualMachineRunCommand(Azure.Core.AzureLocation location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Models.RunCommandDocument>> GetVirtualMachineRunCommandAsync(Azure.Core.AzureLocation location, string commandId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> GetVirtualMachineRunCommands(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase> GetVirtualMachineRunCommandsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachines(string statusOnly = null, string filter = null, Azure.ResourceManager.Compute.Models.ExpandTypesForListVm? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForListVm?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachinesAsync(string statusOnly = null, string filter = null, Azure.ResourceManager.Compute.Models.ExpandTypesForListVm? expand = default(Azure.ResourceManager.Compute.Models.ExpandTypesForListVm?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachinesByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineResource> GetVirtualMachinesByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.VirtualMachineScaleSetResource> GetVirtualMachineScaleSetsByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetVirtualMachineSizes(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachineSize> GetVirtualMachineSizesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Models
{
    public partial class AdditionalCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AdditionalCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AdditionalCapabilities>
    {
        public AdditionalCapabilities() { }
        public bool? HibernationEnabled { get { throw null; } set { } }
        public bool? UltraSsdEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.AdditionalCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AdditionalCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AdditionalCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.AdditionalCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AdditionalCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AdditionalCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AdditionalCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdditionalUnattendContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent>
    {
        public AdditionalUnattendContent() { }
        public Azure.ResourceManager.Compute.Models.ComponentName? ComponentName { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PassName? PassName { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SettingName? SettingName { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.AdditionalUnattendContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.AdditionalUnattendContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArchitectureType : System.IEquatable<Azure.ResourceManager.Compute.Models.ArchitectureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArchitectureType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ArchitectureType Arm64 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ArchitectureType X64 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ArchitectureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ArchitectureType left, Azure.ResourceManager.Compute.Models.ArchitectureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ArchitectureType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ArchitectureType left, Azure.ResourceManager.Compute.Models.ArchitectureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmComputeModelFactory
    {
        public static Azure.ResourceManager.Compute.AvailabilitySetData AvailabilitySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.Models.ComputeSku sku = null, int? platformUpdateDomainCount = default(int?), int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> virtualMachines = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null, Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy scheduledEventsPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.AvailabilitySetPatch AvailabilitySetPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.Models.ComputeSku sku = null, int? platformUpdateDomainCount = default(int?), int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> virtualMachines = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null, Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy scheduledEventsPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.AvailablePatchSummary AvailablePatchSummary(Azure.ResourceManager.Compute.Models.PatchOperationStatus? status = default(Azure.ResourceManager.Compute.Models.PatchOperationStatus?), string assessmentActivityId = null, bool? rebootPending = default(bool?), int? criticalAndSecurityPatchCount = default(int?), int? otherPatchCount = default(int?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.Models.ComputeApiError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView BootDiagnosticsInstanceView(System.Uri consoleScreenshotBlobUri = null, System.Uri serialConsoleLogBlobUri = null, Azure.ResourceManager.Compute.Models.InstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservationData CapacityReservationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.Models.ComputeSku sku = null, System.Collections.Generic.IEnumerable<string> zones = null, string reservationId = null, int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachinesAssociated = null, System.DateTimeOffset? provisioningOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView instanceView = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Compute.CapacityReservationGroupData CapacityReservationGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> capacityReservations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachinesAssociated = null, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView instanceView = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> sharingSubscriptionIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView CapacityReservationGroupInstanceView(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName> capacityReservations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> sharedSubscriptionIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch CapacityReservationGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> capacityReservations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachinesAssociated = null, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView instanceView = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> sharingSubscriptionIds = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView CapacityReservationInstanceView(Azure.ResourceManager.Compute.Models.CapacityReservationUtilization utilizationInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName CapacityReservationInstanceViewWithName(Azure.ResourceManager.Compute.Models.CapacityReservationUtilization utilizationInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationPatch CapacityReservationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.Models.ComputeSku sku = null, string reservationId = null, int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachinesAssociated = null, System.DateTimeOffset? provisioningOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView instanceView = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationUtilization CapacityReservationUtilization(int? currentCapacity = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachinesAllocated = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeApiError ComputeApiError(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ComputeApiErrorBase> details = null, Azure.ResourceManager.Compute.Models.InnerError innererror = null, string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeApiErrorBase ComputeApiErrorBase(string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeSubResourceData ComputeSubResourceData(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeUsage ComputeUsage(Azure.ResourceManager.Compute.Models.ComputeUsageUnit unit = default(Azure.ResourceManager.Compute.Models.ComputeUsageUnit), int currentValue = 0, long limit = (long)0, Azure.ResourceManager.Compute.Models.ComputeUsageName name = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeUsageName ComputeUsageName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DataDiskImage DataDiskImage(int? lun = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DataDisksToAttach DataDisksToAttach(string diskId = null, int? lun = default(int?), Azure.ResourceManager.Compute.Models.CachingType? caching = default(Azure.ResourceManager.Compute.Models.CachingType?), Azure.ResourceManager.Compute.Models.DiskDeleteOptionType? deleteOption = default(Azure.ResourceManager.Compute.Models.DiskDeleteOptionType?), Azure.Core.ResourceIdentifier diskEncryptionSetId = null, bool? writeAcceleratorEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DataDisksToDetach DataDisksToDetach(string diskId = null, Azure.ResourceManager.Compute.Models.DiskDetachOptionType? detachOption = default(Azure.ResourceManager.Compute.Models.DiskDetachOptionType?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm DedicatedHostAllocatableVm(string vmSize = null, double? count = default(double?)) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHostData DedicatedHostData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.Models.ComputeSku sku = null, int? platformFaultDomain = default(int?), bool? autoReplaceOnFailure = default(bool?), string hostId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachines = null, Azure.ResourceManager.Compute.Models.DedicatedHostLicenseType? licenseType = default(Azure.ResourceManager.Compute.Models.DedicatedHostLicenseType?), System.DateTimeOffset? provisioningOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView instanceView = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Compute.DedicatedHostGroupData DedicatedHostGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> dedicatedHosts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName> instanceViewHosts = null, bool? supportAutomaticPlacement = default(bool?), bool? ultraSsdEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch DedicatedHostGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<string> zones = null, int? platformFaultDomainCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> hosts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName> instanceViewHosts = null, bool? supportAutomaticPlacement = default(bool?), bool? ultraSsdEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView DedicatedHostInstanceView(string assetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm> availableCapacityAllocatableVms = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName DedicatedHostInstanceViewWithName(string assetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm> availableCapacityAllocatableVms = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DedicatedHostPatch DedicatedHostPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.Models.ComputeSku sku = null, int? platformFaultDomain = default(int?), bool? autoReplaceOnFailure = default(bool?), string hostId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> virtualMachines = null, Azure.ResourceManager.Compute.Models.DedicatedHostLicenseType? licenseType = default(Azure.ResourceManager.Compute.Models.DedicatedHostLicenseType?), System.DateTimeOffset? provisioningOn = default(System.DateTimeOffset?), string provisioningState = null, Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView instanceView = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Compute.DiskImageData DiskImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.Core.ResourceIdentifier sourceVirtualMachineId = null, Azure.ResourceManager.Compute.Models.ImageStorageProfile storageProfile = null, string provisioningState = null, Azure.ResourceManager.Compute.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Compute.Models.HyperVGeneration?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskImagePatch DiskImagePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.ResourceIdentifier sourceVirtualMachineId = null, Azure.ResourceManager.Compute.Models.ImageStorageProfile storageProfile = null, string provisioningState = null, Azure.ResourceManager.Compute.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Compute.Models.HyperVGeneration?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskInstanceView DiskInstanceView(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings> encryptionSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes DiskRestorePointAttributes(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Compute.Models.RestorePointEncryption encryption = null, Azure.Core.ResourceIdentifier sourceDiskRestorePointId = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView DiskRestorePointInstanceView(string id = null, Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus replicationStatus = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus DiskRestorePointReplicationStatus(Azure.ResourceManager.Compute.Models.InstanceViewStatus status = null, int? completionPercent = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ImageReference ImageReference(Azure.Core.ResourceIdentifier id = null, string publisher = null, string offer = null, string sku = null, string version = null, string exactVersion = null, string sharedGalleryImageUniqueId = null, string communityGalleryImageId = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.InnerError InnerError(string exceptiontype = null, string errordetail = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary LastPatchInstallationSummary(Azure.ResourceManager.Compute.Models.PatchOperationStatus? status = default(Azure.ResourceManager.Compute.Models.PatchOperationStatus?), string installationActivityId = null, bool? maintenanceWindowExceeded = default(bool?), int? notSelectedPatchCount = default(int?), int? excludedPatchCount = default(int?), int? pendingPatchCount = default(int?), int? installedPatchCount = default(int?), int? failedPatchCount = default(int?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.Models.ComputeApiError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.LogAnalytics LogAnalytics(string logAnalyticsOutput = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase LogAnalyticsInputBase(System.Uri blobContainerSasUri = null, System.DateTimeOffset fromTime = default(System.DateTimeOffset), System.DateTimeOffset toTime = default(System.DateTimeOffset), bool? groupByThrottlePolicy = default(bool?), bool? groupByOperationName = default(bool?), bool? groupByResourceName = default(bool?), bool? groupByClientApplicationId = default(bool?), bool? groupByUserAgent = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus MaintenanceRedeployStatus(bool? isCustomerInitiatedMaintenanceAllowed = default(bool?), System.DateTimeOffset? preMaintenanceWindowStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? preMaintenanceWindowEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceWindowStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceWindowEndOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.Models.MaintenanceOperationResultCodeType? lastOperationResultCode = default(Azure.ResourceManager.Compute.Models.MaintenanceOperationResultCodeType?), string lastOperationMessage = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary OrchestrationServiceSummary(Azure.ResourceManager.Compute.Models.OrchestrationServiceName? serviceName = default(Azure.ResourceManager.Compute.Models.OrchestrationServiceName?), Azure.ResourceManager.Compute.Models.OrchestrationServiceState? serviceState = default(Azure.ResourceManager.Compute.Models.OrchestrationServiceState?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PatchInstallationDetail PatchInstallationDetail(string patchId = null, string name = null, string version = null, string kbId = null, System.Collections.Generic.IEnumerable<string> classifications = null, Azure.ResourceManager.Compute.Models.PatchInstallationState? installationState = default(Azure.ResourceManager.Compute.Models.PatchInstallationState?)) { throw null; }
        public static Azure.ResourceManager.Compute.ProximityPlacementGroupData ProximityPlacementGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType? proximityPlacementGroupType = default(Azure.ResourceManager.Compute.Models.ProximityPlacementGroupType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus> virtualMachines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus> virtualMachineScaleSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus> availabilitySets = null, Azure.ResourceManager.Compute.Models.InstanceViewStatus colocationStatus = null, System.Collections.Generic.IEnumerable<string> intentVmSizes = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RecoveryWalkResponse RecoveryWalkResponse(bool? walkPerformed = default(bool?), int? nextPlatformUpdateDomain = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent RequestRateByIntervalContent(System.Uri blobContainerSasUri = null, System.DateTimeOffset fromTime = default(System.DateTimeOffset), System.DateTimeOffset toTime = default(System.DateTimeOffset), bool? groupByThrottlePolicy = default(bool?), bool? groupByOperationName = default(bool?), bool? groupByResourceName = default(bool?), bool? groupByClientApplicationId = default(bool?), bool? groupByUserAgent = default(bool?), Azure.ResourceManager.Compute.Models.IntervalInMins intervalLength = Azure.ResourceManager.Compute.Models.IntervalInMins.ThreeMins) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePointData RestorePointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> excludeDisks = null, Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata sourceMetadata = null, string provisioningState = null, Azure.ResourceManager.Compute.Models.ConsistencyModeType? consistencyMode = default(Azure.ResourceManager.Compute.Models.ConsistencyModeType?), System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier sourceRestorePointId = null, Azure.ResourceManager.Compute.Models.RestorePointInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.Compute.RestorePointGroupData RestorePointGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.Models.RestorePointGroupSource source = null, string provisioningState = null, string restorePointGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.RestorePointData> restorePoints = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointGroupPatch RestorePointGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.Models.RestorePointGroupSource source = null, string provisioningState = null, string restorePointGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.RestorePointData> restorePoints = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointGroupSource RestorePointGroupSource(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointInstanceView RestorePointInstanceView(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView> diskRestorePoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata RestorePointSourceMetadata(Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile hardwareProfile = null, Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile storageProfile = null, Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile osProfile = null, Azure.ResourceManager.Compute.Models.BootDiagnostics bootDiagnostics = null, string licenseType = null, string vmId = null, Azure.ResourceManager.Compute.Models.SecurityProfile securityProfile = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string userData = null, Azure.ResourceManager.Compute.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Compute.Models.HyperVGeneration?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk RestorePointSourceVmDataDisk(int? lun = default(int?), string name = null, Azure.ResourceManager.Compute.Models.CachingType? caching = default(Azure.ResourceManager.Compute.Models.CachingType?), int? diskSizeGB = default(int?), Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk managedDisk = null, Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes diskRestorePoint = null, bool? writeAcceleratorEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk RestorePointSourceVmOSDisk(Azure.ResourceManager.Compute.Models.OperatingSystemType? osType = default(Azure.ResourceManager.Compute.Models.OperatingSystemType?), Azure.ResourceManager.Compute.Models.DiskEncryptionSettings encryptionSettings = null, string name = null, Azure.ResourceManager.Compute.Models.CachingType? caching = default(Azure.ResourceManager.Compute.Models.CachingType?), int? diskSizeGB = default(int?), Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk managedDisk = null, Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes diskRestorePoint = null, bool? writeAcceleratorEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile RestorePointSourceVmStorageProfile(Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk osDisk = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk> dataDiskList = null, Azure.ResourceManager.Compute.Models.DiskControllerType? diskControllerType = default(Azure.ResourceManager.Compute.Models.DiskControllerType?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult RetrieveBootDiagnosticsDataResult(System.Uri consoleScreenshotBlobUri = null, System.Uri serialConsoleLogBlobUri = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RollbackStatusInfo RollbackStatusInfo(int? successfullyRolledbackInstanceCount = default(int?), int? failedRolledbackInstanceCount = default(int?), Azure.ResourceManager.Compute.Models.ComputeApiError rollbackError = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo RollingUpgradeProgressInfo(int? successfulInstanceCount = default(int?), int? failedInstanceCount = default(int?), int? inProgressInstanceCount = default(int?), int? pendingInstanceCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus RollingUpgradeRunningStatus(Azure.ResourceManager.Compute.Models.RollingUpgradeStatusCode? code = default(Azure.ResourceManager.Compute.Models.RollingUpgradeStatusCode?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.Models.RollingUpgradeActionType? lastAction = default(Azure.ResourceManager.Compute.Models.RollingUpgradeActionType?), System.DateTimeOffset? lastActionOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RunCommandDocument RunCommandDocument(string schema = null, string id = null, Azure.ResourceManager.Compute.Models.SupportedOperatingSystemType osType = Azure.ResourceManager.Compute.Models.SupportedOperatingSystemType.Windows, string label = null, string description = null, System.Collections.Generic.IEnumerable<string> script = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition> parameters = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RunCommandDocumentBase RunCommandDocumentBase(string schema = null, string id = null, Azure.ResourceManager.Compute.Models.SupportedOperatingSystemType osType = Azure.ResourceManager.Compute.Models.SupportedOperatingSystemType.Windows, string label = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RunCommandInput RunCommandInput(string commandId = null, System.Collections.Generic.IEnumerable<string> script = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> parameters = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition RunCommandParameterDefinition(string name = null, string runCommandParameterDefinitionType = null, string defaultValue = null, bool? required = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.SshPublicKeyData SshPublicKeyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string publicKey = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult SshPublicKeyGenerateKeyPairResult(string privateKey = null, string publicKey = null, Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ThrottledRequestsContent ThrottledRequestsContent(System.Uri blobContainerSasUri = null, System.DateTimeOffset fromTime = default(System.DateTimeOffset), System.DateTimeOffset toTime = default(System.DateTimeOffset), bool? groupByThrottlePolicy = default(bool?), bool? groupByOperationName = default(bool?), bool? groupByResourceName = default(bool?), bool? groupByClientApplicationId = default(bool?), bool? groupByUserAgent = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo UpgradeOperationHistoricalStatusInfo(Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties properties = null, string upgradeOperationHistoricalStatusInfoType = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties UpgradeOperationHistoricalStatusInfoProperties(Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus runningStatus = null, Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo progress = null, Azure.ResourceManager.Compute.Models.ComputeApiError error = null, Azure.ResourceManager.Compute.Models.UpgradeOperationInvoker? startedBy = default(Azure.ResourceManager.Compute.Models.UpgradeOperationInvoker?), Azure.ResourceManager.Compute.Models.ImageReference targetImageReference = null, Azure.ResourceManager.Compute.Models.RollbackStatusInfo rollbackInfo = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus UpgradeOperationHistoryStatus(Azure.ResourceManager.Compute.Models.UpgradeState? code = default(Azure.ResourceManager.Compute.Models.UpgradeState?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView VirtualMachineAgentInstanceView(string vmAgentVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView> extensionHandlers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult VirtualMachineAssessPatchesResult(Azure.ResourceManager.Compute.Models.PatchOperationStatus? status = default(Azure.ResourceManager.Compute.Models.PatchOperationStatus?), string assessmentActivityId = null, bool? rebootPending = default(bool?), int? criticalAndSecurityPatchCount = default(int?), int? otherPatchCount = default(int?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties> availablePatches = null, Azure.ResourceManager.Compute.Models.ComputeApiError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult VirtualMachineCaptureResult(Azure.Core.ResourceIdentifier id = null, string schema = null, string contentVersion = null, System.BinaryData parameters = null, System.Collections.Generic.IEnumerable<System.BinaryData> resources = null) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineData VirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.Models.ComputePlan plan = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionData> resources = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string managedBy = null, string etag = null, Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile hardwareProfile = null, Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy scheduledEventsPolicy = null, Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile storageProfile = null, Azure.ResourceManager.Compute.Models.AdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile osProfile = null, Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile networkProfile = null, Azure.ResourceManager.Compute.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.Compute.Models.BootDiagnostics bootDiagnostics = null, Azure.Core.ResourceIdentifier availabilitySetId = null, Azure.Core.ResourceIdentifier virtualMachineScaleSetId = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType? priority = default(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType?), Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType? evictionPolicy = default(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType?), double? billingMaxPrice = default(double?), Azure.Core.ResourceIdentifier hostId = null, Azure.Core.ResourceIdentifier hostGroupId = null, string provisioningState = null, Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView instanceView = null, string licenseType = null, string vmId = null, string extensionsTimeBudget = null, int? platformFaultDomain = default(int?), Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication> galleryApplications = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk VirtualMachineDataDisk(int lun = 0, string name = null, System.Uri vhdUri = null, System.Uri imageUri = null, Azure.ResourceManager.Compute.Models.CachingType? caching = default(Azure.ResourceManager.Compute.Models.CachingType?), bool? writeAcceleratorEnabled = default(bool?), Azure.ResourceManager.Compute.Models.DiskCreateOptionType createOption = default(Azure.ResourceManager.Compute.Models.DiskCreateOptionType), int? diskSizeGB = default(int?), Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk managedDisk = null, Azure.Core.ResourceIdentifier sourceResourceId = null, bool? toBeDetached = default(bool?), long? diskIopsReadWrite = default(long?), long? diskMBpsReadWrite = default(long?), Azure.ResourceManager.Compute.Models.DiskDetachOptionType? detachOption = default(Azure.ResourceManager.Compute.Models.DiskDetachOptionType?), Azure.ResourceManager.Compute.Models.DiskDeleteOptionType? deleteOption = default(Azure.ResourceManager.Compute.Models.DiskDeleteOptionType?)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineExtensionData VirtualMachineExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView instanceView = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.Compute.Models.KeyVaultSecretReference keyVaultProtectedSettings = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView VirtualMachineExtensionHandlerInstanceView(string virtualMachineExtensionHandlerInstanceViewType = null, string typeHandlerVersion = null, Azure.ResourceManager.Compute.Models.InstanceViewStatus status = null) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineExtensionImageData VirtualMachineExtensionImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string operatingSystem = null, string computeRole = null, string handlerSchema = null, bool? virtualMachineScaleSetEnabled = default(bool?), bool? supportsMultipleExtensions = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent VirtualMachineInstallPatchesContent(System.TimeSpan? maximumDuration = default(System.TimeSpan?), Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting rebootSetting = default(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting), Azure.ResourceManager.Compute.Models.WindowsParameters windowsParameters = null, Azure.ResourceManager.Compute.Models.LinuxParameters linuxParameters = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult VirtualMachineInstallPatchesResult(Azure.ResourceManager.Compute.Models.PatchOperationStatus? status = default(Azure.ResourceManager.Compute.Models.PatchOperationStatus?), string installationActivityId = null, Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus? rebootStatus = default(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootStatus?), bool? maintenanceWindowExceeded = default(bool?), int? excludedPatchCount = default(int?), int? notSelectedPatchCount = default(int?), int? pendingPatchCount = default(int?), int? installedPatchCount = default(int?), int? failedPatchCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.PatchInstallationDetail> patches = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.Models.ComputeApiError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView VirtualMachineInstanceView(int? platformUpdateDomain = default(int?), int? platformFaultDomain = default(int?), string computerName = null, string osName = null, string osVersion = null, Azure.ResourceManager.Compute.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Compute.Models.HyperVGeneration?), string rdpThumbPrint = null, Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView vmAgent = null, Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus maintenanceRedeployStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.DiskInstanceView> disks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView> extensions = null, Azure.ResourceManager.Compute.Models.InstanceViewStatus vmHealthStatus = null, Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView bootDiagnostics = null, string assignedHost = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null, Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus patchStatus = null, bool? isVmInStandbyPool = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePatch VirtualMachinePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.Models.ComputePlan plan = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile hardwareProfile = null, Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy scheduledEventsPolicy = null, Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile storageProfile = null, Azure.ResourceManager.Compute.Models.AdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile osProfile = null, Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile networkProfile = null, Azure.ResourceManager.Compute.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.Compute.Models.BootDiagnostics bootDiagnostics = null, Azure.Core.ResourceIdentifier availabilitySetId = null, Azure.Core.ResourceIdentifier virtualMachineScaleSetId = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType? priority = default(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType?), Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType? evictionPolicy = default(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType?), double? billingMaxPrice = default(double?), Azure.Core.ResourceIdentifier hostId = null, Azure.Core.ResourceIdentifier hostGroupId = null, string provisioningState = null, Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView instanceView = null, string licenseType = null, string vmId = null, string extensionsTimeBudget = null, int? platformFaultDomain = default(int?), Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication> galleryApplications = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus VirtualMachinePatchStatus(Azure.ResourceManager.Compute.Models.AvailablePatchSummary availablePatchSummary = null, Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary lastPatchInstallationSummary = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> configurationStatuses = null) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineRunCommandData VirtualMachineRunCommandData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource source = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> protectedParameters = null, bool? asyncExecution = default(bool?), string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = default(int?), System.Uri outputBlobUri = null, System.Uri errorBlobUri = null, Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity outputBlobManagedIdentity = null, Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity errorBlobManagedIdentity = null, string provisioningState = null, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView instanceView = null, bool? treatFailureAsDeploymentFailure = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView VirtualMachineRunCommandInstanceView(Azure.ResourceManager.Compute.Models.ExecutionState? executionState = default(Azure.ResourceManager.Compute.Models.ExecutionState?), string executionMessage = null, int? exitCode = default(int?), string output = null, string error = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult VirtualMachineRunCommandResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> value = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate VirtualMachineRunCommandUpdate(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource source = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> protectedParameters = null, bool? asyncExecution = default(bool?), string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = default(int?), System.Uri outputBlobUri = null, System.Uri errorBlobUri = null, Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity outputBlobManagedIdentity = null, Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity errorBlobManagedIdentity = null, string provisioningState = null, Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView instanceView = null, bool? treatFailureAsDeploymentFailure = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetData VirtualMachineScaleSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.Models.ComputeSku sku = null, Azure.ResourceManager.Compute.Models.ComputePlan plan = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string etag = null, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy upgradePolicy = null, Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy scheduledEventsPolicy = null, Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy automaticRepairsPolicy = null, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile virtualMachineProfile = null, string provisioningState = null, bool? overprovision = default(bool?), bool? doNotRunExtensionsOnOverprovisionedVms = default(bool?), string uniqueId = null, bool? singlePlacementGroup = default(bool?), bool? zoneBalance = default(bool?), int? platformFaultDomainCount = default(int?), Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, Azure.Core.ResourceIdentifier hostGroupId = null, Azure.ResourceManager.Compute.Models.AdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.Compute.Models.ScaleInPolicy scaleInPolicy = null, Azure.ResourceManager.Compute.Models.OrchestrationMode? orchestrationMode = default(Azure.ResourceManager.Compute.Models.OrchestrationMode?), Azure.ResourceManager.Compute.Models.SpotRestorePolicy spotRestorePolicy = null, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy priorityMixPolicy = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), bool? isMaximumCapacityConstrained = default(bool?), Azure.ResourceManager.Compute.Models.ResiliencyPolicy resiliencyPolicy = null, Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode? zonalPlatformFaultDomainAlignMode = default(Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode?), Azure.ResourceManager.Compute.Models.ComputeSkuProfile skuProfile = null) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData VirtualMachineScaleSetExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.Compute.Models.KeyVaultSecretReference keyVaultProtectedSettings = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch VirtualMachineScaleSetExtensionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.Compute.Models.KeyVaultSecretReference keyVaultProtectedSettings = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView VirtualMachineScaleSetInstanceView(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount> virtualMachineStatusesSummary = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary> extensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary> orchestrationServices = null) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetRollingUpgradeData VirtualMachineScaleSetRollingUpgradeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Compute.Models.RollingUpgradePolicy policy = null, Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus runningStatus = null, Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo progress = null, Azure.ResourceManager.Compute.Models.ComputeApiError error = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku VirtualMachineScaleSetSku(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), Azure.ResourceManager.Compute.Models.ComputeSku sku = null, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity VirtualMachineScaleSetSkuCapacity(long? minimum = default(long?), long? maximum = default(long?), long? defaultCapacity = default(long?), Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuScaleType? scaleType = default(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuScaleType?)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetVmData VirtualMachineScaleSetVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string instanceId = null, Azure.ResourceManager.Compute.Models.ComputeSku sku = null, Azure.ResourceManager.Compute.Models.ComputePlan plan = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.VirtualMachineExtensionData> resources = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string etag = null, bool? latestModelApplied = default(bool?), string vmId = null, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView instanceView = null, Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile hardwareProfile = null, Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile storageProfile = null, Azure.ResourceManager.Compute.Models.AdditionalCapabilities additionalCapabilities = null, Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile osProfile = null, Azure.ResourceManager.Compute.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile networkProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations = null, Azure.ResourceManager.Compute.Models.BootDiagnostics bootDiagnostics = null, Azure.Core.ResourceIdentifier availabilitySetId = null, string provisioningState = null, string licenseType = null, string modelDefinitionApplied = null, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy protectionPolicy = null, string userData = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Compute.VirtualMachineScaleSetVmExtensionData VirtualMachineScaleSetVmExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, string provisioningState = null, Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView instanceView = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.Compute.Models.KeyVaultSecretReference keyVaultProtectedSettings = null, System.Collections.Generic.IEnumerable<string> provisionAfterExtensions = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch VirtualMachineScaleSetVmExtensionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = default(bool?), bool? enableAutomaticUpgrade = default(bool?), System.BinaryData settings = null, System.BinaryData protectedSettings = null, bool? suppressFailures = default(bool?), Azure.ResourceManager.Compute.Models.KeyVaultSecretReference keyVaultProtectedSettings = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary VirtualMachineScaleSetVmExtensionsSummary(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount> statusesSummary = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView VirtualMachineScaleSetVmInstanceView(int? platformUpdateDomain = default(int?), int? platformFaultDomain = default(int?), string rdpThumbPrint = null, Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView vmAgent = null, Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus maintenanceRedeployStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.DiskInstanceView> disks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView> extensions = null, Azure.ResourceManager.Compute.Models.InstanceViewStatus vmHealthStatus = null, Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView bootDiagnostics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.InstanceViewStatus> statuses = null, Azure.Core.ResourceIdentifier assignedHost = null, string placementGroupId = null, string computerName = null, string osName = null, string osVersion = null, Azure.ResourceManager.Compute.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Compute.Models.HyperVGeneration?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile VirtualMachineScaleSetVmProfile(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile osProfile = null, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile storageProfile = null, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile networkProfile = null, Azure.ResourceManager.Compute.Models.SecurityProfile securityProfile = null, Azure.ResourceManager.Compute.Models.BootDiagnostics bootDiagnostics = null, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile extensionProfile = null, string licenseType = null, Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType? priority = default(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType?), Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType? evictionPolicy = default(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType?), double? billingMaxPrice = default(double?), Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile scheduledEventsProfile = null, string userData = null, Azure.Core.ResourceIdentifier capacityReservationGroupId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication> galleryApplications = null, Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties hardwareVmSizeProperties = null, Azure.Core.ResourceIdentifier serviceArtifactReferenceId = null, Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference securityPostureReference = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSize VirtualMachineSize(string name = null, int? numberOfCores = default(int?), int? osDiskSizeInMB = default(int?), int? resourceDiskSizeInMB = default(int?), int? memoryInMB = default(int?), int? maxDataDiskCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties VirtualMachineSoftwarePatchProperties(string patchId = null, string name = null, string version = null, string kbId = null, System.Collections.Generic.IEnumerable<string> classifications = null, Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior? rebootBehavior = default(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootBehavior?), string activityId = null, System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.Models.PatchAssessmentState? assessmentState = default(Azure.ResourceManager.Compute.Models.PatchAssessmentState?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount VirtualMachineStatusCodeCount(string code = null, int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.WindowsConfiguration WindowsConfiguration(bool? provisionVmAgent = default(bool?), bool? isAutomaticUpdatesEnabled = default(bool?), string timeZone = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent> additionalUnattendContent = null, Azure.ResourceManager.Compute.Models.PatchSettings patchSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.WinRMListener> winRMListeners = null, bool? isVmAgentPlatformUpdatesEnabled = default(bool?)) { throw null; }
    }
    public partial class AttachDetachDataDisksRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest>
    {
        public AttachDetachDataDisksRequest() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDisksToAttach> DataDisksToAttach { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDisksToDetach> DataDisksToDetach { get { throw null; } }
        Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AttachDetachDataDisksRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutomaticOSUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy>
    {
        public AutomaticOSUpgradePolicy() { }
        public bool? DisableAutomaticRollback { get { throw null; } set { } }
        public bool? EnableAutomaticOSUpgrade { get { throw null; } set { } }
        public bool? OSRollingUpgradeDeferral { get { throw null; } set { } }
        public bool? UseRollingUpgradePolicy { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutomaticRepairsPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy>
    {
        public AutomaticRepairsPolicy() { }
        public bool? Enabled { get { throw null; } set { } }
        public string GracePeriod { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RepairAction? RepairAction { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilitySetPatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AvailabilitySetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AvailabilitySetPatch>
    {
        public AvailabilitySetPatch() { }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public int? PlatformUpdateDomainCount { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.Compute.Models.AvailabilitySetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AvailabilitySetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AvailabilitySetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.AvailabilitySetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AvailabilitySetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AvailabilitySetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AvailabilitySetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailablePatchSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AvailablePatchSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AvailablePatchSummary>
    {
        internal AvailablePatchSummary() { }
        public string AssessmentActivityId { get { throw null; } }
        public int? CriticalAndSecurityPatchCount { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeApiError Error { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public int? OtherPatchCount { get { throw null; } }
        public bool? RebootPending { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchOperationStatus? Status { get { throw null; } }
        Azure.ResourceManager.Compute.Models.AvailablePatchSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AvailablePatchSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.AvailablePatchSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.AvailablePatchSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AvailablePatchSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AvailablePatchSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.AvailablePatchSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BootDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.BootDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.BootDiagnostics>
    {
        public BootDiagnostics() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.BootDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.BootDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.BootDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.BootDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.BootDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.BootDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.BootDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BootDiagnosticsInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView>
    {
        internal BootDiagnosticsInstanceView() { }
        public System.Uri ConsoleScreenshotBlobUri { get { throw null; } }
        public System.Uri SerialConsoleLogBlobUri { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus Status { get { throw null; } }
        Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityReservationGroupGetExpand : System.IEquatable<Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityReservationGroupGetExpand(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand VirtualMachineScaleSetVmsRef { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand VirtualMachinesRef { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand left, Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand left, Azure.ResourceManager.Compute.Models.CapacityReservationGroupGetExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityReservationGroupInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView>
    {
        internal CapacityReservationGroupInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName> CapacityReservations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> SharedSubscriptionIds { get { throw null; } }
        Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityReservationGroupInstanceViewType : System.IEquatable<Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityReservationGroupInstanceViewType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType left, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType left, Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityReservationGroupPatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch>
    {
        public CapacityReservationGroupPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> CapacityReservations { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CapacityReservationGroupInstanceView InstanceView { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> SharingSubscriptionIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityReservationInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView>
    {
        internal CapacityReservationInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.CapacityReservationUtilization UtilizationInfo { get { throw null; } }
        Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityReservationInstanceViewType : System.IEquatable<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityReservationInstanceViewType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType left, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType left, Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityReservationInstanceViewWithName : Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName>
    {
        internal CapacityReservationInstanceViewWithName() { }
        public string Name { get { throw null; } }
        Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationInstanceViewWithName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityReservationPatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationPatch>
    {
        public CapacityReservationPatch() { }
        public Azure.ResourceManager.Compute.Models.CapacityReservationInstanceView InstanceView { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ReservationId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAssociated { get { throw null; } }
        Azure.ResourceManager.Compute.Models.CapacityReservationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.CapacityReservationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityReservationUtilization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationUtilization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationUtilization>
    {
        internal CapacityReservationUtilization() { }
        public int? CurrentCapacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachinesAllocated { get { throw null; } }
        Azure.ResourceManager.Compute.Models.CapacityReservationUtilization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationUtilization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.CapacityReservationUtilization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.CapacityReservationUtilization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationUtilization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationUtilization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.CapacityReservationUtilization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentName : System.IEquatable<Azure.ResourceManager.Compute.Models.ComponentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentName(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComponentName MicrosoftWindowsShellSetup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ComponentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ComponentName left, Azure.ResourceManager.Compute.Models.ComponentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ComponentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ComponentName left, Azure.ResourceManager.Compute.Models.ComponentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeAllocationStrategy : System.IEquatable<Azure.ResourceManager.Compute.Models.ComputeAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeAllocationStrategy CapacityOptimized { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputeAllocationStrategy LowestPrice { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ComputeAllocationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ComputeAllocationStrategy left, Azure.ResourceManager.Compute.Models.ComputeAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ComputeAllocationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ComputeAllocationStrategy left, Azure.ResourceManager.Compute.Models.ComputeAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeApiError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeApiError>
    {
        internal ComputeApiError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeApiErrorBase> Details { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.ResourceManager.Compute.Models.ComputeApiError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeApiError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeApiErrorBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeApiErrorBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeApiErrorBase>
    {
        internal ComputeApiErrorBase() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.ResourceManager.Compute.Models.ComputeApiErrorBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeApiErrorBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeApiErrorBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeApiErrorBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeApiErrorBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeApiErrorBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeApiErrorBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeDeleteOption : System.IEquatable<Azure.ResourceManager.Compute.Models.ComputeDeleteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeDeleteOption(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeDeleteOption Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputeDeleteOption Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ComputeDeleteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ComputeDeleteOption left, Azure.ResourceManager.Compute.Models.ComputeDeleteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ComputeDeleteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ComputeDeleteOption left, Azure.ResourceManager.Compute.Models.ComputeDeleteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeNetworkInterfaceAuxiliaryMode : System.IEquatable<Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeNetworkInterfaceAuxiliaryMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode AcceleratedConnections { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode Floating { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode left, Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeNetworkInterfaceAuxiliarySku : System.IEquatable<Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeNetworkInterfaceAuxiliarySku(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku A1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku A2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku A4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku A8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku left, Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku left, Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputePlan>
    {
        public ComputePlan() { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ComputePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputePublicIPAddressSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku>
    {
        public ComputePublicIPAddressSku() { }
        public Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputePublicIPAddressSkuName : System.IEquatable<Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputePublicIPAddressSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuName left, Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuName left, Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputePublicIPAddressSkuTier : System.IEquatable<Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputePublicIPAddressSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuTier Global { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuTier Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuTier left, Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuTier left, Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourcePatch>
    {
        public ComputeResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Compute.Models.ComputeResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeScheduledEventsProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile>
    {
        public ComputeScheduledEventsProfile() { }
        public Azure.ResourceManager.Compute.Models.OSImageNotificationProfile OSImageNotificationProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.TerminateNotificationProfile TerminateNotificationProfile { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSecurityPostureReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference>
    {
        public ComputeSecurityPostureReference(Azure.Core.ResourceIdentifier id) { }
        public System.Collections.Generic.IList<string> ExcludeExtensionNames { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public bool? IsOverridable { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSku>
    {
        public ComputeSku() { }
        public long? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ComputeSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSkuProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfile>
    {
        public ComputeSkuProfile() { }
        public Azure.ResourceManager.Compute.Models.ComputeAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.ComputeSkuProfileVmSize> VmSizes { get { throw null; } }
        Azure.ResourceManager.Compute.Models.ComputeSkuProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeSkuProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSkuProfileVmSize : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfileVmSize>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfileVmSize>
    {
        public ComputeSkuProfileVmSize() { }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ComputeSkuProfileVmSize System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfileVmSize>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfileVmSize>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeSkuProfileVmSize System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfileVmSize>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfileVmSize>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSkuProfileVmSize>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ComputeStatusLevelType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }
    public partial class ComputeSubResourceData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceData>
    {
        public ComputeSubResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        Azure.ResourceManager.Compute.Models.ComputeSubResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeSubResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSubResourceDataWithColocationStatus : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus>
    {
        public ComputeSubResourceDataWithColocationStatus() { }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus ColocationStatus { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeSubResourceDataWithColocationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeUsage>
    {
        internal ComputeUsage() { }
        public int CurrentValue { get { throw null; } }
        public long Limit { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeUsageName Name { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeUsageUnit Unit { get { throw null; } }
        Azure.ResourceManager.Compute.Models.ComputeUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeUsageName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeUsageName>
    {
        internal ComputeUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.Compute.Models.ComputeUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeUsageUnit : System.IEquatable<Azure.ResourceManager.Compute.Models.ComputeUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ComputeUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ComputeUsageUnit left, Azure.ResourceManager.Compute.Models.ComputeUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ComputeUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ComputeUsageUnit left, Azure.ResourceManager.Compute.Models.ComputeUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeWriteableSubResourceData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData>
    {
        public ComputeWriteableSubResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsistencyModeType : System.IEquatable<Azure.ResourceManager.Compute.Models.ConsistencyModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsistencyModeType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ConsistencyModeType ApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ConsistencyModeType CrashConsistent { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ConsistencyModeType FileSystemConsistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ConsistencyModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ConsistencyModeType left, Azure.ResourceManager.Compute.Models.ConsistencyModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ConsistencyModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ConsistencyModeType left, Azure.ResourceManager.Compute.Models.ConsistencyModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DataDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDiskImage>
    {
        public DataDiskImage() { }
        public int? Lun { get { throw null; } }
        Azure.ResourceManager.Compute.Models.DataDiskImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DataDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DataDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DataDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDisksToAttach : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DataDisksToAttach>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDisksToAttach>
    {
        public DataDisksToAttach(string diskId) { }
        public Azure.ResourceManager.Compute.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public string DiskId { get { throw null; } }
        public int? Lun { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.DataDisksToAttach System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DataDisksToAttach>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DataDisksToAttach>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DataDisksToAttach System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDisksToAttach>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDisksToAttach>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDisksToAttach>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDisksToDetach : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DataDisksToDetach>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDisksToDetach>
    {
        public DataDisksToDetach(string diskId) { }
        public Azure.ResourceManager.Compute.Models.DiskDetachOptionType? DetachOption { get { throw null; } set { } }
        public string DiskId { get { throw null; } }
        Azure.ResourceManager.Compute.Models.DataDisksToDetach System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DataDisksToDetach>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DataDisksToDetach>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DataDisksToDetach System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDisksToDetach>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDisksToDetach>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DataDisksToDetach>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostAllocatableVm : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm>
    {
        internal DedicatedHostAllocatableVm() { }
        public double? Count { get { throw null; } }
        public string VmSize { get { throw null; } }
        Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostGroupPatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch>
    {
        public DedicatedHostGroupPatch() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Hosts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName> InstanceViewHosts { get { throw null; } }
        public int? PlatformFaultDomainCount { get { throw null; } set { } }
        public bool? SupportAutomaticPlacement { get { throw null; } set { } }
        public bool? UltraSsdEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView>
    {
        internal DedicatedHostInstanceView() { }
        public string AssetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DedicatedHostAllocatableVm> AvailableCapacityAllocatableVms { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHostInstanceViewWithName : Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName>
    {
        internal DedicatedHostInstanceViewWithName() { }
        public string Name { get { throw null; } }
        Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostInstanceViewWithName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DedicatedHostLicenseType
    {
        None = 0,
        WindowsServerHybrid = 1,
        WindowsServerPerpetual = 2,
    }
    public partial class DedicatedHostPatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostPatch>
    {
        public DedicatedHostPatch() { }
        public bool? AutoReplaceOnFailure { get { throw null; } set { } }
        public string HostId { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DedicatedHostLicenseType? LicenseType { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public System.DateTimeOffset? ProvisioningOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> VirtualMachines { get { throw null; } }
        Azure.ResourceManager.Compute.Models.DedicatedHostPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DedicatedHostPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DedicatedHostPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DedicatedHostPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskOption : System.IEquatable<Azure.ResourceManager.Compute.Models.DiffDiskOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskOption(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiffDiskOption Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiffDiskOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiffDiskOption left, Azure.ResourceManager.Compute.Models.DiffDiskOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiffDiskOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiffDiskOption left, Azure.ResourceManager.Compute.Models.DiffDiskOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.ResourceManager.Compute.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiffDiskPlacement NvmeDisk { get { throw null; } }
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
    public partial class DiffDiskSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiffDiskSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiffDiskSettings>
    {
        public DiffDiskSettings() { }
        public Azure.ResourceManager.Compute.Models.DiffDiskOption? Option { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiffDiskPlacement? Placement { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.DiffDiskSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiffDiskSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiffDiskSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DiffDiskSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiffDiskSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiffDiskSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiffDiskSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskControllerType : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskControllerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskControllerType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskControllerType NVMe { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskControllerType Scsi { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskControllerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskControllerType left, Azure.ResourceManager.Compute.Models.DiskControllerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskControllerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskControllerType left, Azure.ResourceManager.Compute.Models.DiskControllerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOptionType : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskCreateOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOptionType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionType Attach { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionType Copy { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionType Empty { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionType FromImage { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskCreateOptionType Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskCreateOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskCreateOptionType left, Azure.ResourceManager.Compute.Models.DiskCreateOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskCreateOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskCreateOptionType left, Azure.ResourceManager.Compute.Models.DiskCreateOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDeleteOptionType : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskDeleteOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDeleteOptionType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskDeleteOptionType Delete { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DiskDeleteOptionType Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskDeleteOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskDeleteOptionType left, Azure.ResourceManager.Compute.Models.DiskDeleteOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskDeleteOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskDeleteOptionType left, Azure.ResourceManager.Compute.Models.DiskDeleteOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskDetachOptionType : System.IEquatable<Azure.ResourceManager.Compute.Models.DiskDetachOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskDetachOptionType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DiskDetachOptionType ForceDetach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DiskDetachOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DiskDetachOptionType left, Azure.ResourceManager.Compute.Models.DiskDetachOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DiskDetachOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DiskDetachOptionType left, Azure.ResourceManager.Compute.Models.DiskDetachOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskEncryptionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings>
    {
        public DiskEncryptionSettings() { }
        public Azure.ResourceManager.Compute.Models.KeyVaultSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultKeyReference KeyEncryptionKey { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.DiskEncryptionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DiskEncryptionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImagePatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskImagePatch>
    {
        public DiskImagePatch() { }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceVirtualMachineId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageStorageProfile StorageProfile { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.DiskImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DiskImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskInstanceView>
    {
        internal DiskInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DiskEncryptionSettings> EncryptionSettings { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        Azure.ResourceManager.Compute.Models.DiskInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DiskInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskRestorePointAttributes : Azure.ResourceManager.Compute.Models.ComputeSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes>
    {
        public DiskRestorePointAttributes() { }
        public Azure.ResourceManager.Compute.Models.RestorePointEncryption Encryption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceDiskRestorePointId { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskRestorePointInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView>
    {
        internal DiskRestorePointInstanceView() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus ReplicationStatus { get { throw null; } }
        Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskRestorePointReplicationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus>
    {
        internal DiskRestorePointReplicationStatus() { }
        public int? CompletionPercent { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus Status { get { throw null; } }
        Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.DiskRestorePointReplicationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainNameLabelScopeType : System.IEquatable<Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainNameLabelScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType NoReuse { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType left, Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType left, Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType right) { throw null; }
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
    public readonly partial struct ExpandTypesForListVm : System.IEquatable<Azure.ResourceManager.Compute.Models.ExpandTypesForListVm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpandTypesForListVm(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ExpandTypesForListVm InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ExpandTypesForListVm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ExpandTypesForListVm left, Azure.ResourceManager.Compute.Models.ExpandTypesForListVm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ExpandTypesForListVm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ExpandTypesForListVm left, Azure.ResourceManager.Compute.Models.ExpandTypesForListVm right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GetVirtualMachineExpandType : System.IEquatable<Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GetVirtualMachineExpandType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType left, Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType left, Azure.ResourceManager.Compute.Models.GetVirtualMachineExpandType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ImageAlternativeOption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageAlternativeOption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageAlternativeOption>
    {
        public ImageAlternativeOption() { }
        public Azure.ResourceManager.Compute.Models.ImageAlternativeType? AlternativeType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ImageAlternativeOption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageAlternativeOption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageAlternativeOption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ImageAlternativeOption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageAlternativeOption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageAlternativeOption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageAlternativeOption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageAlternativeType : System.IEquatable<Azure.ResourceManager.Compute.Models.ImageAlternativeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageAlternativeType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ImageAlternativeType None { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ImageAlternativeType Offer { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ImageAlternativeType Plan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ImageAlternativeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ImageAlternativeType left, Azure.ResourceManager.Compute.Models.ImageAlternativeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ImageAlternativeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ImageAlternativeType left, Azure.ResourceManager.Compute.Models.ImageAlternativeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageDataDisk : Azure.ResourceManager.Compute.Models.ImageDisk, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDataDisk>
    {
        public ImageDataDisk(int lun) { }
        public int Lun { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ImageDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ImageDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDeprecationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageDeprecationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDeprecationStatus>
    {
        public ImageDeprecationStatus() { }
        public Azure.ResourceManager.Compute.Models.ImageAlternativeOption AlternativeOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageState? ImageState { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduledDeprecationOn { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ImageDeprecationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageDeprecationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageDeprecationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ImageDeprecationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDeprecationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDeprecationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDeprecationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDisk>
    {
        public ImageDisk() { }
        public System.Uri BlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedDiskId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SnapshotId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ImageDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ImageDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageOSDisk : Azure.ResourceManager.Compute.Models.ImageDisk, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageOSDisk>
    {
        public ImageOSDisk(Azure.ResourceManager.Compute.Models.SupportedOperatingSystemType osType, Azure.ResourceManager.Compute.Models.OperatingSystemStateType osState) { }
        public Azure.ResourceManager.Compute.Models.OperatingSystemStateType OSState { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SupportedOperatingSystemType OSType { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ImageOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ImageOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageReference : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageReference>
    {
        public ImageReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string SharedGalleryImageUniqueId { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageState : System.IEquatable<Azure.ResourceManager.Compute.Models.ImageState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageState(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ImageState Active { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ImageState Deprecated { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ImageState ScheduledForDeprecation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ImageState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ImageState left, Azure.ResourceManager.Compute.Models.ImageState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ImageState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ImageState left, Azure.ResourceManager.Compute.Models.ImageState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageStorageProfile>
    {
        public ImageStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.ImageDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImageOSDisk OSDisk { get { throw null; } set { } }
        public bool? ZoneResilient { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ImageStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ImageStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ImageStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ImageStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InnerError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.InnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.InnerError>
    {
        internal InnerError() { }
        public string Errordetail { get { throw null; } }
        public string Exceptiontype { get { throw null; } }
        Azure.ResourceManager.Compute.Models.InnerError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.InnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.InnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.InnerError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.InnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.InnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.InnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.InstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.InstanceViewStatus>
    {
        public InstanceViewStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeStatusLevelType? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.InstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.InstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.InstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.InstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.InstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.InstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.InstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class KeyVaultKeyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.KeyVaultKeyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.KeyVaultKeyReference>
    {
        public KeyVaultKeyReference(System.Uri keyUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.KeyVaultKeyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.KeyVaultKeyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.KeyVaultKeyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.KeyVaultKeyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.KeyVaultKeyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.KeyVaultKeyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.KeyVaultKeyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.KeyVaultSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.KeyVaultSecretReference>
    {
        public KeyVaultSecretReference(System.Uri secretUri, Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault) { }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.KeyVaultSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.KeyVaultSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.KeyVaultSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.KeyVaultSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.KeyVaultSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.KeyVaultSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.KeyVaultSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LastPatchInstallationSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary>
    {
        internal LastPatchInstallationSummary() { }
        public Azure.ResourceManager.Compute.Models.ComputeApiError Error { get { throw null; } }
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
        Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxConfiguration>
    {
        public LinuxConfiguration() { }
        public bool? IsPasswordAuthenticationDisabled { get { throw null; } set { } }
        public bool? IsVmAgentPlatformUpdatesEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxPatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.SshPublicKeyConfiguration> SshPublicKeys { get { throw null; } }
        Azure.ResourceManager.Compute.Models.LinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.LinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxParameters>
    {
        public LinuxParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux> ClassificationsToInclude { get { throw null; } }
        public string MaintenanceRunId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PackageNameMasksToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToInclude { get { throw null; } }
        Azure.ResourceManager.Compute.Models.LinuxParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.LinuxParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LinuxPatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxPatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxPatchSettings>
    {
        public LinuxPatchSettings() { }
        public Azure.ResourceManager.Compute.Models.LinuxPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchMode? PatchMode { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.LinuxPatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxPatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxPatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.LinuxPatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxPatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxPatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxPatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxVmGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxVmGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>
    {
        public LinuxVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LinuxVmGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LogAnalytics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LogAnalytics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LogAnalytics>
    {
        internal LogAnalytics() { }
        public string LogAnalyticsOutput { get { throw null; } }
        Azure.ResourceManager.Compute.Models.LogAnalytics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LogAnalytics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LogAnalytics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.LogAnalytics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LogAnalytics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LogAnalytics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LogAnalytics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsInputBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase>
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
        Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MaintenanceOperationResultCodeType
    {
        None = 0,
        RetryLater = 1,
        MaintenanceAborted = 2,
        MaintenanceCompleted = 3,
    }
    public partial class MaintenanceRedeployStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus>
    {
        internal MaintenanceRedeployStatus() { }
        public bool? IsCustomerInitiatedMaintenanceAllowed { get { throw null; } }
        public string LastOperationMessage { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.MaintenanceOperationResultCodeType? LastOperationResultCode { get { throw null; } }
        public System.DateTimeOffset? MaintenanceWindowEndOn { get { throw null; } }
        public System.DateTimeOffset? MaintenanceWindowStartOn { get { throw null; } }
        public System.DateTimeOffset? PreMaintenanceWindowEndOn { get { throw null; } }
        public System.DateTimeOffset? PreMaintenanceWindowStartOn { get { throw null; } }
        Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Mode : System.IEquatable<Azure.ResourceManager.Compute.Models.Mode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Mode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.Mode Audit { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.Mode Enforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.Mode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.Mode left, Azure.ResourceManager.Compute.Models.Mode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.Mode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.Mode left, Azure.ResourceManager.Compute.Models.Mode right) { throw null; }
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
    public enum OperatingSystemStateType
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
    public readonly partial struct OrchestrationServiceName : System.IEquatable<Azure.ResourceManager.Compute.Models.OrchestrationServiceName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestrationServiceName(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.OrchestrationServiceName AutomaticRepairs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.OrchestrationServiceName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.OrchestrationServiceName left, Azure.ResourceManager.Compute.Models.OrchestrationServiceName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.OrchestrationServiceName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.OrchestrationServiceName left, Azure.ResourceManager.Compute.Models.OrchestrationServiceName right) { throw null; }
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
    public partial class OrchestrationServiceStateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent>
    {
        public OrchestrationServiceStateContent(Azure.ResourceManager.Compute.Models.OrchestrationServiceName serviceName, Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction action) { }
        public Azure.ResourceManager.Compute.Models.OrchestrationServiceStateAction Action { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OrchestrationServiceName ServiceName { get { throw null; } }
        Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceStateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrchestrationServiceSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary>
    {
        internal OrchestrationServiceSummary() { }
        public Azure.ResourceManager.Compute.Models.OrchestrationServiceName? ServiceName { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OrchestrationServiceState? ServiceState { get { throw null; } }
        Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSImageNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OSImageNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OSImageNotificationProfile>
    {
        public OSImageNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.OSImageNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OSImageNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OSImageNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.OSImageNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OSImageNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OSImageNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OSImageNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OSProfileProvisioningData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OSProfileProvisioningData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OSProfileProvisioningData>
    {
        public OSProfileProvisioningData() { }
        public string AdminPassword { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.OSProfileProvisioningData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OSProfileProvisioningData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.OSProfileProvisioningData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.OSProfileProvisioningData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OSProfileProvisioningData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OSProfileProvisioningData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.OSProfileProvisioningData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PassName : System.IEquatable<Azure.ResourceManager.Compute.Models.PassName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PassName(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.PassName OobeSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.PassName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.PassName left, Azure.ResourceManager.Compute.Models.PassName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.PassName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.PassName left, Azure.ResourceManager.Compute.Models.PassName right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class PatchInstallationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.PatchInstallationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PatchInstallationDetail>
    {
        internal PatchInstallationDetail() { }
        public System.Collections.Generic.IReadOnlyList<string> Classifications { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchInstallationState? InstallationState { get { throw null; } }
        public string KbId { get { throw null; } }
        public string Name { get { throw null; } }
        public string PatchId { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.Compute.Models.PatchInstallationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.PatchInstallationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.PatchInstallationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.PatchInstallationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PatchInstallationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PatchInstallationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PatchInstallationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PatchSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.PatchSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PatchSettings>
    {
        public PatchSettings() { }
        public Azure.ResourceManager.Compute.Models.WindowsPatchAssessmentMode? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get { throw null; } set { } }
        public bool? EnableHotpatching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchMode? PatchMode { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.PatchSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.PatchSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.PatchSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.PatchSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PatchSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PatchSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PatchSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProximityPlacementGroupPatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch>
    {
        public ProximityPlacementGroupPatch() { }
        Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ProximityPlacementGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ProxyAgentSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ProxyAgentSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ProxyAgentSettings>
    {
        public ProxyAgentSettings() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? KeyIncarnationId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.Mode? Mode { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ProxyAgentSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ProxyAgentSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ProxyAgentSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ProxyAgentSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ProxyAgentSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ProxyAgentSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ProxyAgentSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PurchasePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.PurchasePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PurchasePlan>
    {
        public PurchasePlan(string publisher, string name, string product) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.PurchasePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.PurchasePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.PurchasePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.PurchasePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PurchasePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PurchasePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.PurchasePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryWalkResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>
    {
        internal RecoveryWalkResponse() { }
        public int? NextPlatformUpdateDomain { get { throw null; } }
        public bool? WalkPerformed { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RecoveryWalkResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RecoveryWalkResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RecoveryWalkResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RepairAction : System.IEquatable<Azure.ResourceManager.Compute.Models.RepairAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RepairAction(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RepairAction Reimage { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.RepairAction Replace { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.RepairAction Restart { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.RepairAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.RepairAction left, Azure.ResourceManager.Compute.Models.RepairAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.RepairAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.RepairAction left, Azure.ResourceManager.Compute.Models.RepairAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestRateByIntervalContent : Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent>
    {
        public RequestRateByIntervalContent(System.Uri blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime, Azure.ResourceManager.Compute.Models.IntervalInMins intervalLength) : base (default(System.Uri), default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
        public Azure.ResourceManager.Compute.Models.IntervalInMins IntervalLength { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RequestRateByIntervalContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResiliencyPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ResiliencyPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ResiliencyPolicy>
    {
        public ResiliencyPolicy() { }
        public bool? ResilientVmCreationPolicyEnabled { get { throw null; } set { } }
        public bool? ResilientVmDeletionPolicyEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ResiliencyPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ResiliencyPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ResiliencyPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ResiliencyPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ResiliencyPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ResiliencyPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ResiliencyPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceIdOptionsForGetCapacityReservationGroup : System.IEquatable<Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceIdOptionsForGetCapacityReservationGroup(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup All { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup CreatedInSubscription { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup SharedWithSubscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup left, Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup left, Azure.ResourceManager.Compute.Models.ResourceIdOptionsForGetCapacityReservationGroup right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestorePointEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointEncryption>
    {
        public RestorePointEncryption() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RestorePointEncryptionType? EncryptionType { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.RestorePointEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RestorePointEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestorePointEncryptionType : System.IEquatable<Azure.ResourceManager.Compute.Models.RestorePointEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestorePointEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointEncryptionType EncryptionAtRestWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.RestorePointEncryptionType EncryptionAtRestWithPlatformAndCustomerKeys { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.RestorePointEncryptionType EncryptionAtRestWithPlatformKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.RestorePointEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.RestorePointEncryptionType left, Azure.ResourceManager.Compute.Models.RestorePointEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.RestorePointEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.RestorePointEncryptionType left, Azure.ResourceManager.Compute.Models.RestorePointEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestorePointExpand : System.IEquatable<Azure.ResourceManager.Compute.Models.RestorePointExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestorePointExpand(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointExpand InstanceView { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.RestorePointExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.RestorePointExpand left, Azure.ResourceManager.Compute.Models.RestorePointExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.RestorePointExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.RestorePointExpand left, Azure.ResourceManager.Compute.Models.RestorePointExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestorePointGroupExpand : System.IEquatable<Azure.ResourceManager.Compute.Models.RestorePointGroupExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestorePointGroupExpand(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.RestorePointGroupExpand RestorePoints { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand left, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.RestorePointGroupExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.RestorePointGroupExpand left, Azure.ResourceManager.Compute.Models.RestorePointGroupExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestorePointGroupPatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointGroupPatch>
    {
        public RestorePointGroupPatch() { }
        public string ProvisioningState { get { throw null; } }
        public string RestorePointGroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.RestorePointData> RestorePoints { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointGroupSource Source { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.RestorePointGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RestorePointGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointGroupSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointGroupSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointGroupSource>
    {
        public RestorePointGroupSource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RestorePointGroupSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointGroupSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointGroupSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RestorePointGroupSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointGroupSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointGroupSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointGroupSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointInstanceView>
    {
        internal RestorePointInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DiskRestorePointInstanceView> DiskRestorePoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RestorePointInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RestorePointInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointSourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata>
    {
        public RestorePointSourceMetadata() { }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public string LicenseType { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile OSProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } }
        public string VmId { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointSourceVmDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk>
    {
        public RestorePointSourceVmDataDisk() { }
        public Azure.ResourceManager.Compute.Models.CachingType? Caching { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes DiskRestorePoint { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } }
        public int? Lun { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointSourceVmOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk>
    {
        public RestorePointSourceVmOSDisk() { }
        public Azure.ResourceManager.Compute.Models.CachingType? Caching { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskRestorePointAttributes DiskRestorePoint { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskEncryptionSettings EncryptionSettings { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.OperatingSystemType? OSType { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestorePointSourceVmStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile>
    {
        public RestorePointSourceVmStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RestorePointSourceVmDataDisk> DataDiskList { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskControllerType? DiskControllerType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RestorePointSourceVmOSDisk OSDisk { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RestorePointSourceVmStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RetrieveBootDiagnosticsDataResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>
    {
        internal RetrieveBootDiagnosticsDataResult() { }
        public System.Uri ConsoleScreenshotBlobUri { get { throw null; } }
        public System.Uri SerialConsoleLogBlobUri { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RetrieveBootDiagnosticsDataResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RollbackStatusInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollbackStatusInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollbackStatusInfo>
    {
        internal RollbackStatusInfo() { }
        public int? FailedRolledbackInstanceCount { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeApiError RollbackError { get { throw null; } }
        public int? SuccessfullyRolledbackInstanceCount { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RollbackStatusInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollbackStatusInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollbackStatusInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RollbackStatusInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollbackStatusInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollbackStatusInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollbackStatusInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum RollingUpgradeActionType
    {
        Start = 0,
        Cancel = 1,
    }
    public partial class RollingUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollingUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradePolicy>
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
        Azure.ResourceManager.Compute.Models.RollingUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollingUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollingUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RollingUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RollingUpgradeProgressInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo>
    {
        internal RollingUpgradeProgressInfo() { }
        public int? FailedInstanceCount { get { throw null; } }
        public int? InProgressInstanceCount { get { throw null; } }
        public int? PendingInstanceCount { get { throw null; } }
        public int? SuccessfulInstanceCount { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RollingUpgradeRunningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus>
    {
        internal RollingUpgradeRunningStatus() { }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeStatusCode? Code { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeActionType? LastAction { get { throw null; } }
        public System.DateTimeOffset? LastActionOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RollingUpgradeRunningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum RollingUpgradeStatusCode
    {
        RollingForward = 0,
        Cancelled = 1,
        Completed = 2,
        Faulted = 3,
    }
    public partial class RunCommandDocument : Azure.ResourceManager.Compute.Models.RunCommandDocumentBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandDocument>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandDocument>
    {
        internal RunCommandDocument() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition> Parameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Script { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RunCommandDocument System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandDocument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandDocument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RunCommandDocument System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandDocument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandDocument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandDocument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandDocumentBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase>
    {
        internal RunCommandDocumentBase() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Label { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.SupportedOperatingSystemType OSType { get { throw null; } }
        public string Schema { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RunCommandDocumentBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RunCommandDocumentBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandDocumentBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandInput>
    {
        public RunCommandInput(string commandId) { }
        public string CommandId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<string> Script { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RunCommandInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RunCommandInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandInputParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandInputParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandInputParameter>
    {
        public RunCommandInputParameter(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.RunCommandInputParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandInputParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandInputParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RunCommandInputParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandInputParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandInputParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandInputParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity>
    {
        public RunCommandManagedIdentity() { }
        public string ClientId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandParameterDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition>
    {
        internal RunCommandParameterDefinition() { }
        public string DefaultValue { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? Required { get { throw null; } }
        public string RunCommandParameterDefinitionType { get { throw null; } }
        Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.RunCommandParameterDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScaleInPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ScaleInPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ScaleInPolicy>
    {
        public ScaleInPolicy() { }
        public bool? ForceDeletion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule> Rules { get { throw null; } }
        Azure.ResourceManager.Compute.Models.ScaleInPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ScaleInPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ScaleInPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ScaleInPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ScaleInPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ScaleInPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ScaleInPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledEventsPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy>
    {
        public ScheduledEventsPolicy() { }
        public bool? AutomaticallyApprove { get { throw null; } set { } }
        public bool? Enable { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UserInitiatedRedeploy UserInitiatedRedeploy { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityEncryptionType : System.IEquatable<Azure.ResourceManager.Compute.Models.SecurityEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SecurityEncryptionType DiskWithVmGuestState { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SecurityEncryptionType NonPersistedTPM { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SecurityEncryptionType VmGuestStateOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.SecurityEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.SecurityEncryptionType left, Azure.ResourceManager.Compute.Models.SecurityEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.SecurityEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.SecurityEncryptionType left, Azure.ResourceManager.Compute.Models.SecurityEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityPostureReferenceUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SecurityPostureReferenceUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SecurityPostureReferenceUpdate>
    {
        public SecurityPostureReferenceUpdate() { }
        public System.Collections.Generic.IList<string> ExcludeExtensions { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public bool? IsOverridable { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.SecurityPostureReferenceUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SecurityPostureReferenceUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SecurityPostureReferenceUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.SecurityPostureReferenceUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SecurityPostureReferenceUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SecurityPostureReferenceUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SecurityPostureReferenceUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SecurityProfile>
    {
        public SecurityProfile() { }
        public bool? EncryptionAtHost { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ProxyAgentSettings ProxyAgentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityType? SecurityType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.UefiSettings UefiSettings { get { throw null; } set { } }
        public string UserAssignedIdentityResourceId { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.SecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.SecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityType : System.IEquatable<Azure.ResourceManager.Compute.Models.SecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SecurityType ConfidentialVm { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.SecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.SecurityType left, Azure.ResourceManager.Compute.Models.SecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.SecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.SecurityType left, Azure.ResourceManager.Compute.Models.SecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SettingName
    {
        AutoLogon = 0,
        FirstLogonCommands = 1,
    }
    public partial class SpotRestorePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SpotRestorePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SpotRestorePolicy>
    {
        public SpotRestorePolicy() { }
        public bool? Enabled { get { throw null; } set { } }
        public string RestoreTimeout { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.SpotRestorePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SpotRestorePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SpotRestorePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.SpotRestorePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SpotRestorePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SpotRestorePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SpotRestorePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SshEncryptionType : System.IEquatable<Azure.ResourceManager.Compute.Models.SshEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SshEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.SshEncryptionType Ed25519 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.SshEncryptionType RSA { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.SshEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.SshEncryptionType left, Azure.ResourceManager.Compute.Models.SshEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.SshEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.SshEncryptionType left, Azure.ResourceManager.Compute.Models.SshEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SshGenerateKeyPairInputContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent>
    {
        public SshGenerateKeyPairInputContent() { }
        public Azure.ResourceManager.Compute.Models.SshEncryptionType? EncryptionType { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshGenerateKeyPairInputContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPublicKeyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshPublicKeyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyConfiguration>
    {
        public SshPublicKeyConfiguration() { }
        public string KeyData { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.SshPublicKeyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshPublicKeyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshPublicKeyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.SshPublicKeyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPublicKeyGenerateKeyPairResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>
    {
        internal SshPublicKeyGenerateKeyPairResult() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
        Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyGenerateKeyPairResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SshPublicKeyPatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshPublicKeyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyPatch>
    {
        public SshPublicKeyPatch() { }
        public string PublicKey { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.SshPublicKeyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshPublicKeyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.SshPublicKeyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.SshPublicKeyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.SshPublicKeyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.Compute.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType PremiumV2Lrs { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType PremiumZrs { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType StandardSsdLrs { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType StandardSsdZrs { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.StorageAccountType UltraSsdLrs { get { throw null; } }
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
    public partial class TerminateNotificationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.TerminateNotificationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.TerminateNotificationProfile>
    {
        public TerminateNotificationProfile() { }
        public bool? Enable { get { throw null; } set { } }
        public string NotBeforeTimeout { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.TerminateNotificationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.TerminateNotificationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.TerminateNotificationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.TerminateNotificationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.TerminateNotificationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.TerminateNotificationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.TerminateNotificationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThrottledRequestsContent : Azure.ResourceManager.Compute.Models.LogAnalyticsInputBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ThrottledRequestsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ThrottledRequestsContent>
    {
        public ThrottledRequestsContent(System.Uri blobContainerSasUri, System.DateTimeOffset fromTime, System.DateTimeOffset toTime) : base (default(System.Uri), default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
        Azure.ResourceManager.Compute.Models.ThrottledRequestsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ThrottledRequestsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ThrottledRequestsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ThrottledRequestsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ThrottledRequestsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ThrottledRequestsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ThrottledRequestsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UefiSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UefiSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UefiSettings>
    {
        public UefiSettings() { }
        public bool? IsSecureBootEnabled { get { throw null; } set { } }
        public bool? IsVirtualTpmEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.UefiSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UefiSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UefiSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.UefiSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UefiSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UefiSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UefiSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradeOperationHistoricalStatusInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo>
    {
        internal UpgradeOperationHistoricalStatusInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties Properties { get { throw null; } }
        public string UpgradeOperationHistoricalStatusInfoType { get { throw null; } }
        Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradeOperationHistoricalStatusInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties>
    {
        internal UpgradeOperationHistoricalStatusInfoProperties() { }
        public Azure.ResourceManager.Compute.Models.ComputeApiError Error { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradeProgressInfo Progress { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RollbackStatusInfo RollbackInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus RunningStatus { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.UpgradeOperationInvoker? StartedBy { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ImageReference TargetImageReference { get { throw null; } }
        Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoricalStatusInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradeOperationHistoryStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus>
    {
        internal UpgradeOperationHistoryStatus() { }
        public Azure.ResourceManager.Compute.Models.UpgradeState? Code { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UpgradeOperationHistoryStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class UserInitiatedRedeploy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UserInitiatedRedeploy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UserInitiatedRedeploy>
    {
        public UserInitiatedRedeploy() { }
        public bool? AutomaticallyApprove { get { throw null; } set { } }
        public string DummyProperty { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.UserInitiatedRedeploy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UserInitiatedRedeploy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.UserInitiatedRedeploy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.UserInitiatedRedeploy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UserInitiatedRedeploy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UserInitiatedRedeploy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.UserInitiatedRedeploy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VaultCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VaultCertificate>
    {
        public VaultCertificate() { }
        public string CertificateStore { get { throw null; } set { } }
        public System.Uri CertificateUri { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VaultCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VaultCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VaultCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VaultCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VaultCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VaultCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VaultCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultSecretGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VaultSecretGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VaultSecretGroup>
    {
        public VaultSecretGroup() { }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultCertificate> VaultCertificates { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VaultSecretGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VaultSecretGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VaultSecretGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VaultSecretGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VaultSecretGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VaultSecretGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VaultSecretGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineAgentInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView>
    {
        internal VirtualMachineAgentInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView> ExtensionHandlers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public string VmAgentVersion { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineAssessPatchesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>
    {
        internal VirtualMachineAssessPatchesResult() { }
        public string AssessmentActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties> AvailablePatches { get { throw null; } }
        public int? CriticalAndSecurityPatchCount { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeApiError Error { get { throw null; } }
        public int? OtherPatchCount { get { throw null; } }
        public bool? RebootPending { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchOperationStatus? Status { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineAssessPatchesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineCaptureContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent>
    {
        public VirtualMachineCaptureContent(string vhdPrefix, string destinationContainerName, bool overwriteVhds) { }
        public string DestinationContainerName { get { throw null; } }
        public bool OverwriteVhds { get { throw null; } }
        public string VhdPrefix { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineCaptureResult : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>
    {
        public VirtualMachineCaptureResult() { }
        public string ContentVersion { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> Resources { get { throw null; } }
        public string Schema { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineCaptureResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk>
    {
        public VirtualMachineDataDisk(int lun, Azure.ResourceManager.Compute.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskDetachOptionType? DetachOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } }
        public long? DiskMBpsReadWrite { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public bool? ToBeDetached { get { throw null; } set { } }
        public System.Uri VhdUri { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineDiskSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile>
    {
        public VirtualMachineDiskSecurityProfile() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityEncryptionType? SecurityEncryptionType { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineDiskType : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineDiskType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineDiskType None { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineDiskType Unmanaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineDiskType left, Azure.ResourceManager.Compute.Models.VirtualMachineDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineDiskType left, Azure.ResourceManager.Compute.Models.VirtualMachineDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineEvictionPolicyType : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineEvictionPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType Deallocate { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType left, Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType left, Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineExtensionHandlerInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView>
    {
        internal VirtualMachineExtensionHandlerInstanceView() { }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus Status { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } }
        public string VirtualMachineExtensionHandlerInstanceViewType { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionHandlerInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView>
    {
        public VirtualMachineExtensionInstanceView() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Substatuses { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        public string VirtualMachineExtensionInstanceViewType { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineExtensionPatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch>
    {
        public VirtualMachineExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineGalleryApplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication>
    {
        public VirtualMachineGalleryApplication(string packageReferenceId) { }
        public string ConfigurationReference { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public int? Order { get { throw null; } set { } }
        public string PackageReferenceId { get { throw null; } set { } }
        public string Tags { get { throw null; } set { } }
        public bool? TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineHardwareProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile>
    {
        public VirtualMachineHardwareProfile() { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineSizeType? VmSize { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties VmSizeProperties { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineImage : Azure.ResourceManager.Compute.Models.VirtualMachineImageBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImage>
    {
        public VirtualMachineImage(string name, Azure.Core.AzureLocation location) : base (default(string), default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Compute.Models.ArchitectureType? Architecture { get { throw null; } set { } }
        public bool? AutomaticOSUpgradeSupported { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.DataDiskImage> DataDiskImages { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineDiskType? DisallowedVmDiskType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature> Features { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageDeprecationStatus ImageDeprecationStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SupportedOperatingSystemType? OSDiskImageOperatingSystem { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PurchasePlan Plan { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineImageBase : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase>
    {
        public VirtualMachineImageBase(string name, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineImageBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineImageBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineImageFeature : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature>
    {
        public VirtualMachineImageFeature() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineImageFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstallPatchesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent>
    {
        public VirtualMachineInstallPatchesContent(Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting rebootSetting) { }
        public Azure.ResourceManager.Compute.Models.LinuxParameters LinuxParameters { get { throw null; } set { } }
        public System.TimeSpan? MaximumDuration { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VmGuestPatchRebootSetting RebootSetting { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.WindowsParameters WindowsParameters { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstallPatchesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>
    {
        internal VirtualMachineInstallPatchesResult() { }
        public Azure.ResourceManager.Compute.Models.ComputeApiError Error { get { throw null; } }
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
        Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstallPatchesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView>
    {
        internal VirtualMachineInstanceView() { }
        public string AssignedHost { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView BootDiagnostics { get { throw null; } }
        public string ComputerName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DiskInstanceView> Disks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView> Extensions { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public bool? IsVmInStandbyPool { get { throw null; } }
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
        Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineIPTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineIPTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineIPTag>
    {
        public VirtualMachineIPTag() { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineIPTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineIPTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineIPTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineIPTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineIPTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineIPTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineIPTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineManagedDisk : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk>
    {
        public VirtualMachineManagedDisk() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration>
    {
        public VirtualMachineNetworkInterfaceConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeDeleteOption? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public Azure.Core.ResourceIdentifier DscpConfigurationId { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration> IPConfigurations { get { throw null; } }
        public bool? IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration>
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
        Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkInterfaceReference : Azure.ResourceManager.Compute.Models.ComputeWriteableSubResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceReference>
    {
        public VirtualMachineNetworkInterfaceReference() { }
        public Azure.ResourceManager.Compute.Models.ComputeDeleteOption? DeleteOption { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile>
    {
        public VirtualMachineNetworkProfile() { }
        public Azure.ResourceManager.Compute.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkInterfaceReference> NetworkInterfaces { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSDisk>
    {
        public VirtualMachineOSDisk(Azure.ResourceManager.Compute.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskEncryptionSettings EncryptionSettings { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SupportedOperatingSystemType? OSType { get { throw null; } set { } }
        public System.Uri VhdUri { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile>
    {
        public VirtualMachineOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public bool? AllowExtensionOperations { get { throw null; } set { } }
        public string ComputerName { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public bool? RequireGuestProvisionSignal { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatch>
    {
        public VirtualMachinePatch() { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AvailabilitySetId { get { throw null; } set { } }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType? EvictionPolicy { get { throw null; } set { } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineHardwareProfile HardwareProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineInstanceView InstanceView { get { throw null; } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePlan Plan { get { throw null; } set { } }
        public int? PlatformFaultDomain { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScheduledEventsPolicy ScheduledEventsPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile StorageProfile { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UserData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineScaleSetId { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachinePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachinePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePatchStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus>
    {
        internal VirtualMachinePatchStatus() { }
        public Azure.ResourceManager.Compute.Models.AvailablePatchSummary AvailablePatchSummary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> ConfigurationStatuses { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.LastPatchInstallationSummary LastPatchInstallationSummary { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePatchStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePriorityType : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePriorityType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType Low { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType Regular { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType left, Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType left, Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration>
    {
        public VirtualMachinePublicIPAddressConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.ComputeDeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineIPTag> IPTags { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.PublicIPAllocationMethod? PublicIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku Sku { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachinePublicIPAddressDnsSettingsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>
    {
        public VirtualMachinePublicIPAddressDnsSettingsConfiguration(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType? DomainNameLabelScope { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachinePublicIPAddressDnsSettingsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineReimageContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent>
    {
        public VirtualMachineReimageContent() { }
        public string ExactVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.OSProfileProvisioningData OSProfile { get { throw null; } set { } }
        public bool? TempDisk { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRunCommandInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView>
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
        Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRunCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult>
    {
        internal VirtualMachineRunCommandResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Value { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRunCommandScriptSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource>
    {
        public VirtualMachineRunCommandScriptSource() { }
        public string CommandId { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Uri ScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity ScriptUriManagedIdentity { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineRunCommandUpdate : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate>
    {
        public VirtualMachineRunCommandUpdate() { }
        public bool? AsyncExecution { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity ErrorBlobManagedIdentity { get { throw null; } set { } }
        public System.Uri ErrorBlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.RunCommandManagedIdentity OutputBlobManagedIdentity { get { throw null; } set { } }
        public System.Uri OutputBlobUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.RunCommandInputParameter> ProtectedParameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string RunAsPassword { get { throw null; } set { } }
        public string RunAsUser { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandScriptSource Source { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public bool? TreatFailureAsDeploymentFailure { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineRunCommandUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetConvertToSinglePlacementGroupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>
    {
        public VirtualMachineScaleSetConvertToSinglePlacementGroupContent() { }
        public string ActivePlacementGroupId { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetConvertToSinglePlacementGroupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk>
    {
        public VirtualMachineScaleSetDataDisk(int lun, Azure.ResourceManager.Compute.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch>
    {
        public VirtualMachineScaleSetExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetExtensionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile>
    {
        public VirtualMachineScaleSetExtensionProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.VirtualMachineScaleSetExtensionData> Extensions { get { throw null; } }
        public string ExtensionsTimeBudget { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineScaleSetGetExpand : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineScaleSetGetExpand(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand UserData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand left, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand left, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetGetExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineScaleSetInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView>
    {
        internal VirtualMachineScaleSetInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary> Extensions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.OrchestrationServiceSummary> OrchestrationServices { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount> VirtualMachineStatusesSummary { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration>
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
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetIPTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag>
    {
        public VirtualMachineScaleSetIPTag() { }
        public string IPTagType { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetManagedDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk>
    {
        public VirtualMachineScaleSetManagedDisk() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineDiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration>
    {
        public VirtualMachineScaleSetNetworkConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeDeleteOption? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPConfiguration> IPConfigurations { get { throw null; } }
        public bool? IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile>
    {
        public VirtualMachineScaleSetNetworkProfile() { }
        public Azure.Core.ResourceIdentifier HealthProbeId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk>
    {
        public VirtualMachineScaleSetOSDisk(Azure.ResourceManager.Compute.Models.DiskCreateOptionType createOption) { }
        public Azure.ResourceManager.Compute.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskCreateOptionType CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk ManagedDisk { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SupportedOperatingSystemType? OSType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile>
    {
        public VirtualMachineScaleSetOSProfile() { }
        public string AdminPassword { get { throw null; } set { } }
        public string AdminUsername { get { throw null; } set { } }
        public bool? AllowExtensionOperations { get { throw null; } set { } }
        public string ComputerNamePrefix { get { throw null; } set { } }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public bool? RequireGuestProvisionSignal { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPatch : Azure.ResourceManager.Compute.Models.ComputeResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch>
    {
        public VirtualMachineScaleSetPatch() { }
        public Azure.ResourceManager.Compute.Models.AdditionalCapabilities AdditionalCapabilities { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.AutomaticRepairsPolicy AutomaticRepairsPolicy { get { throw null; } set { } }
        public bool? DoNotRunExtensionsOnOverprovisionedVms { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? Overprovision { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy PriorityMixPolicy { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ResiliencyPolicy ResiliencyPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ScaleInPolicy ScaleInPolicy { get { throw null; } set { } }
        public bool? SinglePlacementGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSkuProfile SkuProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SpotRestorePolicy SpotRestorePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy UpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile VirtualMachineProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode? ZonalPlatformFaultDomainAlignMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPriorityMixPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy>
    {
        public VirtualMachineScaleSetPriorityMixPolicy() { }
        public int? BaseRegularPriorityCount { get { throw null; } set { } }
        public int? RegularPriorityPercentageAboveBase { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPriorityMixPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>
    {
        public VirtualMachineScaleSetPublicIPAddressConfiguration(string name) { }
        public Azure.ResourceManager.Compute.Models.ComputeDeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetIPTag> IPTags { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.IPVersion? PublicIPAddressVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputePublicIPAddressSku Sku { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>
    {
        public VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings(string domainNameLabel) { }
        public string DomainNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DomainNameLabelScopeType? DomainNameLabelScope { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetReimageContent : Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent>
    {
        public VirtualMachineScaleSetReimageContent() { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetReimageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineScaleSetScaleInRule : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineScaleSetScaleInRule(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule Default { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule NewestVm { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule OldestVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule left, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule left, Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetScaleInRule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineScaleSetSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku>
    {
        internal VirtualMachineScaleSetSku() { }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeSku Sku { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity>
    {
        internal VirtualMachineScaleSetSkuCapacity() { }
        public long? DefaultCapacity { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuScaleType? ScaleType { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum VirtualMachineScaleSetSkuScaleType
    {
        None = 0,
        Automatic = 1,
    }
    public partial class VirtualMachineScaleSetStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile>
    {
        public VirtualMachineScaleSetStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } }
        public string DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSDisk OSDisk { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration>
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
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>
    {
        public VirtualMachineScaleSetUpdateNetworkConfiguration() { }
        public Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliaryMode? AuxiliaryMode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeNetworkInterfaceAuxiliarySku? AuxiliarySku { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeDeleteOption? DeleteOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DnsServers { get { throw null; } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public bool? EnableFpga { get { throw null; } set { } }
        public bool? EnableIPForwarding { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateIPConfiguration> IPConfigurations { get { throw null; } }
        public bool? IsTcpStateTrackingDisabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkSecurityGroupId { get { throw null; } set { } }
        public bool? Primary { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile>
    {
        public VirtualMachineScaleSetUpdateNetworkProfile() { }
        public Azure.Core.ResourceIdentifier HealthProbeId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.NetworkApiVersion? NetworkApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkConfiguration> NetworkInterfaceConfigurations { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk>
    {
        public VirtualMachineScaleSetUpdateOSDisk() { }
        public Azure.ResourceManager.Compute.Models.CachingType? Caching { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiskDeleteOptionType? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.DiffDiskSettings DiffDiskSettings { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetManagedDisk ManagedDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VhdContainers { get { throw null; } }
        public bool? WriteAcceleratorEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile>
    {
        public VirtualMachineScaleSetUpdateOSProfile() { }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.LinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VaultSecretGroup> Secrets { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdatePublicIPAddressConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>
    {
        public VirtualMachineScaleSetUpdatePublicIPAddressConfiguration() { }
        public Azure.ResourceManager.Compute.Models.ComputeDeleteOption? DeleteOption { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettings DnsSettings { get { throw null; } set { } }
        public int? IdleTimeoutInMinutes { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPPrefixId { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdatePublicIPAddressConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile>
    {
        public VirtualMachineScaleSetUpdateStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetDataDisk> DataDisks { get { throw null; } }
        public string DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSDisk OSDisk { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetUpdateVmProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile>
    {
        public VirtualMachineScaleSetUpdateVmProfile() { }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties HardwareVmSizeProperties { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityPostureReferenceUpdate SecurityPostureReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpdateVmProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum VirtualMachineScaleSetUpgradeMode
    {
        Automatic = 0,
        Manual = 1,
        Rolling = 2,
    }
    public partial class VirtualMachineScaleSetUpgradePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy>
    {
        public VirtualMachineScaleSetUpgradePolicy() { }
        public Azure.ResourceManager.Compute.Models.AutomaticOSUpgradePolicy AutomaticOSUpgradePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradeMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.RollingUpgradePolicy RollingUpgradePolicy { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetUpgradePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch>
    {
        public VirtualMachineScaleSetVmExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ExtensionType { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.KeyVaultSecretReference KeyVaultProtectedSettings { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public bool? SuppressFailures { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmExtensionsSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary>
    {
        internal VirtualMachineScaleSetVmExtensionsSummary() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount> StatusesSummary { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmExtensionsSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmInstanceIds : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds>
    {
        public VirtualMachineScaleSetVmInstanceIds() { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceIds>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmInstanceRequiredIds : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds>
    {
        public VirtualMachineScaleSetVmInstanceRequiredIds(System.Collections.Generic.IEnumerable<string> instanceIds) { }
        public System.Collections.Generic.IList<string> InstanceIds { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceRequiredIds>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView>
    {
        internal VirtualMachineScaleSetVmInstanceView() { }
        public Azure.Core.ResourceIdentifier AssignedHost { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.BootDiagnosticsInstanceView BootDiagnostics { get { throw null; } }
        public string ComputerName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.DiskInstanceView> Disks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.VirtualMachineExtensionInstanceView> Extensions { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.MaintenanceRedeployStatus MaintenanceRedeployStatus { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSVersion { get { throw null; } }
        public string PlacementGroupId { get { throw null; } }
        public int? PlatformFaultDomain { get { throw null; } }
        public int? PlatformUpdateDomain { get { throw null; } }
        public string RdpThumbPrint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineAgentInstanceView VmAgent { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.InstanceViewStatus VmHealthStatus { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile>
    {
        public VirtualMachineScaleSetVmProfile() { }
        public double? BillingMaxPrice { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.BootDiagnostics BootDiagnostics { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CapacityReservationGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineEvictionPolicyType? EvictionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetExtensionProfile ExtensionProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineGalleryApplication> GalleryApplications { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties HardwareVmSizeProperties { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetOSProfile OSProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachinePriorityType? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeScheduledEventsProfile ScheduledEventsProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ComputeSecurityPostureReference SecurityPostureReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.SecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceArtifactReferenceId { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetStorageProfile StorageProfile { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UserData { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmProtectionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy>
    {
        public VirtualMachineScaleSetVmProtectionPolicy() { }
        public bool? ProtectFromScaleIn { get { throw null; } set { } }
        public bool? ProtectFromScaleSetActions { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineScaleSetVmReimageContent : Azure.ResourceManager.Compute.Models.VirtualMachineReimageContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent>
    {
        public VirtualMachineScaleSetVmReimageContent() { }
        public bool? ForceUpdateOSDiskForEphemeral { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineScaleSetVmReimageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineSize : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineSize>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSize>
    {
        internal VirtualMachineSize() { }
        public int? MaxDataDiskCount { get { throw null; } }
        public int? MemoryInMB { get { throw null; } }
        public string Name { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public int? OSDiskSizeInMB { get { throw null; } }
        public int? ResourceDiskSizeInMB { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineSize System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineSize>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineSize>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineSize System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSize>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSize>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSize>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineSizeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties>
    {
        public VirtualMachineSizeProperties() { }
        public int? VCpusAvailable { get { throw null; } set { } }
        public int? VCpusPerCore { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSizeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineSizeType : System.IEquatable<Azure.ResourceManager.Compute.Models.VirtualMachineSizeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineSizeType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType BasicA0 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType BasicA1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType BasicA2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType BasicA3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType BasicA4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA0 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA10 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA1V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA2MV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA4MV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA6 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA7 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA8MV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA8V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardA9 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardB1Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardB1S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardB2Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardB2S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardB4Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardB8Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD13 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD14 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD15V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD16V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD1V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD2V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD2V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD32V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD3V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD4V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD4V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD5V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD64V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardD8V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS11 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS11V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS12V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS13 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS132V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS134V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS14 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS144V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS148V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS14V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS15V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS1V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE16V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE2V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE3216V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE328SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE32V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE4V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE6416SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE6432SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE64V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardE8V3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF16 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF16S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF1S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF2S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF2SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF32SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF4S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF4SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF72SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF8S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardF8SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardG1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardG2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardG3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardG4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardG5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardGS1 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardGS2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardGS3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardGS4 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardGS44 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardGS48 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardGS5 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardGS516 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardGS58 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardH16 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardH16M { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardH16Mr { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardH16R { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardH8 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardH8M { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardL16S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardL32S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardL4S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardL8S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardM12832Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardM12864Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardM128Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardM128S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardM6416Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardM6432Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardM64Ms { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardM64S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC12SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC12SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC24 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC24R { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC24RsV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC24RsV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC24SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC24SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC6 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC6SV2 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNC6SV3 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardND12S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardND24Rs { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardND24S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardND6S { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNV12 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNV24 { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VirtualMachineSizeType StandardNV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VirtualMachineSizeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VirtualMachineSizeType left, Azure.ResourceManager.Compute.Models.VirtualMachineSizeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VirtualMachineSizeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VirtualMachineSizeType left, Azure.ResourceManager.Compute.Models.VirtualMachineSizeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachineSoftwarePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties>
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
        Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineSoftwarePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineStatusCodeCount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount>
    {
        internal VirtualMachineStatusCodeCount() { }
        public string Code { get { throw null; } }
        public int? Count { get { throw null; } }
        Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineStatusCodeCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualMachineStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile>
    {
        public VirtualMachineStorageProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VirtualMachineDataDisk> DataDisks { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.DiskControllerType? DiskControllerType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.ImageReference ImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.VirtualMachineOSDisk OSDisk { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.VirtualMachineStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchClassificationForLinux : System.IEquatable<Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchClassificationForLinux(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux Critical { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux Other { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux Security { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux left, Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux left, Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForLinux right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchClassificationForWindows : System.IEquatable<Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchClassificationForWindows(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows Critical { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows Definition { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows FeaturePack { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows Security { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows ServicePack { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows Tools { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows UpdateRollUp { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows Updates { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows left, Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows left, Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows right) { throw null; }
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
    public partial class WindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsConfiguration>
    {
        public WindowsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.AdditionalUnattendContent> AdditionalUnattendContent { get { throw null; } }
        public bool? IsAutomaticUpdatesEnabled { get { throw null; } set { } }
        public bool? IsVmAgentPlatformUpdatesEnabled { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.PatchSettings PatchSettings { get { throw null; } set { } }
        public bool? ProvisionVmAgent { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.WinRMListener> WinRMListeners { get { throw null; } }
        Azure.ResourceManager.Compute.Models.WindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.WindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WindowsParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WindowsParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsParameters>
    {
        public WindowsParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Models.VmGuestPatchClassificationForWindows> ClassificationsToInclude { get { throw null; } }
        public bool? ExcludeKbsRequiringReboot { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KbNumbersToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> KbNumbersToInclude { get { throw null; } }
        public System.DateTimeOffset? MaxPatchPublishOn { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.WindowsParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WindowsParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WindowsParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.WindowsParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct WindowsVmGuestPatchAutomaticByPlatformRebootSetting : System.IEquatable<Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsVmGuestPatchAutomaticByPlatformRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Never { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting left, Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsVmGuestPatchAutomaticByPlatformSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>
    {
        public WindowsVmGuestPatchAutomaticByPlatformSettings() { }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformRebootSetting? RebootSetting { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WindowsVmGuestPatchAutomaticByPlatformSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class WinRMListener : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WinRMListener>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WinRMListener>
    {
        public WinRMListener() { }
        public System.Uri CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Models.WinRMListenerProtocolType? Protocol { get { throw null; } set { } }
        Azure.ResourceManager.Compute.Models.WinRMListener System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WinRMListener>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.WinRMListener>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.WinRMListener System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WinRMListener>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WinRMListener>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.WinRMListener>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WinRMListenerProtocolType
    {
        Http = 0,
        Https = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZonalPlatformFaultDomainAlignMode : System.IEquatable<Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZonalPlatformFaultDomainAlignMode(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode Aligned { get { throw null; } }
        public static Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode Unaligned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode left, Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode left, Azure.ResourceManager.Compute.Models.ZonalPlatformFaultDomainAlignMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
