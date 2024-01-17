namespace Azure.ResourceManager.Chaos
{
    public partial class CapabilityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.CapabilityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.CapabilityResource>, System.Collections.IEnumerable
    {
        protected CapabilityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.CapabilityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capabilityName, Azure.ResourceManager.Chaos.CapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.CapabilityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capabilityName, Azure.ResourceManager.Chaos.CapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.CapabilityResource> Get(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.CapabilityResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.CapabilityResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.CapabilityResource>> GetAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.CapabilityResource> GetIfExists(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.CapabilityResource>> GetIfExistsAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.CapabilityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.CapabilityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.CapabilityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.CapabilityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapabilityData : Azure.ResourceManager.Models.ResourceData
    {
        public CapabilityData() { }
        public string Description { get { throw null; } }
        public string ParametersSchema { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string TargetType { get { throw null; } }
        public string Urn { get { throw null; } }
    }
    public partial class CapabilityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapabilityResource() { }
        public virtual Azure.ResourceManager.Chaos.CapabilityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, string capabilityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.CapabilityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.CapabilityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.CapabilityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.CapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.CapabilityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.CapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapabilityTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.CapabilityTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.CapabilityTypeResource>, System.Collections.IEnumerable
    {
        protected CapabilityTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.CapabilityTypeResource> Get(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.CapabilityTypeResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.CapabilityTypeResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.CapabilityTypeResource>> GetAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.CapabilityTypeResource> GetIfExists(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.CapabilityTypeResource>> GetIfExistsAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.CapabilityTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.CapabilityTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.CapabilityTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.CapabilityTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapabilityTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public CapabilityTypeData() { }
        public System.Collections.Generic.IList<string> AzureRbacActions { get { throw null; } }
        public System.Collections.Generic.IList<string> AzureRbacDataActions { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ParametersSchema { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string RuntimeKind { get { throw null; } }
        public string TargetType { get { throw null; } }
        public string Urn { get { throw null; } }
    }
    public partial class CapabilityTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapabilityTypeResource() { }
        public virtual Azure.ResourceManager.Chaos.CapabilityTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string targetTypeName, string capabilityTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.CapabilityTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.CapabilityTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ChaosExtensions
    {
        public static Azure.ResourceManager.Chaos.CapabilityResource GetCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.CapabilityTypeResource GetCapabilityTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ExperimentResource> GetExperiment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ExperimentResource>> GetExperimentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ExperimentExecutionResource GetExperimentExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ExperimentResource GetExperimentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ExperimentCollection GetExperiments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Chaos.ExperimentResource> GetExperiments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Chaos.ExperimentResource> GetExperimentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.Models.OperationStatus> GetOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.Models.OperationStatus>> GetOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.TargetResource> GetTarget(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.TargetResource>> GetTargetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.TargetResource GetTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.TargetCollection GetTargets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.TargetTypeResource> GetTargetType(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.TargetTypeResource>> GetTargetTypeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.TargetTypeResource GetTargetTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.TargetTypeCollection GetTargetTypes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName) { throw null; }
    }
    public partial class ExperimentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ExperimentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ExperimentResource>, System.Collections.IEnumerable
    {
        protected ExperimentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ExperimentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string experimentName, Azure.ResourceManager.Chaos.ExperimentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ExperimentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string experimentName, Azure.ResourceManager.Chaos.ExperimentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ExperimentResource> Get(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ExperimentResource> GetAll(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ExperimentResource> GetAllAsync(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ExperimentResource>> GetAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ExperimentResource> GetIfExists(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ExperimentResource>> GetIfExistsAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ExperimentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ExperimentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ExperimentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ExperimentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExperimentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ExperimentData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> steps, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> selectors) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> Selectors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> Steps { get { throw null; } }
    }
    public partial class ExperimentExecutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ExperimentExecutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ExperimentExecutionResource>, System.Collections.IEnumerable
    {
        protected ExperimentExecutionCollection() { }
        public virtual Azure.Response<bool> Exists(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ExperimentExecutionResource> Get(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ExperimentExecutionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ExperimentExecutionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ExperimentExecutionResource>> GetAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ExperimentExecutionResource> GetIfExists(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ExperimentExecutionResource>> GetIfExistsAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ExperimentExecutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ExperimentExecutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ExperimentExecutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ExperimentExecutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExperimentExecutionData : Azure.ResourceManager.Models.ResourceData
    {
        internal ExperimentExecutionData() { }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? StoppedOn { get { throw null; } }
    }
    public partial class ExperimentExecutionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExperimentExecutionResource() { }
        public virtual Azure.ResourceManager.Chaos.ExperimentExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string experimentName, string executionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails> ExecutionDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>> ExecutionDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ExperimentExecutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ExperimentExecutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExperimentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExperimentResource() { }
        public virtual Azure.ResourceManager.Chaos.ExperimentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string experimentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ExperimentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ExperimentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ExperimentExecutionResource> GetExperimentExecution(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ExperimentExecutionResource>> GetExperimentExecutionAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ExperimentExecutionCollection GetExperimentExecutions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ExperimentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ExperimentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ExperimentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ExperimentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.TargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.TargetResource>, System.Collections.IEnumerable
    {
        protected TargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.TargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.Chaos.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.TargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.Chaos.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.TargetResource> Get(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.TargetResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.TargetResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.TargetResource>> GetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.TargetResource> GetIfExists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.TargetResource>> GetIfExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.TargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.TargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.TargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.TargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TargetData : Azure.ResourceManager.Models.ResourceData
    {
        public TargetData(System.Collections.Generic.IDictionary<string, System.BinaryData> properties) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } }
    }
    public partial class TargetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TargetResource() { }
        public virtual Azure.ResourceManager.Chaos.TargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.TargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.TargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.CapabilityCollection GetCapabilities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.CapabilityResource> GetCapability(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.CapabilityResource>> GetCapabilityAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.TargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.TargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TargetTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.TargetTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.TargetTypeResource>, System.Collections.IEnumerable
    {
        protected TargetTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.TargetTypeResource> Get(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.TargetTypeResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.TargetTypeResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.TargetTypeResource>> GetAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.TargetTypeResource> GetIfExists(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.TargetTypeResource>> GetIfExistsAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.TargetTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.TargetTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.TargetTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.TargetTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TargetTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public TargetTypeData() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string PropertiesSchema { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResourceTypes { get { throw null; } }
    }
    public partial class TargetTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TargetTypeResource() { }
        public virtual Azure.ResourceManager.Chaos.TargetTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string targetTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.TargetTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.TargetTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.CapabilityTypeResource> GetCapabilityType(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.CapabilityTypeResource>> GetCapabilityTypeAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.CapabilityTypeCollection GetCapabilityTypes() { throw null; }
    }
}
namespace Azure.ResourceManager.Chaos.Mocking
{
    public partial class MockableChaosArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosArmClient() { }
        public virtual Azure.ResourceManager.Chaos.CapabilityResource GetCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.CapabilityTypeResource GetCapabilityTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ExperimentExecutionResource GetExperimentExecutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ExperimentResource GetExperimentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.TargetResource GetTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.TargetTypeResource GetTargetTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableChaosResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ExperimentResource> GetExperiment(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ExperimentResource>> GetExperimentAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ExperimentCollection GetExperiments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.TargetResource> GetTarget(string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.TargetResource>> GetTargetAsync(string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.TargetCollection GetTargets(string parentProviderNamespace, string parentResourceType, string parentResourceName) { throw null; }
    }
    public partial class MockableChaosSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ExperimentResource> GetExperiments(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ExperimentResource> GetExperimentsAsync(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.Models.OperationStatus> GetOperationStatus(Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.Models.OperationStatus>> GetOperationStatusAsync(Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.TargetTypeResource> GetTargetType(string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.TargetTypeResource>> GetTargetTypeAsync(string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.TargetTypeCollection GetTargetTypes(string locationName) { throw null; }
    }
}
namespace Azure.ResourceManager.Chaos.Models
{
    public partial class ActionStatus
    {
        internal ActionStatus() { }
        public string ActionId { get { throw null; } }
        public string ActionName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties> Targets { get { throw null; } }
    }
    public static partial class ArmChaosModelFactory
    {
        public static Azure.ResourceManager.Chaos.Models.ActionStatus ActionStatus(string actionName = null, string actionId = null, string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties> targets = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.BranchStatus BranchStatus(string branchName = null, string branchId = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ActionStatus> actions = null) { throw null; }
        public static Azure.ResourceManager.Chaos.CapabilityData CapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string targetType = null, string description = null, string parametersSchema = null, string urn = null) { throw null; }
        public static Azure.ResourceManager.Chaos.CapabilityTypeData CapabilityTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, System.Collections.Generic.IEnumerable<string> azureRbacActions = null, System.Collections.Generic.IEnumerable<string> azureRbacDataActions = null, string runtimeKind = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ErrorResponse ErrorResponse(Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ExperimentData ExperimentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Chaos.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> steps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> selectors = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError ExperimentExecutionActionTargetDetailsError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties ExperimentExecutionActionTargetDetailsProperties(string status = null, string target = null, System.DateTimeOffset? targetFailedOn = default(System.DateTimeOffset?), System.DateTimeOffset? targetCompletedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ExperimentExecutionData ExperimentExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails ExperimentExecutionDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?), string failureReason = null, System.DateTimeOffset? lastActionOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.StepStatus> runInformationSteps = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.OperationStatus OperationStatus(Azure.ResponseError error = null, string id = null, string name = null, string startTime = null, string endTime = null, string status = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.StepStatus StepStatus(string stepName = null, string stepId = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.BranchStatus> branches = null) { throw null; }
        public static Azure.ResourceManager.Chaos.TargetData TargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.TargetTypeData TargetTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string displayName = null, string description = null, string propertiesSchema = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
    }
    public partial class BranchStatus
    {
        internal BranchStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ActionStatus> Actions { get { throw null; } }
        public string BranchId { get { throw null; } }
        public string BranchName { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public abstract partial class ChaosExperimentAction
    {
        protected ChaosExperimentAction(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class ChaosExperimentBranch
    {
        public ChaosExperimentBranch(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosExperimentAction> Actions { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ChaosExperimentStep
    {
        public ChaosExperimentStep(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch> branches) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch> Branches { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public abstract partial class ChaosTargetFilter
    {
        protected ChaosTargetFilter() { }
    }
    public partial class ChaosTargetListSelector : Azure.ResourceManager.Chaos.Models.ChaosTargetSelector
    {
        public ChaosTargetListSelector(string id, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.TargetReference> targets) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.TargetReference> Targets { get { throw null; } }
    }
    public partial class ChaosTargetQuerySelector : Azure.ResourceManager.Chaos.Models.ChaosTargetSelector
    {
        public ChaosTargetQuerySelector(string id, string queryString, System.Collections.Generic.IEnumerable<string> subscriptionIds) : base (default(string)) { }
        public string QueryString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
    }
    public abstract partial class ChaosTargetSelector
    {
        protected ChaosTargetSelector(string id) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.Chaos.Models.ChaosTargetFilter Filter { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
    }
    public partial class ChaosTargetSimpleFilter : Azure.ResourceManager.Chaos.Models.ChaosTargetFilter
    {
        public ChaosTargetSimpleFilter() { }
        public System.Collections.Generic.IList<string> ParametersZones { get { throw null; } }
    }
    public partial class ContinuousAction : Azure.ResourceManager.Chaos.Models.ChaosExperimentAction
    {
        public ContinuousAction(string name, System.TimeSpan duration, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.KeyValuePair> parameters, string selectorId) : base (default(string)) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.KeyValuePair> Parameters { get { throw null; } }
        public string SelectorId { get { throw null; } set { } }
    }
    public partial class DelayAction : Azure.ResourceManager.Chaos.Models.ChaosExperimentAction
    {
        public DelayAction(string name, System.TimeSpan duration) : base (default(string)) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
    }
    public partial class DiscreteAction : Azure.ResourceManager.Chaos.Models.ChaosExperimentAction
    {
        public DiscreteAction(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.KeyValuePair> parameters, string selectorId) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.KeyValuePair> Parameters { get { throw null; } }
        public string SelectorId { get { throw null; } set { } }
    }
    public partial class ErrorResponse
    {
        internal ErrorResponse() { }
        public Azure.ResponseError Error { get { throw null; } }
    }
    public partial class ExperimentExecutionActionTargetDetailsError
    {
        internal ExperimentExecutionActionTargetDetailsError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ExperimentExecutionActionTargetDetailsProperties
    {
        internal ExperimentExecutionActionTargetDetailsProperties() { }
        public Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError Error { get { throw null; } }
        public string Status { get { throw null; } }
        public string Target { get { throw null; } }
        public System.DateTimeOffset? TargetCompletedOn { get { throw null; } }
        public System.DateTimeOffset? TargetFailedOn { get { throw null; } }
    }
    public partial class ExperimentExecutionDetails : Azure.ResourceManager.Models.ResourceData
    {
        internal ExperimentExecutionDetails() { }
        public string FailureReason { get { throw null; } }
        public System.DateTimeOffset? LastActionOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.StepStatus> RunInformationSteps { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? StoppedOn { get { throw null; } }
    }
    public partial class ExperimentPatch
    {
        public ExperimentPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
    }
    public partial class KeyValuePair
    {
        public KeyValuePair(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class OperationStatus : Azure.ResourceManager.Chaos.Models.ErrorResponse
    {
        internal OperationStatus() { }
        public string EndTime { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string StartTime { get { throw null; } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ProvisioningState left, Azure.ResourceManager.Chaos.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ProvisioningState left, Azure.ResourceManager.Chaos.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StepStatus
    {
        internal StepStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.BranchStatus> Branches { get { throw null; } }
        public string Status { get { throw null; } }
        public string StepId { get { throw null; } }
        public string StepName { get { throw null; } }
    }
    public partial class TargetReference
    {
        public TargetReference(Azure.ResourceManager.Chaos.Models.TargetReferenceType referenceType, string id) { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.TargetReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetReferenceType : System.IEquatable<Azure.ResourceManager.Chaos.Models.TargetReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.TargetReferenceType ChaosTarget { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.TargetReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.TargetReferenceType left, Azure.ResourceManager.Chaos.Models.TargetReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.TargetReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.TargetReferenceType left, Azure.ResourceManager.Chaos.Models.TargetReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
