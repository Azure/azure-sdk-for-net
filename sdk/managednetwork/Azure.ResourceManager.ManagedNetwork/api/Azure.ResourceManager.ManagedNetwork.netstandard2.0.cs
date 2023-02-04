namespace Azure.ResourceManager.ManagedNetwork
{
    public partial class ManagedNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>, System.Collections.IEnumerable
    {
        protected ManagedNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedNetworkName, Azure.ResourceManager.ManagedNetwork.ManagedNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedNetworkName, Azure.ResourceManager.ManagedNetwork.ManagedNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> Get(string managedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> GetAll(int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> GetAllAsync(int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>> GetAsync(string managedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedNetworkData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.ManagedNetwork.Models.ConnectivityCollection Connectivity { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ManagedNetwork.Models.Scope Scope { get { throw null; } set { } }
    }
    public static partial class ManagedNetworkExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> GetManagedNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string managedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>> GetManagedNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string managedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource GetManagedNetworkGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource GetManagedNetworkPeeringPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource GetManagedNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.ManagedNetworkCollection GetManagedNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> GetManagedNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> GetManagedNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource> GetScopeAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scopeAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource>> GetScopeAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scopeAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource GetScopeAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.ScopeAssignmentCollection GetScopeAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class ManagedNetworkGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource>, System.Collections.IEnumerable
    {
        protected ManagedNetworkGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedNetworkGroupName, Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedNetworkGroupName, Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedNetworkGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedNetworkGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource> Get(string managedNetworkGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource> GetAll(int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource> GetAllAsync(int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource>> GetAsync(string managedNetworkGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedNetworkGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedNetworkGroupData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind? Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Subnets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Subscriptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualNetworks { get { throw null; } }
    }
    public partial class ManagedNetworkGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedNetworkGroupResource() { }
        public virtual Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedNetworkName, string managedNetworkGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedNetworkPeeringPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource>, System.Collections.IEnumerable
    {
        protected ManagedNetworkPeeringPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedNetworkPeeringPolicyName, Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedNetworkPeeringPolicyName, Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedNetworkPeeringPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedNetworkPeeringPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource> Get(string managedNetworkPeeringPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource> GetAll(int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource> GetAllAsync(int? top = default(int?), string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource>> GetAsync(string managedNetworkPeeringPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedNetworkPeeringPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedNetworkPeeringPolicyData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkPeeringPolicyProperties Properties { get { throw null; } set { } }
    }
    public partial class ManagedNetworkPeeringPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedNetworkPeeringPolicyResource() { }
        public virtual Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedNetworkName, string managedNetworkPeeringPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedNetworkResource() { }
        public virtual Azure.ResourceManager.ManagedNetwork.ManagedNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource> GetManagedNetworkGroup(string managedNetworkGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupResource>> GetManagedNetworkGroupAsync(string managedNetworkGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupCollection GetManagedNetworkGroups() { throw null; }
        public virtual Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyCollection GetManagedNetworkPeeringPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource> GetManagedNetworkPeeringPolicy(string managedNetworkPeeringPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyResource>> GetManagedNetworkPeeringPolicyAsync(string managedNetworkPeeringPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ManagedNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScopeAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource>, System.Collections.IEnumerable
    {
        protected ScopeAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scopeAssignmentName, Azure.ResourceManager.ManagedNetwork.ScopeAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scopeAssignmentName, Azure.ResourceManager.ManagedNetwork.ScopeAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scopeAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scopeAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource> Get(string scopeAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource>> GetAsync(string scopeAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScopeAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public ScopeAssignmentData() { }
        public string AssignedManagedNetwork { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ScopeAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScopeAssignmentResource() { }
        public virtual Azure.ResourceManager.ManagedNetwork.ScopeAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string scopeAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetwork.ScopeAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ManagedNetwork.ScopeAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ManagedNetwork.ScopeAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ManagedNetwork.Models
{
    public partial class ConnectivityCollection
    {
        internal ConnectivityCollection() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupData> Groups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyData> Peerings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectivityType : System.IEquatable<Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectivityType(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType HubAndSpokeTopology { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType MeshTopology { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType left, Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType left, Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedNetworkKind : System.IEquatable<Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedNetworkKind(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind Connectivity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind left, Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind left, Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ManagedNetworkModelFactory
    {
        public static Azure.ResourceManager.ManagedNetwork.Models.ConnectivityCollection ConnectivityCollection(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupData> groups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyData> peerings = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.ManagedNetworkData ManagedNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState?), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.ManagedNetwork.Models.Scope scope = null, Azure.ResourceManager.ManagedNetwork.Models.ConnectivityCollection connectivity = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.ManagedNetworkGroupData ManagedNetworkGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind? kind = default(Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkKind?), Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState?), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> managementGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> subscriptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> virtualNetworks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> subnets = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.ManagedNetworkPeeringPolicyData ManagedNetworkPeeringPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkPeeringPolicyProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.Models.ManagedNetworkPeeringPolicyProperties ManagedNetworkPeeringPolicyProperties(Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState?), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType connectivityType = default(Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType), Azure.Core.ResourceIdentifier hubId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> spokes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> mesh = null) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.Models.ResourceProperties ResourceProperties(Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.ScopeAssignmentData ScopeAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState?), Azure.ETag? etag = default(Azure.ETag?), string assignedManagedNetwork = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
    }
    public partial class ManagedNetworkPatch
    {
        public ManagedNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ManagedNetworkPeeringPolicyProperties : Azure.ResourceManager.ManagedNetwork.Models.ResourceProperties
    {
        public ManagedNetworkPeeringPolicyProperties(Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType connectivityType) { }
        public Azure.ResourceManager.ManagedNetwork.Models.ConnectivityType ConnectivityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HubId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Mesh { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Spokes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState left, Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState left, Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceProperties
    {
        public ResourceProperties() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ManagedNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class Scope
    {
        public Scope() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> ManagementGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Subnets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Subscriptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualNetworks { get { throw null; } }
    }
}
