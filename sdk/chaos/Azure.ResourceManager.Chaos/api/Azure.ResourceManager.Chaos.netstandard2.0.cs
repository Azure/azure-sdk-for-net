namespace Azure.ResourceManager.Chaos
{
    public partial class ChaosCapabilityTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>, System.Collections.IEnumerable
    {
        protected ChaosCapabilityTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> Get(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>> GetAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> GetIfExists(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>> GetIfExistsAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosCapabilityTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public ChaosCapabilityTypeData() { }
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
    public partial class ChaosCapabilityTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosCapabilityTypeResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string targetTypeName, string capabilityTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosExperimentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentResource>, System.Collections.IEnumerable
    {
        protected ChaosExperimentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosExperimentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string experimentName, Azure.ResourceManager.Chaos.ChaosExperimentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosExperimentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string experimentName, Azure.ResourceManager.Chaos.ChaosExperimentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> Get(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetAll(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetAllAsync(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetIfExists(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetIfExistsAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosExperimentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosExperimentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosExperimentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ChaosExperimentData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> steps, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> selectors) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> Selectors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> Steps { get { throw null; } }
    }
    public partial class ChaosExperimentExecutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>, System.Collections.IEnumerable
    {
        protected ChaosExperimentExecutionCollection() { }
        public virtual Azure.Response<bool> Exists(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> Get(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>> GetAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> GetIfExists(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>> GetIfExistsAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosExperimentExecutionData : Azure.ResourceManager.Models.ResourceData
    {
        internal ChaosExperimentExecutionData() { }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? StoppedOn { get { throw null; } }
    }
    public partial class ChaosExperimentExecutionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosExperimentExecutionResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string experimentName, string executionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails> ExecutionDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails>> ExecutionDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosExperimentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosExperimentResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string experimentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource> GetChaosExperimentExecution(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource>> GetChaosExperimentExecutionAsync(string executionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentExecutionCollection GetChaosExperimentExecutions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosExperimentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosExperimentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.Models.ChaosExperimentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ChaosExtensions
    {
        public static Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource GetChaosCapabilityTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetChaosExperimentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource GetChaosExperimentExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentResource GetChaosExperimentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentCollection GetChaosExperiments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperimentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> GetChaosTarget(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetChaosTargetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource GetChaosTargetCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetResource GetChaosTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetCollection GetChaosTargets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parentProviderNamespace, string parentResourceType, string parentResourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetChaosTargetType(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetChaosTargetTypeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeResource GetChaosTargetTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeCollection GetChaosTargetTypes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Chaos.Models.ChaosOperationStatus> GetOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.Models.ChaosOperationStatus>> GetOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosTargetCapabilityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource>, System.Collections.IEnumerable
    {
        protected ChaosTargetCapabilityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string capabilityName, Azure.ResourceManager.Chaos.ChaosTargetCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string capabilityName, Azure.ResourceManager.Chaos.ChaosTargetCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource> Get(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource>> GetAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource> GetIfExists(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource>> GetIfExistsAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosTargetCapabilityData : Azure.ResourceManager.Models.ResourceData
    {
        public ChaosTargetCapabilityData() { }
        public string Description { get { throw null; } }
        public string ParametersSchema { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string TargetType { get { throw null; } }
        public string Urn { get { throw null; } }
    }
    public partial class ChaosTargetCapabilityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosTargetCapabilityResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetCapabilityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, string capabilityName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosTargetCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosTargetCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetResource>, System.Collections.IEnumerable
    {
        protected ChaosTargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.Chaos.ChaosTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.Chaos.ChaosTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> Get(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosTargetResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosTargetResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetResource> GetIfExists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetIfExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosTargetData : Azure.ResourceManager.Models.ResourceData
    {
        public ChaosTargetData(System.Collections.Generic.IDictionary<string, System.BinaryData> properties) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } }
    }
    public partial class ChaosTargetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosTargetResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetCapabilityCollection GetChaosTargetCapabilities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource> GetChaosTargetCapability(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource>> GetChaosTargetCapabilityAsync(string capabilityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Chaos.ChaosTargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Chaos.ChaosTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChaosTargetTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>, System.Collections.IEnumerable
    {
        protected ChaosTargetTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> Get(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetIfExists(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetIfExistsAsync(string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChaosTargetTypeData : Azure.ResourceManager.Models.ResourceData
    {
        public ChaosTargetTypeData() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string PropertiesSchema { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResourceTypes { get { throw null; } }
    }
    public partial class ChaosTargetTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChaosTargetTypeResource() { }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string locationName, string targetTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource> GetChaosCapabilityType(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource>> GetChaosCapabilityTypeAsync(string capabilityTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityTypeCollection GetChaosCapabilityTypes() { throw null; }
    }
}
namespace Azure.ResourceManager.Chaos.Mocking
{
    public partial class MockableChaosArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosArmClient() { }
        public virtual Azure.ResourceManager.Chaos.ChaosCapabilityTypeResource GetChaosCapabilityTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentExecutionResource GetChaosExperimentExecutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentResource GetChaosExperimentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetCapabilityResource GetChaosTargetCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetResource GetChaosTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeResource GetChaosTargetTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableChaosResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiment(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosExperimentResource>> GetChaosExperimentAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosExperimentCollection GetChaosExperiments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource> GetChaosTarget(string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetResource>> GetChaosTargetAsync(string parentProviderNamespace, string parentResourceType, string parentResourceName, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetCollection GetChaosTargets(string parentProviderNamespace, string parentResourceType, string parentResourceName) { throw null; }
    }
    public partial class MockableChaosSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChaosSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperiments(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Chaos.ChaosExperimentResource> GetChaosExperimentsAsync(bool? running = default(bool?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource> GetChaosTargetType(string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.ChaosTargetTypeResource>> GetChaosTargetTypeAsync(string locationName, string targetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Chaos.ChaosTargetTypeCollection GetChaosTargetTypes(string locationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Chaos.Models.ChaosOperationStatus> GetOperationStatus(Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Chaos.Models.ChaosOperationStatus>> GetOperationStatusAsync(Azure.Core.AzureLocation location, string asyncOperationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Chaos.Models
{
    public static partial class ArmChaosModelFactory
    {
        public static Azure.ResourceManager.Chaos.ChaosCapabilityTypeData ChaosCapabilityTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string publisher = null, string targetType = null, string displayName = null, string description = null, string parametersSchema = null, string urn = null, string kind = null, System.Collections.Generic.IEnumerable<string> azureRbacActions = null, System.Collections.Generic.IEnumerable<string> azureRbacDataActions = null, string runtimeKind = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosErrorResult ChaosErrorResult(Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentData ChaosExperimentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState? provisioningState = default(Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentStep> steps = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetSelector> selectors = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosExperimentExecutionData ChaosExperimentExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosOperationStatus ChaosOperationStatus(Azure.ResponseError error = null, string id = null, string name = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string status = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetCapabilityData ChaosTargetCapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string publisher = null, string targetType = null, string description = null, string parametersSchema = null, string urn = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetData ChaosTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, System.BinaryData> properties = null) { throw null; }
        public static Azure.ResourceManager.Chaos.ChaosTargetTypeData ChaosTargetTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string displayName = null, string description = null, string propertiesSchema = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExecutionActionStatus ExecutionActionStatus(string actionName = null, System.Guid? actionId = default(System.Guid?), string status = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties> targets = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExecutionBranchStatus ExecutionBranchStatus(string branchName = null, string branchId = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ExecutionActionStatus> actions = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExecutionStepStatus ExecutionStepStatus(string stepName = null, string stepId = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ExecutionBranchStatus> branches = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError ExperimentExecutionActionTargetDetailsError(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties ExperimentExecutionActionTargetDetailsProperties(string status = null, string target = null, System.DateTimeOffset? targetFailedOn = default(System.DateTimeOffset?), System.DateTimeOffset? targetCompletedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsError error = null) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentExecutionDetails ExperimentExecutionDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string status = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?), string failureReason = null, System.DateTimeOffset? lastActionOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ExecutionStepStatus> runInformationSteps = null) { throw null; }
    }
    public partial class ChaosErrorResult
    {
        internal ChaosErrorResult() { }
        public Azure.ResponseError Error { get { throw null; } }
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
    public partial class ChaosExperimentPatch
    {
        public ChaosExperimentPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
    }
    public partial class ChaosExperimentStep
    {
        public ChaosExperimentStep(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch> branches) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosExperimentBranch> Branches { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ChaosOperationStatus : Azure.ResourceManager.Chaos.Models.ChaosErrorResult
    {
        internal ChaosOperationStatus() { }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public abstract partial class ChaosTargetFilter
    {
        protected ChaosTargetFilter() { }
    }
    public partial class ChaosTargetListSelector : Azure.ResourceManager.Chaos.Models.ChaosTargetSelector
    {
        public ChaosTargetListSelector(string id, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ChaosTargetReference> targets) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ChaosTargetReference> Targets { get { throw null; } }
    }
    public partial class ChaosTargetQuerySelector : Azure.ResourceManager.Chaos.Models.ChaosTargetSelector
    {
        public ChaosTargetQuerySelector(string id, string queryString, System.Collections.Generic.IEnumerable<string> subscriptionIds) : base (default(string)) { }
        public string QueryString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SubscriptionIds { get { throw null; } }
    }
    public partial class ChaosTargetReference
    {
        public ChaosTargetReference(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType referenceType, Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChaosTargetReferenceType : System.IEquatable<Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChaosTargetReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType ChaosTarget { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType left, Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType left, Azure.ResourceManager.Chaos.Models.ChaosTargetReferenceType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ContinuousActionKeyValuePair
    {
        public ContinuousActionKeyValuePair(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ExecutionActionStatus
    {
        internal ExecutionActionStatus() { }
        public System.Guid? ActionId { get { throw null; } }
        public string ActionName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ExperimentExecutionActionTargetDetailsProperties> Targets { get { throw null; } }
    }
    public partial class ExecutionBranchStatus
    {
        internal ExecutionBranchStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ExecutionActionStatus> Actions { get { throw null; } }
        public string BranchId { get { throw null; } }
        public string BranchName { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ExecutionStepStatus
    {
        internal ExecutionStepStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ExecutionBranchStatus> Branches { get { throw null; } }
        public string Status { get { throw null; } }
        public string StepId { get { throw null; } }
        public string StepName { get { throw null; } }
    }
    public partial class ExperimentContinuousAction : Azure.ResourceManager.Chaos.Models.ChaosExperimentAction
    {
        public ExperimentContinuousAction(string name, System.TimeSpan duration, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ContinuousActionKeyValuePair> parameters, string selectorId) : base (default(string)) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ContinuousActionKeyValuePair> Parameters { get { throw null; } }
        public string SelectorId { get { throw null; } set { } }
    }
    public partial class ExperimentDelayAction : Azure.ResourceManager.Chaos.Models.ChaosExperimentAction
    {
        public ExperimentDelayAction(string name, System.TimeSpan duration) : base (default(string)) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
    }
    public partial class ExperimentDiscreteAction : Azure.ResourceManager.Chaos.Models.ChaosExperimentAction
    {
        public ExperimentDiscreteAction(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Chaos.Models.ContinuousActionKeyValuePair> parameters, string selectorId) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Chaos.Models.ContinuousActionKeyValuePair> Parameters { get { throw null; } }
        public string SelectorId { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Chaos.Models.ExecutionStepStatus> RunInformationSteps { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? StoppedOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExperimentProvisioningState : System.IEquatable<Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExperimentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState left, Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState left, Azure.ResourceManager.Chaos.Models.ExperimentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
