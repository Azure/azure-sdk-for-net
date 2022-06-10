namespace Azure.ResourceManager.NetworkFunction
{
    public partial class AzureTrafficCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>, System.Collections.IEnumerable
    {
        protected AzureTrafficCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureTrafficCollectorName, Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureTrafficCollectorName, Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> Get(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> GetAsync(string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureTrafficCollectorData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AzureTrafficCollectorData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkFunction.CollectorPolicyData> CollectorPolicies { get { throw null; } }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualHubId { get { throw null; } }
    }
    public partial class AzureTrafficCollectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureTrafficCollectorResource() { }
        public virtual Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureTrafficCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkFunction.CollectorPolicyCollection GetCollectorPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> GetCollectorPolicy(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> GetCollectorPolicyAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> Update(Azure.ResourceManager.NetworkFunction.Models.AzureTrafficCollectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> UpdateAsync(Azure.ResourceManager.NetworkFunction.Models.AzureTrafficCollectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CollectorPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>, System.Collections.IEnumerable
    {
        protected CollectorPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string collectorPolicyName, Azure.ResourceManager.NetworkFunction.CollectorPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string collectorPolicyName, Azure.ResourceManager.NetworkFunction.CollectorPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> Get(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> GetAsync(string collectorPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CollectorPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public CollectorPolicyData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkFunction.Models.EmissionPoliciesPropertiesFormat> EmissionPolicies { get { throw null; } }
        public Azure.ETag? Etag { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.IngestionPolicyPropertiesFormat IngestionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkFunction.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class CollectorPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CollectorPolicyResource() { }
        public virtual Azure.ResourceManager.NetworkFunction.CollectorPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureTrafficCollectorName, string collectorPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkFunction.CollectorPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkFunction.CollectorPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkFunction.CollectorPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NetworkFunctionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAzureTrafficCollector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource>> GetAzureTrafficCollectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureTrafficCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource GetAzureTrafficCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorCollection GetAzureTrafficCollectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAzureTrafficCollectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.AzureTrafficCollectorResource> GetAzureTrafficCollectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.CollectorPolicyResource GetCollectorPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkFunction.Models.Operation> GetOperationsNetworkFunctions(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkFunction.Models.Operation> GetOperationsNetworkFunctionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkFunction.Models
{
    public partial class AzureTrafficCollectorPatch
    {
        public AzureTrafficCollectorPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DestinationType : System.IEquatable<Azure.ResourceManager.NetworkFunction.Models.DestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DestinationType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.DestinationType AzureMonitor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkFunction.Models.DestinationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.DestinationType left, Azure.ResourceManager.NetworkFunction.Models.DestinationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.DestinationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.DestinationType left, Azure.ResourceManager.NetworkFunction.Models.DestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmissionPoliciesPropertiesFormat
    {
        public EmissionPoliciesPropertiesFormat() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkFunction.Models.EmissionPolicyDestination> EmissionDestinations { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.EmissionType? EmissionType { get { throw null; } set { } }
    }
    public partial class EmissionPolicyDestination
    {
        public EmissionPolicyDestination() { }
        public Azure.ResourceManager.NetworkFunction.Models.DestinationType? DestinationType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmissionType : System.IEquatable<Azure.ResourceManager.NetworkFunction.Models.EmissionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmissionType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.EmissionType Ipfix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkFunction.Models.EmissionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.EmissionType left, Azure.ResourceManager.NetworkFunction.Models.EmissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.EmissionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.EmissionType left, Azure.ResourceManager.NetworkFunction.Models.EmissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IngestionPolicyPropertiesFormat
    {
        public IngestionPolicyPropertiesFormat() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkFunction.Models.IngestionSourcesPropertiesFormat> IngestionSources { get { throw null; } }
        public Azure.ResourceManager.NetworkFunction.Models.IngestionType? IngestionType { get { throw null; } set { } }
    }
    public partial class IngestionSourcesPropertiesFormat
    {
        public IngestionSourcesPropertiesFormat() { }
        public string ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkFunction.Models.SourceType? SourceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionType : System.IEquatable<Azure.ResourceManager.NetworkFunction.Models.IngestionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.IngestionType Ipfix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkFunction.Models.IngestionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.IngestionType left, Azure.ResourceManager.NetworkFunction.Models.IngestionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.IngestionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.IngestionType left, Azure.ResourceManager.NetworkFunction.Models.IngestionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.NetworkFunction.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkFunction.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkFunction.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkFunction.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkFunction.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkFunction.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.ProvisioningState left, Azure.ResourceManager.NetworkFunction.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.ProvisioningState left, Azure.ResourceManager.NetworkFunction.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceType : System.IEquatable<Azure.ResourceManager.NetworkFunction.Models.SourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkFunction.Models.SourceType Resource { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkFunction.Models.SourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkFunction.Models.SourceType left, Azure.ResourceManager.NetworkFunction.Models.SourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkFunction.Models.SourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkFunction.Models.SourceType left, Azure.ResourceManager.NetworkFunction.Models.SourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
