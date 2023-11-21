namespace Azure.ResourceManager.EnergyServices
{
    public partial class EnergyServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EnergyServices.EnergyServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EnergyServices.EnergyServiceResource>, System.Collections.IEnumerable
    {
        protected EnergyServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EnergyServices.EnergyServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.EnergyServices.EnergyServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EnergyServices.EnergyServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.EnergyServices.EnergyServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EnergyServices.EnergyServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EnergyServices.EnergyServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EnergyServices.EnergyServiceResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EnergyServices.EnergyServiceResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EnergyServices.EnergyServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EnergyServices.EnergyServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EnergyServices.EnergyServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EnergyServices.EnergyServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EnergyServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EnergyServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.EnergyServices.Models.EnergyServiceProperties Properties { get { throw null; } set { } }
    }
    public partial class EnergyServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EnergyServiceResource() { }
        public virtual Azure.ResourceManager.EnergyServices.EnergyServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EnergyServices.Models.DataPartitionAddOrRemoveContent> AddPartition(Azure.WaitUntil waitUntil, Azure.ResourceManager.EnergyServices.Models.DataPartitionAddOrRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EnergyServices.Models.DataPartitionAddOrRemoveContent>> AddPartitionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EnergyServices.Models.DataPartitionAddOrRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EnergyServices.Models.DataPartitionsListResult> GetPartitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.Models.DataPartitionsListResult>> GetPartitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EnergyServices.Models.DataPartitionAddOrRemoveContent> RemovePartition(Azure.WaitUntil waitUntil, Azure.ResourceManager.EnergyServices.Models.DataPartitionAddOrRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EnergyServices.Models.DataPartitionAddOrRemoveContent>> RemovePartitionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EnergyServices.Models.DataPartitionAddOrRemoveContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource> Update(Azure.ResourceManager.EnergyServices.Models.EnergyServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource>> UpdateAsync(Azure.ResourceManager.EnergyServices.Models.EnergyServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class EnergyServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameAvailabilityResult> CheckNameAvailabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameAvailabilityResult>> CheckNameAvailabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource> GetEnergyService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource>> GetEnergyServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EnergyServices.EnergyServiceResource GetEnergyServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EnergyServices.EnergyServiceCollection GetEnergyServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EnergyServices.EnergyServiceResource> GetEnergyServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EnergyServices.EnergyServiceResource> GetEnergyServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EnergyServices.Mocking
{
    public partial class MockableEnergyServicesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEnergyServicesArmClient() { }
        public virtual Azure.ResourceManager.EnergyServices.EnergyServiceResource GetEnergyServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEnergyServicesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEnergyServicesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource> GetEnergyService(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.EnergyServiceResource>> GetEnergyServiceAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EnergyServices.EnergyServiceCollection GetEnergyServices() { throw null; }
    }
    public partial class MockableEnergyServicesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEnergyServicesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameAvailabilityResult> CheckNameAvailabilityLocation(Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameAvailabilityResult>> CheckNameAvailabilityLocationAsync(Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EnergyServices.EnergyServiceResource> GetEnergyServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EnergyServices.EnergyServiceResource> GetEnergyServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EnergyServices.Models
{
    public static partial class ArmEnergyServicesModelFactory
    {
        public static Azure.ResourceManager.EnergyServices.Models.DataPartition DataPartition(string name = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.EnergyServices.Models.DataPartitionsListResult DataPartitionsListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EnergyServices.Models.DataPartition> dataPartitionInfo = null) { throw null; }
        public static Azure.ResourceManager.EnergyServices.EnergyServiceData EnergyServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EnergyServices.Models.EnergyServiceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameAvailabilityResult EnergyServiceNameAvailabilityResult(bool? nameAvailable = default(bool?), Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason? reason = default(Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.EnergyServices.Models.EnergyServiceProperties EnergyServiceProperties(string dnsName = null, Azure.ResourceManager.EnergyServices.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EnergyServices.Models.ProvisioningState?), string authAppId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EnergyServices.Models.DataPartitionName> dataPartitionNames = null) { throw null; }
    }
    public partial class DataPartition
    {
        internal DataPartition() { }
        public string Name { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class DataPartitionAddOrRemoveContent
    {
        public DataPartitionAddOrRemoveContent() { }
        public string DataPartitionName { get { throw null; } set { } }
    }
    public partial class DataPartitionName
    {
        public DataPartitionName() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class DataPartitionsListResult
    {
        internal DataPartitionsListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EnergyServices.Models.DataPartition> DataPartitionInfo { get { throw null; } }
    }
    public partial class EnergyServiceNameAvailabilityContent
    {
        public EnergyServiceNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class EnergyServiceNameAvailabilityResult
    {
        internal EnergyServiceNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnergyServiceNameUnavailableReason : System.IEquatable<Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnergyServiceNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason left, Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason left, Azure.ResourceManager.EnergyServices.Models.EnergyServiceNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnergyServicePatch
    {
        public EnergyServicePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class EnergyServiceProperties
    {
        public EnergyServiceProperties() { }
        public string AuthAppId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EnergyServices.Models.DataPartitionName> DataPartitionNames { get { throw null; } }
        public string DnsName { get { throw null; } }
        public Azure.ResourceManager.EnergyServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.EnergyServices.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EnergyServices.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EnergyServices.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EnergyServices.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EnergyServices.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EnergyServices.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EnergyServices.Models.ProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.EnergyServices.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EnergyServices.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EnergyServices.Models.ProvisioningState left, Azure.ResourceManager.EnergyServices.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EnergyServices.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EnergyServices.Models.ProvisioningState left, Azure.ResourceManager.EnergyServices.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
