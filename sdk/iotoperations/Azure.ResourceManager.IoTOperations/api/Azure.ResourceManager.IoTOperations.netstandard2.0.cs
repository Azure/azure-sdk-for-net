namespace Azure.ResourceManager.IoTOperations
{
    public partial class InstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.InstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.InstanceResource>, System.Collections.IEnumerable
    {
        protected InstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.InstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IoTOperations.InstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.InstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IoTOperations.InstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.InstanceResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.InstanceResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.InstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.InstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.InstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.InstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.InstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceData>
    {
        public InstanceData(Azure.Core.AzureLocation location, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel ReconciliationPolicy { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Solution { get { throw null; } set { } }
        public string TargetName { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.InstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.InstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.InstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.InstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InstanceResource() { }
        public virtual Azure.ResourceManager.IoTOperations.InstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> Update(Azure.ResourceManager.IoTOperations.Models.InstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> UpdateAsync(Azure.ResourceManager.IoTOperations.Models.InstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IoTOperationsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> GetInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.InstanceResource GetInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTOperations.InstanceCollection GetInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource> GetSolution(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource>> GetSolutionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.SolutionResource GetSolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTOperations.SolutionCollection GetSolutions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IoTOperations.SolutionResource> GetSolutions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.SolutionResource> GetSolutionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource> GetTarget(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource>> GetTargetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.TargetResource GetTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTOperations.TargetCollection GetTargets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IoTOperations.TargetResource> GetTargets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.TargetResource> GetTargetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SolutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.SolutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.SolutionResource>, System.Collections.IEnumerable
    {
        protected SolutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.SolutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IoTOperations.SolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.SolutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IoTOperations.SolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.SolutionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.SolutionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.SolutionResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.SolutionResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.SolutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.SolutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.SolutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.SolutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SolutionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.SolutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.SolutionData>
    {
        public SolutionData(Azure.Core.AzureLocation location, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.ComponentProperties> Components { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.SolutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.SolutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.SolutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.SolutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.SolutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.SolutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.SolutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SolutionResource() { }
        public virtual Azure.ResourceManager.IoTOperations.SolutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource> Update(Azure.ResourceManager.IoTOperations.Models.SolutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource>> UpdateAsync(Azure.ResourceManager.IoTOperations.Models.SolutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.TargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.TargetResource>, System.Collections.IEnumerable
    {
        protected TargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.TargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IoTOperations.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.TargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.IoTOperations.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.TargetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.TargetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.TargetResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.TargetResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.TargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.TargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.TargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.TargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TargetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.TargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.TargetData>
    {
        public TargetData(Azure.Core.AzureLocation location, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.ComponentProperties> Components { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel ReconciliationPolicy { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.TopologiesProperties> Topologies { get { throw null; } }
        public string Version { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.TargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.TargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.TargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.TargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.TargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.TargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.TargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TargetResource() { }
        public virtual Azure.ResourceManager.IoTOperations.TargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource> Update(Azure.ResourceManager.IoTOperations.Models.TargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource>> UpdateAsync(Azure.ResourceManager.IoTOperations.Models.TargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IoTOperations.Mocking
{
    public partial class MockableIoTOperationsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableIoTOperationsArmClient() { }
        public virtual Azure.ResourceManager.IoTOperations.InstanceResource GetInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.SolutionResource GetSolutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.TargetResource GetTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableIoTOperationsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIoTOperationsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstance(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> GetInstanceAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.InstanceCollection GetInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource> GetSolution(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.SolutionResource>> GetSolutionAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.SolutionCollection GetSolutions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource> GetTarget(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.TargetResource>> GetTargetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.TargetCollection GetTargets() { throw null; }
    }
    public partial class MockableIoTOperationsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIoTOperationsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.SolutionResource> GetSolutions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.SolutionResource> GetSolutionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.TargetResource> GetTargets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.TargetResource> GetTargetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IoTOperations.Models
{
    public static partial class ArmIoTOperationsModelFactory
    {
        public static Azure.ResourceManager.IoTOperations.InstanceData InstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null, string scope = null, string solution = null, string targetName = null, Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel reconciliationPolicy = null, string version = null, Azure.ResourceManager.IoTOperations.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.SolutionData SolutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.Models.ComponentProperties> components = null, string version = null, Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.TargetData TargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.Models.ComponentProperties> components = null, string scope = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.Models.TopologiesProperties> topologies = null, Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel reconciliationPolicy = null, string version = null, Azure.ResourceManager.IoTOperations.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ProvisioningState?)) { throw null; }
    }
    public partial class BindingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BindingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BindingProperties>
    {
        public BindingProperties(System.Collections.Generic.IDictionary<string, System.BinaryData> config, string provider, string role) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Config { get { throw null; } }
        public string Provider { get { throw null; } set { } }
        public string Role { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.BindingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BindingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BindingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BindingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BindingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BindingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BindingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ComponentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ComponentProperties>
    {
        public ComponentProperties(string name, string componentPropertiesType) { }
        public string ComponentPropertiesType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Dependencies { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.ComponentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ComponentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ComponentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.ComponentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ComponentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ComponentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ComponentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>
    {
        public ExtendedLocation(string name, string extendedLocationType) { }
        public string ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.ExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.ExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.InstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstancePatch>
    {
        public InstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.InstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.InstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.InstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.InstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Reconciling { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.ProvisioningState left, Azure.ResourceManager.IoTOperations.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.ProvisioningState left, Azure.ResourceManager.IoTOperations.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReconciliationPolicy : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReconciliationPolicy(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicy Periodic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicy left, Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicy left, Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReconciliationPolicyModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel>
    {
        public ReconciliationPolicyModel(Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicy policyType) { }
        public string Interval { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicy PolicyType { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ReconciliationPolicyModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState left, Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState left, Azure.ResourceManager.IoTOperations.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SolutionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SolutionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SolutionPatch>
    {
        public SolutionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.SolutionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SolutionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SolutionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.SolutionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SolutionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SolutionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SolutionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TargetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TargetPatch>
    {
        public TargetPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.TargetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TargetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TargetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.TargetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TargetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TargetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TargetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopologiesProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TopologiesProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TopologiesProperties>
    {
        public TopologiesProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.BindingProperties> Bindings { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.TopologiesProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TopologiesProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TopologiesProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.TopologiesProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TopologiesProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TopologiesProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TopologiesProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
