namespace Azure.ResourceManager.DataBoxEdge
{
    public partial class AddonCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.AddonResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.AddonResource>, System.Collections.IEnumerable
    {
        protected AddonCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.AddonResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.DataBoxEdge.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.AddonResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string addonName, Azure.ResourceManager.DataBoxEdge.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.AddonResource> Get(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.AddonResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.AddonResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.AddonResource>> GetAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.AddonResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.AddonResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.AddonResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.AddonResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AddonData : Azure.ResourceManager.Models.ResourceData
    {
        public AddonData() { }
    }
    public partial class AddonResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AddonResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.AddonData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string roleName, string addonName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.AddonResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.AddonResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.AddonResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.AddonResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.AddonData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.AlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.AlertResource>, System.Collections.IEnumerable
    {
        protected AlertCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.AlertResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.AlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.AlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.AlertResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.AlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.AlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.AlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.AlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertData : Azure.ResourceManager.Models.ResourceData
    {
        public AlertData() { }
        public string AlertType { get { throw null; } }
        public System.DateTimeOffset? AppearedAtOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> DetailedInformation { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.AlertErrorDetails ErrorDetails { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity? Severity { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class AlertResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.AlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.AlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.AlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BandwidthScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>, System.Collections.IEnumerable
    {
        protected BandwidthScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.BandwidthScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.BandwidthScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BandwidthScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public BandwidthScheduleData(string start, string stop, int rateInMbps, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek> days) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek> Days { get { throw null; } }
        public int RateInMbps { get { throw null; } set { } }
        public string Start { get { throw null; } set { } }
        public string Stop { get { throw null; } set { } }
    }
    public partial class BandwidthScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BandwidthScheduleResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.BandwidthScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.BandwidthScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.BandwidthScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.ContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.ContainerResource>, System.Collections.IEnumerable
    {
        protected ContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.ContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string containerName, Azure.ResourceManager.DataBoxEdge.ContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.ContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string containerName, Azure.ResourceManager.DataBoxEdge.ContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.ContainerResource> Get(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.ContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.ContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.ContainerResource>> GetAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.ContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.ContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.ContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.ContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerData : Azure.ResourceManager.Models.ResourceData
    {
        public ContainerData(Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat dataFormat) { }
        public Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus? ContainerStatus { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat DataFormat { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.RefreshDetails RefreshDetails { get { throw null; } }
    }
    public partial class ContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.ContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string storageAccountName, string containerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.ContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.ContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Refresh(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.ContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.ContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.ContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.ContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeDeviceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>, System.Collections.IEnumerable
    {
        protected DataBoxEdgeDeviceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deviceName, Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> Get(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> GetAsync(string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataBoxEdgeDeviceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DataBoxEdgeDeviceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.RoleType> ConfiguredRoleTypes { get { throw null; } }
        public string Culture { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus? DataBoxEdgeDeviceStatus { get { throw null; } }
        public string Description { get { throw null; } }
        public string DeviceHcsVersion { get { throw null; } }
        public long? DeviceLocalCapacity { get { throw null; } }
        public string DeviceModel { get { throw null; } }
        public string DeviceSoftwareVersion { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DeviceType? DeviceType { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeProfileSubscription EdgeSubscription { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind? Kind { get { throw null; } }
        public string ModelDescription { get { throw null; } }
        public int? NodeCount { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataResidencyType? ResidencyType { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveDetails ResourceMoveDetails { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemDataPropertiesSystemData { get { throw null; } }
        public string TimeZone { get { throw null; } }
    }
    public partial class DataBoxEdgeDeviceJobCollection : Azure.ResourceManager.ArmCollection
    {
        protected DataBoxEdgeDeviceJobCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeDeviceJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeDeviceJobResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.JobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeDeviceJobStatusCollection : Azure.ResourceManager.ArmCollection
    {
        protected DataBoxEdgeDeviceJobStatusCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobStatusResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobStatusResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeDeviceJobStatusResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeDeviceJobStatusResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.JobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobStatusResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobStatusResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoxEdgeDeviceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoxEdgeDeviceResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CheckResourceCreationFeasibilityDeviceCapacityCheck(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.DeviceCapacityRequestContent content, string capacityName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CheckResourceCreationFeasibilityDeviceCapacityCheckAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.DeviceCapacityRequestContent content, string capacityName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdateSecuritySettings(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.SecuritySettings securitySettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateSecuritySettingsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.SecuritySettings securitySettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DownloadUpdates(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DownloadUpdatesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.GenerateCertResponse> GenerateCertificate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.GenerateCertResponse>> GenerateCertificateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.AlertResource> GetAlert(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.AlertResource>> GetAlertAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.AlertCollection GetAlerts() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource> GetBandwidthSchedule(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource>> GetBandwidthScheduleAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.BandwidthScheduleCollection GetBandwidthSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobResource> GetDataBoxEdgeDeviceJob(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobResource>> GetDataBoxEdgeDeviceJobAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobCollection GetDataBoxEdgeDeviceJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobStatusResource> GetDataBoxEdgeDeviceJobStatus(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobStatusResource>> GetDataBoxEdgeDeviceJobStatusAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobStatusCollection GetDataBoxEdgeDeviceJobStatuses() { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DeviceCapacityInfoResource GetDeviceCapacityInfo() { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource GetDiagnosticProactiveLogCollectionSetting() { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource GetDiagnosticRemoteSupportSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfo> GetExtendedInformation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfo>> GetExtendedInformationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.NetworkSettingResource GetNetworkSetting() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.Models.Node> GetNodesByDataBoxEdgeDevice(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.Models.Node> GetNodesByDataBoxEdgeDeviceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.OrderResource GetOrder() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.RoleResource> GetRole(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.RoleResource>> GetRoleAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.RoleCollection GetRoles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.ShareResource> GetShare(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.ShareResource>> GetShareAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.ShareCollection GetShares() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountResource> GetStorageAccount(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountResource>> GetStorageAccountAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource> GetStorageAccountCredential(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource>> GetStorageAccountCredentialAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialCollection GetStorageAccountCredentials() { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.StorageAccountCollection GetStorageAccounts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.TriggerResource> GetTrigger(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.TriggerResource>> GetTriggerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.TriggerCollection GetTriggers() { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.UpdateSummaryResource GetUpdateSummary() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.UserResource> GetUser(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.UserResource>> GetUserAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.UserCollection GetUsers() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InstallUpdates(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InstallUpdatesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ScanForUpdates(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ScanForUpdatesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerSupportPackageSupportPackage(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.TriggerSupportPackageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerSupportPackageSupportPackageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.Models.TriggerSupportPackageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> Update(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> UpdateAsync(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDevicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfo> UpdateExtendedInformation(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfo>> UpdateExtendedInformationAsync(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceExtendedInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.UploadCertificateResponse> UploadCertificate(Azure.ResourceManager.DataBoxEdge.Models.UploadCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.UploadCertificateResponse>> UploadCertificateAsync(Azure.ResourceManager.DataBoxEdge.Models.UploadCertificateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DataBoxEdgeExtensions
    {
        public static Azure.ResourceManager.DataBoxEdge.AddonResource GetAddonResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.AlertResource GetAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataBoxEdge.Models.AvailableDataBoxEdgeSku> GetAvailableSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.Models.AvailableDataBoxEdgeSku> GetAvailableSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.BandwidthScheduleResource GetBandwidthScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.ContainerResource GetContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> GetDataBoxEdgeDevice(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource>> GetDataBoxEdgeDeviceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobResource GetDataBoxEdgeDeviceJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceJobStatusResource GetDataBoxEdgeDeviceJobStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource GetDataBoxEdgeDeviceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceCollection GetDataBoxEdgeDevices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> GetDataBoxEdgeDevices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.DataBoxEdgeDeviceResource> GetDataBoxEdgeDevicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DeviceCapacityInfoResource GetDeviceCapacityInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource GetDiagnosticProactiveLogCollectionSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource GetDiagnosticRemoteSupportSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource GetMonitoringMetricConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.NetworkSettingResource GetNetworkSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.OrderResource GetOrderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.RoleResource GetRoleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.ShareResource GetShareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource GetStorageAccountCredentialResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.StorageAccountResource GetStorageAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.TriggerResource GetTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.UpdateSummaryResource GetUpdateSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.UserResource GetUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DeviceCapacityInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public DeviceCapacityInfoData() { }
        public Azure.ResourceManager.DataBoxEdge.Models.ClusterCapacityViewData ClusterComputeCapacityInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.ClusterStorageViewData ClusterStorageCapacityInfo { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBoxEdge.Models.HostCapacity> NodeCapacityInfos { get { throw null; } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } set { } }
    }
    public partial class DeviceCapacityInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceCapacityInfoResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DeviceCapacityInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DeviceCapacityInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DeviceCapacityInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticProactiveLogCollectionSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticProactiveLogCollectionSettingData(Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent userConsent) { }
        public Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent UserConsent { get { throw null; } set { } }
    }
    public partial class DiagnosticProactiveLogCollectionSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiagnosticProactiveLogCollectionSettingResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DiagnosticProactiveLogCollectionSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticRemoteSupportSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticRemoteSupportSettingData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.RemoteSupportSettings> RemoteSupportSettingsList { get { throw null; } }
    }
    public partial class DiagnosticRemoteSupportSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiagnosticRemoteSupportSettingResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.DiagnosticRemoteSupportSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobData : Azure.ResourceManager.Models.ResourceData
    {
        internal JobData() { }
        public Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage? CurrentStage { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.UpdateDownloadProgress DownloadProgress { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.JobErrorDetails Error { get { throw null; } }
        public string ErrorManifestFile { get { throw null; } }
        public string Folder { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.UpdateInstallProgress InstallProgress { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.JobType? JobType { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string RefreshedEntityId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.JobStatus? Status { get { throw null; } }
        public int? TotalRefreshErrors { get { throw null; } }
    }
    public partial class MonitoringMetricConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public MonitoringMetricConfigurationData(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.Models.MetricConfiguration> metricConfigurations) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.MetricConfiguration> MetricConfigurations { get { throw null; } }
    }
    public partial class MonitoringMetricConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitoringMetricConfigurationResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string roleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public NetworkSettingData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapter> NetworkAdapters { get { throw null; } }
    }
    public partial class NetworkSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkSettingResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.NetworkSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.NetworkSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.NetworkSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrderData : Azure.ResourceManager.Models.ResourceData
    {
        public OrderData() { }
        public Azure.ResourceManager.DataBoxEdge.Models.ContactDetails ContactInformation { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.OrderStatus CurrentStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.TrackingInfo> DeliveryTrackingInfo { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.OrderStatus> OrderHistory { get { throw null; } }
        public string OrderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.TrackingInfo> ReturnTrackingInfo { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.ShipmentType? ShipmentType { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.Address ShippingAddress { get { throw null; } set { } }
    }
    public partial class OrderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrderResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.OrderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.OrderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.OrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.OrderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.OrderData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.OrderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.OrderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DCAccessCode> GetDCAccessCode(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.Models.DCAccessCode>> GetDCAccessCodeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.RoleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.RoleResource>, System.Collections.IEnumerable
    {
        protected RoleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.RoleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.RoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.RoleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.RoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.RoleResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.RoleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.RoleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.RoleResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.RoleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.RoleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.RoleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.RoleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleData : Azure.ResourceManager.Models.ResourceData
    {
        public RoleData() { }
    }
    public partial class RoleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.RoleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.RoleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.AddonResource> GetAddon(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.AddonResource>> GetAddonAsync(string addonName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.AddonCollection GetAddons() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.RoleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.MonitoringMetricConfigurationResource GetMonitoringMetricConfiguration() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.RoleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.RoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.RoleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.RoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ShareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.ShareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.ShareResource>, System.Collections.IEnumerable
    {
        protected ShareCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.ShareResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.ShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.ShareResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.ShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.ShareResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.ShareResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.ShareResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.ShareResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.ShareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.ShareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.ShareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.ShareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ShareData : Azure.ResourceManager.Models.ResourceData
    {
        public ShareData(Azure.ResourceManager.DataBoxEdge.Models.ShareStatus shareStatus, Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus monitoringStatus, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol accessProtocol) { }
        public Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol AccessProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.AzureContainerInfo AzureContainerInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.ClientAccessRight> ClientAccessRights { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataPolicy? DataPolicy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.RefreshDetails RefreshDetails { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.MountPointMap> ShareMappings { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.ShareStatus ShareStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.UserAccessRight> UserAccessRights { get { throw null; } }
    }
    public partial class ShareResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ShareResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.ShareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.ShareResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.ShareResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Refresh(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.ShareResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.ShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.ShareResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.ShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.StorageAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.StorageAccountResource>, System.Collections.IEnumerable
    {
        protected StorageAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.StorageAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageAccountName, Azure.ResourceManager.DataBoxEdge.StorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.StorageAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageAccountName, Azure.ResourceManager.DataBoxEdge.StorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountResource> Get(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.StorageAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.StorageAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountResource>> GetAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.StorageAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.StorageAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.StorageAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.StorageAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageAccountCredentialCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource>, System.Collections.IEnumerable
    {
        protected StorageAccountCredentialCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageAccountCredentialData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageAccountCredentialData(string alias, Azure.ResourceManager.DataBoxEdge.Models.SSLStatus sslStatus, Azure.ResourceManager.DataBoxEdge.Models.AccountType accountType) { }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret AccountKey { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.AccountType AccountType { get { throw null; } set { } }
        public string Alias { get { throw null; } set { } }
        public string BlobDomainName { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.SSLStatus SslStatus { get { throw null; } set { } }
        public string StorageAccountId { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class StorageAccountCredentialResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageAccountCredentialResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.StorageAccountCredentialData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageAccountData(Azure.ResourceManager.DataBoxEdge.Models.DataPolicy dataPolicy) { }
        public string BlobEndpoint { get { throw null; } }
        public int? ContainerCount { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataPolicy DataPolicy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string StorageAccountCredentialId { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus? StorageAccountStatus { get { throw null; } set { } }
    }
    public partial class StorageAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageAccountResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.StorageAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string storageAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.StorageAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.ContainerResource> GetContainer(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.ContainerResource>> GetContainerAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataBoxEdge.ContainerCollection GetContainers() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.StorageAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.StorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.StorageAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.StorageAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.TriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.TriggerResource>, System.Collections.IEnumerable
    {
        protected TriggerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.TriggerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.TriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.TriggerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.TriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.TriggerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.TriggerResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.TriggerResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.TriggerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.TriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.TriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.TriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.TriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TriggerData : Azure.ResourceManager.Models.ResourceData
    {
        public TriggerData() { }
    }
    public partial class TriggerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TriggerResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.TriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.TriggerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.TriggerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.TriggerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.TriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.TriggerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.TriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UpdateSummaryData : Azure.ResourceManager.Models.ResourceData
    {
        public UpdateSummaryData() { }
        public System.DateTimeOffset? DeviceLastScannedOn { get { throw null; } set { } }
        public string DeviceVersionNumber { get { throw null; } set { } }
        public string FriendlyDeviceVersionName { get { throw null; } set { } }
        public string InProgressDownloadJobId { get { throw null; } }
        public System.DateTimeOffset? InProgressDownloadJobStartedOn { get { throw null; } }
        public string InProgressInstallJobId { get { throw null; } }
        public System.DateTimeOffset? InProgressInstallJobStartedOn { get { throw null; } }
        public string LastCompletedDownloadJobId { get { throw null; } }
        public System.DateTimeOffset? LastCompletedDownloadJobOn { get { throw null; } }
        public string LastCompletedInstallJobId { get { throw null; } }
        public System.DateTimeOffset? LastCompletedInstallJobOn { get { throw null; } }
        public System.DateTimeOffset? LastCompletedScanJobOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.JobStatus? LastDownloadJobStatus { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.JobStatus? LastInstallJobStatus { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulInstallJobOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastSuccessfulScanJobOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation? OngoingUpdateOperation { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior? RebootBehavior { get { throw null; } }
        public int? TotalNumberOfUpdatesAvailable { get { throw null; } }
        public int? TotalNumberOfUpdatesPendingDownload { get { throw null; } }
        public int? TotalNumberOfUpdatesPendingInstall { get { throw null; } }
        public int? TotalTimeInMinutes { get { throw null; } }
        public double? TotalUpdateSizeInBytes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.UpdateDetails> Updates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> UpdateTitles { get { throw null; } }
    }
    public partial class UpdateSummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UpdateSummaryResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.UpdateSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.UpdateSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.UpdateSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.UserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.UserResource>, System.Collections.IEnumerable
    {
        protected UserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.UserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.UserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DataBoxEdge.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.UserResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataBoxEdge.UserResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataBoxEdge.UserResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.UserResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataBoxEdge.UserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataBoxEdge.UserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataBoxEdge.UserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.UserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UserData : Azure.ResourceManager.Models.ResourceData
    {
        public UserData(Azure.ResourceManager.DataBoxEdge.Models.UserType userType) { }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret EncryptedPassword { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.ShareAccessRight> ShareAccessRights { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.UserType UserType { get { throw null; } set { } }
    }
    public partial class UserResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UserResource() { }
        public virtual Azure.ResourceManager.DataBoxEdge.UserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deviceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataBoxEdge.UserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataBoxEdge.UserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.UserResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataBoxEdge.UserResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataBoxEdge.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataBoxEdge.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessLevel : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.AccessLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessLevel(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.AccessLevel FullAccess { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AccessLevel None { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AccessLevel ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AccessLevel ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.AccessLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.AccessLevel left, Azure.ResourceManager.DataBoxEdge.Models.AccessLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.AccessLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.AccessLevel left, Azure.ResourceManager.DataBoxEdge.Models.AccessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccountType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.AccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccountType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.AccountType BlobStorage { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AccountType GeneralPurposeStorage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.AccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.AccountType left, Azure.ResourceManager.DataBoxEdge.Models.AccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.AccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.AccountType left, Azure.ResourceManager.DataBoxEdge.Models.AccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AddonState : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.AddonState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AddonState(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.AddonState Created { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AddonState Creating { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AddonState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AddonState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AddonState Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AddonState Reconfiguring { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AddonState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.AddonState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.AddonState left, Azure.ResourceManager.DataBoxEdge.Models.AddonState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.AddonState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.AddonState left, Azure.ResourceManager.DataBoxEdge.Models.AddonState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Address
    {
        public Address(string country) { }
        public string AddressLine1 { get { throw null; } set { } }
        public string AddressLine2 { get { throw null; } set { } }
        public string AddressLine3 { get { throw null; } set { } }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
    public partial class AlertErrorDetails
    {
        internal AlertErrorDetails() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int? Occurrences { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertSeverity : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity Critical { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity left, Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity left, Azure.ResourceManager.DataBoxEdge.Models.AlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArcAddon : Azure.ResourceManager.DataBoxEdge.AddonData
    {
        public ArcAddon(string subscriptionId, string resourceGroupName, string resourceName, string resourceLocation) { }
        public Azure.ResourceManager.DataBoxEdge.Models.PlatformType? HostPlatform { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType? HostPlatformType { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.AddonState? ProvisioningState { get { throw null; } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string ResourceLocation { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class AsymmetricEncryptedSecret
    {
        public AsymmetricEncryptedSecret(string value, Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm encryptionAlgorithm) { }
        public Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm EncryptionAlgorithm { get { throw null; } set { } }
        public string EncryptionCertThumbprint { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType AzureActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType left, Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType left, Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailableDataBoxEdgeSku
    {
        internal AvailableDataBoxEdgeSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.SkuAvailability? Availability { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.SkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.SkuCost> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.SkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName? Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.ShipmentType> ShipmentTypes { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.SkuSignupOption? SignupOption { get { throw null; } }
        public string Size { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier? Tier { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.SkuVersion? Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureContainerDataFormat : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureContainerDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat AzureFile { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat BlockBlob { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat PageBlob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat left, Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat left, Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureContainerInfo
    {
        public AzureContainerInfo(string storageAccountCredentialId, string containerName, Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat dataFormat) { }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.AzureContainerDataFormat DataFormat { get { throw null; } set { } }
        public string StorageAccountCredentialId { get { throw null; } set { } }
    }
    public partial class ClientAccessRight
    {
        public ClientAccessRight(string client, Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType accessPermission) { }
        public Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType AccessPermission { get { throw null; } set { } }
        public string Client { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientPermissionType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientPermissionType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType NoAccess { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType left, Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType left, Azure.ResourceManager.DataBoxEdge.Models.ClientPermissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudEdgeManagementRole : Azure.ResourceManager.DataBoxEdge.RoleData
    {
        public CloudEdgeManagementRole() { }
        public Azure.ResourceManager.DataBoxEdge.Models.EdgeProfileSubscription EdgeSubscription { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.RoleStatus? LocalManagementStatus { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.RoleStatus? RoleStatus { get { throw null; } set { } }
    }
    public partial class ClusterCapacityViewData
    {
        public ClusterCapacityViewData() { }
        public string Fqdn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.ClusterGpuCapacity GpuCapacity { get { throw null; } set { } }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.ClusterMemoryCapacity MemoryCapacity { get { throw null; } set { } }
        public long? TotalProvisionedNonHpnCores { get { throw null; } set { } }
    }
    public partial class ClusterGpuCapacity
    {
        public ClusterGpuCapacity() { }
        public int? GpuFreeUnitsCount { get { throw null; } set { } }
        public int? GpuReservedForFailoverUnitsCount { get { throw null; } set { } }
        public int? GpuTotalUnitsCount { get { throw null; } set { } }
        public string GpuType { get { throw null; } set { } }
        public int? GpuUsedUnitsCount { get { throw null; } set { } }
    }
    public partial class ClusterMemoryCapacity
    {
        public ClusterMemoryCapacity() { }
        public double? ClusterFailoverMemoryMb { get { throw null; } set { } }
        public double? ClusterFragmentationMemoryMb { get { throw null; } set { } }
        public double? ClusterFreeMemoryMb { get { throw null; } set { } }
        public double? ClusterHyperVReserveMemoryMb { get { throw null; } set { } }
        public double? ClusterInfraVmMemoryMb { get { throw null; } set { } }
        public double? ClusterMemoryUsedByVmsMb { get { throw null; } set { } }
        public double? ClusterNonFailoverVmMb { get { throw null; } set { } }
        public double? ClusterTotalMemoryMb { get { throw null; } set { } }
        public double? ClusterUsedMemoryMb { get { throw null; } set { } }
    }
    public partial class ClusterStorageViewData
    {
        public ClusterStorageViewData() { }
        public double? ClusterFreeStorageMb { get { throw null; } set { } }
        public double? ClusterTotalStorageMb { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterWitnessType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterWitnessType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType Cloud { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType FileShare { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType left, Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType left, Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CniConfig
    {
        internal CniConfig() { }
        public string CniConfigType { get { throw null; } }
        public string PodSubnet { get { throw null; } }
        public string ServiceSubnet { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ComputeResource
    {
        public ComputeResource(int processorCount, long memoryInGB) { }
        public long MemoryInGB { get { throw null; } set { } }
        public int ProcessorCount { get { throw null; } set { } }
    }
    public partial class ContactDetails
    {
        public ContactDetails(string contactPerson, string companyName, string phone, System.Collections.Generic.IEnumerable<string> emailList) { }
        public string CompanyName { get { throw null; } set { } }
        public string ContactPerson { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailList { get { throw null; } }
        public string Phone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus OK { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus left, Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus left, Azure.ResourceManager.DataBoxEdge.Models.ContainerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeDeviceExtendedInfo : Azure.ResourceManager.Models.ResourceData
    {
        public DataBoxEdgeDeviceExtendedInfo() { }
        public string ChannelIntegrityKeyName { get { throw null; } set { } }
        public string ChannelIntegrityKeyVersion { get { throw null; } set { } }
        public string ClientSecretStoreId { get { throw null; } set { } }
        public System.Uri ClientSecretStoreUri { get { throw null; } set { } }
        public string CloudWitnessContainerName { get { throw null; } }
        public string CloudWitnessStorageAccountName { get { throw null; } }
        public string CloudWitnessStorageEndpoint { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.ClusterWitnessType? ClusterWitnessType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.DataBoxEdge.Models.Secret> DeviceSecrets { get { throw null; } }
        public string EncryptionKey { get { throw null; } set { } }
        public string EncryptionKeyThumbprint { get { throw null; } set { } }
        public string FileShareWitnessLocation { get { throw null; } }
        public string FileShareWitnessUsername { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus? KeyVaultSyncStatus { get { throw null; } set { } }
        public string ResourceKey { get { throw null; } }
    }
    public partial class DataBoxEdgeDeviceExtendedInfoPatch
    {
        public DataBoxEdgeDeviceExtendedInfoPatch() { }
        public string ChannelIntegrityKeyName { get { throw null; } set { } }
        public string ChannelIntegrityKeyVersion { get { throw null; } set { } }
        public string ClientSecretStoreId { get { throw null; } set { } }
        public System.Uri ClientSecretStoreUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus? SyncStatus { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeDeviceKind : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeDeviceKind(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind AzureDataBoxGateway { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind AzureModularDataCentre { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind AzureStackEdge { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind AzureStackHub { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeDevicePatch
    {
        public DataBoxEdgeDevicePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubscriptionId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeDeviceStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeDeviceStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus Maintenance { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus Online { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus PartiallyDisconnected { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus ReadyToSetup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeDeviceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoxEdgeSku
    {
        public DataBoxEdgeSku() { }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeSkuName : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeSkuName(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Edge { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgeMRMini { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgeMRTCP { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgePBase { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgePHigh { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgePRBase { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EdgePRBaseUPS { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP21281T4Mx1W { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP2128GPU1Mx1W { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP22562T4W { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP2256GPU2Mx1 { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP2641VpuW { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName EP264Mx1W { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Gateway { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName GPU { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName Management { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName RCALarge { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName RCASmall { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName RDC { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TCALarge { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TCASmall { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TDC { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TEA1Node { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TEA1NodeHeater { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TEA1NodeUPS { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TEA1NodeUPSHeater { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TEA4NodeHeater { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TEA4NodeUPSHeater { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName TMA { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoxEdgeSkuTier : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoxEdgeSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier left, Azure.ResourceManager.DataBoxEdge.Models.DataBoxEdgeSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataPolicy : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataPolicy(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataPolicy Cloud { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataPolicy Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataPolicy left, Azure.ResourceManager.DataBoxEdge.Models.DataPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataPolicy left, Azure.ResourceManager.DataBoxEdge.Models.DataPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataResidencyType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DataResidencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataResidencyType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataResidencyType GeoZoneReplication { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DataResidencyType ZoneReplication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DataResidencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DataResidencyType left, Azure.ResourceManager.DataBoxEdge.Models.DataResidencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DataResidencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DataResidencyType left, Azure.ResourceManager.DataBoxEdge.Models.DataResidencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DayOfWeek : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek left, Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek left, Azure.ResourceManager.DataBoxEdge.Models.DayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DCAccessCode
    {
        internal DCAccessCode() { }
        public string AuthCode { get { throw null; } }
    }
    public partial class DeviceCapacityRequestContent
    {
        public DeviceCapacityRequestContent(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> vmPlacementQuery) { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> VmPlacementQuery { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.VmPlacementRequestResult> VmPlacementResults { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DeviceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DeviceType DataBoxEdgeDevice { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DeviceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DeviceType left, Azure.ResourceManager.DataBoxEdge.Models.DeviceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DeviceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DeviceType left, Azure.ResourceManager.DataBoxEdge.Models.DeviceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DownloadPhase : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DownloadPhase(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase Downloading { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase Initializing { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase Verifying { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase left, Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase left, Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeProfileSubscription
    {
        internal EdgeProfileSubscription() { }
        public string Id { get { throw null; } }
        public string LocationPlacementId { get { throw null; } }
        public string QuotaId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.SubscriptionRegisteredFeatures> RegisteredFeatures { get { throw null; } }
        public string RegistrationDate { get { throw null; } }
        public string RegistrationId { get { throw null; } }
        public string SerializedDetails { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState? State { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionAlgorithm : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm AES256 { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm None { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm RsaesPkcs1V15 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm left, Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm left, Azure.ResourceManager.DataBoxEdge.Models.EncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EtcdInfo
    {
        internal EtcdInfo() { }
        public string EtcdInfoType { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class FileEventTrigger : Azure.ResourceManager.DataBoxEdge.TriggerData
    {
        public FileEventTrigger(Azure.ResourceManager.DataBoxEdge.Models.FileSourceInfo sourceInfo, Azure.ResourceManager.DataBoxEdge.Models.RoleSinkInfo sinkInfo) { }
        public string CustomContextTag { get { throw null; } set { } }
        public string SinkInfoRoleId { get { throw null; } set { } }
        public string SourceInfoShareId { get { throw null; } set { } }
    }
    public partial class FileSourceInfo
    {
        public FileSourceInfo(string shareId) { }
        public string ShareId { get { throw null; } set { } }
    }
    public partial class GenerateCertResponse
    {
        internal GenerateCertResponse() { }
        public string ExpiryTimeInUTC { get { throw null; } }
        public string PrivateKey { get { throw null; } }
        public string PublicKey { get { throw null; } }
    }
    public partial class HostCapacity
    {
        public HostCapacity() { }
        public int? AvailableGpuCount { get { throw null; } set { } }
        public long? EffectiveAvailableMemoryMbOnHost { get { throw null; } set { } }
        public string GpuType { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.NumaNodeData> NumaNodesData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.DataBoxEdge.Models.VmMemory> VmUsedMemory { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostPlatformType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostPlatformType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType KubernetesCluster { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType LinuxVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType left, Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType left, Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageRepositoryCredential
    {
        public ImageRepositoryCredential(System.Uri imageRepositoryUri, string userName) { }
        public System.Uri ImageRepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstallationImpact : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstallationImpact(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact DeviceRebooted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact KubernetesWorkloadsDown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact left, Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact left, Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstallRebootBehavior : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstallRebootBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior NeverReboots { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior RequestReboot { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior RequiresReboot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior left, Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior left, Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTAddon : Azure.ResourceManager.DataBoxEdge.AddonData
    {
        public IoTAddon(Azure.ResourceManager.DataBoxEdge.Models.IoTDeviceInfo ioTDeviceDetails, Azure.ResourceManager.DataBoxEdge.Models.IoTDeviceInfo ioTEdgeDeviceDetails) { }
        public Azure.ResourceManager.DataBoxEdge.Models.PlatformType? HostPlatform { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType? HostPlatformType { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.IoTDeviceInfo IoTDeviceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.IoTDeviceInfo IoTEdgeDeviceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.AddonState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class IoTDeviceInfo
    {
        public IoTDeviceInfo(string deviceId, string ioTHostHub) { }
        public string DeviceId { get { throw null; } set { } }
        public string IoTHostHub { get { throw null; } set { } }
        public string IoTHostHubId { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret SymmetricKeyConnectionString { get { throw null; } set { } }
    }
    public partial class IoTEdgeAgentInfo
    {
        public IoTEdgeAgentInfo(string imageName, string tag) { }
        public string ImageName { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.ImageRepositoryCredential ImageRepository { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class IoTRole : Azure.ResourceManager.DataBoxEdge.RoleData
    {
        public IoTRole() { }
        public Azure.ResourceManager.DataBoxEdge.Models.ComputeResource ComputeResource { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.PlatformType? HostPlatform { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType? HostPlatformType { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.IoTDeviceInfo IoTDeviceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.IoTEdgeAgentInfo IoTEdgeAgentInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.IoTDeviceInfo IoTEdgeDeviceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.RoleStatus? RoleStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.MountPointMap> ShareMappings { get { throw null; } }
    }
    public partial class IPv4Config
    {
        internal IPv4Config() { }
        public string Gateway { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public string Subnet { get { throw null; } }
    }
    public partial class IPv6Config
    {
        internal IPv6Config() { }
        public string Gateway { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public int? PrefixLength { get { throw null; } }
    }
    public partial class JobErrorDetails
    {
        internal JobErrorDetails() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.JobErrorItem> ErrorDetails { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class JobErrorItem
    {
        internal JobErrorItem() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.JobStatus left, Azure.ResourceManager.DataBoxEdge.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.JobStatus left, Azure.ResourceManager.DataBoxEdge.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.JobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobType Backup { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobType DownloadUpdates { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobType InstallUpdates { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobType Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobType RefreshContainer { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobType RefreshShare { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobType Restore { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobType ScanForUpdates { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.JobType TriggerSupportPackage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.JobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.JobType left, Azure.ResourceManager.DataBoxEdge.Models.JobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.JobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.JobType left, Azure.ResourceManager.DataBoxEdge.Models.JobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyVaultSyncStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyVaultSyncStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus KeyVaultNotConfigured { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus KeyVaultNotSynced { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus KeyVaultSynced { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus KeyVaultSyncFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus KeyVaultSyncing { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus KeyVaultSyncPending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus left, Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus left, Azure.ResourceManager.DataBoxEdge.Models.KeyVaultSyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesClusterInfo
    {
        public KubernetesClusterInfo(string version) { }
        public Azure.ResourceManager.DataBoxEdge.Models.EtcdInfo EtcdInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.NodeInfo> Nodes { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class KubernetesIPConfiguration
    {
        internal KubernetesIPConfiguration() { }
        public string IPAddress { get { throw null; } }
        public string Port { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesNodeType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesNodeType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType Master { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType Worker { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType left, Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType left, Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesRole : Azure.ResourceManager.DataBoxEdge.RoleData
    {
        public KubernetesRole() { }
        public Azure.ResourceManager.DataBoxEdge.Models.PlatformType? HostPlatform { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.HostPlatformType? HostPlatformType { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.KubernetesClusterInfo KubernetesClusterInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.KubernetesRoleResources KubernetesRoleResources { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.KubernetesState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.RoleStatus? RoleStatus { get { throw null; } set { } }
    }
    public partial class KubernetesRoleCompute
    {
        public KubernetesRoleCompute(string vmProfile) { }
        public long? MemoryInBytes { get { throw null; } }
        public int? ProcessorCount { get { throw null; } }
        public string VmProfile { get { throw null; } set { } }
    }
    public partial class KubernetesRoleNetwork
    {
        internal KubernetesRoleNetwork() { }
        public Azure.ResourceManager.DataBoxEdge.Models.CniConfig CniConfig { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.LoadBalancerConfig LoadBalancerConfig { get { throw null; } }
    }
    public partial class KubernetesRoleResources
    {
        public KubernetesRoleResources(Azure.ResourceManager.DataBoxEdge.Models.KubernetesRoleCompute compute) { }
        public Azure.ResourceManager.DataBoxEdge.Models.KubernetesRoleCompute Compute { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.KubernetesRoleNetwork Network { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.KubernetesRoleStorage Storage { get { throw null; } set { } }
    }
    public partial class KubernetesRoleStorage
    {
        public KubernetesRoleStorage() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.MountPointMap> Endpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.KubernetesRoleStorageClassInfo> StorageClasses { get { throw null; } }
    }
    public partial class KubernetesRoleStorageClassInfo
    {
        internal KubernetesRoleStorageClassInfo() { }
        public string KubernetesRoleStorageClassInfoType { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus? PosixCompliant { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesState : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.KubernetesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesState(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.KubernetesState Created { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KubernetesState Creating { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KubernetesState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KubernetesState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KubernetesState Invalid { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KubernetesState Reconfiguring { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.KubernetesState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.KubernetesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.KubernetesState left, Azure.ResourceManager.DataBoxEdge.Models.KubernetesState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.KubernetesState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.KubernetesState left, Azure.ResourceManager.DataBoxEdge.Models.KubernetesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadBalancerConfig
    {
        internal LoadBalancerConfig() { }
        public string LoadBalancerConfigType { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class MECRole : Azure.ResourceManager.DataBoxEdge.RoleData
    {
        public MECRole() { }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret ConnectionString { get { throw null; } set { } }
        public string ControllerEndpoint { get { throw null; } set { } }
        public string ResourceUniqueId { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.RoleStatus? RoleStatus { get { throw null; } set { } }
    }
    public partial class MetricConfiguration
    {
        public MetricConfiguration(string resourceId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.Models.MetricCounterSet> counterSets) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.MetricCounterSet> CounterSets { get { throw null; } }
        public string MdmAccount { get { throw null; } set { } }
        public string MetricNameSpace { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class MetricCounter
    {
        public MetricCounter(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.MetricDimension> AdditionalDimensions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.MetricDimension> DimensionFilter { get { throw null; } }
        public string Instance { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MetricCounterSet
    {
        public MetricCounterSet(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataBoxEdge.Models.MetricCounter> counters) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataBoxEdge.Models.MetricCounter> Counters { get { throw null; } }
    }
    public partial class MetricDimension
    {
        public MetricDimension(string sourceType, string sourceName) { }
        public string SourceName { get { throw null; } set { } }
        public string SourceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus left, Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus left, Azure.ResourceManager.DataBoxEdge.Models.MonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MountPointMap
    {
        public MountPointMap(string shareId) { }
        public string MountPoint { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.MountType? MountType { get { throw null; } }
        public string RoleId { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.RoleType? RoleType { get { throw null; } }
        public string ShareId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MountType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.MountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MountType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.MountType HostPath { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.MountType Volume { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.MountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.MountType left, Azure.ResourceManager.DataBoxEdge.Models.MountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.MountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.MountType left, Azure.ResourceManager.DataBoxEdge.Models.MountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkAdapter
    {
        internal NetworkAdapter() { }
        public string AdapterId { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterPosition AdapterPosition { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterDhcpStatus? DhcpStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DnsServers { get { throw null; } }
        public int? Index { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.IPv4Config IPv4Configuration { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.IPv6Config IPv6Configuration { get { throw null; } }
        public string IPv6LinkLocalAddress { get { throw null; } }
        public string Label { get { throw null; } }
        public long? LinkSpeed { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string NetworkAdapterName { get { throw null; } }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterRdmaStatus? RdmaStatus { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkAdapterDhcpStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterDhcpStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkAdapterDhcpStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterDhcpStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterDhcpStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterDhcpStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterDhcpStatus left, Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterDhcpStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterDhcpStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterDhcpStatus left, Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterDhcpStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkAdapterPosition
    {
        internal NetworkAdapterPosition() { }
        public Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup? NetworkGroup { get { throw null; } }
        public int? Port { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkAdapterRdmaStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterRdmaStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkAdapterRdmaStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterRdmaStatus Capable { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterRdmaStatus Incapable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterRdmaStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterRdmaStatus left, Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterRdmaStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterRdmaStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterRdmaStatus left, Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterRdmaStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkAdapterStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkAdapterStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterStatus Active { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterStatus Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterStatus left, Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterStatus left, Azure.ResourceManager.DataBoxEdge.Models.NetworkAdapterStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkGroup : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkGroup(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup None { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup NonRdma { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup Rdma { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup left, Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup left, Azure.ResourceManager.DataBoxEdge.Models.NetworkGroup right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Node : Azure.ResourceManager.Models.ResourceData
    {
        public Node() { }
        public string NodeChassisSerialNumber { get { throw null; } }
        public string NodeDisplayName { get { throw null; } }
        public string NodeFriendlySoftwareVersion { get { throw null; } }
        public string NodeHcsVersion { get { throw null; } }
        public string NodeInstanceId { get { throw null; } }
        public string NodeSerialNumber { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.NodeStatus? NodeStatus { get { throw null; } }
    }
    public partial class NodeInfo
    {
        internal NodeInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataBoxEdge.Models.KubernetesIPConfiguration> IPConfiguration { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.KubernetesNodeType? KubernetesNodeType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.NodeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.NodeStatus Down { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.NodeStatus Rebooting { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.NodeStatus ShuttingDown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.NodeStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.NodeStatus Up { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.NodeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.NodeStatus left, Azure.ResourceManager.DataBoxEdge.Models.NodeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.NodeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.NodeStatus left, Azure.ResourceManager.DataBoxEdge.Models.NodeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NumaNodeData
    {
        public NumaNodeData() { }
        public long? EffectiveAvailableMemoryInMb { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> FreeVCpuIndexesForHpn { get { throw null; } }
        public int? LogicalCoreCountPerCore { get { throw null; } set { } }
        public int? NumaNodeIndex { get { throw null; } set { } }
        public long? TotalMemoryInMb { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> VCpuIndexesForHpn { get { throw null; } }
        public System.Collections.Generic.IList<int> VCpuIndexesForRoot { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrderState : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.OrderState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrderState(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState Arriving { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState AwaitingDrop { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState AwaitingFulfillment { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState AwaitingPickup { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState AwaitingPreparation { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState AwaitingReturnShipment { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState AwaitingShipment { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState CollectedAtMicrosoft { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState Declined { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState Delivered { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState LostDevice { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState PickupCompleted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState ReplacementRequested { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState ReturnInitiated { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState Shipped { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState ShippedBack { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.OrderState Untracked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.OrderState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.OrderState left, Azure.ResourceManager.DataBoxEdge.Models.OrderState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.OrderState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.OrderState left, Azure.ResourceManager.DataBoxEdge.Models.OrderState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OrderStatus
    {
        internal OrderStatus() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalOrderDetails { get { throw null; } }
        public string Comments { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.OrderState Status { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.TrackingInfo TrackingInformation { get { throw null; } }
        public System.DateTimeOffset? UpdateOn { get { throw null; } }
    }
    public partial class PeriodicTimerEventTrigger : Azure.ResourceManager.DataBoxEdge.TriggerData
    {
        public PeriodicTimerEventTrigger(Azure.ResourceManager.DataBoxEdge.Models.PeriodicTimerSourceInfo sourceInfo, Azure.ResourceManager.DataBoxEdge.Models.RoleSinkInfo sinkInfo) { }
        public string CustomContextTag { get { throw null; } set { } }
        public string SinkInfoRoleId { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.PeriodicTimerSourceInfo SourceInfo { get { throw null; } set { } }
    }
    public partial class PeriodicTimerSourceInfo
    {
        public PeriodicTimerSourceInfo(System.DateTimeOffset startOn, string schedule) { }
        public string Schedule { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public string Topic { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlatformType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.PlatformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlatformType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.PlatformType Linux { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.PlatformType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.PlatformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.PlatformType left, Azure.ResourceManager.DataBoxEdge.Models.PlatformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.PlatformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.PlatformType left, Azure.ResourceManager.DataBoxEdge.Models.PlatformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PosixComplianceStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PosixComplianceStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus left, Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus left, Azure.ResourceManager.DataBoxEdge.Models.PosixComplianceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProactiveDiagnosticsConsent : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProactiveDiagnosticsConsent(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent left, Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent left, Azure.ResourceManager.DataBoxEdge.Models.ProactiveDiagnosticsConsent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RefreshDetails
    {
        public RefreshDetails() { }
        public string ErrorManifestFile { get { throw null; } set { } }
        public string InProgressRefreshJobId { get { throw null; } set { } }
        public System.DateTimeOffset? LastCompletedRefreshJobTimeInUTC { get { throw null; } set { } }
        public string LastJob { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteApplicationType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType AllApplications { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType LocalUI { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType Powershell { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType WAC { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType left, Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType left, Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoteSupportSettings
    {
        public RemoteSupportSettings() { }
        public Azure.ResourceManager.DataBoxEdge.Models.AccessLevel? AccessLevel { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationTimeStampInUTC { get { throw null; } set { } }
        public Azure.ResourceManager.DataBoxEdge.Models.RemoteApplicationType? RemoteApplicationType { get { throw null; } set { } }
    }
    public partial class ResourceMoveDetails
    {
        internal ResourceMoveDetails() { }
        public Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus? OperationInProgress { get { throw null; } }
        public System.DateTimeOffset? OperationInProgressLockTimeoutInUTC { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceMoveStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceMoveStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus None { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus ResourceMoveFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus ResourceMoveInProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus left, Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus left, Azure.ResourceManager.DataBoxEdge.Models.ResourceMoveStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleSinkInfo
    {
        public RoleSinkInfo(string roleId) { }
        public string RoleId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.RoleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.RoleStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.RoleStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.RoleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.RoleStatus left, Azure.ResourceManager.DataBoxEdge.Models.RoleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.RoleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.RoleStatus left, Azure.ResourceManager.DataBoxEdge.Models.RoleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.RoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.RoleType ASA { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.RoleType CloudEdgeManagement { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.RoleType Cognitive { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.RoleType Functions { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.RoleType IOT { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.RoleType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.RoleType MEC { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.RoleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.RoleType left, Azure.ResourceManager.DataBoxEdge.Models.RoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.RoleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.RoleType left, Azure.ResourceManager.DataBoxEdge.Models.RoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Secret
    {
        internal Secret() { }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret EncryptedSecret { get { throw null; } }
        public string KeyVaultId { get { throw null; } }
    }
    public partial class SecuritySettings : Azure.ResourceManager.Models.ResourceData
    {
        public SecuritySettings(Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret deviceAdminPassword) { }
        public Azure.ResourceManager.DataBoxEdge.Models.AsymmetricEncryptedSecret DeviceAdminPassword { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareAccessProtocol : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareAccessProtocol(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol NFS { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol SMB { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol left, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol left, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareAccessRight
    {
        internal ShareAccessRight() { }
        public Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType AccessType { get { throw null; } }
        public string ShareId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareAccessType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareAccessType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType Change { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType Custom { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType Read { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType left, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType left, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ShareStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareStatus NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareStatus OK { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShareStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ShareStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ShareStatus left, Azure.ResourceManager.DataBoxEdge.Models.ShareStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ShareStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ShareStatus left, Azure.ResourceManager.DataBoxEdge.Models.ShareStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShipmentType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.ShipmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShipmentType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShipmentType NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShipmentType SelfPickup { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.ShipmentType ShippedToCustomer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.ShipmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.ShipmentType left, Azure.ResourceManager.DataBoxEdge.Models.ShipmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.ShipmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.ShipmentType left, Azure.ResourceManager.DataBoxEdge.Models.ShipmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuAvailability : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.SkuAvailability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuAvailability(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.SkuAvailability Available { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.SkuAvailability Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.SkuAvailability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.SkuAvailability left, Azure.ResourceManager.DataBoxEdge.Models.SkuAvailability right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.SkuAvailability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.SkuAvailability left, Azure.ResourceManager.DataBoxEdge.Models.SkuAvailability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuCapability
    {
        internal SkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SkuCost
    {
        internal SkuCost() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public long? Quantity { get { throw null; } }
    }
    public partial class SkuLocationInfo
    {
        internal SkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Sites { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuSignupOption : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.SkuSignupOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuSignupOption(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.SkuSignupOption Available { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.SkuSignupOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.SkuSignupOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.SkuSignupOption left, Azure.ResourceManager.DataBoxEdge.Models.SkuSignupOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.SkuSignupOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.SkuSignupOption left, Azure.ResourceManager.DataBoxEdge.Models.SkuSignupOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuVersion : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.SkuVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuVersion(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.SkuVersion Preview { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.SkuVersion Stable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.SkuVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.SkuVersion left, Azure.ResourceManager.DataBoxEdge.Models.SkuVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.SkuVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.SkuVersion left, Azure.ResourceManager.DataBoxEdge.Models.SkuVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SSLStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.SSLStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SSLStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.SSLStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.SSLStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.SSLStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.SSLStatus left, Azure.ResourceManager.DataBoxEdge.Models.SSLStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.SSLStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.SSLStatus left, Azure.ResourceManager.DataBoxEdge.Models.SSLStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus NeedsAttention { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus OK { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus left, Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus left, Azure.ResourceManager.DataBoxEdge.Models.StorageAccountStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionRegisteredFeatures
    {
        internal SubscriptionRegisteredFeatures() { }
        public string Name { get { throw null; } }
        public string State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionState : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionState(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState Registered { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState Suspended { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState left, Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState left, Azure.ResourceManager.DataBoxEdge.Models.SubscriptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrackingInfo
    {
        internal TrackingInfo() { }
        public string CarrierName { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string TrackingId { get { throw null; } }
        public System.Uri TrackingUri { get { throw null; } }
    }
    public partial class TriggerSupportPackageContent : Azure.ResourceManager.Models.ResourceData
    {
        public TriggerSupportPackageContent() { }
        public string Include { get { throw null; } set { } }
        public System.DateTimeOffset? MaximumTimeStamp { get { throw null; } set { } }
        public System.DateTimeOffset? MinimumTimeStamp { get { throw null; } set { } }
    }
    public partial class UpdateDetails
    {
        internal UpdateDetails() { }
        public int? EstimatedInstallTimeInMins { get { throw null; } }
        public string FriendlyVersionNumber { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.InstallationImpact? InstallationImpact { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.InstallRebootBehavior? RebootBehavior { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus? Status { get { throw null; } }
        public string TargetVersion { get { throw null; } }
        public double? UpdateSize { get { throw null; } }
        public string UpdateTitle { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.UpdateType? UpdateType { get { throw null; } }
    }
    public partial class UpdateDownloadProgress
    {
        internal UpdateDownloadProgress() { }
        public Azure.ResourceManager.DataBoxEdge.Models.DownloadPhase? DownloadPhase { get { throw null; } }
        public int? NumberOfUpdatesDownloaded { get { throw null; } }
        public int? NumberOfUpdatesToDownload { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public double? TotalBytesDownloaded { get { throw null; } }
        public double? TotalBytesToDownload { get { throw null; } }
    }
    public partial class UpdateInstallProgress
    {
        internal UpdateInstallProgress() { }
        public int? NumberOfUpdatesInstalled { get { throw null; } }
        public int? NumberOfUpdatesToInstall { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateOperation : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateOperation(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation Download { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation Install { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation None { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation Scan { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation left, Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation left, Azure.ResourceManager.DataBoxEdge.Models.UpdateOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateOperationStage : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateOperationStage(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage DownloadComplete { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage DownloadFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage DownloadStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage Failure { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage Initial { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage InstallComplete { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage InstallFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage InstallStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage RebootInitiated { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage RescanComplete { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage RescanFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage RescanStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage ScanComplete { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage ScanFailed { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage ScanStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage Success { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage left, Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage left, Azure.ResourceManager.DataBoxEdge.Models.UpdateOperationStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateStatus : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus DownloadCompleted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus DownloadPending { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus DownloadStarted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus InstallCompleted { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus InstallStarted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus left, Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus left, Azure.ResourceManager.DataBoxEdge.Models.UpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.UpdateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateType Firmware { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateType Kubernetes { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UpdateType Software { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.UpdateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.UpdateType left, Azure.ResourceManager.DataBoxEdge.Models.UpdateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.UpdateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.UpdateType left, Azure.ResourceManager.DataBoxEdge.Models.UpdateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UploadCertificateContent
    {
        public UploadCertificateContent(string certificate) { }
        public Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType? AuthenticationType { get { throw null; } set { } }
        public string Certificate { get { throw null; } }
    }
    public partial class UploadCertificateResponse
    {
        internal UploadCertificateResponse() { }
        public string AadAudience { get { throw null; } }
        public string AadAuthority { get { throw null; } }
        public string AadTenantId { get { throw null; } }
        public Azure.ResourceManager.DataBoxEdge.Models.AuthenticationType? AuthType { get { throw null; } }
        public string AzureManagementEndpointAudience { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string ServicePrincipalClientId { get { throw null; } }
        public string ServicePrincipalObjectId { get { throw null; } }
    }
    public partial class UserAccessRight
    {
        public UserAccessRight(string userId, Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType accessType) { }
        public Azure.ResourceManager.DataBoxEdge.Models.ShareAccessType AccessType { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserType : System.IEquatable<Azure.ResourceManager.DataBoxEdge.Models.UserType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserType(string value) { throw null; }
        public static Azure.ResourceManager.DataBoxEdge.Models.UserType ARM { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UserType LocalManagement { get { throw null; } }
        public static Azure.ResourceManager.DataBoxEdge.Models.UserType Share { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataBoxEdge.Models.UserType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataBoxEdge.Models.UserType left, Azure.ResourceManager.DataBoxEdge.Models.UserType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataBoxEdge.Models.UserType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataBoxEdge.Models.UserType left, Azure.ResourceManager.DataBoxEdge.Models.UserType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmMemory
    {
        public VmMemory() { }
        public long? CurrentMemoryUsageMB { get { throw null; } set { } }
        public long? StartupMemoryMB { get { throw null; } set { } }
    }
    public partial class VmPlacementRequestResult
    {
        public VmPlacementRequestResult() { }
        public bool? IsFeasible { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string MessageCode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VmSize { get { throw null; } }
    }
}
